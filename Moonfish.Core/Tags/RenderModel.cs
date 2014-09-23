using Moonfish.Model;
using OpenTK;
using System;
using System.Runtime.InteropServices;
using System.IO;
using Moonfish.ResourceManagement;
using System.Linq;
using System.Collections.Generic;

namespace Moonfish.Tags
{
    [StructLayout(LayoutKind.Sequential, Size = 132, Pack = 4)]
    [TagClass("mode")]
    public partial class RenderModel
    {
        public StringID name;
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding0;
        #endregion
        [TagBlockField]
        public GlobalTagImportInfoBlock[] importInfo;
        [TagBlockField]
        public GlobalGeometryCompressionInfoBlock[] compressionInfo;
        [TagBlockField]
        public RenderModelRegionBlock[] regions;
        [TagBlockField]
        public RenderModelSectionBlock[] sections;
        [TagBlockField]
        public RenderModelInvalidSectionPairsBlock[] invalidSectionPairBits;
        [TagBlockField]
        public RenderModelSectionGroupBlock[] sectionGroups;
        public byte l1SectionGroupIndexSuperLow;
        public byte l2SectionGroupIndexLow;
        public byte l3SectionGroupIndexMedium;
        public byte l4SectionGroupIndexHigh;
        public byte l5SectionGroupIndexSuperHigh;
        public byte l6SectionGroupIndexHollywood;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding1;
        #endregion
        public int nodeListChecksum;
        [TagBlockField]
        public RenderModelNodeBlock[] nodes;
        [TagBlockField]
        public RenderModelNodeMapBlockOLD[] nodeMapOLD;
        [TagBlockField]
        public RenderModelMarkerGroupBlock[] markerGroups;
        [TagBlockField]
        public GlobalGeometryMaterialBlock[] materials;
        [TagBlockField]
        public GlobalErrorReportCategoriesBlock[] errors;
        public float dontDrawOverCameraCosineAngleDontDrawFpModelWhenCameraThisAngleCosine11Sugg020Disables;
        [TagBlockField]
        public PrtInfoBlock[] pRTInfo;
        [TagBlockField]
        public SectionRenderLeavesBlock[] sectionRenderLeaves;
        public RenderModel()
        {
        }
        public RenderModel(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(4);
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalTagImportInfoBlock));
                this.importInfo = new GlobalTagImportInfoBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.importInfo[i] = new GlobalTagImportInfoBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryCompressionInfoBlock));
                this.compressionInfo = new GlobalGeometryCompressionInfoBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.compressionInfo[i] = new GlobalGeometryCompressionInfoBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelRegionBlock));
                this.regions = new RenderModelRegionBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.regions[i] = new RenderModelRegionBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelSectionBlock));
                this.sections = new RenderModelSectionBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.sections[i] = new RenderModelSectionBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelInvalidSectionPairsBlock));
                this.invalidSectionPairBits = new RenderModelInvalidSectionPairsBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.invalidSectionPairBits[i] = new RenderModelInvalidSectionPairsBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelSectionGroupBlock));
                this.sectionGroups = new RenderModelSectionGroupBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.sectionGroups[i] = new RenderModelSectionGroupBlock(binaryReader);
                    }
                }
            }
            this.l1SectionGroupIndexSuperLow = binaryReader.ReadByte();
            this.l2SectionGroupIndexLow = binaryReader.ReadByte();
            this.l3SectionGroupIndexMedium = binaryReader.ReadByte();
            this.l4SectionGroupIndexHigh = binaryReader.ReadByte();
            this.l5SectionGroupIndexSuperHigh = binaryReader.ReadByte();
            this.l6SectionGroupIndexHollywood = binaryReader.ReadByte();
            this.padding1 = binaryReader.ReadBytes(2);
            this.nodeListChecksum = binaryReader.ReadInt32();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelNodeBlock));
                this.nodes = new RenderModelNodeBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.nodes[i] = new RenderModelNodeBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelNodeMapBlockOLD));
                this.nodeMapOLD = new RenderModelNodeMapBlockOLD[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.nodeMapOLD[i] = new RenderModelNodeMapBlockOLD(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelMarkerGroupBlock));
                this.markerGroups = new RenderModelMarkerGroupBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.markerGroups[i] = new RenderModelMarkerGroupBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryMaterialBlock));
                this.materials = new GlobalGeometryMaterialBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.materials[i] = new GlobalGeometryMaterialBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
                this.errors = new GlobalErrorReportCategoriesBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.errors[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                    }
                }
            }
            this.dontDrawOverCameraCosineAngleDontDrawFpModelWhenCameraThisAngleCosine11Sugg020Disables = binaryReader.ReadSingle();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(PrtInfoBlock));
                this.pRTInfo = new PrtInfoBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.pRTInfo[i] = new PrtInfoBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(SectionRenderLeavesBlock));
                this.sectionRenderLeaves = new SectionRenderLeavesBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.sectionRenderLeaves[i] = new SectionRenderLeavesBlock(binaryReader);
                    }
                }
            }
        }
        [Flags]
        public enum Flags : short
        {
            RenderModelForceThirdPersonBit = 1,
            ForceCarmackReverse = 2,
            ForceNodeMaps = 4,
            GeometryPostprocessed = 8,
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
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(TagImportFileBlock));
                this.files = new TagImportFileBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.files[i] = new TagImportFileBlock(binaryReader);
                    }
                }
            }
            this.padding1 = binaryReader.ReadBytes(128);
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


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class RenderModelPermutationBlock
    {
        public StringID name;
        public short l1SectionIndexSuperLow;
        public short l2SectionIndexLow;
        public short l3SectionIndexMedium;
        public short l4SectionIndexHigh;
        public short l5SectionIndexSuperHigh;
        public short l6SectionIndexHollywood;
        public RenderModelPermutationBlock()
        {
        }
        public RenderModelPermutationBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.l1SectionIndexSuperLow = binaryReader.ReadInt16();
            this.l2SectionIndexLow = binaryReader.ReadInt16();
            this.l3SectionIndexMedium = binaryReader.ReadInt16();
            this.l4SectionIndexHigh = binaryReader.ReadInt16();
            this.l5SectionIndexSuperHigh = binaryReader.ReadInt16();
            this.l6SectionIndexHollywood = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class RenderModelRegionBlock
    {
        public StringID name;
        public short nodeMapOffsetOLD;
        public short nodeMapSizeOLD;
        [TagBlockField]
        public RenderModelPermutationBlock[] permutations;
        public RenderModelRegionBlock()
        {
        }
        public RenderModelRegionBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.nodeMapOffsetOLD = binaryReader.ReadInt16();
            this.nodeMapSizeOLD = binaryReader.ReadInt16();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelPermutationBlock));
                this.permutations = new RenderModelPermutationBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.permutations[i] = new RenderModelPermutationBlock(binaryReader);
                    }
                }
            }
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
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryCompressionInfoBlock));
                this.eMPTYSTRING = new GlobalGeometryCompressionInfoBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
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
        public GlobalGeometryPartBlockNew[] parts;
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
        public GlobalGeometrySectionVertexBufferBlock[] vertexBuffers;
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
                this.parts = new GlobalGeometryPartBlockNew[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.parts[i] = new GlobalGeometryPartBlockNew(binaryReader);
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
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionVertexBufferBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.vertexBuffers = new GlobalGeometrySectionVertexBufferBlock[blamPointer.Count];
                List<BlamPointer> vertexBufferPointers = null;
                if (binaryReader.BaseStream is ResourceStream)
                {
                    var stream = binaryReader.BaseStream as ResourceStream;
                    vertexBufferPointers = stream.Resources.Where(x => x.type == GlobalGeometryBlockResourceBlock.Type.VertexBuffer)
                    .Select(x=>
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
                        this.vertexBuffers[i] = new GlobalGeometrySectionVertexBufferBlock(binaryReader);
                        if (vertexBufferPointers != null)
                        {
                            binaryReader.BaseStream.Position = vertexBufferPointers[i].Address;
                            this.vertexBuffers[i].vertexBuffer.Data = binaryReader.ReadBytes(vertexBufferPointers[i].Count);
                        }
                    }
                }
            }
            this.padding = binaryReader.ReadBytes(4);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
    public partial class GlobalGeometryRawPointBlock
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
        public GlobalGeometryRawPointBlock()
        {
        }
        public GlobalGeometryRawPointBlock(BinaryReader binaryReader)
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
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class GlobalGeometryRigidPointGroupBlock
    {
        public byte rigidNodeIndex;
        public byte nodesPoint;
        public short pointCount;
        public GlobalGeometryRigidPointGroupBlock()
        {
        }
        public GlobalGeometryRigidPointGroupBlock(BinaryReader binaryReader)
        {
            this.rigidNodeIndex = binaryReader.ReadByte();
            this.nodesPoint = binaryReader.ReadByte();
            this.pointCount = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class GlobalGeometryPointDataIndexBlock
    {
        public short index;
        public GlobalGeometryPointDataIndexBlock()
        {
        }
        public GlobalGeometryPointDataIndexBlock(BinaryReader binaryReader)
        {
            this.index = binaryReader.ReadInt16();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class GlobalGeometryPointDataStruct
    {
        [TagBlockField]
        public GlobalGeometryRawPointBlock[] rawPoints;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingruntimePointData;
        #endregion
        [TagBlockField]
        public GlobalGeometryRigidPointGroupBlock[] rigidPointGroups;
        [TagBlockField]
        public GlobalGeometryPointDataIndexBlock[] vertexPointIndices;
        public GlobalGeometryPointDataStruct()
        {
        }
        public GlobalGeometryPointDataStruct(BinaryReader binaryReader)
        {
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryRawPointBlock));
                this.rawPoints = new GlobalGeometryRawPointBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.rawPoints[i] = new GlobalGeometryRawPointBlock(binaryReader);
                    }
                }
            }
            this.paddingruntimePointData = binaryReader.ReadBytes(8);
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryRigidPointGroupBlock));
                this.rigidPointGroups = new GlobalGeometryRigidPointGroupBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.rigidPointGroups[i] = new GlobalGeometryRigidPointGroupBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryPointDataIndexBlock));
                this.vertexPointIndices = new GlobalGeometryPointDataIndexBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.vertexPointIndices[i] = new GlobalGeometryPointDataIndexBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 4)]
    public partial class RenderModelNodeMapBlock
    {
        public byte nodeIndex;
        public RenderModelNodeMapBlock()
        {
        }
        public RenderModelNodeMapBlock(BinaryReader binaryReader)
        {
            this.nodeIndex = binaryReader.ReadByte();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 112, Pack = 4)]
    public partial class RenderModelSectionDataBlock
    {
        [TagStructField]
        public GlobalGeometrySectionStruct section;
        [TagStructField]
        public GlobalGeometryPointDataStruct pointData;
        [TagBlockField]
        public RenderModelNodeMapBlock[] nodeMap;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public RenderModelSectionDataBlock()
        {
        }
        public RenderModelSectionDataBlock(BinaryReader binaryReader)
        {
            this.section = new GlobalGeometrySectionStruct(binaryReader);
            this.pointData = new GlobalGeometryPointDataStruct(binaryReader);
            {
                var elementSize = Marshal.SizeOf(typeof(RenderModelNodeMapBlock));
                var blamPointer = binaryReader.ReadBlamPointer(elementSize);
                this.nodeMap = new RenderModelNodeMapBlock[blamPointer.Count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < blamPointer.Count; ++i)
                    {
                        binaryReader.BaseStream.Position = blamPointer[i];
                        this.nodeMap[i] = new RenderModelNodeMapBlock(binaryReader);
                    }
                }
            }
            this.padding = binaryReader.ReadBytes(4);
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 92, Pack = 4)]
    public partial class RenderModelSectionBlock
    {
        public GlobalGeometryClassificationEnumDefinition globalGeometryClassificationEnumDefinition;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        [TagStructField]
        public GlobalGeometrySectionInfoStruct sectionInfo;
        public ShortBlockIndex1 rigidNode;
        public Flags flags;
        [TagBlockField]
        public RenderModelSectionDataBlock[] sectionData;
        [TagStructField]
        public GlobalGeometryBlockInfoStruct geometryBlockInfo;
        public RenderModelSectionBlock()
        {
        }
        public RenderModelSectionBlock(BinaryReader binaryReader)
        {
            this.globalGeometryClassificationEnumDefinition = (GlobalGeometryClassificationEnumDefinition)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.sectionInfo = new GlobalGeometrySectionInfoStruct(binaryReader);
            this.rigidNode = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelSectionDataBlock));
                this.sectionData = new RenderModelSectionDataBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.sectionData[i] = new RenderModelSectionDataBlock(binaryReader);
                    }
                }
            }
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStruct(binaryReader);
        }
        public enum GlobalGeometryClassificationEnumDefinition : short
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        }
        [Flags]
        public enum Flags : short
        {
            GeometryPostprocessed = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class RenderModelInvalidSectionPairsBlock
    {
        public int bits;
        public RenderModelInvalidSectionPairsBlock()
        {
        }
        public RenderModelInvalidSectionPairsBlock(BinaryReader binaryReader)
        {
            this.bits = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class RenderModelCompoundNodeBlock
    {
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
        public RenderModelCompoundNodeBlock()
        {
        }
        public RenderModelCompoundNodeBlock(BinaryReader binaryReader)
        {
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
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class RenderModelSectionGroupBlock
    {
        public DetailLevels detailLevels;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public RenderModelCompoundNodeBlock[] compoundNodes;
        public RenderModelSectionGroupBlock()
        {
        }
        public RenderModelSectionGroupBlock(BinaryReader binaryReader)
        {
            this.detailLevels = (DetailLevels)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelCompoundNodeBlock));
                this.compoundNodes = new RenderModelCompoundNodeBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.compoundNodes[i] = new RenderModelCompoundNodeBlock(binaryReader);
                    }
                }
            }
        }
        [Flags]
        public enum DetailLevels : short
        {
            L1SuperLow = 1,
            L2Low = 2,
            L3Medium = 4,
            L4High = 8,
            L5SuperHigh = 16,
            L6Hollywood = 32,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 96, Pack = 4)]
    public partial class RenderModelNodeBlock
    {
        public StringID name;
        public ShortBlockIndex1 parentNode;
        public ShortBlockIndex1 firstChildNode;
        public ShortBlockIndex1 nextSiblingNode;
        public short importNodeIndex;
        public Vector3 defaultTranslation;
        public Quaternion defaultRotation;
        public Vector3 inverseForward;
        public Vector3 inverseLeft;
        public Vector3 inverseUp;
        public Vector3 inversePosition;
        public float inverseScale;
        public float distanceFromParent;
        public RenderModelNodeBlock()
        {
        }
        public RenderModelNodeBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.parentNode = binaryReader.ReadShortBlockIndex1();
            this.firstChildNode = binaryReader.ReadShortBlockIndex1();
            this.nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            this.importNodeIndex = binaryReader.ReadInt16();
            this.defaultTranslation = binaryReader.ReadVector3();
            this.defaultRotation = binaryReader.ReadQuaternion();
            this.inverseForward = binaryReader.ReadVector3();
            this.inverseLeft = binaryReader.ReadVector3();
            this.inverseUp = binaryReader.ReadVector3();
            this.inversePosition = binaryReader.ReadVector3();
            this.inverseScale = binaryReader.ReadSingle();
            this.distanceFromParent = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 4)]
    public partial class RenderModelNodeMapBlockOLD
    {
        public byte nodeIndex;
        public RenderModelNodeMapBlockOLD()
        {
        }
        public RenderModelNodeMapBlockOLD(BinaryReader binaryReader)
        {
            this.nodeIndex = binaryReader.ReadByte();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
    public partial class RenderModelMarkerBlock
    {
        public byte regionIndex;
        public byte permutationIndex;
        public byte nodeIndex;
        #region padding
        private byte padding;
        #endregion
        public Vector3 translation;
        public Quaternion rotation;
        public float scale;
        public RenderModelMarkerBlock()
        {
        }
        public RenderModelMarkerBlock(BinaryReader binaryReader)
        {
            this.regionIndex = binaryReader.ReadByte();
            this.permutationIndex = binaryReader.ReadByte();
            this.nodeIndex = binaryReader.ReadByte();
            this.padding = binaryReader.ReadByte();
            this.translation = binaryReader.ReadVector3();
            this.rotation = binaryReader.ReadQuaternion();
            this.scale = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class RenderModelMarkerGroupBlock
    {
        public StringID name;
        [TagBlockField]
        public RenderModelMarkerBlock[] markers;
        public RenderModelMarkerGroupBlock()
        {
        }
        public RenderModelMarkerGroupBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(RenderModelMarkerBlock));
                this.markers = new RenderModelMarkerBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.markers[i] = new RenderModelMarkerBlock(binaryReader);
                    }
                }
            }
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
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryMaterialPropertyBlock));
                this.properties = new GlobalGeometryMaterialPropertyBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.properties[i] = new GlobalGeometryMaterialPropertyBlock(binaryReader);
                    }
                }
            }
            this.padding = binaryReader.ReadBytes(4);
            this.breakableSurfaceIndex = binaryReader.ReadByte();
            this.padding0 = binaryReader.ReadBytes(3);
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
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ErrorReportVerticesBlock));
                this.vertices = new ErrorReportVerticesBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.vertices[i] = new ErrorReportVerticesBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ErrorReportVectorsBlock));
                this.vectors = new ErrorReportVectorsBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.vectors[i] = new ErrorReportVectorsBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ErrorReportLinesBlock));
                this.lines = new ErrorReportLinesBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.lines[i] = new ErrorReportLinesBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ErrorReportTrianglesBlock));
                this.triangles = new ErrorReportTrianglesBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.triangles[i] = new ErrorReportTrianglesBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ErrorReportQuadsBlock));
                this.quads = new ErrorReportQuadsBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.quads[i] = new ErrorReportQuadsBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ErrorReportCommentsBlock));
                this.comments = new ErrorReportCommentsBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
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
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ErrorReportsBlock));
                this.reports = new ErrorReportsBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
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


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class PrtSectionInfoBlock
    {
        public int sectionIndex;
        public int pcaDataOffset;
        public PrtSectionInfoBlock()
        {
        }
        public PrtSectionInfoBlock(BinaryReader binaryReader)
        {
            this.sectionIndex = binaryReader.ReadInt32();
            this.pcaDataOffset = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class PrtLodInfoBlock
    {
        public int clusterOffset;
        [TagBlockField]
        public PrtSectionInfoBlock[] sectionInfo;
        public PrtLodInfoBlock()
        {
        }
        public PrtLodInfoBlock(BinaryReader binaryReader)
        {
            this.clusterOffset = binaryReader.ReadInt32();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(PrtSectionInfoBlock));
                this.sectionInfo = new PrtSectionInfoBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.sectionInfo[i] = new PrtSectionInfoBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class PrtClusterBasisBlock
    {
        public float basisData;
        public PrtClusterBasisBlock()
        {
        }
        public PrtClusterBasisBlock(BinaryReader binaryReader)
        {
            this.basisData = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class PrtRawPcaDataBlock
    {
        public float rawPcaData;
        public PrtRawPcaDataBlock()
        {
        }
        public PrtRawPcaDataBlock(BinaryReader binaryReader)
        {
            this.rawPcaData = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class PrtVertexBuffersBlock
    {
        public VertexBuffer vertexBuffer;
        public PrtVertexBuffersBlock()
        {
        }
        public PrtVertexBuffersBlock(BinaryReader binaryReader)
        {
            this.vertexBuffer = binaryReader.ReadVertexBuffer();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 88, Pack = 4)]
    public partial class PrtInfoBlock
    {
        public short sHOrder;
        public short numOfClusters;
        public short pcaVectorsPerCluster;
        public short numberOfRays;
        public short numberOfBounces;
        public short matIndexForSbsfcScattering;
        public float lengthScale;
        public short numberOfLodsInModel;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public PrtLodInfoBlock[] lodInfo;
        [TagBlockField]
        public PrtClusterBasisBlock[] clusterBasis;
        [TagBlockField]
        public PrtRawPcaDataBlock[] rawPcaData;
        [TagBlockField]
        public PrtVertexBuffersBlock[] vertexBuffers;
        [TagStructField]
        public GlobalGeometryBlockInfoStruct geometryBlockInfo;
        public PrtInfoBlock()
        {
        }
        public PrtInfoBlock(BinaryReader binaryReader)
        {
            this.sHOrder = binaryReader.ReadInt16();
            this.numOfClusters = binaryReader.ReadInt16();
            this.pcaVectorsPerCluster = binaryReader.ReadInt16();
            this.numberOfRays = binaryReader.ReadInt16();
            this.numberOfBounces = binaryReader.ReadInt16();
            this.matIndexForSbsfcScattering = binaryReader.ReadInt16();
            this.lengthScale = binaryReader.ReadSingle();
            this.numberOfLodsInModel = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(PrtLodInfoBlock));
                this.lodInfo = new PrtLodInfoBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.lodInfo[i] = new PrtLodInfoBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(PrtClusterBasisBlock));
                this.clusterBasis = new PrtClusterBasisBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.clusterBasis[i] = new PrtClusterBasisBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(PrtRawPcaDataBlock));
                this.rawPcaData = new PrtRawPcaDataBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.rawPcaData[i] = new PrtRawPcaDataBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(PrtVertexBuffersBlock));
                this.vertexBuffers = new PrtVertexBuffersBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.vertexBuffers[i] = new PrtVertexBuffersBlock(binaryReader);
                    }
                }
            }
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStruct(binaryReader);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class BspLeafBlock
    {
        public short cluster;
        public short surfaceReferenceCount;
        public int firstSurfaceReferenceIndex;
        public BspLeafBlock()
        {
        }
        public BspLeafBlock(BinaryReader binaryReader)
        {
            this.cluster = binaryReader.ReadInt16();
            this.surfaceReferenceCount = binaryReader.ReadInt16();
            this.firstSurfaceReferenceIndex = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class BspSurfaceReferenceBlock
    {
        public short stripIndex;
        public short lightmapTriangleIndex;
        public int bspNodeIndex;
        public BspSurfaceReferenceBlock()
        {
        }
        public BspSurfaceReferenceBlock(BinaryReader binaryReader)
        {
            this.stripIndex = binaryReader.ReadInt16();
            this.lightmapTriangleIndex = binaryReader.ReadInt16();
            this.bspNodeIndex = binaryReader.ReadInt32();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class NodeRenderLeavesBlock
    {
        [TagBlockField]
        public BspLeafBlock[] collisionLeaves;
        [TagBlockField]
        public BspSurfaceReferenceBlock[] surfaceReferences;
        public NodeRenderLeavesBlock()
        {
        }
        public NodeRenderLeavesBlock(BinaryReader binaryReader)
        {
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(BspLeafBlock));
                this.collisionLeaves = new BspLeafBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.collisionLeaves[i] = new BspLeafBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(BspSurfaceReferenceBlock));
                this.surfaceReferences = new BspSurfaceReferenceBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.surfaceReferences[i] = new BspSurfaceReferenceBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class SectionRenderLeavesBlock
    {
        [TagBlockField]
        public NodeRenderLeavesBlock[] nodeRenderLeaves;
        public SectionRenderLeavesBlock()
        {
        }
        public SectionRenderLeavesBlock(BinaryReader binaryReader)
        {
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(NodeRenderLeavesBlock));
                this.nodeRenderLeaves = new NodeRenderLeavesBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.nodeRenderLeaves[i] = new NodeRenderLeavesBlock(binaryReader);
                    }
                }
            }
        }
    }
}

