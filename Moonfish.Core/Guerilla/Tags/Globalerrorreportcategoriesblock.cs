using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalErrorReportCategoriesBlock
    {
        Moonfish.Tags.String256 name;
        ReportType reportType;
        Flags flags;
        byte[] invalidName_;
        byte[] invalidName_0;
        byte[] invalidName_1;
        ErrorReportsBlock[] reports;
        internal  GlobalErrorReportCategoriesBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString256();
            this.reportType = (ReportType)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(404);
            this.reports = ReadErrorReportsBlockArray(binaryReader);
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
        ErrorReportsBlock[] ReadErrorReportsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportsBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum ReportType : short
        {
            Silent = 0,
            Comment = 0,
            Warning = 0,
            Error = 0,
        };
        internal enum Flags : short
        {
            Rendered = 1,
            TangentSpace = 2,
            Noncritical = 4,
            LightmapLight = 8,
            ReportKeyIsValid = 16,
        };
    };
}
