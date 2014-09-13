using Moonfish.Collision;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public interface IRenderable
    {
        void Render(IEnumerable<Program> shaderPasses);
        void Render(IEnumerable<Program> shaderPasses, IList<IH2ObjectInstance> instances);
    }
    public class ScenarioObject : IRenderable
    {
        HierarchyModel model;
        List<Mesh> sectionBuffers;

        public StringID activePermuation;

        public ScenarioObject()
        {
            activePermuation = StringID.Zero;
            sectionBuffers = new List<Mesh>();
        }
        public ScenarioObject(HierarchyModel model)
            : this()
        {
            this.model = model;
            foreach (var section in model.RenderModel.Sections)
            {
                sectionBuffers.Add(new Mesh(section));
            }
        }

        public IEnumerable<StringID> Permutations
        {
            get
            {
                var query = model.RenderModel.regions.SelectMany(x => x.permutations).Select(x => x.name).Distinct();
                return query;
            }
        }

        void Render(IEnumerable<Program> shaderPasses)
        {
            var objectMatrix = model.RenderModel.compressionInfo[0].ToExtentsMatrix();
            foreach (var program in shaderPasses)
            {
                RenderPass(objectMatrix, program);
            }

        }

        private void RenderPass(Matrix4 objectMatrix, Program program)
        {
            using (program.Using("object_extents", objectMatrix))
            {
                foreach (var region in model.RenderModel.regions)
                {
                    var section_index = region.permutations[0].l6SectionIndexHollywood;
                    var mesh = sectionBuffers[section_index];
                    using (mesh.Bind())
                    {
                        foreach (var part in mesh.Parts)
                        {
                            GL.DrawElements(BeginMode.TriangleStrip, part.stripLength, DrawElementsType.UnsignedShort, part.stripStartIndex * 2);
                        }
                    }
                }
                foreach (var markerGroup in model.RenderModel.markerGroups)
                {
                    foreach (var marker in markerGroup.markers)
                    {
                        var node = marker.nodeIndex;
                        var translation = marker.translation;
                        var rotation = marker.rotation;
                        var scale = marker.scale;

                        DebugDrawer.DrawPoint(translation);
                    }
                }
            }
        }

        void IRenderable.Render(IEnumerable<Program> shaderPasses)
        {
            this.Render(shaderPasses);
        }

        void IRenderable.Render(IEnumerable<Program> shaderPasses, IList<IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }
    }

    class ScenarioObjectd
    {
        HierarchyModel model;

        public ScenarioObjectd(HierarchyModel test)
        {
            this.model = test;
            ActivePermutation = StringID.Zero;
        }

        public StringID ActivePermutation { get; set; }

        public IEnumerable<StringID> Permutations
        {
            get
            {
                var query = model.RenderModel.regions.SelectMany(x => x.permutations).Select(x => x.name).Distinct();
                return query;
            }
        }

        public void Draw()
        {
        }
    }
}
