using Moonfish.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    class ResourceCollection
    {
        fourcc header_fourcc;
        int size;
        int[] resource_counts;
        List<Resource> resources;

        ResourceCollection()
        {
            header_fourcc = new fourcc("blkh");
            size = 0;
            resource_counts = new int[0];
        }
    }

    class Resource
    {
        fourcc resource_fourcc;
    }

    class Resource<T>:Resource
    {
        T resource;
    }

    
}
