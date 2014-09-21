using Moonfish.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.ResourceManagement
{
    using Moonfish.Graphics;
    public static class ResourceStreamStaticMethods
    {
        public static BlamPointer ReadBlamPointer(this BinaryReader binaryReader, int elementSize)
        {
            if (binaryReader.BaseStream is ResourceStream)
            {
                var stream = binaryReader.BaseStream as ResourceStream;
                var offset = stream.Position;
                binaryReader.BaseStream.Seek(8, SeekOrigin.Current);
                var resource = stream.Resources.Where(x => x.primaryLocator == offset && x.type != GlobalGeometryBlockResourceBlock.Type.VertexBuffer).SingleOrDefault();
                if (resource == null)
                {
                    return new BlamPointer(0, 0, elementSize);
                }
                else
                {
                    var count = resource.resourceDataSize / resource.secondaryLocator;
                    var address = resource.resourceDataOffset + stream.HeaderSize;
                    var size = resource.secondaryLocator;
                    return new BlamPointer(count, address, elementSize);
                }
            }
            else
            {
                return new BlamPointer(binaryReader.ReadInt32(), binaryReader.ReadInt32(), elementSize);
            }
        }
    }

    public class ResourceStream : MemoryStream
    {

        public IList<GlobalGeometryBlockResourceBlock> Resources { get; private set; }

        public int HeaderSize { get; private set; }

        public ResourceStream(byte[] buffer, GlobalGeometryBlockInfoStruct blockInfo)
            : base(buffer)
        {
            HeaderSize = blockInfo.sectionDataSize;
            Resources = blockInfo.resources;
        }

        public new enum SeekOrigin
        {
            Header,
            Data,
        }

        public new long Seek(long offset, SeekOrigin loc)
        {
            switch (loc)
            {
                case SeekOrigin.Header:
                    return base.Seek(offset, System.IO.SeekOrigin.Begin);
                case SeekOrigin.Data:
                    return base.Seek(HeaderSize + offset, System.IO.SeekOrigin.Begin);

            }
            return base.Seek(offset, System.IO.SeekOrigin.Begin);
        }
    }
}
