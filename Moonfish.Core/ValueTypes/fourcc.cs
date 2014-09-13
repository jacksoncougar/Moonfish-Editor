using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.ValueTypes
{
    struct fourcc
    {
        public readonly byte msb0;
        public readonly byte msb1;
        public readonly byte lsb2;
        public readonly byte lsb3;

        public fourcc(byte in_msb0, byte in_msb1, byte in_lsb2, byte in_lsb3)
        {
            msb0 = in_msb0;
            msb1 = in_msb1;
            lsb2 = in_lsb2;
            lsb3 = in_lsb3;
        }

        public fourcc(string value)
            : this()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);

            switch (bytes.Length)
            {
                case 4: msb0 = bytes[3];
                    goto case 3;
                case 3: msb1 = bytes[2];
                    goto case 2;
                case 2: lsb2 = bytes[1];
                    goto case 1;
                case 1: lsb3 = bytes[0];
                    break;
                case 0: break;
                default: goto case 4;
            }
        }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(new byte[] { msb0, msb1, lsb2, lsb3 });
        }
    }

    static class fourcc_extensions
    {
        public static void WriteFourcc(this System.IO.BinaryWriter writer, fourcc code)
        {
            byte[] buffer = { code.msb0, code.msb1, code.lsb2, code.lsb3 };
            writer.Write(buffer);
        }

        public static fourcc ReadFourcc(this System.IO.BinaryReader reader)
        {
            var buffer = reader.ReadBytes(4);
            fourcc code = new fourcc(buffer[0], buffer[1], buffer[2], buffer[3]);
            return code;
        }
    }
}
