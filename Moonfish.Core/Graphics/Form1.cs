﻿using Moonfish.Collision;
using Moonfish.Definitions;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Moonfish.Graphics
{
    public partial class Form1 : Form
    {
        private Program program;
        private Program system_program;
        private Stopwatch timer;
        private Camera camera;
        private CoordinateGrid grid;
        private MeshManager manager;
        BulletSharp.CollisionWorld collisionWorld;

        Scenario Scenario;
        bool gl_loaded = false;

        public static Camera ActiveCamera { get; private set; }

        HierarchyModel test;
        ArrowSlider slider;

        public Form1()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
            glControl1.MouseDown += glControl1_MouseClick;

        }

        void glControl1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            BulletSharp.RaycastInfo raycast = new BulletSharp.RaycastInfo();
            BulletSharp.CollisionWorld.ClosestRayResultCallback callback = new BulletSharp.CollisionWorld.ClosestRayResultCallback(Vector3.Zero, Vector3.UnitX);
            Vector3 nearPoint, farPoint;
            nearPoint = Maths.Project(camera.ViewMatrix, camera.ProjectionMatrix, new Vector3(e.X, e.Y, 0f), (Rectangle)camera.Viewport).Xyz;
            farPoint = Maths.Project(camera.ViewMatrix, camera.ProjectionMatrix, new Vector3(e.X, e.Y, 1f), (Rectangle)camera.Viewport).Xyz;
            collisionWorld.RayTest(nearPoint, farPoint, callback);

            if (callback.HasHit)
            {
                Console.WriteLine(callback.CollisionObject.ToString());
                var control = (callback.CollisionObject.UserObject as ArrowSlider);
                if (control != null)
                {
                    control.Hook(system_program, glControl1);
                }
            }
            else
            {
                Console.WriteLine("nothing");
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                UpdateFrame();
                RenderFrame();
            }
        }

        private void UpdateFrame()
        {
            this.propertyGrid1.Refresh();
            if (!gl_loaded) return;
            camera.Update();

            collisionWorld.PerformDiscreteCollisionDetection();
        }

        private void RenderFrame()
        {
            if (!gl_loaded) return;
            var errorState = GL.GetError();

            //manager.Draw();

            using (system_program.Use())
            {
                errorState = GL.GetError();
                grid.Draw();
                errorState = GL.GetError();
                //pole.Draw();
                
                slider.Render(new[] { system_program });

            }
            using (system_program.Use())
            {
                collisionWorld.DebugDrawWorld();
            }
            using (system_program.Use())
            using (Grid grid = new Grid(new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector2(1, 1), 8, 8))
            {
                //grid.Draw();
            }

            glControl1.SwapBuffers();
            errorState = GL.GetError();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        private void LoadMeshes()
        {
            var errorState = GL.GetError();
        }

        private void LoadScenerio()
        {
            MapStream map = new MapStream(@"C:\Users\stem\Documents\modding\sharedx.map");

            //this.Scenario = map["scnr", ""].Deserialize();
            //test = map["hlmt", @"warthog"].Deserialize();

            //modelWrapper testWrapper = new modelWrapper(test);
            //var testresults = testWrapper.Permutations.ToList();
            //manager.Load(test);
            //manager.LoadScenario(map);
            //Application.Exit();

        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            // camera 
            camera = new Camera();
            camera.ViewProjectionMatrixChanged += viewport_ProjectionChanged;
            camera.ViewMatrixChanged += camera_ViewMatrixChanged;
            this.glControl1.MouseMove += camera.MouseMove;
            this.glControl1.MouseDown += camera.MouseDown;
            this.glControl1.MouseUp += camera.MouseUp;

            Form1.ActiveCamera = camera;


            // start timer
            timer = new Stopwatch();
            timer.Start();

            //setup our default program
            LoadPrograms();

            // initialize OpenGL

            GL.ClearColor(Color.FromArgb(0x1E1E1E));
            this.BackColor = Color.FromArgb(0xFF, 0x39, 0x39, 0x39);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
            GL.PolygonMode(MaterialFace.Back, PolygonMode.Fill);
            GL.PrimitiveRestartIndex((ushort)(0xFFFF));
            GL.Disable(EnableCap.PrimitiveRestart);
            GL.Disable(EnableCap.CullFace);
            GL.FrontFace(FrontFaceDirection.Cw);
            GL.Enable(EnableCap.DepthTest);
            GL.PointSize(2.0f);

            // initialize manager
            manager = new MeshManager(program);
            slider = new ArrowSlider(Vector3.UnitZ, Vector3.UnitX, Vector3.UnitY);
            LoadScenerio();
            LoadPhysics();

            grid = new CoordinateGrid();

            LoadMeshes();
            DebugDrawer.debugProgram = system_program;

            gl_loaded = true;


            glControl1_Resize(this, new EventArgs());
        }

        private void LoadPhysics()
        {
            var defaultCollisionConfiguration = new BulletSharp.DefaultCollisionConfiguration();
            var collisionDispatcher = new BulletSharp.CollisionDispatcher();
            var worldAabbMin = new Vector3(-1000, -1000, -1000);
            var worldAabbMax = new Vector3(1000, 1000, 1000);
            BulletSharp.AxisSweep3 broadphase = new BulletSharp.AxisSweep3(worldAabbMin, worldAabbMax);
            this.collisionWorld = new BulletSharp.CollisionWorld(collisionDispatcher, broadphase, defaultCollisionConfiguration);
            this.collisionWorld.DebugDrawer = new BulletDebugDrawer(this.system_program);

            var collisionObject = new BulletSharp.CollisionObject();
            collisionObject.WorldTransform = Matrix4.Identity;
            collisionObject.CollisionShape = new BulletSharp.BoxShape(0.5f);

            this.collisionWorld.AddCollisionObject(slider.CollisionObject);
        }

        void camera_ViewMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            if (!gl_loaded) return;
            program.Use();
            program["normal_view_matrix"] = new Matrix3(e.Matrix);
        }

        private void LoadPrograms()
        {
            Shader vertex_shader = new Shader("data/vertex.vert.glsl", ShaderType.VertexShader);
            Shader fragment_shader = new Shader("data/fragment.frag.glsl", ShaderType.FragmentShader);
            this.program = new Program(new List<Shader>(2) { vertex_shader, fragment_shader });


            program.Use();
            program["object_matrix"] = Matrix4.CreateTranslation(new Vector3(0.0f, 0.0f, 0.0f));
            program["object_extents"] = Matrix4.CreateScale(1.0f, 1.0f, 1.0f);
            program["direction_to_light"] = new Vector3(2, 2, 0);
            program["light_intensity"] = 0.666f;

            vertex_shader = new Shader("data/sys_vertex.vert.glsl", ShaderType.VertexShader);
            fragment_shader = new Shader("data/sys_fragment.frag.glsl", ShaderType.FragmentShader);
            this.system_program = new Program(new List<Shader>(2) { vertex_shader, fragment_shader });


            system_program.Use();
            system_program["object_matrix"] = Matrix4.CreateTranslation(new Vector3(0.0f, 0.0f, 0.0f));
        }

        private void viewport_ProjectionChanged(object sender, MatrixChangedEventArgs e)
        {
            if (!gl_loaded) return;
            var errorState = GL.GetError();
            program.Use();
            errorState = GL.GetError();
            program["view_projection_matrix"] = e.Matrix;
            errorState = GL.GetError();
            program["normal_view_matrix"] = new Matrix3(e.Matrix);
            errorState = GL.GetError();
            system_program.Use();
            errorState = GL.GetError();
            system_program["view_projection_matrix"] = e.Matrix;
            errorState = GL.GetError();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!gl_loaded) return;
            ChangeViewport(glControl1.Width, glControl1.Height);
            RenderFrame();
        }

        private void ChangeViewport(int width, int height)
        {
            var errorState = GL.GetError();
            camera.Viewport.Size = new Size(width, height);
            errorState = GL.GetError();
            GL.Viewport(0, 0, width, height);
            errorState = GL.GetError();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            RenderFrame();
        }
    }
}