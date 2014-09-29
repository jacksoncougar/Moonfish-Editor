using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class DecoratorGroupBlock
    {
        Moonfish.Tags.ByteBlockIndex1 decoratorSet;
        DecoratorType decoratorType;
        byte shaderIndex;
        byte compressedRadius;
        short cluster;
        Moonfish.Tags.ShortBlockIndex1 cacheBlock;
        short decoratorStartIndex;
        short decoratorCount;
        short vertexStartOffset;
        short vertexCount;
        short indexStartOffset;
        short indexCount;
        int compressedBoundingCenter;
        internal  DecoratorGroupBlock(BinaryReader binaryReader)
        {
            this.decoratorSet = binaryReader.ReadByteBlockIndex1();
            this.decoratorType = (DecoratorType)binaryReader.ReadByte();
            this.shaderIndex = binaryReader.ReadByte();
            this.compressedRadius = binaryReader.ReadByte();
            this.cluster = binaryReader.ReadInt16();
            this.cacheBlock = binaryReader.ReadShortBlockIndex1();
            this.decoratorStartIndex = binaryReader.ReadInt16();
            this.decoratorCount = binaryReader.ReadInt16();
            this.vertexStartOffset = binaryReader.ReadInt16();
            this.vertexCount = binaryReader.ReadInt16();
            this.indexStartOffset = binaryReader.ReadInt16();
            this.indexCount = binaryReader.ReadInt16();
            this.compressedBoundingCenter = binaryReader.ReadInt32();
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
        internal enum DecoratorType : byte
        {
            Model = 0,
            FloatingDecal = 0,
            ProjectedDecal = 0,
            ScreenFacingQuad = 0,
            AxisRotatingQuad = 0,
            CrossQuad = 0,
        };
    };
}
