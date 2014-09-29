using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class DecalVerticesBlock
    {
        OpenTK.Vector3 position;
        OpenTK.Vector2 texcoord0;
        OpenTK.Vector2 texcoord1;
        Moonfish.Tags.RGBColor color;
        internal  DecalVerticesBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.texcoord0 = binaryReader.ReadVector2();
            this.texcoord1 = binaryReader.ReadVector2();
            this.color = binaryReader.ReadRGBColor();
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
    };
}
