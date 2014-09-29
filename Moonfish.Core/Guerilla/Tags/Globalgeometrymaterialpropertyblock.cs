using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalgeometryMaterialPropertyBlock
    {
        Type type;
        short intValue;
        float realValue;
        internal  GlobalgeometryMaterialPropertyBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.intValue = binaryReader.ReadInt16();
            this.realValue = binaryReader.ReadSingle();
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
        internal enum Type : short
        {
            LightmapResolution = 0,
            LightmapPower = 0,
            LightmapHalfLife = 0,
            LightmapDiffuseScale = 0,
        };
    };
}
