using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 71)]
    public  partial class ErrorReportTrianglesBlock : ErrorReportTrianglesBlockBase
    {
        public  ErrorReportTrianglesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 71)]
    public class ErrorReportTrianglesBlockBase
    {
        internal Points points;
        internal OpenTK.Vector3 position;
        internal NodeIndices nodeIndices;
        internal byte nodeIndex;
        internal  ErrorReportTrianglesBlockBase(BinaryReader binaryReader)
        {
            this.points = new Points(binaryReader);
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices(binaryReader);
            this.nodeIndex = binaryReader.ReadByte();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        public class Points
        {
            internal OpenTK.Vector3 position;
            internal NodeIndices nodeIndices;
            internal byte nodeIndex;
            internal  Points(BinaryReader binaryReader)
            {
                this.position = binaryReader.ReadVector3();
                this.nodeIndices = new NodeIndices(binaryReader);
                this.nodeIndex = binaryReader.ReadByte();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
            public class NodeIndices
            {
                internal byte nodeIndex;
                internal  NodeIndices(BinaryReader binaryReader)
                {
                    this.nodeIndex = binaryReader.ReadByte();
                }
                internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        public class NodeIndices
        {
            internal byte nodeIndex;
            internal  NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
