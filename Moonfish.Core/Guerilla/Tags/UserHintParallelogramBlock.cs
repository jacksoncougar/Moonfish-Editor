using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class UserHintParallelogramBlock
    {
        Flags flags;
        OpenTK.Vector3 point0;
        short referenceFrame;
        byte[] invalidName_;
        OpenTK.Vector3 point1;
        short referenceFrame0;
        byte[] invalidName_0;
        OpenTK.Vector3 point2;
        short referenceFrame1;
        byte[] invalidName_1;
        OpenTK.Vector3 point3;
        short referenceFrame2;
        byte[] invalidName_2;
        internal  UserHintParallelogramBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.point0 = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.point1 = binaryReader.ReadVector3();
            this.referenceFrame0 = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.point2 = binaryReader.ReadVector3();
            this.referenceFrame1 = binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.point3 = binaryReader.ReadVector3();
            this.referenceFrame2 = binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
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
        internal enum Flags : int
        {
            Bidirectional = 1,
            Closed = 2,
        };
    };
}
