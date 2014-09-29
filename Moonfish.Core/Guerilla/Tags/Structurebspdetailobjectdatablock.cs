using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspDetailObjectdatablock
    {
        GlobalDetailObjectCellsBlock[] cells;
        GlobalDetailObjectBlock[] instances;
        GlobalDetailObjectCountsBlock[] counts;
        GlobalZReferenceVectorBlock[] zReferenceVectors;
        byte[] invalidName_;
        byte[] invalidName_0;
        internal  StructureBspDetailObjectdatablock(BinaryReader binaryReader)
        {
            this.cells = ReadGlobalDetailObjectCellsBlockArray(binaryReader);
            this.instances = ReadGlobalDetailObjectBlockArray(binaryReader);
            this.counts = ReadGlobalDetailObjectCountsBlockArray(binaryReader);
            this.zReferenceVectors = ReadGlobalZReferenceVectorBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.invalidName_0 = binaryReader.ReadBytes(3);
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
        GlobalDetailObjectCellsBlock[] ReadGlobalDetailObjectCellsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDetailObjectCellsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDetailObjectCellsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDetailObjectCellsBlock(binaryReader);
                }
            }
            return array;
        }
        GlobalDetailObjectBlock[] ReadGlobalDetailObjectBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDetailObjectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDetailObjectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDetailObjectBlock(binaryReader);
                }
            }
            return array;
        }
        GlobalDetailObjectCountsBlock[] ReadGlobalDetailObjectCountsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDetailObjectCountsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDetailObjectCountsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDetailObjectCountsBlock(binaryReader);
                }
            }
            return array;
        }
        GlobalZReferenceVectorBlock[] ReadGlobalZReferenceVectorBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalZReferenceVectorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalZReferenceVectorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalZReferenceVectorBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
