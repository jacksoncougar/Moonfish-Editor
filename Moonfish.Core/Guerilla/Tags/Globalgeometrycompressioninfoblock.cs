using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalgeometryCompressionInfoBlock
    {
        Moonfish.Model.Range positionBoundsX;
        Moonfish.Model.Range positionBoundsY;
        Moonfish.Model.Range positionBoundsZ;
        Moonfish.Model.Range texcoordBoundsX;
        Moonfish.Model.Range texcoordBoundsY;
        Moonfish.Model.Range secondaryTexcoordBoundsX;
        Moonfish.Model.Range secondaryTexcoordBoundsY;
        internal  GlobalgeometryCompressionInfoBlock(BinaryReader binaryReader)
        {
            this.positionBoundsX = binaryReader.ReadRange();
            this.positionBoundsY = binaryReader.ReadRange();
            this.positionBoundsZ = binaryReader.ReadRange();
            this.texcoordBoundsX = binaryReader.ReadRange();
            this.texcoordBoundsY = binaryReader.ReadRange();
            this.secondaryTexcoordBoundsX = binaryReader.ReadRange();
            this.secondaryTexcoordBoundsY = binaryReader.ReadRange();
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
