using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{
    public class Performance
    {
        struct FrameInfo
        {
            public float RenderTime;
            public float WaitTime;
        }

        public float FramesPerSecond { get; private set; }

        Stopwatch Timer;
        FrameInfo[] frameHistory;
        int index = 0;

        const int Size = 50;

        TimeSpan frameStart, frameEnd;

        public Performance()
        {
            Timer = new Stopwatch();
            frameHistory = new FrameInfo[Size];
            Timer.Start();
        }

        public void BeginFrame()
        {
            frameStart = Timer.Elapsed;
        }

        public void EndFrame()
        {
            frameEnd = Timer.Elapsed;

            var elapsed = (frameEnd - frameStart).Milliseconds;
            frameHistory[++index >= Size ? index = 0 : index] = new FrameInfo() { RenderTime = elapsed };
            var sum = 0.0f;
            foreach (var value in frameHistory) sum += value.RenderTime;
            FramesPerSecond = (float)(1000f / (sum / frameHistory.Length));
        }

        public float Delta { get { return (Timer.Elapsed - frameEnd).Milliseconds; } }
    }
}
