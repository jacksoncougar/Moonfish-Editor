using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspLeafblock
    {
        short cluster;
        short surfaceReferenceCount;
        int firstSurfaceReferenceIndex;
        internal  StructureBspLeafblock(BinaryReader binaryReader)
        {
            this.cluster = binaryReader.ReadInt16();
            this.surfaceReferenceCount = binaryReader.ReadInt16();
            this.firstSurfaceReferenceIndex = binaryReader.ReadInt32();
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
    };
}