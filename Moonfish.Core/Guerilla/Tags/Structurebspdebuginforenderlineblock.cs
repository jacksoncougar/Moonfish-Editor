using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspDebugInfoRenderLineblock
    {
        Type type;
        short code;
        short padThai;
        byte[] invalidName_;
        OpenTK.Vector3 point0;
        OpenTK.Vector3 point1;
        internal  StructureBspDebugInfoRenderLineblock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.code = binaryReader.ReadInt16();
            this.padThai = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.point0 = binaryReader.ReadVector3();
            this.point1 = binaryReader.ReadVector3();
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
        internal enum Type : short
        {
            FogPlaneBoundaryEdge = 0,
            FogPlaneInternalEdge = 0,
            FogZoneFloodfill = 0,
            FogZoneClusterCentroid = 0,
            FogZoneClusterGeometry = 0,
            FogZonePortalCentroid = 0,
            FogZonePortalGeometry = 0,
        };
    };
}
