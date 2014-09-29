using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalgeometryBlockResourceblock
    {
        Type type;
        byte[] invalidName_;
        short primaryLocator;
        short secondaryLocator;
        int resourceDataSize;
        int resourceDataOffset;
        internal  GlobalgeometryBlockResourceblock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(3);
            this.primaryLocator = binaryReader.ReadInt16();
            this.secondaryLocator = binaryReader.ReadInt16();
            this.resourceDataSize = binaryReader.ReadInt32();
            this.resourceDataOffset = binaryReader.ReadInt32();
        }
        byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal enum Type : byte
        {
            TagBlock = 0,
            TagData = 0,
            VertexBuffer = 0,
        };
    };
}
