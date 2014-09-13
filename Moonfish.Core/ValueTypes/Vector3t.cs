using OpenTK;
using System;
using System.IO;

namespace Moonfish.Model
{
    /// <summary>
    /// My hacky attempt at unit testing :)
    /// </summary>
    public static class UT_Vector3t
    {
        public static bool RunTests() { return false; }
        static UT_Vector3t()
        {
            if (Vector3.UnitX != (Vector3)(Vector3T)Vector3.UnitX) throw new Exception();
            if (Vector3.UnitY != (Vector3)(Vector3T)Vector3.UnitY) throw new Exception();
            if (Vector3.UnitZ != (Vector3)(Vector3T)Vector3.UnitZ) throw new Exception();
            if (-Vector3.UnitX != (Vector3)(Vector3T)(-Vector3.UnitX)) throw new Exception();
            if (-Vector3.UnitY != (Vector3)(Vector3T)(-Vector3.UnitY)) throw new Exception();
            if (-Vector3.UnitZ != (Vector3)(Vector3T)(-Vector3.UnitZ)) throw new Exception();
        }
    }

    /// <summary>
    /// A one-third vector where each componant is restricted to the range of:  { x | 0.0 <= x <= 1.0 }
    /// Each combonent is stored as a 10 or 11 bit value: of which a single bit is reserved for sign, 
    /// and the remainder used for the magnitude.
    /// </summary>
    public struct Vector3T
    {
        const float z_max_inverse = 1 / (float)0x1FF;
        const float xy_max_inverse = 1 / (float)0x3FF;

        private uint bits;

        public float X
        {
            get
            {
                ushort radix = (ushort)(bits >> 00 & 0x7FF);                // retrieve the bits of this componant (first 11 bits)
                if (radix == 0x7FF || radix == 0) return 0;                 // two special cases for zero: return zero on either
                if ((radix & 0x400) == 0x400)                               // if sign bit is set, output should be negetive
                    return -(float)(~(radix) & 0x3FF) * xy_max_inverse;     /* return the radix 'ones compliment' trimming the sign bit
                                                                             * return the negetive value*/
                else                                                        /* else just return the radix value multiplied by the pre-
                                                                             * calculated ratio */
                    return (float)(radix) * xy_max_inverse;
            }
            set
            {
                bits &= ~(uint)0x7FF;
                var x_bits = (uint)(value < 0 ? 0x400 | ~(uint)(-value * 0x3FF) & 0x7FF : (uint)(value * 0x3FF) & 0x3FF);
                bits |= x_bits;
            }
        }
        public float Y
        {
            get
            {
                ushort radix = (ushort)(bits >> 11 & 0x7FF);                // retrieve the bits of this componant (first 11 bits)
                if (radix == 0x7FF || radix == 0) return 0;                 // two special cases for zero: return zero on either
                if ((radix & 0x400) == 0x400)                               // if sign bit is set, output should be negetive
                    return -(float)(~(radix) & 0x3FF) * xy_max_inverse;     /* return the radix 'ones compliment' trimming the sign bit
                                                                             * return the negetive value*/
                else                                                        /* else just return the radix value multiplied by the pre-
                                                                             * calculated ratio */
                    return (float)(radix) * xy_max_inverse;
            }
            set
            {
                bits &= ~(uint)0x7FF << 11 | 0x7FF;
                var y_bits = (uint)(value < 0 ? 0x400 | ~(uint)(-value * 0x3FF) & 0x7FF : (uint)(value * 0x3FF) & 0x3FF);
                bits |= y_bits << 11;
            }
        }
        public float Z
        {
            get
            {
                ushort radix = (ushort)(bits >> 22 & 0x3FF);                // retrieve the bits of this componant (first 10 bits)
                if (radix == 0x7FF || radix == 0) return 0;                 // two special cases for zero: return zero on either
                if ((radix & 0x200) == 0x200)                               // if sign bit is set, output should be negetive
                    return -(float)(~(radix) & 0x1FF) * z_max_inverse;     /* return the radix 'ones compliment' trimming the sign bit
                                                                             * return the negetive value*/
                else                                                        /* else just return the radix value multiplied by the pre-
                                                                             * calculated ratio */
                    return (float)(radix) * z_max_inverse;
            }
            set
            {
                bits &= 0x003FFFFF;
                var z_bits = (uint)(value < 0 ? 0x200 | ~(uint)(-value * 0x1FF) & 0x3FF : (uint)(value * 0x1FF) & 0x1FF);
                bits |= z_bits << 22;
            }
        }

        public Vector3T(uint value)
        {
            bits = value;
            UT_Vector3t.RunTests();
            Vector3 test = new Vector3(X, Y, Z); float rounded;
            if ((rounded = (float)System.Math.Round(test.Length, 2)) != 1)
            {
                Log.Warn("Zero vector found?");
            }
        }

        public static explicit operator Vector3(Vector3T tvector)
        {
            return new Vector3(x: tvector.X, y: tvector.Y, z: tvector.Z);
        }
        public static explicit operator Vector3T(Vector3 vector3)
        {
            return new Vector3T() { X = vector3.X, Y = vector3.Y, Z = vector3.Z };
        }
        public static explicit operator uint(Vector3T tvector)
        {
            return tvector.bits;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }

    public struct short_vector3
    {
        public short x;
        public short y; 
        public short z;
    }

    public struct UnitVertexNode1
    {
        short_vector3 position;
        byte bone_index;

        public static UnitVertexNode1 FromStream(BinaryReader reader)
        {
            UnitVertexNode1 vertex = new UnitVertexNode1()
            {
                position = new short_vector3()
                {
                    x = reader.ReadInt16(),
                    y = reader.ReadInt16(),
                    z = reader.ReadInt16(),
                },
                bone_index = reader.ReadByte()
            };
            reader.ReadByte(); // padding
            return vertex;
        }
    }
}
