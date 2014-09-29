using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class UserHintJumpBlock
    {
        Flags flags;
        Moonfish.Tags.ShortBlockIndex1 geometryIndex;
        ForceJumpHeight forceJumpHeight;
        ControlFlags controlFlags;
        internal  UserHintJumpBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.geometryIndex = binaryReader.ReadShortBlockIndex1();
            this.forceJumpHeight = (ForceJumpHeight)binaryReader.ReadInt16();
            this.controlFlags = (ControlFlags)binaryReader.ReadInt16();
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
        internal enum Flags : short
        {
            Bidirectional = 1,
            Closed = 2,
        };
        internal enum ForceJumpHeight : short
        {
            NONE = 0,
            Down = 0,
            Step = 0,
            Crouch = 0,
            Stand = 0,
            Storey = 0,
            Tower = 0,
            Infinite = 0,
        };
        internal enum ControlFlags : short
        {
            MagicLift = 1,
        };
    };
}
