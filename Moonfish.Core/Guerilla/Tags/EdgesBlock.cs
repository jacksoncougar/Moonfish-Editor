using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class EdgesBlock
    {
        short startVertex;
        short endVertex;
        short forwardEdge;
        short reverseEdge;
        short leftSurface;
        short rightSurface;
        internal  EdgesBlock(BinaryReader binaryReader)
        {
            this.startVertex = binaryReader.ReadInt16();
            this.endVertex = binaryReader.ReadInt16();
            this.forwardEdge = binaryReader.ReadInt16();
            this.reverseEdge = binaryReader.ReadInt16();
            this.leftSurface = binaryReader.ReadInt16();
            this.rightSurface = binaryReader.ReadInt16();
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
