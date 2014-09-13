using Moonfish.Guerilla;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Tags
{
    partial class StructureBinarySeperationPlane
    {
        [GuerillaPreProcessMethod(BlockName = "scenario_structure_bsp_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            fields.Insert(0, new tag_field() { type = field_type._field_pad, Name = "padding", definition = 8 });
            fields.Insert(1, new tag_field() { type = field_type._field_tag_reference, Name = "sbsp" });
        }
    }
    public partial class CollisionBSPPhysicsBlock
    {
        [GuerillaPreProcessMethod(BlockName = "collision_bsp_physics_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            var field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
            fields.Insert(fields.IndexOf(fields.Last()), new tag_field() { type = field_type._field_pad, Name = "padding", definition = 4 });
        }
    }
    public partial class DecoratorCacheBlockBlock
    {
        [GuerillaPreProcessMethod(BlockName = "decorator_cache_block_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            var field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
            field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
        }
    }
}
