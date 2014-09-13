using Moonfish.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Moonfish
{
    /* Intent: Create a class which contains a TagStruct and links all the references 
     * in that struct to local resources or local lookup tables. The tag in a wrapper 
     * state should have all the data it needs to recompile¹ into a cache map
     * 
     * Implementation:
     * • list of strings for stringID references, 
     * • list of filepaths(?) for TagIdent references
     * • list of tagIDs + addresses(?) for External Tagblock references
     * • list of addresses + ids for internal TagBlocks?
     */

    public class TagWrapper
    {
        TagBlock tag_;
        List<KeyValuePair<StringID, string>> local_strings_ = new List<KeyValuePair<StringID, string>>();
        HashSet<TagIdent> tag_ids_ = new HashSet<TagIdent>();
        List<object> tag_blocks = new List<object>();

        public TagWrapper(TagBlock tag, MapStream map, Tag meta)
        {
            tag_ = tag;
            /* Enumerate through all the StringIDs in this tag, check to see if they exist in the Globals list, 
             * if not we should add them locally and update the StringID value to point to the list*/
            foreach (StringID string_id in tag as IEnumerable<StringID>)
            {
                if (Halo2.Strings.Contains(string_id)) continue;
                else
                {
                    var string_value = map.Strings[string_id.Index];
                    var entry = new KeyValuePair<StringID, string>(string_id, string_value);
                    local_strings_.Add(entry);
                    var index = local_strings_.IndexOf(entry);
                    short string_id_index = (short)(index |= 0x8000);
                    sbyte string_length = (sbyte)Encoding.UTF8.GetByteCount(string_value);
                    var bytes = BitConverter.GetBytes((int)new StringID(string_id_index, string_length));
                    //((IField)string_id).SetFieldData(bytes);
                    throw new Exception();
                }
            }
            foreach (TagIdent tag_id in tag as IEnumerable<TagIdent>)
            {
                tag_ids_.Add(tag_id);
            }
            /*Intent: to build a list of all tagblock addresses in tag
             */
            foreach (var array in tag as IEnumerable<IFieldArray>)
            {
                var address = array.Address;
                if (array.Fields.Count() > 0)
                {
                    var item = new { Address = address, Size = array.Fields[0].Size, Count = array.Fields.Count() };
                    tag_blocks.Add(item);
                    if (meta.Contains(item.Address))
                    {
                    }
                }
            }
            /* Intent: check every tag_block in the list for being external
             * if it is external build a reference list and add information about the tag_block
             * to that list.
             * address => [count, size]?
             * */

        }
    }
}