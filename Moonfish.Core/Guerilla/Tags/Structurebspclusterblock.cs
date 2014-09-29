using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspClusterblock
    {
        GlobalgeometrySectionInfostructBlock sectionInfo;
        GlobalgeometryBlockInfoStructblock geometryBlockInfo;
        StructureBspClusterDatablockNew[] clusterData;
        Moonfish.Model.Range boundsX;
        Moonfish.Model.Range boundsY;
        Moonfish.Model.Range boundsZ;
        byte scenarioSkyIndex;
        byte mediaIndex;
        byte scenarioVisibleSkyIndex;
        byte scenarioAtmosphericFogIndex;
        byte planarFogDesignator;
        byte visibleFogPlaneIndex;
        Moonfish.Tags.ShortBlockIndex1 backgroundSound;
        Moonfish.Tags.ShortBlockIndex1 soundEnvironment;
        Moonfish.Tags.ShortBlockIndex1 weather;
        short transitionStructureBSP;
        byte[] invalidName_;
        byte[] invalidName_0;
        Flags flags;
        byte[] invalidName_1;
        PredictedResourceBlock[] predictedResources;
        StructureBspClusterPortalIndexblock[] portals;
        int checksumFromStructure;
        StructureBspClusterInstancedGeometryindexblock[] instancedGeometryIndices;
        GlobalgeometrySectionstripIndexBlock[] indexReorderTable;
        byte[] collisionMoppCode;
        internal  StructureBspClusterblock(BinaryReader binaryReader)
        {
            this.sectionInfo = new GlobalgeometrySectionInfostructBlock(binaryReader);
            this.geometryBlockInfo = new GlobalgeometryBlockInfoStructblock(binaryReader);
            this.clusterData = ReadStructureBspClusterDatablockNewArray(binaryReader);
            this.boundsX = binaryReader.ReadRange();
            this.boundsY = binaryReader.ReadRange();
            this.boundsZ = binaryReader.ReadRange();
            this.scenarioSkyIndex = binaryReader.ReadByte();
            this.mediaIndex = binaryReader.ReadByte();
            this.scenarioVisibleSkyIndex = binaryReader.ReadByte();
            this.scenarioAtmosphericFogIndex = binaryReader.ReadByte();
            this.planarFogDesignator = binaryReader.ReadByte();
            this.visibleFogPlaneIndex = binaryReader.ReadByte();
            this.backgroundSound = binaryReader.ReadShortBlockIndex1();
            this.soundEnvironment = binaryReader.ReadShortBlockIndex1();
            this.weather = binaryReader.ReadShortBlockIndex1();
            this.transitionStructureBSP = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.predictedResources = ReadPredictedResourceBlockArray(binaryReader);
            this.portals = ReadStructureBspClusterPortalIndexblockArray(binaryReader);
            this.checksumFromStructure = binaryReader.ReadInt32();
            this.instancedGeometryIndices = ReadStructureBspClusterInstancedGeometryindexblockArray(binaryReader);
            this.indexReorderTable = ReadGlobalgeometrySectionstripIndexBlockArray(binaryReader);
            this.collisionMoppCode = ReadData(binaryReader);
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
        StructureBspClusterDatablockNew[] ReadStructureBspClusterDatablockNewArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterDatablockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterDatablockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterDatablockNew(binaryReader);
                }
            }
            return array;
        }
        PredictedResourceBlock[] ReadPredictedResourceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PredictedResourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PredictedResourceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PredictedResourceBlock(binaryReader);
                }
            }
            return array;
        }
        StructureBspClusterPortalIndexblock[] ReadStructureBspClusterPortalIndexblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterPortalIndexblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterPortalIndexblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterPortalIndexblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspClusterInstancedGeometryindexblock[] ReadStructureBspClusterInstancedGeometryindexblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterInstancedGeometryindexblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterInstancedGeometryindexblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterInstancedGeometryindexblock(binaryReader);
                }
            }
            return array;
        }
        GlobalgeometrySectionstripIndexBlock[] ReadGlobalgeometrySectionstripIndexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalgeometrySectionstripIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalgeometrySectionstripIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalgeometrySectionstripIndexBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Flags : short
        {
            OneWayPortal = 1,
            DoorPortal = 2,
            PostprocessedGeometry = 4,
            IsTheSky = 8,
        };
    };
}
