using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class PathfindingHintsBlock
    {
        HintType hintType;
        short nextHintIndex;
        short hintData0;
        short hintData1;
        short hintData2;
        short hintData3;
        short hintData4;
        short hintData5;
        short hintData6;
        short hintData7;
        internal  PathfindingHintsBlock(BinaryReader binaryReader)
        {
            this.hintType = (HintType)binaryReader.ReadInt16();
            this.nextHintIndex = binaryReader.ReadInt16();
            this.hintData0 = binaryReader.ReadInt16();
            this.hintData1 = binaryReader.ReadInt16();
            this.hintData2 = binaryReader.ReadInt16();
            this.hintData3 = binaryReader.ReadInt16();
            this.hintData4 = binaryReader.ReadInt16();
            this.hintData5 = binaryReader.ReadInt16();
            this.hintData6 = binaryReader.ReadInt16();
            this.hintData7 = binaryReader.ReadInt16();
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
        internal enum HintType : short
        {
            IntersectionLink = 0,
            JumpLink = 0,
            ClimbLink = 0,
            VaultLink = 0,
            MountLink = 0,
            HoistLink = 0,
            WallJumpLink = 0,
            BreakableFloor = 0,
        };
    };
}
