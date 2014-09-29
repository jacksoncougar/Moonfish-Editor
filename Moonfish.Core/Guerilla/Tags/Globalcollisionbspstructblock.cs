using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class GlobalCollisionBspStructblock
    {
        Bsp3dNodesblock[] bSP3DNodes;
        PlanesBlock[] planes;
        LeavesBlock[] leaves;
        Bsp2dReferencesblock[] bSP2DReferences;
        Bsp2dNodesblock[] bSP2DNodes;
        SurfacesBlock[] surfaces;
        EdgesBlock[] edges;
        VerticesBlock[] vertices;
        internal  GlobalCollisionBspStructblock(BinaryReader binaryReader)
        {
            this.bSP3DNodes = ReadBsp3dNodesblockArray(binaryReader);
            this.planes = ReadPlanesBlockArray(binaryReader);
            this.leaves = ReadLeavesBlockArray(binaryReader);
            this.bSP2DReferences = ReadBsp2dReferencesblockArray(binaryReader);
            this.bSP2DNodes = ReadBsp2dNodesblockArray(binaryReader);
            this.surfaces = ReadSurfacesBlockArray(binaryReader);
            this.edges = ReadEdgesBlockArray(binaryReader);
            this.vertices = ReadVerticesBlockArray(binaryReader);
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
        Bsp3dNodesblock[] ReadBsp3dNodesblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(Bsp3dNodesblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new Bsp3dNodesblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new Bsp3dNodesblock(binaryReader);
                }
            }
            return array;
        }
        PlanesBlock[] ReadPlanesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlanesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlanesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlanesBlock(binaryReader);
                }
            }
            return array;
        }
        LeavesBlock[] ReadLeavesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LeavesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LeavesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LeavesBlock(binaryReader);
                }
            }
            return array;
        }
        Bsp2dReferencesblock[] ReadBsp2dReferencesblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(Bsp2dReferencesblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new Bsp2dReferencesblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new Bsp2dReferencesblock(binaryReader);
                }
            }
            return array;
        }
        Bsp2dNodesblock[] ReadBsp2dNodesblockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(Bsp2dNodesblock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new Bsp2dNodesblock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new Bsp2dNodesblock(binaryReader);
                }
            }
            return array;
        }
        SurfacesBlock[] ReadSurfacesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SurfacesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SurfacesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SurfacesBlock(binaryReader);
                }
            }
            return array;
        }
        EdgesBlock[] ReadEdgesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EdgesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EdgesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EdgesBlock(binaryReader);
                }
            }
            return array;
        }
        VerticesBlock[] ReadVerticesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VerticesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
