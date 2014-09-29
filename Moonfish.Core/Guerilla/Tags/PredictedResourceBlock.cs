using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class PredictedResourceBlock
    {
        Type type;
        short resourceIndex;
        int tagIndex;
        internal  PredictedResourceBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.resourceIndex = binaryReader.ReadInt16();
            this.tagIndex = binaryReader.ReadInt32();
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
            Bitmap = 0,
            Sound = 0,
            RenderModelGeometry = 0,
            ClusterGeometry = 0,
            ClusterInstancedGeometry = 0,
            LightmapGeometryObjectBuckets = 0,
            LightmapGeometryInstanceBuckets = 0,
            LightmapClusterBitmaps = 0,
            LightmapInstanceBitmaps = 0,
        };
    };
}
