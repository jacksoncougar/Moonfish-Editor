using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalDetailObjectBlock
    {
        byte invalidName_;
        byte invalidName_0;
        byte invalidName_1;
        byte invalidName_2;
        short invalidName_3;
        internal  GlobalDetailObjectBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadByte();
            this.invalidName_1 = binaryReader.ReadByte();
            this.invalidName_2 = binaryReader.ReadByte();
            this.invalidName_3 = binaryReader.ReadInt16();
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
