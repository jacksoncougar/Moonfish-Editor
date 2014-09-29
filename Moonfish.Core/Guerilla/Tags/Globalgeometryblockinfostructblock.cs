using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalgeometryBlockInfoStructblock
    {
        int blockOffset;
        int blockSize;
        int sectionDataSize;
        int resourceDataSize;
        GlobalgeometryBlockResourceblock[] resources;
        byte[] invalidName_;
        short ownerTagSectionOffset;
        byte[] invalidName_0;
        byte[] invalidName_1;
        internal  GlobalgeometryBlockInfoStructblock(BinaryReader binaryReader)
        {
            this.blockOffset = binaryReader.ReadInt32();
            this.blockSize = binaryReader.ReadInt32();
            this.sectionDataSize = binaryReader.ReadInt32();
            this.resourceDataSize = binaryReader.ReadInt32();
            this.resources = ReadGlobalgeometryBlockResourceblockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.ownerTagSectionOffset = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(4);
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
        GlobalgeometryBlockResourceblock[] ReadGlobalgeometryBlockResourceblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalgeometryBlockResourceblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalgeometryBlockResourceblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalgeometryBlockResourceblock(binaryReader);
                }
            }
            return array;
        }
    };
}
