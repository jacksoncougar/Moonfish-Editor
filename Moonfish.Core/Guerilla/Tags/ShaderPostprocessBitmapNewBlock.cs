using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessBitmapNewBlock : ShaderPostprocessBitmapNewBlockBase
    {
        public  ShaderPostprocessBitmapNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ShaderPostprocessBitmapNewBlockBase
    {
        internal int bitmapGroup;
        internal int bitmapIndex;
        internal float logBitmapDimension;
        internal  ShaderPostprocessBitmapNewBlockBase(BinaryReader binaryReader)
        {
            this.bitmapGroup = binaryReader.ReadInt32();
            this.bitmapIndex = binaryReader.ReadInt32();
            this.logBitmapDimension = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
