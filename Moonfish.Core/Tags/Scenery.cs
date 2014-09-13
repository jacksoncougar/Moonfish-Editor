using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Tags
{
    [TagClass("scen")]
    public partial class Scenery
    {
        [TagReference("hlmt", Offset = 52)]
        public TagReference hierarchyModel;

        public HierarchyModel HierarchyModel { get { return Halo2.GetReferenceObject(hierarchyModel); } }
    }
}
