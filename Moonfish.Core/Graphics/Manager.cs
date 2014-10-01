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
                ClusterObjects.Add( new RenderObject( cluster ) { DiffuseColour = Color.Tan } );
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
        ScenarioBlock scenario;
        Program program;
        Program systemProgram;
        Dictionary<TagIdent, ScenarioObject> objects;

        internal void Add( ModelBlock model, TagIdent id )
        {
            objects[id] = new ScenarioObject( model );
        }

        public ScenarioObject this[TagIdent ident]
        {
            get { return this.objects.ContainsKey( ident ) ? objects[ident] : null; }
        }

        public MeshManager( Program program, Program systemProgram )
        {
            objects = new Dictionary<TagIdent, ScenarioObject>( );
            this.program = program;
            this.systemProgram = systemProgram;
        }

        public void LoadScenario( MapStream map )
        {
            this.scenario = map["scnr", ""].Deserialize( );
            var scenery = scenario.sceneryPalette.Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );
            var weapons = scenario.weaponPalette.Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );
            var vehicles = scenario.vehiclePalette.Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );
            var crates = scenario.cratesPalette.Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );
            var equipment = scenario.equipmentPalette.Select( x => new { Tag = (ObjectBlock)map[x.name.TagID].Deserialize( ), Ident = x.name.TagID } ).ToArray( );

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
            objects[item] = new ScenarioObject( (ModelBlock)data );
        }

        public void Draw( TagIdent item )
        {
            if( objects.ContainsKey( item ) )
            {
                IRenderable @object = objects[item] as IRenderable;
                @object.Render( new[] { program, systemProgram } );
            }
            else
            {
                var data = Halo2.GetReferenceObject( item );
                objects[item] = new ScenarioObject( (ModelBlock)data );
            }
        }

        private void RenderPalette( IList<IH2ObjectPalette> palette, IEnumerable<IH2ObjectInstance> instances )
        {
            foreach( var instance in instances )
            {
                using( program.Use( ) )
                {
                    if( (int)instance.PaletteIndex < 0 ) continue;
                    program[Uniforms.WorldMatrix] = (Matrix4)instance.WorldMatrix;
                    IRenderable @object = objects[palette[(int)instance.PaletteIndex].ObjectReference.TagID];
                    @object.Render( new[] { program } );
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
