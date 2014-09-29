using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspWeatherPaletteblock
    {
        Moonfish.Tags.String32 name;
        [TagReference("weat")]
        Moonfish.Tags.TagReference weatherSystem;
        byte[] invalidName_;
        byte[] invalidName_0;
        byte[] invalidName_1;
        [TagReference("wind")]
        Moonfish.Tags.TagReference wind;
        OpenTK.Vector3 windDirection;
        float windMagnitude;
        byte[] invalidName_2;
        Moonfish.Tags.String32 windScaleFunction;
        internal  StructureBspWeatherPaletteblock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.weatherSystem = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(32);
            this.wind = binaryReader.ReadTagReference();
            this.windDirection = binaryReader.ReadVector3();
            this.windMagnitude = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.windScaleFunction = binaryReader.ReadString32();
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
