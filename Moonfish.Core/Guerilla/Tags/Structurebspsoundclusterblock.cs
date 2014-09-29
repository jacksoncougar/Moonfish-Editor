using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class StructureBspsoundClusterblock
    {
        byte[] invalidName_;
        byte[] invalidName_0;
        StructuresoundClusterPortalDesignators[] enclosingPortalDesignators;
        StructuresoundClusterInteriorclusterindices[] interiorClusterIndices;
        internal  StructureBspsoundClusterblock(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.enclosingPortalDesignators = ReadStructuresoundClusterPortalDesignatorsArray(binaryReader);
            this.interiorClusterIndices = ReadStructuresoundClusterInteriorclusterindicesArray(binaryReader);
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
        StructuresoundClusterPortalDesignators[] ReadStructuresoundClusterPortalDesignatorsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructuresoundClusterPortalDesignators));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructuresoundClusterPortalDesignators[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructuresoundClusterPortalDesignators(binaryReader);
                }
            }
            return array;
        }
        StructuresoundClusterInteriorclusterindices[] ReadStructuresoundClusterInteriorclusterindicesArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructuresoundClusterInteriorclusterindices));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructuresoundClusterInteriorclusterindices[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructuresoundClusterInteriorclusterindices(binaryReader);
                }
            }
            return array;
        }
    };
}
