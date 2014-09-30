using Moonfish.Definitions;
using Moonfish.Guerilla.Tags;
using Moonfish.Model;
using Moonfish.Structures;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{

    /// <summary>
    /// Wrapper class for buffering Halo 2 mesh data for use through OpenGL
    /// </summary>
    public class Mesh : IDisposable
    {
        public RenderModelSectionBlock sectionBlock;

        int mVAO_id;
        List<int> mVBO_ids;

        public int VertexCount { get { return sectionBlock.sectionInfo.totalVertexCount; } }
        public int IndexCount { get { return sectionBlock.sectionData[0].section.stripIndices.Length; } }
        public GlobalGeometryPartBlockNew[] Parts
        {
            get
            {
                if (sectionBlock != null)
                {
                    var sectionData = sectionBlock.sectionData;
                    return sectionData.Count() > 0 ? sectionData[0].section.parts : new GlobalGeometryPartBlockNew[0];
                }
                else
                {
                    return new GlobalGeometryPartBlockNew[0];
                }
            }
        }

        public Mesh(RenderModelSectionBlock sectionBlock)
        {
            if (sectionBlock.sectionData.Length == 0) //sectionBlock.LoadSectionData();
            this.sectionBlock = sectionBlock;
            BufferMeshResources(sectionBlock);
        }

        public IDisposable Bind()
        {
            GL.BindVertexArray(mVAO_id); OpenGL.ReportError();
            return new Handle(0);
        }

        private void BufferMeshResources(RenderModelSectionBlock section)
        {
            if (section.sectionData.Count() > 0)
            {
                mVBO_ids = new List<int>();
                mVAO_id = GL.GenVertexArray();
                GL.BindVertexArray(mVAO_id);

                BufferElementArrayData(section.sectionData[0].section.stripIndices.Select(x => x.index).ToArray());

                BufferVertexAttributeData(section.sectionData[0].section.vertexBuffers.Select(x => x.vertexBuffer).ToArray());

                GL.BindVertexArray(0);
            }
        }

        private void BufferVertexAttributeData(VertexBuffer[] vertexBuffers)
        {
            for (int i = 0; i < vertexBuffers.Length; ++i)
            {
                if (!Enum.IsDefined(typeof(VertexAttributeType), vertexBuffers[i].Type)) continue;
                mVBO_ids.Add(GL.GenBuffer());

                GL.BindBuffer(BufferTarget.ArrayBuffer, mVBO_ids.Last()); OpenGL.ReportError();
                GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)vertexBuffers[i].Data.Length, vertexBuffers[i].Data, BufferUsageHint.StaticDraw); OpenGL.ReportError();
                GL.EnableVertexAttribArray(i); OpenGL.ReportError();

                var attribute_type = vertexBuffers[i].Type;
                var attribute_size = attribute_type.GetSize();
                switch (attribute_type)
                {
                    case VertexAttributeType.coordinate_compressed:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Short, true, attribute_size, 0);
                        break;
                    case VertexAttributeType.coordinate_with_single_node:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Short, true, attribute_size, 0);
                        break;
                    case VertexAttributeType.coordinate_with_double_node:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Short, true, attribute_size, 0);
                        break;
                    case VertexAttributeType.coordinate_with_triple_node:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Short, true, attribute_size, 0);
                        break;
                    case VertexAttributeType.texture_coordinate_compressed:
                        GL.VertexAttribPointer(i, 2, VertexAttribPointerType.Short, true, attribute_size, 0);
                        break;
                    case VertexAttributeType.tangent_space_unit_vectors_compressed:
                        GL.VertexAttribIPointer(i, 3, VertexAttribIntegerType.Int, attribute_size, IntPtr.Zero);
                        break;
                    case VertexAttributeType.coordinate_float:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Float, false, attribute_size, 0);
                        break;
                    case VertexAttributeType.texture_coordinate_float:
                        GL.VertexAttribPointer(i, 2, VertexAttribPointerType.Float, false, attribute_size, 0);
                        break;
                    default: break;
                }
                OpenGL.ReportError();
            }
        }

        private void BufferElementArrayData(short[] indices)
        {
            mVBO_ids.Add(GL.GenBuffer());
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, mVBO_ids.Last());
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(short)), indices, BufferUsageHint.StaticDraw);
        }

        public void Dispose()
        {
            //  Bind default VBA
            GL.BindVertexArray(0);
            //  Delete VBA buffer
            GL.DeleteBuffer(mVAO_id);
            //  Delete VBO buffers
            GL.DeleteBuffers(mVBO_ids.Count, mVBO_ids.ToArray());
        }

        private class Handle : IDisposable
        {
            int previousVAO;

            public Handle(int in_previousVAO)
            {
                previousVAO = in_previousVAO;
            }

            public void Dispose()
            {
                GL.BindVertexArray(previousVAO);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            }
        }
    }

    public class MeshManager
    {
        Scenario scenario;
        Program program;
        Program systemProgram;
        Dictionary<TagIdent, ScenarioObject> objects;

        internal void Add(HierarchyModel model, TagIdent id)
        {
            objects[id] = new ScenarioObject(model);
        }

        public ScenarioObject this[TagIdent ident]
        {
            get { return this.objects.ContainsKey(ident) ? objects[ident] : null; }
        }

        public MeshManager(Program program, Program systemProgram)
        {
            objects = new Dictionary<TagIdent, ScenarioObject>();
            this.program = program;
            this.systemProgram = systemProgram;
        }

        public void LoadScenario(MapStream map)
        {
            this.scenario = map["scnr", ""].Deserialize();
            var scenery = scenario.sceneryPalette.Select(x => new { item = map[x.name.TagID].Deserialize(), id = x.name.TagID });
            var weapons = scenario.weaponPalette.Select(x => new { item = map[x.name.TagID].Deserialize(), id = x.name.TagID });
            var vehicles = scenario.vehiclePalette.Select(x => new { item = map[x.name.TagID].Deserialize(), id = x.name.TagID });
            var crates = scenario.cratesPalette.Select(x => new { item = map[x.name.TagID].Deserialize(), id = x.name.TagID });
            var equipment = scenario.equipmentPalette.Select(x => new { item = map[x.name.TagID].Deserialize(), id = x.name.TagID });

            var items = scenery
                .Concat(weapons)
                .Concat(vehicles)
                .Concat(crates)
                .Concat(equipment);

            foreach (var item in items)
            {
                Add(item.item.HierarchyModel, item.id);
            }

            Log.Info(GL.GetError().ToString());
        }

        public void Draw()
        {
            if( scenario == null ) return;
            using (program.Use())
            {
                RenderPalette(scenario.sceneryPalette, scenario.scenery);
                RenderPalette(scenario.vehiclePalette, scenario.vehicles);
                RenderPalette(scenario.equipmentPalette, scenario.equipment);
                RenderPalette(scenario.weaponPalette, scenario.weapons);
                RenderPalette(scenario.cratesPalette, scenario.crates);
            }
        }
        public void Add(TagIdent item)
        {
            var data = Halo2.GetReferenceObject(item);
            objects[item] = new ScenarioObject((HierarchyModel)data);
        }
        public void Draw(TagIdent item)
        {
            if (objects.ContainsKey(item))
            {
                IRenderable @object = objects[item] as IRenderable;
                @object.Render(new[] { program, systemProgram });
            }
            else
            {
                var data = Halo2.GetReferenceObject(item);
                objects[item] = new ScenarioObject((HierarchyModel)data);
            }
        }

        private void RenderPalette(IList<IH2ObjectPalette> palette, IEnumerable<IH2ObjectInstance> instances)
        {
            foreach (var instance in instances)
            {
                using (program.Use())
                {
                    if ((int)instance.PaletteIndex < 0) continue;
                    program[Uniforms.WorldMatrix] = (Matrix4)instance.WorldMatrix;
                    IRenderable @object = objects[palette[(int)instance.PaletteIndex].ObjectReference.TagID];
                    @object.Render(new[] { program });
                }
            }
        }

        internal void LoadHierarchyModels(MapStream map)
        {
            //var tags = map.Where(x => x.Type.ToString() == "hlmt").Select(x => new { item = map[x.Identifier].Deserialize(), id = x.Identifier });
            //foreach (var tag in tags)
            //{
            //    this.Add(tag.item, tag.id);
            //}
        }

        internal void Remove(TagIdent item)
        {
            this.objects.Remove(item);
        }

        internal void Clear()
        {
            this.objects.Clear();
        }
    }

    public static class VertexAttributeTypeExtensions
    {
        public static byte GetSize(this VertexAttributeType attribute_type)
        {
            var value = (short)attribute_type;
            var size = (byte)(value & 0x00FF);
            return size;
        }

        public static VertexAttributeType ReadVertexAttributeType(this BinaryReader binaryReader)
        {
            byte msb = binaryReader.ReadByte();
            byte lsb = binaryReader.ReadByte();
            var type = (VertexAttributeType)(msb << 8 | lsb);
            return type;
        }
    }

    public enum VertexAttributeType : short
    {
        none = 0x0000,
        coordinate_float = 0x010C,
        coordinate_compressed = 0x0206,
        coordinate_with_single_node = 0x0408,
        coordinate_with_double_node = 0x060C,
        coordinate_with_triple_node = 0x080C,

        texture_coordinate_float_pc = 0x1708,
        texture_coordinate_float = 0x1808,
        texture_coordinate_compressed = 0x1904,

        tangent_space_unit_vectors_float = 0x1924,
        tangent_space_unit_vectors_compressed = 0x1B0C,

        lightmap_uv_coordinate_one = 0x1F08,
        lightmap_uv_coordinate_two = 0x3008,

        diffuse_colour = 0x350C,
    }
}