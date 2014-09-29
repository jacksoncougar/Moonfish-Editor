using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalgeometryPartBlockNew
    {
        Type type;
        Flags flags;
        Moonfish.Tags.ShortBlockIndex1 material;
        short stripStartIndex;
        short stripLength;
        short firstSubpartIndex;
        short subpartCount;
        byte maxNodesVertex;
        byte contributingCompoundNodeCount;
        OpenTK.Vector3 position;
        NodeIndices nodeIndices;
        byte nodeIndex;
        internal  GlobalgeometryPartBlockNew(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.material = binaryReader.ReadShortBlockIndex1();
            this.stripStartIndex = binaryReader.ReadInt16();
            this.stripLength = binaryReader.ReadInt16();
            this.firstSubpartIndex = binaryReader.ReadInt16();
            this.subpartCount = binaryReader.ReadInt16();
            this.maxNodesVertex = binaryReader.ReadByte();
            this.contributingCompoundNodeCount = binaryReader.ReadByte();
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices(binaryReader);
            this.nodeIndex = binaryReader.ReadByte();
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
            NotDrawn = 0,
            OpaqueShadowOnly = 0,
            OpaqueShadowCasting = 0,
            OpaqueNonshadowing = 0,
            Transparent = 0,
            LightmapOnly = 0,
        };
        internal enum Flags : short
        {
            Decalable = 1,
            NewPartTypes = 2,
            DislikesPhotons = 4,
            OverrideTriangleList = 8,
            IgnoredByLightmapper = 16,
        };
        class NodeIndices
        {
            byte nodeIndex;
            internal  NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
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
    };
}
