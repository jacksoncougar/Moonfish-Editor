using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Moonfish
{
    public interface IMeta
    {
        void CopyFrom(Stream source);
        int Size { get; }
    }
}