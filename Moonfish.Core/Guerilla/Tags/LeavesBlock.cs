using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class LeavesBlock
    {
        Flags flags;
        byte bSP2DReferenceCount;
        short firstBSP2DReference;
        internal  LeavesBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadByte();
            this.bSP2DReferenceCount = binaryReader.ReadByte();
            this.firstBSP2DReference = binaryReader.ReadInt16();
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
        internal enum Flags : byte
        {
            ContainsDoubleSidedSurfaces = 1,
        };
    };
}
