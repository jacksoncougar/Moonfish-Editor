using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{

    class BulletDebugDrawer : BulletSharp.DebugDraw
    {
        Program debugProgram;

        public BulletDebugDrawer(Program program)
        {
            debugProgram = program;
        }

        public override BulletSharp.DebugDrawModes DebugMode
        {
            get
            {
                return BulletSharp.DebugDrawModes.MaxDebugDrawMode;
            }
            set
            {
            }
        }

        public override void DrawBox(ref OpenTK.Vector3 bbMin, ref OpenTK.Vector3 bbMax, OpenTK.Graphics.Color4 color)
        {
            using (Box box = new Box(bbMin, bbMax))
            {
                box.Render(new[] { debugProgram });
            }
        }

        public override void DrawBox(ref OpenTK.Vector3 bbMin, ref OpenTK.Vector3 bbMax, ref OpenTK.Matrix4 trans, OpenTK.Graphics.Color4 color)
        {
            using (debugProgram.Using("object_matrix", trans))
            using (Box box = new Box(bbMin, bbMax))
            {
                GL.VertexAttrib3(1, new[] { 1f, 1f, 1f });
                box.Render(new[] { debugProgram });
            }
        }


        public override void Draw3dText(ref OpenTK.Vector3 location, string textString)
        {
        }

        public override void DrawContactPoint(ref OpenTK.Vector3 pointOnB, ref OpenTK.Vector3 normalOnB, float distance, int lifeTime, OpenTK.Graphics.Color4 color)
        {
        }

        public override void DrawLine(ref OpenTK.Vector3 from, ref OpenTK.Vector3 to, OpenTK.Graphics.Color4 color)
        {
        }

        public override void ReportErrorWarning(string warningString)
        {
        }
    }
}
