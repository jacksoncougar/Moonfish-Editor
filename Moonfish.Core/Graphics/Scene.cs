using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Moonfish.Graphics
{
    public class Scene
    {
        public Performance Performance { get; private set; }
        public MeshManager ObjectManager { get; set; }
        Dictionary<string, Program> Shaders { get; set; }
        Stopwatch Timer { get; set; }
        Camera Camera { get; set; }

        public event EventHandler OnFrameReady;

        public Scene()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            Console.WriteLine(GL.GetString(StringName.Version));
            Timer = new Stopwatch();
            Camera = new Camera();
            Shaders = new Dictionary<string, Program>();
            ObjectManager = new MeshManager();
            Performance = new Performance();
        }

        public virtual void RenderFrame()
        {
            Console.WriteLine("RenderFrame()");
            BeginFrame();
            Draw(Performance.Delta);
            EndFrame();
        }

        private void EndFrame()
        {
            Console.WriteLine("EndFrame()");
            Performance.EndFrame();
            if (OnFrameReady != null) OnFrameReady(this, new EventArgs());
        }

        private void BeginFrame()
        {
            Console.WriteLine("BeginFrame()");
            Performance.BeginFrame();
        }

        public virtual void Draw(float delta)
        {
            Console.WriteLine("Draw()");
            ObjectManager.Draw();
        }

        public virtual void Update()
        {
            Console.WriteLine("Update()");
        }
    };
}
