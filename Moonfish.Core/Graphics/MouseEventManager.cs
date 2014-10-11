using BulletSharp;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{
    /// <summary>
    /// Checks for mouse->object collisions in CollisionWorld and fires mouse events based on collisions
    /// </summary>
    public class MouseEventDispatcher
    {
        private Dictionary<object, IClickable> Hooks = new Dictionary<object, IClickable>( );

        public object SelectedObject
        {
            get { return selectedObject; }
            set
            {
                selectedObject = value; 
                if( SelectedObjectChanged != null )
                    SelectedObjectChanged( this, null );
            }
        }
        object selectedObject;

        public event EventHandler SelectedObjectChanged;

        public void OnMouseDown( CollisionManager collision, Camera viewportCamera, System.Windows.Forms.MouseEventArgs e )
        {
            var callback = SetupCallback( collision, viewportCamera, e );

            if( callback.HasHit && callback.CollisionObject.UserObject is IClickable )
            {
                var @object = callback.CollisionObject.UserObject as IClickable;

                @object.OnMouseDown( this,
                    new MouseEventArgs(
                        viewportCamera,
                        new Vector2( e.X, e.Y ),
                        callback.CollisionObject.WorldTransform.ExtractTranslation( ),
                        e.Button ) { WasHit = true } );
                Hooks[callback.CollisionObject.UserObject] = @object;
            }
        }

        public void OnMouseUp( CollisionManager collision, Camera viewportCamera, System.Windows.Forms.MouseEventArgs e )
        {
            var callback = SetupCallback( collision, viewportCamera, e );

            var @object = (IClickable)( null );
            if( callback.HasHit && callback.CollisionObject.UserObject is IClickable )
            {
                @object = callback.CollisionObject.UserObject as IClickable;
                @object.OnMouseUp( this, new MouseEventArgs(
                        viewportCamera,
                        new Vector2( e.X, e.Y ),
                        callback.CollisionObject.WorldTransform.ExtractTranslation( ),
                        e.Button ) { WasHit = true } );
                SelectedObject = ( @object );
            }
            foreach( var item in Hooks.Where( x => !x.Equals( @object ) ).Select( x => x.Value ) )
            {
                item.OnMouseUp( this, new MouseEventArgs(
                        viewportCamera,
                        new Vector2( e.X, e.Y ),
                        callback.RayToWorld,
                        e.Button ) { WasHit = false } );
            }
            Hooks.Clear( );
        }

        private static CollisionWorld.ClosestRayResultCallback SetupCallback(
            CollisionManager collision, Camera viewportCamera, System.Windows.Forms.MouseEventArgs e )
        {
            var mouse = new
            {
                Near = viewportCamera.Project( new Vector2( e.X, e.Y ), depth: -1 ),
                Far = viewportCamera.Project( new Vector2( e.X, e.Y ), depth: 1 )
            };

            var callback = new CollisionWorld.ClosestRayResultCallback(
                mouse.Near,
                mouse.Far );
            collision.World.RayTest( mouse.Near, mouse.Far, callback );
            return callback;
        }

        internal void OnMouseMove( CollisionManager CollisionManager, Camera ActiveCamera, System.Windows.Forms.MouseEventArgs e )
        {
            //throw new NotImplementedException( );
        }
    }
}
