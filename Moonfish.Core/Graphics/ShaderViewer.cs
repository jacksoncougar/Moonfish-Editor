using Moonfish.Guerilla.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            MapStream file = new MapStream(@"C:\Users\stem\Documents\modding\shared.map");
            Scene.ObjectManager.Add( file["mode", "box"].Meta.Identifier, 
                new ScenarioObject((ModelBlock)(file["hlmt", "box"].Deserialize())));
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
