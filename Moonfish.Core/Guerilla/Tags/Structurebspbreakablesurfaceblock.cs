using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspbreakablesurfaceblock
    {
        Moonfish.Tags.ShortBlockIndex1 instancedGeometryInstance;
        short breakableSurfaceIndex;
        OpenTK.Vector3 centroid;
        float radius;
        int collisionSurfaceIndex;
        internal  StructureBspbreakablesurfaceblock(BinaryReader binaryReader)
        {
            this.instancedGeometryInstance = binaryReader.ReadShortBlockIndex1();
            this.breakableSurfaceIndex = binaryReader.ReadInt16();
            this.centroid = binaryReader.ReadVector3();
            this.radius = binaryReader.ReadSingle();
            this.collisionSurfaceIndex = binaryReader.ReadInt32();
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
    };
}
