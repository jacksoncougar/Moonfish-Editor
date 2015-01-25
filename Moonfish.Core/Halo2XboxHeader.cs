using Moonfish.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish
{
    public struct Halo2XboxHeader
    {
        int fileSize;
        int indexAddress;
        int intdexLength;
        int tagsDataLength;
        int cacheLength;
        String32 buildData;
        int strings128DataAddress;
        int stringsCount;
        int stringsDataLength;
        int stringsIndexAddress;
        int stringsDataAddress;
        String32 name;
        String32 scenario;
        int pathsCount;
        int pathsDataAddress;
        int pathsDataLength;
        int pathsIndexAddress;

    }
}
