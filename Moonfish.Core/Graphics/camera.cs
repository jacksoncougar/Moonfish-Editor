using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Moonfish.Graphics
{
    public class Camera : Node
    {
        #region Properties
        public Viewport Viewport { get { return viewport; } set { viewport = value; } }
        public Track Track { get { return track; } set { track = value; } }

        public new Vector3 Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                CalculateViewProjectionMatrix();
            }
        }
        public new Quaternion Rotation
        {
            get
            {
                return base.Rotation;
            }
            set
            {
                base.Rotation = value;
                CalculateViewProjectionMatrix();
            }
        }

        public Matrix4 ViewMatrix { get; private set; }
        public Matrix4 ProjectionMatrix { get; private set; }
        #endregion

        #region Public Methods

        public void Update()
        {
            Position = track.WorldMatrix.ExtractTranslation();
            Rotation = track.WorldMatrix.ExtractRotation();
        }

        Vector2 previousMouseCoordinate;
        public void MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //var mouseState = Mouse.GetState();
            //var keyboardState = Keyboard.GetState();
            //var currentMouseCoordinate = new Vector2(e.X, e.Y);

            //if (keyboardState.IsKeyDown(Key.ShiftLeft) && mouseState[MouseButton.Middle])
            //{
            //    track = new PanTrack(track);
            //}
            //else if (keyboardState.IsKeyDown(Key.ControlLeft) && mouseState[MouseButton.Middle])
            //{
            //    track = new ZoomTrack(track);
            //}
        }
        public void MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //track = new Track(track);
        }
        public void MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var mouseState = Mouse.GetState();
            var keyboardState = Keyboard.GetState();
            var currentMouseCoordinate = new Vector2(e.X, e.Y);
            if (keyboardState.IsKeyDown(Key.ShiftLeft) && mouseState[MouseButton.Middle])
            {
                var d = 5;
                var previousMouseWorldCoordinate = Maths.Project(ViewMatrix, Viewport.ProjectionMatrix, previousMouseCoordinate, (Rectangle)Viewport, Maths.ProjectionTarget.View);
                var mouseWorldCoordinate = Maths.Project(ViewMatrix, ProjectionMatrix, currentMouseCoordinate, (Rectangle)Viewport, Maths.ProjectionTarget.View);
                var delta = mouseWorldCoordinate - previousMouseWorldCoordinate;
                delta *= d;
                panTrack.Update(delta.X, delta.Y);
            }
            else if (keyboardState.IsKeyDown(Key.ControlLeft) && mouseState[MouseButton.Middle])
            {
                var previousMouseWorldCoordinate = Maths.Project(ViewMatrix, Viewport.ProjectionMatrix, previousMouseCoordinate, (Rectangle)Viewport, Maths.ProjectionTarget.View);
                var mouseWorldCoordinate = Maths.Project(ViewMatrix, ProjectionMatrix, currentMouseCoordinate, (Rectangle)Viewport, Maths.ProjectionTarget.View);
                var delta = mouseWorldCoordinate - previousMouseWorldCoordinate;
                delta *= 10;
                zoomTrack.Update(delta.Y);
            }
            else if (mouseState[MouseButton.Middle] || (mouseState[MouseButton.Left] && keyboardState[Key.ControlLeft]))
            {
                var delta = currentMouseCoordinate - previousMouseCoordinate;
                //delta *= 10;
                orbitTrack.Update(delta.X, delta.Y);
            }
            previousMouseCoordinate = currentMouseCoordinate;
        }

        #endregion

        #region Private Fields
        Vector2 MouseCoordinate;
        Viewport viewport;
        Track track;
        PanTrack panTrack;
        ZoomTrack zoomTrack;
        OrbitTrack orbitTrack;

        #endregion

        #region Private Methods

        void CalculateViewProjectionMatrix()
        {
            var view_matrix = Matrix4.Invert(track.WorldMatrix);
            var projection_matrix = viewport.ProjectionMatrix;

            this.ViewMatrix = view_matrix;
            this.ProjectionMatrix = projection_matrix;

            Matrix4 view_projection_matrix;
            Matrix4.Mult(ref view_matrix, ref projection_matrix, out view_projection_matrix);
            OnViewProjectionMatrixChanged(new MatrixChangedEventArgs(ref view_projection_matrix));
            OnViewMatrixChanged(new MatrixChangedEventArgs(ref view_matrix));
        }

        void viewport_ProjectionChanged(object sender, MatrixChangedEventArgs e)
        {
            CalculateViewProjectionMatrix();
        }

        void OnViewProjectionMatrixChanged(MatrixChangedEventArgs e)
        {
            if (ViewProjectionMatrixChanged != null)
                ViewProjectionMatrixChanged(this, e);
        }

        void OnViewMatrixChanged(MatrixChangedEventArgs e)
        {
            if (ViewMatrixChanged != null)
                ViewMatrixChanged(this, e);
        }

        #endregion

        #region Constructors
        public Camera()
        {
            viewport = new Viewport();
            track = new Track();

            track.Parent = panTrack = new PanTrack(track);
            track.Parent.Parent = orbitTrack = new OrbitTrack(track);
            track.Parent.Parent.Parent = zoomTrack = new ZoomTrack(track);

            zoomTrack.Zoom(-5f);

            viewport.ProjectionChanged += viewport_ProjectionChanged;
        }
        #endregion

        #region Events

        public event ViewMatrixChangedEventHandler ViewMatrixChanged;

        public event ViewProjectionMatrixChangedEventHandler ViewProjectionMatrixChanged;

        #endregion
    }

    //public class OrbitTrack : Track
    //{
    //    #region Properties
    //    public override Matrix4 TransformationMatrix
    //    {
    //        get { return transformation_matrix; }
    //    }        
    //    public override Vector2 Input
    //    {
    //        set
    //        {
    //            setAzimuth(value.X);
    //            setAltitude(value.Y);
    //            CalculateTransformationMatrix();
    //            setRadial(value.Y);
    //        }
    //    }
    //    #endregion

    //    #region Private Fields
    //    float radial;
    //    float azimuth;
    //    float altitude;
    //    float delta_distance = 0.5f;
    //    float min_distance = 1.0f;
    //    float max_distance = 1000.0f;
    //    Matrix4 transformation_matrix;
    //    #endregion

    //    #region Private Methods
    //    void CalculateTransformationMatrix()
    //    {
    //        float cos_altitude = (float)Math.Cos(altitude);
    //        float sin_altitude = (float)Math.Sin(altitude);
    //        float cos_azimuth = (float)Math.Cos(azimuth);
    //        float sin_azimuth = (float)Math.Sin(azimuth);


    //        float x = radial * cos_azimuth * sin_altitude;
    //        float y = radial * sin_azimuth * sin_altitude;
    //        float z = radial * cos_altitude;

    //        Vector3 eye = new Vector3(x, y, z);

    //        var radial_axis = new Vector3(eye);
    //        var azimuth_axis = new Vector3(
    //            -sin_azimuth,
    //            cos_azimuth,
    //            0);
    //        var altitude_axis = new Vector3(
    //            cos_azimuth * cos_altitude,
    //            sin_azimuth * cos_altitude,
    //            -sin_altitude
    //            );

    //        radial_axis.Normalize();
    //        azimuth_axis.Normalize();
    //        altitude_axis.Normalize();

    //        transformation_matrix = new Matrix4(
    //            new Vector4(azimuth_axis, 0),
    //            new Vector4(altitude_axis, 0),
    //            new Vector4(radial_axis, 0),
    //            new Vector4(eye, 1));
    //    }
    //    void setRadial(float value)
    //    {
    //        //var step = -value * delta_distance;
    //        //if (radial + step < min_distance)
    //        //    radial = min_distance;
    //        //else if (radial + step > max_distance)
    //        //    radial = max_distance;
    //        //else
    //        //    radial += step;
    //    }
    //    void setAzimuth(float value)
    //    {
    //        azimuth += MathHelper.DegreesToRadians(value);
    //    }
    //    void setAltitude(float value)
    //    {
    //        altitude += MathHelper.DegreesToRadians(value);
    //   }
    //    #endregion

    //    #region Constructor
    //    public OrbitTrack()
    //    {
    //        radial = 5.0f;
    //        azimuth = MathHelper.DegreesToRadians(0);
    //        altitude = MathHelper.DegreesToRadians(-0);
    //        //state = States.Disabled;
    //        transformation_matrix = Matrix4.Identity;
    //        CalculateTransformationMatrix();
    //    }
    //    #endregion
    //}

    public class Viewport
    {
        #region Constants
        const int max_width_8k = 4320;
        const int max_height_8k = 7680;
        const int default_width = 640;
        const int default_height = 480;
        #endregion

        #region Properties
        public int Width
        {
            get { return width; }
            set
            {
                if (isValidWidth(value))
                {
                    width = value;
                    CalculateProjectionMatrix();
                }
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if (isValidHeight(value))
                {
                    height = value;
                    CalculateProjectionMatrix();
                }
            }
        }
        public Size Size
        {
            get { return new Size(width, height); }
            set
            {
                if (isValidWidth(value.Width) && isValidHeight(value.Height))
                {
                    width = value.Width;
                    height = value.Height;
                    CalculateProjectionMatrix();
                }
            }
        }

        public float ZNear { get { return z_near; } }
        #endregion

        #region Internal Properties
        internal Matrix4 ProjectionMatrix { get { return projection_matrix; } }
        #endregion

        #region Private Fields
        private Matrix4 projection_matrix;
        private int width;
        private int height;
        private float z_near;
        private float z_far;
        private float field_of_view;
        #endregion

        #region Private Methods
        bool isValidWidth(int value)
        {
            return (value > 0 && value <= max_width_8k);
        }
        bool isValidHeight(int value)
        {
            return (value > 0 && value <= max_height_8k);
        }
        void CalculateProjectionMatrix()
        {
            var aspect_ratio = (float)Width / (float)Height;
            Matrix4.CreatePerspectiveFieldOfView(
                field_of_view,
                aspect_ratio,
                z_near,
                z_far,
                out projection_matrix);
            OnProjectionChanged(new MatrixChangedEventArgs(ref projection_matrix));
        }
        void OnProjectionChanged(MatrixChangedEventArgs e)
        {
            if (ProjectionChanged != null)
                ProjectionChanged(this, e);
        }
        #endregion

        #region Constructors
        public Viewport()
        {
            ProjectionChanged = null;
            width = default_width;
            height = default_height;
            z_near = 0.5f;
            z_far = 100.0f;
            field_of_view = (float)Math.PI / 4;
            projection_matrix = Matrix4.Identity;
            CalculateProjectionMatrix();
        }
        #endregion

        #region Conversion Operator
        public static explicit operator Rectangle(Viewport viewport)
        {
            var rectangle = new Rectangle(0, 0, viewport.width, viewport.height);
            return rectangle;
        }
        #endregion

        #region Events
        public event ProjectionMatrixChangedEventHandler ProjectionChanged;
        #endregion
    }

    public class MatrixChangedEventArgs : EventArgs
    {
        public Matrix4 Matrix;
        public MatrixChangedEventArgs(ref Matrix4 view_projection_matrix)
        {
            Matrix = view_projection_matrix;
        }
    }

    public delegate void ProjectionMatrixChangedEventHandler(object sender, MatrixChangedEventArgs e);

    public delegate void ViewMatrixChangedEventHandler(object sender, MatrixChangedEventArgs e);

    public delegate void ViewProjectionMatrixChangedEventHandler(object sender, MatrixChangedEventArgs e);

}
