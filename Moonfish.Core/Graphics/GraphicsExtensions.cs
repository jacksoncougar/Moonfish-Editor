using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public static class ColorExtensions
    {
        public static float[] ToFloatRgba(this Color color)
        {
            var components = new[] { color.R, color.G, color.B, color.A };
            return Array.ConvertAll(components, x=>(float)x / 255f);
        }
    }
}
