using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspPrecomputedLightingblock
    {
        int index;
        LightType lightType;
        byte attachmentIndex;
        byte objectType;
        VisibilityStructBlock visibility;
        internal  StructureBspPrecomputedLightingblock(BinaryReader binaryReader)
        {
            this.index = binaryReader.ReadInt32();
            this.lightType = (LightType)binaryReader.ReadInt16();
            this.attachmentIndex = binaryReader.ReadByte();
            this.objectType = binaryReader.ReadByte();
            this.visibility = new VisibilityStructBlock(binaryReader);
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
        internal enum LightType : short
        {
            FreeStanding = 0,
            AttachedToEditorObject = 0,
            AttachedToStructureObject = 0,
        };
    };
}
