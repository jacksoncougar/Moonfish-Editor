using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalDetailObjectCellsBlock
    {
        short invalidName_;
        short invalidName_0;
        short invalidName_1;
        short invalidName_2;
        int invalidName_3;
        int invalidName_4;
        int invalidName_5;
        byte[] invalidName_6;
        internal  GlobalDetailObjectCellsBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadInt32();
            this.invalidName_4 = binaryReader.ReadInt32();
            this.invalidName_5 = binaryReader.ReadInt32();
            this.invalidName_6 = binaryReader.ReadBytes(12);
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
