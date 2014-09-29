using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalgeometrySectionstructBlock
    {
        GlobalgeometryPartBlockNew[] parts;
        GlobalSubpartsBlock[] subparts;
        GlobalVisibilityBoundsblock[] visibilityBounds;
        GlobalgeometrySectionRawVertexBlock[] rawVertices;
        GlobalgeometrySectionstripIndexBlock[] stripIndices;
        byte[] visibilityMoppCode;
        GlobalgeometrySectionstripIndexBlock[] moppReorderTable;
        GlobalgeometrySectionVertexBufferblock[] vertexBuffers;
        byte[] invalidName_;
        internal  GlobalgeometrySectionstructBlock(BinaryReader binaryReader)
        {
            this.parts = ReadGlobalgeometryPartBlockNewArray(binaryReader);
            this.subparts = ReadGlobalSubpartsBlockArray(binaryReader);
            this.visibilityBounds = ReadGlobalVisibilityBoundsblockArray(binaryReader);
            this.rawVertices = ReadGlobalgeometrySectionRawVertexBlockArray(binaryReader);
            this.stripIndices = ReadGlobalgeometrySectionstripIndexBlockArray(binaryReader);
            this.visibilityMoppCode = ReadData(binaryReader);
            this.moppReorderTable = ReadGlobalgeometrySectionstripIndexBlockArray(binaryReader);
            this.vertexBuffers = ReadGlobalgeometrySectionVertexBufferblockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
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
        GlobalgeometryPartBlockNew[] ReadGlobalgeometryPartBlockNewArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalgeometryPartBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalgeometryPartBlockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalgeometryPartBlockNew(binaryReader);
                }
            }
            return array;
        }
        GlobalSubpartsBlock[] ReadGlobalSubpartsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalSubpartsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalSubpartsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalSubpartsBlock(binaryReader);
                }
            }
            return array;
        }
        GlobalVisibilityBoundsblock[] ReadGlobalVisibilityBoundsblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalVisibilityBoundsblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalVisibilityBoundsblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalVisibilityBoundsblock(binaryReader);
                }
            }
            return array;
        }
        GlobalgeometrySectionRawVertexBlock[] ReadGlobalgeometrySectionRawVertexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalgeometrySectionRawVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalgeometrySectionRawVertexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalgeometrySectionRawVertexBlock(binaryReader);
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
        GlobalgeometrySectionVertexBufferblock[] ReadGlobalgeometrySectionVertexBufferblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalgeometrySectionVertexBufferblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalgeometrySectionVertexBufferblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalgeometrySectionVertexBufferblock(binaryReader);
                }
            }
            return array;
        }
    };
}
