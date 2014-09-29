using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class ScenariostructureBspblock
    {
        int blockLength;
        int sBSPVirtualStartAddress;
        int lTMPVirtualStartAddress;
        Moonfish.Tags.TagClass sBSPClass;
        GlobalTagImportinfoBlock[] importInfo;
        byte[] invalidName_;
        StructureCollisionMaterialsBlock[] collisionMaterials;
        GlobalCollisionBspblock[] collisionBSP;
        /// <summary>
        /// Height below which vehicles get pushed up by an unstoppable force.
        /// </summary>
        float vehicleFloorWorldUnits;
        /// <summary>
        /// Height above which vehicles get pushed down by an unstoppable force.
        /// </summary>
        float vehicleCeilingWorldUnits;
        UNuSEDstructureBspnodeblock[] uNUSEDNodes;
        StructureBspLeafblock[] leaves;
        Moonfish.Model.Range worldBoundsX;
        Moonfish.Model.Range worldBoundsY;
        Moonfish.Model.Range worldBoundsZ;
        StructureBspsurfaceReferenceblock[] surfaceReferences;
        byte[] clusterData;
        StructureBspClusterPortalblock[] clusterPortals;
        StructureBspFogPlaneblock[] fogPlanes;
        byte[] invalidName_0;
        StructureBspWeatherPaletteblock[] weatherPalette;
        StructureBspWeatherPolyhedronblock[] weatherPolyhedra;
        StructureBspDetailObjectdatablock[] detailObjects;
        StructureBspClusterblock[] clusters;
        GlobalgeometryMaterialBlock[] materials;
        StructureBspskyOwnerClusterblock[] skyOwnerCluster;
        StructureBspConveyorsurfaceblock[] conveyorSurfaces;
        StructureBspbreakablesurfaceblock[] breakableSurfaces;
        PathfindingDataBlock[] pathfindingData;
        StructureBspPathfindingEdgesblock[] pathfindingEdges;
        StructureBspbackgroundsoundPaletteblock[] backgroundSoundPalette;
        StructureBspsoundEnvironmentPaletteblock[] soundEnvironmentPalette;
        byte[] soundPASData;
        StructureBspMarkerblock[] markers;
        StructureBspRuntimeDecalblock[] runtimeDecals;
        StructureBspEnvironmentObjectPaletteblock[] environmentObjectPalette;
        StructureBspEnvironmentObjectblock[] environmentObjects;
        StructureBspLightmapDatablock[] lightmaps;
        byte[] invalidName_1;
        GlobalMapLeafBlock[] leafMapLeaves;
        GlobalLeafConnectionBlock[] leafMapConnections;
        GlobalErrorReportCategoriesBlock[] errors;
        StructureBspPrecomputedLightingblock[] precomputedLighting;
        StructureBspInstancedGeometryDefinitionblock[] instancedGeometriesDefinitions;
        StructureBspInstancedGeometryinstancesblock[] instancedGeometryInstances;
        StructureBspsoundClusterblock[] ambienceSoundClusters;
        StructureBspsoundClusterblock[] reverbSoundClusters;
        TransparentPlanesBlock[] transparentPlanes;
        byte[] invalidName_2;
        /// <summary>
        /// Distances this far and longer from limit origin will pull you back in.
        /// </summary>
        float vehicleSpericalLimitRadius;
        /// <summary>
        /// Center of space in which vehicle can move.
        /// </summary>
        OpenTK.Vector3 vehicleSpericalLimitCenter;
        StructureBspDebugInfoblock[] debugInfo;
        [TagReference("DECP")]
        Moonfish.Tags.TagReference decorators;
        GlobalStructurePhysicsstructBlock structurePhysics;
        GlobalWaterDefinitionsBlock[] waterDefinitions;
        StructurePortalDeviceMappingBlock[] portalDeviceMapping;
        StructureBspAudibilityblock[] audibility;
        StructureBspFakeLightprobesblock[] objectFakeLightprobes;
        DecoratorPlacementdefinitionBlock[] decorators0;
        internal  ScenariostructureBspblock(BinaryReader binaryReader)
        {
            this.blockLength = binaryReader.ReadInt32();
            this.sBSPVirtualStartAddress = binaryReader.ReadInt32();
            this.lTMPVirtualStartAddress = binaryReader.ReadInt32();
            this.sBSPClass = binaryReader.ReadTagClass();
            this.importInfo = ReadGlobalTagImportinfoBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.collisionMaterials = ReadStructureCollisionMaterialsBlockArray(binaryReader);
            this.collisionBSP = ReadGlobalCollisionBspblockArray(binaryReader);
            this.vehicleFloorWorldUnits = binaryReader.ReadSingle();
            this.vehicleCeilingWorldUnits = binaryReader.ReadSingle();
            this.uNUSEDNodes = ReadUNuSEDstructureBspnodeblockArray(binaryReader);
            this.leaves = ReadStructureBspLeafblockArray(binaryReader);
            this.worldBoundsX = binaryReader.ReadRange();
            this.worldBoundsY = binaryReader.ReadRange();
            this.worldBoundsZ = binaryReader.ReadRange();
            this.surfaceReferences = ReadStructureBspsurfaceReferenceblockArray(binaryReader);
            this.clusterData = ReadData(binaryReader);
            this.clusterPortals = ReadStructureBspClusterPortalblockArray(binaryReader);
            this.fogPlanes = ReadStructureBspFogPlaneblockArray(binaryReader);
            this.invalidName_0 = binaryReader.ReadBytes(24);
            this.weatherPalette = ReadStructureBspWeatherPaletteblockArray(binaryReader);
            this.weatherPolyhedra = ReadStructureBspWeatherPolyhedronblockArray(binaryReader);
            this.detailObjects = ReadStructureBspDetailObjectdatablockArray(binaryReader);
            this.clusters = ReadStructureBspClusterblockArray(binaryReader);
            this.materials = ReadGlobalgeometryMaterialBlockArray(binaryReader);
            this.skyOwnerCluster = ReadStructureBspskyOwnerClusterblockArray(binaryReader);
            this.conveyorSurfaces = ReadStructureBspConveyorsurfaceblockArray(binaryReader);
            this.breakableSurfaces = ReadStructureBspbreakablesurfaceblockArray(binaryReader);
            this.pathfindingData = ReadPathfindingDataBlockArray(binaryReader);
            this.pathfindingEdges = ReadStructureBspPathfindingEdgesblockArray(binaryReader);
            this.backgroundSoundPalette = ReadStructureBspbackgroundsoundPaletteblockArray(binaryReader);
            this.soundEnvironmentPalette = ReadStructureBspsoundEnvironmentPaletteblockArray(binaryReader);
            this.soundPASData = ReadData(binaryReader);
            this.markers = ReadStructureBspMarkerblockArray(binaryReader);
            this.runtimeDecals = ReadStructureBspRuntimeDecalblockArray(binaryReader);
            this.environmentObjectPalette = ReadStructureBspEnvironmentObjectPaletteblockArray(binaryReader);
            this.environmentObjects = ReadStructureBspEnvironmentObjectblockArray(binaryReader);
            this.lightmaps = ReadStructureBspLightmapDatablockArray(binaryReader);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.leafMapLeaves = ReadGlobalMapLeafBlockArray(binaryReader);
            this.leafMapConnections = ReadGlobalLeafConnectionBlockArray(binaryReader);
            this.errors = ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            this.precomputedLighting = ReadStructureBspPrecomputedLightingblockArray(binaryReader);
            this.instancedGeometriesDefinitions = ReadStructureBspInstancedGeometryDefinitionblockArray(binaryReader);
            this.instancedGeometryInstances = ReadStructureBspInstancedGeometryinstancesblockArray(binaryReader);
            this.ambienceSoundClusters = ReadStructureBspsoundClusterblockArray(binaryReader);
            this.reverbSoundClusters = ReadStructureBspsoundClusterblockArray(binaryReader);
            this.transparentPlanes = ReadTransparentPlanesBlockArray(binaryReader);
            this.invalidName_2 = binaryReader.ReadBytes(96);
            this.vehicleSpericalLimitRadius = binaryReader.ReadSingle();
            this.vehicleSpericalLimitCenter = binaryReader.ReadVector3();
            this.debugInfo = ReadStructureBspDebugInfoblockArray(binaryReader);
            this.decorators = binaryReader.ReadTagReference();
            this.structurePhysics = new GlobalStructurePhysicsstructBlock(binaryReader);
            this.waterDefinitions = ReadGlobalWaterDefinitionsBlockArray(binaryReader);
            this.portalDeviceMapping = ReadStructurePortalDeviceMappingBlockArray(binaryReader);
            this.audibility = ReadStructureBspAudibilityblockArray(binaryReader);
            this.objectFakeLightprobes = ReadStructureBspFakeLightprobesblockArray(binaryReader);
            this.decorators0 = ReadDecoratorPlacementdefinitionBlockArray(binaryReader);
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
        GlobalTagImportinfoBlock[] ReadGlobalTagImportinfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalTagImportinfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalTagImportinfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalTagImportinfoBlock(binaryReader);
                }
            }
            return array;
        }
        StructureCollisionMaterialsBlock[] ReadStructureCollisionMaterialsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureCollisionMaterialsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureCollisionMaterialsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureCollisionMaterialsBlock(binaryReader);
                }
            }
            return array;
        }
        GlobalCollisionBspblock[] ReadGlobalCollisionBspblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalCollisionBspblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalCollisionBspblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalCollisionBspblock(binaryReader);
                }
            }
            return array;
        }
        UNuSEDstructureBspnodeblock[] ReadUNuSEDstructureBspnodeblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UNuSEDstructureBspnodeblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UNuSEDstructureBspnodeblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UNuSEDstructureBspnodeblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspLeafblock[] ReadStructureBspLeafblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspLeafblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspLeafblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspLeafblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspsurfaceReferenceblock[] ReadStructureBspsurfaceReferenceblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspsurfaceReferenceblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspsurfaceReferenceblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspsurfaceReferenceblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspClusterPortalblock[] ReadStructureBspClusterPortalblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterPortalblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterPortalblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterPortalblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspFogPlaneblock[] ReadStructureBspFogPlaneblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspFogPlaneblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspFogPlaneblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspFogPlaneblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspWeatherPaletteblock[] ReadStructureBspWeatherPaletteblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspWeatherPaletteblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspWeatherPaletteblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspWeatherPaletteblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspWeatherPolyhedronblock[] ReadStructureBspWeatherPolyhedronblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspWeatherPolyhedronblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspWeatherPolyhedronblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspWeatherPolyhedronblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspDetailObjectdatablock[] ReadStructureBspDetailObjectdatablockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspDetailObjectdatablock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspDetailObjectdatablock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspDetailObjectdatablock(binaryReader);
                }
            }
            return array;
        }
        StructureBspClusterblock[] ReadStructureBspClusterblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterblock(binaryReader);
                }
            }
            return array;
        }
        GlobalgeometryMaterialBlock[] ReadGlobalgeometryMaterialBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalgeometryMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalgeometryMaterialBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalgeometryMaterialBlock(binaryReader);
                }
            }
            return array;
        }
        StructureBspskyOwnerClusterblock[] ReadStructureBspskyOwnerClusterblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspskyOwnerClusterblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspskyOwnerClusterblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspskyOwnerClusterblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspConveyorsurfaceblock[] ReadStructureBspConveyorsurfaceblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspConveyorsurfaceblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspConveyorsurfaceblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspConveyorsurfaceblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspbreakablesurfaceblock[] ReadStructureBspbreakablesurfaceblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspbreakablesurfaceblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspbreakablesurfaceblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspbreakablesurfaceblock(binaryReader);
                }
            }
            return array;
        }
        PathfindingDataBlock[] ReadPathfindingDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PathfindingDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PathfindingDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PathfindingDataBlock(binaryReader);
                }
            }
            return array;
        }
        StructureBspPathfindingEdgesblock[] ReadStructureBspPathfindingEdgesblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspPathfindingEdgesblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspPathfindingEdgesblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspPathfindingEdgesblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspbackgroundsoundPaletteblock[] ReadStructureBspbackgroundsoundPaletteblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspbackgroundsoundPaletteblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspbackgroundsoundPaletteblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspbackgroundsoundPaletteblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspsoundEnvironmentPaletteblock[] ReadStructureBspsoundEnvironmentPaletteblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspsoundEnvironmentPaletteblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspsoundEnvironmentPaletteblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspsoundEnvironmentPaletteblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspMarkerblock[] ReadStructureBspMarkerblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspMarkerblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspMarkerblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspMarkerblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspRuntimeDecalblock[] ReadStructureBspRuntimeDecalblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspRuntimeDecalblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspRuntimeDecalblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspRuntimeDecalblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspEnvironmentObjectPaletteblock[] ReadStructureBspEnvironmentObjectPaletteblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspEnvironmentObjectPaletteblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspEnvironmentObjectPaletteblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspEnvironmentObjectPaletteblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspEnvironmentObjectblock[] ReadStructureBspEnvironmentObjectblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspEnvironmentObjectblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspEnvironmentObjectblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspEnvironmentObjectblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspLightmapDatablock[] ReadStructureBspLightmapDatablockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspLightmapDatablock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspLightmapDatablock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspLightmapDatablock(binaryReader);
                }
            }
            return array;
        }
        GlobalMapLeafBlock[] ReadGlobalMapLeafBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalMapLeafBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalMapLeafBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalMapLeafBlock(binaryReader);
                }
            }
            return array;
        }
        GlobalLeafConnectionBlock[] ReadGlobalLeafConnectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalLeafConnectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalLeafConnectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalLeafConnectionBlock(binaryReader);
                }
            }
            return array;
        }
        GlobalErrorReportCategoriesBlock[] ReadGlobalErrorReportCategoriesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalErrorReportCategoriesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                }
            }
            return array;
        }
        StructureBspPrecomputedLightingblock[] ReadStructureBspPrecomputedLightingblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspPrecomputedLightingblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspPrecomputedLightingblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspPrecomputedLightingblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspInstancedGeometryDefinitionblock[] ReadStructureBspInstancedGeometryDefinitionblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspInstancedGeometryDefinitionblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspInstancedGeometryDefinitionblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspInstancedGeometryDefinitionblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspInstancedGeometryinstancesblock[] ReadStructureBspInstancedGeometryinstancesblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspInstancedGeometryinstancesblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspInstancedGeometryinstancesblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspInstancedGeometryinstancesblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspsoundClusterblock[] ReadStructureBspsoundClusterblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspsoundClusterblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspsoundClusterblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspsoundClusterblock(binaryReader);
                }
            }
            return array;
        }
        TransparentPlanesBlock[] ReadTransparentPlanesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TransparentPlanesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TransparentPlanesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TransparentPlanesBlock(binaryReader);
                }
            }
            return array;
        }
        StructureBspDebugInfoblock[] ReadStructureBspDebugInfoblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspDebugInfoblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspDebugInfoblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspDebugInfoblock(binaryReader);
                }
            }
            return array;
        }
        GlobalWaterDefinitionsBlock[] ReadGlobalWaterDefinitionsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalWaterDefinitionsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalWaterDefinitionsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalWaterDefinitionsBlock(binaryReader);
                }
            }
            return array;
        }
        StructurePortalDeviceMappingBlock[] ReadStructurePortalDeviceMappingBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructurePortalDeviceMappingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructurePortalDeviceMappingBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructurePortalDeviceMappingBlock(binaryReader);
                }
            }
            return array;
        }
        StructureBspAudibilityblock[] ReadStructureBspAudibilityblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspAudibilityblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspAudibilityblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspAudibilityblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspFakeLightprobesblock[] ReadStructureBspFakeLightprobesblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspFakeLightprobesblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspFakeLightprobesblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspFakeLightprobesblock(binaryReader);
                }
            }
            return array;
        }
        DecoratorPlacementdefinitionBlock[] ReadDecoratorPlacementdefinitionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorPlacementdefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorPlacementdefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorPlacementdefinitionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
