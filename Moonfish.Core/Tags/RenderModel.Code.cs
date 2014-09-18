﻿using OpenTK;
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

    public class MarkerWrapper : IClickable
    {
        public event EventHandler<MouseEventArgs> OnMouseClick;

        public RenderModelMarkerBlock marker;

        public MarkerWrapper(RenderModelMarkerBlock marker)
        {
            this.marker = marker;
        }

        public Action<Matrix4> MarkerUpdatedCallback;

        public event EventHandler MarkerUpdated;

        internal void mousePole_WorldMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            var translation = e.Delta.ExtractTranslation();
            this.marker.Translation += translation;
            if (MarkerUpdated != null) MarkerUpdated(this, null);
            if (MarkerUpdatedCallback != null) MarkerUpdatedCallback(e.Matrix);
        }

        void IClickable.OnMouseDown(object sender, MouseEventArgs e)
        {
        }

        void IClickable.OnMouseMove(object sender, MouseEventArgs e)
        {
        }

        void IClickable.OnMouseUp(object sender, MouseEventArgs e)
        {
        }

        void IClickable.OnMouseClickHandler(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Click");
            if (this.OnMouseClick != null) this.OnMouseClick(this, e);
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    partial class RenderModelMarkerBlock
    {
        public byte RegionIndex { get { return this.regionIndex; } set { this.regionIndex = value; } }
        public byte PermutationIndex { get { return this.permutationIndex; } set { this.permutationIndex = value; } }
        public byte NodeIndex { get { return this.nodeIndex; } set { this.nodeIndex = value; } }
        public Vector3 Translation { get { return this.translation; } set { this.translation = value; } }
        public Quaternion Rotation { get { return this.rotation; } set { this.rotation = value; } }
        public float Scale { get { return this.scale; } set { this.scale = value; } }
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
    partial class RenderModelSectionBlock
    {
        [ReflectionPermission(SecurityAction.Assert, Unrestricted = true)]
        public void ReadSectionData(BinaryReader sourceReader, Object item, FieldInfo field)
        {
            var originalDelegate = Deserializer.ProcessTagBlockArray.Clone();
            Deserializer.ProcessTagBlockArray = new Deserializer.ProcessTagBlockArrayDelegate(CustomProcessTagBlockArray);
            //DeserializerOLD.PreprocessField = new DeserializerOLD.PreprocessFieldDelegate(PreprocessField);

            if (!geometryBlockInfo.IsInternal)
            {
                Stream resourceStream;
                if (Halo2.TryGettingResourceStream(geometryBlockInfo.blockOffset + 8, out resourceStream))
                {
                    resourceStream.Position = geometryBlockInfo.BlockAddress + 8;
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
                sourceReader.BaseStream.Position = geometryBlockInfo.BlockAddress + 8;
                var returnValue = Deserializer.Deserialize(sourceReader, typeof(RenderModelSectionDataBlock));

                Deserializer.PreprocessField = null;
                Deserializer.ProcessTagBlockArray = (Deserializer.ProcessTagBlockArrayDelegate)originalDelegate;
                field.Set(item, new RenderModelSectionDataBlock[] { returnValue });
            }
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
                var off = Marshal.OffsetOf(item.GetType(), field.Name);
                var offset = (int)Deserializer.OffsetOf(item.GetType(), field.Name);
                if (item.GetType() == typeof(GlobalGeometryPointDataStruct))
                {
                    var size = Marshal.SizeOf(typeof(GlobalGeometrySectionStruct));
                    offset += size;
                }

                var r = (from resource in this.geometryBlockInfo.resources
                         where resource.primaryLocator == offset
                         select resource).ToArray();
                address = this.geometryBlockInfo.BlockAddress + this.geometryBlockInfo.sectionDataSize + 8 + r.First().resourceDataOffset;


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
                                sourceReader.BaseStream.Position = this.geometryBlockInfo.BlockAddress + this.geometryBlockInfo.sectionDataSize + 8 + r[i + 1].resourceDataOffset;
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
