using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class SectorLinkBlock
    {
        short vertex1;
        short vertex2;
        LinkFlags linkFlags;
        short hintIndex;
        short forwardLink;
        short reverseLink;
        short leftSector;
        short rightSector;
        internal  SectorLinkBlock(BinaryReader binaryReader)
        {
            this.vertex1 = binaryReader.ReadInt16();
            this.vertex2 = binaryReader.ReadInt16();
            this.linkFlags = (LinkFlags)binaryReader.ReadInt16();
            this.hintIndex = binaryReader.ReadInt16();
            this.forwardLink = binaryReader.ReadInt16();
            this.reverseLink = binaryReader.ReadInt16();
            this.leftSector = binaryReader.ReadInt16();
            this.rightSector = binaryReader.ReadInt16();
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
        internal enum LinkFlags : short
        {
            SectorLinkFromCollisionEdge = 1,
            SectorIntersectionLink = 2,
            SectorLinkBsp2dCreationError = 4,
            SectorLinkTopologyError = 8,
            SectorLinkChainError = 16,
            SectorLinkBothSectorsWalkable = 32,
            SectorLinkMagicHangingLink = 64,
            SectorLinkThreshold = 128,
            SectorLinkCrouchable = 256,
            SectorLinkWallBase = 512,
            SectorLinkLedge = 1024,
            SectorLinkLeanable = 2048,
            SectorLinkStartCorner = 4096,
            SectorLinkEndCorner = 8192,
        };
    };
}
