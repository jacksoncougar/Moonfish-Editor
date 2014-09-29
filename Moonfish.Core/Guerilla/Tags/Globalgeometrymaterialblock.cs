using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalgeometryMaterialBlock
    {
        [TagReference("shad")]
        Moonfish.Tags.TagReference oldShader;
        [TagReference("shad")]
        Moonfish.Tags.TagReference shader;
        GlobalgeometryMaterialPropertyBlock[] properties;
        byte[] invalidName_;
        byte breakableSurfaceIndex;
        byte[] invalidName_0;
        internal  GlobalgeometryMaterialBlock(BinaryReader binaryReader)
        {
            this.oldShader = binaryReader.ReadTagReference();
            this.shader = binaryReader.ReadTagReference();
            this.properties = ReadGlobalgeometryMaterialPropertyBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.breakableSurfaceIndex = binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(3);
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
        GlobalgeometryMaterialPropertyBlock[] ReadGlobalgeometryMaterialPropertyBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalgeometryMaterialPropertyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalgeometryMaterialPropertyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalgeometryMaterialPropertyBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
