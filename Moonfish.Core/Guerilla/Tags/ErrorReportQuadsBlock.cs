using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class ErrorReportQuadsBlock
    {
        Points points;
        OpenTK.Vector3 position;
        NodeIndices nodeIndices;
        byte nodeIndex;
        internal  ErrorReportQuadsBlock(BinaryReader binaryReader)
        {
            this.points = new Points(binaryReader);
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices(binaryReader);
            this.nodeIndex = binaryReader.ReadByte();
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
        class Points
        {
            OpenTK.Vector3 position;
            NodeIndices nodeIndices;
            byte nodeIndex;
            internal  Points(BinaryReader binaryReader)
            {
                this.position = binaryReader.ReadVector3();
                this.nodeIndices = new NodeIndices(binaryReader);
                this.nodeIndex = binaryReader.ReadByte();
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
            class NodeIndices
            {
                byte nodeIndex;
                internal  NodeIndices(BinaryReader binaryReader)
                {
                    this.nodeIndex = binaryReader.ReadByte();
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
        class NodeIndices
        {
            byte nodeIndex;
            internal  NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
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
