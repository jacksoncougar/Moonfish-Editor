using Moonfish.Model;
using Moonfish.ResourceManagement;
using OpenTK;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Moonfish.Tags
{
    [StructLayout(LayoutKind.Sequential, Size = 132, Pack = 4)]
    [TagClass("mode")]
    public partial class RenderModel
    {
        public StringID name;
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding0;
        #endregion
        [TagBlockField]
        public GlobalTagImportInfoBlock[] importInfo;
        [TagBlockField]
        public GlobalGeometryCompressionInfoBlock[] compressionInfo;
        [TagBlockField]
        public RenderModelRegionBlock[] regions;
        [TagBlockField]
        public RenderModelSectionBlock[] sections;
        [TagBlockField]
        public RenderModelInvalidSectionPairsBlock[] invalidSectionPairBits;
        [TagBlockField]
        public RenderModelSectionGroupBlock[] sectionGroups;
        public byte l1SectionGroupIndexSuperLow;
        public byte l2SectionGroupIndexLow;
        public byte l3SectionGroupIndexMedium;
        public byte l4SectionGroupIndexHigh;
        public byte l5SectionGroupIndexSuperHigh;
        public byte l6SectionGroupIndexHollywood;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding1;
        #endregion
        public int nodeListChecksum;
        [TagBlockField]
        public RenderModelNodeBlock[] nodes;
        [TagBlockField]
        public RenderModelNodeMapBlockOLD[] nodeMapOLD;
        [TagBlockField]
        public RenderModelMarkerGroupBlock[] markerGroups;
        [TagBlockField]
        public GlobalGeometryMaterialBlock[] materials;
        [TagBlockField]
        public GlobalErrorReportCategoriesBlock[] errors;
        public float dontDrawOverCameraCosineAngleDontDrawFpModelWhenCameraThisAngleCosine11Sugg020Disables;
        [TagBlockField]
        public PrtInfoBlock[] pRTInfo;
        [TagBlockField]
        public SectionRenderLeavesBlock[] sectionRenderLeaves;
        public RenderModel()
        {
        }
        public RenderModel(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(4);
            this.importInfo = ReadImportinfo(binaryReader);
            this.compressionInfo = ReadCompressioninfo(binaryReader);
            this.regions = ReadRegions(binaryReader);
            this.sections = ReadSections(binaryReader);
            this.invalidSectionPairBits = ReadInvalidsectionpairbits(binaryReader);
            this.sectionGroups = ReadSectiongroups(binaryReader);
            this.l1SectionGroupIndexSuperLow = binaryReader.ReadByte();
            this.l2SectionGroupIndexLow = binaryReader.ReadByte();
            this.l3SectionGroupIndexMedium = binaryReader.ReadByte();
            this.l4SectionGroupIndexHigh = binaryReader.ReadByte();
            this.l5SectionGroupIndexSuperHigh = binaryReader.ReadByte();
            this.l6SectionGroupIndexHollywood = binaryReader.ReadByte();
            this.padding1 = binaryReader.ReadBytes(2);
            this.nodeListChecksum = binaryReader.ReadInt32();
            this.nodes = ReadNodes(binaryReader);
            this.nodeMapOLD = ReadNodemapold(binaryReader);
            this.markerGroups = ReadMarkergroups(binaryReader);
            this.materials = ReadMaterials(binaryReader);
            this.errors = ReadErrors(binaryReader);
            this.dontDrawOverCameraCosineAngleDontDrawFpModelWhenCameraThisAngleCosine11Sugg020Disables = binaryReader.ReadSingle();
            this.pRTInfo = ReadPrtinfo(binaryReader);
            this.sectionRenderLeaves = ReadSectionrenderleaves(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.name);
            binaryWriter.Write((Int16)this.flags);
            binaryWriter.Write(this.padding);
            binaryWriter.Write(this.padding0);
            WriteImportinfo(binaryWriter);
            WriteCompressioninfo(binaryWriter);
            WriteRegions(binaryWriter);
            WriteSections(binaryWriter);
            WriteInvalidsectionpairbits(binaryWriter);
            WriteSectiongroups(binaryWriter);
            binaryWriter.Write(this.l1SectionGroupIndexSuperLow);
            binaryWriter.Write(this.l2SectionGroupIndexLow);
            binaryWriter.Write(this.l3SectionGroupIndexMedium);
            binaryWriter.Write(this.l4SectionGroupIndexHigh);
            binaryWriter.Write(this.l5SectionGroupIndexSuperHigh);
            binaryWriter.Write(this.l6SectionGroupIndexHollywood);
            binaryWriter.Write(this.padding1);
            binaryWriter.Write(this.nodeListChecksum);
            WriteNodes(binaryWriter);
            WriteNodemapold(binaryWriter);
            WriteMarkergroups(binaryWriter);
            WriteMaterials(binaryWriter);
            WriteErrors(binaryWriter);
            binaryWriter.Write(this.dontDrawOverCameraCosineAngleDontDrawFpModelWhenCameraThisAngleCosine11Sugg020Disables);
            WritePrtinfo(binaryWriter);
            WriteSectionrenderleaves(binaryWriter);
        }
        [Flags]
        public enum Flags : short
        {
            RenderModelForceThirdPersonBit = 1,
            ForceCarmackReverse = 2,
            ForceNodeMaps = 4,
            GeometryPostprocessed = 8,
        }
        public virtual GlobalTagImportInfoBlock[] ReadImportinfo(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalTagImportInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var importInfo = new GlobalTagImportInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    importInfo[i] = new GlobalTagImportInfoBlock(binaryReader);
                }
            }
            return importInfo;
        }
        public virtual void WriteImportinfo(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalTagImportInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.importInfo.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.importInfo[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalGeometryCompressionInfoBlock[] ReadCompressioninfo(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryCompressionInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var compressionInfo = new GlobalGeometryCompressionInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    compressionInfo[i] = new GlobalGeometryCompressionInfoBlock(binaryReader);
                }
            }
            return compressionInfo;
        }
        public virtual void WriteCompressioninfo(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryCompressionInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.compressionInfo.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.compressionInfo[i].Write(binaryWriter);
                }
            }
        }
        public virtual RenderModelRegionBlock[] ReadRegions(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelRegionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var regions = new RenderModelRegionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    regions[i] = new RenderModelRegionBlock(binaryReader);
                }
            }
            return regions;
        }
        public virtual void WriteRegions(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelRegionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.regions.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.regions[i].Write(binaryWriter);
                }
            }
        }
        public virtual RenderModelSectionBlock[] ReadSections(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelSectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var sections = new RenderModelSectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    sections[i] = new RenderModelSectionBlock(binaryReader);
                }
            }
            return sections;
        }
        public virtual void WriteSections(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelSectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.sections.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.sections[i].Write(binaryWriter);
                }
            }
        }
        public virtual RenderModelInvalidSectionPairsBlock[] ReadInvalidsectionpairbits(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelInvalidSectionPairsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var invalidSectionPairBits = new RenderModelInvalidSectionPairsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    invalidSectionPairBits[i] = new RenderModelInvalidSectionPairsBlock(binaryReader);
                }
            }
            return invalidSectionPairBits;
        }
        public virtual void WriteInvalidsectionpairbits(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelInvalidSectionPairsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.invalidSectionPairBits.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.invalidSectionPairBits[i].Write(binaryWriter);
                }
            }
        }
        public virtual RenderModelSectionGroupBlock[] ReadSectiongroups(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelSectionGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var sectionGroups = new RenderModelSectionGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    sectionGroups[i] = new RenderModelSectionGroupBlock(binaryReader);
                }
            }
            return sectionGroups;
        }
        public virtual void WriteSectiongroups(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelSectionGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.sectionGroups.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.sectionGroups[i].Write(binaryWriter);
                }
            }
        }
        public virtual RenderModelNodeBlock[] ReadNodes(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var nodes = new RenderModelNodeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    nodes[i] = new RenderModelNodeBlock(binaryReader);
                }
            }
            return nodes;
        }
        public virtual void WriteNodes(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.nodes.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.nodes[i].Write(binaryWriter);
                }
            }
        }
        public virtual RenderModelNodeMapBlockOLD[] ReadNodemapold(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelNodeMapBlockOLD));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var nodeMapOLD = new RenderModelNodeMapBlockOLD[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    nodeMapOLD[i] = new RenderModelNodeMapBlockOLD(binaryReader);
                }
            }
            return nodeMapOLD;
        }
        public virtual void WriteNodemapold(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelNodeMapBlockOLD));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.nodeMapOLD.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.nodeMapOLD[i].Write(binaryWriter);
                }
            }
        }
        public virtual RenderModelMarkerGroupBlock[] ReadMarkergroups(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelMarkerGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var markerGroups = new RenderModelMarkerGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    markerGroups[i] = new RenderModelMarkerGroupBlock(binaryReader);
                }
            }
            return markerGroups;
        }
        public virtual void WriteMarkergroups(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelMarkerGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.markerGroups.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.markerGroups[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalGeometryMaterialBlock[] ReadMaterials(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var materials = new GlobalGeometryMaterialBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    materials[i] = new GlobalGeometryMaterialBlock(binaryReader);
                }
            }
            return materials;
        }
        public virtual void WriteMaterials(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.materials.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.materials[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalErrorReportCategoriesBlock[] ReadErrors(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var errors = new GlobalErrorReportCategoriesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    errors[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                }
            }
            return errors;
        }
        public virtual void WriteErrors(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.errors.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.errors[i].Write(binaryWriter);
                }
            }
        }
        public virtual PrtInfoBlock[] ReadPrtinfo(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(PrtInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var pRTInfo = new PrtInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    pRTInfo[i] = new PrtInfoBlock(binaryReader);
                }
            }
            return pRTInfo;
        }
        public virtual void WritePrtinfo(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(PrtInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.pRTInfo.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.pRTInfo[i].Write(binaryWriter);
                }
            }
        }
        public virtual SectionRenderLeavesBlock[] ReadSectionrenderleaves(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(SectionRenderLeavesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var sectionRenderLeaves = new SectionRenderLeavesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    sectionRenderLeaves[i] = new SectionRenderLeavesBlock(binaryReader);
                }
            }
            return sectionRenderLeaves;
        }
        public virtual void WriteSectionrenderleaves(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(SectionRenderLeavesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.sectionRenderLeaves.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.sectionRenderLeaves[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 528, Pack = 4)]
    public partial class TagImportFileBlock
    {
        public String256 path;
        public String32 modificationDate;
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] skip;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
        private byte[] padding0;
        #endregion
        public int checksumCrc32;
        public int sizeBytes;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingzippedData;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        private byte[] padding1;
        #endregion
        public TagImportFileBlock()
        {
        }
        public TagImportFileBlock(BinaryReader binaryReader)
        {
            this.path = binaryReader.ReadString256();
            this.modificationDate = binaryReader.ReadString32();
            this.skip = binaryReader.ReadBytes(8);
            this.padding0 = binaryReader.ReadBytes(88);
            this.checksumCrc32 = binaryReader.ReadInt32();
            this.sizeBytes = binaryReader.ReadInt32();
            this.paddingzippedData = binaryReader.ReadBytes(8);
            this.padding1 = binaryReader.ReadBytes(128);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.path);
            binaryWriter.Write(this.modificationDate);
            binaryWriter.Write(this.skip);
            binaryWriter.Write(this.padding0);
            binaryWriter.Write(this.checksumCrc32);
            binaryWriter.Write(this.sizeBytes);
            binaryWriter.Write(this.paddingzippedData, 0, 8);
            binaryWriter.Write(this.padding1);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 592, Pack = 4)]
    public partial class GlobalTagImportInfoBlock
    {
        public int build;
        public String256 version;
        public String32 importDate;
        public String32 culprit;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        private byte[] padding;
        #endregion
        public String32 importTime;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding0;
        #endregion
        [TagBlockField]
        public TagImportFileBlock[] files;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        private byte[] padding1;
        #endregion
        public GlobalTagImportInfoBlock()
        {
        }
        public GlobalTagImportInfoBlock(BinaryReader binaryReader)
        {
            this.build = binaryReader.ReadInt32();
            this.version = binaryReader.ReadString256();
            this.importDate = binaryReader.ReadString32();
            this.culprit = binaryReader.ReadString32();
            this.padding = binaryReader.ReadBytes(96);
            this.importTime = binaryReader.ReadString32();
            this.padding0 = binaryReader.ReadBytes(4);
            this.files = ReadFiles(binaryReader);
            this.padding1 = binaryReader.ReadBytes(128);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.build);
            binaryWriter.Write(this.version);
            binaryWriter.Write(this.importDate);
            binaryWriter.Write(this.culprit);
            binaryWriter.Write(this.padding);
            binaryWriter.Write(this.importTime);
            binaryWriter.Write(this.padding0);
            WriteFiles(binaryWriter);
            binaryWriter.Write(this.padding1);
        }
        public virtual TagImportFileBlock[] ReadFiles(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(TagImportFileBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var files = new TagImportFileBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    files[i] = new TagImportFileBlock(binaryReader);
                }
            }
            return files;
        }
        public virtual void WriteFiles(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(TagImportFileBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.files.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.files[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 4)]
    public partial class GlobalGeometryCompressionInfoBlock
    {
        public Range positionBoundsX;
        public Range positionBoundsY;
        public Range positionBoundsZ;
        public Range texcoordBoundsX;
        public Range texcoordBoundsY;
        public Range secondaryTexcoordBoundsX;
        public Range secondaryTexcoordBoundsY;
        public GlobalGeometryCompressionInfoBlock()
        {
        }
        public GlobalGeometryCompressionInfoBlock(BinaryReader binaryReader)
        {
            this.positionBoundsX = binaryReader.ReadRange();
            this.positionBoundsY = binaryReader.ReadRange();
            this.positionBoundsZ = binaryReader.ReadRange();
            this.texcoordBoundsX = binaryReader.ReadRange();
            this.texcoordBoundsY = binaryReader.ReadRange();
            this.secondaryTexcoordBoundsX = binaryReader.ReadRange();
            this.secondaryTexcoordBoundsY = binaryReader.ReadRange();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.positionBoundsX);
            binaryWriter.Write(this.positionBoundsY);
            binaryWriter.Write(this.positionBoundsZ);
            binaryWriter.Write(this.texcoordBoundsX);
            binaryWriter.Write(this.texcoordBoundsY);
            binaryWriter.Write(this.secondaryTexcoordBoundsX);
            binaryWriter.Write(this.secondaryTexcoordBoundsY);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class RenderModelPermutationBlock
    {
        public StringID name;
        public short l1SectionIndexSuperLow;
        public short l2SectionIndexLow;
        public short l3SectionIndexMedium;
        public short l4SectionIndexHigh;
        public short l5SectionIndexSuperHigh;
        public short l6SectionIndexHollywood;
        public RenderModelPermutationBlock()
        {
        }
        public RenderModelPermutationBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.l1SectionIndexSuperLow = binaryReader.ReadInt16();
            this.l2SectionIndexLow = binaryReader.ReadInt16();
            this.l3SectionIndexMedium = binaryReader.ReadInt16();
            this.l4SectionIndexHigh = binaryReader.ReadInt16();
            this.l5SectionIndexSuperHigh = binaryReader.ReadInt16();
            this.l6SectionIndexHollywood = binaryReader.ReadInt16();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.name);
            binaryWriter.Write(this.l1SectionIndexSuperLow);
            binaryWriter.Write(this.l2SectionIndexLow);
            binaryWriter.Write(this.l3SectionIndexMedium);
            binaryWriter.Write(this.l4SectionIndexHigh);
            binaryWriter.Write(this.l5SectionIndexSuperHigh);
            binaryWriter.Write(this.l6SectionIndexHollywood);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class RenderModelRegionBlock
    {
        public StringID name;
        public short nodeMapOffsetOLD;
        public short nodeMapSizeOLD;
        [TagBlockField]
        public RenderModelPermutationBlock[] permutations;
        public RenderModelRegionBlock()
        {
        }
        public RenderModelRegionBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.nodeMapOffsetOLD = binaryReader.ReadInt16();
            this.nodeMapSizeOLD = binaryReader.ReadInt16();
            this.permutations = ReadPermutations(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.name);
            binaryWriter.Write(this.nodeMapOffsetOLD);
            binaryWriter.Write(this.nodeMapSizeOLD);
            WritePermutations(binaryWriter);
        }
        public virtual RenderModelPermutationBlock[] ReadPermutations(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelPermutationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var permutations = new RenderModelPermutationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    permutations[i] = new RenderModelPermutationBlock(binaryReader);
                }
            }
            return permutations;
        }
        public virtual void WritePermutations(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelPermutationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.permutations.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.permutations[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
    public partial class GlobalGeometrySectionInfoStruct
    {
        public short totalVertexCount;
        public short totalTriangleCount;
        public short totalPartCount;
        public short shadowCastingTriangleCount;
        public short shadowCastingPartCount;
        public short opaquePointCount;
        public short opaqueVertexCount;
        public short opaquePartCount;
        public byte opaqueMaxNodesVertex;
        public byte transparentMaxNodesVertex;
        public short shadowCastingRigidTriangleCount;
        public GeometryClassification geometryClassification;
        public GeometryCompressionFlags geometryCompressionFlags;
        [TagBlockField]
        public GlobalGeometryCompressionInfoBlock[] eMPTYSTRING;
        public byte hardwareNodeCount;
        public byte nodeMapSize;
        public short softwarePlaneCount;
        public short totalSubpartCont;
        public SectionLightingFlags sectionLightingFlags;
        public GlobalGeometrySectionInfoStruct()
        {
        }
        public GlobalGeometrySectionInfoStruct(BinaryReader binaryReader)
        {
            this.totalVertexCount = binaryReader.ReadInt16();
            this.totalTriangleCount = binaryReader.ReadInt16();
            this.totalPartCount = binaryReader.ReadInt16();
            this.shadowCastingTriangleCount = binaryReader.ReadInt16();
            this.shadowCastingPartCount = binaryReader.ReadInt16();
            this.opaquePointCount = binaryReader.ReadInt16();
            this.opaqueVertexCount = binaryReader.ReadInt16();
            this.opaquePartCount = binaryReader.ReadInt16();
            this.opaqueMaxNodesVertex = binaryReader.ReadByte();
            this.transparentMaxNodesVertex = binaryReader.ReadByte();
            this.shadowCastingRigidTriangleCount = binaryReader.ReadInt16();
            this.geometryClassification = (GeometryClassification)binaryReader.ReadInt16();
            this.geometryCompressionFlags = (GeometryCompressionFlags)binaryReader.ReadInt16();
            this.eMPTYSTRING = ReadEmptystring(binaryReader);
            this.hardwareNodeCount = binaryReader.ReadByte();
            this.nodeMapSize = binaryReader.ReadByte();
            this.softwarePlaneCount = binaryReader.ReadInt16();
            this.totalSubpartCont = binaryReader.ReadInt16();
            this.sectionLightingFlags = (SectionLightingFlags)binaryReader.ReadInt16();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.totalVertexCount);
            binaryWriter.Write(this.totalTriangleCount);
            binaryWriter.Write(this.totalPartCount);
            binaryWriter.Write(this.shadowCastingTriangleCount);
            binaryWriter.Write(this.shadowCastingPartCount);
            binaryWriter.Write(this.opaquePointCount);
            binaryWriter.Write(this.opaqueVertexCount);
            binaryWriter.Write(this.opaquePartCount);
            binaryWriter.Write(this.opaqueMaxNodesVertex);
            binaryWriter.Write(this.transparentMaxNodesVertex);
            binaryWriter.Write(this.shadowCastingRigidTriangleCount);
            binaryWriter.Write((Int16)this.geometryClassification);
            binaryWriter.Write((Int16)this.geometryCompressionFlags);
            WriteEmptystring(binaryWriter);
            binaryWriter.Write(this.hardwareNodeCount);
            binaryWriter.Write(this.nodeMapSize);
            binaryWriter.Write(this.softwarePlaneCount);
            binaryWriter.Write(this.totalSubpartCont);
            binaryWriter.Write((Int16)this.sectionLightingFlags);
        }
        public enum GeometryClassification : short
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        }
        [Flags]
        public enum GeometryCompressionFlags : short
        {
            CompressedPosition = 1,
            CompressedTexcoord = 2,
            CompressedSecondaryTexcoord = 4,
        }
        public virtual GlobalGeometryCompressionInfoBlock[] ReadEmptystring(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryCompressionInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var eMPTYSTRING = new GlobalGeometryCompressionInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    eMPTYSTRING[i] = new GlobalGeometryCompressionInfoBlock(binaryReader);
                }
            }
            return eMPTYSTRING;
        }
        public virtual void WriteEmptystring(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryCompressionInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.eMPTYSTRING.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.eMPTYSTRING[i].Write(binaryWriter);
                }
            }
        }
        [Flags]
        public enum SectionLightingFlags : short
        {
            HasLmTexcoords = 1,
            HasLmIncRad = 2,
            HasLmColors = 4,
            HasLmPrt = 8,
        }
    }


    [Layout(Size = 72)]
    public partial class GlobalGeometryPartBlockNew
    {
        public Type type;
        public Flags flags;
        public ShortBlockIndex1 material;
        public short stripStartIndex;
        public short stripLength;
        public short firstSubpartIndex;
        public short subpartCount;
        public byte maxNodesVertex;
        public byte contributingCompoundNodeCount;
        public Vector3 position;
        public class NodeIndices
        {
            public byte nodeIndex;
            public NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeIndex);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndices[] nodeIndices;
        public class NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeWeight);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public NodeWeights[] nodeWeights;
        public float lodMipmapMagicNumber;
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        private byte[] skip;
        #endregion
        public GlobalGeometryPartBlockNew()
        {
        }
        public GlobalGeometryPartBlockNew(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.material = binaryReader.ReadShortBlockIndex1();
            this.stripStartIndex = binaryReader.ReadInt16();
            this.stripLength = binaryReader.ReadInt16();
            this.firstSubpartIndex = binaryReader.ReadInt16();
            this.subpartCount = binaryReader.ReadInt16();
            this.maxNodesVertex = binaryReader.ReadByte();
            this.contributingCompoundNodeCount = binaryReader.ReadByte();
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndices[i] = new NodeIndices(binaryReader);
            }
            this.nodeWeights = new NodeWeights[3];
            for (int i = 0; i < 3; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.lodMipmapMagicNumber = binaryReader.ReadSingle();
            this.skip = binaryReader.ReadBytes(24);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write((Int16)this.type);
            binaryWriter.Write((Int16)this.flags);
            binaryWriter.Write(this.material);
            binaryWriter.Write(this.stripStartIndex);
            binaryWriter.Write(this.stripLength);
            binaryWriter.Write(this.firstSubpartIndex);
            binaryWriter.Write(this.subpartCount);
            binaryWriter.Write(this.maxNodesVertex);
            binaryWriter.Write(this.contributingCompoundNodeCount);
            binaryWriter.Write(this.position);
            for (int i = 0; i < this.nodeIndices.Length; ++i)
            {
                this.nodeIndices[i].Write(binaryWriter);
            }
            for (int i = 0; i < this.nodeWeights.Length; ++i)
            {
                this.nodeWeights[i].Write(binaryWriter);
            }
            binaryWriter.Write(this.lodMipmapMagicNumber);
            binaryWriter.Write(this.skip);
        }
        public enum Type : short
        {
            NotDrawn = 0,
            OpaqueShadowOnly = 1,
            OpaqueShadowCasting = 2,
            OpaqueNonshadowing = 3,
            Transparent = 4,
            LightmapOnly = 5,
        }
        [Flags]
        public enum Flags : short
        {
            Decalable = 1,
            NewPartTypes = 2,
            DislikesPhotons = 4,
            OverrideTriangleList = 8,
            IgnoredByLightmapper = 16,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class GlobalSubpartsBlock
    {
        public short indicesStartIndex;
        public short indicesLength;
        public short visibilityBoundsIndex;
        public short partIndex;
        public GlobalSubpartsBlock()
        {
        }
        public GlobalSubpartsBlock(BinaryReader binaryReader)
        {
            this.indicesStartIndex = binaryReader.ReadInt16();
            this.indicesLength = binaryReader.ReadInt16();
            this.visibilityBoundsIndex = binaryReader.ReadInt16();
            this.partIndex = binaryReader.ReadInt16();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.indicesStartIndex);
            binaryWriter.Write(this.indicesLength);
            binaryWriter.Write(this.visibilityBoundsIndex);
            binaryWriter.Write(this.partIndex);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
    public partial class GlobalVisibilityBoundsBlock
    {
        public float positionX;
        public float positionY;
        public float positionZ;
        public float radius;
        public byte node0;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        private byte[] padding;
        #endregion
        public GlobalVisibilityBoundsBlock()
        {
        }
        public GlobalVisibilityBoundsBlock(BinaryReader binaryReader)
        {
            this.positionX = binaryReader.ReadSingle();
            this.positionY = binaryReader.ReadSingle();
            this.positionZ = binaryReader.ReadSingle();
            this.radius = binaryReader.ReadSingle();
            this.node0 = binaryReader.ReadByte();
            this.padding = binaryReader.ReadBytes(3);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.positionX);
            binaryWriter.Write(this.positionY);
            binaryWriter.Write(this.positionZ);
            binaryWriter.Write(this.radius);
            binaryWriter.Write(this.node0);
            binaryWriter.Write(this.padding);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 196, Pack = 4)]
    public partial class GlobalGeometrySectionRawVertexBlock
    {
        public Vector3 position;
        public class NodeIndicesOLD
        {
            public int nodeIndexOLD;
            public NodeIndicesOLD(BinaryReader binaryReader)
            {
                this.nodeIndexOLD = binaryReader.ReadInt32();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeIndexOLD);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndicesOLD[] nodeIndicesOLD;
        public class NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeWeight);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeWeights[] nodeWeights;
        public class NodeIndicesNEW
        {
            public int nodeIndexNEW;
            public NodeIndicesNEW(BinaryReader binaryReader)
            {
                this.nodeIndexNEW = binaryReader.ReadInt32();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeIndexNEW);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndicesNEW[] nodeIndicesNEW;
        public int useNewNodeIndices;
        public int adjustedCompoundNodeIndex;
        public Vector2 texcoord;
        public Vector3 normal;
        public Vector3 binormal;
        public Vector3 tangent;
        public Vector3 anisotropicBinormal;
        public Vector2 secondaryTexcoord;
        public ColorR8G8B8 primaryLightmapColor;
        public Vector2 primaryLightmapTexcoord;
        public Vector3 primaryLightmapIncidentDirection;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] padding0;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] padding1;
        #endregion
        public GlobalGeometrySectionRawVertexBlock()
        {
        }
        public GlobalGeometrySectionRawVertexBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndicesOLD = new NodeIndicesOLD[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndicesOLD[i] = new NodeIndicesOLD(binaryReader);
            }
            this.nodeWeights = new NodeWeights[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.nodeIndicesNEW = new NodeIndicesNEW[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndicesNEW[i] = new NodeIndicesNEW(binaryReader);
            }
            this.useNewNodeIndices = binaryReader.ReadInt32();
            this.adjustedCompoundNodeIndex = binaryReader.ReadInt32();
            this.texcoord = binaryReader.ReadVector2();
            this.normal = binaryReader.ReadVector3();
            this.binormal = binaryReader.ReadVector3();
            this.tangent = binaryReader.ReadVector3();
            this.anisotropicBinormal = binaryReader.ReadVector3();
            this.secondaryTexcoord = binaryReader.ReadVector2();
            this.primaryLightmapColor = binaryReader.ReadColorR8G8B8();
            this.primaryLightmapTexcoord = binaryReader.ReadVector2();
            this.primaryLightmapIncidentDirection = binaryReader.ReadVector3();
            this.padding = binaryReader.ReadBytes(12);
            this.padding0 = binaryReader.ReadBytes(8);
            this.padding1 = binaryReader.ReadBytes(12);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.position);
            for (int i = 0; i < this.nodeIndicesOLD.Length; ++i)
            {
                this.nodeIndicesOLD[i].Write(binaryWriter);
            }
            for (int i = 0; i < this.nodeWeights.Length; ++i)
            {
                this.nodeWeights[i].Write(binaryWriter);
            }
            for (int i = 0; i < this.nodeIndicesNEW.Length; ++i)
            {
                this.nodeIndicesNEW[i].Write(binaryWriter);
            }
            binaryWriter.Write(this.useNewNodeIndices);
            binaryWriter.Write(this.adjustedCompoundNodeIndex);
            binaryWriter.Write(this.texcoord);
            binaryWriter.Write(this.normal);
            binaryWriter.Write(this.binormal);
            binaryWriter.Write(this.tangent);
            binaryWriter.Write(this.anisotropicBinormal);
            binaryWriter.Write(this.secondaryTexcoord);
            binaryWriter.Write(this.primaryLightmapColor);
            binaryWriter.Write(this.primaryLightmapTexcoord);
            binaryWriter.Write(this.primaryLightmapIncidentDirection);
            binaryWriter.Write(this.padding);
            binaryWriter.Write(this.padding0);
            binaryWriter.Write(this.padding1);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class GlobalGeometrySectionStripIndexBlock
    {
        public short index;
        public GlobalGeometrySectionStripIndexBlock()
        {
        }
        public GlobalGeometrySectionStripIndexBlock(BinaryReader binaryReader)
        {
            this.index = binaryReader.ReadInt16();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.index);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class GlobalGeometrySectionVertexBufferBlock
    {
        public VertexBuffer vertexBuffer;
        public GlobalGeometrySectionVertexBufferBlock()
        {
        }
        public GlobalGeometrySectionVertexBufferBlock(BinaryReader binaryReader)
        {
            this.vertexBuffer = binaryReader.ReadVertexBuffer();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.vertexBuffer);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
    public partial class GlobalGeometrySectionStruct
    {
        [TagBlockField]
        public GlobalGeometryPartBlockNew[] parts;
        [TagBlockField]
        public GlobalSubpartsBlock[] subparts;
        [TagBlockField]
        public GlobalVisibilityBoundsBlock[] visibilityBounds;
        [TagBlockField]
        public GlobalGeometrySectionRawVertexBlock[] rawVertices;
        [TagBlockField]
        public GlobalGeometrySectionStripIndexBlock[] stripIndices;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingvisibilityMoppCode;
        #endregion
        [TagBlockField]
        public GlobalGeometrySectionStripIndexBlock[] moppReorderTable;
        [TagBlockField]
        public GlobalGeometrySectionVertexBufferBlock[] vertexBuffers;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public GlobalGeometrySectionStruct()
        {
        }
        public GlobalGeometrySectionStruct(BinaryReader binaryReader)
        {
            this.parts = ReadParts(binaryReader);
            this.subparts = ReadSubparts(binaryReader);
            this.visibilityBounds = ReadVisibilitybounds(binaryReader);
            this.rawVertices = ReadRawvertices(binaryReader);
            this.stripIndices = ReadStripindices(binaryReader);
            this.paddingvisibilityMoppCode = binaryReader.ReadBytes(8);
            this.moppReorderTable = ReadMoppreordertable(binaryReader);
            this.vertexBuffers = ReadVertexbuffers(binaryReader);
            this.padding = binaryReader.ReadBytes(4);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            WriteParts(binaryWriter);
            WriteSubparts(binaryWriter);
            WriteVisibilitybounds(binaryWriter);
            WriteRawvertices(binaryWriter);
            WriteStripindices(binaryWriter);
            binaryWriter.Write(this.paddingvisibilityMoppCode, 0, 8);
            WriteMoppreordertable(binaryWriter);
            WriteVertexbuffers(binaryWriter);
            binaryWriter.Write(this.padding);
        }
        public virtual GlobalGeometryPartBlockNew[] ReadParts(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryPartBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var parts = new GlobalGeometryPartBlockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    parts[i] = new GlobalGeometryPartBlockNew(binaryReader);
                }
            }
            return parts;
        }
        public virtual void WriteParts(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryPartBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.parts.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.parts[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalSubpartsBlock[] ReadSubparts(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalSubpartsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var subparts = new GlobalSubpartsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    subparts[i] = new GlobalSubpartsBlock(binaryReader);
                }
            }
            return subparts;
        }
        public virtual void WriteSubparts(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalSubpartsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.subparts.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.subparts[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalVisibilityBoundsBlock[] ReadVisibilitybounds(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalVisibilityBoundsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var visibilityBounds = new GlobalVisibilityBoundsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    visibilityBounds[i] = new GlobalVisibilityBoundsBlock(binaryReader);
                }
            }
            return visibilityBounds;
        }
        public virtual void WriteVisibilitybounds(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalVisibilityBoundsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.visibilityBounds.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.visibilityBounds[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalGeometrySectionRawVertexBlock[] ReadRawvertices(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionRawVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var rawVertices = new GlobalGeometrySectionRawVertexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    rawVertices[i] = new GlobalGeometrySectionRawVertexBlock(binaryReader);
                }
            }
            return rawVertices;
        }
        public virtual void WriteRawvertices(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionRawVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.rawVertices.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.rawVertices[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalGeometrySectionStripIndexBlock[] ReadStripindices(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var stripIndices = new GlobalGeometrySectionStripIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    stripIndices[i] = new GlobalGeometrySectionStripIndexBlock(binaryReader);
                }
            }
            return stripIndices;
        }
        public virtual void WriteStripindices(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.stripIndices.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.stripIndices[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalGeometrySectionStripIndexBlock[] ReadMoppreordertable(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var moppReorderTable = new GlobalGeometrySectionStripIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    moppReorderTable[i] = new GlobalGeometrySectionStripIndexBlock(binaryReader);
                }
            }
            return moppReorderTable;
        }
        public virtual void WriteMoppreordertable(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.moppReorderTable.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.moppReorderTable[i].Write(binaryWriter);
                }
            }
        }
        public virtual void WriteVertexbuffers(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionVertexBufferBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.vertexBuffers.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.vertexBuffers[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
    public partial class GlobalGeometryRawPointBlock
    {
        public Vector3 position;
        public class NodeIndicesOLD
        {
            public int nodeIndexOLD;
            public NodeIndicesOLD(BinaryReader binaryReader)
            {
                this.nodeIndexOLD = binaryReader.ReadInt32();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeIndexOLD);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndicesOLD[] nodeIndicesOLD;
        public class NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeWeight);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeWeights[] nodeWeights;
        public class NodeIndicesNEW
        {
            public int nodeIndexNEW;
            public NodeIndicesNEW(BinaryReader binaryReader)
            {
                this.nodeIndexNEW = binaryReader.ReadInt32();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeIndexNEW);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndicesNEW[] nodeIndicesNEW;
        public int useNewNodeIndices;
        public int adjustedCompoundNodeIndex;
        public GlobalGeometryRawPointBlock()
        {
        }
        public GlobalGeometryRawPointBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndicesOLD = new NodeIndicesOLD[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndicesOLD[i] = new NodeIndicesOLD(binaryReader);
            }
            this.nodeWeights = new NodeWeights[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.nodeIndicesNEW = new NodeIndicesNEW[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndicesNEW[i] = new NodeIndicesNEW(binaryReader);
            }
            this.useNewNodeIndices = binaryReader.ReadInt32();
            this.adjustedCompoundNodeIndex = binaryReader.ReadInt32();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.position);
            for (int i = 0; i < this.nodeIndicesOLD.Length; ++i)
            {
                this.nodeIndicesOLD[i].Write(binaryWriter);
            }
            for (int i = 0; i < this.nodeWeights.Length; ++i)
            {
                this.nodeWeights[i].Write(binaryWriter);
            }
            for (int i = 0; i < this.nodeIndicesNEW.Length; ++i)
            {
                this.nodeIndicesNEW[i].Write(binaryWriter);
            }
            binaryWriter.Write(this.useNewNodeIndices);
            binaryWriter.Write(this.adjustedCompoundNodeIndex);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class GlobalGeometryRigidPointGroupBlock
    {
        public byte rigidNodeIndex;
        public byte nodesPoint;
        public short pointCount;
        public GlobalGeometryRigidPointGroupBlock()
        {
        }
        public GlobalGeometryRigidPointGroupBlock(BinaryReader binaryReader)
        {
            this.rigidNodeIndex = binaryReader.ReadByte();
            this.nodesPoint = binaryReader.ReadByte();
            this.pointCount = binaryReader.ReadInt16();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.rigidNodeIndex);
            binaryWriter.Write(this.nodesPoint);
            binaryWriter.Write(this.pointCount);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
    public partial class GlobalGeometryPointDataIndexBlock
    {
        public short index;
        public GlobalGeometryPointDataIndexBlock()
        {
        }
        public GlobalGeometryPointDataIndexBlock(BinaryReader binaryReader)
        {
            this.index = binaryReader.ReadInt16();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.index);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class GlobalGeometryPointDataStruct
    {
        [TagBlockField]
        public GlobalGeometryRawPointBlock[] rawPoints;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingruntimePointData;
        #endregion
        [TagBlockField]
        public GlobalGeometryRigidPointGroupBlock[] rigidPointGroups;
        [TagBlockField]
        public GlobalGeometryPointDataIndexBlock[] vertexPointIndices;
        public GlobalGeometryPointDataStruct()
        {
        }
        public GlobalGeometryPointDataStruct(BinaryReader binaryReader)
        {
            this.rawPoints = ReadRawpoints(binaryReader);
            this.paddingruntimePointData = binaryReader.ReadBytes(8);
            this.rigidPointGroups = ReadRigidpointgroups(binaryReader);
            this.vertexPointIndices = ReadVertexpointindices(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            WriteRawpoints(binaryWriter);
            binaryWriter.Write(this.paddingruntimePointData, 0, 8);
            WriteRigidpointgroups(binaryWriter);
            WriteVertexpointindices(binaryWriter);
        }
        public virtual GlobalGeometryRawPointBlock[] ReadRawpoints(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryRawPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var rawPoints = new GlobalGeometryRawPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    rawPoints[i] = new GlobalGeometryRawPointBlock(binaryReader);
                }
            }
            return rawPoints;
        }
        public virtual void WriteRawpoints(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryRawPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.rawPoints.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.rawPoints[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalGeometryRigidPointGroupBlock[] ReadRigidpointgroups(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryRigidPointGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var rigidPointGroups = new GlobalGeometryRigidPointGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    rigidPointGroups[i] = new GlobalGeometryRigidPointGroupBlock(binaryReader);
                }
            }
            return rigidPointGroups;
        }
        public virtual void WriteRigidpointgroups(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryRigidPointGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.rigidPointGroups.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.rigidPointGroups[i].Write(binaryWriter);
                }
            }
        }
        public virtual GlobalGeometryPointDataIndexBlock[] ReadVertexpointindices(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryPointDataIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var vertexPointIndices = new GlobalGeometryPointDataIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    vertexPointIndices[i] = new GlobalGeometryPointDataIndexBlock(binaryReader);
                }
            }
            return vertexPointIndices;
        }
        public virtual void WriteVertexpointindices(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryPointDataIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.vertexPointIndices.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.vertexPointIndices[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 4)]
    public partial class RenderModelNodeMapBlock
    {
        public byte nodeIndex;
        public RenderModelNodeMapBlock()
        {
        }
        public RenderModelNodeMapBlock(BinaryReader binaryReader)
        {
            this.nodeIndex = binaryReader.ReadByte();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.nodeIndex);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 112, Pack = 4)]
    public partial class RenderModelSectionDataBlock
    {
        [TagStructField]
        public GlobalGeometrySectionStruct section;
        [TagStructField]
        public GlobalGeometryPointDataStruct pointData;
        [TagBlockField]
        public RenderModelNodeMapBlock[] nodeMap;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public RenderModelSectionDataBlock()
        {
        }
        public RenderModelSectionDataBlock(BinaryReader binaryReader)
        {
            this.section = new GlobalGeometrySectionStruct(binaryReader);
            this.pointData = new GlobalGeometryPointDataStruct(binaryReader);
            this.nodeMap = ReadNodemap(binaryReader);
            this.padding = binaryReader.ReadBytes(4);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            this.section.Write(binaryWriter);
            this.pointData.Write(binaryWriter);
            WriteNodemap(binaryWriter);
            binaryWriter.Write(this.padding);
        }
        public virtual RenderModelNodeMapBlock[] ReadNodemap(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelNodeMapBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var nodeMap = new RenderModelNodeMapBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    nodeMap[i] = new RenderModelNodeMapBlock(binaryReader);
                }
            }
            return nodeMap;
        }
        public virtual void WriteNodemap(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelNodeMapBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.nodeMap.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.nodeMap[i].Write(binaryWriter);
                }
            }
        }
    }


    public partial class GlobalGeometryBlockResourceBlock
    {
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write((Byte)this.type);
            binaryWriter.Write(this.padding);
            binaryWriter.Write(this.primaryLocator);
            binaryWriter.Write(this.secondaryLocator);
            binaryWriter.Write(this.resourceDataSize);
            binaryWriter.Write(this.resourceDataOffset);
        }
    }


    public partial class GlobalGeometryBlockInfoStruct
    {
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.blockOffset);
            binaryWriter.Write(this.blockSize);
            binaryWriter.Write(this.sectionDataSize);
            binaryWriter.Write(this.resourceDataSize);
            WriteResources(binaryWriter);
            binaryWriter.Write(this.padding);
            binaryWriter.Write(this.ownerTagSectionOffset);
            binaryWriter.Write(this.padding0);
            binaryWriter.Write(this.padding1);
        }

        public virtual void WriteResources(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryBlockResourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.resources.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.resources[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 92, Pack = 4)]
    public partial class RenderModelSectionBlock
    {
        public GlobalGeometryClassificationEnumDefinition globalGeometryClassificationEnumDefinition;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        [TagStructField]
        public GlobalGeometrySectionInfoStruct sectionInfo;
        public ShortBlockIndex1 rigidNode;
        public Flags flags;
        [TagBlockField]
        public RenderModelSectionDataBlock[] sectionData;
        [TagStructField]
        public GlobalGeometryBlockInfoStruct geometryBlockInfo;
        public RenderModelSectionBlock()
        {
        }
        public RenderModelSectionBlock(BinaryReader binaryReader)
        {
            this.globalGeometryClassificationEnumDefinition = (GlobalGeometryClassificationEnumDefinition)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.sectionInfo = new GlobalGeometrySectionInfoStruct(binaryReader);
            this.rigidNode = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.sectionData = ReadSectiondata(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStruct(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write((Int16)this.globalGeometryClassificationEnumDefinition);
            binaryWriter.Write(this.padding);
            this.sectionInfo.Write(binaryWriter);
            binaryWriter.Write(this.rigidNode);
            binaryWriter.Write((Int16)this.flags);
            WriteSectiondata(binaryWriter);
            this.geometryBlockInfo.Write(binaryWriter);
        }
        public enum GlobalGeometryClassificationEnumDefinition : short
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        }
        [Flags]
        public enum Flags : short
        {
            GeometryPostprocessed = 1,
        }
        public virtual RenderModelSectionDataBlock[] ReadSectiondata(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelSectionDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var sectionData = new RenderModelSectionDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    sectionData[i] = new RenderModelSectionDataBlock(binaryReader);
                }
            }
            return sectionData;
        }
        public virtual void WriteSectiondata(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelSectionDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.sectionData.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.sectionData[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class RenderModelInvalidSectionPairsBlock
    {
        public int bits;
        public RenderModelInvalidSectionPairsBlock()
        {
        }
        public RenderModelInvalidSectionPairsBlock(BinaryReader binaryReader)
        {
            this.bits = binaryReader.ReadInt32();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.bits);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class RenderModelCompoundNodeBlock
    {
        public class NodeIndices
        {
            public byte nodeIndex;
            public NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeIndex);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndices[] nodeIndices;
        public class NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeWeight);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public NodeWeights[] nodeWeights;
        public RenderModelCompoundNodeBlock()
        {
        }
        public RenderModelCompoundNodeBlock(BinaryReader binaryReader)
        {
            this.nodeIndices = new NodeIndices[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndices[i] = new NodeIndices(binaryReader);
            }
            this.nodeWeights = new NodeWeights[3];
            for (int i = 0; i < 3; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            for (int i = 0; i < this.nodeIndices.Length; ++i)
            {
                this.nodeIndices[i].Write(binaryWriter);
            }
            for (int i = 0; i < this.nodeWeights.Length; ++i)
            {
                this.nodeWeights[i].Write(binaryWriter);
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class RenderModelSectionGroupBlock
    {
        public DetailLevels detailLevels;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public RenderModelCompoundNodeBlock[] compoundNodes;
        public RenderModelSectionGroupBlock()
        {
        }
        public RenderModelSectionGroupBlock(BinaryReader binaryReader)
        {
            this.detailLevels = (DetailLevels)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.compoundNodes = ReadCompoundnodes(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write((Int16)this.detailLevels);
            binaryWriter.Write(this.padding);
            WriteCompoundnodes(binaryWriter);
        }
        [Flags]
        public enum DetailLevels : short
        {
            L1SuperLow = 1,
            L2Low = 2,
            L3Medium = 4,
            L4High = 8,
            L5SuperHigh = 16,
            L6Hollywood = 32,
        }
        public virtual RenderModelCompoundNodeBlock[] ReadCompoundnodes(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelCompoundNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var compoundNodes = new RenderModelCompoundNodeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    compoundNodes[i] = new RenderModelCompoundNodeBlock(binaryReader);
                }
            }
            return compoundNodes;
        }
        public virtual void WriteCompoundnodes(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelCompoundNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.compoundNodes.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.compoundNodes[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 96, Pack = 4)]
    public partial class RenderModelNodeBlock
    {
        public StringID name;
        public ShortBlockIndex1 parentNode;
        public ShortBlockIndex1 firstChildNode;
        public ShortBlockIndex1 nextSiblingNode;
        public short importNodeIndex;
        public Vector3 defaultTranslation;
        public Quaternion defaultRotation;
        public Vector3 inverseForward;
        public Vector3 inverseLeft;
        public Vector3 inverseUp;
        public Vector3 inversePosition;
        public float inverseScale;
        public float distanceFromParent;
        public RenderModelNodeBlock()
        {
        }
        public RenderModelNodeBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.parentNode = binaryReader.ReadShortBlockIndex1();
            this.firstChildNode = binaryReader.ReadShortBlockIndex1();
            this.nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            this.importNodeIndex = binaryReader.ReadInt16();
            this.defaultTranslation = binaryReader.ReadVector3();
            this.defaultRotation = binaryReader.ReadQuaternion();
            this.inverseForward = binaryReader.ReadVector3();
            this.inverseLeft = binaryReader.ReadVector3();
            this.inverseUp = binaryReader.ReadVector3();
            this.inversePosition = binaryReader.ReadVector3();
            this.inverseScale = binaryReader.ReadSingle();
            this.distanceFromParent = binaryReader.ReadSingle();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.name);
            binaryWriter.Write(this.parentNode);
            binaryWriter.Write(this.firstChildNode);
            binaryWriter.Write(this.nextSiblingNode);
            binaryWriter.Write(this.importNodeIndex);
            binaryWriter.Write(this.defaultTranslation);
            binaryWriter.Write(this.defaultRotation);
            binaryWriter.Write(this.inverseForward);
            binaryWriter.Write(this.inverseLeft);
            binaryWriter.Write(this.inverseUp);
            binaryWriter.Write(this.inversePosition);
            binaryWriter.Write(this.inverseScale);
            binaryWriter.Write(this.distanceFromParent);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 4)]
    public partial class RenderModelNodeMapBlockOLD
    {
        public byte nodeIndex;
        public RenderModelNodeMapBlockOLD()
        {
        }
        public RenderModelNodeMapBlockOLD(BinaryReader binaryReader)
        {
            this.nodeIndex = binaryReader.ReadByte();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.nodeIndex);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
    public partial class RenderModelMarkerBlock
    {
        public byte regionIndex;
        public byte permutationIndex;
        public byte nodeIndex;
        #region padding
        private byte padding;
        #endregion
        public Vector3 translation;
        public Quaternion rotation;
        public float scale;
        public RenderModelMarkerBlock()
        {
        }
        public RenderModelMarkerBlock(BinaryReader binaryReader)
        {
            this.regionIndex = binaryReader.ReadByte();
            this.permutationIndex = binaryReader.ReadByte();
            this.nodeIndex = binaryReader.ReadByte();
            this.padding = binaryReader.ReadByte();
            this.translation = binaryReader.ReadVector3();
            this.rotation = binaryReader.ReadQuaternion();
            this.scale = binaryReader.ReadSingle();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.regionIndex);
            binaryWriter.Write(this.permutationIndex);
            binaryWriter.Write(this.nodeIndex);
            binaryWriter.Write(this.padding);
            binaryWriter.Write(this.translation);
            binaryWriter.Write(this.rotation);
            binaryWriter.Write(this.scale);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class RenderModelMarkerGroupBlock
    {
        public StringID name;
        [TagBlockField]
        public RenderModelMarkerBlock[] markers;
        public RenderModelMarkerGroupBlock()
        {
        }
        public RenderModelMarkerGroupBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.markers = ReadMarkers(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.name);
            WriteMarkers(binaryWriter);
        }
        public virtual RenderModelMarkerBlock[] ReadMarkers(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(RenderModelMarkerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var markers = new RenderModelMarkerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    markers[i] = new RenderModelMarkerBlock(binaryReader);
                }
            }
            return markers;
        }
        public virtual void WriteMarkers(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(RenderModelMarkerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.markers.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.markers[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class GlobalGeometryMaterialPropertyBlock
    {
        public Type type;
        public short intValue;
        public float realValue;
        public GlobalGeometryMaterialPropertyBlock()
        {
        }
        public GlobalGeometryMaterialPropertyBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.intValue = binaryReader.ReadInt16();
            this.realValue = binaryReader.ReadSingle();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write((Int16)this.type);
            binaryWriter.Write(this.intValue);
            binaryWriter.Write(this.realValue);
        }
        public enum Type : short
        {
            LightmapResolution = 0,
            LightmapPower = 1,
            LightmapHalfLife = 2,
            LightmapDiffuseScale = 3,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class GlobalGeometryMaterialBlock
    {
        [TagReference("shad")]
        public TagReference oldShader;
        [TagReference("shad")]
        public TagReference shader;
        [TagBlockField]
        public GlobalGeometryMaterialPropertyBlock[] properties;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public byte breakableSurfaceIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        private byte[] padding0;
        #endregion
        public GlobalGeometryMaterialBlock()
        {
        }
        public GlobalGeometryMaterialBlock(BinaryReader binaryReader)
        {
            this.oldShader = binaryReader.ReadTagReference();
            this.shader = binaryReader.ReadTagReference();
            this.properties = ReadProperties(binaryReader);
            this.padding = binaryReader.ReadBytes(4);
            this.breakableSurfaceIndex = binaryReader.ReadByte();
            this.padding0 = binaryReader.ReadBytes(3);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.oldShader);
            binaryWriter.Write(this.shader);
            WriteProperties(binaryWriter);
            binaryWriter.Write(this.padding);
            binaryWriter.Write(this.breakableSurfaceIndex);
            binaryWriter.Write(this.padding0);
        }
        public virtual GlobalGeometryMaterialPropertyBlock[] ReadProperties(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryMaterialPropertyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var properties = new GlobalGeometryMaterialPropertyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    properties[i] = new GlobalGeometryMaterialPropertyBlock(binaryReader);
                }
            }
            return properties;
        }
        public virtual void WriteProperties(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometryMaterialPropertyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.properties.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.properties[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 4)]
    public partial class ErrorReportVerticesBlock
    {
        public Vector3 position;
        public class NodeIndices
        {
            public byte nodeIndex;
            public NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeIndex);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndices[] nodeIndices;
        public class NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeWeight);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeWeights[] nodeWeights;
        public Vector4 color;
        public float screenSize;
        public ErrorReportVerticesBlock()
        {
        }
        public ErrorReportVerticesBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndices[i] = new NodeIndices(binaryReader);
            }
            this.nodeWeights = new NodeWeights[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
            this.screenSize = binaryReader.ReadSingle();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.position);
            for (int i = 0; i < this.nodeIndices.Length; ++i)
            {
                this.nodeIndices[i].Write(binaryWriter);
            }
            for (int i = 0; i < this.nodeWeights.Length; ++i)
            {
                this.nodeWeights[i].Write(binaryWriter);
            }
            binaryWriter.Write(this.color);
            binaryWriter.Write(this.screenSize);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
    public partial class ErrorReportVectorsBlock
    {
        public Vector3 position;
        public class NodeIndices
        {
            public byte nodeIndex;
            public NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeIndex);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndices[] nodeIndices;
        public class NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeWeight);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeWeights[] nodeWeights;
        public Vector4 color;
        public Vector3 normal;
        public float screenLength;
        public ErrorReportVectorsBlock()
        {
        }
        public ErrorReportVectorsBlock(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndices[i] = new NodeIndices(binaryReader);
            }
            this.nodeWeights = new NodeWeights[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
            this.normal = binaryReader.ReadVector3();
            this.screenLength = binaryReader.ReadSingle();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.position);
            for (int i = 0; i < this.nodeIndices.Length; ++i)
            {
                this.nodeIndices[i].Write(binaryWriter);
            }
            for (int i = 0; i < this.nodeWeights.Length; ++i)
            {
                this.nodeWeights[i].Write(binaryWriter);
            }
            binaryWriter.Write(this.color);
            binaryWriter.Write(this.normal);
            binaryWriter.Write(this.screenLength);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 58, Pack = 4)]
    public partial class ErrorReportLinesBlock
    {
        public class Points
        {
            public Vector3 position;
            public class NodeIndices
            {
                public byte nodeIndex;
                public NodeIndices(BinaryReader binaryReader)
                {
                    this.nodeIndex = binaryReader.ReadByte();
                }
                public virtual void Write(BinaryWriter binaryWriter)
                {
                    binaryWriter.Write(this.nodeIndex);
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeIndices[] nodeIndices;
            public class NodeWeights
            {
                public float nodeWeight;
                public NodeWeights(BinaryReader binaryReader)
                {
                    this.nodeWeight = binaryReader.ReadSingle();
                }
                public virtual void Write(BinaryWriter binaryWriter)
                {
                    binaryWriter.Write(this.nodeWeight);
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeWeights[] nodeWeights;
            public Points(BinaryReader binaryReader)
            {
                this.position = binaryReader.ReadVector3();
                this.nodeIndices = new NodeIndices[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeIndices[i] = new NodeIndices(binaryReader);
                }
                this.nodeWeights = new NodeWeights[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeWeights[i] = new NodeWeights(binaryReader);
                }
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.position);
                for (int i = 0; i < this.nodeIndices.Length; ++i)
                {
                    this.nodeIndices[i].Write(binaryWriter);
                }
                for (int i = 0; i < this.nodeWeights.Length; ++i)
                {
                    this.nodeWeights[i].Write(binaryWriter);
                }
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public Points[] points;
        public Vector4 color;
        public ErrorReportLinesBlock()
        {
        }
        public ErrorReportLinesBlock(BinaryReader binaryReader)
        {
            this.points = new Points[2];
            for (int i = 0; i < 2; ++i)
            {
                this.points[i] = new Points(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            for (int i = 0; i < this.points.Length; ++i)
            {
                this.points[i].Write(binaryWriter);
            }
            binaryWriter.Write(this.color);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 71, Pack = 4)]
    public partial class ErrorReportTrianglesBlock
    {
        public class Points
        {
            public Vector3 position;
            public class NodeIndices
            {
                public byte nodeIndex;
                public NodeIndices(BinaryReader binaryReader)
                {
                    this.nodeIndex = binaryReader.ReadByte();
                }
                public virtual void Write(BinaryWriter binaryWriter)
                {
                    binaryWriter.Write(this.nodeIndex);
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeIndices[] nodeIndices;
            public class NodeWeights
            {
                public float nodeWeight;
                public NodeWeights(BinaryReader binaryReader)
                {
                    this.nodeWeight = binaryReader.ReadSingle();
                }
                public virtual void Write(BinaryWriter binaryWriter)
                {
                    binaryWriter.Write(this.nodeWeight);
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeWeights[] nodeWeights;
            public Points(BinaryReader binaryReader)
            {
                this.position = binaryReader.ReadVector3();
                this.nodeIndices = new NodeIndices[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeIndices[i] = new NodeIndices(binaryReader);
                }
                this.nodeWeights = new NodeWeights[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeWeights[i] = new NodeWeights(binaryReader);
                }
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.position);
                for (int i = 0; i < this.nodeIndices.Length; ++i)
                {
                    this.nodeIndices[i].Write(binaryWriter);
                }
                for (int i = 0; i < this.nodeWeights.Length; ++i)
                {
                    this.nodeWeights[i].Write(binaryWriter);
                }
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Points[] points;
        public Vector4 color;
        public ErrorReportTrianglesBlock()
        {
        }
        public ErrorReportTrianglesBlock(BinaryReader binaryReader)
        {
            this.points = new Points[3];
            for (int i = 0; i < 3; ++i)
            {
                this.points[i] = new Points(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            for (int i = 0; i < this.points.Length; ++i)
            {
                this.points[i].Write(binaryWriter);
            }
            binaryWriter.Write(this.color);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 84, Pack = 4)]
    public partial class ErrorReportQuadsBlock
    {
        public class Points
        {
            public Vector3 position;
            public class NodeIndices
            {
                public byte nodeIndex;
                public NodeIndices(BinaryReader binaryReader)
                {
                    this.nodeIndex = binaryReader.ReadByte();
                }
                public virtual void Write(BinaryWriter binaryWriter)
                {
                    binaryWriter.Write(this.nodeIndex);
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeIndices[] nodeIndices;
            public class NodeWeights
            {
                public float nodeWeight;
                public NodeWeights(BinaryReader binaryReader)
                {
                    this.nodeWeight = binaryReader.ReadSingle();
                }
                public virtual void Write(BinaryWriter binaryWriter)
                {
                    binaryWriter.Write(this.nodeWeight);
                }
            }
            [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public NodeWeights[] nodeWeights;
            public Points(BinaryReader binaryReader)
            {
                this.position = binaryReader.ReadVector3();
                this.nodeIndices = new NodeIndices[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeIndices[i] = new NodeIndices(binaryReader);
                }
                this.nodeWeights = new NodeWeights[4];
                for (int i = 0; i < 4; ++i)
                {
                    this.nodeWeights[i] = new NodeWeights(binaryReader);
                }
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.position);
                for (int i = 0; i < this.nodeIndices.Length; ++i)
                {
                    this.nodeIndices[i].Write(binaryWriter);
                }
                for (int i = 0; i < this.nodeWeights.Length; ++i)
                {
                    this.nodeWeights[i].Write(binaryWriter);
                }
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Points[] points;
        public Vector4 color;
        public ErrorReportQuadsBlock()
        {
        }
        public ErrorReportQuadsBlock(BinaryReader binaryReader)
        {
            this.points = new Points[4];
            for (int i = 0; i < 4; ++i)
            {
                this.points[i] = new Points(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            for (int i = 0; i < this.points.Length; ++i)
            {
                this.points[i].Write(binaryWriter);
            }
            binaryWriter.Write(this.color);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 4)]
    public partial class ErrorReportCommentsBlock
    {
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingtext;
        #endregion
        public Vector3 position;
        public class NodeIndices
        {
            public byte nodeIndex;
            public NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeIndex);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeIndices[] nodeIndices;
        public class NodeWeights
        {
            public float nodeWeight;
            public NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
            public virtual void Write(BinaryWriter binaryWriter)
            {
                binaryWriter.Write(this.nodeWeight);
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NodeWeights[] nodeWeights;
        public Vector4 color;
        public ErrorReportCommentsBlock()
        {
        }
        public ErrorReportCommentsBlock(BinaryReader binaryReader)
        {
            this.paddingtext = binaryReader.ReadBytes(8);
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new NodeIndices[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeIndices[i] = new NodeIndices(binaryReader);
            }
            this.nodeWeights = new NodeWeights[4];
            for (int i = 0; i < 4; ++i)
            {
                this.nodeWeights[i] = new NodeWeights(binaryReader);
            }
            this.color = binaryReader.ReadVector4();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.paddingtext, 0, 8);
            binaryWriter.Write(this.position);
            for (int i = 0; i < this.nodeIndices.Length; ++i)
            {
                this.nodeIndices[i].Write(binaryWriter);
            }
            for (int i = 0; i < this.nodeWeights.Length; ++i)
            {
                this.nodeWeights[i].Write(binaryWriter);
            }
            binaryWriter.Write(this.color);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 608, Pack = 4)]
    public partial class ErrorReportsBlock
    {
        public Type type;
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] paddingtext;
        #endregion
        public String32 sourceFilename;
        public int sourceLineNumber;
        [TagBlockField]
        public ErrorReportVerticesBlock[] vertices;
        [TagBlockField]
        public ErrorReportVectorsBlock[] vectors;
        [TagBlockField]
        public ErrorReportLinesBlock[] lines;
        [TagBlockField]
        public ErrorReportTrianglesBlock[] triangles;
        [TagBlockField]
        public ErrorReportQuadsBlock[] quads;
        [TagBlockField]
        public ErrorReportCommentsBlock[] comments;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 380)]
        private byte[] padding;
        #endregion
        public int reportKey;
        public int nodeIndex;
        public Range boundsX;
        public Range boundsY;
        public Range boundsZ;
        public Vector4 color;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
        private byte[] padding0;
        #endregion
        public ErrorReportsBlock()
        {
        }
        public ErrorReportsBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.paddingtext = binaryReader.ReadBytes(8);
            this.sourceFilename = binaryReader.ReadString32();
            this.sourceLineNumber = binaryReader.ReadInt32();
            this.vertices = ReadVertices(binaryReader);
            this.vectors = ReadVectors(binaryReader);
            this.lines = ReadLines(binaryReader);
            this.triangles = ReadTriangles(binaryReader);
            this.quads = ReadQuads(binaryReader);
            this.comments = ReadComments(binaryReader);
            this.padding = binaryReader.ReadBytes(380);
            this.reportKey = binaryReader.ReadInt32();
            this.nodeIndex = binaryReader.ReadInt32();
            this.boundsX = binaryReader.ReadRange();
            this.boundsY = binaryReader.ReadRange();
            this.boundsZ = binaryReader.ReadRange();
            this.color = binaryReader.ReadVector4();
            this.padding0 = binaryReader.ReadBytes(84);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write((Int16)this.type);
            binaryWriter.Write((Int16)this.flags);
            binaryWriter.Write(this.paddingtext, 0, 8);
            binaryWriter.Write(this.sourceFilename);
            binaryWriter.Write(this.sourceLineNumber);
            WriteVertices(binaryWriter);
            WriteVectors(binaryWriter);
            WriteLines(binaryWriter);
            WriteTriangles(binaryWriter);
            WriteQuads(binaryWriter);
            WriteComments(binaryWriter);
            binaryWriter.Write(this.padding);
            binaryWriter.Write(this.reportKey);
            binaryWriter.Write(this.nodeIndex);
            binaryWriter.Write(this.boundsX);
            binaryWriter.Write(this.boundsY);
            binaryWriter.Write(this.boundsZ);
            binaryWriter.Write(this.color);
            binaryWriter.Write(this.padding0);
        }
        public enum Type : short
        {
            Silent = 0,
            Comment = 1,
            Warning = 2,
            Error = 3,
        }
        [Flags]
        public enum Flags : short
        {
            Rendered = 1,
            TangentSpace = 2,
            Noncritical = 4,
            LightmapLight = 8,
            ReportKeyIsValid = 16,
        }
        public virtual ErrorReportVerticesBlock[] ReadVertices(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(ErrorReportVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var vertices = new ErrorReportVerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    vertices[i] = new ErrorReportVerticesBlock(binaryReader);
                }
            }
            return vertices;
        }
        public virtual void WriteVertices(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(ErrorReportVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.vertices.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.vertices[i].Write(binaryWriter);
                }
            }
        }
        public virtual ErrorReportVectorsBlock[] ReadVectors(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(ErrorReportVectorsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var vectors = new ErrorReportVectorsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    vectors[i] = new ErrorReportVectorsBlock(binaryReader);
                }
            }
            return vectors;
        }
        public virtual void WriteVectors(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(ErrorReportVectorsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.vectors.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.vectors[i].Write(binaryWriter);
                }
            }
        }
        public virtual ErrorReportLinesBlock[] ReadLines(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(ErrorReportLinesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var lines = new ErrorReportLinesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    lines[i] = new ErrorReportLinesBlock(binaryReader);
                }
            }
            return lines;
        }
        public virtual void WriteLines(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(ErrorReportLinesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.lines.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.lines[i].Write(binaryWriter);
                }
            }
        }
        public virtual ErrorReportTrianglesBlock[] ReadTriangles(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(ErrorReportTrianglesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var triangles = new ErrorReportTrianglesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    triangles[i] = new ErrorReportTrianglesBlock(binaryReader);
                }
            }
            return triangles;
        }
        public virtual void WriteTriangles(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(ErrorReportTrianglesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.triangles.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.triangles[i].Write(binaryWriter);
                }
            }
        }
        public virtual ErrorReportQuadsBlock[] ReadQuads(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(ErrorReportQuadsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var quads = new ErrorReportQuadsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    quads[i] = new ErrorReportQuadsBlock(binaryReader);
                }
            }
            return quads;
        }
        public virtual void WriteQuads(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(ErrorReportQuadsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.quads.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.quads[i].Write(binaryWriter);
                }
            }
        }
        public virtual ErrorReportCommentsBlock[] ReadComments(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(ErrorReportCommentsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var comments = new ErrorReportCommentsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    comments[i] = new ErrorReportCommentsBlock(binaryReader);
                }
            }
            return comments;
        }
        public virtual void WriteComments(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(ErrorReportCommentsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.comments.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.comments[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 676, Pack = 4)]
    public partial class GlobalErrorReportCategoriesBlock
    {
        public String256 name;
        public ReportType reportType;
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 404)]
        private byte[] padding1;
        #endregion
        [TagBlockField]
        public ErrorReportsBlock[] reports;
        public GlobalErrorReportCategoriesBlock()
        {
        }
        public GlobalErrorReportCategoriesBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString256();
            this.reportType = (ReportType)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(2);
            this.padding1 = binaryReader.ReadBytes(404);
            this.reports = ReadReports(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.name);
            binaryWriter.Write((Int16)this.reportType);
            binaryWriter.Write((Int16)this.flags);
            binaryWriter.Write(this.padding);
            binaryWriter.Write(this.padding0);
            binaryWriter.Write(this.padding1);
            WriteReports(binaryWriter);
        }
        public enum ReportType : short
        {
            Silent = 0,
            Comment = 1,
            Warning = 2,
            Error = 3,
        }
        [Flags]
        public enum Flags : short
        {
            Rendered = 1,
            TangentSpace = 2,
            Noncritical = 4,
            LightmapLight = 8,
            ReportKeyIsValid = 16,
        }
        public virtual ErrorReportsBlock[] ReadReports(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(ErrorReportsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var reports = new ErrorReportsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    reports[i] = new ErrorReportsBlock(binaryReader);
                }
            }
            return reports;
        }
        public virtual void WriteReports(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(ErrorReportsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.reports.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.reports[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class PrtSectionInfoBlock
    {
        public int sectionIndex;
        public int pcaDataOffset;
        public PrtSectionInfoBlock()
        {
        }
        public PrtSectionInfoBlock(BinaryReader binaryReader)
        {
            this.sectionIndex = binaryReader.ReadInt32();
            this.pcaDataOffset = binaryReader.ReadInt32();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.sectionIndex);
            binaryWriter.Write(this.pcaDataOffset);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
    public partial class PrtLodInfoBlock
    {
        public int clusterOffset;
        [TagBlockField]
        public PrtSectionInfoBlock[] sectionInfo;
        public PrtLodInfoBlock()
        {
        }
        public PrtLodInfoBlock(BinaryReader binaryReader)
        {
            this.clusterOffset = binaryReader.ReadInt32();
            this.sectionInfo = ReadSectioninfo(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.clusterOffset);
            WriteSectioninfo(binaryWriter);
        }
        public virtual PrtSectionInfoBlock[] ReadSectioninfo(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(PrtSectionInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var sectionInfo = new PrtSectionInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    sectionInfo[i] = new PrtSectionInfoBlock(binaryReader);
                }
            }
            return sectionInfo;
        }
        public virtual void WriteSectioninfo(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(PrtSectionInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.sectionInfo.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.sectionInfo[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class PrtClusterBasisBlock
    {
        public float basisData;
        public PrtClusterBasisBlock()
        {
        }
        public PrtClusterBasisBlock(BinaryReader binaryReader)
        {
            this.basisData = binaryReader.ReadSingle();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.basisData);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
    public partial class PrtRawPcaDataBlock
    {
        public float rawPcaData;
        public PrtRawPcaDataBlock()
        {
        }
        public PrtRawPcaDataBlock(BinaryReader binaryReader)
        {
            this.rawPcaData = binaryReader.ReadSingle();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.rawPcaData);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
    public partial class PrtVertexBuffersBlock
    {
        public VertexBuffer vertexBuffer;
        public PrtVertexBuffersBlock()
        {
        }
        public PrtVertexBuffersBlock(BinaryReader binaryReader)
        {
            this.vertexBuffer = binaryReader.ReadVertexBuffer();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.vertexBuffer);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 88, Pack = 4)]
    public partial class PrtInfoBlock
    {
        public short sHOrder;
        public short numOfClusters;
        public short pcaVectorsPerCluster;
        public short numberOfRays;
        public short numberOfBounces;
        public short matIndexForSbsfcScattering;
        public float lengthScale;
        public short numberOfLodsInModel;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public PrtLodInfoBlock[] lodInfo;
        [TagBlockField]
        public PrtClusterBasisBlock[] clusterBasis;
        [TagBlockField]
        public PrtRawPcaDataBlock[] rawPcaData;
        [TagBlockField]
        public PrtVertexBuffersBlock[] vertexBuffers;
        [TagStructField]
        public GlobalGeometryBlockInfoStruct geometryBlockInfo;
        public PrtInfoBlock()
        {
        }
        public PrtInfoBlock(BinaryReader binaryReader)
        {
            this.sHOrder = binaryReader.ReadInt16();
            this.numOfClusters = binaryReader.ReadInt16();
            this.pcaVectorsPerCluster = binaryReader.ReadInt16();
            this.numberOfRays = binaryReader.ReadInt16();
            this.numberOfBounces = binaryReader.ReadInt16();
            this.matIndexForSbsfcScattering = binaryReader.ReadInt16();
            this.lengthScale = binaryReader.ReadSingle();
            this.numberOfLodsInModel = binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.lodInfo = ReadLodinfo(binaryReader);
            this.clusterBasis = ReadClusterbasis(binaryReader);
            this.rawPcaData = ReadRawpcadata(binaryReader);
            this.vertexBuffers = ReadVertexbuffers(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStruct(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.sHOrder);
            binaryWriter.Write(this.numOfClusters);
            binaryWriter.Write(this.pcaVectorsPerCluster);
            binaryWriter.Write(this.numberOfRays);
            binaryWriter.Write(this.numberOfBounces);
            binaryWriter.Write(this.matIndexForSbsfcScattering);
            binaryWriter.Write(this.lengthScale);
            binaryWriter.Write(this.numberOfLodsInModel);
            binaryWriter.Write(this.padding);
            WriteLodinfo(binaryWriter);
            WriteClusterbasis(binaryWriter);
            WriteRawpcadata(binaryWriter);
            WriteVertexbuffers(binaryWriter);
            this.geometryBlockInfo.Write(binaryWriter);
        }
        public virtual PrtLodInfoBlock[] ReadLodinfo(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(PrtLodInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var lodInfo = new PrtLodInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    lodInfo[i] = new PrtLodInfoBlock(binaryReader);
                }
            }
            return lodInfo;
        }
        public virtual void WriteLodinfo(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(PrtLodInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.lodInfo.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.lodInfo[i].Write(binaryWriter);
                }
            }
        }
        public virtual PrtClusterBasisBlock[] ReadClusterbasis(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(PrtClusterBasisBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var clusterBasis = new PrtClusterBasisBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    clusterBasis[i] = new PrtClusterBasisBlock(binaryReader);
                }
            }
            return clusterBasis;
        }
        public virtual void WriteClusterbasis(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(PrtClusterBasisBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.clusterBasis.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.clusterBasis[i].Write(binaryWriter);
                }
            }
        }
        public virtual PrtRawPcaDataBlock[] ReadRawpcadata(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(PrtRawPcaDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var rawPcaData = new PrtRawPcaDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    rawPcaData[i] = new PrtRawPcaDataBlock(binaryReader);
                }
            }
            return rawPcaData;
        }
        public virtual void WriteRawpcadata(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(PrtRawPcaDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.rawPcaData.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.rawPcaData[i].Write(binaryWriter);
                }
            }
        }
        public virtual PrtVertexBuffersBlock[] ReadVertexbuffers(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(PrtVertexBuffersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var vertexBuffers = new PrtVertexBuffersBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    vertexBuffers[i] = new PrtVertexBuffersBlock(binaryReader);
                }
            }
            return vertexBuffers;
        }
        public virtual void WriteVertexbuffers(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(PrtVertexBuffersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.vertexBuffers.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.vertexBuffers[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class BspLeafBlock
    {
        public short cluster;
        public short surfaceReferenceCount;
        public int firstSurfaceReferenceIndex;
        public BspLeafBlock()
        {
        }
        public BspLeafBlock(BinaryReader binaryReader)
        {
            this.cluster = binaryReader.ReadInt16();
            this.surfaceReferenceCount = binaryReader.ReadInt16();
            this.firstSurfaceReferenceIndex = binaryReader.ReadInt32();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.cluster);
            binaryWriter.Write(this.surfaceReferenceCount);
            binaryWriter.Write(this.firstSurfaceReferenceIndex);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class BspSurfaceReferenceBlock
    {
        public short stripIndex;
        public short lightmapTriangleIndex;
        public int bspNodeIndex;
        public BspSurfaceReferenceBlock()
        {
        }
        public BspSurfaceReferenceBlock(BinaryReader binaryReader)
        {
            this.stripIndex = binaryReader.ReadInt16();
            this.lightmapTriangleIndex = binaryReader.ReadInt16();
            this.bspNodeIndex = binaryReader.ReadInt32();
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.stripIndex);
            binaryWriter.Write(this.lightmapTriangleIndex);
            binaryWriter.Write(this.bspNodeIndex);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
    public partial class NodeRenderLeavesBlock
    {
        [TagBlockField]
        public BspLeafBlock[] collisionLeaves;
        [TagBlockField]
        public BspSurfaceReferenceBlock[] surfaceReferences;
        public NodeRenderLeavesBlock()
        {
        }
        public NodeRenderLeavesBlock(BinaryReader binaryReader)
        {
            this.collisionLeaves = ReadCollisionleaves(binaryReader);
            this.surfaceReferences = ReadSurfacereferences(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            WriteCollisionleaves(binaryWriter);
            WriteSurfacereferences(binaryWriter);
        }
        public virtual BspLeafBlock[] ReadCollisionleaves(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(BspLeafBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var collisionLeaves = new BspLeafBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    collisionLeaves[i] = new BspLeafBlock(binaryReader);
                }
            }
            return collisionLeaves;
        }
        public virtual void WriteCollisionleaves(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(BspLeafBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.collisionLeaves.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.collisionLeaves[i].Write(binaryWriter);
                }
            }
        }
        public virtual BspSurfaceReferenceBlock[] ReadSurfacereferences(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(BspSurfaceReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var surfaceReferences = new BspSurfaceReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    surfaceReferences[i] = new BspSurfaceReferenceBlock(binaryReader);
                }
            }
            return surfaceReferences;
        }
        public virtual void WriteSurfacereferences(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(BspSurfaceReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.surfaceReferences.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.surfaceReferences[i].Write(binaryWriter);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public partial class SectionRenderLeavesBlock
    {
        [TagBlockField]
        public NodeRenderLeavesBlock[] nodeRenderLeaves;
        public SectionRenderLeavesBlock()
        {
        }
        public SectionRenderLeavesBlock(BinaryReader binaryReader)
        {
            this.nodeRenderLeaves = ReadNoderenderleaves(binaryReader);
        }
        public virtual void Write(BinaryWriter binaryWriter)
        {
            WriteNoderenderleaves(binaryWriter);
        }
        public virtual NodeRenderLeavesBlock[] ReadNoderenderleaves(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(NodeRenderLeavesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var nodeRenderLeaves = new NodeRenderLeavesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    nodeRenderLeaves[i] = new NodeRenderLeavesBlock(binaryReader);
                }
            }
            return nodeRenderLeaves;
        }
        public virtual void WriteNoderenderleaves(BinaryWriter binaryWriter)
        {
            var binaryReader = new BinaryReader(binaryWriter.BaseStream);
            var elementSize = Marshal.SizeOf(typeof(NodeRenderLeavesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            using (binaryWriter.BaseStream.Pin())
            {
                for (int i = 0; i < this.nodeRenderLeaves.Length && i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    this.nodeRenderLeaves[i].Write(binaryWriter);
                }
            }
        }
    }
}
