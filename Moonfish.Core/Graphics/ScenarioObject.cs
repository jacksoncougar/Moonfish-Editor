using Moonfish.Collision;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public interface ISelectable
    {
        void Select( );
    }

    public interface IRenderable
    {
        void Render( IEnumerable<Program> shaderPasses );
    }

    public class NodeCollection : List<RenderModelNodeBlock>
    {
        public NodeCollection( ) : base( ) { }
        public NodeCollection( int capacity )
            : base( capacity )
        {
        }
        public NodeCollection( IEnumerable<RenderModelNodeBlock> collection )
            : base( collection )
        {
        }
        public Matrix4 GetWorldMatrix( int nodeIndex )
        {
            return GetWorldMatrix( this[nodeIndex] );
        }
        public Matrix4 GetWorldMatrix( RenderModelNodeBlock node )
        {
            if( !this.Contains( node ) ) throw new ArgumentOutOfRangeException( );

            var worldMatrix = node.WorldMatrix;
            if( (int)node.parentNode < 0 ) return worldMatrix;
            return worldMatrix * GetWorldMatrix( this[(int)node.parentNode] );
        }
    }


    public class ScenarioObject : RenderObject, IRenderable, IEnumerable<BulletSharp.CollisionObject>
    {
        ModelBlock Model { get; set; }

        public NodeCollection Nodes { get; private set; }
        public Dictionary<RenderModelMarkerBlock, MarkerWrapper> Markers;
        public StringID activePermuation;

        IList<object> selectedObjects;

        public ScenarioObject( ):base()
        {
            activePermuation = StringID.Zero;
            selectedObjects = new List<object>( );
            Nodes = new NodeCollection( );
        }
        public ScenarioObject( ModelBlock model )
            : this( )
        {
            this.Model = model;
            foreach( var section in model.RenderModel.sections )
            {
                base.sectionBuffers.Add( new Mesh( section.sectionData[0].section ) );
            }
            this.Nodes = new NodeCollection( model.RenderModel.nodes );
            this.Markers = model.RenderModel.markerGroups.SelectMany( x => x.Markers ).ToDictionary( x => x, x => new MarkerWrapper( x, this.Nodes ) );
        }

        public IEnumerable<StringID> Permutations
        {
            get
            {
                var query = Model.RenderModel.regions.SelectMany( x => x.permutations ).Select( x => x.name ).Distinct( );
                return query;
            }
        }

        void Render( IEnumerable<Program> shaderPasses )
        {
            foreach( var program in shaderPasses )
            {
                RenderPass( program );
            }

        }

        private void RenderPass( Program program )
        {
            if( program.Name != "system" )
            {
                using( program.Use( ) )
                {
                    var extents = Model.RenderModel.compressionInfo[0].ToExtentsMatrix( );
                    program[Uniforms.NormalizationMatrix] = extents;
                    foreach( var region in Model.RenderModel.regions )
                    {
                        var section_index = region.permutations[0].l6SectionIndexHollywood;
                        var mesh = sectionBuffers[section_index];
                        using( mesh.Bind( ) )
                        {
                            GL.UseProgram( program.ID );
                            foreach( var part in mesh.Parts )
                            {
                                GL.DrawElements( PrimitiveType.TriangleStrip, part.stripLength, DrawElementsType.UnsignedShort,
                                    (IntPtr)( part.stripStartIndex * 2 ) ); OpenGL.ReportError( );
                            }
                        }
                    }
                }
            }
            if( program.Name == "system" )
            {
                using( program.Use( ) )
                using( OpenGL.Disable( EnableCap.DepthTest ) )
                {
                    foreach( var markerGroup in Model.RenderModel.markerGroups )
                    {
                        foreach( var marker in markerGroup.markers )
                        {
                            var nodeIndex = marker.nodeIndex;
                            var translation = marker.translation;
                            var rotation = marker.rotation;
                            var scale = marker.scale;

                            var worldMatrix = this.Nodes.GetWorldMatrix( nodeIndex );

                            program[Uniforms.WorldMatrix] = worldMatrix;

                            if( selectedObjects.Contains( marker ) )
                            {
                                GL.VertexAttrib3( 1, Color.Black.ToFloatRgba( ) );
                                DebugDrawer.DrawPoint( translation, 7 );
                                GL.VertexAttrib3( 1, Color.Tomato.ToFloatRgba( ) );
                                DebugDrawer.DrawPoint( translation, 4 );
                            }
                            else
                            {
                                GL.VertexAttrib3( 1, Color.White.ToFloatRgba( ) );
                                DebugDrawer.DrawPoint( translation, 7 );
                                GL.VertexAttrib3( 1, Color.SkyBlue.ToFloatRgba( ) );
                                DebugDrawer.DrawPoint( translation, 3 );
                            }

                            DebugDrawer.DrawPoint( translation, 5 );
                        }
                    }
                }
            }
        }

        void IRenderable.Render( IEnumerable<Program> shaderPasses )
        {
            this.Render( shaderPasses );
        }

        internal void Select( IEnumerable<object> collection )
        {
            selectedObjects.Clear( );
            foreach( var item in collection )
            {
                selectedObjects.Add( item );
            }
        }

        IEnumerator<BulletSharp.CollisionObject> IEnumerable<BulletSharp.CollisionObject>.GetEnumerator( )
        {

            foreach( var markerGroup in Model.RenderModel.markerGroups )
            {
                foreach( var marker in markerGroup.markers )
                {
                    var collisionObject = new BulletSharp.CollisionObject( );
                    collisionObject.CollisionShape = new BulletSharp.BoxShape( 0.045f );
                    collisionObject.WorldTransform = Matrix4.CreateTranslation( marker.translation ) * this.Nodes.GetWorldMatrix( marker.nodeIndex );
                    collisionObject.UserObject = this.Markers[marker];
                    yield return collisionObject;

                    var setPropertyMethodInfo = typeof( BulletSharp.CollisionObject ).GetProperty( "WorldTransform" ).GetSetMethod( );
                    var setProperty = Delegate.CreateDelegate( typeof( Action<Matrix4> ), collisionObject, setPropertyMethodInfo );

                    this.Markers[marker].MarkerUpdatedCallback += (Action<Matrix4>)setProperty;
                }
            }
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator( )
        {
            return null;
        }

        internal void Save( MapStream map )
        {
            //BinaryWriter binaryWriter = new BinaryWriter( map );
            //map[model.renderModel.TagID].Seek();
            // this.model.RenderModel.Write(binaryWriter);
        }
    }

    class ScenarioObjectd
    {
        ModelBlock model;

        public ScenarioObjectd( ModelBlock test )
        {
            this.model = test;
            ActivePermutation = StringID.Zero;
        }

        public StringID ActivePermutation { get; set; }

        public IEnumerable<StringID> Permutations
        {
            get
            {
                var query = model.RenderModel.regions.SelectMany( x => x.permutations ).Select( x => x.name ).Distinct( );
                return query;
            }
        }

        public void Draw( )
        {
        }
    }
}
