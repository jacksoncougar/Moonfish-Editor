using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalTagImportinfoBlock
    {
        int build;
        Moonfish.Tags.String256 version;
        Moonfish.Tags.String32 importDate;
        Moonfish.Tags.String32 culprit;
        byte[] invalidName_;
        Moonfish.Tags.String32 importTime;
        byte[] invalidName_0;
        TagImportFileBlock[] files;
        byte[] invalidName_1;
        internal  GlobalTagImportinfoBlock(BinaryReader binaryReader)
        {
            this.build = binaryReader.ReadInt32();
            this.version = binaryReader.ReadString256();
            this.importDate = binaryReader.ReadString32();
            this.culprit = binaryReader.ReadString32();
            this.invalidName_ = binaryReader.ReadBytes(96);
            this.importTime = binaryReader.ReadString32();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.files = ReadTagImportFileBlockArray(binaryReader);
            this.invalidName_1 = binaryReader.ReadBytes(128);
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
        TagImportFileBlock[] ReadTagImportFileBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TagImportFileBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TagImportFileBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TagImportFileBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
