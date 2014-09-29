using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspFogPlaneblock
    {
        short scenarioPlanarFogIndex;
        byte[] invalidName_;
        OpenTK.Vector4 plane;
        Flags flags;
        short priority;
        internal  StructureBspFogPlaneblock(BinaryReader binaryReader)
        {
            this.scenarioPlanarFogIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.plane = binaryReader.ReadVector4();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.priority = binaryReader.ReadInt16();
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
            ExtendInfinitelyWhileVisible = 1,
            DoNotFloodfill = 2,
            AggressiveFloodfill = 4,
        };
    };
}
