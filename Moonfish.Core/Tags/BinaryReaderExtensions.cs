using Moonfish.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Tags
{
    public struct BlamPointer : IEnumerable<int>,  IEquatable<BlamPointer>
    {
        public readonly int Count;
        public readonly int Address;
        public readonly int ElementSize;

        public BlamPointer(int count, int address, int elementSize)
        {
            this.Count = count;
            this.Address = address;
            this.ElementSize = elementSize;
        }

        public int PointedSize
        {
            get { return Count * ElementSize; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
            {
                yield return Address + ElementSize * i;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Intersects(BlamPointer other)
        {
            return !(this.Address + this.PointedSize <= other.Address
                || other.Address + other.PointedSize <= this.Address);
        }

        public override bool Equals(object obj)
        {
            if (obj is BlamPointer)
            {
                return (this as IEquatable<BlamPointer>).Equals((BlamPointer)obj);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Address.GetHashCode();
        }

        bool IEquatable<BlamPointer>.Equals(BlamPointer other)
        {
            var val = this.Address == other.Address && this.Count == other.Count && this.ElementSize == other.ElementSize;
            if (val)
            {
            }
            return val;
        }
        public override string ToString()
        {
            return string.Format("{0}:{1}", Address, Count);
        }
    }
    static class BinaryReaderExtensions
    {
        public static BlamPointer ReadBlamPointer(this BinaryReader binaryReader, int elementSize)
        {
            return new BlamPointer(binaryReader.ReadInt32(), binaryReader.ReadInt32(), elementSize);
        }
        public static VertexBuffer ReadVertexBuffer(this BinaryReader binaryReader)
        {
            return new VertexBuffer() { Type = binaryReader.ReadVertexAttributeType() };
        }
        public static String32 ReadString32(this BinaryReader binaryReader)
        {
            return new String32(new string(Encoding.UTF8.GetChars(binaryReader.ReadBytes(32))));
        }
        public static String256 ReadString256(this BinaryReader binaryReader)
        {
            return new String256(new string(Encoding.UTF8.GetChars(binaryReader.ReadBytes(256))));
        }
        public static StringID ReadStringID(this BinaryReader binaryReader)
        {
            return new StringID(binaryReader.ReadInt32());
        }
        public static RGBColor ReadRGBColor(this BinaryReader binaryReader)
        {
            return new RGBColor() { Red = binaryReader.ReadByte(), Green = binaryReader.ReadByte(), Blue = binaryReader.ReadByte() };
        }


        public static TagReference ReadTagReference(this BinaryReader binaryReader)
        {
            return new TagReference(binaryReader.ReadTagClass(), binaryReader.ReadTagIdent());
        }

        public static BlockFlags8 ReadBlockFlags8(this BinaryReader binaryReader)
        {
            return new BlockFlags8(binaryReader.ReadByte());
        }

        public static BlockFlags16 ReadBlockFlags16(this BinaryReader binaryReader)
        {
            return new BlockFlags16(binaryReader.ReadInt16());
        }

        public static ByteBlockIndex1 ReadByteBlockIndex1(this BinaryReader binaryReader)
        {
            return (ByteBlockIndex1)binaryReader.ReadByte();
        }

        public static ShortBlockIndex1 ReadShortBlockIndex1(this BinaryReader binaryReader)
        {
            return (ShortBlockIndex1)binaryReader.ReadInt16();
        }

        public static LongBlockIndex1 ReadLongBlockIndex1(this BinaryReader binaryReader)
        {
            return (LongBlockIndex1)binaryReader.ReadInt32();
        }

        public static ShortBlockIndex2 ReadShortBlockIndex2(this BinaryReader binaryReader)
        {
            return (ShortBlockIndex2)binaryReader.ReadInt16();
        }

        public static OpenTK.Quaternion ReadQuaternion(this BinaryReader binaryReader)
        {
            return new OpenTK.Quaternion(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static ColorR8G8B8 ReadColorR8G8B8(this BinaryReader binaryReader)
        {
            return new ColorR8G8B8(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }
    }
}
