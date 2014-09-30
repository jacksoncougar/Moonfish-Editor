using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 40)]
    public  partial class ObjectChangeColorFunction : ObjectChangeColorFunctionBase
    {
        public  ObjectChangeColorFunction(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class ObjectChangeColorFunction
    {
        internal byte[] invalidName_;
        internal ScaleFlags scaleFlags;
        internal Moonfish.Tags.ColorR8G8B8 colorLowerBound;
        internal Moonfish.Tags.ColorR8G8B8 colorUpperBound;
        internal Moonfish.Tags.StringID darkenBy;
        internal Moonfish.Tags.StringID scaleBy;
        internal  ObjectChangeColorFunctionBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.scaleFlags = (ScaleFlags)binaryReader.ReadInt32();
            this.colorLowerBound = binaryReader.ReadColorR8G8B8();
            this.colorUpperBound = binaryReader.ReadColorR8G8B8();
            this.darkenBy = binaryReader.ReadStringID();
            this.scaleBy = binaryReader.ReadStringID();
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
        internal enum ScaleFlags : int
        {
            /// <summary>
            /// blends colors in hsv rather than rgb space
            /// </summary>
            BlendInHsv = 1,
            /// <summary>
            /// blends colors through more hues (goes the long way around the color wheel)
            /// </summary>
            MoreColors = 2,
        };
    };
}
