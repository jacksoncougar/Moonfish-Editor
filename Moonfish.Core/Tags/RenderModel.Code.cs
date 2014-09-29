using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using Fasterflect;
using Moonfish.Graphics;
using Moonfish.ResourceManagement;

namespace Moonfish.Tags
{
    class MarkerGroupConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is RenderModelMarkerGroupBlock)
            {
                var markerGroup = (value as RenderModelMarkerGroupBlock);
                return markerGroup.name.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    

    public partial class GlobalGeometryCompressionInfoBlock
    {
        public Matrix4 ToExtentsMatrix()
        {
            Matrix4 extents_matrix = new Matrix4(
                new Vector4(positionBoundsX.Length / 2, 0.0f, 0.0f, 0.0f),
                new Vector4(0.0f, positionBoundsY.Length / 2, 0.0f, 0.0f),
                new Vector4(0.0f, 0.0f, positionBoundsZ.Length / 2, 0.0f),
                new Vector4(positionBoundsX.min + positionBoundsX.Length / 2, positionBoundsY.min + positionBoundsY.Length / 2, positionBoundsZ.min + positionBoundsZ.Length / 2, 1.0f)
                );
            return extents_matrix;
        }
    };

    [TypeConverter(typeof(ExpandableObjectConverter))]
    partial class RenderModelMarkerBlock
    {
        public byte RegionIndex { get { return this.regionIndex; } set { this.regionIndex = value; } }
        public byte PermutationIndex { get { return this.permutationIndex; } set { this.permutationIndex = value; } }
        public byte NodeIndex { get { return this.nodeIndex; } set { this.nodeIndex = value; } }
        public Vector3 Translation { get { return this.translation; } set { this.translation = value; } }
        public Quaternion Rotation { get { return this.rotation; } set { this.rotation = value; } }
        public float Scale { get { return this.scale == 0 ? 1 : this.scale; } set { this.scale = value; } }
    }

    [TypeConverter(typeof(MarkerGroupConverter))]
    partial class RenderModelMarkerGroupBlock
    {
        public RenderModelMarkerBlock[] Markers { get { return this.markers; } }
    }

    partial class RenderModelNodeBlock
    {

        public Matrix4 WorldMatrix
        {
            get
            {
                var worldMatrix = Matrix4.Identity;
                var translation = Matrix4.CreateTranslation(this.defaultTranslation);
                var rotation = Matrix4.CreateFromQuaternion(this.defaultRotation.Normalized());
                return worldMatrix = rotation * translation * Matrix4.Identity;
            }
        }
    }

    public partial class GlobalGeometryBlockInfoStruct
    {
        public int BlockAddress { get { return (int)(this.blockOffset & ~0xC0000000); } }
        public bool IsInternal
        {
            get
            {
                return (blockOffset & 0xC0000000) == 0;
            }
        }
    };
    partial class GlobalGeometrySectionStruct
    {
        public virtual GlobalGeometrySectionVertexBufferBlock[] ReadVertexbuffers(BinaryReader binaryReader)
        {
            var elementSize = Marshal.SizeOf(typeof(GlobalGeometrySectionVertexBufferBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var vertexBuffers = new GlobalGeometrySectionVertexBufferBlock[blamPointer.Count];
            List<BlamPointer> vertexBufferPointers = null;
            if (binaryReader.BaseStream is ResourceStream)
            {
                var stream = binaryReader.BaseStream as ResourceStream;
                vertexBufferPointers = stream.Resources.Where(x => x.type == Guerilla.Tags.GlobalGeometryBlockResourceBlockBase.Type.VertexBuffer)
                .Select(x =>
                {
                    var count = x.resourceDataSize;
                    var address = x.resourceDataOffset + stream.HeaderSize;
                    var size = 1;
                    return new BlamPointer(count, address, size);
                }).ToList();
            }
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    vertexBuffers[i] = new GlobalGeometrySectionVertexBufferBlock(binaryReader);
                    if (vertexBufferPointers != null)
                    {
                        binaryReader.BaseStream.Position = vertexBufferPointers[i].Address;
                        vertexBuffers[i].vertexBuffer.Data = binaryReader.ReadBytes(vertexBufferPointers[i].Count);
                    }
                }
            }
            return vertexBuffers;
        }
    }

    partial class RenderModelSectionBlock
    {


        [ReflectionPermission(SecurityAction.Assert, Unrestricted = true)]
        public void ReadSectionData(BinaryReader sourceReader, Object item, FieldInfo field)
        {
            var originalDelegate = Deserializer.ProcessTagBlockArray.Clone();
            Deserializer.ProcessTagBlockArray = new Deserializer.ProcessTagBlockArrayDelegate(CustomProcessTagBlockArray);

            if (geometryBlockInfo.ResourceLocation != Halo2.ResourceSource.Local)
            {
                Stream resourceStream;
                if (Halo2.TryGettingResourceStream(geometryBlockInfo.blockOffset + 8, out resourceStream))
                {
                    resourceStream.Position = geometryBlockInfo.ResourceOffset + 8;
                    var readerResource = new BinaryReader(resourceStream);
                    var returnValue = Deserializer.Deserialize(readerResource, typeof(RenderModelSectionDataBlock));

                    Deserializer.PreprocessField = null;
                    Deserializer.ProcessTagBlockArray = (Deserializer.ProcessTagBlockArrayDelegate)originalDelegate;
                    field.Set(item, new RenderModelSectionDataBlock[] { returnValue });
                }
                else
                {
                    Deserializer.PreprocessField = null;
                    Deserializer.ProcessTagBlockArray = (Deserializer.ProcessTagBlockArrayDelegate)originalDelegate;
                    field.Set(item, new RenderModelSectionDataBlock[0]);
                }
            }
            else
            {
                sourceReader.BaseStream.Position = geometryBlockInfo.ResourceOffset + 8;
                var returnValue = Deserializer.Deserialize(sourceReader, typeof(RenderModelSectionDataBlock));

                Deserializer.PreprocessField = null;
                Deserializer.ProcessTagBlockArray = (Deserializer.ProcessTagBlockArrayDelegate)originalDelegate;
                field.Set(item, new RenderModelSectionDataBlock[] { returnValue });
            }
        }

        public bool LoadSectionData()
        {
            ResourceStream source = Halo2.GetResourceBlock(this.geometryBlockInfo);
            BinaryReader reader = new BinaryReader(source);
            this.sectionData = new[] { new RenderModelSectionDataBlock(reader) };
            return false;
        }

        private void CustomProcessTagBlockArray(BinaryReader sourceReader, object item, FieldInfo field)
        {
            Type elementType = field.FieldType.GetElementType();
            int elementSize = Marshal.SizeOf(elementType);

            var count = sourceReader.ReadInt32();
            var address = sourceReader.ReadInt32();

            var array = Array.CreateInstance(elementType, count);
            if (count > 0)
            {
                var offset = Deserializer.OffsetOf(item.GetType(), field.Name);
                if (item.GetType() == typeof(GlobalGeometryPointDataStruct))
                {
                    var size = Marshal.SizeOf(typeof(GlobalGeometrySectionStruct));
                    offset += size;
                }

                var r = (from resource in this.geometryBlockInfo.resources
                         where resource.primaryLocator == offset
                         select resource).ToArray();
                address = this.geometryBlockInfo.ResourceOffset + this.geometryBlockInfo.sectionDataSize + 8 + r.First( ).resourceDataOffset;


                for (int i = 0; i < count; ++i)
                {
                    sourceReader.BaseStream.Position = address + i * elementSize;
                    var element = Deserializer.Deserialize(sourceReader, elementType);
                    if (r.Length > 1)
                    {
                        var fields = (element).GetType().GetFields(
                                                                 BindingFlags.Public |
                                                                 BindingFlags.NonPublic |
                                                                 BindingFlags.Instance);
                        foreach (var elementField in fields)
                            if (elementField.FieldType == typeof(VertexBuffer))
                            {
                                var vertexBufferField = (VertexBuffer)elementField.GetValue(element);
                                sourceReader.BaseStream.Position = this.geometryBlockInfo.ResourceOffset + this.geometryBlockInfo.sectionDataSize + 8 + r[i + 1].resourceDataOffset;
                                vertexBufferField.Data = sourceReader.ReadBytes(r[i + 1].resourceDataSize);
                                elementField.SetValue(element, vertexBufferField);
                            }
                    }
                    array.SetValue(element, i);
                }
            }
            field.SetValue(item, array);
        }
    }
}
