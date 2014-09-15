using Moonfish.Collision;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public interface IRenderable
    {
        void Render(IEnumerable<Program> shaderPasses);
        void Render(IEnumerable<Program> shaderPasses, IList<IH2ObjectInstance> instances);
    }

    public class NodeCollection : List<RenderModelNodeBlock>
    {
        public NodeCollection() : base() { }
        public NodeCollection(int capacity)
            : base(capacity)
        {
        }
        public NodeCollection(IEnumerable<RenderModelNodeBlock> collection)
            : base(collection)
        {
        }
        public Matrix4 GetWorldMatrix(int nodeIndex)
        {
            return GetWorldMatrix(this[nodeIndex]);
        }
        public Matrix4 GetWorldMatrix(RenderModelNodeBlock node)
        {
            if (!this.Contains(node)) throw new ArgumentOutOfRangeException();

            var worldMatrix = node.WorldMatrix;
            if ((int)node.parentNode < 0) return worldMatrix;
            return worldMatrix * GetWorldMatrix(this[(int)node.parentNode]);
        }
    }

    public class SkeletonNode
    {
        IList<SkeletonNode> nodeList;
        public SkeletonNode Parent
        {
            get
            {
                var parent = (int)this.node.parentNode < 0 ? null : nodeList[(int)this.node.parentNode];
                return parent;
            }
        }

        public Matrix4 WorldMatrix
        {
            get
            {
                var worldMatrix = Matrix4.Identity;
                if (Parent != null)
                    worldMatrix = Parent.WorldMatrix;
                var translation = Matrix4.CreateTranslation(this.node.defaultTranslation);
                var rotation = Matrix4.CreateFromQuaternion(this.node.defaultRotation);
                return worldMatrix = translation * rotation * worldMatrix;
            }
        }

        RenderModelNodeBlock node;

        public SkeletonNode(RenderModelNodeBlock node)
        {
            this.node = node;
        }
    }

    public class ScenarioObject : IRenderable
    {
        HierarchyModel model;
        List<Mesh> sectionBuffers;
        NodeCollection nodes;

        public StringID activePermuation;

        IList<object> selectedObjects;

        public ScenarioObject()
        {
            activePermuation = StringID.Zero;
            sectionBuffers = new List<Mesh>();
            selectedObjects = new List<object>();
            nodes = new NodeCollection();
        }
        public ScenarioObject(HierarchyModel model)
            : this()
        {
            this.model = model;
            foreach (var section in model.RenderModel.Sections)
            {
                sectionBuffers.Add(new Mesh(section));
            }
            this.nodes = new NodeCollection(model.RenderModel.nodes);
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
            if (program.Name != "system")
            {
                using (program.Use())
                {
                    program["object_extents"] = objectMatrix;
                    program["object_matrix"] = Matrix4.Identity;

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

                }
            }
            if (program.Name == "system")
            {
                using (program.Use())
                using (OpenGL.Disable(EnableCap.DepthTest))
                {
                    foreach (var markerGroup in model.RenderModel.markerGroups)
                    {
                        foreach (var marker in markerGroup.markers)
                        {
                            var nodeIndex = marker.nodeIndex;
                            var translation = marker.translation;
                            var rotation = marker.rotation;
                            var scale = marker.scale;

                            var worldMatrix = this.nodes.GetWorldMatrix(nodeIndex);

                            program["object_matrix"] = worldMatrix;

                            if (selectedObjects.Contains(marker))
                            {
                                GL.VertexAttrib3(1, Color.Tomato.ToFloatRgba());
                            }
                            else
                            {
                                GL.VertexAttrib3(1, Color.WhiteSmoke.ToFloatRgba());
                            }

                            GL.PointSize(5.5f);
                            DebugDrawer.DrawPoint(translation);
                            if (selectedObjects.Contains(marker))
                                DebugDrawer.DrawFrame(translation, rotation);
                        }
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

        internal void Select(IEnumerable<object> collection)
        {
            selectedObjects.Clear();
            foreach (var item in collection)
            {
                selectedObjects.Add(item);
            }
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
