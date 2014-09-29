using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class SectorBlock
    {
        PathFindingSectorflags pathFindingSectorFlags;
        short hintIndex;
        int firstLinkDoNotSetManually;
        internal  SectorBlock(BinaryReader binaryReader)
        {
            this.pathFindingSectorFlags = (PathFindingSectorflags)binaryReader.ReadInt16();
            this.hintIndex = binaryReader.ReadInt16();
            this.firstLinkDoNotSetManually = binaryReader.ReadInt32();
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
        internal enum PathFindingSectorflags : short
        {
            SectorWalkable = 1,
            SectorBreakable = 2,
            SectorMobile = 4,
            SectorBspSource = 8,
            Floor = 16,
            Ceiling = 32,
            WallNorth = 64,
            WallSouth = 128,
            WallEast = 256,
            WallWest = 512,
            Crouchable = 1024,
            Aligned = 2048,
            SectorStep = 4096,
            SectorInterior = 8192,
        };
    };
}
