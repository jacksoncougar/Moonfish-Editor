using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class VisibilityStructBlock
    {
        short projectionCount;
        short clusterCount;
        short volumeCount;
        byte[] invalidName_;
        byte[] projections;
        byte[] visibilityClusters;
        byte[] clusterRemapTable;
        byte[] visibilityVolumes;
        internal  VisibilityStructBlock(BinaryReader binaryReader)
        {
            this.projectionCount = binaryReader.ReadInt16();
            this.clusterCount = binaryReader.ReadInt16();
            this.volumeCount = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.projections = ReadData(binaryReader);
            this.visibilityClusters = ReadData(binaryReader);
            this.clusterRemapTable = ReadData(binaryReader);
            this.visibilityVolumes = ReadData(binaryReader);
        }
        byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
