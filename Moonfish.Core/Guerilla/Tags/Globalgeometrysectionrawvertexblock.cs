using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalgeometrySectionRawVertexBlock
    {
        OpenTK.Vector3 position;
        NodeIndicesOLD nodeIndicesOLD;
        int nodeIndexOLD;
        internal  GlobalgeometrySectionRawVertexBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndicesOLD = new NodeIndicesOLD(binaryReader);
            this.nodeIndexOLD = binaryReader.ReadInt32();
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
        class NodeIndicesOLD
        {
            int nodeIndexOLD;
            internal  NodeIndicesOLD(BinaryReader binaryReader)
            {
                this.nodeIndexOLD = binaryReader.ReadInt32();
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
    };
}
