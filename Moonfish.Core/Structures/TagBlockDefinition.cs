using Moonfish.Definitions;
using Moonfish.Graphics;
using Moonfish.Tags;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Moonfish
{
    public interface ISerialize
    {
        void Serialize(Stream output, ref int next_address);
    }

    public class TagBlockList<TTagBlock> : FixedArray<TTagBlock>, IField, ISerialize
        where TTagBlock : TagBlock, IMeta, new()
    {
        void IField.SetFieldData(byte[] field_data, IStructure caller)
        {
            count_ = BitConverter.ToInt32(field_data, 0);
            first_element_address_ = BitConverter.ToInt32(field_data, 4);
            for (int i = 0; i < count_; ++i)
            {
                TTagBlock child = new TTagBlock();
                child.this_pointer = first_element_address_ + i * child.Size;
                this.Add(child);
            }
        }

        void ISerialize.Serialize(Stream output, ref int next_address)
        {
            if (Count > 0)
            {
                output.Position = next_address;
                this.first_element_address_ = output.Pad(this[0].Alignment);
                this.count_ = Count;

                this.parent.SetField(this);

                var item_size = this[0].Size;
                var reserve_buffer = new byte[this.count_ * item_size];
                output.Write(reserve_buffer, 0, reserve_buffer.Length);

                next_address = first_element_address_ + this.count_ * item_size;
                for (int i = 0; i < this.count_; i++)
                {
                    output.Position = this.first_element_address_ + i * item_size;
                    this[i].Serialize(output, ref next_address);
                }
            }
            else
            {
                this.first_element_address_ = 0;
                this.count_ = 0;
                return;
            }
        }
    }

    public abstract class TagBlock : IStructure, IMeta,
        IEnumerable<TagBlockField>, IEnumerable<StringID>, IEnumerable<TagIdent>, 
        IEnumerable<TagPointer>
    {
        const int DefaultAlignment = 4;
        protected readonly int size;

        internal int Alignment { get { return alignment; } }
        protected readonly int alignment = DefaultAlignment;
        protected MemoryStream memory_;
        protected readonly List<TagBlockField> fixed_fields;

        public virtual void SetDefinitionData(IDefinition definition)
        {
            var buffer = definition.ToArray();
            this.memory_.Position = 0;
            this.memory_.Write(buffer, 0, buffer.Length);

            for (var i = 0; i < fixed_fields.Count; i++)
            {
                byte[] field_data = new byte[fixed_fields[i].Object.SizeOfField];
                this.memory_.Position = fixed_fields[i].FieldOffset;
                this.memory_.Read(field_data, 0, field_data.Length);
                fixed_fields[i].Object.SetFieldData(field_data);
            }
        }
        public virtual T GetDefinition<T>() where T : IDefinition, new()
        {
            var definition = new T();
            definition.FromArray(this.memory_.ToArray());
            return definition;
        }
        public void Parse(Stream map)
        {
            map.Position = this.this_pointer;
            map.Read(this.memory_.GetBuffer(), 0, this.size);
            foreach (var field in fixed_fields)
            {
                byte[] field_data = new byte[field.Object.SizeOfField];
                this.memory_.Position = field.FieldOffset;
                this.memory_.Read(field_data, 0, field_data.Length);
                field.Object.SetFieldData(field_data, this);

                /* if the field is a fixed array type I want to load all the values into it.
                 * TagBlockList<T>, ByteArray, ShortArray, ResourceArray... etc all at once
                 * */

                var nested_tagblock = field.Object as IEnumerable<IMeta>;
                if (nested_tagblock != null)
                {
                    foreach (var item in nested_tagblock)
                    {
                        item.CopyFrom(map);
                    }
                } 
                var fixed_meta = field.Object as IMeta;
                if (fixed_meta != null)
                {
                    fixed_meta.CopyFrom(map);
                } 
                var nested_resource = field.Object as IResource;
                if (nested_resource != null)
                {
                    nested_resource.CopyFrom(map);
                }
            }
        }


        public void Serialize(Stream output)
        {
            var offset = (int)output.Position + this.size;
            Serialize(output, ref offset);
        }

        internal void Serialize(Stream output, ref int next_address)
        {
            /* Intent: ensure that TagBlock address meets the alignment requirement, padding the stream if needed. 
             * Write bytes to the stream to move the stream-pointer forward and 'reserve' this space for the TagBlock 
             * */
            var padding = Padding.GetCount(output.Position, this.alignment);    // Get padding count (if any) required to satisfy this TagBlock alignment
            next_address += (int)padding;                                       // Increment next_address value by padded-increase
            int destination_address =  output.Pad(this.alignment);              // Pad the current offset to TagBlocks alignment
            this.SetAddress(destination_address);                               // Update this_pointer value for shits

            output.Write(new byte[this.size], 0, this.size);                    // Reserve space in the stream

            /* Intent: process all fields and write the field data to TagBlocks memory: finally write TagBlocks 
             * memory to output stream
             * */
            foreach (var field in fixed_fields)
            {
                ISerialize serializable_field = field.Object as ISerialize;
                if (serializable_field != null)
                {
                    serializable_field.Serialize(output, ref next_address);
                }
                (this as IStructure).SetField(field.Object);
            }
            /* Intent: move the output stream-pointer back to the reserved address:
             * then copy the TagBlock bytes to the output streamb at that address
             * */
            output.Position = this.this_pointer;
            output.Write(this.memory_.ToArray(), 0, (int)this.memory_.Length);
        }
        
        public void SetAddress(int address) { this.this_pointer = address; }

        protected int tagblock_id = -1;
        internal int this_pointer = 0;

        protected TagBlock(int size, int alignment = DefaultAlignment)
            : this(size, new TagBlockField[0]) { }

        public MemoryStream GetMemory() { return memory_; }

        protected TagBlock(int size, params TagBlockField[] fields)
            : this(size, fields, DefaultAlignment) { }
        protected TagBlock(int size, TagBlockField[] fields, int alignment = DefaultAlignment)
        {
            // assign size of this tag_block
            this.size = size;
            this.alignment = alignment;
            this.memory_ = new MemoryStream(new byte[this.size], 0, this.size, true, true);//*
            this.fixed_fields = new List<TagBlockField>(fields);

            int field_offset = 0;
            for (var i = 0; i < fixed_fields.Count; i++)
            {
                if (fixed_fields[i].Object == null)
                {
                    field_offset += fixed_fields[i].FieldOffset;
                    fixed_fields.RemoveAt(i--); continue;
                }
                fixed_fields[i] = new TagBlockField(fixed_fields[i].Object, field_offset);
                field_offset += fixed_fields[i].Object.SizeOfField;
                fixed_fields[i].Object.Initialize(this);
            }
            return;
        }

        void IStructure.SetField(IField calling_field)
        {
            foreach (var field in fixed_fields)
            {
                if (field.Object.Equals(calling_field))
                {
                    // get the data from the field object
                    byte[] field_data = calling_field.GetFieldData();
                    // set field data to buffer_
                    memory_.Position = field.FieldOffset;
                    memory_.Write(field_data, 0, field_data.Length);
                    return;
                }
            }
            throw new Exception();
        }

        /// <summary>
        /// Generic class for searching nested TagBlocks for T and returning a combined Enumerable<T> object
        /// </summary>
        /// <typeparam name="T">Reference type to search for</typeparam>
        /// <returns></returns>
        IEnumerable<T> GetEnumeratorsRecursively<T>()
        {
            List<T> buffer = new List<T>();
            foreach (TagBlockField field in this.fixed_fields)
            {
                T array;
                if ((array = (T)field.Object) != null)
                {
                    buffer.Add(array);
                }
                IEnumerable<TagBlock> tagblock_interface__;
                if ((tagblock_interface__ = field.Object as IEnumerable<TagBlock>) != null)
                {
                    foreach (var item in tagblock_interface__)
                    {
                        IEnumerable<T> tagid_interface__;
                        if ((tagid_interface__ = item as IEnumerable<T>) != null)
                            buffer.AddRange(item.GetEnumeratorsRecursively<T>());
                    }
                }
            }
            return buffer;
        }
        /// <summary>
        /// Returns all StringIDs from this TagBlock and all nested TagBlocks
        /// </summary>
        /// <returns>returns an IEnumerator<StringID></returns>
        IEnumerator<StringID> IEnumerable<StringID>.GetEnumerator()
        {
            foreach (var subitem in this.GetEnumeratorsRecursively<StringID>())
            {
                yield return subitem;
            }
        }
        /// <summary>
        /// Returns all TagIdentifiers¹ from this TagBlock and all nested TagBlocks
        /// ¹Also searches for tag_pointers and returns the TagIdent property with
        /// the enumerator
        /// </summary>
        /// <returns>returns an IEnumerator<TagIdent></returns>
        IEnumerator<TagIdent> IEnumerable<TagIdent>.GetEnumerator()
        {
            List<TagIdent> items = new List<TagIdent>(this.GetEnumeratorsRecursively<TagIdent>());
            List<TagPointer> pointer_items = new List<TagPointer>(this.GetEnumeratorsRecursively<TagPointer>());
            items.AddRange(pointer_items.Select(x => (TagIdent)x).ToArray());
            foreach (var subitem in items)
            {
                yield return subitem;
            }
        }
        /// <summary>
        /// Retusn all tag_pointers from this TagBlock and all nested TagBlocks
        /// </summary>
        /// <returns>returns an IEnumerator<tag_pointer></returns>
        IEnumerator<TagPointer> IEnumerable<TagPointer>.GetEnumerator()
        {
            foreach (var subitem in this.GetEnumeratorsRecursively<TagPointer>())
            {
                yield return subitem;
            }
        }
        /// <summary>
        /// Returns all TagBlockFields from this TagBlock
        /// </summary>
        /// <returns></returns>
        IEnumerator<TagBlockField> IEnumerable<TagBlockField>.GetEnumerator()
        {
            foreach (TagBlockField field in this.fixed_fields)
            {
                yield return field;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return fixed_fields.GetEnumerator();
        }

        void IMeta.CopyFrom(Stream source)
        {
            this.Parse(source);
        }

        int IMeta.Size { get { return size; } }
    }

    public abstract class FixedArray<T> : List<T>, IField, IEnumerable<T>
        where T : new()
    {
        protected IStructure parent;
        protected int count_ = 0;
        protected int first_element_address_;

        byte[] IField.GetFieldData()
        {
            byte[] data_ = new byte[8];
            BitConverter.GetBytes(this.Count).CopyTo(data_, 0);
            BitConverter.GetBytes(first_element_address_).CopyTo(data_, 4);
            return data_;
        }

        int IField.SizeOfField
        {
            get { return 8; }
        }

        void IField.SetFieldData(byte[] field_data, IStructure caller)
        {
            count_ = BitConverter.ToInt32(field_data, 0);
            first_element_address_ = BitConverter.ToInt32(field_data, 4);
            for (int i = 0; i < count_; ++i)
            {
                this.Add(default(T));
            }
        }

        void IField.Initialize(IStructure calling_structure)
        {
            parent = calling_structure;
        }
    }

    public class ByteArray : FixedArray<byte>, IMeta
    {
        void IMeta.CopyFrom(Stream source)
        {
            source.Position = this.first_element_address_;
            BinaryReader bin = new BinaryReader(source);
            this.Clear();
            this.AddRange(bin.ReadBytes(this.count_));
        }

        int IMeta.Size
        {
            get { return this.count_; }
        }
    }

    public class ModelRaw : FixedArray<byte>, IField, IResource
    {
        public int HeaderSize { get; set; }
        public int ResourceDataLength { get; set; }

        byte[] IField.GetFieldData()
        {
            byte[] buffer = new byte[16];
            BitConverter.GetBytes(base.first_element_address_).CopyTo(buffer, 0);
            BitConverter.GetBytes(base.count_).CopyTo(buffer, 4);
            BitConverter.GetBytes(HeaderSize).CopyTo(buffer, 8);
            BitConverter.GetBytes(ResourceDataLength).CopyTo(buffer, 12);
            return buffer;
        }

        void IField.SetFieldData(byte[] field_data, IStructure caller)
        {
            base.first_element_address_ = BitConverter.ToInt32(field_data, 0);
            base.count_ = BitConverter.ToInt32(field_data, 4);
            HeaderSize = BitConverter.ToInt32(field_data, 8);
            ResourceDataLength = BitConverter.ToInt32(field_data, 12);
        }

        int IField.SizeOfField
        {
            get { return 16; }
        }

        void IResource.CopyFrom(Stream input)
        {
            byte[] buffer;
            input.CopyResource(base.first_element_address_, base.count_, out buffer);
            this.AddRange(buffer);
        }

        public byte[] GetResource(DResource resource)
        {
            return this.GetRange(8 + HeaderSize + resource.resource_offset, resource.resource_length).ToArray();
        }
        public int GetHeaderValue(DResource resource)
        {
            BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.GetRange(8, HeaderSize).ToArray()));
            binaryReader.BaseStream.Seek(resource.header_address, SeekOrigin.Begin);
            return binaryReader.ReadInt32();
        }
    }


    /// <summary>
    /// Wrapper structure for linking an IField object with a field offset value
    /// </summary>
    public struct TagBlockField
    {
        public readonly IField Object;
        public readonly int FieldOffset;

        public TagBlockField(IField field)
        {
            this.Object = field;
            this.FieldOffset = -1;
        }

        public TagBlockField(IField field, int field_offset)
        {
            this.Object = field;
            this.FieldOffset = field_offset;
        }
    }
}