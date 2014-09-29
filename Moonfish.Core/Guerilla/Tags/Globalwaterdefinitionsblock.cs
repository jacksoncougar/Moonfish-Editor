using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalWaterDefinitionsBlock
    {
        [TagReference("shad")]
        Moonfish.Tags.TagReference shader;
        WaterGeometrySectionBlock[] section;
        GlobalgeometryBlockInfoStructblock geometryBlockInfo;
        Moonfish.Tags.ColorR8G8B8 sunSpotColor;
        Moonfish.Tags.ColorR8G8B8 reflectionTint;
        Moonfish.Tags.ColorR8G8B8 refractionTint;
        Moonfish.Tags.ColorR8G8B8 horizonColor;
        float sunSpecularPower;
        float reflectionBumpScale;
        float refractionBumpScale;
        float fresnelScale;
        float sunDirHeading;
        float sunDirPitch;
        float fOV;
        float aspect;
        float height;
        float farz;
        float rotateOffset;
        OpenTK.Vector2 center;
        OpenTK.Vector2 extents;
        float fogNear;
        float fogFar;
        float dynamicHeightBias;
        internal  GlobalWaterDefinitionsBlock(BinaryReader binaryReader)
        {
            this.shader = binaryReader.ReadTagReference();
            this.section = ReadWaterGeometrySectionBlockArray(binaryReader);
            this.geometryBlockInfo = new GlobalgeometryBlockInfoStructblock(binaryReader);
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
        WaterGeometrySectionBlock[] ReadWaterGeometrySectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WaterGeometrySectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WaterGeometrySectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WaterGeometrySectionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
