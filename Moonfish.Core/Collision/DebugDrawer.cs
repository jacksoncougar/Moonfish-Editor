using Moonfish.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Collision
{
    public class Point : IRenderable, IDisposable
    {
        int vao, arrayBuffer;

        public Point(Vector3 position)
        {
            vao = GL.GenVertexArray();
            arrayBuffer = GL.GenBuffer();

            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)Vector3.SizeInBytes, ref position, BufferUsageHint.StaticDraw);

            GL.BindVertexBuffer(0, arrayBuffer, IntPtr.Zero, Vector3.SizeInBytes);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);
        }

        public void Render(IEnumerable<Program> shaderPasses)
        {
            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.Points, 0, 1);
        }

        public void Render(IEnumerable<Program> shaderPasses, IList<Tags.IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(vao);
            GL.DeleteBuffer(arrayBuffer);
        }
    }

    static class DebugDrawer
    {
        public static Program debugProgram;



        public static void DrawBox(ref OpenTK.Vector3 bbMin, ref OpenTK.Vector3 bbMax, ref OpenTK.Matrix4 trans, OpenTK.Graphics.Color4 color)
        {
            using (debugProgram.Using("object_matrix", trans))
            using (Box box = new Box(bbMin, bbMax))
            {
                GL.VertexAttrib3(1, new[] { 1f, 1f, 1f });
                box.Render(new[] { debugProgram });
            }
        }

        public static void DrawPoint(Vector3 coordinate)
        {
            using (debugProgram.Use())
            using (Point point = new Point(coordinate))
            {
                point.Render(new[] { debugProgram });
            }
        }


        public static void DrawPlane(Plane plane)
        {
            var x = Vector3.Dot(plane.Normal, Vector3.UnitZ);
            var axis = plane.Normal;
            if (x != 1)
            {
                axis = Vector3.Cross(plane.Normal, Vector3.UnitZ);
                x = (float)Math.Acos(x);
            }

            var rotation = Matrix4.Identity * Matrix4.CreateFromAxisAngle(axis, x);
            var translation = Matrix4.Identity * Matrix4.CreateTranslation(plane.Normal * plane.Distance);
            using (debugProgram.Use())
            using (debugProgram.Using("object_matrix", rotation * translation))
            using (Grid grid = new Grid(new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector2(1, 1), 8, 8))
            {
                grid.Draw();
            }

        }
    }
}
