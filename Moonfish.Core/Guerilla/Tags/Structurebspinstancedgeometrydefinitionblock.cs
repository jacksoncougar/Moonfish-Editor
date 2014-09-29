using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspInstancedGeometryDefinitionblock
    {
        StructureInstancedGeometryRenderinfostructBlock renderInfo;
        int checksum;
        OpenTK.Vector3 boundingSphereCenter;
        float boundingSphereRadius;
        GlobalCollisionBspStructblock collisionInfo;
        CollisionBspPhysicsblock[] bspPhysics;
        StructureBspLeafblock[] renderLeaves;
        StructureBspsurfaceReferenceblock[] surfaceReferences;
        internal  StructureBspInstancedGeometryDefinitionblock(BinaryReader binaryReader)
        {
            this.renderInfo = new StructureInstancedGeometryRenderinfostructBlock(binaryReader);
            this.checksum = binaryReader.ReadInt32();
            this.boundingSphereCenter = binaryReader.ReadVector3();
            this.boundingSphereRadius = binaryReader.ReadSingle();
            this.collisionInfo = new GlobalCollisionBspStructblock(binaryReader);
            this.bspPhysics = ReadCollisionBspPhysicsblockArray(binaryReader);
            this.renderLeaves = ReadStructureBspLeafblockArray(binaryReader);
            this.surfaceReferences = ReadStructureBspsurfaceReferenceblockArray(binaryReader);
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
        CollisionBspPhysicsblock[] ReadCollisionBspPhysicsblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionBspPhysicsblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionBspPhysicsblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionBspPhysicsblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspLeafblock[] ReadStructureBspLeafblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspLeafblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspLeafblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspLeafblock(binaryReader);
                }
            }
            return array;
        }
        StructureBspsurfaceReferenceblock[] ReadStructureBspsurfaceReferenceblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspsurfaceReferenceblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspsurfaceReferenceblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspsurfaceReferenceblock(binaryReader);
                }
            }
            return array;
        }
    };
}
