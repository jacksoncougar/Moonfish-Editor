using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{
    public class MarkerWrapper : IClickable
    {
        private NodeCollection nodes;
        public event EventHandler<MouseEventArgs> OnMouseClick;

        public Matrix4 WorldMatrix
        {
            get
            {
                var translationMatrix = Matrix4.CreateTranslation(this.marker.Translation);
                var rotationMatrix = Matrix4.CreateFromQuaternion(this.marker.Rotation);
                var scaleMatrix = Matrix4.CreateScale(this.marker.Scale);
                return scaleMatrix * rotationMatrix * translationMatrix * nodes.GetWorldMatrix(this.marker.nodeIndex);
            }
        }

        public RenderModelMarkerBlock marker;

        public MarkerWrapper(RenderModelMarkerBlock marker, NodeCollection nodes)
        {
            this.marker = marker;
            this.nodes = nodes;
        }

        public Action<Matrix4> MarkerUpdatedCallback;

        public event EventHandler MarkerUpdated;

        internal void mousePole_WorldMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            var translation = e.Delta.ExtractTranslation();
            this.marker.Translation += translation;
            if (MarkerUpdated != null) MarkerUpdated(this, null);
            if (MarkerUpdatedCallback != null) MarkerUpdatedCallback(this.WorldMatrix);
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
}
