using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspClusterDebugInfoblock
    {
        Errors errors;
        Warnings warnings;
        byte[] invalidName_;
        StructureBspDebugInfoRenderLineblock[] lines;
        StructureBspDebugInfoindicesblock[] fogPlaneIndices;
        StructureBspDebugInfoindicesblock[] visibleFogPlaneIndices;
        StructureBspDebugInfoindicesblock[] visFogOmissionClusterIndices;
        StructureBspDebugInfoindicesblock[] containingFogZoneIndices;
        internal  StructureBspClusterDebugInfoblock(BinaryReader binaryReader)
        {
            this.errors = (Errors)binaryReader.ReadInt16();
            this.warnings = (Warnings)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(28);
            this.lines = ReadStructureBspDebugInfoRenderLineblockArray(binaryReader);
            this.fogPlaneIndices = ReadStructureBspDebugInfoindicesblockArray(binaryReader);
            this.visibleFogPlaneIndices = ReadStructureBspDebugInfoindicesblockArray(binaryReader);
            this.visFogOmissionClusterIndices = ReadStructureBspDebugInfoindicesblockArray(binaryReader);
            this.containingFogZoneIndices = ReadStructureBspDebugInfoindicesblockArray(binaryReader);
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
        internal enum Errors : short
        {
            MultipleFogPlanes = 1,
            FogZoneCollision = 2,
            FogZoneImmersion = 4,
        };
        internal enum Warnings : short
        {
            MultipleVisibleFogPlanes = 1,
            VisibleFogClusterOmission = 2,
            FogPlaneMissedRenderBSP = 4,
        };
    };
}
