﻿using BulletSharp;
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

        internal void LoadScenarioCollision( ScenarioStructureBspBlock structureBSP )
        {
            foreach( var cluster in structureBSP.clusters )
            {
                var @object = new RenderObject( cluster ) { DiffuseColour = Colours.LinearRandomDiffuseColor };
                var mesh = new TriangleMesh( false, false );
                var indexedMesh = new IndexedMesh( )
                {
                    VertexType = PhyScalarType.PhyFloat,
                    IndexType = PhyScalarType.PhyShort
                };
                indexedMesh.Allocate(
                    cluster.clusterData[0].section.vertexBuffers[0].vertexBuffer.Data.Length / 12, 16,
                    cluster.clusterData[0].section.stripIndices.Length, 2 );
                using( var data = indexedMesh.LockIndices( ) )
                {
                    var indices = cluster.clusterData[0].section.stripIndices.Select( x => x.index ).ToArray( );
                    data.WriteRange( indices );
                }
                using( var data = indexedMesh.LockVerts( ) )//manually add
                {
                    var vertices = cluster.clusterData[0].section.vertexBuffers[0].vertexBuffer.Data;
                    for (int i = 0; i < vertices.Length / 12; ++i)
                    {
                        data.Write(vertices, i * 12, 12);
                        data.Write((int)0x00000000);
                    }
                }
                mesh.AddIndexedMesh(indexedMesh);
                CollisionObject o = new CollisionObject();
                o.CollisionShape = new BvhTriangleMeshShape(mesh, false);
                World.AddCollisionObject(o);
                break;
            }
            //var d = new BvhTriangleMeshShape(
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
                break;
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
        MultiValueDictionary<TagIdent, ScenarioObject> objectInstances;


        internal void Add( TagIdent ident, ScenarioObject @object )
        {
            objectInstances.Add( ident, @object );
        }

        public MeshManager( Program program, Program systemProgram )
        {
            objectInstances = new MultiValueDictionary<TagIdent, ScenarioObject>( );
            this.program = program;
            this.systemProgram = systemProgram;
        }

        public void LoadCollision( CollisionManager collision )
        {
            this.Collision = collision;
            foreach( var item in objectInstances.SelectMany( x => x.Value ) )
            {
                Collision.World.AddCollisionObject( item.CollisionObject );
            }
        }

        public void LoadScenario( MapStream map )
        {
            this.scenario = map["scnr", ""].Deserialize( );

            LoadInstances(
                scenario.scenery.Select( x => (IH2ObjectInstance)x ).ToList( ),
                scenario.sceneryPalette.Select( x => (IH2ObjectPalette)x ).ToList( ) );
            LoadInstances(
                scenario.crates.Select( x => (IH2ObjectInstance)x ).ToList( ),
                scenario.cratesPalette.Select( x => (IH2ObjectPalette)x ).ToList( ) );
            LoadInstances(
                scenario.weapons.Select( x => (IH2ObjectInstance)x ).ToList( ),
                scenario.weaponPalette.Select( x => (IH2ObjectPalette)x ).ToList( ) );
            LoadNetgameEquipment(
                scenario.netgameEquipment.Select( x => x ).ToList( ) );

            Log.Info( GL.GetError( ).ToString( ) );
        }

        private void LoadNetgameEquipment( List<ScenarioNetgameEquipmentBlock> list )
        {
            foreach( var item in list.Where( x => !TagIdent.IsNull( x.itemVehicleCollection.Ident )
                && ( x.itemVehicleCollection.Class.ToString( ) == "vehc" || x.itemVehicleCollection.Class.ToString( ) == "itmc" ) ) )
            {
                try
                {
                    Add( item.itemVehicleCollection.Ident, new ScenarioObject( Halo2.GetReferenceObject<ModelBlock>(
                    Halo2.GetReferenceObject<ObjectBlock>(
                    item.itemVehicleCollection.Class.ToString( ) == "itmc" ?
                    Halo2.GetReferenceObject<ItemCollectionBlock>( item.itemVehicleCollection ).itemPermutations.First( ).item
                    : Halo2.GetReferenceObject<VehicleCollectionBlock>( item.itemVehicleCollection ).vehiclePermutations.First( ).vehicle ).model ) )
                        {
                            WorldMatrix = item.WorldMatrix
                        }
                        );
                }
                catch( NullReferenceException )
                {
                }
            }
        }

        private void LoadInstances( List<IH2ObjectInstance> instances, List<IH2ObjectPalette> objectPalette )
        {
            var join = ( from instance in instances
                         join palette in objectPalette on (int)instance.PaletteIndex equals objectPalette.IndexOf( palette ) into gj
                         from items in gj.DefaultIfEmpty( )
                         select new { instance, Object = items.ObjectReference } ).ToArray( );

            foreach( var item in join )
            {
                Add( item.Object.Ident, new ScenarioObject(
                    Halo2.GetReferenceObject<ModelBlock>( Halo2.GetReferenceObject<ObjectBlock>( item.Object ).model ) )
                    {
                        WorldMatrix = item.instance.WorldMatrix
                    }
                );
            }
        }

        public void Draw( )
        {
            if( scenario == null ) return;
            foreach( var item in objectInstances.SelectMany( x => x.Value ) )
            {
                program[Uniforms.WorldMatrix] = item.WorldMatrix;
                IRenderable @object = item;
                @object.Render( new[] { program } );
            }
        }

        public void Add( TagIdent item )
        {
            var data = Halo2.GetReferenceObject( item );
            //objects[item] = new ScenarioObject( (ModelBlock)data );
        }

        public void Draw( TagIdent item )
        {
            if( objectInstances.ContainsKey( item ) )
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

        internal void Remove( TagIdent item )
        {
            this.objectInstances.Remove( item );
        }

        internal void Clear( )
        {
            this.objectInstances.Clear( );
        }
    }
}
