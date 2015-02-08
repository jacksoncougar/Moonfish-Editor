using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BitmapDataBlock : BitmapDataBlockBase
    {
        public  BitmapDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116)]
    public class BitmapDataBlockBase
    {
        internal Moonfish.Tags.TagClass signature;
        internal short widthPixels;
        internal short heightPixels;
        /// <summary>
        /// Depth is 1 for 2D textures and cube maps.
        /// </summary>
        internal byte depthPixels;
        internal MoreFlags moreFlags;
        /// <summary>
        /// Determines bitmap "geometry."
        /// </summary>
        internal TypeDeterminesBitmapGeometry type;
        /// <summary>
        /// Determines how pixels are represented internally.
        /// </summary>
        internal FormatDeterminesHowPixelsAreRepresentedInternally format;
        internal Flags flags;
        internal Moonfish.Tags.Point registrationPoint;
        internal short mipmapCount;
        internal short lowDetailMipmapCount;
        internal int pixelsOffset;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal byte[] invalidName_8;
        internal  BitmapDataBlockBase(BinaryReader binaryReader)
        {
            this.signature = binaryReader.ReadTagClass();
            this.widthPixels = binaryReader.ReadInt16();
            this.heightPixels = binaryReader.ReadInt16();
            this.depthPixels = binaryReader.ReadByte();
            this.moreFlags = (MoreFlags)binaryReader.ReadByte();
            this.type = (TypeDeterminesBitmapGeometry)binaryReader.ReadInt16();
            this.format = (FormatDeterminesHowPixelsAreRepresentedInternally)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.registrationPoint = binaryReader.ReadPoint();
            this.mipmapCount = binaryReader.ReadInt16();
            this.lowDetailMipmapCount = binaryReader.ReadInt16();
            this.pixelsOffset = binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.invalidName_0 = binaryReader.ReadBytes(12);
            this.invalidName_1 = binaryReader.ReadBytes(12);
            this.invalidName_2 = binaryReader.ReadBytes(12);
            this.invalidName_3 = binaryReader.ReadBytes(4);
            this.invalidName_4 = binaryReader.ReadBytes(4);
            this.invalidName_5 = binaryReader.ReadBytes(4);
            this.invalidName_6 = binaryReader.ReadBytes(4);
            this.invalidName_7 = binaryReader.ReadBytes(20);
            this.invalidName_8 = binaryReader.ReadBytes(4);
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
        [FlagsAttribute]
        internal enum MoreFlags : byte
        
        {
            DeleteFromCacheFile = 1,
            BitmapCreateAttempted = 2,
            InvalidName = 4,
        };
        internal enum TypeDeterminesBitmapGeometry : short
        
        {
            InvalidName2DTexture = 0,
            InvalidName3DTexture = 1,
            CubeMap = 2,
        };
        internal enum FormatDeterminesHowPixelsAreRepresentedInternally : short
        
        {
            A8 = 0,
            Y8 = 1,
            Ay8 = 2,
            A8y8 = 3,
            Unused1 = 4,
            Unused2 = 5,
            R5g6b5 = 6,
            Unused3 = 7,
            A1r5g5b5 = 8,
            A4r4g4b4 = 9,
            X8r8g8b8 = 10,
            A8r8g8b8 = 11,
            Unused4 = 12,
            Unused5 = 13,
            Dxt1 = 14,
            Dxt3 = 15,
            Dxt5 = 16,
            P8Bump = 17,
            P8 = 18,
            Argbfp32 = 19,
            Rgbfp32 = 20,
            Rgbfp16 = 21,
            V8u8 = 22,
            G8b8 = 23,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            PowerOfTwoDimensions = 1,
            Compressed = 2,
            Palettized = 4,
            Swizzled = 8,
            Linear = 16,
            V16u16 = 32,
            MIPMapDebugLevel = 64,
            PreferStutterPreferLowDetail = 128,
        };
    };
}
