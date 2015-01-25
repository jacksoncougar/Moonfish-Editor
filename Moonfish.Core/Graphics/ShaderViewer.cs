﻿using Moonfish.Guerilla.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moonfish.Graphics
{
    public partial class ShaderViewer : Form
    {
        Scene Scene { get; set; }

        #region Peek Message Native
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);
        #endregion

        bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }

        public ShaderViewer()
        {
            InitializeComponent();
            glControl1.Load += glControl1_Load;
        }

        void glControl1_Load(object sender, EventArgs e)
        {
            Scene = new Graphics.Scene();
            Application.Idle += HandleApplicationIdle;
            Scene.OnFrameReady += Scene_OnFrameReady;

            glControl1.Resize += glControl1_Resize;
            glControl1.MouseDown += Scene.Camera.OnMouseDown;
            glControl1.MouseMove += Scene.Camera.OnMouseMove;
            glControl1.MouseUp += Scene.Camera.OnMouseUp;
            glControl1.MouseCaptureChanged += Scene.Camera.OnMouseCaptureChanged;

            var fileName = @"C:\Users\stem\Documents\modding\mainmenu.map";
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
            MapStream file = new MapStream(fileName);
            Scene.ObjectManager.Add(file["hlmt", "masterchief"].Meta.Identifier,
                new ScenarioObject((ModelBlock)(file["hlmt", "masterchief"].Deserialize())));

            file.Tags.Where(x => x.Type.ToString() == "shad").Select(x => listView1.Items.Add(new ListViewItem(x.Path) { Tag = file[x.Identifier].Deserialize() }));

            //  firing this method is meant to load the view-projection matrix values into 
            //  the shader uniforms, and initalizes the camera
            glControl1_Resize(this, new EventArgs());
        }

        void glControl1_Resize(object sender, EventArgs e)
        {
            ChangeViewport(glControl1.Width, glControl1.Height);
        }

        private void ChangeViewport(int width, int height)
        {
            Scene.Camera.Viewport.Size = new Size(width, height);
        }

        void Scene_OnFrameReady(object sender, EventArgs e)
        {
            this.Text = Scene.Performance.FramesPerSecond.ToString();
            glControl1.SwapBuffers();
        }

        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                Scene.Update();
                Scene.RenderFrame();
            }
        }
    }
}
