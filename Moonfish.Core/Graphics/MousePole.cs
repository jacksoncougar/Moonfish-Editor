using Moonfish.Collision;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Moonfish.Graphics
{
    public class MousePole2D : IDisposable
    {
        public Vector3 Position
        {
            get { return this.Position; }
            set
            {
                var previousWorldMatrix = Matrix4.CreateTranslation(this.position);
                var worldMatrix = Matrix4.CreateTranslation(value);
                this.position = value;
                if (WorldMatrixChanged != null)
                    WorldMatrixChanged(this, new MatrixChangedEventArgs(previousWorldMatrix, worldMatrix));
            }
        }
        public event MatrixChangedEventHandler WorldMatrixChanged;

        Vector3 position;
        Vector3 origin;
        Vector3 right, forward, up;
        int[] glBuffers;
        int elementCount;

        public bool Hidden { get; private set; }

        BulletSharp.CollisionObject rightContact, forwardContact, upContact;
        SelectedAxis selectedAxis;

        Vector3 worldRegistrationPosition, lineRegistration;
        Matrix4 viewMatrix, projectionMatrix;
        Rectangle viewport;

        [Flags]
        public enum SelectedAxis
        {
            None = 0,
            U = 1,
            V = 2,
            W = 4
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (Hidden) return;
            var scene = sender as Form1;
            if (scene != null && e.Button == MouseButtons.Left)
            {
                var raycast = new BulletSharp.RaycastInfo();
                var callback = new BulletSharp.CollisionWorld.ClosestRayResultCallback(e.MouseRay.Origin, e.MouseRay.Origin + e.MouseRay.Direction * e.MouseRayFarPoint);
                var collisionWorld = scene.collisionWorld;
                collisionWorld.RayTest(e.MouseRay.Origin, e.MouseRay.Origin + e.MouseRay.Direction * e.MouseRayFarPoint, callback);

                if (callback.HasHit)
                {
                    if (callback.CollisionObject == rightContact)
                        this.selectedAxis = SelectedAxis.U;
                    else if (callback.CollisionObject == forwardContact)
                        this.selectedAxis = SelectedAxis.V;
                    else if (callback.CollisionObject == upContact)
                        this.selectedAxis = SelectedAxis.W;
                    else return;
                    worldRegistrationPosition = callback.HitPointWorld - this.position;
                }
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (Hidden) return;
            if (e.Button == MouseButtons.Left)
            {
                selectedAxis = SelectedAxis.None;
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Hidden) return;
            if (selectedAxis != SelectedAxis.None)
            {
                Vector3 intersection;

                var registrationOrigin = ProjectPoint(worldRegistrationPosition);
                var registrationMouse = ProjectScreenPoint(new Vector3(e.ScreenCoordinates));

                var mouseRay = new Ray(
                    Maths.Project(viewMatrix, projectionMatrix, registrationMouse.Xy, depth: -1, viewport: viewport).Xyz,
                    Maths.Project(viewMatrix, projectionMatrix, registrationMouse.Xy, depth: 1, viewport: viewport).Xyz
                    );

                var registrationRay = new Ray(
                    Maths.Project(viewMatrix, projectionMatrix, registrationOrigin.Xy, depth: -1, viewport: viewport).Xyz,
                    Maths.Project(viewMatrix, projectionMatrix, registrationOrigin.Xy, depth: 1, viewport: viewport).Xyz
                    );


                var viewerAxis = (mouseRay.Origin - origin).Normalized();
                viewerAxis.Normalize();

                // Setup and select the collision plane
                var planeUNormal = new Vector3(0, 0, 0);
                var planeVNormal = new Vector3(0, 0, 0);
                var translationNormal = new Vector3(0, 0, 0);
                if (selectedAxis.HasFlag(SelectedAxis.U))
                {
                    planeUNormal = up;
                    planeVNormal = forward;
                    translationNormal = right;
                }
                else if (selectedAxis.HasFlag(SelectedAxis.V))
                {
                    planeUNormal = right;
                    planeVNormal = up;
                    translationNormal = forward;
                }
                else if (selectedAxis.HasFlag(SelectedAxis.W))
                {
                    planeUNormal = right;
                    planeVNormal = forward;
                    translationNormal = up;
                }
                else return;

                Vector3.Normalize(ref planeUNormal, out planeUNormal);
                Vector3.Normalize(ref planeVNormal, out planeVNormal);
                Vector3.Normalize(ref translationNormal, out translationNormal);

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
                var planeOffset = Vector3.Dot(translationPlaneNormal, origin);

                var translationPlane = new Plane(translationPlaneNormal, -planeOffset);

                float? hit, registrationHit;
                if (translationPlane.Intersects(mouseRay, out hit)
                    && translationPlane.Intersects(registrationRay, out registrationHit))
                {
                    //// Debug drawing code
                    //GL.VertexAttrib3(1, new[] { 230f / 255f, 128f / 255f, 0f / 255f });
                    //DebugDrawer.DrawPlane(translationPlane);
                    //using (Form1.ScreenProgram.Use())
                    //{
                    //    GL.VertexAttrib3(1, new[] { 225f / 255f, 128f / 255f, 255f / 255f });
                    //    DebugDrawer.DrawPoint(mouseRay.Origin + mouseRay.Direction * hit.Value, pointSize: 7);
                    //    GL.VertexAttrib3(1, new[] { 15f / 255f, 128f / 255f, 255f / 255f });
                    //    DebugDrawer.DrawPoint(registrationRay.Origin + registrationRay.Direction * registrationHit.Value, pointSize: 9);
                    //}
                    var componentU = Vector3.Dot(planeUNormal, this.position) * planeUNormal;
                    var componentV = Vector3.Dot(planeVNormal, this.position) * planeVNormal;
                    var dot = Vector3.Dot(translationNormal, mouseRay.Origin + mouseRay.Direction * hit.Value);
                    var translation = translationNormal * Vector3.Dot(translationNormal, mouseRay.Origin + mouseRay.Direction * hit.Value);
                    var registrationOffset = translationNormal * Vector3.Dot(translationNormal, worldRegistrationPosition);
                    var actualtranslation = mouseRay.Origin + mouseRay.Direction * hit.Value;
                    this.Position = translation - registrationOffset + componentU + componentV;

                }

            }

            //    var registration = //ProjectPoint(e, this.worldRegistrationPosition);
            //var mousePosition = 
        }

        public void OnCameraUpdate(object sender, CameraEventArgs e)
        {
            if (Hidden) return;
            var scale = e.Camera.CreateScale(origin, 0.5f, pixelSize: 45);
            var scaleMatrix = Matrix4.CreateScale(scale, scale, scale);

            this.origin = this.position + Vector3.Transform(new Vector3(0, 0, 0), scaleMatrix);
            this.right = Vector3.Transform(new Vector3(1, 0, 0), scaleMatrix);
            this.forward = Vector3.Transform(new Vector3(0, 1, 0), scaleMatrix);
            this.up = Vector3.Transform(new Vector3(0, 0, 1), scaleMatrix);

            var contactSize = 0.2f * scale;

            rightContact.CollisionShape = new BulletSharp.SphereShape(contactSize);
            forwardContact.CollisionShape = new BulletSharp.SphereShape(contactSize);
            upContact.CollisionShape = new BulletSharp.SphereShape(contactSize);

            rightContact.WorldTransform = Matrix4.CreateTranslation(this.origin + right);
            forwardContact.WorldTransform = Matrix4.CreateTranslation(this.origin + forward);
            upContact.WorldTransform = Matrix4.CreateTranslation(this.origin + up);

            this.Dispose(false);
            BufferData(e.Camera);
        }


        private Vector3 ProjectScreenPoint(Vector3 screenCoordinate)
        {
            var axisDirection = origin;
            switch (selectedAxis)
            {
                case SelectedAxis.U:
                    axisDirection = origin + right;
                    break;
                case SelectedAxis.V:
                    axisDirection = origin + forward;
                    break;
                case SelectedAxis.W:
                    axisDirection = origin + up;
                    break;
            }
            var pointA = Maths.UnProject(viewMatrix * projectionMatrix, origin, viewport, Maths.ProjectionTarget.View);
            var pointB = Maths.UnProject(viewMatrix * projectionMatrix, axisDirection, viewport, Maths.ProjectionTarget.View);

            var lineNormal = (pointB - pointA).Normalized();
            var dotProduct = Vector3.Dot(screenCoordinate - pointA, lineNormal);
            var intersection = pointA + lineNormal * dotProduct;
            return intersection;
        }

        /// <summary>
        /// Projects the worldCoordinate onto the currently selected axis
        /// </summary>
        /// <param name="worldCoordinate"></param>
        /// <returns>projected point in screen-space</returns>
        private Vector3 ProjectPoint(Vector3 worldCoordinate)
        {
            var axisDirection = origin;
            switch (selectedAxis)
            {
                case SelectedAxis.U:
                    axisDirection = origin + right;
                    break;
                case SelectedAxis.V:
                    axisDirection = origin + forward;
                    break;
                case SelectedAxis.W:
                    axisDirection = origin + up;
                    break;
            }
            var pointA = Maths.UnProject(viewMatrix * projectionMatrix, origin, viewport, Maths.ProjectionTarget.View);
            var pointB = Maths.UnProject(viewMatrix * projectionMatrix, axisDirection, viewport, Maths.ProjectionTarget.View);
            var pointC = Maths.UnProject(viewMatrix * projectionMatrix, worldCoordinate, viewport, Maths.ProjectionTarget.View);


            var lineNormal = (pointB - pointA).Normalized();
            var dotProduct = Vector3.Dot(pointC - pointA, lineNormal);
            var intersection = pointA + lineNormal * dotProduct;
            return intersection;
        }

        public MousePole2D(Camera camera)
        {
            var scale = camera.CreateScale(origin, 0.5f, pixelSize: 85);
            var scaleMatrix = Matrix4.CreateScale(scale, scale, scale);

            this.origin = Vector3.Transform(new Vector3(0, 0, 0), scaleMatrix);
            this.right = Vector3.Transform(new Vector3(1, 0, 0), scaleMatrix);
            this.forward = Vector3.Transform(new Vector3(0, 1, 0), scaleMatrix);
            this.up = Vector3.Transform(new Vector3(0, 0, 1), scaleMatrix);

            rightContact = new BulletSharp.CollisionObject() { UserObject = this };
            forwardContact = new BulletSharp.CollisionObject() { UserObject = this };
            upContact = new BulletSharp.CollisionObject() { UserObject = this };

            BufferData(camera);
            camera.ViewMatrixChanged += camera_ViewMatrixChanged;
            camera.Viewport.ProjectionChanged += Viewport_ProjectionChanged;
            camera.Viewport.ViewportChanged += Viewport_ViewportChanged;
            OnCameraUpdate(this, new CameraEventArgs(camera));
        }

        void Viewport_ViewportChanged(object sender, Viewport.ViewportEventArgs e)
        {
            this.viewport = e.Viewport;
        }

        void Viewport_ProjectionChanged(object sender, MatrixChangedEventArgs e)
        {
            this.projectionMatrix = e.Matrix;
        }

        void camera_ViewMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            this.viewMatrix = e.Matrix;
        }

        public void Render(Program shaderProgram)
        {
            if (Hidden) return;
            using (shaderProgram.Use())
            {
                shaderProgram["object_matrix"] = Matrix4.Identity;
                GL.BindVertexArray(glBuffers[0]);
                GL.DrawElements(BeginMode.Lines, elementCount, DrawElementsType.UnsignedShort, 0);
                GL.BindVertexArray(0);
            }
        }

        private void BufferData(Camera camera)
        {

            var coordinates = new[] { origin, origin, origin, origin + right, origin + forward, origin + up };

            var indices = new ushort[] { 0, 3, 1, 4, 2, 5 };
            this.elementCount = indices.Length;

            BufferData(coordinates, indices);
        }

        private void BufferData(Vector3[] coordinates, ushort[] indices)
        {
            this.glBuffers = new[] { GL.GenVertexArray(), GL.GenBuffer(), GL.GenBuffer() };

            GL.BindVertexArray(glBuffers[0]);

            GL.BindBuffer(BufferTarget.ArrayBuffer, glBuffers[1]);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, glBuffers[2]);

            // assign colours
            var colourPallet = (selectedAxis.HasFlag(SelectedAxis.U) ? Color.Yellow : Color.HotPink).ToFloatRgb()
                .Concat((selectedAxis.HasFlag(SelectedAxis.V) ? Color.Yellow : Color.MediumPurple).ToFloatRgb())
                .Concat((selectedAxis.HasFlag(SelectedAxis.W) ? Color.Yellow : Color.Cyan).ToFloatRgb());
            var colours = colourPallet.Concat(colourPallet).ToArray();

            GL.BufferData<ushort>(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)(sizeof(ushort) * indices.Length),
                indices,
                BufferUsageHint.StreamDraw);
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                (IntPtr)(Vector3.SizeInBytes * coordinates.Length + sizeof(float) * colours.Length),
                IntPtr.Zero,
                BufferUsageHint.StreamDraw);

            BufferPositionData(coordinates);

            BufferColourData(Vector3.SizeInBytes * coordinates.Length, colours);

            GL.BindVertexBuffer(
                0,
                glBuffers[1],
                (IntPtr)0,
                Vector3.SizeInBytes);
            GL.BindVertexBuffer(
                1,
                glBuffers[1],
                (IntPtr)(Vector3.SizeInBytes * coordinates.Length),
                sizeof(float) * 3);

            GL.VertexAttribFormat(0, 3, VertexAttribType.Float, false, 0);
            GL.VertexAttribFormat(1, 3, VertexAttribType.Float, false, 0);

            GL.VertexAttribBinding(0, 0);
            GL.VertexAttribBinding(1, 1);

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.BindVertexArray(0);
        }

        private static void BufferColourData(int offset, float[] colours)
        {
            GL.BufferSubData<float>(
                BufferTarget.ArrayBuffer,
                (IntPtr)(offset),
                (IntPtr)(sizeof(float) * colours.Length),
                colours);
        }

        private static void BufferPositionData(Vector3[] coordinates)
        {
            GL.BufferSubData<Vector3>(
                BufferTarget.ArrayBuffer,
                (IntPtr)0,
                (IntPtr)(Vector3.SizeInBytes * coordinates.Length),
                coordinates);
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
        }

        private void Dispose(bool disposing)
        {
            GL.DeleteVertexArray(glBuffers[0]);
            GL.DeleteBuffer(glBuffers[1]);
            GL.DeleteBuffer(glBuffers[2]);
            if (disposing)
            {
                // call IDisposable on members
                rightContact.Dispose();
                forwardContact.Dispose();
                upContact.Dispose();
            }
        }

        public IEnumerable<BulletSharp.CollisionObject> GetContactObjects
        {
            get
            {
                yield return rightContact;
                yield return forwardContact;
                yield return upContact;
            }
        }

        internal void DropHandlers()
        {
            WorldMatrixChanged = null;
        }

        internal void Hide()
        {
            this.Hidden = true;
        }

        internal void Show()
        {
            this.Hidden = false;
        }
    };

    class MousePole : Primitive, IDisposable
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
                var matrixScale = Matrix4.CreateScale(scale);
                var matrix = matrixPosition * matrixRotation * matrixScale;
                return matrix;
            }
        }
        public Vector3 Position
        {
            set
            {
                //var inverserWorldMatrix = Matrix4.Invert(WorldMatrix);
                this.position = value;// Vector3.Transform(value, inverserWorldMatrix);
                this.UpdateCollisionObject();
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
        Camera parent;
        Matrix4 parentWorldMatrix;

        Color diffuseColor;
        private float scale;

        public MousePole(Vector3 axisUp, Vector3 axisRight, Vector3 axisForward, Color color)
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

        MousePole()
        {
            this.parentWorldMatrix = Matrix4.Identity;
            this.rotation = Quaternion.FromAxisAngle(Vector3.UnitY, (float)0);
            this.position = new Vector3(0f, 0f, 0f);
            this.diffuseColor = Color.FromArgb(254, 242, 0);
            this.IsSelected = false;
            this.scale = 1f;
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

        private void UnHook()
        {
            if (parent == null) return;
            parent.MouseMove -= this.OnMouseMove;
            parent.MouseUp -= this.OnMouseUp;
            parent.MouseCaptureChanged -= this.OnMouseCaptureChanged;
            parent = null;
            IsSelected = false;
            registrationPoint = null;
        }

        void OnMouseMove(object sender, MouseEventArgs e)
        {
            var mouseRay = e.MouseRay;
            var worldMatrix = this.WorldMatrix;

            // Produce a unit-vector pointing towards the camera from this object
            var worldOrigin = worldMatrix.ExtractTranslation() + parentWorldMatrix.ExtractTranslation();
            var viewerAxis = (mouseRay.Origin - worldOrigin).Normalized();
            viewerAxis.Normalize();

            // Setup and select the collision plane
            var planeUNormal = worldMatrix.Row0.Xyz;
            var planeVNormal = worldMatrix.Row1.Xyz;
            var translationNormal = worldMatrix.Row2.Xyz;

            // Store the current position vector
            var offset = worldOrigin;

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
            DebugDrawer.DrawPoint(mouseRay.Origin);
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
                    var worldPosition = worldMatrix.ExtractTranslation();
                    var parentWorldPosition = parentWorldMatrix.ExtractTranslation();
                    var parentWorldScale = parentWorldMatrix.ExtractScale();
                    registrationPoint = intersectionPoint - parentWorldPosition;
                }

                GL.PointSize(9);
                DebugDrawer.DrawPoint(registrationPoint.Value);
                GL.PointSize(6);
                GL.VertexAttrib3(1, new[] { 254f / 255f, 128f / 255f, 0f });
                DebugDrawer.DrawPoint(intersectionPoint);
                GL.PointSize(1);

                // Produce matrices for rotation and inverse rotation
                var inverseRotation = Quaternion.Invert(this.rotation);
                var inverseScale = Matrix4.CreateScale(parentWorldMatrix.ExtractScale()).Inverted();
                var rotationMatrix = Matrix4.CreateFromQuaternion(rotation);

                // Produce translation value along translation axis
                var translation = intersectionPoint - registrationPoint.Value;
                translation = Vector3.Transform(translation, inverseScale);
                translation = Vector3.Dot(rotationMatrix.Row2.Xyz, translation) * rotationMatrix.Row2.Xyz;
                // Apply inverse rotation to cancel rotation later
                translation = Vector3.Transform(translation, inverseRotation);

                // Extract the two position components that are not being edited here (the other two axii)
                var componentU = Vector3.Dot(rotationMatrix.Row0.Xyz, offset) * rotationMatrix.Row0.Xyz;
                var componentV = Vector3.Dot(rotationMatrix.Row1.Xyz, offset) * rotationMatrix.Row1.Xyz;

                this.position = translation + componentU + componentV;
                Console.WriteLine(position);
                if (WorldMatrixChanged != null)
                {
                    worldMatrix = this.WorldMatrix;
                    ;
                    WorldMatrixChanged(this, new MatrixChangedEventArgs(ref worldMatrix));
                }

                this.position = Vector3.Zero;
                UpdateCollisionObject();
            }
        }

        private void UpdateCollisionObject()
        {
            CollisionObject.WorldTransform = Matrix4.CreateTranslation(registrationOffset) * this.WorldMatrix * this.parentWorldMatrix;
        }

        void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            UnHook();
        }

        void MouseCaptureChanged(object sender, EventArgs e)
        {
            UnHook();
        }

        internal void ParentWorldMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            this.parentWorldMatrix = e.Matrix;
            UpdateCollisionObject();
        }

        internal void Hook(Camera camera)
        {

            if (parent != null) UnHook();
            this.parent = camera;
            camera.MouseMove += this.OnMouseMove;
            camera.MouseUp += this.OnMouseUp;
            camera.MouseCaptureChanged += this.OnMouseCaptureChanged;
            IsSelected = true;
        }

        private void OnMouseCaptureChanged(object sender, EventArgs e)
        {
            UnHook();
        }
    };
}
