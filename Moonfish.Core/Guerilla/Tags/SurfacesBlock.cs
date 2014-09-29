using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class SurfacesBlock
    {
        short plane;
        short firstEdge;
        Flags flags;
        byte breakableSurface;
        short material;
        internal  SurfacesBlock(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadInt16();
            this.firstEdge = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadByte();
            this.breakableSurface = binaryReader.ReadByte();
            this.material = binaryReader.ReadInt16();
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
        internal enum Flags : byte
        {
            TwoSided = 1,
            Invisible = 2,
            Climbable = 4,
            Breakable = 8,
            Invalid = 16,
            Conveyor = 32,
        };
    };
}
