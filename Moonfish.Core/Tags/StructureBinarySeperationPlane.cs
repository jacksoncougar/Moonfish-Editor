using Moonfish.Model;
using Moonfish.ResourceManagement;
using OpenTK;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags.BSP
{
    [StructLayout(LayoutKind.Sequential, Size = 588, Pack = 4)]
    [TagClass("sbsp")]
    public partial class ScenarioStructureBSP
    {
        [TagBlockField]
        public GlobalTagImportInfoBlock[] importInfo;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public StructureCollisionMaterialsBlock[] collisionMaterials;
        [TagBlockField]
        public GlobalCollisionBspBlock[] collisionBSP;
        public float vehicleFloorWorldUnitsHeightBelowWhichVehiclesGetPushedUpByAnUnstoppableForce;
        public float vehicleCeilingWorldUnitsHeightAboveWhichVehiclesGetPushedDownByAnUnstoppableForce;
        [TagBlockField]
        public UNUSEDStructureBspNodeBlock[] uNUSEDNodes;
        [TagBlockField]
        public StructureBspLeafBlock[] leaves;
        public Range worldBoundsX;
        public Range worldBoundsY;
        public Range worldBoundsZ;
        [TagBlockField]
        public StructureBspSurfaceReferenceBlock[] surfaceReferences;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingclusterData;
        #endregion
        [TagBlockField]
        public StructureBspClusterPortalBlock[] clusterPortals;
        [TagBlockField]
        public StructureBspFogPlaneBlock[] fogPlanes;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        private byte[] padding0;
        #endregion
        [TagBlockField]
        public StructureBspWeatherPaletteBlock[] weatherPalette;
        [TagBlockField]
        public StructureBspWeatherPolyhedronBlock[] weatherPolyhedra;
        [TagBlockField]
        public StructureBspDetailObjectDataBlock[] detailObjects;
        [TagBlockField]
        public StructureBspClusterBlock[] clusters;
        [TagBlockField]
        public GlobalGeometryMaterialBlock[] materials;
        [TagBlockField]
        public StructureBspSkyOwnerClusterBlock[] skyOwnerCluster;
        [TagBlockField]
        public StructureBspConveyorSurfaceBlock[] conveyorSurfaces;
        [TagBlockField]
        public StructureBspBreakableSurfaceBlock[] breakableSurfaces;
        [TagBlockField]
        public PathfindingDataBlock[] pathfindingData;
        [TagBlockField]
        public StructureBspPathfindingEdgesBlock[] pathfindingEdges;
        [TagBlockField]
        public StructureBspBackgroundSoundPaletteBlock[] backgroundSoundPalette;
        [TagBlockField]
        public StructureBspSoundEnvironmentPaletteBlock[] soundEnvironmentPalette;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingsoundPASData;
        #endregion
        [TagBlockField]
        public StructureBspMarkerBlock[] markers;
        [TagBlockField]
        public StructureBspRuntimeDecalBlock[] runtimeDecals;
        [TagBlockField]
        public StructureBspEnvironmentObjectPaletteBlock[] environmentObjectPalette;
        [TagBlockField]
        public StructureBspEnvironmentObjectBlock[] environmentObjects;
        [TagBlockField]
        public StructureBspLightmapDataBlock[] lightmaps;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding1;
        #endregion
        [TagBlockField]
        public GlobalMapLeafBlock[] leafMapLeaves;
        [TagBlockField]
        public GlobalLeafConnectionBlock[] leafMapConnections;
        [TagBlockField]
        public GlobalErrorReportCategoriesBlock[] errors;
        [TagBlockField]
        public StructureBspPrecomputedLightingBlock[] precomputedLighting;
        [TagBlockField]
        public StructureBspInstancedGeometryDefinitionBlock[] instancedGeometriesDefinitions;
        [TagBlockField]
        public StructureBspInstancedGeometryInstancesBlock[] instancedGeometryInstances;
        [TagBlockField]
        public StructureBspSoundClusterBlock[] ambienceSoundClusters;
        [TagBlockField]
        public StructureBspSoundClusterBlock[] reverbSoundClusters;
        [TagBlockField]
        public TransparentPlanesBlock[] transparentPlanes;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        private byte[] padding2;
        #endregion
        public float vehicleSpericalLimitRadiusDistancesThisFarAndLongerFromLimitOriginWillPullYouBackIn;
        public Vector3 vehicleSpericalLimitCenterCenterOfSpaceInWhichVehicleCanMove;
        [TagBlockField]
        public StructureBspDebugInfoBlock[] debugInfo;
        [TagReference("DECP")]
        public TagReference decorators;
        [TagStructField]
        public GlobalStructurePhysicsStruct structurePhysics;
        [TagBlockField]
        public GlobalWaterDefinitionsBlock[] waterDefinitions;
        [TagBlockField]
        public StructurePortalDeviceMappingBlock[] portalDeviceMapping;
        [TagBlockField]
        public StructureBspAudibilityBlock[] audibility;
        [TagBlockField]
        public StructureBspFakeLightprobesBlock[] objectFakeLightprobes;
        [TagBlockField]
        public DecoratorPlacementDefinitionBlock[] decorators0;
        public ScenarioStructureBSP()
        {
        }
        public ScenarioStructureBSP(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalTagImportInfoBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.importInfo = new GlobalTagImportInfoBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.importInfo[i] = new GlobalTagImportInfoBlock(binaryReader);
                    }
                }
            }
            this.padding = binaryReader.ReadBytes(4);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureCollisionMaterialsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.collisionMaterials = new StructureCollisionMaterialsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.collisionMaterials[i] = new StructureCollisionMaterialsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalCollisionBspBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.collisionBSP = new GlobalCollisionBspBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.collisionBSP[i] = new GlobalCollisionBspBlock(binaryReader);
                    }
                }
            }
            this.vehicleFloorWorldUnitsHeightBelowWhichVehiclesGetPushedUpByAnUnstoppableForce = binaryReader.ReadSingle();
            this.vehicleCeilingWorldUnitsHeightAboveWhichVehiclesGetPushedDownByAnUnstoppableForce = binaryReader.ReadSingle();
            {
                var elementSize = Marshal.SizeOf(typeof(UNUSEDStructureBspNodeBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.uNUSEDNodes = new UNUSEDStructureBspNodeBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.uNUSEDNodes[i] = new UNUSEDStructureBspNodeBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspLeafBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.leaves = new StructureBspLeafBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.leaves[i] = new StructureBspLeafBlock(binaryReader);
                    }
                }
            }
            this.worldBoundsX = binaryReader.ReadRange();
            this.worldBoundsY = binaryReader.ReadRange();
            this.worldBoundsZ = binaryReader.ReadRange();
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspSurfaceReferenceBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.surfaceReferences = new StructureBspSurfaceReferenceBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.surfaceReferences[i] = new StructureBspSurfaceReferenceBlock(binaryReader);
                    }
                }
            }
            this.paddingclusterData = binaryReader.ReadBytes(8);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspClusterPortalBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.clusterPortals = new StructureBspClusterPortalBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.clusterPortals[i] = new StructureBspClusterPortalBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspFogPlaneBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.fogPlanes = new StructureBspFogPlaneBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.fogPlanes[i] = new StructureBspFogPlaneBlock(binaryReader);
                    }
                }
            }
            this.padding0 = binaryReader.ReadBytes(24);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspWeatherPaletteBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.weatherPalette = new StructureBspWeatherPaletteBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.weatherPalette[i] = new StructureBspWeatherPaletteBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspWeatherPolyhedronBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.weatherPolyhedra = new StructureBspWeatherPolyhedronBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.weatherPolyhedra[i] = new StructureBspWeatherPolyhedronBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDetailObjectDataBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.detailObjects = new StructureBspDetailObjectDataBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.detailObjects[i] = new StructureBspDetailObjectDataBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspClusterBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.clusters = new StructureBspClusterBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.clusters[i] = new StructureBspClusterBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryMaterialBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.materials = new GlobalGeometryMaterialBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.materials[i] = new GlobalGeometryMaterialBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspSkyOwnerClusterBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.skyOwnerCluster = new StructureBspSkyOwnerClusterBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.skyOwnerCluster[i] = new StructureBspSkyOwnerClusterBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspConveyorSurfaceBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.conveyorSurfaces = new StructureBspConveyorSurfaceBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.conveyorSurfaces[i] = new StructureBspConveyorSurfaceBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspBreakableSurfaceBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.breakableSurfaces = new StructureBspBreakableSurfaceBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.breakableSurfaces[i] = new StructureBspBreakableSurfaceBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(PathfindingDataBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.pathfindingData = new PathfindingDataBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.pathfindingData[i] = new PathfindingDataBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspPathfindingEdgesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.pathfindingEdges = new StructureBspPathfindingEdgesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.pathfindingEdges[i] = new StructureBspPathfindingEdgesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspBackgroundSoundPaletteBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.backgroundSoundPalette = new StructureBspBackgroundSoundPaletteBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.backgroundSoundPalette[i] = new StructureBspBackgroundSoundPaletteBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspSoundEnvironmentPaletteBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.soundEnvironmentPalette = new StructureBspSoundEnvironmentPaletteBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.soundEnvironmentPalette[i] = new StructureBspSoundEnvironmentPaletteBlock(binaryReader);
                    }
                }
            }
            this.paddingsoundPASData = binaryReader.ReadBytes(8);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspMarkerBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.markers = new StructureBspMarkerBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.markers[i] = new StructureBspMarkerBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspRuntimeDecalBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.runtimeDecals = new StructureBspRuntimeDecalBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.runtimeDecals[i] = new StructureBspRuntimeDecalBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspEnvironmentObjectPaletteBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.environmentObjectPalette = new StructureBspEnvironmentObjectPaletteBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.environmentObjectPalette[i] = new StructureBspEnvironmentObjectPaletteBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspEnvironmentObjectBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.environmentObjects = new StructureBspEnvironmentObjectBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.environmentObjects[i] = new StructureBspEnvironmentObjectBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspLightmapDataBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.lightmaps = new StructureBspLightmapDataBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.lightmaps[i] = new StructureBspLightmapDataBlock(binaryReader);
                    }
                }
            }
            this.padding1 = binaryReader.ReadBytes(4);
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalMapLeafBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.leafMapLeaves = new GlobalMapLeafBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.leafMapLeaves[i] = new GlobalMapLeafBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalLeafConnectionBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.leafMapConnections = new GlobalLeafConnectionBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.leafMapConnections[i] = new GlobalLeafConnectionBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.errors = new GlobalErrorReportCategoriesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.errors[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspPrecomputedLightingBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.precomputedLighting = new StructureBspPrecomputedLightingBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.precomputedLighting[i] = new StructureBspPrecomputedLightingBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspInstancedGeometryDefinitionBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.instancedGeometriesDefinitions = new StructureBspInstancedGeometryDefinitionBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.instancedGeometriesDefinitions[i] = new StructureBspInstancedGeometryDefinitionBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspInstancedGeometryInstancesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.instancedGeometryInstances = new StructureBspInstancedGeometryInstancesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.instancedGeometryInstances[i] = new StructureBspInstancedGeometryInstancesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspSoundClusterBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.ambienceSoundClusters = new StructureBspSoundClusterBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.ambienceSoundClusters[i] = new StructureBspSoundClusterBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspSoundClusterBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.reverbSoundClusters = new StructureBspSoundClusterBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.reverbSoundClusters[i] = new StructureBspSoundClusterBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(TransparentPlanesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.transparentPlanes = new TransparentPlanesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.transparentPlanes[i] = new TransparentPlanesBlock(binaryReader);
                    }
                }
            }
            this.padding2 = binaryReader.ReadBytes(96);
            this.vehicleSpericalLimitRadiusDistancesThisFarAndLongerFromLimitOriginWillPullYouBackIn = binaryReader.ReadSingle();
            this.vehicleSpericalLimitCenterCenterOfSpaceInWhichVehicleCanMove = binaryReader.ReadVector3();
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.debugInfo = new StructureBspDebugInfoBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.debugInfo[i] = new StructureBspDebugInfoBlock(binaryReader);
                    }
                }
            }
            this.decorators = binaryReader.ReadTagReference();
            this.structurePhysics = new GlobalStructurePhysicsStruct(binaryReader);
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalWaterDefinitionsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.waterDefinitions = new GlobalWaterDefinitionsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.waterDefinitions[i] = new GlobalWaterDefinitionsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructurePortalDeviceMappingBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.portalDeviceMapping = new StructurePortalDeviceMappingBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.portalDeviceMapping[i] = new StructurePortalDeviceMappingBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspAudibilityBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.audibility = new StructureBspAudibilityBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.audibility[i] = new StructureBspAudibilityBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspFakeLightprobesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.objectFakeLightprobes = new StructureBspFakeLightprobesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.objectFakeLightprobes[i] = new StructureBspFakeLightprobesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(DecoratorPlacementDefinitionBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.decorators0 = new DecoratorPlacementDefinitionBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.decorators0[i] = new DecoratorPlacementDefinitionBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 528, Pack = 4)]
    public partial class TagImportFileBlock
    {
        public String256 path;
        public String32 modificationDate;
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] skip;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
        private byte[] padding0;
        #endregion
        public int checksumCrc32;
        public int sizeBytes;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingzippedData;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        private byte[] padding1;
        #endregion
        public TagImportFileBlock()
        {
        }
        public TagImportFileBlock(BinaryReader binaryReader)
        {
            this.path = binaryReader.ReadString256();
            this.modificationDate = binaryReader.ReadString32();
            this.skip = binaryReader.ReadBytes(8);
            this.padding0 = binaryReader.ReadBytes(88);
            this.checksumCrc32 = binaryReader.ReadInt32();
            this.sizeBytes = binaryReader.ReadInt32();
            this.paddingzippedData = binaryReader.ReadBytes(8);
            this.padding1 = binaryReader.ReadBytes(128);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 592, Pack = 4)]
    public partial class GlobalTagImportInfoBlock
    {
        public int build;
        public String256 version;
        public String32 importDate;
        public String32 culprit;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        private byte[] padding;
        #endregion
        public String32 importTime;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding0;
        #endregion
        [TagBlockField]
        public TagImportFileBlock[] files;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        private byte[] padding1;
        #endregion
        public GlobalTagImportInfoBlock()
        {
        }
        public GlobalTagImportInfoBlock(BinaryReader binaryReader)
        {
            this.build = binaryReader.ReadInt32();
            this.version = binaryReader.ReadString256();
            this.importDate = binaryReader.ReadString32();
            this.culprit = binaryReader.ReadString32();
            this.padding = binaryReader.ReadBytes(96);
            this.importTime = binaryReader.ReadString32();
            this.padding0 = binaryReader.ReadBytes(4);
            {
                var elementSize = Marshal.SizeOf(typeof(TagImportFileBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.files = new TagImportFileBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.files[i] = new TagImportFileBlock(binaryReader);
                    }
                }
            }
            this.padding1 = binaryReader.ReadBytes(128);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
    public partial class StructureCollisionMaterialsBlock
    {
        [TagReference("shad")]
        public TagReference oldShader;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public ShortBlockIndex1 conveyorSurfaceIndex;
        [TagReference("shad")]
        public TagReference newShader;
        public StructureCollisionMaterialsBlock()
        {
        }
        public StructureCollisionMaterialsBlock(BinaryReader binaryReader)
        {
            this.oldShader = binaryReader.ReadTagReference();
            this.padding = binaryReader.ReadBytes(2);
            this.conveyorSurfaceIndex = binaryReader.ReadShortBlockIndex1();
            this.newShader = binaryReader.ReadTagReference();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 8)]
    public partial class Bsp3dNodesBlock
    {
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] skip;
        #endregion
        public Bsp3dNodesBlock()
        {
        }
        public Bsp3dNodesBlock(BinaryReader binaryReader)
        {
            this.skip = binaryReader.ReadBytes(8);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 16)]
    public partial class PlanesBlock
    {
        public Vector4 plane;
        public PlanesBlock()
        {
        }
        public PlanesBlock(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadVector4();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class LeavesBlock
    {
        public Flags flags;
        public byte bSP2DReferenceCount;
        public short firstBSP2DReference;
        public LeavesBlock()
        {
        }
        public LeavesBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadByte();
            this.bSP2DReferenceCount = binaryReader.ReadByte();
            this.firstBSP2DReference = binaryReader.ReadInt16();
        }
        [Flags]
        public enum Flags : byte
        {
            ContainsDoubleSidedSurfaces = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class Bsp2dReferencesBlock
    {
        public short plane;
        public short bSP2DNode;
        public Bsp2dReferencesBlock()
        {
        }
        public Bsp2dReferencesBlock(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadInt16();
            this.bSP2DNode = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 16)]
    public partial class Bsp2dNodesBlock
    {
        public Vector3 plane;
        public short leftChild;
        public short rightChild;
        public Bsp2dNodesBlock()
        {
        }
        public Bsp2dNodesBlock(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadVector3();
            this.leftChild = binaryReader.ReadInt16();
            this.rightChild = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 8)]
    public partial class SurfacesBlock
    {
        public short plane;
        public short firstEdge;
        public Flags flags;
        public byte breakableSurface;
        public short material;
        public SurfacesBlock()
        {
        }
        public SurfacesBlock(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadInt16();
            this.firstEdge = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadByte();
            this.breakableSurface = binaryReader.ReadByte();
            this.material = binaryReader.ReadInt16();
        }
        [Flags]
        public enum Flags : byte
        {
            TwoSided = 1,
            Invisible = 2,
            Climbable = 4,
            Breakable = 8,
            Invalid = 16,
            Conveyor = 32,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class EdgesBlock
    {
        public short startVertex;
        public short endVertex;
        public short forwardEdge;
        public short reverseEdge;
        public short leftSurface;
        public short rightSurface;
        public EdgesBlock()
        {
        }
        public EdgesBlock(BinaryReader binaryReader)
        {
            this.startVertex = binaryReader.ReadInt16();
            this.endVertex = binaryReader.ReadInt16();
            this.forwardEdge = binaryReader.ReadInt16();
            this.reverseEdge = binaryReader.ReadInt16();
            this.leftSurface = binaryReader.ReadInt16();
            this.rightSurface = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 16)]
    public partial class VerticesBlock
    {
        public Vector3 point;
        public short firstEdge;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public VerticesBlock()
        {
        }
        public VerticesBlock(BinaryReader binaryReader)
        {
            this.point = binaryReader.ReadVector3();
            this.firstEdge = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
    public partial class GlobalCollisionBspBlock
    {
        [TagBlockField]
        public Bsp3dNodesBlock[] bSP3DNodes;
        [TagBlockField]
        public PlanesBlock[] planes;
        [TagBlockField]
        public LeavesBlock[] leaves;
        [TagBlockField]
        public Bsp2dReferencesBlock[] bSP2DReferences;
        [TagBlockField]
        public Bsp2dNodesBlock[] bSP2DNodes;
        [TagBlockField]
        public SurfacesBlock[] surfaces;
        [TagBlockField]
        public EdgesBlock[] edges;
        [TagBlockField]
        public VerticesBlock[] vertices;
        public GlobalCollisionBspBlock()
        {
        }
        public GlobalCollisionBspBlock(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(Bsp3dNodesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.bSP3DNodes = new Bsp3dNodesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.bSP3DNodes[i] = new Bsp3dNodesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(PlanesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.planes = new PlanesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.planes[i] = new PlanesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(LeavesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.leaves = new LeavesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.leaves[i] = new LeavesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(Bsp2dReferencesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.bSP2DReferences = new Bsp2dReferencesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.bSP2DReferences[i] = new Bsp2dReferencesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(Bsp2dNodesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.bSP2DNodes = new Bsp2dNodesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.bSP2DNodes[i] = new Bsp2dNodesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(SurfacesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.surfaces = new SurfacesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.surfaces[i] = new SurfacesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(EdgesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.edges = new EdgesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.edges[i] = new EdgesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(VerticesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.vertices = new VerticesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.vertices[i] = new VerticesBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 4)]
    public partial class UNUSEDStructureBspNodeBlock
    {
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        private byte[] skip;
        #endregion
        public UNUSEDStructureBspNodeBlock()
        {
        }
        public UNUSEDStructureBspNodeBlock(BinaryReader binaryReader)
        {
            this.skip = binaryReader.ReadBytes(6);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class StructureBspLeafBlock
    {
        public short cluster;
        public short surfaceReferenceCount;
        public int firstSurfaceReferenceIndex;
        public StructureBspLeafBlock()
        {
        }
        public StructureBspLeafBlock(BinaryReader binaryReader)
        {
            this.cluster = binaryReader.ReadInt16();
            this.surfaceReferenceCount = binaryReader.ReadInt16();
            this.firstSurfaceReferenceIndex = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class StructureBspSurfaceReferenceBlock
    {
        public short stripIndex;
        public short lightmapTriangleIndex;
        public int bSPNodeIndex;
        public StructureBspSurfaceReferenceBlock()
        {
        }
        public StructureBspSurfaceReferenceBlock(BinaryReader binaryReader)
        {
            this.stripIndex = binaryReader.ReadInt16();
            this.lightmapTriangleIndex = binaryReader.ReadInt16();
            this.bSPNodeIndex = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class StructureBspClusterPortalVertexBlock
    {
        public Vector3 point;
        public StructureBspClusterPortalVertexBlock()
        {
        }
        public StructureBspClusterPortalVertexBlock(BinaryReader binaryReader)
        {
            this.point = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
    public partial class StructureBspClusterPortalBlock
    {
        public short backCluster;
        public short frontCluster;
        public int planeIndex;
        public Vector3 centroid;
        public float boundingRadius;
        public Flags flags;
        [TagBlockField]
        public StructureBspClusterPortalVertexBlock[] vertices;
        public StructureBspClusterPortalBlock()
        {
        }
        public StructureBspClusterPortalBlock(BinaryReader binaryReader)
        {
            this.backCluster = binaryReader.ReadInt16();
            this.frontCluster = binaryReader.ReadInt16();
            this.planeIndex = binaryReader.ReadInt32();
            this.centroid = binaryReader.ReadVector3();
            this.boundingRadius = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspClusterPortalVertexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.vertices = new StructureBspClusterPortalVertexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.vertices[i] = new StructureBspClusterPortalVertexBlock(binaryReader);
                    }
                }
            }
        }
        [Flags]
        public enum Flags : int
        {
            AICannotHearThroughThis = 1,
            OneWay = 2,
            Door = 4,
            NoWay = 8,
            OneWayReversed = 16,
            NoOneCanHearThroughThis = 32,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
    public partial class StructureBspFogPlaneBlock
    {
        public short scenarioPlanarFogIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public Vector4 plane;
        public Flags flags;
        public short priority;
        public StructureBspFogPlaneBlock()
        {
        }
        public StructureBspFogPlaneBlock(BinaryReader binaryReader)
        {
            this.scenarioPlanarFogIndex = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.plane = binaryReader.ReadVector4();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.priority = binaryReader.ReadInt16();
        }
        [Flags]
        public enum Flags : short
        {
            ExtendInfinitelyWhileVisible = 1,
            DoNotFloodfill = 2,
            AggressiveFloodfill = 4,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 136, Pack = 4)]
    public partial class StructureBspWeatherPaletteBlock
    {
        public String32 name;
        [TagReference("weat")]
        public TagReference weatherSystem;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        private byte[] padding1;
        #endregion
        [TagReference("wind")]
        public TagReference wind;
        public Vector3 windDirection;
        public float windMagnitude;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding2;
        #endregion
        public String32 windScaleFunction;
        public StructureBspWeatherPaletteBlock()
        {
        }
        public StructureBspWeatherPaletteBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.weatherSystem = binaryReader.ReadTagReference();
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(2);
            this.padding1 = binaryReader.ReadBytes(32);
            this.wind = binaryReader.ReadTagReference();
            this.windDirection = binaryReader.ReadVector3();
            this.windMagnitude = binaryReader.ReadSingle();
            this.padding2 = binaryReader.ReadBytes(4);
            this.windScaleFunction = binaryReader.ReadString32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class StructureBspWeatherPolyhedronPlaneBlock
    {
        public Vector4 plane;
        public StructureBspWeatherPolyhedronPlaneBlock()
        {
        }
        public StructureBspWeatherPolyhedronPlaneBlock(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadVector4();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
    public partial class StructureBspWeatherPolyhedronBlock
    {
        public Vector3 boundingSphereCenter;
        public float boundingSphereRadius;
        [TagBlockField]
        public StructureBspWeatherPolyhedronPlaneBlock[] planes;
        public StructureBspWeatherPolyhedronBlock()
        {
        }
        public StructureBspWeatherPolyhedronBlock(BinaryReader binaryReader)
        {
            this.boundingSphereCenter = binaryReader.ReadVector3();
            this.boundingSphereRadius = binaryReader.ReadSingle();
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspWeatherPolyhedronPlaneBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.planes = new StructureBspWeatherPolyhedronPlaneBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.planes[i] = new StructureBspWeatherPolyhedronPlaneBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class GlobalDetailObjectCellsBlock
    {
        public short invalidName_;
        public short invalidName_0;
        public short invalidName_1;
        public short invalidName_2;
        public int invalidName_3;
        public int invalidName_4;
        public int invalidName_5;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] padding6;
        #endregion
        public GlobalDetailObjectCellsBlock()
        {
        }
        public GlobalDetailObjectCellsBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadInt32();
            this.invalidName_4 = binaryReader.ReadInt32();
            this.invalidName_5 = binaryReader.ReadInt32();
            this.padding6 = binaryReader.ReadBytes(12);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 4)]
    public partial class GlobalDetailObjectBlock
    {
        public byte invalidName_;
        public byte invalidName_0;
        public byte invalidName_1;
        public byte invalidName_2;
        public short invalidName_3;
        public GlobalDetailObjectBlock()
        {
        }
        public GlobalDetailObjectBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadByte();
            this.invalidName_1 = binaryReader.ReadByte();
            this.invalidName_2 = binaryReader.ReadByte();
            this.invalidName_3 = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class GlobalDetailObjectCountsBlock
    {
        public short invalidName_;
        public GlobalDetailObjectCountsBlock()
        {
        }
        public GlobalDetailObjectCountsBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class GlobalZReferenceVectorBlock
    {
        public float invalidName_;
        public float invalidName_0;
        public float invalidName_1;
        public float invalidName_2;
        public GlobalZReferenceVectorBlock()
        {
        }
        public GlobalZReferenceVectorBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
    public partial class StructureBspDetailObjectDataBlock
    {
        [TagBlockField]
        public GlobalDetailObjectCellsBlock[] cells;
        [TagBlockField]
        public GlobalDetailObjectBlock[] instances;
        [TagBlockField]
        public GlobalDetailObjectCountsBlock[] counts;
        [TagBlockField]
        public GlobalZReferenceVectorBlock[] zReferenceVectors;
        #region padding
        private byte padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        private byte[] padding0;
        #endregion
        public StructureBspDetailObjectDataBlock()
        {
        }
        public StructureBspDetailObjectDataBlock(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalDetailObjectCellsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.cells = new GlobalDetailObjectCellsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.cells[i] = new GlobalDetailObjectCellsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalDetailObjectBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.instances = new GlobalDetailObjectBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.instances[i] = new GlobalDetailObjectBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalDetailObjectCountsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.counts = new GlobalDetailObjectCountsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.counts[i] = new GlobalDetailObjectCountsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalZReferenceVectorBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.zReferenceVectors = new GlobalZReferenceVectorBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.zReferenceVectors[i] = new GlobalZReferenceVectorBlock(binaryReader);
                    }
                }
            }
            this.padding = binaryReader.ReadByte();
            this.padding0 = binaryReader.ReadBytes(3);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 4)]
    public partial class GlobalGeometryCompressionInfoBlock
    {
        public Range positionBoundsX;
        public Range positionBoundsY;
        public Range positionBoundsZ;
        public Range texcoordBoundsX;
        public Range texcoordBoundsY;
        public Range secondaryTexcoordBoundsX;
        public Range secondaryTexcoordBoundsY;
        public GlobalGeometryCompressionInfoBlock()
        {
        }
        public GlobalGeometryCompressionInfoBlock(BinaryReader binaryReader)
        {
            this.positionBoundsX = binaryReader.ReadRange();
            this.positionBoundsY = binaryReader.ReadRange();
            this.positionBoundsZ = binaryReader.ReadRange();
            this.texcoordBoundsX = binaryReader.ReadRange();
            this.texcoordBoundsY = binaryReader.ReadRange();
            this.secondaryTexcoordBoundsX = binaryReader.ReadRange();
            this.secondaryTexcoordBoundsY = binaryReader.ReadRange();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
    public partial class GlobalGeometrySectionInfoStruct
    {
        public short totalVertexCount;
        public short totalTriangleCount;
        public short totalPartCount;
        public short shadowCastingTriangleCount;
        public short shadowCastingPartCount;
        public short opaquePointCount;
        public short opaqueVertexCount;
        public short opaquePartCount;
        public byte opaqueMaxNodesVertex;
        public byte transparentMaxNodesVertex;
        public short shadowCastingRigidTriangleCount;
        public GeometryClassification geometryClassification;
        public GeometryCompressionFlags geometryCompressionFlags;
        [TagBlockField]
        public GlobalGeometryCompressionInfoBlock[] eMPTYSTRING;
        public byte hardwareNodeCount;
        public byte nodeMapSize;
        public short softwarePlaneCount;
        public short totalSubpartCont;
        public SectionLightingFlags sectionLightingFlags;
        public GlobalGeometrySectionInfoStruct()
        {
        }
        public GlobalGeometrySectionInfoStruct(BinaryReader binaryReader)
        {
            this.totalVertexCount = binaryReader.ReadInt16();
            this.totalTriangleCount = binaryReader.ReadInt16();
            this.totalPartCount = binaryReader.ReadInt16();
            this.shadowCastingTriangleCount = binaryReader.ReadInt16();
            this.shadowCastingPartCount = binaryReader.ReadInt16();
            this.opaquePointCount = binaryReader.ReadInt16();
            this.opaqueVertexCount = binaryReader.ReadInt16();
            this.opaquePartCount = binaryReader.ReadInt16();
            this.opaqueMaxNodesVertex = binaryReader.ReadByte();
            this.transparentMaxNodesVertex = binaryReader.ReadByte();
            this.shadowCastingRigidTriangleCount = binaryReader.ReadInt16();
            this.geometryClassification = (GeometryClassification)binaryReader.ReadInt16();
            this.geometryCompressionFlags = (GeometryCompressionFlags)binaryReader.ReadInt16();
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryCompressionInfoBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.eMPTYSTRING = new GlobalGeometryCompressionInfoBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.eMPTYSTRING[i] = new GlobalGeometryCompressionInfoBlock(binaryReader);
                    }
                }
            }
            this.hardwareNodeCount = binaryReader.ReadByte();
            this.nodeMapSize = binaryReader.ReadByte();
            this.softwarePlaneCount = binaryReader.ReadInt16();
            this.totalSubpartCont = binaryReader.ReadInt16();
            this.sectionLightingFlags = (SectionLightingFlags)binaryReader.ReadInt16();
        }
        public enum GeometryClassification : short
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        }
        [Flags]
        public enum GeometryCompressionFlags : short
        {
            CompressedPosition = 1,
            CompressedTexcoord = 2,
            CompressedSecondaryTexcoord = 4,
        }
        [Flags]
        public enum SectionLightingFlags : short
        {
            HasLmTexcoords = 1,
            HasLmIncRad = 2,
            HasLmColors = 4,
            HasLmPrt = 8,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class GlobalGeometryBlockResourceBlock
    {
        public Type type;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        private byte[] padding;
        #endregion
        public short primaryLocator;
        public short secondaryLocator;
        public int resourceDataSize;
        public int resourceDataOffset;
        public GlobalGeometryBlockResourceBlock()
        {
        }
        public GlobalGeometryBlockResourceBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadByte();
            this.padding = binaryReader.ReadBytes(3);
            this.primaryLocator = binaryReader.ReadInt16();
            this.secondaryLocator = binaryReader.ReadInt16();
            this.resourceDataSize = binaryReader.ReadInt32();
            this.resourceDataOffset = binaryReader.ReadInt32();
        }
        public enum Type : byte
        {
            TagBlock = 0,
            TagData = 1,
            VertexBuffer = 2,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
    public partial class GlobalGeometryBlockInfoStruct
    {
        public int blockOffset;
        public int blockSize;
        public int sectionDataSize;
        public int resourceDataSize;
        [TagBlockField]
        public GlobalGeometryBlockResourceBlock[] resources;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public short ownerTagSectionOffset;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding1;
        #endregion
        public GlobalGeometryBlockInfoStruct()
        {
        }
        public GlobalGeometryBlockInfoStruct(BinaryReader binaryReader)
        {
            this.blockOffset = binaryReader.ReadInt32();
            this.blockSize = binaryReader.ReadInt32();
            this.sectionDataSize = binaryReader.ReadInt32();
            this.resourceDataSize = binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryBlockResourceBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.resources = new GlobalGeometryBlockResourceBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.resources[i] = new GlobalGeometryBlockResourceBlock(binaryReader);
                    }
                }
            }
            this.padding = binaryReader.ReadBytes(4);
            this.ownerTagSectionOffset = binaryReader.ReadInt16();
            this.padding0 = binaryReader.ReadBytes(2);
            this.padding1 = binaryReader.ReadBytes(4);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 72, Pack = 4)]
    public partial class GlobalGeometryPartBlockNew
    {
        public Type type;
        public Flags flags;
        public ShortBlockIndex1 material;
        public short stripStartIndex;
        public short stripLength;
        public short firstSubpartIndex;
        public short subpartCount;
        public byte maxNodesVertex;
        public byte contributingCompoundNodeCount;
        public Vector3 position;
        public struct NodeIndices
        {
            public byte nodeIndex;
            public NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndices[] nodeIndices;
        public struct NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public NodeWeights[] nodeWeights;
        public float lodMipmapMagicNumber;
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        private byte[] skip;
        #endregion
        public GlobalGeometryPartBlockNew()
        {
        }
        public GlobalGeometryPartBlockNew(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.material = binaryReader.ReadShortBlockIndex1();
            this.stripStartIndex = binaryReader.ReadInt16();
            this.stripLength = binaryReader.ReadInt16();
            this.firstSubpartIndex = binaryReader.ReadInt16();
            this.subpartCount = binaryReader.ReadInt16();
            this.maxNodesVertex = binaryReader.ReadByte();
            this.contributingCompoundNodeCount = binaryReader.ReadByte();
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndices[i] = new NodeIndices(binaryReader);
            }
            this.nodeWeights = new NodeWeights[3];
            for (int i = 0; i < 3; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.lodMipmapMagicNumber = binaryReader.ReadSingle();
            this.skip = binaryReader.ReadBytes(24);
        }
        public enum Type : short
        {
            NotDrawn = 0,
            OpaqueShadowOnly = 1,
            OpaqueShadowCasting = 2,
            OpaqueNonshadowing = 3,
            Transparent = 4,
            LightmapOnly = 5,
        }
        [Flags]
        public enum Flags : short
        {
            Decalable = 1,
            NewPartTypes = 2,
            DislikesPhotons = 4,
            OverrideTriangleList = 8,
            IgnoredByLightmapper = 16,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class GlobalSubpartsBlock
    {
        public short indicesStartIndex;
        public short indicesLength;
        public short visibilityBoundsIndex;
        public short partIndex;
        public GlobalSubpartsBlock()
        {
        }
        public GlobalSubpartsBlock(BinaryReader binaryReader)
        {
            this.indicesStartIndex = binaryReader.ReadInt16();
            this.indicesLength = binaryReader.ReadInt16();
            this.visibilityBoundsIndex = binaryReader.ReadInt16();
            this.partIndex = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
    public partial class GlobalVisibilityBoundsBlock
    {
        public float positionX;
        public float positionY;
        public float positionZ;
        public float radius;
        public byte node0;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        private byte[] padding;
        #endregion
        public GlobalVisibilityBoundsBlock()
        {
        }
        public GlobalVisibilityBoundsBlock(BinaryReader binaryReader)
        {
            this.positionX = binaryReader.ReadSingle();
            this.positionY = binaryReader.ReadSingle();
            this.positionZ = binaryReader.ReadSingle();
            this.radius = binaryReader.ReadSingle();
            this.node0 = binaryReader.ReadByte();
            this.padding = binaryReader.ReadBytes(3);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 196, Pack = 4)]
    public partial class GlobalGeometrySectionRawVertexBlock
    {
        public Vector3 position;
        public struct NodeIndicesOLD
        {
            public int nodeIndexOLD;
            public NodeIndicesOLD(BinaryReader binaryReader)
            {
                this.nodeIndexOLD = binaryReader.ReadInt32();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndicesOLD[] nodeIndicesOLD;
        public struct NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeWeights[] nodeWeights;
        public struct NodeIndicesNEW
        {
            public int nodeIndexNEW;
            public NodeIndicesNEW(BinaryReader binaryReader)
            {
                this.nodeIndexNEW = binaryReader.ReadInt32();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndicesNEW[] nodeIndicesNEW;
        public int useNewNodeIndices;
        public int adjustedCompoundNodeIndex;
        public Vector2 texcoord;
        public Vector3 normal;
        public Vector3 binormal;
        public Vector3 tangent;
        public Vector3 anisotropicBinormal;
        public Vector2 secondaryTexcoord;
        public ColorR8G8B8 primaryLightmapColor;
        public Vector2 primaryLightmapTexcoord;
        public Vector3 primaryLightmapIncidentDirection;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] padding0;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] padding1;
        #endregion
        public GlobalGeometrySectionRawVertexBlock()
        {
        }
        public GlobalGeometrySectionRawVertexBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndicesOLD = new NodeIndicesOLD[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndicesOLD[i] = new NodeIndicesOLD(binaryReader);
            }
            this.nodeWeights = new NodeWeights[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.nodeIndicesNEW = new NodeIndicesNEW[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndicesNEW[i] = new NodeIndicesNEW(binaryReader);
            }
            this.useNewNodeIndices = binaryReader.ReadInt32();
            this.adjustedCompoundNodeIndex = binaryReader.ReadInt32();
            this.texcoord = binaryReader.ReadVector2();
            this.normal = binaryReader.ReadVector3();
            this.binormal = binaryReader.ReadVector3();
            this.tangent = binaryReader.ReadVector3();
            this.anisotropicBinormal = binaryReader.ReadVector3();
            this.secondaryTexcoord = binaryReader.ReadVector2();
            this.primaryLightmapColor = binaryReader.ReadColorR8G8B8();
            this.primaryLightmapTexcoord = binaryReader.ReadVector2();
            this.primaryLightmapIncidentDirection = binaryReader.ReadVector3();
            this.padding = binaryReader.ReadBytes(12);
            this.padding0 = binaryReader.ReadBytes(8);
            this.padding1 = binaryReader.ReadBytes(12);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class GlobalGeometrySectionStripIndexBlock
    {
        public short index;
        public GlobalGeometrySectionStripIndexBlock()
        {
        }
        public GlobalGeometrySectionStripIndexBlock(BinaryReader binaryReader)
        {
            this.index = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class GlobalGeometrySectionVertexBufferBlock
    {
        public VertexBuffer vertexBuffer;
        public GlobalGeometrySectionVertexBufferBlock()
        {
        }
        public GlobalGeometrySectionVertexBufferBlock(BinaryReader binaryReader)
        {
            this.vertexBuffer = binaryReader.ReadVertexBuffer();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
    public partial class GlobalGeometrySectionStruct
    {
        [TagBlockField]
        public Moonfish.Tags.GlobalGeometryPartBlockNew[] parts;
        [TagBlockField]
        public GlobalSubpartsBlock[] subparts;
        [TagBlockField]
        public GlobalVisibilityBoundsBlock[] visibilityBounds;
        [TagBlockField]
        public GlobalGeometrySectionRawVertexBlock[] rawVertices;
        [TagBlockField]
        public GlobalGeometrySectionStripIndexBlock[] stripIndices;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingvisibilityMoppCode;
        #endregion
        [TagBlockField]
        public GlobalGeometrySectionStripIndexBlock[] moppReorderTable;
        [TagBlockField]
        public Moonfish.Tags.GlobalGeometrySectionVertexBufferBlock[] vertexBuffers;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public GlobalGeometrySectionStruct()
        {
        }
        public GlobalGeometrySectionStruct(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryPartBlockNew));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.parts = new Moonfish.Tags.GlobalGeometryPartBlockNew[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.parts[i] = new Moonfish.Tags.GlobalGeometryPartBlockNew(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalSubpartsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.subparts = new GlobalSubpartsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.subparts[i] = new GlobalSubpartsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalVisibilityBoundsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.visibilityBounds = new GlobalVisibilityBoundsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.visibilityBounds[i] = new GlobalVisibilityBoundsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionRawVertexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.rawVertices = new GlobalGeometrySectionRawVertexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.rawVertices[i] = new GlobalGeometrySectionRawVertexBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.stripIndices = new GlobalGeometrySectionStripIndexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.stripIndices[i] = new GlobalGeometrySectionStripIndexBlock(binaryReader);
                    }
                }
            }
            this.paddingvisibilityMoppCode = binaryReader.ReadBytes(8);
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.moppReorderTable = new GlobalGeometrySectionStripIndexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.moppReorderTable[i] = new GlobalGeometrySectionStripIndexBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(Moonfish.Tags.GlobalGeometrySectionVertexBufferBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                var vertexBuffers = new Moonfish.Tags.GlobalGeometrySectionVertexBufferBlock[blamPointer.Count];
                List<BlamPointer> vertexBufferPointers = null;
                if (binaryReader.BaseStream is ResourceStream)
                {
                    var stream = binaryReader.BaseStream as ResourceStream;
                    vertexBufferPointers = stream.Resources.Where(x => x.type == Moonfish.Tags.GlobalGeometryBlockResourceBlock.Type.VertexBuffer)
                    .Select(x =>
                    {
                        var count = x.resourceDataSize;
                        var address = x.resourceDataOffset + stream.HeaderSize;
                        var size = 1;
                        return new BlamPointer(count, address, size);
                    }).ToList();
                }
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        vertexBuffers[i] = new Moonfish.Tags.GlobalGeometrySectionVertexBufferBlock(binaryReader);
                        if (vertexBufferPointers != null)
                        {
                            binaryReader.BaseStream.Position = vertexBufferPointers[i].Address;
                            vertexBuffers[i].vertexBuffer.Data = binaryReader.ReadBytes(vertexBufferPointers[i].Count);
                        }
                    }
                }
                this.vertexBuffers = vertexBuffers;
            }

            this.padding = binaryReader.ReadBytes(4);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
    public partial class StructureBspClusterDataBlockNew
    {
        [TagStructField]
        public GlobalGeometrySectionStruct section;
        public StructureBspClusterDataBlockNew()
        {
        }
        public StructureBspClusterDataBlockNew(BinaryReader binaryReader)
        {
            this.section = new GlobalGeometrySectionStruct(binaryReader);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class PredictedResourceBlock
    {
        public Type type;
        public short resourceIndex;
        public int tagIndex;
        public PredictedResourceBlock()
        {
        }
        public PredictedResourceBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.resourceIndex = binaryReader.ReadInt16();
            this.tagIndex = binaryReader.ReadInt32();
        }
        public enum Type : short
        {
            Bitmap = 0,
            Sound = 1,
            RenderModelGeometry = 2,
            ClusterGeometry = 3,
            ClusterInstancedGeometry = 4,
            LightmapGeometryObjectBuckets = 5,
            LightmapGeometryInstanceBuckets = 6,
            LightmapClusterBitmaps = 7,
            LightmapInstanceBitmaps = 8,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class StructureBspClusterPortalIndexBlock
    {
        public short portalIndex;
        public StructureBspClusterPortalIndexBlock()
        {
        }
        public StructureBspClusterPortalIndexBlock(BinaryReader binaryReader)
        {
            this.portalIndex = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class StructureBspClusterInstancedGeometryIndexBlock
    {
        public short instancedGeometryIndex;
        public StructureBspClusterInstancedGeometryIndexBlock()
        {
        }
        public StructureBspClusterInstancedGeometryIndexBlock(BinaryReader binaryReader)
        {
            this.instancedGeometryIndex = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 176, Pack = 4)]
    public partial class StructureBspClusterBlock
    {
        [TagStructField]
        public GlobalGeometrySectionInfoStruct sectionInfo;
        [TagStructField]
        public Moonfish.Tags.GlobalGeometryBlockInfoStruct geometryBlockInfo;
        [TagBlockField]
        public StructureBspClusterDataBlockNew[] clusterData;
        public Range boundsX;
        public Range boundsY;
        public Range boundsZ;
        public byte scenarioSkyIndex;
        public byte mediaIndex;
        public byte scenarioVisibleSkyIndex;
        public byte scenarioAtmosphericFogIndex;
        public byte planarFogDesignator;
        public byte visibleFogPlaneIndex;
        public ShortBlockIndex1 backgroundSound;
        public ShortBlockIndex1 soundEnvironment;
        public ShortBlockIndex1 weather;
        public short transitionStructureBSP;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding0;
        #endregion
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding1;
        #endregion
        [TagBlockField]
        public PredictedResourceBlock[] predictedResources;
        [TagBlockField]
        public StructureBspClusterPortalIndexBlock[] portals;
        public int checksumFromStructure;
        [TagBlockField]
        public StructureBspClusterInstancedGeometryIndexBlock[] instancedGeometryIndices;
        [TagBlockField]
        public GlobalGeometrySectionStripIndexBlock[] indexReorderTable;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingcollisionMoppCode;
        #endregion
        public StructureBspClusterBlock()
        {
        }
        public StructureBspClusterBlock(BinaryReader binaryReader)
        {
            this.sectionInfo = new GlobalGeometrySectionInfoStruct(binaryReader);
            this.geometryBlockInfo = new Moonfish.Tags.GlobalGeometryBlockInfoStruct(binaryReader);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspClusterDataBlockNew));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.clusterData = new StructureBspClusterDataBlockNew[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.clusterData[i] = new StructureBspClusterDataBlockNew(binaryReader);
                    }
                }
            }
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
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(4);
            this.flags = (Flags)binaryReader.ReadInt16();
            this.padding1 = binaryReader.ReadBytes(2);
            {
                var elementSize = Marshal.SizeOf(typeof(PredictedResourceBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.predictedResources = new PredictedResourceBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.predictedResources[i] = new PredictedResourceBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspClusterPortalIndexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.portals = new StructureBspClusterPortalIndexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.portals[i] = new StructureBspClusterPortalIndexBlock(binaryReader);
                    }
                }
            }
            this.checksumFromStructure = binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspClusterInstancedGeometryIndexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.instancedGeometryIndices = new StructureBspClusterInstancedGeometryIndexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.instancedGeometryIndices[i] = new StructureBspClusterInstancedGeometryIndexBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.indexReorderTable = new GlobalGeometrySectionStripIndexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.indexReorderTable[i] = new GlobalGeometrySectionStripIndexBlock(binaryReader);
                    }
                }
            }
            this.paddingcollisionMoppCode = binaryReader.ReadBytes(8);
        }
        [Flags]
        public enum Flags : short
        {
            OneWayPortal = 1,
            DoorPortal = 2,
            PostprocessedGeometry = 4,
            IsTheSky = 8,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class GlobalGeometryMaterialPropertyBlock
    {
        public Type type;
        public short intValue;
        public float realValue;
        public GlobalGeometryMaterialPropertyBlock()
        {
        }
        public GlobalGeometryMaterialPropertyBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.intValue = binaryReader.ReadInt16();
            this.realValue = binaryReader.ReadSingle();
        }
        public enum Type : short
        {
            LightmapResolution = 0,
            LightmapPower = 1,
            LightmapHalfLife = 2,
            LightmapDiffuseScale = 3,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class GlobalGeometryMaterialBlock
    {
        [TagReference("shad")]
        public TagReference oldShader;
        [TagReference("shad")]
        public TagReference shader;
        [TagBlockField]
        public GlobalGeometryMaterialPropertyBlock[] properties;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public byte breakableSurfaceIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        private byte[] padding0;
        #endregion
        public GlobalGeometryMaterialBlock()
        {
        }
        public GlobalGeometryMaterialBlock(BinaryReader binaryReader)
        {
            this.oldShader = binaryReader.ReadTagReference();
            this.shader = binaryReader.ReadTagReference();
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryMaterialPropertyBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.properties = new GlobalGeometryMaterialPropertyBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.properties[i] = new GlobalGeometryMaterialPropertyBlock(binaryReader);
                    }
                }
            }
            this.padding = binaryReader.ReadBytes(4);
            this.breakableSurfaceIndex = binaryReader.ReadByte();
            this.padding0 = binaryReader.ReadBytes(3);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class StructureBspSkyOwnerClusterBlock
    {
        public short clusterOwner;
        public StructureBspSkyOwnerClusterBlock()
        {
        }
        public StructureBspSkyOwnerClusterBlock(BinaryReader binaryReader)
        {
            this.clusterOwner = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
    public partial class StructureBspConveyorSurfaceBlock
    {
        public Vector3 u;
        public Vector3 v;
        public StructureBspConveyorSurfaceBlock()
        {
        }
        public StructureBspConveyorSurfaceBlock(BinaryReader binaryReader)
        {
            this.u = binaryReader.ReadVector3();
            this.v = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
    public partial class StructureBspBreakableSurfaceBlock
    {
        public ShortBlockIndex1 instancedGeometryInstance;
        public short breakableSurfaceIndex;
        public Vector3 centroid;
        public float radius;
        public int collisionSurfaceIndex;
        public StructureBspBreakableSurfaceBlock()
        {
        }
        public StructureBspBreakableSurfaceBlock(BinaryReader binaryReader)
        {
            this.instancedGeometryInstance = binaryReader.ReadShortBlockIndex1();
            this.breakableSurfaceIndex = binaryReader.ReadInt16();
            this.centroid = binaryReader.ReadVector3();
            this.radius = binaryReader.ReadSingle();
            this.collisionSurfaceIndex = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class SectorBlock
    {
        public PathFindingSectorFlags pathFindingSectorFlags;
        public short hintIndex;
        public int firstLinkDoNotSetManually;
        public SectorBlock()
        {
        }
        public SectorBlock(BinaryReader binaryReader)
        {
            this.pathFindingSectorFlags = (PathFindingSectorFlags)binaryReader.ReadInt16();
            this.hintIndex = binaryReader.ReadInt16();
            this.firstLinkDoNotSetManually = binaryReader.ReadInt32();
        }
        [Flags]
        public enum PathFindingSectorFlags : short
        {
            SectorWalkable = 1,
            SectorBreakable = 2,
            SectorMobile = 4,
            SectorBspSource = 8,
            Floor = 16,
            Ceiling = 32,
            WallNorth = 64,
            WallSouth = 128,
            WallEast = 256,
            WallWest = 512,
            Crouchable = 1024,
            Aligned = 2048,
            SectorStep = 4096,
            SectorInterior = 8192,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class SectorLinkBlock
    {
        public short vertex1;
        public short vertex2;
        public LinkFlags linkFlags;
        public short hintIndex;
        public short forwardLink;
        public short reverseLink;
        public short leftSector;
        public short rightSector;
        public SectorLinkBlock()
        {
        }
        public SectorLinkBlock(BinaryReader binaryReader)
        {
            this.vertex1 = binaryReader.ReadInt16();
            this.vertex2 = binaryReader.ReadInt16();
            this.linkFlags = (LinkFlags)binaryReader.ReadInt16();
            this.hintIndex = binaryReader.ReadInt16();
            this.forwardLink = binaryReader.ReadInt16();
            this.reverseLink = binaryReader.ReadInt16();
            this.leftSector = binaryReader.ReadInt16();
            this.rightSector = binaryReader.ReadInt16();
        }
        [Flags]
        public enum LinkFlags : short
        {
            SectorLinkFromCollisionEdge = 1,
            SectorIntersectionLink = 2,
            SectorLinkBsp2dCreationError = 4,
            SectorLinkTopologyError = 8,
            SectorLinkChainError = 16,
            SectorLinkBothSectorsWalkable = 32,
            SectorLinkMagicHangingLink = 64,
            SectorLinkThreshold = 128,
            SectorLinkCrouchable = 256,
            SectorLinkWallBase = 512,
            SectorLinkLedge = 1024,
            SectorLinkLeanable = 2048,
            SectorLinkStartCorner = 4096,
            SectorLinkEndCorner = 8192,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class RefBlock
    {
        public int nodeRefOrSectorRef;
        public RefBlock()
        {
        }
        public RefBlock(BinaryReader binaryReader)
        {
            this.nodeRefOrSectorRef = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
    public partial class SectorBsp2dNodesBlock
    {
        public Vector3 plane;
        public int leftChild;
        public int rightChild;
        public SectorBsp2dNodesBlock()
        {
        }
        public SectorBsp2dNodesBlock(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadVector3();
            this.leftChild = binaryReader.ReadInt32();
            this.rightChild = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class SurfaceFlagsBlock
    {
        public int flags;
        public SurfaceFlagsBlock()
        {
        }
        public SurfaceFlagsBlock(BinaryReader binaryReader)
        {
            this.flags = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class SectorVertexBlock
    {
        public Vector3 point;
        public SectorVertexBlock()
        {
        }
        public SectorVertexBlock(BinaryReader binaryReader)
        {
            this.point = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class EnvironmentObjectBspRefs
    {
        public int bspReference;
        public int firstSector;
        public int lastSector;
        public short nodeIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public EnvironmentObjectBspRefs()
        {
        }
        public EnvironmentObjectBspRefs(BinaryReader binaryReader)
        {
            this.bspReference = binaryReader.ReadInt32();
            this.firstSector = binaryReader.ReadInt32();
            this.lastSector = binaryReader.ReadInt32();
            this.nodeIndex = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class EnvironmentObjectNodes
    {
        public short referenceFrameIndex;
        public byte projectionAxis;
        public ProjectionSign projectionSign;
        public EnvironmentObjectNodes()
        {
        }
        public EnvironmentObjectNodes(BinaryReader binaryReader)
        {
            this.referenceFrameIndex = binaryReader.ReadInt16();
            this.projectionAxis = binaryReader.ReadByte();
            this.projectionSign = (ProjectionSign)binaryReader.ReadByte();
        }
        [Flags]
        public enum ProjectionSign : byte
        {
            ProjectionSign = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 28, Pack = 4)]
    public partial class EnvironmentObjectRefs
    {
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public int firstSector;
        public int lastSector;
        [TagBlockField]
        public EnvironmentObjectBspRefs[] bsps;
        [TagBlockField]
        public EnvironmentObjectNodes[] nodes;
        public EnvironmentObjectRefs()
        {
        }
        public EnvironmentObjectRefs(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.firstSector = binaryReader.ReadInt32();
            this.lastSector = binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(EnvironmentObjectBspRefs));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.bsps = new EnvironmentObjectBspRefs[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.bsps[i] = new EnvironmentObjectBspRefs(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(EnvironmentObjectNodes));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.nodes = new EnvironmentObjectNodes[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.nodes[i] = new EnvironmentObjectNodes(binaryReader);
                    }
                }
            }
        }
        [Flags]
        public enum Flags : short
        {
            Mobile = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
    public partial class PathfindingHintsBlock
    {
        public HintType hintType;
        public short nextHintIndex;
        public short hintData0;
        public short hintData1;
        public short hintData2;
        public short hintData3;
        public short hintData4;
        public short hintData5;
        public short hintData6;
        public short hintData7;
        public PathfindingHintsBlock()
        {
        }
        public PathfindingHintsBlock(BinaryReader binaryReader)
        {
            this.hintType = (HintType)binaryReader.ReadInt16();
            this.nextHintIndex = binaryReader.ReadInt16();
            this.hintData0 = binaryReader.ReadInt16();
            this.hintData1 = binaryReader.ReadInt16();
            this.hintData2 = binaryReader.ReadInt16();
            this.hintData3 = binaryReader.ReadInt16();
            this.hintData4 = binaryReader.ReadInt16();
            this.hintData5 = binaryReader.ReadInt16();
            this.hintData6 = binaryReader.ReadInt16();
            this.hintData7 = binaryReader.ReadInt16();
        }
        public enum HintType : short
        {
            IntersectionLink = 0,
            JumpLink = 1,
            ClimbLink = 2,
            VaultLink = 3,
            MountLink = 4,
            HoistLink = 5,
            WallJumpLink = 6,
            BreakableFloor = 7,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class InstancedGeometryReferenceBlock
    {
        public short pathfindingObjectIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public InstancedGeometryReferenceBlock()
        {
        }
        public InstancedGeometryReferenceBlock(BinaryReader binaryReader)
        {
            this.pathfindingObjectIndex = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class UserHintPointBlock
    {
        public Vector3 point;
        public short referenceFrame;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public UserHintPointBlock()
        {
        }
        public UserHintPointBlock(BinaryReader binaryReader)
        {
            this.point = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 28, Pack = 4)]
    public partial class UserHintRayBlock
    {
        public Vector3 point;
        public short referenceFrame;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public Vector3 vector;
        public UserHintRayBlock()
        {
        }
        public UserHintRayBlock(BinaryReader binaryReader)
        {
            this.point = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.vector = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
    public partial class UserHintLineSegmentBlock
    {
        public Flags flags;
        public Vector3 point0;
        public short referenceFrame;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public Vector3 point1;
        public short referenceFrame0;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        public UserHintLineSegmentBlock()
        {
        }
        public UserHintLineSegmentBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.point0 = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.point1 = binaryReader.ReadVector3();
            this.referenceFrame0 = binaryReader.ReadInt16();
            this.padding0 = binaryReader.ReadBytes(2);
        }
        [Flags]
        public enum Flags : int
        {
            Bidirectional = 1,
            Closed = 2,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
    public partial class UserHintParallelogramBlock
    {
        public Flags flags;
        public Vector3 point0;
        public short referenceFrame;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public Vector3 point1;
        public short referenceFrame0;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        public Vector3 point2;
        public short referenceFrame1;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding1;
        #endregion
        public Vector3 point3;
        public short referenceFrame2;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding2;
        #endregion
        public UserHintParallelogramBlock()
        {
        }
        public UserHintParallelogramBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.point0 = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.point1 = binaryReader.ReadVector3();
            this.referenceFrame0 = binaryReader.ReadInt16();
            this.padding0 = binaryReader.ReadBytes(2);
            this.point2 = binaryReader.ReadVector3();
            this.referenceFrame1 = binaryReader.ReadInt16();
            this.padding1 = binaryReader.ReadBytes(2);
            this.point3 = binaryReader.ReadVector3();
            this.referenceFrame2 = binaryReader.ReadInt16();
            this.padding2 = binaryReader.ReadBytes(2);
        }
        [Flags]
        public enum Flags : int
        {
            Bidirectional = 1,
            Closed = 2,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class UserHintPolygonBlock
    {
        public Flags flags;
        [TagBlockField]
        public UserHintPointBlock[] points;
        public UserHintPolygonBlock()
        {
        }
        public UserHintPolygonBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintPointBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.points = new UserHintPointBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.points[i] = new UserHintPointBlock(binaryReader);
                    }
                }
            }
        }
        [Flags]
        public enum Flags : int
        {
            Bidirectional = 1,
            Closed = 2,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class UserHintJumpBlock
    {
        public Flags flags;
        public ShortBlockIndex1 geometryIndex;
        public ForceJumpHeight forceJumpHeight;
        public ControlFlags controlFlags;
        public UserHintJumpBlock()
        {
        }
        public UserHintJumpBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.geometryIndex = binaryReader.ReadShortBlockIndex1();
            this.forceJumpHeight = (ForceJumpHeight)binaryReader.ReadInt16();
            this.controlFlags = (ControlFlags)binaryReader.ReadInt16();
        }
        [Flags]
        public enum Flags : short
        {
            Bidirectional = 1,
            Closed = 2,
        }
        public enum ForceJumpHeight : short
        {
            NONE = 0,
            Down = 1,
            Step = 2,
            Crouch = 3,
            Stand = 4,
            Storey = 5,
            Tower = 6,
            Infinite = 7,
        }
        [Flags]
        public enum ControlFlags : short
        {
            MagicLift = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class UserHintClimbBlock
    {
        public Flags flags;
        public ShortBlockIndex1 geometryIndex;
        public UserHintClimbBlock()
        {
        }
        public UserHintClimbBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.geometryIndex = binaryReader.ReadShortBlockIndex1();
        }
        [Flags]
        public enum Flags : short
        {
            Bidirectional = 1,
            Closed = 2,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class UserHintWellPointBlock
    {
        public Type type;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public Vector3 point;
        public short referenceFrame;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        public int sectorIndex;
        public Vector2 normal;
        public UserHintWellPointBlock()
        {
        }
        public UserHintWellPointBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.point = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.padding0 = binaryReader.ReadBytes(2);
            this.sectorIndex = binaryReader.ReadInt32();
            this.normal = binaryReader.ReadVector2();
        }
        public enum Type : short
        {
            Jump = 0,
            Climb = 1,
            Hoist = 2,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class UserHintWellBlock
    {
        public Flags flags;
        [TagBlockField]
        public UserHintWellPointBlock[] points;
        public UserHintWellBlock()
        {
        }
        public UserHintWellBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintWellPointBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.points = new UserHintWellPointBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.points[i] = new UserHintWellPointBlock(binaryReader);
                    }
                }
            }
        }
        [Flags]
        public enum Flags : int
        {
            Bidirectional = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class UserHintFlightPointBlock
    {
        public Vector3 point;
        public UserHintFlightPointBlock()
        {
        }
        public UserHintFlightPointBlock(BinaryReader binaryReader)
        {
            this.point = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class UserHintFlightBlock
    {
        [TagBlockField]
        public UserHintFlightPointBlock[] points;
        public UserHintFlightBlock()
        {
        }
        public UserHintFlightBlock(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintFlightPointBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.points = new UserHintFlightPointBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.points[i] = new UserHintFlightPointBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 72, Pack = 4)]
    public partial class UserHintBlock
    {
        [TagBlockField]
        public UserHintPointBlock[] pointGeometry;
        [TagBlockField]
        public UserHintRayBlock[] rayGeometry;
        [TagBlockField]
        public UserHintLineSegmentBlock[] lineSegmentGeometry;
        [TagBlockField]
        public UserHintParallelogramBlock[] parallelogramGeometry;
        [TagBlockField]
        public UserHintPolygonBlock[] polygonGeometry;
        [TagBlockField]
        public UserHintJumpBlock[] jumpHints;
        [TagBlockField]
        public UserHintClimbBlock[] climbHints;
        [TagBlockField]
        public UserHintWellBlock[] wellHints;
        [TagBlockField]
        public UserHintFlightBlock[] flightHints;
        public UserHintBlock()
        {
        }
        public UserHintBlock(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintPointBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.pointGeometry = new UserHintPointBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.pointGeometry[i] = new UserHintPointBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintRayBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.rayGeometry = new UserHintRayBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.rayGeometry[i] = new UserHintRayBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintLineSegmentBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.lineSegmentGeometry = new UserHintLineSegmentBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.lineSegmentGeometry[i] = new UserHintLineSegmentBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintParallelogramBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.parallelogramGeometry = new UserHintParallelogramBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.parallelogramGeometry[i] = new UserHintParallelogramBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintPolygonBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.polygonGeometry = new UserHintPolygonBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.polygonGeometry[i] = new UserHintPolygonBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintJumpBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.jumpHints = new UserHintJumpBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.jumpHints[i] = new UserHintJumpBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintClimbBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.climbHints = new UserHintClimbBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.climbHints[i] = new UserHintClimbBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintWellBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.wellHints = new UserHintWellBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.wellHints[i] = new UserHintWellBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintFlightBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.flightHints = new UserHintFlightBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.flightHints[i] = new UserHintFlightBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 116, Pack = 4)]
    public partial class PathfindingDataBlock
    {
        [TagBlockField]
        public SectorBlock[] sectors;
        [TagBlockField]
        public SectorLinkBlock[] links;
        [TagBlockField]
        public RefBlock[] refs;
        [TagBlockField]
        public SectorBsp2dNodesBlock[] bsp2dNodes;
        [TagBlockField]
        public SurfaceFlagsBlock[] surfaceFlags;
        [TagBlockField]
        public SectorVertexBlock[] vertices;
        [TagBlockField]
        public EnvironmentObjectRefs[] objectRefs;
        [TagBlockField]
        public PathfindingHintsBlock[] pathfindingHints;
        [TagBlockField]
        public InstancedGeometryReferenceBlock[] instancedGeometryRefs;
        public int structureChecksum;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public UserHintBlock[] userPlacedHints;
        public PathfindingDataBlock()
        {
        }
        public PathfindingDataBlock(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(SectorBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.sectors = new SectorBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.sectors[i] = new SectorBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(SectorLinkBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.links = new SectorLinkBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.links[i] = new SectorLinkBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(RefBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.refs = new RefBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.refs[i] = new RefBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(SectorBsp2dNodesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.bsp2dNodes = new SectorBsp2dNodesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.bsp2dNodes[i] = new SectorBsp2dNodesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(SurfaceFlagsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.surfaceFlags = new SurfaceFlagsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.surfaceFlags[i] = new SurfaceFlagsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(SectorVertexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.vertices = new SectorVertexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.vertices[i] = new SectorVertexBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(EnvironmentObjectRefs));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.objectRefs = new EnvironmentObjectRefs[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.objectRefs[i] = new EnvironmentObjectRefs(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(PathfindingHintsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.pathfindingHints = new PathfindingHintsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.pathfindingHints[i] = new PathfindingHintsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(InstancedGeometryReferenceBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.instancedGeometryRefs = new InstancedGeometryReferenceBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.instancedGeometryRefs[i] = new InstancedGeometryReferenceBlock(binaryReader);
                    }
                }
            }
            this.structureChecksum = binaryReader.ReadInt32();
            this.padding = binaryReader.ReadBytes(32);
            {
                var elementSize = Marshal.SizeOf(typeof(UserHintBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.userPlacedHints = new UserHintBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.userPlacedHints[i] = new UserHintBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 4)]
    public partial class StructureBspPathfindingEdgesBlock
    {
        public byte midpoint;
        public StructureBspPathfindingEdgesBlock()
        {
        }
        public StructureBspPathfindingEdgesBlock(BinaryReader binaryReader)
        {
            this.midpoint = binaryReader.ReadByte();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 100, Pack = 4)]
    public partial class StructureBspBackgroundSoundPaletteBlock
    {
        public String32 name;
        [TagReference("lsnd")]
        public TagReference backgroundSound;
        [TagReference("lsnd")]
        public TagReference insideClusterSoundPlayOnlyWhenPlayerIsInsideCluster;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        private byte[] padding;
        #endregion
        public float cutoffDistance;
        public ScaleFlags scaleFlags;
        public float interiorScale;
        public float portalScale;
        public float exteriorScale;
        public float interpolationSpeed1Sec;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] padding0;
        #endregion
        public StructureBspBackgroundSoundPaletteBlock()
        {
        }
        public StructureBspBackgroundSoundPaletteBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.backgroundSound = binaryReader.ReadTagReference();
            this.insideClusterSoundPlayOnlyWhenPlayerIsInsideCluster = binaryReader.ReadTagReference();
            this.padding = binaryReader.ReadBytes(20);
            this.cutoffDistance = binaryReader.ReadSingle();
            this.scaleFlags = (ScaleFlags)binaryReader.ReadInt32();
            this.interiorScale = binaryReader.ReadSingle();
            this.portalScale = binaryReader.ReadSingle();
            this.exteriorScale = binaryReader.ReadSingle();
            this.interpolationSpeed1Sec = binaryReader.ReadSingle();
            this.padding0 = binaryReader.ReadBytes(8);
        }
        [Flags]
        public enum ScaleFlags : int
        {
            OverrideDefaultScale = 1,
            UseAdjacentClusterAsPortalScale = 2,
            UseAdjacentClusterAsExteriorScale = 4,
            ScaleWithWeatherIntensity = 8,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 72, Pack = 4)]
    public partial class StructureBspSoundEnvironmentPaletteBlock
    {
        public String32 name;
        [TagReference("snde")]
        public TagReference soundEnvironment;
        public float cutoffDistance;
        public float interpolationSpeed1Sec;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        private byte[] padding;
        #endregion
        public StructureBspSoundEnvironmentPaletteBlock()
        {
        }
        public StructureBspSoundEnvironmentPaletteBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.soundEnvironment = binaryReader.ReadTagReference();
            this.cutoffDistance = binaryReader.ReadSingle();
            this.interpolationSpeed1Sec = binaryReader.ReadSingle();
            this.padding = binaryReader.ReadBytes(24);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 60, Pack = 4)]
    public partial class StructureBspMarkerBlock
    {
        public String32 name;
        public Quaternion rotation;
        public Vector3 position;
        public StructureBspMarkerBlock()
        {
        }
        public StructureBspMarkerBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.rotation = binaryReader.ReadQuaternion();
            this.position = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class StructureBspRuntimeDecalBlock
    {
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private byte[] skip;
        #endregion
        public StructureBspRuntimeDecalBlock()
        {
        }
        public StructureBspRuntimeDecalBlock(BinaryReader binaryReader)
        {
            this.skip = binaryReader.ReadBytes(16);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
    public partial class StructureBspEnvironmentObjectPaletteBlock
    {
        [TagReference("scen")]
        public TagReference definition;
        [TagReference("mode")]
        public TagReference model;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public StructureBspEnvironmentObjectPaletteBlock()
        {
        }
        public StructureBspEnvironmentObjectPaletteBlock(BinaryReader binaryReader)
        {
            this.definition = binaryReader.ReadTagReference();
            this.model = binaryReader.ReadTagReference();
            this.padding = binaryReader.ReadBytes(4);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 104, Pack = 4)]
    public partial class StructureBspEnvironmentObjectBlock
    {
        public String32 name;
        public Quaternion rotation;
        public Vector3 translation;
        public ShortBlockIndex1 paletteIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public int uniqueID;
        public TagClass exportedObjectType;
        public String32 scenarioObjectName;
        public StructureBspEnvironmentObjectBlock()
        {
        }
        public StructureBspEnvironmentObjectBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.rotation = binaryReader.ReadQuaternion();
            this.translation = binaryReader.ReadVector3();
            this.paletteIndex = binaryReader.ReadShortBlockIndex1();
            this.padding = binaryReader.ReadBytes(2);
            this.uniqueID = binaryReader.ReadInt32();
            this.exportedObjectType = binaryReader.ReadTagClass();
            this.scenarioObjectName = binaryReader.ReadString32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class StructureBspLightmapDataBlock
    {
        [TagReference("bitm")]
        public TagReference bitmapGroup;
        public StructureBspLightmapDataBlock()
        {
        }
        public StructureBspLightmapDataBlock(BinaryReader binaryReader)
        {
            this.bitmapGroup = binaryReader.ReadTagReference();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class MapLeafFaceVertexBlock
    {
        public Vector3 vertex;
        public MapLeafFaceVertexBlock()
        {
        }
        public MapLeafFaceVertexBlock(BinaryReader binaryReader)
        {
            this.vertex = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class MapLeafFaceBlock
    {
        public int nodeIndex;
        [TagBlockField]
        public MapLeafFaceVertexBlock[] vertices;
        public MapLeafFaceBlock()
        {
        }
        public MapLeafFaceBlock(BinaryReader binaryReader)
        {
            this.nodeIndex = binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(MapLeafFaceVertexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.vertices = new MapLeafFaceVertexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.vertices[i] = new MapLeafFaceVertexBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class MapLeafConnectionIndexBlock
    {
        public int connectionIndex;
        public MapLeafConnectionIndexBlock()
        {
        }
        public MapLeafConnectionIndexBlock(BinaryReader binaryReader)
        {
            this.connectionIndex = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class GlobalMapLeafBlock
    {
        [TagBlockField]
        public MapLeafFaceBlock[] faces;
        [TagBlockField]
        public MapLeafConnectionIndexBlock[] connectionIndices;
        public GlobalMapLeafBlock()
        {
        }
        public GlobalMapLeafBlock(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(MapLeafFaceBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.faces = new MapLeafFaceBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.faces[i] = new MapLeafFaceBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(MapLeafConnectionIndexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.connectionIndices = new MapLeafConnectionIndexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.connectionIndices[i] = new MapLeafConnectionIndexBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class LeafConnectionVertexBlock
    {
        public Vector3 vertex;
        public LeafConnectionVertexBlock()
        {
        }
        public LeafConnectionVertexBlock(BinaryReader binaryReader)
        {
            this.vertex = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
    public partial class GlobalLeafConnectionBlock
    {
        public int planeIndex;
        public int backLeafIndex;
        public int frontLeafIndex;
        [TagBlockField]
        public LeafConnectionVertexBlock[] vertices;
        public float area;
        public GlobalLeafConnectionBlock()
        {
        }
        public GlobalLeafConnectionBlock(BinaryReader binaryReader)
        {
            this.planeIndex = binaryReader.ReadInt32();
            this.backLeafIndex = binaryReader.ReadInt32();
            this.frontLeafIndex = binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(LeafConnectionVertexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.vertices = new LeafConnectionVertexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.vertices[i] = new LeafConnectionVertexBlock(binaryReader);
                    }
                }
            }
            this.area = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 4)]
    public partial class ErrorReportVerticesBlock
    {
        public Vector3 position;
        public struct NodeIndices
        {
            public byte nodeIndex;
            public NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndices[] nodeIndices;
        public struct NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeWeights[] nodeWeights;
        public Vector4 color;
        public float screenSize;
        public ErrorReportVerticesBlock()
        {
        }
        public ErrorReportVerticesBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndices[i] = new NodeIndices(binaryReader);
            }
            this.nodeWeights = new NodeWeights[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
            this.screenSize = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
    public partial class ErrorReportVectorsBlock
    {
        public Vector3 position;
        public struct NodeIndices
        {
            public byte nodeIndex;
            public NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndices[] nodeIndices;
        public struct NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeWeights[] nodeWeights;
        public Vector4 color;
        public Vector3 normal;
        public float screenLength;
        public ErrorReportVectorsBlock()
        {
        }
        public ErrorReportVectorsBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndices[i] = new NodeIndices(binaryReader);
            }
            this.nodeWeights = new NodeWeights[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
            this.normal = binaryReader.ReadVector3();
            this.screenLength = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 58, Pack = 4)]
    public partial class ErrorReportLinesBlock
    {
        public struct Points
        {
            public Vector3 position;
            public struct NodeIndices
            {
                public byte nodeIndex;
                public NodeIndices(BinaryReader binaryReader)
                {
                    this.nodeIndex = binaryReader.ReadByte();
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeIndices[] nodeIndices;
            public struct NodeWeights
            {
                public float nodeWeight;
                public NodeWeights(BinaryReader binaryReader)
                {
                    this.nodeWeight = binaryReader.ReadSingle();
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeWeights[] nodeWeights;
            public Points(BinaryReader binaryReader)
            {
                this.position = binaryReader.ReadVector3();
                this.nodeIndices = new NodeIndices[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeIndices[i] = new NodeIndices(binaryReader);
                }
                this.nodeWeights = new NodeWeights[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeWeights[i] = new NodeWeights(binaryReader);
                }
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public Points[] points;
        public Vector4 color;
        public ErrorReportLinesBlock()
        {
        }
        public ErrorReportLinesBlock(BinaryReader binaryReader)
        {
            this.points = new Points[2];
            for (int i = 0; i < 2; ++i)
            {
                this.points[i] = new Points(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 71, Pack = 4)]
    public partial class ErrorReportTrianglesBlock
    {
        public struct Points
        {
            public Vector3 position;
            public struct NodeIndices
            {
                public byte nodeIndex;
                public NodeIndices(BinaryReader binaryReader)
                {
                    this.nodeIndex = binaryReader.ReadByte();
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeIndices[] nodeIndices;
            public struct NodeWeights
            {
                public float nodeWeight;
                public NodeWeights(BinaryReader binaryReader)
                {
                    this.nodeWeight = binaryReader.ReadSingle();
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeWeights[] nodeWeights;
            public Points(BinaryReader binaryReader)
            {
                this.position = binaryReader.ReadVector3();
                this.nodeIndices = new NodeIndices[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeIndices[i] = new NodeIndices(binaryReader);
                }
                this.nodeWeights = new NodeWeights[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeWeights[i] = new NodeWeights(binaryReader);
                }
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Points[] points;
        public Vector4 color;
        public ErrorReportTrianglesBlock()
        {
        }
        public ErrorReportTrianglesBlock(BinaryReader binaryReader)
        {
            this.points = new Points[3];
            for (int i = 0; i < 3; ++i)
            {
                this.points[i] = new Points(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 84, Pack = 4)]
    public partial class ErrorReportQuadsBlock
    {
        public struct Points
        {
            public Vector3 position;
            public struct NodeIndices
            {
                public byte nodeIndex;
                public NodeIndices(BinaryReader binaryReader)
                {
                    this.nodeIndex = binaryReader.ReadByte();
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeIndices[] nodeIndices;
            public struct NodeWeights
            {
                public float nodeWeight;
                public NodeWeights(BinaryReader binaryReader)
                {
                    this.nodeWeight = binaryReader.ReadSingle();
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeWeights[] nodeWeights;
            public Points(BinaryReader binaryReader)
            {
                this.position = binaryReader.ReadVector3();
                this.nodeIndices = new NodeIndices[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeIndices[i] = new NodeIndices(binaryReader);
                }
                this.nodeWeights = new NodeWeights[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeWeights[i] = new NodeWeights(binaryReader);
                }
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Points[] points;
        public Vector4 color;
        public ErrorReportQuadsBlock()
        {
        }
        public ErrorReportQuadsBlock(BinaryReader binaryReader)
        {
            this.points = new Points[4];
            for (int i = 0; i < 4; ++i)
            {
                this.points[i] = new Points(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 4)]
    public partial class ErrorReportCommentsBlock
    {
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingtext;
        #endregion
        public Vector3 position;
        public struct NodeIndices
        {
            public byte nodeIndex;
            public NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndices[] nodeIndices;
        public struct NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeWeights[] nodeWeights;
        public Vector4 color;
        public ErrorReportCommentsBlock()
        {
        }
        public ErrorReportCommentsBlock(BinaryReader binaryReader)
        {
            this.paddingtext = binaryReader.ReadBytes(8);
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndices[i] = new NodeIndices(binaryReader);
            }
            this.nodeWeights = new NodeWeights[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 608, Pack = 4)]
    public partial class ErrorReportsBlock
    {
        public Type type;
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingtext;
        #endregion
        public String32 sourceFilename;
        public int sourceLineNumber;
        [TagBlockField]
        public ErrorReportVerticesBlock[] vertices;
        [TagBlockField]
        public ErrorReportVectorsBlock[] vectors;
        [TagBlockField]
        public ErrorReportLinesBlock[] lines;
        [TagBlockField]
        public ErrorReportTrianglesBlock[] triangles;
        [TagBlockField]
        public ErrorReportQuadsBlock[] quads;
        [TagBlockField]
        public ErrorReportCommentsBlock[] comments;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 380)]
        private byte[] padding;
        #endregion
        public int reportKey;
        public int nodeIndex;
        public Range boundsX;
        public Range boundsY;
        public Range boundsZ;
        public Vector4 color;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
        private byte[] padding0;
        #endregion
        public ErrorReportsBlock()
        {
        }
        public ErrorReportsBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.paddingtext = binaryReader.ReadBytes(8);
            this.sourceFilename = binaryReader.ReadString32();
            this.sourceLineNumber = binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(ErrorReportVerticesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.vertices = new ErrorReportVerticesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.vertices[i] = new ErrorReportVerticesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(ErrorReportVectorsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.vectors = new ErrorReportVectorsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.vectors[i] = new ErrorReportVectorsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(ErrorReportLinesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.lines = new ErrorReportLinesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.lines[i] = new ErrorReportLinesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(ErrorReportTrianglesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.triangles = new ErrorReportTrianglesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.triangles[i] = new ErrorReportTrianglesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(ErrorReportQuadsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.quads = new ErrorReportQuadsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.quads[i] = new ErrorReportQuadsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(ErrorReportCommentsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.comments = new ErrorReportCommentsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.comments[i] = new ErrorReportCommentsBlock(binaryReader);
                    }
                }
            }
            this.padding = binaryReader.ReadBytes(380);
            this.reportKey = binaryReader.ReadInt32();
            this.nodeIndex = binaryReader.ReadInt32();
            this.boundsX = binaryReader.ReadRange();
            this.boundsY = binaryReader.ReadRange();
            this.boundsZ = binaryReader.ReadRange();
            this.color = binaryReader.ReadVector4();
            this.padding0 = binaryReader.ReadBytes(84);
        }
        public enum Type : short
        {
            Silent = 0,
            Comment = 1,
            Warning = 2,
            Error = 3,
        }
        [Flags]
        public enum Flags : short
        {
            Rendered = 1,
            TangentSpace = 2,
            Noncritical = 4,
            LightmapLight = 8,
            ReportKeyIsValid = 16,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 676, Pack = 4)]
    public partial class GlobalErrorReportCategoriesBlock
    {
        public String256 name;
        public ReportType reportType;
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 404)]
        private byte[] padding1;
        #endregion
        [TagBlockField]
        public ErrorReportsBlock[] reports;
        public GlobalErrorReportCategoriesBlock()
        {
        }
        public GlobalErrorReportCategoriesBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString256();
            this.reportType = (ReportType)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(2);
            this.padding1 = binaryReader.ReadBytes(404);
            {
                var elementSize = Marshal.SizeOf(typeof(ErrorReportsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.reports = new ErrorReportsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.reports[i] = new ErrorReportsBlock(binaryReader);
                    }
                }
            }
        }
        public enum ReportType : short
        {
            Silent = 0,
            Comment = 1,
            Warning = 2,
            Error = 3,
        }
        [Flags]
        public enum Flags : short
        {
            Rendered = 1,
            TangentSpace = 2,
            Noncritical = 4,
            LightmapLight = 8,
            ReportKeyIsValid = 16,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
    public partial class VisibilityStruct
    {
        public short projectionCount;
        public short clusterCount;
        public short volumeCount;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingprojections;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingvisibilityClusters;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingclusterRemapTable;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingvisibilityVolumes;
        #endregion
        public VisibilityStruct()
        {
        }
        public VisibilityStruct(BinaryReader binaryReader)
        {
            this.projectionCount = binaryReader.ReadInt16();
            this.clusterCount = binaryReader.ReadInt16();
            this.volumeCount = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.paddingprojections = binaryReader.ReadBytes(8);
            this.paddingvisibilityClusters = binaryReader.ReadBytes(8);
            this.paddingclusterRemapTable = binaryReader.ReadBytes(8);
            this.paddingvisibilityVolumes = binaryReader.ReadBytes(8);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 4)]
    public partial class StructureBspPrecomputedLightingBlock
    {
        public int index;
        public LightType lightType;
        public byte attachmentIndex;
        public byte objectType;
        [TagStructField]
        public VisibilityStruct visibility;
        public StructureBspPrecomputedLightingBlock()
        {
        }
        public StructureBspPrecomputedLightingBlock(BinaryReader binaryReader)
        {
            this.index = binaryReader.ReadInt32();
            this.lightType = (LightType)binaryReader.ReadInt16();
            this.attachmentIndex = binaryReader.ReadByte();
            this.objectType = binaryReader.ReadByte();
            this.visibility = new VisibilityStruct(binaryReader);
        }
        public enum LightType : short
        {
            FreeStanding = 0,
            AttachedToEditorObject = 1,
            AttachedToStructureObject = 2,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 92, Pack = 4)]
    public partial class StructureInstancedGeometryRenderInfoStruct
    {
        [TagStructField]
        public GlobalGeometrySectionInfoStruct sectionInfo;
        [TagStructField]
        public Moonfish.Tags.GlobalGeometryBlockInfoStruct geometryBlockInfo;
        [TagBlockField]
        public StructureBspClusterDataBlockNew[] renderData;
        [TagBlockField]
        public GlobalGeometrySectionStripIndexBlock[] indexReorderTable;
        public StructureInstancedGeometryRenderInfoStruct()
        {
        }
        public StructureInstancedGeometryRenderInfoStruct(BinaryReader binaryReader)
        {
            this.sectionInfo = new GlobalGeometrySectionInfoStruct(binaryReader);
            this.geometryBlockInfo = new Moonfish.Tags.GlobalGeometryBlockInfoStruct(binaryReader);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspClusterDataBlockNew));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.renderData = new StructureBspClusterDataBlockNew[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.renderData[i] = new StructureBspClusterDataBlockNew(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.indexReorderTable = new GlobalGeometrySectionStripIndexBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.indexReorderTable[i] = new GlobalGeometrySectionStripIndexBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
    public partial class GlobalCollisionBspStruct
    {
        [TagBlockField]
        public Bsp3dNodesBlock[] bSP3DNodes;
        [TagBlockField]
        public PlanesBlock[] planes;
        [TagBlockField]
        public LeavesBlock[] leaves;
        [TagBlockField]
        public Bsp2dReferencesBlock[] bSP2DReferences;
        [TagBlockField]
        public Bsp2dNodesBlock[] bSP2DNodes;
        [TagBlockField]
        public SurfacesBlock[] surfaces;
        [TagBlockField]
        public EdgesBlock[] edges;
        [TagBlockField]
        public VerticesBlock[] vertices;
        public GlobalCollisionBspStruct()
        {
        }
        public GlobalCollisionBspStruct(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(Bsp3dNodesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.bSP3DNodes = new Bsp3dNodesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.bSP3DNodes[i] = new Bsp3dNodesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(PlanesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.planes = new PlanesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.planes[i] = new PlanesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(LeavesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.leaves = new LeavesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.leaves[i] = new LeavesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(Bsp2dReferencesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.bSP2DReferences = new Bsp2dReferencesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.bSP2DReferences[i] = new Bsp2dReferencesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(Bsp2dNodesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.bSP2DNodes = new Bsp2dNodesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.bSP2DNodes[i] = new Bsp2dNodesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(SurfacesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.surfaces = new SurfacesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.surfaces[i] = new SurfacesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(EdgesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.edges = new EdgesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.edges[i] = new EdgesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(VerticesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.vertices = new VerticesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.vertices[i] = new VerticesBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 112, Pack = 16)]
    public partial class CollisionBspPhysicsBlock
    {
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] skip;
        #endregion
        public short size;
        public short count;
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] skip0;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding1;
        #endregion
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        private byte[] skip2;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private byte[] padding3;
        #endregion
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] skip4;
        #endregion
        public short size0;
        public short count0;
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] skip5;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding6;
        #endregion
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] skip7;
        #endregion
        public short size1;
        public short count1;
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] skip8;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] padding9;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingmoppCodeData;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] paddingpadding;
        #endregion
        public CollisionBspPhysicsBlock()
        {
        }
        public CollisionBspPhysicsBlock(BinaryReader binaryReader)
        {
            this.skip = binaryReader.ReadBytes(4);
            this.size = binaryReader.ReadInt16();
            this.count = binaryReader.ReadInt16();
            this.skip0 = binaryReader.ReadBytes(4);
            this.padding1 = binaryReader.ReadBytes(4);
            this.skip2 = binaryReader.ReadBytes(32);
            this.padding3 = binaryReader.ReadBytes(16);
            this.skip4 = binaryReader.ReadBytes(4);
            this.size0 = binaryReader.ReadInt16();
            this.count0 = binaryReader.ReadInt16();
            this.skip5 = binaryReader.ReadBytes(4);
            this.padding6 = binaryReader.ReadBytes(4);
            this.skip7 = binaryReader.ReadBytes(4);
            this.size1 = binaryReader.ReadInt16();
            this.count1 = binaryReader.ReadInt16();
            this.skip8 = binaryReader.ReadBytes(4);
            this.padding9 = binaryReader.ReadBytes(8);
            this.paddingmoppCodeData = binaryReader.ReadBytes(8);
            this.paddingpadding = binaryReader.ReadBytes(4);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 200, Pack = 4)]
    public partial class StructureBspInstancedGeometryDefinitionBlock
    {
        [TagStructField]
        public StructureInstancedGeometryRenderInfoStruct renderInfo;
        public int checksum;
        public Vector3 boundingSphereCenter;
        public float boundingSphereRadius;
        [TagStructField]
        public GlobalCollisionBspStruct collisionInfo;
        [TagBlockField]
        public CollisionBspPhysicsBlock[] bspPhysics;
        [TagBlockField]
        public StructureBspLeafBlock[] renderLeaves;
        [TagBlockField]
        public StructureBspSurfaceReferenceBlock[] surfaceReferences;
        public StructureBspInstancedGeometryDefinitionBlock()
        {
        }
        public StructureBspInstancedGeometryDefinitionBlock(BinaryReader binaryReader)
        {
            this.renderInfo = new StructureInstancedGeometryRenderInfoStruct(binaryReader);
            this.checksum = binaryReader.ReadInt32();
            this.boundingSphereCenter = binaryReader.ReadVector3();
            this.boundingSphereRadius = binaryReader.ReadSingle();
            this.collisionInfo = new GlobalCollisionBspStruct(binaryReader);
            {
                var elementSize = Marshal.SizeOf(typeof(CollisionBspPhysicsBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.bspPhysics = new CollisionBspPhysicsBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.bspPhysics[i] = new CollisionBspPhysicsBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspLeafBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.renderLeaves = new StructureBspLeafBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.renderLeaves[i] = new StructureBspLeafBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspSurfaceReferenceBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.surfaceReferences = new StructureBspSurfaceReferenceBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.surfaceReferences[i] = new StructureBspSurfaceReferenceBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 88, Pack = 4)]
    public partial class StructureBspInstancedGeometryInstancesBlock
    {
        public float scale;
        public Vector3 forward;
        public Vector3 left;
        public Vector3 up;
        public Vector3 position;
        public ShortBlockIndex1 instanceDefinition;
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] skip0;
        #endregion
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] skip1;
        #endregion
        public int checksum;
        public StringID name;
        public PathfindingPolicy pathfindingPolicy;
        public LightmappingPolicy lightmappingPolicy;
        public StructureBspInstancedGeometryInstancesBlock()
        {
        }
        public StructureBspInstancedGeometryInstancesBlock(BinaryReader binaryReader)
        {
            this.scale = binaryReader.ReadSingle();
            this.forward = binaryReader.ReadVector3();
            this.left = binaryReader.ReadVector3();
            this.up = binaryReader.ReadVector3();
            this.position = binaryReader.ReadVector3();
            this.instanceDefinition = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(4);
            this.skip0 = binaryReader.ReadBytes(12);
            this.skip1 = binaryReader.ReadBytes(4);
            this.checksum = binaryReader.ReadInt32();
            this.name = binaryReader.ReadStringID();
            this.pathfindingPolicy = (PathfindingPolicy)binaryReader.ReadInt16();
            this.lightmappingPolicy = (LightmappingPolicy)binaryReader.ReadInt16();
        }
        [Flags]
        public enum Flags : short
        {
            NotInLightprobes = 1,
        }
        public enum PathfindingPolicy : short
        {
            Cutout = 0,
            Static = 1,
            None = 2,
        }
        public enum LightmappingPolicy : short
        {
            PerPixel = 0,
            PerVertex = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class StructureSoundClusterPortalDesignators
    {
        public short portalDesignator;
        public StructureSoundClusterPortalDesignators()
        {
        }
        public StructureSoundClusterPortalDesignators(BinaryReader binaryReader)
        {
            this.portalDesignator = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class StructureSoundClusterInteriorClusterIndices
    {
        public short interiorClusterIndex;
        public StructureSoundClusterInteriorClusterIndices()
        {
        }
        public StructureSoundClusterInteriorClusterIndices(BinaryReader binaryReader)
        {
            this.interiorClusterIndex = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
    public partial class StructureBspSoundClusterBlock
    {
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        [TagBlockField]
        public StructureSoundClusterPortalDesignators[] enclosingPortalDesignators;
        [TagBlockField]
        public StructureSoundClusterInteriorClusterIndices[] interiorClusterIndices;
        public StructureBspSoundClusterBlock()
        {
        }
        public StructureBspSoundClusterBlock(BinaryReader binaryReader)
        {
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(2);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureSoundClusterPortalDesignators));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.enclosingPortalDesignators = new StructureSoundClusterPortalDesignators[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.enclosingPortalDesignators[i] = new StructureSoundClusterPortalDesignators(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureSoundClusterInteriorClusterIndices));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.interiorClusterIndices = new StructureSoundClusterInteriorClusterIndices[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.interiorClusterIndices[i] = new StructureSoundClusterInteriorClusterIndices(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
    public partial class TransparentPlanesBlock
    {
        public short sectionIndex;
        public short partIndex;
        public Vector4 plane;
        public TransparentPlanesBlock()
        {
        }
        public TransparentPlanesBlock(BinaryReader binaryReader)
        {
            this.sectionIndex = binaryReader.ReadInt16();
            this.partIndex = binaryReader.ReadInt16();
            this.plane = binaryReader.ReadVector4();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class StructureBspDebugInfoRenderLineBlock
    {
        public Type type;
        public short code;
        public short padThai;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public Vector3 point0;
        public Vector3 point1;
        public StructureBspDebugInfoRenderLineBlock()
        {
        }
        public StructureBspDebugInfoRenderLineBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.code = binaryReader.ReadInt16();
            this.padThai = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.point0 = binaryReader.ReadVector3();
            this.point1 = binaryReader.ReadVector3();
        }
        public enum Type : short
        {
            FogPlaneBoundaryEdge = 0,
            FogPlaneInternalEdge = 1,
            FogZoneFloodfill = 2,
            FogZoneClusterCentroid = 3,
            FogZoneClusterGeometry = 4,
            FogZonePortalCentroid = 5,
            FogZonePortalGeometry = 6,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class StructureBspDebugInfoIndicesBlock
    {
        public int index;
        public StructureBspDebugInfoIndicesBlock()
        {
        }
        public StructureBspDebugInfoIndicesBlock(BinaryReader binaryReader)
        {
            this.index = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 72, Pack = 4)]
    public partial class StructureBspClusterDebugInfoBlock
    {
        public Errors errors;
        public Warnings warnings;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public StructureBspDebugInfoRenderLineBlock[] lines;
        [TagBlockField]
        public StructureBspDebugInfoIndicesBlock[] fogPlaneIndices;
        [TagBlockField]
        public StructureBspDebugInfoIndicesBlock[] visibleFogPlaneIndices;
        [TagBlockField]
        public StructureBspDebugInfoIndicesBlock[] visFogOmissionClusterIndices;
        [TagBlockField]
        public StructureBspDebugInfoIndicesBlock[] containingFogZoneIndices;
        public StructureBspClusterDebugInfoBlock()
        {
        }
        public StructureBspClusterDebugInfoBlock(BinaryReader binaryReader)
        {
            this.errors = (Errors)binaryReader.ReadInt16();
            this.warnings = (Warnings)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(28);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoRenderLineBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.lines = new StructureBspDebugInfoRenderLineBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.lines[i] = new StructureBspDebugInfoRenderLineBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.fogPlaneIndices = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.fogPlaneIndices[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.visibleFogPlaneIndices = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.visibleFogPlaneIndices[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.visFogOmissionClusterIndices = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.visFogOmissionClusterIndices[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.containingFogZoneIndices = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.containingFogZoneIndices[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                    }
                }
            }
        }
        [Flags]
        public enum Errors : short
        {
            MultipleFogPlanes = 1,
            FogZoneCollision = 2,
            FogZoneImmersion = 4,
        }
        [Flags]
        public enum Warnings : short
        {
            MultipleVisibleFogPlanes = 1,
            VisibleFogClusterOmission = 2,
            FogPlaneMissedRenderBSP = 4,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 4)]
    public partial class StructureBspFogPlaneDebugInfoBlock
    {
        public int fogZoneIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        private byte[] padding;
        #endregion
        public int connectedPlaneDesignator;
        [TagBlockField]
        public StructureBspDebugInfoRenderLineBlock[] lines;
        [TagBlockField]
        public StructureBspDebugInfoIndicesBlock[] intersectedClusterIndices;
        [TagBlockField]
        public StructureBspDebugInfoIndicesBlock[] infExtentClusterIndices;
        public StructureBspFogPlaneDebugInfoBlock()
        {
        }
        public StructureBspFogPlaneDebugInfoBlock(BinaryReader binaryReader)
        {
            this.fogZoneIndex = binaryReader.ReadInt32();
            this.padding = binaryReader.ReadBytes(24);
            this.connectedPlaneDesignator = binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoRenderLineBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.lines = new StructureBspDebugInfoRenderLineBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.lines[i] = new StructureBspDebugInfoRenderLineBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.intersectedClusterIndices = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.intersectedClusterIndices[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.infExtentClusterIndices = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.infExtentClusterIndices[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
    public partial class StructureBspFogZoneDebugInfoBlock
    {
        public int mediaIndexScenarioFogPlane;
        public int baseFogPlaneIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public StructureBspDebugInfoRenderLineBlock[] lines;
        [TagBlockField]
        public StructureBspDebugInfoIndicesBlock[] immersedClusterIndices;
        [TagBlockField]
        public StructureBspDebugInfoIndicesBlock[] boundingFogPlaneIndices;
        [TagBlockField]
        public StructureBspDebugInfoIndicesBlock[] collisionFogPlaneIndices;
        public StructureBspFogZoneDebugInfoBlock()
        {
        }
        public StructureBspFogZoneDebugInfoBlock(BinaryReader binaryReader)
        {
            this.mediaIndexScenarioFogPlane = binaryReader.ReadInt32();
            this.baseFogPlaneIndex = binaryReader.ReadInt32();
            this.padding = binaryReader.ReadBytes(24);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoRenderLineBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.lines = new StructureBspDebugInfoRenderLineBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.lines[i] = new StructureBspDebugInfoRenderLineBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.immersedClusterIndices = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.immersedClusterIndices[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.boundingFogPlaneIndices = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.boundingFogPlaneIndices[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.collisionFogPlaneIndices = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.collisionFogPlaneIndices[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 88, Pack = 4)]
    public partial class StructureBspDebugInfoBlock
    {
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public StructureBspClusterDebugInfoBlock[] clusters;
        [TagBlockField]
        public StructureBspFogPlaneDebugInfoBlock[] fogPlanes;
        [TagBlockField]
        public StructureBspFogZoneDebugInfoBlock[] fogZones;
        public StructureBspDebugInfoBlock()
        {
        }
        public StructureBspDebugInfoBlock(BinaryReader binaryReader)
        {
            this.padding = binaryReader.ReadBytes(64);
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspClusterDebugInfoBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.clusters = new StructureBspClusterDebugInfoBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.clusters[i] = new StructureBspClusterDebugInfoBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspFogPlaneDebugInfoBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.fogPlanes = new StructureBspFogPlaneDebugInfoBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.fogPlanes[i] = new StructureBspFogPlaneDebugInfoBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(StructureBspFogZoneDebugInfoBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.fogZones = new StructureBspFogZoneDebugInfoBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.fogZones[i] = new StructureBspFogZoneDebugInfoBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class BreakableSurfaceKeyTableBlock
    {
        public short instancedGeometryIndex;
        public short breakableSurfaceIndex;
        public int seedSurfaceIndex;
        public float x0;
        public float x1;
        public float y0;
        public float y1;
        public float z0;
        public float z1;
        public BreakableSurfaceKeyTableBlock()
        {
        }
        public BreakableSurfaceKeyTableBlock(BinaryReader binaryReader)
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
    }


    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 4)]
    public partial class GlobalStructurePhysicsStruct
    {
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingmoppCode;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public Vector3 moppBoundsMin;
        public Vector3 moppBoundsMax;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingbreakableSurfacesMoppCode;
        #endregion
        [TagBlockField]
        public BreakableSurfaceKeyTableBlock[] breakableSurfaceKeyTable;
        public GlobalStructurePhysicsStruct()
        {
        }
        public GlobalStructurePhysicsStruct(BinaryReader binaryReader)
        {
            this.paddingmoppCode = binaryReader.ReadBytes(8);
            this.padding = binaryReader.ReadBytes(4);
            this.moppBoundsMin = binaryReader.ReadVector3();
            this.moppBoundsMax = binaryReader.ReadVector3();
            this.paddingbreakableSurfacesMoppCode = binaryReader.ReadBytes(8);
            {
                var elementSize = Marshal.SizeOf(typeof(BreakableSurfaceKeyTableBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.breakableSurfaceKeyTable = new BreakableSurfaceKeyTableBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.breakableSurfaceKeyTable[i] = new BreakableSurfaceKeyTableBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
    public partial class WaterGeometrySectionBlock
    {
        [TagStructField]
        public GlobalGeometrySectionStruct section;
        public WaterGeometrySectionBlock()
        {
        }
        public WaterGeometrySectionBlock(BinaryReader binaryReader)
        {
            this.section = new GlobalGeometrySectionStruct(binaryReader);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 172, Pack = 4)]
    public partial class GlobalWaterDefinitionsBlock
    {
        [TagReference("shad")]
        public TagReference shader;
        [TagBlockField]
        public WaterGeometrySectionBlock[] section;
        [TagStructField]
        public GlobalGeometryBlockInfoStruct geometryBlockInfo;
        public ColorR8G8B8 sunSpotColor;
        public ColorR8G8B8 reflectionTint;
        public ColorR8G8B8 refractionTint;
        public ColorR8G8B8 horizonColor;
        public float sunSpecularPower;
        public float reflectionBumpScale;
        public float refractionBumpScale;
        public float fresnelScale;
        public float sunDirHeading;
        public float sunDirPitch;
        public float fOV;
        public float aspect;
        public float height;
        public float farz;
        public float rotateOffset;
        public Vector2 center;
        public Vector2 extents;
        public float fogNear;
        public float fogFar;
        public float dynamicHeightBias;
        public GlobalWaterDefinitionsBlock()
        {
        }
        public GlobalWaterDefinitionsBlock(BinaryReader binaryReader)
        {
            this.shader = binaryReader.ReadTagReference();
            {
                var elementSize = Marshal.SizeOf(typeof(WaterGeometrySectionBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.section = new WaterGeometrySectionBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.section[i] = new WaterGeometrySectionBlock(binaryReader);
                    }
                }
            }
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStruct(binaryReader);
            this.sunSpotColor = binaryReader.ReadColorR8G8B8();
            this.reflectionTint = binaryReader.ReadColorR8G8B8();
            this.refractionTint = binaryReader.ReadColorR8G8B8();
            this.horizonColor = binaryReader.ReadColorR8G8B8();
            this.sunSpecularPower = binaryReader.ReadSingle();
            this.reflectionBumpScale = binaryReader.ReadSingle();
            this.refractionBumpScale = binaryReader.ReadSingle();
            this.fresnelScale = binaryReader.ReadSingle();
            this.sunDirHeading = binaryReader.ReadSingle();
            this.sunDirPitch = binaryReader.ReadSingle();
            this.fOV = binaryReader.ReadSingle();
            this.aspect = binaryReader.ReadSingle();
            this.height = binaryReader.ReadSingle();
            this.farz = binaryReader.ReadSingle();
            this.rotateOffset = binaryReader.ReadSingle();
            this.center = binaryReader.ReadVector2();
            this.extents = binaryReader.ReadVector2();
            this.fogNear = binaryReader.ReadSingle();
            this.fogFar = binaryReader.ReadSingle();
            this.dynamicHeightBias = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class ScenarioObjectIdStruct
    {
        public int uniqueID;
        public ShortBlockIndex1 originBSPIndex;
        public Type type;
        public Source source;
        public ScenarioObjectIdStruct()
        {
        }
        public ScenarioObjectIdStruct(BinaryReader binaryReader)
        {
            this.uniqueID = binaryReader.ReadInt32();
            this.originBSPIndex = binaryReader.ReadShortBlockIndex1();
            this.type = (Type)binaryReader.ReadByte();
            this.source = (Source)binaryReader.ReadByte();
        }
        public enum Type : byte
        {
            Biped = 0,
            Vehicle = 1,
            Weapon = 2,
            Equipment = 3,
            Garbage = 4,
            Projectile = 5,
            Scenery = 6,
            Machine = 7,
            Control = 8,
            LightFixture = 9,
            SoundScenery = 10,
            Crate = 11,
            Creature = 12,
        }
        public enum Source : byte
        {
            Structure = 0,
            Editor = 1,
            Dynamic = 2,
            Legacy = 3,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class StructureDevicePortalAssociationBlock
    {
        [TagStructField]
        public ScenarioObjectIdStruct deviceId;
        public short firstGamePortalIndex;
        public short gamePortalCount;
        public StructureDevicePortalAssociationBlock()
        {
        }
        public StructureDevicePortalAssociationBlock(BinaryReader binaryReader)
        {
            this.deviceId = new ScenarioObjectIdStruct(binaryReader);
            this.firstGamePortalIndex = binaryReader.ReadInt16();
            this.gamePortalCount = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class GamePortalToPortalMappingBlock
    {
        public short portalIndex;
        public GamePortalToPortalMappingBlock()
        {
        }
        public GamePortalToPortalMappingBlock(BinaryReader binaryReader)
        {
            this.portalIndex = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class StructurePortalDeviceMappingBlock
    {
        [TagBlockField]
        public StructureDevicePortalAssociationBlock[] devicePortalAssociations;
        [TagBlockField]
        public GamePortalToPortalMappingBlock[] gamePortalToPortalMap;
        public StructurePortalDeviceMappingBlock()
        {
        }
        public StructurePortalDeviceMappingBlock(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(StructureDevicePortalAssociationBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.devicePortalAssociations = new StructureDevicePortalAssociationBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.devicePortalAssociations[i] = new StructureDevicePortalAssociationBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(GamePortalToPortalMappingBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.gamePortalToPortalMap = new GamePortalToPortalMappingBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.gamePortalToPortalMap[i] = new GamePortalToPortalMappingBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class DoorEncodedPasBlock
    {
        public int invalidName_;
        public DoorEncodedPasBlock()
        {
        }
        public DoorEncodedPasBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class ClusterDoorPortalEncodedPasBlock
    {
        public int invalidName_;
        public ClusterDoorPortalEncodedPasBlock()
        {
        }
        public ClusterDoorPortalEncodedPasBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class AiDeafeningEncodedPasBlock
    {
        public int invalidName_;
        public AiDeafeningEncodedPasBlock()
        {
        }
        public AiDeafeningEncodedPasBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 4)]
    public partial class EncodedClusterDistancesBlock
    {
        public byte invalidName_;
        public EncodedClusterDistancesBlock()
        {
        }
        public EncodedClusterDistancesBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadByte();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 4)]
    public partial class OccluderToMachineDoorMapping
    {
        public byte machineDoorIndex;
        public OccluderToMachineDoorMapping()
        {
        }
        public OccluderToMachineDoorMapping(BinaryReader binaryReader)
        {
            this.machineDoorIndex = binaryReader.ReadByte();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 4)]
    public partial class StructureBspAudibilityBlock
    {
        public int doorPortalCount;
        public Range clusterDistanceBounds;
        [TagBlockField]
        public DoorEncodedPasBlock[] encodedDoorPas;
        [TagBlockField]
        public ClusterDoorPortalEncodedPasBlock[] clusterDoorPortalEncodedPas;
        [TagBlockField]
        public AiDeafeningEncodedPasBlock[] aiDeafeningPas;
        [TagBlockField]
        public EncodedClusterDistancesBlock[] clusterDistances;
        [TagBlockField]
        public OccluderToMachineDoorMapping[] machineDoorMapping;
        public StructureBspAudibilityBlock()
        {
        }
        public StructureBspAudibilityBlock(BinaryReader binaryReader)
        {
            this.doorPortalCount = binaryReader.ReadInt32();
            this.clusterDistanceBounds = binaryReader.ReadRange();
            {
                var elementSize = Marshal.SizeOf(typeof(DoorEncodedPasBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.encodedDoorPas = new DoorEncodedPasBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.encodedDoorPas[i] = new DoorEncodedPasBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(ClusterDoorPortalEncodedPasBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.clusterDoorPortalEncodedPas = new ClusterDoorPortalEncodedPasBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.clusterDoorPortalEncodedPas[i] = new ClusterDoorPortalEncodedPasBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(AiDeafeningEncodedPasBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.aiDeafeningPas = new AiDeafeningEncodedPasBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.aiDeafeningPas[i] = new AiDeafeningEncodedPasBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(EncodedClusterDistancesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.clusterDistances = new EncodedClusterDistancesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.clusterDistances[i] = new EncodedClusterDistancesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(OccluderToMachineDoorMapping));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.machineDoorMapping = new OccluderToMachineDoorMapping[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.machineDoorMapping[i] = new OccluderToMachineDoorMapping(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 84, Pack = 4)]
    public partial class RenderLightingStruct
    {
        public ColorR8G8B8 ambient;
        public Vector3 shadowDirection;
        public float lightingAccuracy;
        public float shadowOpacity;
        public ColorR8G8B8 primaryDirectionColor;
        public Vector3 primaryDirection;
        public ColorR8G8B8 secondaryDirectionColor;
        public Vector3 secondaryDirection;
        public short shIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public RenderLightingStruct()
        {
        }
        public RenderLightingStruct(BinaryReader binaryReader)
        {
            this.ambient = binaryReader.ReadColorR8G8B8();
            this.shadowDirection = binaryReader.ReadVector3();
            this.lightingAccuracy = binaryReader.ReadSingle();
            this.shadowOpacity = binaryReader.ReadSingle();
            this.primaryDirectionColor = binaryReader.ReadColorR8G8B8();
            this.primaryDirection = binaryReader.ReadVector3();
            this.secondaryDirectionColor = binaryReader.ReadColorR8G8B8();
            this.secondaryDirection = binaryReader.ReadVector3();
            this.shIndex = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 92, Pack = 4)]
    public partial class StructureBspFakeLightprobesBlock
    {
        [TagStructField]
        public ScenarioObjectIdStruct objectIdentifier;
        [TagStructField]
        public RenderLightingStruct renderLighting;
        public StructureBspFakeLightprobesBlock()
        {
        }
        public StructureBspFakeLightprobesBlock(BinaryReader binaryReader)
        {
            this.objectIdentifier = new ScenarioObjectIdStruct(binaryReader);
            this.renderLighting = new RenderLightingStruct(binaryReader);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 22, Pack = 4)]
    public partial class DecoratorPlacementBlock
    {
        public int internalData1;
        public int compressedPosition;
        public RGBColor tintColor;
        public RGBColor lightmapColor;
        public int compressedLightDirection;
        public int compressedLight2Direction;
        public DecoratorPlacementBlock()
        {
        }
        public DecoratorPlacementBlock(BinaryReader binaryReader)
        {
            this.internalData1 = binaryReader.ReadInt32();
            this.compressedPosition = binaryReader.ReadInt32();
            this.tintColor = binaryReader.ReadRGBColor();
            this.lightmapColor = binaryReader.ReadRGBColor();
            this.compressedLightDirection = binaryReader.ReadInt32();
            this.compressedLight2Direction = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 31, Pack = 4)]
    public partial class DecalVerticesBlock
    {
        public Vector3 position;
        public Vector2 texcoord0;
        public Vector2 texcoord1;
        public RGBColor color;
        public DecalVerticesBlock()
        {
        }
        public DecalVerticesBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.texcoord0 = binaryReader.ReadVector2();
            this.texcoord1 = binaryReader.ReadVector2();
            this.color = binaryReader.ReadRGBColor();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class IndicesBlock
    {
        public short index;
        public IndicesBlock()
        {
        }
        public IndicesBlock(BinaryReader binaryReader)
        {
            this.index = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 47, Pack = 4)]
    public partial class SpriteVerticesBlock
    {
        public Vector3 position;
        public Vector3 offset;
        public Vector3 axis;
        public Vector2 texcoord;
        public RGBColor color;
        public SpriteVerticesBlock()
        {
        }
        public SpriteVerticesBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.offset = binaryReader.ReadVector3();
            this.axis = binaryReader.ReadVector3();
            this.texcoord = binaryReader.ReadVector2();
            this.color = binaryReader.ReadRGBColor();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 136, Pack = 4)]
    public partial class DecoratorCacheBlockDataBlock
    {
        [TagBlockField]
        public DecoratorPlacementBlock[] placements;
        [TagBlockField]
        public DecalVerticesBlock[] decalVertices;
        [TagBlockField]
        public IndicesBlock[] decalIndices;
        public VertexBuffer decalVertexBuffer;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public SpriteVerticesBlock[] spriteVertices;
        [TagBlockField]
        public IndicesBlock[] spriteIndices;
        public VertexBuffer spriteVertexBuffer;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private byte[] padding0;
        #endregion
        public DecoratorCacheBlockDataBlock()
        {
        }
        public DecoratorCacheBlockDataBlock(BinaryReader binaryReader)
        {
            {
                var elementSize = Marshal.SizeOf(typeof(DecoratorPlacementBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.placements = new DecoratorPlacementBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.placements[i] = new DecoratorPlacementBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(DecalVerticesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.decalVertices = new DecalVerticesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.decalVertices[i] = new DecalVerticesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(IndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.decalIndices = new IndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.decalIndices[i] = new IndicesBlock(binaryReader);
                    }
                }
            }
            this.decalVertexBuffer = binaryReader.ReadVertexBuffer();
            this.padding = binaryReader.ReadBytes(16);
            {
                var elementSize = Marshal.SizeOf(typeof(SpriteVerticesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.spriteVertices = new SpriteVerticesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.spriteVertices[i] = new SpriteVerticesBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(IndicesBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.spriteIndices = new IndicesBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.spriteIndices[i] = new IndicesBlock(binaryReader);
                    }
                }
            }
            this.spriteVertexBuffer = binaryReader.ReadVertexBuffer();
            this.padding0 = binaryReader.ReadBytes(16);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 44, Pack = 4)]
    public partial class DecoratorCacheBlockBlock
    {
        [TagStructField]
        public GlobalGeometryBlockInfoStruct geometryBlockInfo;
        [TagBlockField]
        public DecoratorCacheBlockDataBlock[] cacheBlockData;
        public DecoratorCacheBlockBlock()
        {
        }
        public DecoratorCacheBlockBlock(BinaryReader binaryReader)
        {
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStruct(binaryReader);
            {
                var elementSize = Marshal.SizeOf(typeof(DecoratorCacheBlockDataBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.cacheBlockData = new DecoratorCacheBlockDataBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.cacheBlockData[i] = new DecoratorCacheBlockDataBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
    public partial class DecoratorGroupBlock
    {
        public ByteBlockIndex1 decoratorSet;
        public DecoratorType decoratorType;
        public byte shaderIndex;
        public byte compressedRadius;
        public short cluster;
        public ShortBlockIndex1 cacheBlock;
        public short decoratorStartIndex;
        public short decoratorCount;
        public short vertexStartOffset;
        public short vertexCount;
        public short indexStartOffset;
        public short indexCount;
        public int compressedBoundingCenter;
        public DecoratorGroupBlock()
        {
        }
        public DecoratorGroupBlock(BinaryReader binaryReader)
        {
            this.decoratorSet = binaryReader.ReadByteBlockIndex1();
            this.decoratorType = (DecoratorType)binaryReader.ReadByte();
            this.shaderIndex = binaryReader.ReadByte();
            this.compressedRadius = binaryReader.ReadByte();
            this.cluster = binaryReader.ReadInt16();
            this.cacheBlock = binaryReader.ReadShortBlockIndex1();
            this.decoratorStartIndex = binaryReader.ReadInt16();
            this.decoratorCount = binaryReader.ReadInt16();
            this.vertexStartOffset = binaryReader.ReadInt16();
            this.vertexCount = binaryReader.ReadInt16();
            this.indexStartOffset = binaryReader.ReadInt16();
            this.indexCount = binaryReader.ReadInt16();
            this.compressedBoundingCenter = binaryReader.ReadInt32();
        }
        public enum DecoratorType : byte
        {
            Model = 0,
            FloatingDecal = 1,
            ProjectedDecal = 2,
            ScreenFacingQuad = 3,
            AxisRotatingQuad = 4,
            CrossQuad = 5,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
    public partial class DecoratorCellCollectionBlock
    {
        public struct ChildIndices
        {
            public short childIndex;
            public ChildIndices(BinaryReader binaryReader)
            {
                this.childIndex = binaryReader.ReadInt16();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public ChildIndices[] childIndices;
        public ShortBlockIndex1 cacheBlockIndex;
        public short groupCount;
        public int groupStartIndex;
        public DecoratorCellCollectionBlock()
        {
        }
        public DecoratorCellCollectionBlock(BinaryReader binaryReader)
        {
            this.childIndices = new ChildIndices[8];
            for (int i = 0; i < 8; ++i)
            {
                this.childIndices[i] = new ChildIndices(binaryReader);
            }
            this.cacheBlockIndex = binaryReader.ReadShortBlockIndex1();
            this.groupCount = binaryReader.ReadInt16();
            this.groupStartIndex = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
    public partial class DecoratorProjectedDecalBlock
    {
        public ByteBlockIndex1 decoratorSet;
        public byte decoratorClass;
        public byte decoratorPermutation;
        public byte spriteIndex;
        public Vector3 position;
        public Vector3 left;
        public Vector3 up;
        public Vector3 extents;
        public Vector3 previousPosition;
        public DecoratorProjectedDecalBlock()
        {
        }
        public DecoratorProjectedDecalBlock(BinaryReader binaryReader)
        {
            this.decoratorSet = binaryReader.ReadByteBlockIndex1();
            this.decoratorClass = binaryReader.ReadByte();
            this.decoratorPermutation = binaryReader.ReadByte();
            this.spriteIndex = binaryReader.ReadByte();
            this.position = binaryReader.ReadVector3();
            this.left = binaryReader.ReadVector3();
            this.up = binaryReader.ReadVector3();
            this.extents = binaryReader.ReadVector3();
            this.previousPosition = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 4)]
    public partial class DecoratorPlacementDefinitionBlock
    {
        public Vector3 gridOrigin;
        public int cellCountPerDimension;
        [TagBlockField]
        public DecoratorCacheBlockBlock[] cacheBlocks;
        [TagBlockField]
        public DecoratorGroupBlock[] groups;
        [TagBlockField]
        public DecoratorCellCollectionBlock[] cells;
        [TagBlockField]
        public DecoratorProjectedDecalBlock[] decals;
        public DecoratorPlacementDefinitionBlock()
        {
        }
        public DecoratorPlacementDefinitionBlock(BinaryReader binaryReader)
        {
            this.gridOrigin = binaryReader.ReadVector3();
            this.cellCountPerDimension = binaryReader.ReadInt32();
            {
                var elementSize = Marshal.SizeOf(typeof(DecoratorCacheBlockBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.cacheBlocks = new DecoratorCacheBlockBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.cacheBlocks[i] = new DecoratorCacheBlockBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(DecoratorGroupBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.groups = new DecoratorGroupBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.groups[i] = new DecoratorGroupBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(DecoratorCellCollectionBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.cells = new DecoratorCellCollectionBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.cells[i] = new DecoratorCellCollectionBlock(binaryReader);
                    }
                }
            }
            {
                var elementSize = Marshal.SizeOf(typeof(DecoratorProjectedDecalBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.decals = new DecoratorProjectedDecalBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.decals[i] = new DecoratorProjectedDecalBlock(binaryReader);
                    }
                }
            }
        }
    }
}
