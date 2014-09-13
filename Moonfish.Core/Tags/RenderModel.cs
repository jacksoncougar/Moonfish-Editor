using Moonfish.Model;
using OpenTK;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Linq;
using Fasterflect;
using System.Security.Permissions;

namespace Moonfish.Tags
{
    [StructLayout(LayoutKind.Sequential, Size = 132, Pack = 0)]
    [TagClass("mode")]
    public class RenderModel
    {
        StringID name;
        Flags flags;


        [TagBlockField(Offset = 20)]
        public GlobalGeometryCompressionInfoBlock[] compressionInfo;

        [TagBlockField(Offset = 28)]
        public RenderModelRegionBlock[] regions;

        [TagBlockField(Offset = 36)]
        public RenderModelSectionBlock[] Sections;

        [TagBlockField(Offset = 72)]
        public RenderModelNodeBlock[] nodes;

        [TagBlockField(Offset = 88)]
        public RenderModelMarkerGroupBlock[] markerGroups;

        [TagBlockField(Offset = 96)]
        public GlobalGeometryMaterialBlock[] materials;

        enum Flags : short
        {
            RenderModelForceThirdPersonBit = 0,
            ForceCarmackReverse = 0,
            ForceNodeMaps = 0,
            GeometryPostprocessed = 0,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 528, Pack = 0)]
    public class TagImportFileBlock
    {
        String256 path;
        String32 modificationDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] skipinvalidName_;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
        byte[] paddinginvalidName_0;
        int checksumCrc32;
        int sizeBytes;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] paddingzippedData;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        byte[] paddinginvalidName_1;
    };


    [StructLayout(LayoutKind.Sequential, Size = 592, Pack = 0)]
    public class GlobalTagImportInfoBlock
    {
        int build;
        String256 version;
        String32 importDate;
        String32 culprit;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        byte[] paddinginvalidName_;
        String32 importTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddinginvalidName_0;
        [TagBlockField]
        TagImportFileBlock[] files;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingfiles0;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        byte[] paddinginvalidName_1;
    };


    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 0)]
    public class GlobalGeometryCompressionInfoBlock
    {
        Range positionBoundsX;
        Range positionBoundsY;
        Range positionBoundsZ;
        Range texcoordBoundsX;
        Range texcoordBoundsY;
        Range secondaryTexcoordBoundsX;
        Range secondaryTexcoordBoundsY;

        public Matrix4 ToExtentsMatrix()
        {

            Matrix4 extents_matrix = new Matrix4(
                new Vector4(positionBoundsX.Length / 2, 0.0f, 0.0f, 0.0f),
                new Vector4(0.0f, positionBoundsY.Length / 2, 0.0f, 0.0f),
                new Vector4(0.0f, 0.0f, positionBoundsZ.Length / 2, 0.0f),
                new Vector4(positionBoundsX.min + positionBoundsX.Length / 2, positionBoundsY.min + positionBoundsY.Length / 2, positionBoundsZ.min + positionBoundsZ.Length / 2, 1.0f)
                );
            return extents_matrix;
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 0)]
    public class RenderModelPermutationBlock
    {
        public StringID name;
        public short l1SectionIndexSuperLow;
        public short l2SectionIndexLow;
        public short l3SectionIndexMedium;
        public short l4SectionIndexHigh;
        public short l5SectionIndexSuperHigh;
        public short l6SectionIndexHollywood;
    };


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 0)]
    public class RenderModelRegionBlock
    {
        public StringID name;
        public short nodeMapOffsetOLD;
        public short nodeMapSizeOLD;
        [TagBlockField]
        public RenderModelPermutationBlock[] permutations;
    };


    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 0)]
    public class GlobalGeometrySectionInfoStruct
    {
        //FIELD_EXPLAINATION("SECTION INFO", "EMPTY STRING"),
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
        GlobalGeometryCompressionInfoBlock[] eMPTYSTRING;
        public byte hardwareNodeCount;
        public byte nodeMapSize;
        public short softwarePlaneCount;
        public short totalSubpartCont;
        public SectionLightingFlags sectionLightingFlags;
        public enum GeometryClassification : short
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        }
        public enum GeometryCompressionFlags : short
        {
            CompressedPosition = 0,
            CompressedTexcoord = 0,
            CompressedSecondaryTexcoord = 0,
        }
        public enum SectionLightingFlags : short
        {
            HasLmTexcoords = 0,
            HasLmIncRad = 0,
            HasLmColors = 0,
            HasLmPrt = 0,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 72, Pack = 0)]
    public class GlobalGeometryPartBlockNew
    {
        public Type type;
        public Flags flags;
        public ShortBlockIndex1 material; //   &global_geometry_material_block},
        public short stripStartIndex;
        public short stripLength;
        public short firstSubpartIndex;
        public short subpartCount;
        public byte maxNodesVertex;
        public byte contributingCompoundNodeCount;
        //FIELD_EXPLAINATION("CENTROID", "EMPTY STRING"),
        public Vector3 position;

        
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] nodeIndices;

        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] nodeWeights;
        public float lodMipmapMagicNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        byte[] skipinvalidName_;
        public enum Type : short
        {
            NotDrawn = 0,
            OpaqueShadowOnly = 1,
            OpaqueShadowCasting = 2,
            OpaqueNonshadowing = 3,
            Transparent = 4,
            LightmapOnly = 5,
        }
        public enum Flags : short
        {
            Decalable = 1,
            NewPartTypes = 2,
            DislikesPhotons = 4,
            OverrideTriangleList = 8,
            IgnoredByLightmapper = 16,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public class GlobalSubpartsBlock
    {
        short indicesStartIndex;
        short indicesLength;
        short visibilityBoundsIndex;
        short partIndex;
    };


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 0)]
    public class GlobalVisibilityBoundsBlock
    {
        float positionX;
        float positionY;
        float positionZ;
        float radius;
        byte node0;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        byte[] paddinginvalidName_;
    };


    [StructLayout(LayoutKind.Sequential, Size = 172, Pack = 0)]
    public class GlobalGeometrySectionRawVertexBlock
    {
        Vector3 position;

        struct NodeIndicesOLD
        {
            int nodeIndexOLD;
        }
        NodeIndicesOLD nodeIndicesOLD;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeIndicesOLD0;

        struct NodeWeights
        {
            float nodeWeight;
        }
        NodeWeights nodeWeights;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeWeights0;

        struct NodeIndicesNEW
        {
            int nodeIndexNEW;
        }
        NodeIndicesNEW nodeIndicesNEW;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeIndicesNEW0;
        int useNewNodeIndices;
        int adjustedCompoundNodeIndex;
        Vector2 texcoord;
        Vector3 normal;
        Vector3 binormal;
        Vector3 tangent;
        Vector3 anisotropicBinormal;
        Vector2 secondaryTexcoord;
        ColorR8G8B8 primaryLightmapColor;
        Vector2 primaryLightmapTexcoord;
        Vector3 primaryLightmapIncidentDirection;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        byte[] paddinginvalidName_;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] paddinginvalidName_0;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        byte[] paddinginvalidName_1;
    };


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 0)]
    public struct GlobalGeometrySectionStripIndexBlock
    {
        public short index;

        public override string ToString()
        {
            return index.ToString();
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 0)]
    public class GlobalGeometrySectionVertexBufferBlock
    {
        public VertexBuffer vertexBuffer;
    };


    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 0)]
    public class GlobalGeometrySectionStruct
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

        [TagBlockField]
        byte[] paddingvisibilityMoppCode;

        [TagBlockField]
        public GlobalGeometrySectionStripIndexBlock[] moppReorderTable;

        [TagBlockField]
        public GlobalGeometrySectionVertexBufferBlock[] vertexBuffers;

    };


    [StructLayout(LayoutKind.Sequential, Size = 44, Pack = 0)]
    public class GlobalGeometryRawPointBlock
    {
        Vector3 position;

        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        int[] nodeIndicesOLD;

        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        float[] nodeWeights;

        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        int[] nodeIndicesNEW;
        int useNewNodeIndices;
        int adjustedCompoundNodeIndex;
    };


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 0)]
    public class GlobalGeometryRigidPointGroupBlock
    {
        byte rigidNodeIndex;
        byte nodesPoint;
        short pointCount;
    };


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 0)]
    public class GlobalGeometryPointDataIndexBlock
    {
        short index;
    };


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 0)]
    public class GlobalGeometryPointDataStruct
    {
        [TagBlockField]
        GlobalGeometryRawPointBlock[] rawPoints;
        [TagBlockField]
        byte[] paddingruntimePointData;
        [TagBlockField]
        GlobalGeometryRigidPointGroupBlock[] rigidPointGroups;
        [TagBlockField]
        GlobalGeometryPointDataIndexBlock[] vertexPointIndices;
    };


    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 0)]
    public class RenderModelNodeMapBlock
    {
        byte nodeIndex;
    };


    [StructLayout(LayoutKind.Sequential, Size = 112, Pack = 0)]
    public class RenderModelSectionDataBlock
    {
        [TagStructField]
        public GlobalGeometrySectionStruct section;
        [TagStructField]
        public GlobalGeometryPointDataStruct pointData;
        //[TagBlockField]
        //RenderModelNodeMapBlock[] nodeMap;
        //[TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        //byte[] paddingnodeMap0;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        //byte[] paddinginvalidName_;
    };

    public partial class GlobalGeometryBlockInfoStruct
    {
        public bool IsInternal
        {
            get
            {
                return (blockOffset & 0xC0000000) == 0;
            }
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 92, Pack = 0)]
    public class RenderModelSectionBlock
    {
        public GlobalGeometryClassificationEnumDefinition globalGeometryClassificationEnumDefinition;
        [TagStructField(Offset = 4)]
        public GlobalGeometrySectionInfoStruct sectionInfo; //44
        public ShortBlockIndex1 rigidNode; //   &render_model_node_block},
        public Flags flags;//48
        [TagBlockField(UsesCustomFunction = true)]
        public RenderModelSectionDataBlock[] sectionData;
        [TagStructField]
        public GlobalGeometryBlockInfoStruct geometryBlockInfo;
        public enum GlobalGeometryClassificationEnumDefinition : short
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        }
        public enum Flags : short
        {
            GeometryPostprocessed = 0,
        }
        
        [ReflectionPermission( SecurityAction.Assert, Unrestricted = true)]
        public void ReadSectionData(BinaryReader sourceReader, Object item, FieldInfo field)
        {
            var originalDelegate = Deserializer.ProcessTagBlockArray.Clone();
            Deserializer.ProcessTagBlockArray = new Deserializer.ProcessTagBlockArrayDelegate(CustomProcessTagBlockArray);
            //DeserializerOLD.PreprocessField = new DeserializerOLD.PreprocessFieldDelegate(PreprocessField);

            if (!geometryBlockInfo.IsInternal)
            {
                Deserializer.PreprocessField = null;
                Deserializer.ProcessTagBlockArray = (Deserializer.ProcessTagBlockArrayDelegate)originalDelegate;
                field.Set(item, new RenderModelSectionDataBlock[0]);
            }
            else
            {
                sourceReader.BaseStream.Position = geometryBlockInfo.blockOffset + 8;
                var returnValue = Deserializer.Deserialize(sourceReader, typeof(RenderModelSectionDataBlock));

                Deserializer.PreprocessField = null;
                Deserializer.ProcessTagBlockArray = (Deserializer.ProcessTagBlockArrayDelegate)originalDelegate;
                field.Set(item, new RenderModelSectionDataBlock[] { returnValue });
            }
        }

        private void CustomProcessTagBlockArray(BinaryReader sourceReader, object item, FieldInfo field)
        {
            Type elementType = field.FieldType.GetElementType();
            int elementSize = Marshal.SizeOf(elementType);

            var count = sourceReader.ReadInt32();
            var address = sourceReader.ReadInt32();

            var array = Array.CreateInstance(elementType, count);
            if (count > 0)
            {
                var off = Marshal.OffsetOf(item.GetType(), field.Name);
                var offset = (int)Deserializer.OffsetOf(item.GetType(), field.Name);
                if (item.GetType() == typeof(GlobalGeometryPointDataStruct))
                {
                    var size = Marshal.SizeOf(typeof(GlobalGeometrySectionStruct));
                    offset += size;
                }

                var r = (from resource in this.geometryBlockInfo.resources
                         where resource.primaryLocator == offset
                         select resource).ToArray();
                address = this.geometryBlockInfo.blockOffset + this.geometryBlockInfo.sectionDataSize + 8 + r.First().resourceDataOffset;


                for (int i = 0; i < count; ++i)
                {
                    sourceReader.BaseStream.Position = address + i * elementSize;
                    var element = Deserializer.Deserialize(sourceReader, elementType);
                    if (r.Length > 1)
                    {
                        var fields = (element).GetType().GetFields(
                                                                 BindingFlags.Public |
                                                                 BindingFlags.NonPublic |
                                                                 BindingFlags.Instance);
                        foreach (var elementField in fields)
                            if (elementField.FieldType == typeof(VertexBuffer))
                            {
                                var vertexBufferField = (VertexBuffer)elementField.GetValue(element);
                                sourceReader.BaseStream.Position = this.geometryBlockInfo.blockOffset + this.geometryBlockInfo.sectionDataSize + 8 + r[i + 1].resourceDataOffset;
                                vertexBufferField.Data = sourceReader.ReadBytes(r[i + 1].resourceDataSize);
                                elementField.SetValue(element, vertexBufferField);
                            }
                    }
                    array.SetValue(element, i);
                }
            }
            field.SetValue(item, array);
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 0)]
    public class RenderModelInvalidSectionPairsBlock
    {
        int bits;
    };


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 0)]
    public class RenderModelCompoundNodeBlock
    {

        struct NodeIndices
        {
            byte nodeIndex;
        }
        NodeIndices nodeIndices;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeIndices0;

        struct NodeWeights
        {
            float nodeWeight;
        }
        NodeWeights nodeWeights;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeWeights0;
    };


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 0)]
    public class RenderModelSectionGroupBlock
    {
        DetailLevels detailLevels;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_;
        [TagBlockField]
        RenderModelCompoundNodeBlock[] compoundNodes;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingcompoundNodes0;
        enum DetailLevels : short
        {
            L1SuperLow = 0,
            L2Low = 0,
            L3Medium = 0,
            L4High = 0,
            L5SuperHigh = 0,
            L6Hollywood = 0,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 96, Pack = 0)]
    public partial class RenderModelNodeBlock
    {
        public StringID name;
        public ShortBlockIndex1 parentNode; //   &render_model_node_block},
        public ShortBlockIndex1 firstChildNode; //   &render_model_node_block},
        public ShortBlockIndex1 nextSiblingNode; //   &render_model_node_block},
        public short importNodeIndex;
        public Vector3 defaultTranslation;
        public Quaternion defaultRotation;
        public Vector3 inverseForward;
        public Vector3 inverseLeft;
        public Vector3 inverseUp;
        public Vector3 inversePosition;
        public float inverseScale;
        public float distanceFromParent;
    };


    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 0)]
    public class RenderModelNodeMapBlockOLD
    {
        byte nodeIndex;
    };


    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 0)]
    public class RenderModelMarkerBlock
    {
        public byte regionIndex;
        public byte permutationIndex;
        public byte nodeIndex;
        #region padding
        byte padding; 
        #endregion
        public Vector3 translation;
        public Quaternion rotation;
        public float scale;
    };


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 0)]
    public class RenderModelMarkerGroupBlock
    {
        public StringID name;
        [TagBlockField]
        public RenderModelMarkerBlock[] markers;
    };


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public class GlobalGeometryMaterialPropertyBlock
    {
        Type type;
        short intValue;
        float realValue;
        enum Type : short
        {
            LightmapResolution = 0,
            LightmapPower = 1,
            LightmapHalfLife = 2,
            LightmapDiffuseScale = 3,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 0)]
    public class GlobalGeometryMaterialBlock
    {
        [TagReference("shad")]
        TagReference oldShader;
        [TagReference("shad")]
        TagReference shader;
        [TagBlockField]
        GlobalGeometryMaterialPropertyBlock[] properties;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingproperties0;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddinginvalidName_;
        byte breakableSurfaceIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        byte[] paddinginvalidName_0;
    };


    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 0)]
    public class ErrorReportVerticesBlock
    {
        Vector3 position;

        struct NodeIndices
        {
            byte nodeIndex;
        }
        NodeIndices nodeIndices;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeIndices0;

        struct NodeWeights
        {
            float nodeWeight;
        }
        NodeWeights nodeWeights;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeWeights0;
        Vector4 color;
        float screenSize;
    };


    [StructLayout(LayoutKind.Sequential, Size = 60, Pack = 0)]
    public class ErrorReportVectorsBlock
    {
        Vector3 position;

        struct NodeIndices
        {
            byte nodeIndex;
        }
        NodeIndices nodeIndices;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeIndices0;

        struct NodeWeights
        {
            float nodeWeight;
        }
        NodeWeights nodeWeights;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeWeights0;
        Vector4 color;
        Vector3 normal;
        float screenLength;
    };


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 0)]
    public class ErrorReportLinesBlock
    {

        struct Points
        {
            Vector3 position;

            struct NodeIndices
            {
                byte nodeIndex;
            }
            NodeIndices nodeIndices;
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            byte[] skipnodeIndices0;

            struct NodeWeights
            {
                float nodeWeight;
            }
            NodeWeights nodeWeights;
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            byte[] skipnodeWeights0;
        }
        Points points;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skippoints0;
        Vector4 color;
    };


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 0)]
    public class ErrorReportTrianglesBlock
    {

        struct Points
        {
            Vector3 position;

            struct NodeIndices
            {
                byte nodeIndex;
            }
            NodeIndices nodeIndices;
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            byte[] skipnodeIndices0;

            struct NodeWeights
            {
                float nodeWeight;
            }
            NodeWeights nodeWeights;
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            byte[] skipnodeWeights0;
        }
        Points points;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skippoints0;
        Vector4 color;
    };


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 0)]
    public class ErrorReportQuadsBlock
    {

        struct Points
        {
            Vector3 position;

            struct NodeIndices
            {
                byte nodeIndex;
            }
            NodeIndices nodeIndices;
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            byte[] skipnodeIndices0;

            struct NodeWeights
            {
                float nodeWeight;
            }
            NodeWeights nodeWeights;
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            byte[] skipnodeWeights0;
        }
        Points points;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skippoints0;
        Vector4 color;
    };


    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 0)]
    public class ErrorReportCommentsBlock
    {
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] paddingtext;
        Vector3 position;

        struct NodeIndices
        {
            byte nodeIndex;
        }
        NodeIndices nodeIndices;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeIndices0;

        struct NodeWeights
        {
            float nodeWeight;
        }
        NodeWeights nodeWeights;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] skipnodeWeights0;
        Vector4 color;
    };


    [StructLayout(LayoutKind.Sequential, Size = 608, Pack = 0)]
    public class ErrorReportsBlock
    {
        Type type;
        Flags flags;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] paddingtext;
        String32 sourceFilename;
        int sourceLineNumber;
        [TagBlockField]
        ErrorReportVerticesBlock[] vertices;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingvertices0;
        [TagBlockField]
        ErrorReportVectorsBlock[] vectors;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingvectors0;
        [TagBlockField]
        ErrorReportLinesBlock[] lines;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddinglines0;
        [TagBlockField]
        ErrorReportTrianglesBlock[] triangles;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingtriangles0;
        [TagBlockField]
        ErrorReportQuadsBlock[] quads;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingquads0;
        [TagBlockField]
        ErrorReportCommentsBlock[] comments;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingcomments0;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 380)]
        byte[] paddinginvalidName_;
        int reportKey;
        int nodeIndex;
        Range boundsX;
        Range boundsY;
        Range boundsZ;
        Vector4 color;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
        byte[] paddinginvalidName_0;
        enum Type : short
        {
            Silent = 0,
            Comment = 1,
            Warning = 2,
            Error = 3,
        }
        enum Flags : short
        {
            Rendered = 0,
            TangentSpace = 0,
            Noncritical = 0,
            LightmapLight = 0,
            ReportKeyIsValid = 0,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 676, Pack = 0)]
    public class GlobalErrorReportCategoriesBlock
    {
        String256 name;
        ReportType reportType;
        Flags flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_0;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 404)]
        byte[] paddinginvalidName_1;
        [TagBlockField]
        ErrorReportsBlock[] reports;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingreports0;
        enum ReportType : short
        {
            Silent = 0,
            Comment = 1,
            Warning = 2,
            Error = 3,
        }
        enum Flags : short
        {
            Rendered = 0,
            TangentSpace = 0,
            Noncritical = 0,
            LightmapLight = 0,
            ReportKeyIsValid = 0,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public class PrtSectionInfoBlock
    {
        int sectionIndex;
        int pcaDataOffset;
    };


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 0)]
    public class PrtLodInfoBlock
    {
        int clusterOffset;
        [TagBlockField]
        PrtSectionInfoBlock[] sectionInfo;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingsectionInfo0;
    };


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 0)]
    public class PrtClusterBasisBlock
    {
        float basisData;
    };


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 0)]
    public class PrtRawPcaDataBlock
    {
        float rawPcaData;
    };


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 0)]
    public class PrtVertexBuffersBlock
    {
        VertexBuffer vertexBuffer;
    };


    [StructLayout(LayoutKind.Sequential, Size = 88, Pack = 0)]
    public class PrtInfoBlock
    {
        short sHOrder;
        short numOfClusters;
        short pcaVectorsPerCluster;
        short numberOfRays;
        short numberOfBounces;
        short matIndexForSbsfcScattering;
        float lengthScale;
        short numberOfLodsInModel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_;
        [TagBlockField]
        PrtLodInfoBlock[] lodInfo;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddinglodInfo0;
        [TagBlockField]
        PrtClusterBasisBlock[] clusterBasis;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingclusterBasis0;
        [TagBlockField]
        PrtRawPcaDataBlock[] rawPcaData;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingrawPcaData0;
        [TagBlockField]
        PrtVertexBuffersBlock[] vertexBuffers;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingvertexBuffers0;
        [TagStructField]
        GlobalGeometryBlockInfoStruct geometryBlockInfo;
    };


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public class BspLeafBlock
    {
        short cluster;
        short surfaceReferenceCount;
        int firstSurfaceReferenceIndex;
    };


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public class BspSurfaceReferenceBlock
    {
        short stripIndex;
        short lightmapTriangleIndex;
        int bspNodeIndex;
    };


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 0)]
    public class NodeRenderLeavesBlock
    {
        [TagBlockField]
        BspLeafBlock[] collisionLeaves;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingcollisionLeaves0;
        [TagBlockField]
        BspSurfaceReferenceBlock[] surfaceReferences;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingsurfaceReferences0;
    };


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public class SectionRenderLeavesBlock
    {
        [TagBlockField]
        NodeRenderLeavesBlock[] nodeRenderLeaves;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] paddingnodeRenderLeaves0;
    };
}
