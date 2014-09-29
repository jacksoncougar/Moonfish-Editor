using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class TransparentPlanesBlock
    {
        short sectionIndex;
        short partIndex;
        OpenTK.Vector4 plane;
        internal  TransparentPlanesBlock(BinaryReader binaryReader)
        {
            this.sectionIndex = binaryReader.ReadInt16();
            this.partIndex = binaryReader.ReadInt16();
            this.plane = binaryReader.ReadVector4();
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
