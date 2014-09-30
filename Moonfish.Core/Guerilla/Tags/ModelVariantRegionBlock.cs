using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 20)]
    public  partial class ModelVariantRegionBlock : ModelVariantRegionBlockBase
    {
        public  ModelVariantRegionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class ModelVariantRegionBlockBase
    {
        internal Moonfish.Tags.StringID regionNameMustMatchRegionNameInRenderModel;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ShortBlockIndex1 parentVariant;
        internal ModelVariantPermutationBlock[] permutations;
        /// <summary>
        /// negative values mean closer to the camera
        /// </summary>
        internal SortOrderNegativeValuesMeanCloserToTheCamera sortOrder;
        internal byte[] invalidName_1;
        internal  ModelVariantRegionBlockBase(BinaryReader binaryReader)
        {
            this.regionNameMustMatchRegionNameInRenderModel = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.invalidName_0 = binaryReader.ReadBytes(1);
            this.parentVariant = binaryReader.ReadShortBlockIndex1();
            this.permutations = ReadModelVariantPermutationBlockArray(binaryReader);
            this.sortOrder = (SortOrderNegativeValuesMeanCloserToTheCamera)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
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
        internal  virtual ModelVariantPermutationBlock[] ReadModelVariantPermutationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelVariantPermutationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelVariantPermutationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelVariantPermutationBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum SortOrderNegativeValuesMeanCloserToTheCamera : short
        {
            NoSorting = 0,
            invalidName_5Closest = 1,
            invalidName_4 = 2,
            invalidName_3 = 3,
            invalidName_2 = 4,
            invalidName_1 = 5,
            invalidName_0SameAsModel = 6,
            invalidNuame_1 = 7,
            invalidNiuiame_2 = 8,
            invalidNauuume_3 = 9,
            invalidNauume_4 = 10,
            invalidName_5Farthest = 11,
        };
    };
}
