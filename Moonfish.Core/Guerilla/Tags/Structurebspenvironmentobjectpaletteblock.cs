using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspEnvironmentObjectPaletteblock
    {
        [TagReference("scen")]
        Moonfish.Tags.TagReference definition;
        [TagReference("mode")]
        Moonfish.Tags.TagReference model;
        byte[] invalidName_;
        internal  StructureBspEnvironmentObjectPaletteblock(BinaryReader binaryReader)
        {
            this.definition = binaryReader.ReadTagReference();
            this.model = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(4);
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
