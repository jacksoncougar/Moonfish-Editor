using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspFakeLightprobesblock
    {
        ScenarioObjectIdstructBlock objectIdentifier;
        RenderLightingStructBlock renderLighting;
        internal  StructureBspFakeLightprobesblock(BinaryReader binaryReader)
        {
            this.objectIdentifier = new ScenarioObjectIdstructBlock(binaryReader);
            this.renderLighting = new RenderLightingStructBlock(binaryReader);
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
