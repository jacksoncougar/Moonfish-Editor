using Moonfish.Model;
using Moonfish.Tags;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Moonfish.Definitions
{
    


    public interface IDefinition
    {
        byte[] ToArray();
        void FromArray(byte[] buffer);
        int Size { get; }
    }

    public class DCompressionRanges : IDefinition
    {
        public Range X;
        public Range Y;
        public Range Z;
        public Range U;
        public Range V;

        byte[] IDefinition.ToArray()
        {
            MemoryStream buffer = new MemoryStream(40);
            BinaryWriter bin = new BinaryWriter(buffer);
            bin.Write(X);
            bin.Write(Y);
            bin.Write(Z);
            bin.Write(U);
            bin.Write(V);
            return buffer.ToArray();
        }

        void IDefinition.FromArray(byte[] buffer)
        {
            BinaryReader bin = new BinaryReader(new MemoryStream(buffer));
            X = bin.ReadRange();
            Y = bin.ReadRange();
            Z = bin.ReadRange();
            U = bin.ReadRange();
            V = bin.ReadRange();
        }

        internal void Expand(float p)
        {
            X = Range.Expand(X, p);
            Y = Range.Expand(Y, p);
            Z = Range.Expand(Z, p);
            U = Range.Expand(U, p);
            V = Range.Expand(V, p);
        }

        int IDefinition.Size
        {
            get { return 40; }
        }
    }

    public class DRegion : IDefinition
    {
        public StringID Name = StringID.Zero;
        public short NodeMapOffset = -1;
        public short NodeMapSize = 0;

        byte[] IDefinition.ToArray()
        {
            MemoryStream buffer = new MemoryStream(16);
            BinaryWriter bin = new BinaryWriter(buffer);
            bin.Write(Name);
            bin.Write(NodeMapOffset);
            bin.Write(NodeMapSize);
            return buffer.ToArray();
        }

        void IDefinition.FromArray(byte[] buffer)
        {
            BinaryReader bin = new BinaryReader(new MemoryStream(buffer));
            Name = bin.ReadStringID();
            NodeMapOffset = bin.ReadInt16();
            NodeMapSize = bin.ReadInt16();
        }


        int IDefinition.Size
        {
            get { return 8; }
        }
    }

    public class DPermutation : IDefinition
    {
        public StringID Name = StringID.Zero;
        public short Index;
        public short HighLOD;

        byte[] IDefinition.ToArray()
        {
            byte[] buffer = new byte[(this as IDefinition).Size];
            BitConverter.GetBytes((int)Name).CopyTo(buffer, 0);
            BitConverter.GetBytes(Index).CopyTo(buffer, 4);
            return buffer;
        }

        void IDefinition.FromArray(byte[] buffer)
        {
            this.Name = (StringID)BitConverter.ToInt32(buffer, 0);
            this.Index = BitConverter.ToInt16(buffer, 4);
            this.HighLOD = BitConverter.ToInt16(buffer, 14);
        }

        int IDefinition.Size
        {
            get { return 16; }
        }
    }

    public class DSection : IDefinition
    {
        public enum VertexDefinition
        {
            Fixed = 0,
            RigidBone = 1,
            WeightedBone = 2,
        }
        [Flags]
        public enum CompressionFlags : ushort
        {
            Uncompressed = 0,
            CompressVertexData = 1,
            CompressTexcoordData = 2,
        }

        public VertexDefinition VertexType = VertexDefinition.Fixed;
        public ushort VertexCount;
        public ushort TriangleCount;
        public CompressionFlags Compression = CompressionFlags.CompressTexcoordData | CompressionFlags.CompressVertexData;
        public uint RawOffset;
        public uint RawSize;
        public uint HeaderSize = 112;
        public uint RawDataSize;

        byte[] IDefinition.ToArray()
        {
            MemoryStream buffer = new MemoryStream();
            BinaryWriter bin = new BinaryWriter(buffer);
            bin.Write((int)VertexType);
            bin.Write((ushort)VertexCount);
            bin.Write(TriangleCount);
            bin.Seek(16, SeekOrigin.Current);
            bin.Write((int)Compression);
            bin.Seek(28, SeekOrigin.Current);
            bin.Write(RawOffset);
            bin.Write(RawSize);
            bin.Write(HeaderSize);
            bin.Write(RawDataSize);
            return buffer.ToArray();
        }

        void IDefinition.FromArray(byte[] buffer)
        {
            BinaryReader bin = new BinaryReader(new MemoryStream(buffer));
            VertexType = (VertexDefinition)bin.ReadInt32();
            VertexCount = bin.ReadUInt16();
            TriangleCount = bin.ReadUInt16();
            bin.BaseStream.Seek(16, SeekOrigin.Current);
            Compression = (CompressionFlags)bin.ReadUInt16();
            bin.BaseStream.Seek(28, SeekOrigin.Current);
            RawOffset = bin.ReadUInt32();
            RawSize = bin.ReadUInt32();
            HeaderSize = bin.ReadUInt32();
            RawDataSize = bin.ReadUInt32();
        }

        int IDefinition.Size
        {
            get { return 70; }
        }
    }

    public class DResource : IDefinition
    {
        public byte first_;
        public byte second_;
        public short header_address;
        public short header_address_again;
        public short data_size__or__first_index;
        public int resource_length;
        public int resource_offset;

        public DResource(byte[] buffer)
        {
            first_ = buffer[0];
            second_ = buffer[1];
            header_address = BitConverter.ToInt16(buffer, 2);
            header_address_again = BitConverter.ToInt16(buffer, 4);
            data_size__or__first_index = BitConverter.ToInt16(buffer, 6);
            resource_length = BitConverter.ToInt32(buffer, 8);
            resource_offset = BitConverter.ToInt32(buffer, 12);
        }

        public DResource(short address, short element_size, int total_resource_size, int resource_offset, bool first = false)
        {
            this.header_address = address;
            this.header_address_again = address;
            this.data_size__or__first_index = element_size;
            if (first) first_ = 2;
            else first_ = 0x00;
            second_ = 2;
            this.resource_length = total_resource_size;
            this.resource_offset = resource_offset;
        }
        public DResource() { }
        byte[] IDefinition.ToArray()
        {
            MemoryStream buffer = new MemoryStream();
            BinaryWriter bin = new BinaryWriter(buffer);
            bin.Write(first_);
            bin.Write(second_);
            bin.Write(header_address);
            bin.Write(header_address_again);
            bin.Write(data_size__or__first_index);
            bin.Write(resource_length);
            bin.Write(resource_offset);
            return buffer.ToArray();
        }

        void IDefinition.FromArray(byte[] buffer)
        {
            BinaryReader bin = new BinaryReader(new MemoryStream(buffer));
            first_ = bin.ReadByte();
            second_ = bin.ReadByte();
            header_address = bin.ReadInt16();
            header_address_again = bin.ReadInt16();
            data_size__or__first_index = bin.ReadInt16();
            resource_length = bin.ReadInt32();
            resource_offset = bin.ReadInt32();
        }

        int IDefinition.Size
        {
            get { return 16; }
        }
    }

    public class DGroup : IDefinition
    {
        [Flags]
        public enum DetailLevel
        {
            LOD1,
            LOD2,
            LOD3,
            LOD4,
            LOD5,
            LOD6,
            All = LOD1 | LOD2 | LOD3 | LOD4 | LOD5 | LOD6,
        }
        public DetailLevel Levels = DetailLevel.All;

        byte[] IDefinition.ToArray()
        {
            return BitConverter.GetBytes((int)Levels);
        }

        void IDefinition.FromArray(byte[] buffer)
        {
            Levels = (DetailLevel)BitConverter.ToUInt32(buffer, 0);
        }


        int IDefinition.Size
        {
            get { return 4; }
        }
    }

    public class DNode : IDefinition
    {
        public StringID Name = StringID.Zero;
        public short Parent_NodeIndex = -1;
        public short FirstChild_NodeIndex = -1;
        public short NextSibling_NodeIndex = -1;
        public Quaternion Rotation = new Quaternion(0, 0, 0, -1);
        public Vector3 Position = Vector3.Zero;
        public float Scale = 1.0f;
        public Vector3 Right = Vector3.UnitX;
        public Vector3 Forward = Vector3.UnitY;
        public Vector3 Up = Vector3.UnitZ;
        public Vector3 AbsolutePosition = Vector3.Zero;

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="copy"></param>
        public DNode(DNode copy)
        {
            this.Name = copy.Name;
            this.Parent_NodeIndex = copy.Parent_NodeIndex;
            this.FirstChild_NodeIndex = copy.FirstChild_NodeIndex;
            this.NextSibling_NodeIndex = copy.NextSibling_NodeIndex;
            this.Rotation = copy.Rotation;
            this.Position = copy.Position;
            this.Scale = copy.Scale;
            this.Right = copy.Right;
            this.Up = copy.Up;
            this.Forward = copy.Forward;
            this.AbsolutePosition = copy.AbsolutePosition;
        }

        public DNode() { }

        byte[] IDefinition.ToArray()
        {
            MemoryStream buffer = new MemoryStream();
            BinaryWriter bin = new BinaryWriter(buffer);
            bin.Write(Name);
            bin.Write(Parent_NodeIndex);
            bin.Write(FirstChild_NodeIndex);
            bin.Write(NextSibling_NodeIndex);
            bin.Seek(sizeof(short), SeekOrigin.Current);
            bin.Write(Position);
            bin.Write(Rotation);
            bin.Write(Scale);
            bin.Write(Right);
            bin.Write(Forward);
            bin.Write(Up);
            bin.Write(AbsolutePosition);
            return buffer.ToArray();
        }

        void IDefinition.FromArray(byte[] buffer)
        {
            BinaryReader bin = new BinaryReader(new MemoryStream(buffer));
            Name = bin.ReadStringID();
            Parent_NodeIndex = bin.ReadInt16();
            FirstChild_NodeIndex = bin.ReadInt16();
            NextSibling_NodeIndex = bin.ReadInt16();
            bin.BaseStream.Seek(sizeof(short), SeekOrigin.Current);
            Position = bin.ReadVector3();
            Rotation = bin.ReadQuaternion();
            Scale = bin.ReadSingle();
            Right = bin.ReadVector3();
            Forward = bin.ReadVector3();
            Up = bin.ReadVector3();
            AbsolutePosition = bin.ReadVector3();
        }

        int IDefinition.Size
        {
            get { return 96; }
        }
    }

    public class DShader : IDefinition
    {
        TagIdent Shader = TagIdent.NullIdentifier;

        byte[] IDefinition.ToArray()
        {
            MemoryStream buffer = new MemoryStream();
            BinaryWriter bin = new BinaryWriter(buffer);
            bin.Write((TagClass)"shad");
            bin.Write(TagIdent.NullIdentifier);
            bin.Write((TagClass)"shad");
            bin.Write(Shader);
            return buffer.ToArray();
        }

        void IDefinition.FromArray(byte[] buffer)
        {
            BinaryReader bin = new BinaryReader(new MemoryStream(buffer));
            bin.BaseStream.Seek(12, SeekOrigin.Begin);
            Shader = bin.ReadTagIdent();
        }


        int IDefinition.Size
        {
            get { return 16; }
        }
    }
}
