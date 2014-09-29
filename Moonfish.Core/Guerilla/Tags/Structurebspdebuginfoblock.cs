using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspDebugInfoblock
    {
        byte[] invalidName_;
        StructureBspClusterDebugInfoblock[] clusters;
        StructureBspFogPlaneDebugInfoblock[] fogPlanes;
        StructureBspFogZoneDebugInfoblock[] fogZones;
        internal  StructureBspDebugInfoblock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(64);
            this.clusters = ReadStructureBspClusterDebugInfoblockArray(binaryReader);
            this.fogPlanes = ReadStructureBspFogPlaneDebugInfoblockArray(binaryReader);
            this.fogZones = ReadStructureBspFogZoneDebugInfoblockArray(binaryReader);
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
        StructureBspClusterDebugInfoblock[] ReadStructureBspClusterDebugInfoblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterDebugInfoblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterDebugInfoblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterDebugInfoblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspFogPlaneDebugInfoblock[] ReadStructureBspFogPlaneDebugInfoblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspFogPlaneDebugInfoblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspFogPlaneDebugInfoblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspFogPlaneDebugInfoblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspFogZoneDebugInfoblock[] ReadStructureBspFogZoneDebugInfoblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspFogZoneDebugInfoblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspFogZoneDebugInfoblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspFogZoneDebugInfoblock(binaryReader);
                }
            }
            return array;
        }
    };
}
