using Moonfish.Collision;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public interface ISelectable
    {
        void Select();
    }

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

    public class ScenarioObject : IRenderable, IEnumerable<BulletSharp.CollisionObject>
    {
        HierarchyModel model;
        List<Mesh> sectionBuffers;
        public NodeCollection nodes;

        public Dictionary<RenderModelMarkerBlock, MarkerWrapper> markers;

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
            foreach (var section in model.RenderModel.sections)
            {
                sectionBuffers.Add(new Mesh(section));
            }
            this.nodes = new NodeCollection(model.RenderModel.nodes);
            this.markers = model.RenderModel.markerGroups.SelectMany(x => x.Markers).ToDictionary(x => x, x => new MarkerWrapper(x, this.nodes));
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
            var anyProgram = shaderPasses.First();
            anyProgram.UniformBuffer.BufferUniformData(UniformBuffer.Uniform.WorldMatrix, Matrix4.Identity);
            anyProgram.UniformBuffer.BufferUniformData(UniformBuffer.Uniform.WorldMatrix, model.RenderModel.compressionInfo[0].ToExtentsMatrix());

            foreach (var program in shaderPasses)
            {
                RenderPass(program);
            }

        }

        private void RenderPass(Program program)
        {
            if (program.Name != "system")
            {
                using (program.Use())
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

                            program.UniformBuffer.BufferUniformData(UniformBuffer.Uniform.WorldMatrix, ref worldMatrix);

                            if (selectedObjects.Contains(marker))
                            {
                                GL.VertexAttrib3(1, Color.Black.ToFloatRgba());
                                DebugDrawer.DrawPoint(translation, 7);
                                GL.VertexAttrib3(1, Color.Tomato.ToFloatRgba());
                                DebugDrawer.DrawPoint(translation, 4);
                            }
                            else
                            {
                                GL.VertexAttrib3(1, Color.White.ToFloatRgba());
                                DebugDrawer.DrawPoint(translation, 7);
                                GL.VertexAttrib3(1, Color.SkyBlue.ToFloatRgba());
                                DebugDrawer.DrawPoint(translation, 3);
                            }

                            DebugDrawer.DrawPoint(translation, 5);
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

        IEnumerator<BulletSharp.CollisionObject> IEnumerable<BulletSharp.CollisionObject>.GetEnumerator()
        {

            foreach (var markerGroup in model.RenderModel.markerGroups)
            {
                foreach (var marker in markerGroup.markers)
                {
                    var collisionObject = new BulletSharp.CollisionObject();
                    collisionObject.CollisionShape = new BulletSharp.BoxShape(0.045f);
                    collisionObject.WorldTransform = Matrix4.CreateTranslation(marker.translation) * this.nodes.GetWorldMatrix(marker.nodeIndex);
                    collisionObject.UserObject = this.markers[marker];
                    yield return collisionObject;

                    var setPropertyMethodInfo = typeof(BulletSharp.CollisionObject).GetProperty("WorldTransform").GetSetMethod();
                    var setProperty = Delegate.CreateDelegate(typeof(Action<Matrix4>), collisionObject, setPropertyMethodInfo);

                    this.markers[marker].MarkerUpdatedCallback += (Action<Matrix4>)setProperty;
                }
            }
        }

        void marker_MarkerUpdated(object sender, EventArgs e)
        {
            var markerQuery = model.RenderModel.markerGroups.SelectMany(x => x.markers).Where(x => x.Equals(sender)).FirstOrDefault();
            if (markerQuery != null)
            {

            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return null;
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
