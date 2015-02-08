using System.Collections.Generic;
using System.IO;

namespace Moonfish.Guerilla.Preprocess
{
    public partial class TagBlockIndexStructBlock
    {
        [GuerillaPreProcessMethod(BlockName = "tag_block_index_struct_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            fields.Clear();
            fields.Add(new tag_field() { Name = "Index0", type = field_type._field_char_integer });
            fields.Add(new tag_field() { Name = "Index1", type = field_type._field_char_integer });
            fields.Add(new tag_field() { type = field_type._field_terminator });
        }
    }
}
