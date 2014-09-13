using Moonfish.Guerilla;
using Moonfish.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Model
{
    [GuerillaType(field_type._field_real_bounds)]
    [GuerillaType(field_type._field_angle_bounds)]
    public struct Range
    {
        public readonly float min;
        public readonly float max;

        public Range(float min1, float max1)
        {
            // TODO: Complete member initialization
            this.min = min1;
            this.max = max1;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", min, max);
        }

        public static Range Include(Range x, float p)
        {
            float min = x.min;
            float max = x.max;
            if (x.min > p) min = p;
            if (x.max < p) max = p;
            return new Range(min, max);
        }

        public static Range Expand(Range x, float p)
        {
            float min = x.min;
            float max = x.max;
            min -= p;
            max += p;
            return new Range(min, max);
        }

        /// <summary>
        /// Truncates the passed value to the closest value in range if value is outside of the range (range.min or range.max)
        /// Else returns the value unchanged.
        /// </summary>
        /// <param name="range">The range of values to check against</param>
        /// <param name="value">The value to truncate</param>
        /// <returns>The truncated value</returns>
        public static float Truncate(Range range, float value)
        {
            if (value < range.min) return range.min;
            if (value > range.max) return range.max;
            return value;
        }

        public static float Median(Range range)
        {
            return (range.min + range.max) * 0.5f;
        }

        /// <summary>
        /// Maps values outside of the range back into the range using the magnitude of the 
        /// value from the closest range-boundary (min or max)
        /// [min₁..max₁][min₂..max₂] .. [minₓ..maxₓ]
        /// </summary>
        /// <param name="range"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Wrap(Range range, float value)
        {
            var wrapped_value = value < range.min ? range.max + (value - range.min) % (range.max - range.min):
                value > range.max ? range.min + (value - range.min) % (range.max - range.min) : value;
            return wrapped_value;
        }

        public float Length { get { return max - min; } }
    }
}
