using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalStructurePhysicsstructBlock
    {
        byte[] moppCode;
        byte[] invalidName_;
        OpenTK.Vector3 moppBoundsMin;
        OpenTK.Vector3 moppBoundsMax;
        byte[] breakableSurfacesMoppCode;
        BreakableSurfaceKeyTableblock[] breakableSurfaceKeyTable;
        internal  GlobalStructurePhysicsstructBlock(BinaryReader binaryReader)
        {
            this.moppCode = ReadData(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.moppBoundsMin = binaryReader.ReadVector3();
            this.moppBoundsMax = binaryReader.ReadVector3();
            this.breakableSurfacesMoppCode = ReadData(binaryReader);
            this.breakableSurfaceKeyTable = ReadBreakableSurfaceKeyTableblockArray(binaryReader);
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
        BreakableSurfaceKeyTableblock[] ReadBreakableSurfaceKeyTableblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BreakableSurfaceKeyTableblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BreakableSurfaceKeyTableblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BreakableSurfaceKeyTableblock(binaryReader);
                }
            }
            return array;
        }
    };
}
