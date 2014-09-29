using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalgeometrySectionInfostructBlock
    {
        short totalVertexCount;
        short totalTriangleCount;
        short totalPartCount;
        short shadowCastingTriangleCount;
        short shadowCastingPartCount;
        short opaquePointCount;
        short opaqueVertexCount;
        short opaquePartCount;
        byte opaqueMaxNodesVertex;
        byte transparentMaxNodesVertex;
        short shadowCastingRigidTriangleCount;
        GeometryClassification geometryClassification;
        GeometryCompressionFlags geometryCompressionFlags;
        GlobalgeometryCompressionInfoBlock[] eMPTYSTRING;
        byte hardwareNodeCount;
        byte nodeMapSize;
        short softwarePlaneCount;
        short totalSubpartCont;
        SectionLightingFlags sectionLightingFlags;
        internal  GlobalgeometrySectionInfostructBlock(BinaryReader binaryReader)
        {
            this.totalVertexCount = binaryReader.ReadInt16();
            this.totalTriangleCount = binaryReader.ReadInt16();
            this.totalPartCount = binaryReader.ReadInt16();
            this.shadowCastingTriangleCount = binaryReader.ReadInt16();
            this.shadowCastingPartCount = binaryReader.ReadInt16();
            this.opaquePointCount = binaryReader.ReadInt16();
            this.opaqueVertexCount = binaryReader.ReadInt16();
            this.opaquePartCount = binaryReader.ReadInt16();
            this.opaqueMaxNodesVertex = binaryReader.ReadByte();
            this.transparentMaxNodesVertex = binaryReader.ReadByte();
            this.shadowCastingRigidTriangleCount = binaryReader.ReadInt16();
            this.geometryClassification = (GeometryClassification)binaryReader.ReadInt16();
            this.geometryCompressionFlags = (GeometryCompressionFlags)binaryReader.ReadInt16();
            this.eMPTYSTRING = ReadGlobalgeometryCompressionInfoBlockArray(binaryReader);
            this.hardwareNodeCount = binaryReader.ReadByte();
            this.nodeMapSize = binaryReader.ReadByte();
            this.softwarePlaneCount = binaryReader.ReadInt16();
            this.totalSubpartCont = binaryReader.ReadInt16();
            this.sectionLightingFlags = (SectionLightingFlags)binaryReader.ReadInt16();
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
        GlobalgeometryCompressionInfoBlock[] ReadGlobalgeometryCompressionInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalgeometryCompressionInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalgeometryCompressionInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalgeometryCompressionInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum GeometryClassification : short
        {
            Worldspace = 0,
            Rigid = 0,
            RigidBoned = 0,
            Skinned = 0,
            UnsupportedReimport = 0,
        };
        internal enum GeometryCompressionFlags : short
        {
            CompressedPosition = 1,
            CompressedTexcoord = 2,
            CompressedSecondaryTexcoord = 4,
        };
        internal enum SectionLightingFlags : short
        {
            HasLmTexcoords = 1,
            HasLmIncRad = 2,
            HasLmColors = 4,
            HasLmPrt = 8,
        };
    };
}
