using Moonfish.Guerilla;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Tags
{

    public partial class Biped
    {
        [GuerillaPreProcessMethod(BlockName = "biped_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            //var paddingfield = fields.Last(x => x.type != field_type._field_pad && x.definition == 8);
            //fields.Remove(paddingfield);
            //paddingfield = fields.Last(x => x.type != field_type._field_pad && x.definition == 8);
            //fields.Remove(paddingfield);
            //fields.Insert(fields.IndexOf(fields.Last()), new tag_field() { type = field_type._field_pad, Name = "padding", definition = 16 });
        }
    }
}
