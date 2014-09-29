using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class DecoratorProjecteddecalBlock
    {
        Moonfish.Tags.ByteBlockIndex1 decoratorSet;
        byte decoratorClass;
        byte decoratorPermutation;
        byte spriteIndex;
        OpenTK.Vector3 position;
        OpenTK.Vector3 left;
        OpenTK.Vector3 up;
        OpenTK.Vector3 extents;
        OpenTK.Vector3 previousPosition;
        internal  DecoratorProjecteddecalBlock(BinaryReader binaryReader)
        {
            this.decoratorSet = binaryReader.ReadByteBlockIndex1();
            this.decoratorClass = binaryReader.ReadByte();
            this.decoratorPermutation = binaryReader.ReadByte();
            this.spriteIndex = binaryReader.ReadByte();
            this.position = binaryReader.ReadVector3();
            this.left = binaryReader.ReadVector3();
            this.up = binaryReader.ReadVector3();
            this.extents = binaryReader.ReadVector3();
            this.previousPosition = binaryReader.ReadVector3();
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
