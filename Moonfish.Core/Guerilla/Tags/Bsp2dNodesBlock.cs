using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class Bsp2dNodesblock
    {
        OpenTK.Vector3 plane;
        short leftChild;
        short rightChild;
        internal  Bsp2dNodesblock(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadVector3();
            this.leftChild = binaryReader.ReadInt16();
            this.rightChild = binaryReader.ReadInt16();
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
