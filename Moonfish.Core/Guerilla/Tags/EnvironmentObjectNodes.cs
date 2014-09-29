using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class EnvironmentObjectNodes
    {
        short referenceFrameIndex;
        byte projectionAxis;
        ProjectionSign projectionSign;
        internal  EnvironmentObjectNodes(BinaryReader binaryReader)
        {
            this.referenceFrameIndex = binaryReader.ReadInt16();
            this.projectionAxis = binaryReader.ReadByte();
            this.projectionSign = (ProjectionSign)binaryReader.ReadByte();
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
        internal enum ProjectionSign : byte
        {
            ProjectionSign = 1,
        };
    };
}
