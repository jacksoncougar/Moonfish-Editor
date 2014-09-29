using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class DecoratorCacheBlockblock
    {
        GlobalgeometryBlockInfoStructblock geometryBlockInfo;
        DecoratorCacheBlockdatablock[] cacheBlockData;
        internal  DecoratorCacheBlockblock(BinaryReader binaryReader)
        {
            this.geometryBlockInfo = new GlobalgeometryBlockInfoStructblock(binaryReader);
            this.cacheBlockData = ReadDecoratorCacheBlockdatablockArray(binaryReader);
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
        DecoratorCacheBlockdatablock[] ReadDecoratorCacheBlockdatablockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorCacheBlockdatablock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorCacheBlockdatablock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorCacheBlockdatablock(binaryReader);
                }
            }
            return array;
        }
    };
}
