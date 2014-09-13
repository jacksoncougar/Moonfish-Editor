using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    class MouseMoveEventArgs : EventArgs
    {
        public Matrix4 WorldMatrix { get; private set; }
        public Matrix4 ViewMatrix {get; private set;}
        public Matrix4 ProjectionMatrix { get; private set; }
        public Vector2 ScreenCoordinates { get; private set; }
    }

    delegate void OnMouseMoveDelegate(object sender, MouseMoveEventArgs e);
}
