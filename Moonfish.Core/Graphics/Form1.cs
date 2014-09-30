using Moonfish.Collision;
using Moonfish.Definitions;
using Moonfish.Graphics.Input;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.ES30;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
        List<BulletSharp.CollisionObject> selectableObjects = new List<BulletSharp.CollisionObject>();

        TagIdent? activeObject;
        Object selectedObject;

        MousePole2D mousePole;

        ScenarioBlock Scenario;
        bool gl_loaded = false;
        UniformBuffer globalUniformBuffer;

        public static Camera ActiveCamera { get; private set; }
        public static Program ScreenProgram { get; private set; }


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
            propertyGrid1.Refresh();
            collisionWorld.PerformDiscreteCollisionDetection();
        }

        private void UpdateGUI()
        {
            foreach (var item in selectableObjects)
            {
                var origin = item.WorldTransform.ExtractTranslation();
                var scale = camera.CreateScale(origin, 0.1f, pixelSize: 10);
                var scaleMatrix = Matrix4.CreateScale(scale);
                var inverseScaleMatrix = Matrix4.CreateScale(item.WorldTransform.ExtractScale()).Inverted();
                item.WorldTransform = scaleMatrix * inverseScaleMatrix * item.WorldTransform;
            }
        }

        private void RenderFrame()
        {
            if (!gl_loaded) return;

            if (activeObject.HasValue)
            {
                program[Uniforms.WorldMatrix] = Matrix4.Identity;
                manager.Draw(activeObject.Value);
            }
            foreach (var item in test)
            {
                item.Render(program);
            }
            manager.Draw();
            using (system_program.Use())
            {
                system_program[Uniforms.WorldMatrix] = Matrix4.Identity;
                system_program[Uniforms.NormalizationMatrix] = Matrix4.Identity;
                grid.Draw();
            }
            //using (OpenGL.Disable(EnableCap.DepthTest))
            //{
            //    //mousePole.Render(system_program);
            //    using (system_program.Use())
            //    {
            //        //collisionWorld.DebugDrawWorld();
            //    }
            //}
            glControl1.SwapBuffers();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
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
            //manager.LoadHierarchyModels(map);
        }

        private void Initialization(object sender, EventArgs e)
        {
            Console.WriteLine(GL.GetString(StringName.Version));
            DebugDrawer.debugProgram = system_program;

            this.camera = new Camera();
            this.timer = new Stopwatch();
            this.grid = new CoordinateGrid();
            this.mousePole = new MousePole2D(camera);
            OpenGL.ReportError();

            this.BackColor = Colours.ClearColour;
            ActiveCamera = camera;

            this.camera.ViewProjectionMatrixChanged += viewport_ProjectionChanged;
            this.camera.ViewMatrixChanged += camera_ViewMatrixChanged;
            this.camera.CameraUpdated += mousePole.OnCameraUpdate;

            this.glControl1.MouseMove += camera.OnMouseMove;
            this.glControl1.MouseDown += camera.OnMouseDown;
            this.glControl1.MouseUp += camera.OnMouseUp;
            this.glControl1.MouseCaptureChanged += camera.OnMouseCaptureChanged;

            InitializeOpenGL();

            this.manager = new MeshManager(program, system_program);

            timer.Start();
            //  firing this method is meant to load the view-projection matrix values into 
            //  the shader uniforms, and initalizes the camera
            glControl1_Resize(this, new EventArgs());
        }

        private void InitializeOpenGL()
        {
            OpenGL.ReportError();
            GL.ClearColor(Colours.ClearColour);
            OpenGL.ReportError();
            GL.FrontFace(FrontFaceDirection.Cw);
            OpenGL.ReportError();
            GL.Disable(EnableCap.CullFace);
            OpenGL.ReportError();
            GL.Enable(EnableCap.DepthTest);
            OpenGL.ReportError();

            LoadPrograms();
            LoadPhysics();

            Scene.LoadSceneShaders();

            gl_loaded = true;

            Console.WriteLine(GL.GetString(StringName.Version));
        }

        private void LoadPhysics()
        {
            var defaultCollisionConfiguration = new BulletSharp.DefaultCollisionConfiguration();
            var collisionDispatcher = new BulletSharp.CollisionDispatcher();
            var worldAabbMin = new Vector3(-1000, -1000, -1000);
            var worldAabbMax = new Vector3(1000, 1000, 1000);
            var broadphase = new BulletSharp.AxisSweep3(worldAabbMin, worldAabbMax);
            this.collisionWorld = new BulletSharp.CollisionWorld(collisionDispatcher, broadphase, defaultCollisionConfiguration);
            this.collisionWorld.DebugDrawer = new BulletDebugDrawer(this.viewscreenProgram);

            foreach (var collisionObject in mousePole.ContactObjects)
            {
                collisionWorld.AddCollisionObject(collisionObject);
            }
        }

        private void LoadPrograms()
        {
            var vertex_shader = new Shader("data/vertex.vert", ShaderType.VertexShader);
            var fragment_shader = new Shader("data/fragment.frag", ShaderType.FragmentShader);
            this.program = new Program("shaded"); OpenGL.ReportError();
            GL.BindAttribLocation(this.program.ID, 0, "position"); OpenGL.ReportError();
            GL.BindAttribLocation(this.program.ID, 1, "texcoord"); OpenGL.ReportError();
            GL.BindAttribLocation(this.program.ID, 2, "compressedNormal"); OpenGL.ReportError();
            this.program.Link(new List<Shader>(2) { vertex_shader, fragment_shader }); OpenGL.ReportError();

            vertex_shader = new Shader("data/viewscreen.vert", ShaderType.VertexShader);
            fragment_shader = new Shader("data/sys_fragment.frag", ShaderType.FragmentShader);
            this.viewscreenProgram = new Program("viewscreen"); OpenGL.ReportError();
            GL.BindAttribLocation(this.viewscreenProgram.ID, 0, "position");
            GL.BindAttribLocation(this.viewscreenProgram.ID, 1, "diffuse_color");
            this.viewscreenProgram.Link(new List<Shader>(2) { vertex_shader, fragment_shader }); OpenGL.ReportError();

            vertex_shader = new Shader("data/sys_vertex.vert", ShaderType.VertexShader); OpenGL.ReportError();
            fragment_shader = new Shader("data/sys_fragment.frag", ShaderType.FragmentShader); OpenGL.ReportError();
            this.system_program = new Program("system"); OpenGL.ReportError();
            GL.BindAttribLocation(this.system_program.ID, 0, "position"); OpenGL.ReportError();
            GL.BindAttribLocation(this.system_program.ID, 1, "diffuse_color"); OpenGL.ReportError();
            this.system_program.Link(new List<Shader>(2) { vertex_shader, fragment_shader }); OpenGL.ReportError();

            vertex_shader = new Shader("data/sprite.vert", ShaderType.VertexShader); OpenGL.ReportError();
            fragment_shader = new Shader("data/sprite.frag", ShaderType.FragmentShader); OpenGL.ReportError();
            this.system_program = new Program("system"); OpenGL.ReportError();
            GL.BindAttribLocation(this.system_program.ID, 0, "position"); OpenGL.ReportError();
            GL.BindAttribLocation(this.system_program.ID, 1, "diffuse_color"); OpenGL.ReportError();
            this.system_program.Link(new List<Shader>(2) { vertex_shader, fragment_shader }); OpenGL.ReportError();
        }

        List<RenderObject> test = new List<RenderObject>();
        private void LoadScenarioStructureBSP()
        {
            var structureBSP = (ScenarioStructureBSP)map["sbsp", ""].Deserialize();
            //structureBSP.clusters.ToList().ForEach(x => test.Add(new RenderObject(x)));
        }

        private void LoadScenario()
        {
            manager.LoadScenario(map);
        }

        private void LoadFile(string fileName)
        {
            this.activeObject = null;
            var directory = Path.GetDirectoryName(fileName);
            var maps = Directory.GetFiles(directory, "*.map", SearchOption.TopDirectoryOnly);
            var resourceMaps = maps.GroupBy(
                x =>
                {
                    return Halo2.CheckMapType(x);
                }
            ).Where(x => x.Key == MapType.MainMenu
                || x.Key == MapType.Shared
                || x.Key == MapType.SinglePlayerShared)
                .Select(g => g.First()).ToList();
            resourceMaps.ForEach(x => Halo2.LoadResource(new MapStream(x)));
            StaticBenchmark.Begin();

            this.map = new MapStream(fileName);
            StaticBenchmark.End();
            this.Text = string.Format("{0} - Moonfish Marker Viewer 2014 for Remnantmods", (this.map as FileStream).Name);
            LoadModels();
            //LoadScenarioStructureBSP();
            LoadScenario();
        }

        private void camera_ViewMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            if (!gl_loaded) return;
            //  TODO: code handling when view matrix changes
        }

        private void viewport_ProjectionChanged(object sender, MatrixChangedEventArgs e)
        {
            if (!gl_loaded) return;

            system_program[Uniforms.ViewProjectionMatrix] = e.Matrix;
            program[Uniforms.ViewProjectionMatrix] = e.Matrix;
            viewscreenProgram[Uniforms.ViewProjectionMatrix] = e.Matrix;
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!gl_loaded) return;
            ChangeViewport(glControl1.Width, glControl1.Height);
            RenderFrame();
        }

        private void ChangeViewport(int width, int height)
        {
            camera.Viewport.Size = new Size(width, height);
            GL.Viewport(0, 0, width, height);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            RenderFrame();
        }

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

        private void userObject_OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var marker = sender as MarkerWrapper;
                mousePole.DropHandlers();
                mousePole.Show();
                mousePole.Position = e.WorldCoordinates;
                mousePole.Rotation = manager[activeObject.Value].nodes.GetWorldMatrix(marker.marker.NodeIndex).ExtractRotation();
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
                var model = ( Halo2.GetReferenceObject( activeObject.Value ) as ModelBlock );
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
                    LoadFile(dialog.FileName);
                }
            }
        }

        private void glControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!gl_loaded) return;
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
            if (!gl_loaded) return;
            mousePole.OnMouseUp(this, new MouseEventArgs(ActiveCamera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        private void glControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!gl_loaded) return;
            mousePole.OnMouseMove(this, new MouseEventArgs(ActiveCamera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        private void glControl1_MouseClick_1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!gl_loaded) return;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.Clear();
            toolStripComboBox1.Items.Add(TransformMode.World);
            toolStripComboBox1.Items.Add(TransformMode.Local);
            toolStripComboBox1.SelectedIndex = 0;
            //k?
            LoadFile(@"C:\Users\stem\Documents\modding\headlong.map");
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mousePole.Mode = (TransformMode)toolStripComboBox1.SelectedItem;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager[activeObject.Value].Save(map);
            map.Sign();
        }
    }
}
