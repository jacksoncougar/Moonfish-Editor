using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class DecoratorPlacementBlock
    {
        int internalData1;
        int compressedPosition;
        Moonfish.Tags.RGBColor tintColor;
        Moonfish.Tags.RGBColor lightmapColor;
        int compressedLightDirection;
        int compressedLight2Direction;
        internal  DecoratorPlacementBlock(BinaryReader binaryReader)
        {
            this.internalData1 = binaryReader.ReadInt32();
            this.compressedPosition = binaryReader.ReadInt32();
            this.tintColor = binaryReader.ReadRGBColor();
            this.lightmapColor = binaryReader.ReadRGBColor();
            this.compressedLightDirection = binaryReader.ReadInt32();
            this.compressedLight2Direction = binaryReader.ReadInt32();
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
