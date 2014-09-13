using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Moonfish.Structures
{
    public class Struct
    {
        public StructType Type;
        string name;
        public string Name
        {
            get
            {
                var value = name;
                foreach (var invalid_char in Path.GetInvalidPathChars())
                    value = value.Replace(invalid_char, '_');

                var tokens = value.Split(' ');

                for (var i = 0; i < tokens.Length; ++i)
                {
                    var firstLetter = new string(new char[] { tokens[i][0] }).ToUpper();
                    tokens[i] =  firstLetter + tokens[i].Substring(1);
                }

                value = string.Join(string.Empty, tokens);

                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                value = rgx.Replace(value, "");

                return value;
            }
            set {name = value;}
        }
        public int Offset;
        public int Size;
        public List<Struct> Children;

        public void Read(XmlReader xmlReader)
        {
            xmlReader.Read();
            switch (xmlReader.Name.ToLower())
            {
                case "plugin": 
                    name = xmlReader["class"];
                    Offset = 0;
                    Size = int.Parse(xmlReader["headersize"]);
                    Children = new List<Struct>();
                    ReadChildren(xmlReader);
                    break;
                case "struct": 
                    name = xmlReader["name"];
                    Offset = int.Parse(xmlReader["offset"]);
                    Size = int.Parse(xmlReader["size"]);
                    Children = new List<Struct>();
                    ReadChildren(xmlReader);
                    break;
            }
        }

        private void ReadChildren(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (xmlReader.Name.ToLower())
                        {
                            case "struct":
                                Children.Add(new Struct());
                                Children.Last().Read(xmlReader.ReadSubtree());
                                break;
                        }
                        break;
                }
            }
        }

        public int FieldSize
        {
            get
            {
                switch (Type)
                {
                    case StructType.StringID:
                    case StructType.TagID: 
                        return 4;

                    case StructType.TagBlock:
                        return 8;
                }
                return 0;
            }
        }

        public string TypeName
        {
            get
            {
                switch (Type)
                {
                    case StructType.StringID:
                        return "StringID";
                    case StructType.TagBlock:
                        return string.Format("TagBlockList<{0}>", Name);
                    case StructType.TagID:
                        return "TagPointer";
                }
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return String.Format("{1} : {0}", Offset, Name);
        }
        

        public enum StructType
        {
            TagBlock,
            StringID,
            TagID,
        }
    }
    public static class EntConverter
    {
        static Struct pluginStructure;
        static Dictionary<string, int> Names;

        static EntConverter()
        {
            Names = new Dictionary<string, int>();
        }

        public static void ConvertEnt(Stream plugin, Stream output)
        {
            Names.Clear();
            pluginStructure = new Struct();
            using (XmlReader xmlReader = XmlReader.Create(plugin))
            {
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (xmlReader.Name.ToLower())
                            {
                                case "plugin":
                                    pluginStructure.Read(xmlReader.ReadSubtree());
                                    break;
                            }
                            break;
                    }
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(output))
            {
                streamWriter.WriteLine(
                @"using Moonfish;
                using Moonfish.Definitions;
                using Moonfish.Structures;
                namespace Moonfish
                {{   
                [TagClass(""{0}"")]", pluginStructure.Name);

                BeginTagBlock(streamWriter, pluginStructure);

                streamWriter.WriteLine("}");
            }
        }

        private static void BeginTagBlock(StreamWriter streamWriter, Struct structure)
        {

            streamWriter.Write(
            @"public class {0} : TagBlock
              {{
                public {0}()
                : base({1}", structure.Name, structure.Size);
            if (structure.Children.Count > 0)
            {
                streamWriter.WriteLine(", new TagBlockField[] {");
                int offset = 0;
                foreach (var child in structure.Children)
                {
                    if (offset < child.Offset)
                    {
                        var shift = child.Offset - offset;
                        streamWriter.WriteLine("   new TagBlockField(null, {0}),", shift);
                        offset += shift;
                    }
                    else if (offset > child.Offset) throw new InvalidProgramException();

                    ProcessName(child);

                    streamWriter.WriteLine(" new TagBlockField(new {0}()),", child.TypeName);
                    offset += child.FieldSize;
                }
                streamWriter.WriteLine("}) { }");

                foreach(var child in structure.Children)
                {
                    BeginTagBlock(streamWriter, child);
                }

            }
            else
            {
                streamWriter.WriteLine(") { }");
            }
            streamWriter.WriteLine(@"}");
        }

        private static void ProcessName(Struct child)
        {
            if (!Names.ContainsKey(child.Name))
            {
                Names[child.Name] = 0;
            }
            else
            {
                Names[child.Name]++;
                child.Name = child.Name + Names[child.Name];
            }
        }
    }
}
