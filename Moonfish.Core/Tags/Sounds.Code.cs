using Moonfish.Guerilla;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Tags
{
    partial class Sound
    {
        [GuerillaPreProcessMethod(BlockName = "sound_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
        }
    }
}
