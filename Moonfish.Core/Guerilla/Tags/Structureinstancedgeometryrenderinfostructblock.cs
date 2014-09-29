using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureInstancedGeometryRenderinfostructBlock
    {
        GlobalgeometrySectionInfostructBlock sectionInfo;
        GlobalgeometryBlockInfoStructblock geometryBlockInfo;
        StructureBspClusterDatablockNew[] renderData;
        GlobalgeometrySectionstripIndexBlock[] indexReorderTable;
        internal  StructureInstancedGeometryRenderinfostructBlock(BinaryReader binaryReader)
        {
            this.sectionInfo = new GlobalgeometrySectionInfostructBlock(binaryReader);
            this.geometryBlockInfo = new GlobalgeometryBlockInfoStructblock(binaryReader);
            this.renderData = ReadStructureBspClusterDatablockNewArray(binaryReader);
            this.indexReorderTable = ReadGlobalgeometrySectionstripIndexBlockArray(binaryReader);
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
        StructureBspClusterDatablockNew[] ReadStructureBspClusterDatablockNewArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterDatablockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterDatablockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterDatablockNew(binaryReader);
                }
            }
            return array;
        }
        GlobalgeometrySectionstripIndexBlock[] ReadGlobalgeometrySectionstripIndexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalgeometrySectionstripIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalgeometrySectionstripIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalgeometrySectionstripIndexBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
