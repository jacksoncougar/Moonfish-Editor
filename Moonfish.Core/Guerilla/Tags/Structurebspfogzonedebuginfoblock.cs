using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspFogZoneDebugInfoblock
    {
        int mediaIndexScenarioFogPlane;
        int baseFogPlaneIndex;
        byte[] invalidName_;
        StructureBspDebugInfoRenderLineblock[] lines;
        StructureBspDebugInfoindicesblock[] immersedClusterIndices;
        StructureBspDebugInfoindicesblock[] boundingFogPlaneIndices;
        StructureBspDebugInfoindicesblock[] collisionFogPlaneIndices;
        internal  StructureBspFogZoneDebugInfoblock(BinaryReader binaryReader)
        {
            this.mediaIndexScenarioFogPlane = binaryReader.ReadInt32();
            this.baseFogPlaneIndex = binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(24);
            this.lines = ReadStructureBspDebugInfoRenderLineblockArray(binaryReader);
            this.immersedClusterIndices = ReadStructureBspDebugInfoindicesblockArray(binaryReader);
            this.boundingFogPlaneIndices = ReadStructureBspDebugInfoindicesblockArray(binaryReader);
            this.collisionFogPlaneIndices = ReadStructureBspDebugInfoindicesblockArray(binaryReader);
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
        StructureBspDebugInfoRenderLineblock[] ReadStructureBspDebugInfoRenderLineblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspDebugInfoRenderLineblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspDebugInfoRenderLineblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspDebugInfoRenderLineblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspDebugInfoindicesblock[] ReadStructureBspDebugInfoindicesblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspDebugInfoindicesblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspDebugInfoindicesblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspDebugInfoindicesblock(binaryReader);
                }
            }
            return array;
        }
    };
}
