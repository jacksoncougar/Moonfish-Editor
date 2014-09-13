using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Tags
{
    partial class RenderModelNodeBlock
    {
        public Matrix4 WorldMatrix
        {
            get
            {
                var worldMatrix = Matrix4.Identity;
                var translation = Matrix4.CreateTranslation(this.defaultTranslation);
                var rotation = Matrix4.CreateFromQuaternion(this.defaultRotation);
                return worldMatrix *= translation * rotation;
            }
        }
    }
}
