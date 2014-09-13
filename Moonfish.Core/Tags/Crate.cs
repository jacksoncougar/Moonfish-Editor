using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Tags
{
    [TagClass("bloc")]
    public class Crate
    {
        [TagReference("hlmt", Offset = 52)]
        public HierarchyModel HierarchyModel;
    }
}
