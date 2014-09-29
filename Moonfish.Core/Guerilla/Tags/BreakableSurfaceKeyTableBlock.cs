using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class BreakableSurfaceKeyTableblock
    {
        short instancedGeometryIndex;
        short breakableSurfaceIndex;
        int seedSurfaceIndex;
        float x0;
        float x1;
        float y0;
        float y1;
        float z0;
        float z1;
        internal  BreakableSurfaceKeyTableblock(BinaryReader binaryReader)
        {
            this.instancedGeometryIndex = binaryReader.ReadInt16();
            this.breakableSurfaceIndex = binaryReader.ReadInt16();
            this.seedSurfaceIndex = binaryReader.ReadInt32();
            this.x0 = binaryReader.ReadSingle();
            this.x1 = binaryReader.ReadSingle();
            this.y0 = binaryReader.ReadSingle();
            this.y1 = binaryReader.ReadSingle();
            this.z0 = binaryReader.ReadSingle();
            this.z1 = binaryReader.ReadSingle();
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
