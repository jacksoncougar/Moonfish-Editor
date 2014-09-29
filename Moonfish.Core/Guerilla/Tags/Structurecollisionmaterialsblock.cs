using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureCollisionMaterialsBlock
    {
        [TagReference("shad")]
        Moonfish.Tags.TagReference oldShader;
        byte[] invalidName_;
        Moonfish.Tags.ShortBlockIndex1 conveyorSurfaceIndex;
        [TagReference("shad")]
        Moonfish.Tags.TagReference newShader;
        internal  StructureCollisionMaterialsBlock(BinaryReader binaryReader)
        {
            this.oldShader = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.conveyorSurfaceIndex = binaryReader.ReadShortBlockIndex1();
            this.newShader = binaryReader.ReadTagReference();
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
