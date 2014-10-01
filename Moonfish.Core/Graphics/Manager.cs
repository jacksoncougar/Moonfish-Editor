using BulletSharp;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public class CollisionManager
    {
        public CollisionWorld World { get; private set; }

        public CollisionManager( Program debug )
        {
            var defaultCollisionConfiguration = new DefaultCollisionConfiguration( );
            var collisionDispatcher = new CollisionDispatcher( );
            var worldAabbMin = new Vector3( -1000, -1000, -1000 );
            var worldAabbMax = new Vector3( 1000, 1000, 1000 );
            var broadphase = new AxisSweep3( worldAabbMin, worldAabbMax );
            this.World = new CollisionWorld( collisionDispatcher, broadphase, defaultCollisionConfiguration );
            if( debug != null )
                this.World.DebugDrawer = new BulletDebugDrawer( debug );
        }
    }

    public class LevelManager
    {
        Program shaded, system;

        public ScenarioStructureBspBlock Level { get; private set; }
        public List<RenderObject> ClusterObjects { get; private set; }
        public List<RenderObject> InstancedGeometryObjects { get; private set; }

        public LevelManager( params Program[] programs )
        {
            shaded = programs.Length > 0 ? programs[0] : null;
            system = programs.Length > 1 ? programs[1] : null;
        }

        public void LoadScenarioStructure( ScenarioStructureBspBlock levelBlock )
        {
            this.Level = levelBlock;
            ClusterObjects = new List<RenderObject>( );
            InstancedGeometryObjects = new List<RenderObject>( );
            foreach( var cluster in this.Level.clusters )
            {
                ClusterObjects.Add( new RenderObject( cluster ) { DiffuseColour = Colours.LinearRandomDiffuseColor } );
            }
            foreach( var item in this.Level.instancedGeometriesDefinitions )
            {
                InstancedGeometryObjects.Add( new RenderObject( item ) { DiffuseColour = Color.DarkRed } );
            }
        }

        public void RenderLevel( )
        {
            if( Level == null ) return;
            shaded[Uniforms.WorldMatrix] = Matrix4.Identity;
            foreach( var item in ClusterObjects )
                item.Render( shaded );
            foreach( var instance in this.Level.instancedGeometryInstances )
            {
                shaded[Uniforms.WorldMatrix] = instance.WorldMatrix;
                InstancedGeometryObjects[(int)instance.instanceDefinition].Render( shaded );
            }
        }
    }
    public class MeshManager
    {
        CollisionManager Collision { get; set; }
        ScenarioBlock scenario;
        Program program;
        Program systemProgram;
        Dictionary<TagIdent, List<ScenarioObject>> objects;

        internal void Add( ModelBlock model, TagIdent id )
        {
            //objects.Contains
         //   objects[id] = {new ScenarioObject( model )};
        }

        public List<ScenarioObject> this[TagIdent ident]
        {
            get { return this.objects.ContainsKey( ident ) ? objects[ident] : null; }
        }

        public MeshManager( Program program, Program systemProgram )
        {
            objects = new Dictionary<TagIdent, List<ScenarioObject>>( );
            this.program = program;
            this.systemProgram = systemProgram;
        }

        public void LoadCollision( CollisionManager collision )
        {
            this.Collision = collision;
            foreach( var item in objects.SelectMany( x => x.Value ) )
            {
                Collision.World.AddCollisionObject( item.CollisionObject );
            }
        }

        public void LoadScenario( MapStream map )
        {
            this.scenario = map["scnr", ""].Deserialize( );
            var scenery = scenario.sceneryPalette
                .Where( x => !TagIdent.IsNull( x.name.TagID ) )
                .Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );
            var weapons = scenario.weaponPalette
                .Where( x => !TagIdent.IsNull( x.name.TagID ) )
                .Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );
            var vehicles = scenario.vehiclePalette
                .Where( x => !TagIdent.IsNull( x.name.TagID ) )
                .Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );
            var crates = scenario.cratesPalette
                .Where( x => !TagIdent.IsNull( x.name.TagID ) )
                .Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );
            var equipment = scenario.equipmentPalette
                .Where( x => !TagIdent.IsNull( x.name.TagID ) )
                .Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );

            var items = scenery
            .Concat( weapons )
            .Concat( vehicles )
            .Concat( crates )
            .Concat( equipment );

            foreach( var item in items )
            {
                Add( Halo2.GetReferenceObject( item.Tag.model ), item.Ident );
            }

            Log.Info( GL.GetError( ).ToString( ) );
        }

        public void Draw( )
        {
            if( scenario == null ) return;
            RenderPalette( scenario.sceneryPalette, scenario.scenery );
            RenderPalette( scenario.vehiclePalette, scenario.vehicles );
            RenderPalette( scenario.equipmentPalette, scenario.equipment );
            RenderPalette( scenario.weaponPalette, scenario.weapons );
            RenderPalette( scenario.cratesPalette, scenario.crates );
        }

        public void Add( TagIdent item )
        {
            var data = Halo2.GetReferenceObject( item );
            //objects[item] = new ScenarioObject( (ModelBlock)data );
        }

        public void Draw( TagIdent item )
        {
            if( objects.ContainsKey( item ) )
            {
                //IRenderable @object = objects[item] as IRenderable;
                //@object.Render( new[] { program, systemProgram } );
            }
            else
            {
                var data = Halo2.GetReferenceObject( item );
                //objects[item] = new ScenarioObject( (ModelBlock)data );
            }
        }

        private void RenderPalette( IList<IH2ObjectPalette> palette, IEnumerable<IH2ObjectInstance> instances )
        {
            foreach( var instance in instances )
            {
                using( program.Use( ) )
                {
                    //if( (int)instance.PaletteIndex < 0 ) continue;
                    //program[Uniforms.WorldMatrix] = (Matrix4)instance.WorldMatrix;
                    //IRenderable @object = objects[palette[(int)instance.PaletteIndex].ObjectReference.TagID];
                    //@object.Render( new[] { program } );
                }
            }
        }

        internal void Remove( TagIdent item )
        {
            this.objects.Remove( item );
        }

        internal void Clear( )
        {
            this.objects.Clear( );
        }
    }
}
