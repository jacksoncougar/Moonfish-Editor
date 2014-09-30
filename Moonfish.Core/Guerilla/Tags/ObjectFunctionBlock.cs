using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 32)]
    public  partial class ObjectFunctionBlock : ObjectFunctionBlockBase
    {
        public  ObjectFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class ObjectFunctionBlockBase
    {
        internal Flags flags;
        internal Moonfish.Tags.StringID importName;
        internal Moonfish.Tags.StringID exportName;
        /// <summary>
        /// if the specified function is off, so is this function
        /// </summary>
        internal Moonfish.Tags.StringID turnOffWith;
        /// <summary>
        /// function must exceed this value (after mapping) to be active 0. means do nothing
        /// </summary>
        internal float minValue;
        internal MappingFunctionBlock defaultFunction;
        internal Moonfish.Tags.StringID scaleBy;
        internal  ObjectFunctionBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.importName = binaryReader.ReadStringID();
            this.exportName = binaryReader.ReadStringID();
            this.turnOffWith = binaryReader.ReadStringID();
            this.minValue = binaryReader.ReadSingle();
            this.defaultFunction = new MappingFunctionBlock(binaryReader);
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
        internal enum Flags : int
        {
            /// <summary>
            /// result of function is one minus actual result
            /// </summary>
            Invert = 1,
            /// <summary>
            /// the curve mapping can make the function active/inactive
            /// </summary>
            MappingDoesNotControlsActive = 2,
            /// <summary>
            /// function does not deactivate when at or below lower bound
            /// </summary>
            AlwaysActive = 4,
            /// <summary>
            /// function offsets periodic function input by random value between 0 and 1
            /// </summary>
            RandomTimeOffset = 8,
        };
    };
}
