using Moonfish;
using System;

namespace Obsolete
{

    public class StringID : IField, IEquatable<StringID>
    {
        public short Index { get { return index; } }
        public sbyte Length { get { return length; } }

        IStructure parent;
        const int size = 4;
        short index;
        sbyte length;
        byte nullbyte;

        public static explicit operator int(StringID strRef)
        {
            return (strRef.length << 24) | strRef.nullbyte | (ushort)strRef.index;
        }

        public static explicit operator StringID(int i)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            return new StringID(BitConverter.ToInt16(bytes, 0), (sbyte)bytes[3], bytes[2]);
        }

        byte[] IField.GetFieldData()
        {
            return BitConverter.GetBytes((int)this);
        }

        void IField.SetFieldData(byte[] field_data, IStructure caller)
        {
            var copy = (StringID)BitConverter.ToInt32(field_data, 0);
            copy.parent = this.parent;//copy pointer to parent//
            this.Copy(copy);
            if (caller != parent && parent != null)
                parent.SetField(this);
        }

        private void Copy(StringID copy)
        {
            parent = copy.parent;
            nullbyte = copy.nullbyte; if (nullbyte != byte.MinValue) //throw new Exception("Bad String ID. \nBad. bad. bad! >:D");
                index = copy.index;
            length = copy.length;
        }

        int IField.SizeOfField
        {
            get { return size; }
        }

        void IField.Initialize(IStructure calling_structure)
        {
            parent = calling_structure;
        }

        public StringID(StringID copy)
        {
            this.parent = copy.parent;
            this.nullbyte = copy.nullbyte; if (nullbyte != byte.MinValue) throw new Exception("Bad String ID. \nBad. bad. bad! >:D");
            this.index = copy.index;
            this.length = copy.length;
        }
        public StringID(short index, sbyte length, byte debug = byte.MinValue)
        {
            this.parent = default(IStructure);
            this.nullbyte = debug; if (nullbyte != byte.MinValue) //throw new Exception("Bad String ID. \nBad. bad. bad! >:D");
                this.index = index;
            this.length = length;
        }
        public StringID() { }

        public override string ToString()
        {
            return string.Format("{0} : {1} bytes", index, length);
        }

        public static StringID Zero { get { return new StringID(0, 0); } }

        bool IEquatable<StringID>.Equals(StringID other)
        {
            return (index == other.index && length == other.length && nullbyte == other.nullbyte);
        }
    }
}