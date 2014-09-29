using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspsurfaceReferenceblock
    {
        short stripIndex;
        short lightmapTriangleIndex;
        int bSPNodeIndex;
        internal  StructureBspsurfaceReferenceblock(BinaryReader binaryReader)
        {
            this.stripIndex = binaryReader.ReadInt16();
            this.lightmapTriangleIndex = binaryReader.ReadInt16();
            this.bSPNodeIndex = binaryReader.ReadInt32();
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
