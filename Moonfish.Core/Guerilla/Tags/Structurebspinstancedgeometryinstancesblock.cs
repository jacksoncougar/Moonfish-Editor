using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspInstancedGeometryinstancesblock
    {
        float scale;
        OpenTK.Vector3 forward;
        OpenTK.Vector3 left;
        OpenTK.Vector3 up;
        OpenTK.Vector3 position;
        Moonfish.Tags.ShortBlockIndex1 instanceDefinition;
        Flags flags;
        byte[] invalidName_;
        byte[] invalidName_0;
        byte[] invalidName_1;
        int checksum;
        Moonfish.Tags.StringID name;
        Pathfindingpolicy pathfindingPolicy;
        LightmappingPolicy lightmappingPolicy;
        internal  StructureBspInstancedGeometryinstancesblock(BinaryReader binaryReader)
        {
            this.scale = binaryReader.ReadSingle();
            this.forward = binaryReader.ReadVector3();
            this.left = binaryReader.ReadVector3();
            this.up = binaryReader.ReadVector3();
            this.position = binaryReader.ReadVector3();
            this.instanceDefinition = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.invalidName_0 = binaryReader.ReadBytes(12);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.checksum = binaryReader.ReadInt32();
            this.name = binaryReader.ReadStringID();
            this.pathfindingPolicy = (Pathfindingpolicy)binaryReader.ReadInt16();
            this.lightmappingPolicy = (LightmappingPolicy)binaryReader.ReadInt16();
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
        internal enum Flags : short
        {
            NotInLightprobes = 1,
        };
        internal enum Pathfindingpolicy : short
        {
            Cutout = 0,
            Static = 0,
            None = 0,
        };
        internal enum LightmappingPolicy : short
        {
            PerPixel = 0,
            PerVertex = 0,
        };
    };
}
