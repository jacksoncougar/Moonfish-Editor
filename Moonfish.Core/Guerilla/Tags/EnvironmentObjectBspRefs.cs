using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class EnvironmentObjectBspRefs
    {
        int bspReference;
        int firstSector;
        int lastSector;
        short nodeIndex;
        byte[] invalidName_;
        internal  EnvironmentObjectBspRefs(BinaryReader binaryReader)
        {
            this.bspReference = binaryReader.ReadInt32();
            this.firstSector = binaryReader.ReadInt32();
            this.lastSector = binaryReader.ReadInt32();
            this.nodeIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
