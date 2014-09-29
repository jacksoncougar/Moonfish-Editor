using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructurePortalDeviceMappingBlock
    {
        StructureDevicePortalAssociationBlock[] devicePortalAssociations;
        GamePortalToportalMappingBlock[] gamePortalToPortalMap;
        internal  StructurePortalDeviceMappingBlock(BinaryReader binaryReader)
        {
            this.devicePortalAssociations = ReadStructureDevicePortalAssociationBlockArray(binaryReader);
            this.gamePortalToPortalMap = ReadGamePortalToportalMappingBlockArray(binaryReader);
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
        StructureDevicePortalAssociationBlock[] ReadStructureDevicePortalAssociationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureDevicePortalAssociationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureDevicePortalAssociationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureDevicePortalAssociationBlock(binaryReader);
                }
            }
            return array;
        }
        GamePortalToportalMappingBlock[] ReadGamePortalToportalMappingBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GamePortalToportalMappingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GamePortalToportalMappingBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GamePortalToportalMappingBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
