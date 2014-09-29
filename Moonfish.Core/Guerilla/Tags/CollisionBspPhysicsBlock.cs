using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class CollisionBspPhysicsblock
    {
        byte[] invalidName_;
        short size;
        short count;
        byte[] invalidName_0;
        byte[] invalidName_1;
        byte[] invalidName_2;
        byte[] invalidName_3;
        byte[] invalidName_4;
        short size0;
        short count0;
        byte[] invalidName_5;
        byte[] invalidName_6;
        byte[] invalidName_7;
        short size1;
        short count1;
        byte[] invalidName_8;
        byte[] invalidName_9;
        byte[] moppCodeData;
        byte[] padding;
        internal  CollisionBspPhysicsblock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.size = binaryReader.ReadInt16();
            this.count = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.invalidName_2 = binaryReader.ReadBytes(32);
            this.invalidName_3 = binaryReader.ReadBytes(16);
            this.invalidName_4 = binaryReader.ReadBytes(4);
            this.size0 = binaryReader.ReadInt16();
            this.count0 = binaryReader.ReadInt16();
            this.invalidName_5 = binaryReader.ReadBytes(4);
            this.invalidName_6 = binaryReader.ReadBytes(4);
            this.invalidName_7 = binaryReader.ReadBytes(4);
            this.size1 = binaryReader.ReadInt16();
            this.count1 = binaryReader.ReadInt16();
            this.invalidName_8 = binaryReader.ReadBytes(4);
            this.invalidName_9 = binaryReader.ReadBytes(8);
            this.moppCodeData = ReadData(binaryReader);
            this.padding = binaryReader.ReadBytes(4);
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
