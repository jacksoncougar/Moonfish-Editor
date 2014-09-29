using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspsoundEnvironmentPaletteblock
    {
        Moonfish.Tags.String32 name;
        [TagReference("snde")]
        Moonfish.Tags.TagReference soundEnvironment;
        float cutoffDistance;
        float interpolationSpeed1Sec;
        byte[] invalidName_;
        internal  StructureBspsoundEnvironmentPaletteblock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.soundEnvironment = binaryReader.ReadTagReference();
            this.cutoffDistance = binaryReader.ReadSingle();
            this.interpolationSpeed1Sec = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(24);
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
