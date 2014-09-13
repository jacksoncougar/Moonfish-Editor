using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Globalization;
using Moonfish.Tags;

namespace Moonfish
{
    public class TagPointer : IField
    {
        IStructure parent;
        TagClass tag_class;
        TagIdent tag_identifier;
        const int size = 8;

        public static implicit operator TagIdent(TagPointer pointer)
        {
            return pointer.tag_identifier;
        }

        byte[] IField.GetFieldData()
        {
            byte[] return_bytes = new byte[size];
            BitConverter.GetBytes((int)tag_class).CopyTo(return_bytes, 0);
            BitConverter.GetBytes(tag_identifier).CopyTo(return_bytes, 4);
            return return_bytes;
        }

        void IField.SetFieldData(byte[] field_data, IStructure caller)
        {
            tag_class = (TagClass)BitConverter.ToInt32(field_data, 0);
            tag_identifier = BitConverter.ToInt32(field_data, 4);
        }

        int IField.SizeOfField
        {
            get { return size; }
        }

        void IField.Initialize(IStructure calling_structure)
        {
            parent = calling_structure;
        }
    }


}