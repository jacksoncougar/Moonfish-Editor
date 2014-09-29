using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspWeatherPolyhedronblock
    {
        OpenTK.Vector3 boundingSphereCenter;
        float boundingSphereRadius;
        StructureBspWeatherPolyhedronplaneblock[] planes;
        internal  StructureBspWeatherPolyhedronblock(BinaryReader binaryReader)
        {
            this.boundingSphereCenter = binaryReader.ReadVector3();
            this.boundingSphereRadius = binaryReader.ReadSingle();
            this.planes = ReadStructureBspWeatherPolyhedronplaneblockArray(binaryReader);
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
        StructureBspWeatherPolyhedronplaneblock[] ReadStructureBspWeatherPolyhedronplaneblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspWeatherPolyhedronplaneblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspWeatherPolyhedronplaneblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspWeatherPolyhedronplaneblock(binaryReader);
                }
            }
            return array;
        }
    };
}
