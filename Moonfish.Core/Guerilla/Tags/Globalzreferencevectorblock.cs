using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalZReferenceVectorBlock
    {
        float invalidName_;
        float invalidName_0;
        float invalidName_1;
        float invalidName_2;
        internal  GlobalZReferenceVectorBlock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadSingle();
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
