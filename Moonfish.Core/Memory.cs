using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Moonfish
{
    public interface IFieldArray
    {
        int Address { get; set; }
        IList<IAField> Fields { get; }
    }

    public interface IAField
    {
        int Size { get; }
    }

    public interface IField
    {
        byte[] GetFieldData();
        void SetFieldData(byte[] field_data, IStructure caller = null);
        int SizeOfField { get; }

        void Initialize(IStructure calling_structure);
    }

    public interface IStructure
    {
        void SetField(IField calling_field);
    }

    /// <summary>
    /// Get rid of this lol
    /// </summary>
    public interface IPointable
    {
        void Parse(Memory mem);
        void PointTo(Memory mem);
        int Address { get; set; }
        int Alignment { get; }
        int SizeOf { get; }
        void CopyTo(Stream stream);
    }

    public class Memory : MemoryStream
    {
        public List<mem_ref> instance_table = new List<mem_ref>();
        int start_address = 0;
        public int Address
        {
            get { return start_address; }
        }
        internal void SetAddress(int address)
        {
            start_address = address;
        }
        public Memory Copy(int address)
        {
            mem_ref[] instance_table__ = this.instance_table.ToArray();
            int shift__ = 0;

            for (int i = 0; i < instance_table__.Length; ++i)
            {
                if (instance_table__[i].external == false)
                {
                    int new_address = instance_table__[i].address - start_address + address;
                    int padding = instance_table__[i].GetPaddingCount(new_address);
                    shift__ += padding;
                    instance_table__[i].SetAddress(new_address, false);
                }
            }


            byte[] buffer_ = new byte[this.Length + shift__];
            Memory copy = new Memory(buffer_, this.start_address);
            instance_table__[0].client.PointTo(copy);
            copy.start_address = address;
            copy.instance_table = new List<mem_ref>(instance_table__);

            BinaryReader bin_reader = new BinaryReader(this);
            for (int i = 0; i < copy.instance_table.Count; ++i)
            {
                if (instance_table__[i].external == false)
                {
                    copy.Position = copy.instance_table[i].address - copy.start_address;
                    this.Position = this.instance_table[i].address - start_address;
                    int length = instance_table__[i].client.SizeOf;
                    copy.Write(bin_reader.ReadBytes(length), 0, length);
                }
            }
            for (int i = 0; i < instance_table__.Length; ++i)
            {
                if (instance_table__[i].external == false)
                {
                    instance_table__[i].SetAddress(instance_table__[i].address);
                }
            }
            return copy;
        }

        public Memory(byte[] buffer, int translation = 0)
            : base(buffer, 0, buffer.Length, true, true)
        {
            start_address = translation;
        }
        public Memory()
            : base() { }
        public bool Contains(IPointable calling_object)
        {
            return (calling_object.Address - start_address >= 0
                && calling_object.Address - start_address + calling_object.SizeOf <= Length);
        }
        public MemoryStream getmem(IPointable data)
        {
            if (this.Contains(data))
                return new MemoryStream(base.GetBuffer(), data.Address - start_address, data.SizeOf);
            else return null;
        }

        /// <summary>
        /// Parses the TagBlock, which updates the TagBlock internal 'pointers', 
        /// then copies it to the stream and the current stream location. 
        /// Note: the tag-block will be parsed so that the internal pointers are stream-offset values
        /// </summary>
        /// <param name="source">TagBlock object which to perform parsing on and copying from</param>
        /// <param name="stream">Destination stream for copied data</param>
        /// <returns>true</returns>
        public static bool Map(TagBlock source, Stream stream)
        {
            /* Intent: Using the TagBlock which is passed in, calculate all Pointers—count and address—
             * values for the new position in the stream. Copy all the bytes from the TagBlocks
             * recursively into the stream. */

            var start_offset = stream.Position;                                             /* Store the current position in the stream that was passed in.
                                                                                             * This will be the address we start copying TagBlock data at */
            var block_size = (source as IPointable).SizeOf;                                 // Size of the source TagBlock internal data
            stream.Write(Padding.GetBytes(block_size, 0xCD), 0, block_size);                /* Write padding bytes for debug purposes. This also moves the 
                                                                                             * streams internal position forward so that we are 'reserving' 
                                                                                             * this space*/
            (source as IPointable).CopyTo(stream);                                          /* This method is a recursive two-pass into the TagBlock which 
                                                                                             * will update internal properties before copying to the stream */
            stream.Position = start_offset;                                                 // Move the stream back to our stored offset
            stream.Write(source.GetMemory().ToArray(), 0, block_size);                      // Write the TagBlock internal memory to the stream
            return true;
        }

        public struct mem_ref
        {
            public IPointable client;
            public int address;
            public int count;
            public Type type;
            public bool external;
            public bool isnull { get { return count == 0 && address == Halo2.NullPtr; } }

            public void SetAddress(int address, bool commit = true)
            {
                if (commit && client != null) client.Address = address;
                this.address = address;
            }

            public int GetPaddingCount(int address)
            {
                if (client != null) return (int)Padding.GetCount(address, client.Alignment);
                else throw new Exception();
            }

            public override string ToString()
            {
                return string.Format("{0} : x{1} : {2}", address, count, external);
            }
        }
    }

    public static class Scanner
    {
        public static void Scan(MapStream input) {
            BinaryReader bin = new BinaryReader(input);
            input.Position = 0;
            var start_address = input.IndexVirtualAddress;
            List<object> possible_pointers = new List<object>();
            for (int i = 0; i < input.Length / 8; i++)
            {
                var count = bin.ReadInt32();
                var address = bin.ReadInt32();
                if (count > 0 && address > start_address && address < start_address + input.Length)
                {
                    possible_pointers.Add(new { Count = count, Address = address });
                }
            }
        }
    }
}
