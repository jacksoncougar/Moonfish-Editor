using Moonfish.Collision;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Moonfish.Graphics
{
    class Box : Primitive, IRenderable, IDisposable
    {
        int vao, arrayBuffer, elementBuffer;
        int elementCount;

        public Box(Vector3 min, Vector3 max)
        {
            var coordinates = new Vector3[8];
            coordinates[0] = min;
            coordinates[1] = new Vector3(max[0], min[1], min[2]);
            coordinates[2] = new Vector3(min[0], max[1], min[2]);
            coordinates[3] = new Vector3(max[0], max[1], min[2]);
            coordinates[4] = max;
            coordinates[5] = new Vector3(min[0], max[1], max[2]);
            coordinates[6] = new Vector3(max[0], min[1], max[2]);
            coordinates[7] = new Vector3(min[0], min[1], max[2]);
            ushort[] indices = new ushort[]{
                0,1,
                0,2,
                0,7,
                7,5,
                7,6,
                4,6,
                4,5,
                3,1,
                3,2,
                3,4,
                5,2,
                6,1,
            };
            this.elementCount = indices.Length;
            vao = GL.GenVertexArray();
            arrayBuffer = GL.GenBuffer();
            elementBuffer = GL.GenBuffer();
            GL.BindVertexArray(vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Vector3.SizeInBytes * coordinates.Length), coordinates, BufferUsageHint.StaticDraw);

            GL.BindVertexBuffer(0, arrayBuffer, IntPtr.Zero, Vector3.SizeInBytes);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(sizeof(ushort) * indices.Length), indices, BufferUsageHint.StaticDraw);

        }

        public void Render(IEnumerable<Program> shaderPasses)
        {
            GL.BindVertexArray(vao);
            GL.DrawElements(PrimitiveType.Lines, elementCount, DrawElementsType.UnsignedShort, IntPtr.Zero);
        }

        public void Render(IEnumerable<Program> shaderPasses, IList<Tags.IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            GL.DeleteVertexArray(vao);
            GL.DeleteBuffer(arrayBuffer);
            GL.DeleteBuffer(elementBuffer);
        }
    }

    class TranslationGizmo : IRenderable
    {
        public Vector3 origin;
        public ArrowSlider axisU;
        public ArrowSlider axisV;
        public ArrowSlider axisW;

        public TranslationGizmo()
        {
            Vector3 axisUp = Vector3.UnitZ, axisRight = Vector3.UnitX, axisForward = Vector3.UnitY;
            axisU = new ArrowSlider(axisUp, axisRight, axisForward, Color.Blue);
            axisV = new ArrowSlider(axisRight, axisUp, axisForward, Color.Red);
            axisW = new ArrowSlider(axisForward, axisRight, axisUp, Color.Green);

            axisU.WorldMatrixChanged += AxisWorldMatrixChanged;
            axisV.WorldMatrixChanged += AxisWorldMatrixChanged;
            axisW.WorldMatrixChanged += AxisWorldMatrixChanged;
        }

        void AxisWorldMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            var position = e.Matrix.ExtractTranslation();
            origin = position;
            if (axisU.Equals(sender))
                axisU.Position = Vector3.Zero;
            if (axisV.Equals(sender))
                axisV.Position = Vector3.Zero;
            if (axisW.Equals(sender))
                axisW.Position = Vector3.Zero;
        }



        public void Render(IEnumerable<Program> shaderPasses)
        {
            {
                axisU.Render(shaderPasses);
                axisV.Render(shaderPasses);
                axisW.Render(shaderPasses);
            }
        }

        public void Render(IEnumerable<Program> shaderPasses, IList<Tags.IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }
    }

    class ArrowSlider : Primitive, IDisposable, IRenderable
    {
        public delegate void WorldMatrixChangedEventHandler(object sender, MatrixChangedEventArgs e);
        public event WorldMatrixChangedEventHandler WorldMatrixChanged;

        public BulletSharp.CollisionObject CollisionObject { get; private set; }
        public Matrix4 WorldMatrix
        {
            get
            {
                var matrixPosition = Matrix4.CreateTranslation(position);
                var matrixRotation = Matrix4.CreateFromQuaternion(rotation.Normalized());
                var matrix = matrixPosition * matrixRotation;
                return matrix;
            }
        }
        public Vector3 Position
        {
            set
            {
                //var inverserWorldMatrix = Matrix4.Invert(WorldMatrix);
                this.position = value;// Vector3.Transform(value, inverserWorldMatrix);
            }
        }
        // states
        public bool IsSelected { get; private set; }

        // opengl members
        int vao, arrayBuffer, elementBuffer;

        // render elements
        Conic top;

        // fields
        Quaternion rotation;
        Vector3 position;
        Vector3? registrationPoint;
        Vector3 registrationOffset;
        Control parent;

        Color diffuseColor;

        public ArrowSlider(Vector3 axisUp, Vector3 axisRight, Vector3 axisForward, Color color)
            : this()
        {
            var coordinates = new[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1) };
            var indices = new ushort[] { 0, 1 };
            this.top = new Conic(coordinates[1], 0.2f, 0.12f);

            BufferData(coordinates, indices);

            var rotationMatrix = new Matrix3(
                axisRight,
                axisForward,
                axisUp);
            var rotationX = Matrix3.CreateRotationX((float)Math.Acos(Vector3.Dot(Vector3.UnitX, axisRight)));
            var rotationY = Matrix3.CreateRotationY((float)Math.Acos(Vector3.Dot(Vector3.UnitY, axisForward)));
            var rotationZ = Matrix3.CreateRotationZ((float)Math.Acos(Vector3.Dot(Vector3.UnitZ, axisUp)));
            this.rotation = Quaternion.FromMatrix(rotationX * rotationY * rotationZ);
            this.position = new Vector3(0f, 0f, 0f);
            this.diffuseColor = color; // Color.FromArgb(254, 242, 0);


            this.CollisionObject = new BulletSharp.CollisionObject();
            this.CollisionObject.CollisionShape = new BulletSharp.BoxShape(0.1f);
            var halfHeight = (coordinates[1] - coordinates[1] + new Vector3(0, 0, 0.2f)).Length / 2;
            this.registrationOffset = coordinates[1] + (new Vector3(0, 0, 1) * halfHeight);
            UpdateCollisionObject();
            this.CollisionObject.UserObject = this;
        }

        private ArrowSlider()
        {
            this.rotation = Quaternion.FromAxisAngle(Vector3.UnitY, (float)0);
            this.position = new Vector3(0f, 0f, 0f);
            this.diffuseColor = Color.FromArgb(254, 242, 0);
            this.IsSelected = false;
        }

        private void BufferData(Vector3[] coordinates, ushort[] indices)
        {
            this.vao = GL.GenVertexArray();
            this.arrayBuffer = GL.GenBuffer();
            this.elementBuffer = GL.GenBuffer();

            GL.BindVertexArray(vao);

            int arrayBufferDataLength = Vector3.SizeInBytes * coordinates.Length + top.ArrayBufferLength,
                elementBufferDataLength = sizeof(ushort) * indices.Length + top.ElementBufferLength;
            int arrayBufferOffset = 0, elementBufferOffset = 0;
            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(arrayBufferDataLength), IntPtr.Zero, BufferUsageHint.DynamicDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(elementBufferDataLength), IntPtr.Zero, BufferUsageHint.DynamicDraw);

            this.BufferPrimitiveData(coordinates.SelectMany(vector =>
            {
                byte[] buffer = new byte[Vector3.SizeInBytes];
                var array = new[] { vector.X, vector.Y, vector.Z };
                Buffer.BlockCopy(array, 0, buffer, 0, buffer.Length);
                return buffer;
            }).ToArray(), indices, Vector3.SizeInBytes, arrayBuffer, ref arrayBufferOffset, elementBuffer, ref elementBufferOffset);
            top.BufferConeData(arrayBuffer, ref arrayBufferOffset, elementBuffer, ref elementBufferOffset);

            GL.BindVertexBuffer(0, arrayBuffer, (IntPtr)0, Vector3.SizeInBytes);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);
        }

        public void Render(IEnumerable<Program> shaderPasses)
        {
            GL.BindVertexArray(vao);
            {
                if (!IsSelected)
                    GL.VertexAttrib3(1, diffuseColor.ToFloatRgba());
                else
                    GL.VertexAttrib3(1, new[] { 204f / 255f, 202f / 255f, 0f });
                GL.DrawElementsBaseVertex(PrimitiveType.Lines, base.elementCount, DrawElementsType.UnsignedShort, (IntPtr)base.elementBufferOffset, base.elementBufferOffset / sizeof(ushort));

                top.Render(shaderPasses);
            }
            GL.BindVertexArray(0);
        }

        public void Render(IEnumerable<Program> shaderPasses, IList<Tags.IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            GL.DeleteVertexArray(vao);
            GL.DeleteBuffer(arrayBuffer);
            GL.DeleteBuffer(elementBuffer);
            if (disposing)
            {
                UnHook();
                if (top != null) top.Dispose();
            }
        }

        public void Hook(Program program, Control control)
        {
            if (parent != null) UnHook();
            parent = control;
            control.MouseMove += this.OnMouseMove;
            control.MouseUp += this.OnMouseUp;
            control.MouseCaptureChanged += MouseCaptureChanged;
            IsSelected = true;
        }

        private void UnHook()
        {
            if (parent == null) return;
            parent.MouseMove -= this.OnMouseMove;
            parent.MouseUp -= this.OnMouseUp;
            parent = null;
            IsSelected = false;
            registrationPoint = null;
        }

        void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // IN PARAMS: world matrix, view matrix, projection matrix, mouse position

            // Project the mouse coordinates into world-space at the far z-plane
            var distantWorldPoint = Maths.Project(Form1.ActiveCamera.ViewMatrix, Form1.ActiveCamera.ProjectionMatrix, new Vector3(e.X, e.Y, 1f), (Rectangle)Form1.ActiveCamera.Viewport).Xyz;

            // Produce a ray originating at the camera and pointing towards the distant world point^
            var mouseRay = new Ray(Form1.ActiveCamera.Position, distantWorldPoint);

            // Produce a unit-vector pointing towards the camera from this object
            var viewerAxis = (Form1.ActiveCamera.Position - this.WorldMatrix.ExtractTranslation()).Normalized();
            viewerAxis.Normalize();

            // Setup and select the collision plane
            var planeUNormal = this.WorldMatrix.Row0.Xyz;
            var planeVNormal = this.WorldMatrix.Row1.Xyz;
            var translationNormal = this.WorldMatrix.Row2.Xyz;

            // Store the current position vector
            var offset = this.WorldMatrix.Row3.Xyz;

            // Calculate the perpendicularness values
            var cosineToPlaneU = Vector3.Cross(viewerAxis, planeUNormal).LengthFast;
            var cosineToPlaneV = Vector3.Cross(viewerAxis, planeVNormal).LengthFast;

            // Select the most perpendicular plane
            var translationPlaneNormal = planeUNormal;
            if (cosineToPlaneU > cosineToPlaneV)
            {
                translationPlaneNormal = planeVNormal;
            }

            // Produce the plane-distance from origin from this obejcts position vector
            var planeOffset = Vector3.Dot(translationPlaneNormal, offset);

            var translationPlane = new Plane(translationPlaneNormal, planeOffset);

            // Debug drawing code
            DebugDrawer.DrawPlane(translationPlane);
            DebugDrawer.DrawPoint(Form1.ActiveCamera.Position); GL.PointSize(3);
            GL.PointSize(4);
            GL.VertexAttrib3(1, new[] { 25f / 255f, 128f / 255f, 255f / 255f });
            DebugDrawer.DrawPoint(distantWorldPoint);
            GL.PointSize(1);

            // test for collision of mouse ray with plane
            float? fraction;
            if (translationPlane.Intersects(mouseRay, out fraction))
            {
                // Produce the point where the ray intersects the plane
                var intersectionPoint = mouseRay.Origin + fraction.Value * mouseRay.Direction;

                // Produce the point where the mouse originates over this object
                if (registrationPoint == null)
                {
                    var worldPosition = this.WorldMatrix.ExtractTranslation();
                    registrationPoint = intersectionPoint - worldPosition;
                }

                GL.PointSize(2);
                DebugDrawer.DrawPoint(registrationPoint.Value);
                GL.PointSize(6);
                GL.VertexAttrib3(1, new[] { 254f / 255f, 128f / 255f, 0f });
                DebugDrawer.DrawPoint(intersectionPoint);
                GL.PointSize(1);

                // Produce matrices for rotation and inverse rotation
                var inverseRotation = Quaternion.Invert(this.rotation);
                var rotationMatrix = Matrix4.CreateFromQuaternion(rotation);

                // Produce translation value along translation axis
                var translation = intersectionPoint - registrationPoint.Value;
                translation = Vector3.Dot(rotationMatrix.Row2.Xyz, translation) * rotationMatrix.Row2.Xyz;
                // Apply inverse rotation to cancel rotation later
                translation = Vector3.Transform(translation, inverseRotation);

                // Extract the two position components that are not being edited here (the other two axii)
                var componentU = Vector3.Dot(rotationMatrix.Row0.Xyz, offset) * rotationMatrix.Row0.Xyz;
                var componentV = Vector3.Dot(rotationMatrix.Row1.Xyz, offset) * rotationMatrix.Row1.Xyz;

                this.position = translation + componentU + componentV;

                if (WorldMatrixChanged != null)
                {
                    var worldMatrix = this.WorldMatrix;
                    WorldMatrixChanged(this, new MatrixChangedEventArgs(ref worldMatrix));
                }

                UpdateCollisionObject();
            }
        }

        private void UpdateCollisionObject()
        {
            CollisionObject.WorldTransform = Matrix4.CreateTranslation(registrationOffset) * this.WorldMatrix;
        }

        void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            UnHook();
        }

        void MouseCaptureChanged(object sender, EventArgs e)
        {
            UnHook();
        }
    }

    public class Primitive : IDisposable
    {
        protected int elementBufferOffset;
        protected int elementCount;

        protected int arrayBufferOffset;
        protected int arrayBufferCount;
        protected int arrayBufferStride;

        public virtual int ArrayBufferLength { get; protected set; }
        public virtual int ElementBufferLength { get; protected set; }

        protected void BufferPrimitiveData(IList<byte> coordinates, IList<ushort> indices, int stride, int arrayBuffer, ref int arrayBufferOffset, int elementBuffer, ref int elementBufferOffset)
        {
            int lengthOfElementData = indices.Count * sizeof(ushort),
                lengthOfArrayData = coordinates.Count;

            this.arrayBufferOffset = arrayBufferOffset;
            this.arrayBufferCount = lengthOfArrayData / stride;
            this.arrayBufferStride = stride;

            this.elementBufferOffset = elementBufferOffset;
            this.elementCount = indices.Count;

            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)arrayBufferOffset, (IntPtr)(lengthOfArrayData), coordinates.ToArray());

            var check = GL.GetError();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBuffer);
            GL.BufferSubData(BufferTarget.ElementArrayBuffer, (IntPtr)elementBufferOffset, (IntPtr)(lengthOfElementData), indices.ToArray());

            check = GL.GetError();
            arrayBufferOffset += lengthOfArrayData;
            elementBufferOffset += lengthOfElementData;

        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.arrayBufferOffset = 0;
            this.arrayBufferStride = 0;
            this.arrayBufferCount = 0;
            this.elementBufferOffset = 0;
            this.elementCount = 0;

            if (disposing)
            {
            }
        }
    }

    class MouseOrb
    {
        public Vector3 position;
        public float radius;

        public void OnMouseDown(Ray mouseRay, MouseButton mouseButton)
        {

        }
    }

    class Conic : Primitive, IRenderable
    {
        public override int ArrayBufferLength
        {
            get
            {
                return VertexCoordinates.Count * Vector3.SizeInBytes;
            }
        }

        public override int ElementBufferLength
        {
            get
            {
                return Indices.Count * sizeof(ushort);
            }
        }

        public IList<Vector3> VertexCoordinates { get; private set; }
        public IList<ushort> Indices { get; private set; }

        public Conic(Vector3 origin, float height, float width, int sideCount = 16)
        {
            var coordinates = new List<Vector3>();
            var baseCoordinate = origin;
            var apexCoordinate = origin + Vector3.UnitZ * height;

            var circleCoordinates = GenerateCircleCoordinates(width / 2, origin, sideCount);

            coordinates = new List<Vector3>(circleCoordinates.Length + 2);
            coordinates.Add(baseCoordinate);
            coordinates.Add(apexCoordinate);
            coordinates.AddRange(circleCoordinates);

            var indices = GenerateIndices(coordinates);

            this.VertexCoordinates = coordinates;
            this.Indices = indices;
        }

        public void BufferConeData(int arrayBuffer, ref int arrayBufferOffset, int elementBuffer, ref int elementBufferOffset)
        {
            base.BufferPrimitiveData(
                this.VertexCoordinates
                .SelectMany(vector =>
                {
                    byte[] buffer = new byte[Vector3.SizeInBytes];
                    var array = new[] { vector.X, vector.Y, vector.Z };
                    Buffer.BlockCopy(array, 0, buffer, 0, buffer.Length);
                    return buffer;
                }).ToArray(), this.Indices, Vector3.SizeInBytes, arrayBuffer, ref arrayBufferOffset, elementBuffer, ref elementBufferOffset);
        }

        private static IList<ushort> GenerateIndices(IList<Vector3> vertices)
        {
            var indices = new List<ushort>();
            var count = (ushort)(vertices.Count - 2);
            const ushort offset = 1;
            indices.Add(0);
            for (ushort i = (ushort)(count + offset); i > offset; --i)
            {
                indices.Add(i);
            }
            indices.Add((ushort)(count + offset));
            indices.Add(ushort.MaxValue); // reset primitive            
            indices.Add(1);
            for (ushort i = offset + 1; i <= (ushort)(count + offset); ++i)
            {
                indices.Add(i);
            }
            indices.Add(offset + 1);
            return indices;
        }

        private static Vector3[] GenerateCircleCoordinates(float radius, Vector3 origin, int sideCount = 16)
        {
            float theta = 2 * (float)Math.PI / (float)sideCount;
            float cosine = (float)Math.Cos(theta);//precalculate the sine and cosine
            float sine = (float)Math.Sin(theta);

            float x = radius;//we start at angle = 0 
            float y = 0;
            float t;

            Vector3[] coorindates = new Vector3[sideCount];
            for (int i = 0; i < sideCount; i++)
            {
                //output vertex
                coorindates[i] = origin + new Vector3(x, y, 0);

                //apply the rotation matrix
                t = x;
                x = cosine * x - sine * y;
                y = sine * t + cosine * y;
            }
            return coorindates;
        }

        public void Render(IEnumerable<Program> shaderPasses)
        {
            GL.DrawElementsBaseVertex(PrimitiveType.TriangleFan, base.elementCount, DrawElementsType.UnsignedShort, (IntPtr)base.elementBufferOffset, base.elementBufferOffset / sizeof(ushort));
        }

        public void Render(IEnumerable<Program> shaderPasses, IList<Tags.IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }
    }

    struct Cone
    {
        Vector3 base_position;
        Vector3 axis;
        float height;
        float radius;

        public Cone(Vector3 in_base_position, float in_height, float in_radius)
        {
            base_position = in_base_position;
            height = in_height;
            radius = in_radius;
            axis = Vector3.UnitX;
        }

        public float? TestRayIntersection(Ray ray)
        {
            //Ray = P + tV;
            var P = ray.Origin;
            var V = ray.Direction;

            var A = -axis;
            // var X = //Vector3.Perpendicular(axis);
            return null;
        }
    }

    class ConePrimitive
    {

        Vector3[] vertices;
        ushort[] indices;

        public Vector3[] Vertices { get { return vertices; } }
        public ushort[] Indices { get { return indices; } }

        public ConePrimitive(Vector3 apex_position, Vector3 base_position, float radius, ushort segments)
        {
            Vector3 apex_vector = apex_position - base_position;

            Vector3 base_vector = new Vector3(apex_vector.Y, -apex_vector.Z, 0.0f);
            if (apex_vector.X * apex_vector.X > 0) base_vector = new Vector3(apex_vector.Y, -apex_vector.X, apex_vector.Z);

            Vector3.Normalize(base_vector);
            Vector3.Multiply(ref base_vector, radius, out base_vector);

            float theta = (float)(Math.PI * 2) / segments;
            Matrix4 rotation_matrix = Matrix4.CreateFromAxisAngle(apex_vector, theta);

            var vertex_position = base_position + base_vector;
            var vertex_count = segments + 2;
            vertices = new Vector3[vertex_count];
            for (int i = 0; i != segments; ++i)
            {
                vertices[i] = vertex_position;
                Vector3.Transform(ref vertex_position, ref rotation_matrix, out vertex_position);
            }
            vertices[segments] = apex_position;
            vertices[segments + 1] = base_position;

            var index_count = segments * 2 + 5;
            indices = new ushort[index_count];

            int current_index = 0;
            indices[current_index++] = (ushort)(segments + 1);
            for (ushort i = 0; i < segments; ++i)
            {
                indices[current_index++] = i;
            }
            indices[current_index++] = 0;

            indices[current_index++] = ushort.MaxValue;
            indices[current_index++] = (ushort)(segments);
            for (ushort i = 0; i < segments; ++i)
            {
                indices[current_index++] = i;
            }
            indices[current_index++] = 0;

            if (current_index != index_count) throw new IndexOutOfRangeException();
        }
    }
}
