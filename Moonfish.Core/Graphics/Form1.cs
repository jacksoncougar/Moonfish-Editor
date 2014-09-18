using Moonfish.Collision;
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
        private Program viewscreenProgram;
        private Stopwatch timer;
        private Camera camera;
        private CoordinateGrid grid;
        private MeshManager manager;
        private MapStream map;
        public BulletSharp.CollisionWorld collisionWorld;

        TagIdent? activeObject;
        Object selectedObject;

        MousePole2D mousePole;

        Scenario Scenario;
        bool gl_loaded = false;

        public static Camera ActiveCamera { get; private set; }
        public static Program ScreenProgram { get; private set; }

        HierarchyModel test;
        MousePole slider;
        TranslationGizmo gizmo;

        public Form1()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;

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
            if (!gl_loaded) return;
            camera.Update();

            UpdateGUI();

            collisionWorld.PerformDiscreteCollisionDetection();
            if (!activeObject.HasValue) return;
            var model = (Halo2.GetReferenceObject(this.activeObject.Value) as HierarchyModel);
            if (activeObject.HasValue && model != null && Halo2.ObjectChanged(model.renderModel.TagID))
            {
                manager.Remove(activeObject.Value);
                Halo2.GetReferenceObject(activeObject.Value, true);
                Halo2.GetReferenceObject(model.renderModel.TagID, true);
                manager.Add(activeObject.Value);
                LoadPropertyGrid();
            }
        }

        private void UpdateGUI()
        {
            foreach (var item in selectableObjects)
            {
                var origin = item.WorldTransform.ExtractTranslation();
                var scale = camera.CreateScale(origin, 0.1f, pixelSize: 25);
                var scaleMatrix = Matrix4.CreateScale(scale);
                var inverseScaleMatrix = Matrix4.CreateScale(item.WorldTransform.ExtractScale()).Inverted();
                item.WorldTransform = scaleMatrix * inverseScaleMatrix * item.WorldTransform;
            }
        }

        private void RenderFrame()
        {
            if (!gl_loaded) return;
            var errorState = GL.GetError();


            //manager.Draw();

            if (activeObject != null)
            {
                manager.Draw(activeObject.Value);
            }

            using (system_program.Use())
            {
                system_program["object_matrix"] = Matrix4.Identity;
                errorState = GL.GetError();
                grid.Draw();
                errorState = GL.GetError();
                //pole.Draw();
                //gizmo.Render(new[] { system_program });

                //slider.Render(new[] { system_program });

            }
            using (system_program.Use())
            using (Grid grid = new Grid(new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector2(1, 1), 8, 8))
            {
                //grid.Draw();
            }
            using (OpenGL.Disable(EnableCap.DepthTest))
            {
                mousePole.Render(viewscreenProgram);
                using (system_program.Use())
                {
                    collisionWorld.DebugDrawWorld();
                }
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
        }

        private void LoadModels()
        {
            if (map == null) return;
            var tags = map.Where(x => x.Type.ToString() == "hlmt").Select(x => new ListViewItem(x.Path) { Tag = x }).ToArray();
            this.listView1.Clear();
            this.listView1.Columns.Add("Name");
            this.listView1.FullRowSelect = true;
            this.listView1.MultiSelect = false;
            this.listView1.Items.AddRange(tags.ToArray());
            this.listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            manager.Clear();
            manager.LoadHierarchyModels(map);
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            // camera 
            camera = new Camera();
            camera.ViewProjectionMatrixChanged += viewport_ProjectionChanged;
            camera.ViewMatrixChanged += camera_ViewMatrixChanged;
            this.glControl1.MouseMove += camera.OnMouseMove;
            this.glControl1.MouseDown += camera.OnMouseDown;
            this.glControl1.MouseUp += camera.OnMouseUp;
            this.glControl1.MouseCaptureChanged += camera.OnMouseCaptureChanged;

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
            manager = new MeshManager(program, system_program);
            // slider = new ArrowSlider(Vector3.UnitZ, Vector3.UnitX, Vector3.UnitY, Color.Red);
            // LoadScenerio();
            gizmo = new TranslationGizmo();
            camera.CameraUpdated += gizmo.Update;
            mousePole = new MousePole2D(ActiveCamera);
            camera.CameraUpdated += mousePole.OnCameraUpdate;
            LoadPhysics();


            grid = new CoordinateGrid();
            LoadModels();
            //LoadMeshes();
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
            this.collisionWorld.DebugDrawer = new BulletDebugDrawer(this.viewscreenProgram);

            foreach (BulletSharp.CollisionObject collisionObject in mousePole.GetContactObjects)
            {
                collisionWorld.AddCollisionObject(collisionObject);
            }
        }

        void camera_ViewMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            if (!gl_loaded) return;
            program.Use();
            program["normal_view_matrix"] = new Matrix3(e.Matrix);
        }

        private void LoadPrograms()
        {
            var vertex_shader = new Shader("data/vertex.vert", ShaderType.VertexShader);
            var fragment_shader = new Shader("data/fragment.frag", ShaderType.FragmentShader);
            this.program = new Program(new List<Shader>(2) { vertex_shader, fragment_shader }, "shaded");

            vertex_shader = new Shader("data/viewscreen.vert", ShaderType.VertexShader);
            fragment_shader = new Shader("data/sys_fragment.frag", ShaderType.FragmentShader);
            this.viewscreenProgram = new Program(new List<Shader>(2) { vertex_shader, fragment_shader }, "viewscreen");

            Form1.ScreenProgram = viewscreenProgram;

            program.Use();
            program["object_matrix"] = Matrix4.CreateTranslation(new Vector3(0.0f, 0.0f, 0.0f));
            program["object_extents"] = Matrix4.CreateScale(1.0f, 1.0f, 1.0f);
            program["direction_to_light"] = new Vector3(2, 2, 0);
            program["light_intensity"] = 0.666f;

            vertex_shader = new Shader("data/sys_vertex.vert", ShaderType.VertexShader);
            fragment_shader = new Shader("data/sys_fragment.frag", ShaderType.FragmentShader);
            this.system_program = new Program(new List<Shader>(2) { vertex_shader, fragment_shader }, "system");


            system_program.Use();
            system_program["object_matrix"] = Matrix4.CreateTranslation(new Vector3(0.0f, 0.0f, 0.0f));
        }

        private void viewport_ProjectionChanged(object sender, MatrixChangedEventArgs e)
        {
            if (!gl_loaded) return;
            program.Use();
            program["view_projection_matrix"] = e.Matrix;
            program["normal_view_matrix"] = new Matrix3(e.Matrix);
            system_program.Use();
            system_program["view_projection_matrix"] = e.Matrix;
            viewscreenProgram.Use();
            viewscreenProgram["view_projection_matrix"] = e.Matrix;
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

        List<BulletSharp.CollisionObject> selectableObjects = new List<BulletSharp.CollisionObject>();
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected) return;
            var tag = e.Item.Tag as Tag;
            if (tag != null)
            {
                activeObject = tag.Identifier;
                manager.Add(activeObject.Value);

                foreach (var item in selectableObjects)
                {
                    this.collisionWorld.RemoveCollisionObject(item);
                }
                selectableObjects = manager[activeObject.Value].Select(x => x).ToList();
                foreach (var item in selectableObjects)
                {
                    var userObject = item.UserObject as IClickable;
                    if (userObject != null)
                        userObject.OnMouseClick += userObject_OnMouseClick;

                    this.collisionWorld.AddCollisionObject(item);
                }

                LoadPropertyGrid();
            }
        }

        void userObject_OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousePole.Show();
                mousePole.Position = e.WorldCoordinates;
                var marker = sender as MarkerWrapper;
                if (marker != null)
                {
                    var query = from item in propertyGrid1.EnumerateAllItems()
                                where item.Value == marker.marker
                                select item;
                    if (query.Any())
                    {
                        var item = query.Single();
                        var parent = item;
                        do
                        {
                            parent.Expanded = true;
                            parent = parent.Parent;
                        } while (parent != null);
                        propertyGrid1.SelectedGridItem = item;
                    }

                    mousePole.DropHandlers();
                    mousePole.WorldMatrixChanged += marker.mousePole_WorldMatrixChanged;
                }
            }
        }

        private void LoadPropertyGrid()
        {
            if (activeObject != null)
            {
                var model = (Halo2.GetReferenceObject(activeObject.Value) as HierarchyModel);
                if (model != null)
                {
                    this.propertyGrid1.SelectedObject = model.RenderModel.markerGroups;
                }
            }

        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            if (e.NewSelection.Value == null) return;
            if (e.NewSelection.Value.GetType() == typeof(RenderModelMarkerBlock) && activeObject.HasValue)
            {
                manager[activeObject.Value].Select(new[] { e.NewSelection.Value });
            }
            else if (e.NewSelection.Value.GetType() == typeof(RenderModelMarkerGroupBlock) && activeObject.HasValue)
            {
                var markerGroup = e.NewSelection.Value as RenderModelMarkerGroupBlock;
                manager[activeObject.Value].Select(markerGroup.Markers);
            }
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Halo 2 cache map (*.map)|*.map|All files (*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.activeObject = null;
                    var directory = Path.GetDirectoryName(dialog.FileName);
                    var maps = Directory.GetFiles(directory, "*.map", SearchOption.TopDirectoryOnly);
                    var resourceMaps = maps.Where(x =>
                    {
                        var type = Halo2.CheckMapType(x);
                        return type == MapStream.MapType.Shared
                            || type == MapStream.MapType.MainMenu
                            || type == MapStream.MapType.SinglePlayerShared;
                    }).Select(x => new MapStream(x)).ToList();
                    resourceMaps.ForEach(x => Halo2.LoadResource(x));

                    this.map = new MapStream(dialog.FileName);
                    this.Text = string.Format("{0} - Moonfish Marker Viewer 2014 for Remnantmods", (this.map as FileStream).Name);
                    LoadModels();
                }
            }
        }

        private void glControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mousePole.OnMouseDown(this, new MouseEventArgs(ActiveCamera, new Vector2(e.X, e.Y), default(Vector3), e.Button));

            var mouse = new
            {
                Close = camera.Project(new Vector2(e.X, e.Y), depth: -1),
                Far = camera.Project(new Vector2(e.X, e.Y), depth: 1)
            };

            var callback = new BulletSharp.CollisionWorld.ClosestRayResultCallback(mouse.Close, mouse.Far);
            collisionWorld.PerformDiscreteCollisionDetection();
            collisionWorld.RayTest(mouse.Close, mouse.Far, callback);

            if (callback.HasHit)
            {
                var clickableInterface = callback.CollisionObject.UserObject as IClickable;
                if (clickableInterface != null)
                {
                    clickableInterface.OnMouseClickHandler(this, new MouseEventArgs(camera, new Vector2(e.X, e.Y), callback.CollisionObject.WorldTransform.ExtractTranslation(), e.Button));
                }
            }
            else
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    mousePole.DropHandlers();
                    mousePole.Hide();
                }
            }
        }

        private void glControl1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mousePole.OnMouseUp(this, new MouseEventArgs(ActiveCamera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        private void glControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mousePole.OnMouseMove(this, new MouseEventArgs(ActiveCamera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        private void glControl1_MouseClick_1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var mouse = new
            {
                Close = camera.Project(new Vector2(e.X, e.Y), depth: -1),
                Far = camera.Project(new Vector2(e.X, e.Y), depth: 1)
            };

            var callback = new BulletSharp.CollisionWorld.ClosestRayResultCallback(mouse.Close, mouse.Far);
            collisionWorld.PerformDiscreteCollisionDetection();
            collisionWorld.RayTest(mouse.Close, mouse.Far, callback);

            if (callback.HasHit)
            {
                var clickableInterface = callback.CollisionObject.UserObject as IClickable;
                if (clickableInterface != null)
                {
                    clickableInterface.OnMouseClickHandler(this, new MouseEventArgs(camera, new Vector2(e.X, e.Y), callback.CollisionObject.WorldTransform.ExtractTranslation(), e.Button));
                }
            }
        }
    }
}
