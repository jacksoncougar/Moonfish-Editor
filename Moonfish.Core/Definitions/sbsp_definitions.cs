using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Definitions
{
    class DSurfaceReference : IDefinition
    {
        short TriangleStripIndex;
        short LightmapTriangleIndex;
        int BSPNodeIndex;

        byte[] IDefinition.ToArray()
        {
            MemoryStream buffer = new MemoryStream((this as IDefinition).Size);
            BinaryWriter binary_writer = new BinaryWriter(buffer);
            binary_writer.Write(TriangleStripIndex);
            binary_writer.Write(LightmapTriangleIndex);
            binary_writer.Write(BSPNodeIndex);
            binary_writer.Flush();
            return buffer.ToArray();
        }

        void IDefinition.FromArray(byte[] buffer)
        {
            var binary_reader = new BinaryReader(new MemoryStream(buffer));
            TriangleStripIndex = binary_reader.ReadInt16();
            LightmapTriangleIndex = binary_reader.ReadInt16();
            BSPNodeIndex = binary_reader.ReadInt32();
        }

        int IDefinition.Size
        {
            get { return 8; }
        }
    }
}
