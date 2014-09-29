using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class ErrorReportsBlock
    {
        Type type;
        Flags flags;
        byte[] text;
        Moonfish.Tags.String32 sourceFilename;
        int sourceLineNumber;
        ErrorReportVerticesBlock[] vertices;
        ErrorReportVectorsBlock[] vectors;
        ErrorReportLinesBlock[] lines;
        ErrorReportTrianglesBlock[] triangles;
        ErrorReportQuadsBlock[] quads;
        ErrorReportCommentsBlock[] comments;
        byte[] invalidName_;
        int reportKey;
        int nodeIndex;
        Moonfish.Model.Range boundsX;
        Moonfish.Model.Range boundsY;
        Moonfish.Model.Range boundsZ;
        OpenTK.Vector4 color;
        byte[] invalidName_0;
        internal  ErrorReportsBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.text = ReadData(binaryReader);
            this.sourceFilename = binaryReader.ReadString32();
            this.sourceLineNumber = binaryReader.ReadInt32();
            this.vertices = ReadErrorReportVerticesBlockArray(binaryReader);
            this.vectors = ReadErrorReportVectorsBlockArray(binaryReader);
            this.lines = ReadErrorReportLinesBlockArray(binaryReader);
            this.triangles = ReadErrorReportTrianglesBlockArray(binaryReader);
            this.quads = ReadErrorReportQuadsBlockArray(binaryReader);
            this.comments = ReadErrorReportCommentsBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(380);
            this.reportKey = binaryReader.ReadInt32();
            this.nodeIndex = binaryReader.ReadInt32();
            this.boundsX = binaryReader.ReadRange();
            this.boundsY = binaryReader.ReadRange();
            this.boundsZ = binaryReader.ReadRange();
            this.color = binaryReader.ReadVector4();
            this.invalidName_0 = binaryReader.ReadBytes(84);
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
        ErrorReportVerticesBlock[] ReadErrorReportVerticesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportVerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportVerticesBlock(binaryReader);
                }
            }
            return array;
        }
        ErrorReportVectorsBlock[] ReadErrorReportVectorsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportVectorsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportVectorsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportVectorsBlock(binaryReader);
                }
            }
            return array;
        }
        ErrorReportLinesBlock[] ReadErrorReportLinesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportLinesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportLinesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportLinesBlock(binaryReader);
                }
            }
            return array;
        }
        ErrorReportTrianglesBlock[] ReadErrorReportTrianglesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportTrianglesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportTrianglesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportTrianglesBlock(binaryReader);
                }
            }
            return array;
        }
        ErrorReportQuadsBlock[] ReadErrorReportQuadsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportQuadsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportQuadsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportQuadsBlock(binaryReader);
                }
            }
            return array;
        }
        ErrorReportCommentsBlock[] ReadErrorReportCommentsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportCommentsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportCommentsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportCommentsBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Type : short
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
