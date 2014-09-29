using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class DecoratorPlacementdefinitionBlock
    {
        OpenTK.Vector3 gridOrigin;
        int cellCountPerDimension;
        DecoratorCacheBlockblock[] cacheBlocks;
        DecoratorGroupBlock[] groups;
        DecoratorCellcollectionBlock[] cells;
        DecoratorProjecteddecalBlock[] decals;
        internal  DecoratorPlacementdefinitionBlock(BinaryReader binaryReader)
        {
            this.gridOrigin = binaryReader.ReadVector3();
            this.cellCountPerDimension = binaryReader.ReadInt32();
            this.cacheBlocks = ReadDecoratorCacheBlockblockArray(binaryReader);
            this.groups = ReadDecoratorGroupBlockArray(binaryReader);
            this.cells = ReadDecoratorCellcollectionBlockArray(binaryReader);
            this.decals = ReadDecoratorProjecteddecalBlockArray(binaryReader);
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
        DecoratorCacheBlockblock[] ReadDecoratorCacheBlockblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorCacheBlockblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorCacheBlockblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorCacheBlockblock(binaryReader);
                }
            }
            return array;
        }
        DecoratorGroupBlock[] ReadDecoratorGroupBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorGroupBlock(binaryReader);
                }
            }
            return array;
        }
        DecoratorCellcollectionBlock[] ReadDecoratorCellcollectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorCellcollectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorCellcollectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorCellcollectionBlock(binaryReader);
                }
            }
            return array;
        }
        DecoratorProjecteddecalBlock[] ReadDecoratorProjecteddecalBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorProjecteddecalBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorProjecteddecalBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorProjecteddecalBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
