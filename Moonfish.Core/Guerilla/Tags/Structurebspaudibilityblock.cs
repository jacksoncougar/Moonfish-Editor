using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspAudibilityblock
    {
        int doorPortalCount;
        Moonfish.Model.Range clusterDistanceBounds;
        DoorEncodedPasBlock[] encodedDoorPas;
        ClusterDoorPortalEncodedpasBlock[] clusterDoorPortalEncodedPas;
        AiDeafeningEncodedPasBlock[] aiDeafeningPas;
        EncodedClusterDistancesBlock[] clusterDistances;
        OccluderToMachineDoormapping[] machineDoorMapping;
        internal  StructureBspAudibilityblock(BinaryReader binaryReader)
        {
            this.doorPortalCount = binaryReader.ReadInt32();
            this.clusterDistanceBounds = binaryReader.ReadRange();
            this.encodedDoorPas = ReadDoorEncodedPasBlockArray(binaryReader);
            this.clusterDoorPortalEncodedPas = ReadClusterDoorPortalEncodedpasBlockArray(binaryReader);
            this.aiDeafeningPas = ReadAiDeafeningEncodedPasBlockArray(binaryReader);
            this.clusterDistances = ReadEncodedClusterDistancesBlockArray(binaryReader);
            this.machineDoorMapping = ReadOccluderToMachineDoormappingArray(binaryReader);
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
        DoorEncodedPasBlock[] ReadDoorEncodedPasBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DoorEncodedPasBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DoorEncodedPasBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DoorEncodedPasBlock(binaryReader);
                }
            }
            return array;
        }
        ClusterDoorPortalEncodedpasBlock[] ReadClusterDoorPortalEncodedpasBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ClusterDoorPortalEncodedpasBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ClusterDoorPortalEncodedpasBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ClusterDoorPortalEncodedpasBlock(binaryReader);
                }
            }
            return array;
        }
        AiDeafeningEncodedPasBlock[] ReadAiDeafeningEncodedPasBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiDeafeningEncodedPasBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiDeafeningEncodedPasBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiDeafeningEncodedPasBlock(binaryReader);
                }
            }
            return array;
        }
        EncodedClusterDistancesBlock[] ReadEncodedClusterDistancesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EncodedClusterDistancesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EncodedClusterDistancesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EncodedClusterDistancesBlock(binaryReader);
                }
            }
            return array;
        }
        OccluderToMachineDoormapping[] ReadOccluderToMachineDoormappingArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OccluderToMachineDoormapping));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OccluderToMachineDoormapping[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OccluderToMachineDoormapping(binaryReader);
                }
            }
            return array;
        }
    };
}
