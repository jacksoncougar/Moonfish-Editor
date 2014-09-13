using Moonfish.Model;
using OpenTK;
using System;
using System.Runtime.InteropServices;

namespace Moonfish.Tags
{
    [StructLayout(LayoutKind.Sequential, Size = 96, Pack = 0)]
    public class ShaderTemplateBlock
    {
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] paddingdocumentation;
        StringID defaultMaterialName;
        //FIELD_EXPLAINATION("FLAGS", "* Force Active Camo: Should be used with cautuion, as this causes a backbuffer copy when this shader is rendered.<lb>* Water: ???.<lb>* Foliage: Used with lightmapped foliage (two-sided lighting) shaders. It affects importing but not rendering."),
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_;
        Flags flags;
        [TagBlockField]
        ShaderTemplatePropertyBlock[] properties;
        [TagBlockField]
        ShaderTemplateCategoryBlock[] categories;
        //FIELD_EXPLAINATION("LIGHT RESPONSE", "Not used anymore."),
        [TagReference("slit")]
        TagReference lightResponse;
        [TagBlockField]
        ShaderTemplateLevelOfDetailBlock[] lods;
        [TagBlockField]
        ShaderTemplateRuntimeExternalLightResponseIndexBlock[] eMPTYSTRING;
        [TagBlockField]
        ShaderTemplateRuntimeExternalLightResponseIndexBlock[] eMPTYSTRING0;
        //FIELD_EXPLAINATION("RECURSIVE RENDERING", "Really cool stuff."),
        [TagReference("shad")]
        TagReference aux1Shader;
        Aux1Layer aux1Layer;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_0;
        [TagReference("shad")]
        TagReference aux2Shader;
        Aux2Layer aux2Layer;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_1;
        [TagBlockField]
        ShaderTemplatePostprocessDefinitionNewBlock[] postprocessDefinition;
        [Flags]
        enum Flags : short
        {
            ForceActiveCamo = 1,
            Water = 2,
            Foliage = 4,
            HideStandardParameters = 8,
        }
        enum Aux1Layer : short
        {
            Texaccum = 0,
            EnvironmentMap = 1,
            SelfIllumination = 2,
            Overlay = 3,
            Transparent = 4,
            LightmapIndirect = 5,
            Diffuse = 6,
            Specular = 7,
            ShadowGenerate = 8,
            ShadowApply = 9,
            Boom = 10,
            Fog = 11,
            ShPrt = 12,
            ActiveCamo = 13,
            WaterEdgeBlend = 14,
            Decal = 15,
            ActiveCamoStencilModulate = 16,
            Hologram = 17,
            LightAlbedo = 18,
        }
        enum Aux2Layer : short
        {
            Texaccum = 0,
            EnvironmentMap = 1,
            SelfIllumination = 2,
            Overlay = 3,
            Transparent = 4,
            LightmapIndirect = 5,
            Diffuse = 6,
            Specular = 7,
            ShadowGenerate = 8,
            ShadowApply = 9,
            Boom = 10,
            Fog = 11,
            ShPrt = 12,
            ActiveCamo = 13,
            WaterEdgeBlend = 14,
            Decal = 15,
            ActiveCamoStencilModulate = 16,
            Hologram = 17,
            LightAlbedo = 18,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public class ShaderTemplatePropertyBlock
    {
        Property property;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_;
        StringID parameterName;
        enum Property : short
        {
            Unused = 0,
            DiffuseMap = 1,
            LightmapEmissiveMap = 2,
            LightmapEmissiveColor = 3,
            LightmapEmissivePower = 4,
            LightmapResolutionScale = 5,
            LightmapHalfLife = 6,
            LightmapDiffuseScale = 7,
            LightmapAlphaTestMap = 8,
            LightmapTranslucentMap = 9,
            LightmapTranslucentColor = 10,
            LightmapTranslucentAlpha = 11,
            ActiveCamoMap = 12,
            LightmapFoliageScale = 13,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 0)]
    public class ShaderTemplateParameterBlock
    {
        StringID name;
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] paddingexplanation;
        Type type;
        Flags flags;
        [TagReference("bitm")]
        TagReference defaultBitmap;
        float defaultConstValue;
        ColorR8G8B8 defaultConstColor;
        BitmapType bitmapType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_;
        BitmapAnimationFlags bitmapAnimationFlags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_0;
        float bitmapScale;
        enum Type : short
        {
            Bitmap = 0,
            Value = 1,
            Color = 2,
            Switch = 3,
        }
        [Flags]
        enum Flags : short
        {
            Animated = 1,
            HideBitmapReference = 2,
        }
        enum BitmapType : short
        {
            invalidName_2D = 0,
            invalidName_3D = 1,
            CubeMap = 2,
        }
        [Flags]
        enum BitmapAnimationFlags : short
        {
            ScaleUniform = 1,
            Scale = 2,
            Translation = 4,
            Rotation = 8,
            Index = 16,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 0)]
    public class ShaderTemplateCategoryBlock
    {
        StringID name;
        [TagBlockField]
        ShaderTemplateParameterBlock[] parameters;
    };


    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 0)]
    public class ShaderTemplatePassReferenceBlock
    {
        Layer layer;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        byte[] paddinginvalidName_;
        [TagReference("spas")]
        TagReference pass;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        byte[] paddinginvalidName_0;
        enum Layer : short
        {
            Texaccum = 0,
            EnvironmentMap = 1,
            SelfIllumination = 2,
            Overlay = 3,
            Transparent = 4,
            LightmapIndirect = 5,
            Diffuse = 6,
            Specular = 7,
            ShadowGenerate = 8,
            ShadowApply = 9,
            Boom = 10,
            Fog = 11,
            ShPrt = 12,
            ActiveCamo = 13,
            WaterEdgeBlend = 14,
            Decal = 15,
            ActiveCamoStencilModulate = 16,
            Hologram = 17,
            LightAlbedo = 18,
        }
    };


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 0)]
    public class ShaderTemplateLevelOfDetailBlock
    {
        float projectedDiameterPixels;
        [TagBlockField]
        ShaderTemplatePassReferenceBlock[] pass;
    };


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 0)]
    public class ShaderTemplateRuntimeExternalLightResponseIndexBlock
    {
        int eMPTYSTRING;
    };


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 0)]
    public class TagBlockIndexStruct
    {
        short blockIndexData;
    };


    [StructLayout(LayoutKind.Sequential, Size = 10, Pack = 0)]
    public class ShaderTemplatePostprocessLevelOfDetailNewBlock
    {
        [TagStructField]
        TagBlockIndexStruct layers;
        int availableLayers;
        float projectedHeightPercentage;
    };


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 0)]
    public class TagBlockIndexBlock
    {
        [TagStructField]
        TagBlockIndexStruct indices;
    };


    [StructLayout(LayoutKind.Sequential, Size = 10, Pack = 0)]
    public class ShaderTemplatePostprocessPassNewBlock
    {
        [TagReference("spas")]
        TagReference pass;
        [TagStructField]
        TagBlockIndexStruct implementations;
    };


    [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 0)]
    public class ShaderTemplatePostprocessImplementationNewBlock
    {
        [TagStructField]
        TagBlockIndexStruct bitmaps;
        [TagStructField]
        TagBlockIndexStruct pixelConstants;
        [TagStructField]
        TagBlockIndexStruct vertexConstants;
    };


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 0)]
    public class ShaderTemplatePostprocessRemappingNewBlock
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        byte[] skipinvalidName_;
        byte sourceIndex;
    };


    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 0)]
    public class ShaderTemplatePostprocessDefinitionNewBlock
    {
        [TagBlockField]
        ShaderTemplatePostprocessLevelOfDetailNewBlock[] levelsOfDetail;
        [TagBlockField]
        TagBlockIndexBlock[] layers;
        [TagBlockField]
        ShaderTemplatePostprocessPassNewBlock[] passes;
        [TagBlockField]
        ShaderTemplatePostprocessImplementationNewBlock[] implementations;
        [TagBlockField]
        ShaderTemplatePostprocessRemappingNewBlock[] remappings;
    };
}
