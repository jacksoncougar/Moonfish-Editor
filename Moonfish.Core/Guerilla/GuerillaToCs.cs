using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.CSharp;
using System.CodeDom;
using System.Reflection;
using System.Runtime.CompilerServices;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla
{
    public class GuerillaCs : Guerilla
    {
        public void DumpTagLayout(string folder, string tagClassName, string outputClassName)
        {
            var readTag = h2Tags.Where(x => x.Class.ToString() == tagClassName).First();

            // Create the tag layout file.
            StreamWriter writer = new StreamWriter(string.Format("{0}\\{1}.cs", folder, readTag.Class.ToSafeString()));

            // Write Includes & Namespace
            writer.WriteLine(
@"using Moonfish.Model;
using OpenTK;
using System;
using System.Runtime.InteropServices;
using System.IO;

namespace Moonfish.Tags
{"
                );

            Dictionary<string, string> definitionDictionary = new Dictionary<string, string>();

            // Process the tag_group definition.
            string definitionString = ProcessTagBlockDefinition(readTag.Definition, definitionDictionary, readTag.definition_address, readTag.Class.ToString(), outputClassName, true);

            writer.Write(definitionString);
            foreach (string definition in definitionDictionary.Values.ToArray())
            {
                writer.WriteLine(writer.NewLine);
                writer.Write(definition);
            }

            // Write closing brace
            writer.WriteLine("}");

            // Close the tag layout writer.
            writer.Close();
        }

        Dictionary<field_type, Type> valueTypeDictionary;
        public GuerillaCs(string guerillaExecutablePath)
            : base(guerillaExecutablePath)
        {
            CacheBinaryReaderMethods();
            var assembly = typeof(Moonfish.Tags.StringID).Assembly;
            var query = from type in assembly.GetTypes()
                        where type.GetCustomAttributes(typeof(GuerillaTypeAttribute), false).Count() > 0
                        select type;
            var valueTypes = query.ToArray();
            valueTypeDictionary = new Dictionary<field_type, Type>(valueTypes.Count());
            foreach (var type in valueTypes)
            {
                var guerillaTypeAttributes = (GuerillaTypeAttribute[])type.GetCustomAttributes(typeof(GuerillaTypeAttribute), false);
                foreach (var guerillaType in guerillaTypeAttributes)
                {
                    valueTypeDictionary.Add(guerillaType.FieldType, type);
                }
            }
            valueTypeDictionary.Add(field_type._field_angle, typeof(float));
            valueTypeDictionary.Add(field_type._field_real_euler_angles_3d, typeof(Vector3));
            valueTypeDictionary.Add(field_type._field_char_integer, typeof(byte));
            valueTypeDictionary.Add(field_type._field_short_integer, typeof(short));
            valueTypeDictionary.Add(field_type._field_short_bounds, typeof(int));
            valueTypeDictionary.Add(field_type._field_long_integer, typeof(int));
            valueTypeDictionary.Add(field_type._field_real, typeof(float));
            valueTypeDictionary.Add(field_type._field_real_fraction, typeof(float));
            valueTypeDictionary.Add(field_type._field_real_fraction_bounds, typeof(float));
            valueTypeDictionary.Add(field_type._field_real_vector_3d, typeof(Vector3));
            valueTypeDictionary.Add(field_type._field_real_point_2d, typeof(Vector2));
            valueTypeDictionary.Add(field_type._field_real_point_3d, typeof(Vector3));
            valueTypeDictionary.Add(field_type._field_real_euler_angles_2d, typeof(Vector2));
            valueTypeDictionary.Add(field_type._field_real_plane_2d, typeof(Vector3));
            valueTypeDictionary.Add(field_type._field_real_plane_3d, typeof(Vector4));
            valueTypeDictionary.Add(field_type._field_real_quaternion, typeof(Quaternion));
            valueTypeDictionary.Add(field_type._field_real_argb_color, typeof(Vector4));
            valueTypeDictionary.Add(field_type._field_rectangle_2d, typeof(Vector2));

        }

        public string ProcessTagBlockDefinition(tag_block_definition tagBlock, Dictionary<string, string> structDictionary, int address, string group_tag = "", string className = "", bool root = false)
        {
            //
            StringWriter writer = new StringWriter();
            var size = CalculateSizeOfFieldSet(tagBlock.LatestFieldSet.Fields);

            // Write StructLayout attribute
            writer.WriteLine(@"[StructLayout(LayoutKind.Sequential, Size = {0}, Pack = {1})]", size, tagBlock.LatestFieldSet.Alignment);
            if (root) { writer.WriteLine(@"[TagClass(""{0}"")]", group_tag); }
            //Write class declaration
            writer.WriteLine(@"public partial {0} {1}", "class", className == string.Empty ? ToTypeName(tagBlock.Name) : className);
            writer.WriteLine("{");

            var i = 0;
            string constructorBody, fieldDefinitions;
            ProcessFields(tagBlock, structDictionary, writer, tagBlock.LatestFieldSet.Fields, ref i, out fieldDefinitions, out constructorBody);
            writer.WriteLine("public {0}()", className == string.Empty ? ToTypeName(tagBlock.Name) : className);
            writer.WriteLine("{");
            writer.WriteLine("}");
            writer.WriteLine("public {0}(BinaryReader binaryReader)", className == string.Empty ? ToTypeName(tagBlock.Name) : className);
            writer.WriteLine("{");
            writer.Write(constructorBody);
            writer.WriteLine("}");

            writer.Write(fieldDefinitions);


            // Finish the tag_field_set struct.
            writer.WriteLine("}");

            //
            return writer.ToString();
        }

        private void ProcessFields(tag_block_definition tagBlock, Dictionary<string, string> structDictionary, StringWriter writer, List<tag_field> fields, ref int i,
            out string fieldDefinitions, out string constructorBody)
        {
            StringBuilder fieldDefinitionsBuilder = new StringBuilder();
            StringBuilder constructorBodyBuilder = new StringBuilder();
            Dictionary<string, int> fieldNames = new Dictionary<string, int>();
            for (; i < fields.Count; ++i)
            {
                StringBuilder attributeString = new StringBuilder();
                var field = fields[i];
                // Check the field type.
                switch (field.type)
                {
                    case field_type._field_tag_reference:
                        {
                            attributeString.AppendFormat(@"TagReference(""{0}"")", GroupTagToString(field.Definition.group_tag));

                            string fieldName, fieldType;
                            WriteField(writer, field, fieldNames, out fieldName, out fieldType, attributeString.ToString());
                            constructorBodyBuilder.AppendLine(string.Format("this.{0} = binaryReader.Read{1}();", fieldName, fieldType));

                            break;
                        }
                    case field_type._field_block:
                        {
                            attributeString.Append("TagBlockField");

                            // Write the field
                            var fieldName = ProcessFieldName(ResolveFieldName(ref field, ToMemberName(field.Definition.DisplayName)), fieldNames);
                            var fieldType = ToTypeName(field.Definition.Name);

                            WriteField(writer, fieldType, fieldName, attributeString.ToString(), true);
                            constructorBodyBuilder.AppendLine(string.Format(@"{{    
    var elementSize = Marshal.SizeOf(typeof({0}));
    var blamPointer = binaryReader.ReadBlamPointer(elementSize);
    this.{1} = new {0}[blamPointer.Count];
    using(binaryReader.BaseStream.Pin())
    {{
    for(int i = 0; i < blamPointer.Count; ++i)
    {{
        binaryReader.BaseStream.Position = blamPointer[i]; 
        this.{1}[i] = new {0}(binaryReader);
    }}
    }}
}}", fieldType, fieldName));

                            if (!structDictionary.ContainsKey(field.Definition.Name))
                            {
                                structDictionary[field.Definition.Name] = ProcessTagBlockDefinition(field.Definition, structDictionary, field.definition);
                            }
                            break;
                        }
                    case field_type._field_struct:
                        {
                            attributeString.Append("TagStructField");

                            var fieldName = ProcessFieldName(ResolveFieldName(ref field, ToMemberName(field.Definition.displayName)), fieldNames);
                            var fieldType = ToTypeName(field.Definition.name);

                            WriteField(writer, fieldType, fieldName, attributeString.ToString());
                            constructorBodyBuilder.AppendLine(string.Format("this.{0} = new {1}(binaryReader);", fieldName, fieldType));

                            if (!structDictionary.ContainsKey(field.Definition.name))
                            {
                                structDictionary[field.Definition.name] = ProcessTagBlockDefinition(field.Definition.Definition, structDictionary, field.Definition.block_definition_address, "", fieldType);
                            }
                            break;
                        }
                    case field_type._field_data:
                        {
                            string fieldName;
                            WritePaddingField(writer, ref field, fieldNames, out fieldName, 8);
                            constructorBodyBuilder.AppendLine(string.Format("this.{0} = binaryReader.ReadBytes(8);",
                                fieldName));
                            break;
                        }
                    case field_type._field_explanation:
                        {
                            //// Check if there is sub-text for this explaination.
                            //string subtext = "";
                            //if (field.definition != 0)
                            //    subtext = ReadString(reader, field.definition);

                            //// Write the field info to the output file.
                            //writer.WriteLine("//FIELD_EXPLAINATION(\"{0}\", \"{1}\"),", field.Name, subtext.Replace("\n", "<lb>"));
                            break;
                        }
                    case field_type._field_byte_flags:
                    case field_type._field_long_flags:
                    case field_type._field_word_flags:
                    case field_type._field_char_enum:
                    case field_type._field_enum:
                    case field_type._field_long_enum:
                        {
                            var enumString = ReadEnum(ref field);

                            fieldDefinitionsBuilder.Append(enumString);

                            string fieldName = ToMemberName(field.Name);
                            string fieldType = ToTypeName(field.Name);

                            WriteField(writer, fieldType, fieldName, attributeString.ToString());
                            string baseType;
                            switch (field.type)
                            {
                                case field_type._field_char_enum:
                                case field_type._field_byte_flags:
                                    baseType = "Byte";
                                    break;
                                case field_type._field_word_flags:
                                case field_type._field_enum:
                                    baseType = "Int16";
                                    break;
                                case field_type._field_long_flags:
                                case field_type._field_long_enum:
                                    baseType = "Int32";
                                    break;
                                default:
                                    baseType = ""; break;

                            }
                            constructorBodyBuilder.AppendLine(string.Format("this.{0} = ({1})binaryReader.Read{2}();", fieldName, fieldType, baseType));
                            break;
                        }
                    case field_type._field_byte_block_flags:
                    case field_type._field_word_block_flags:
                    case field_type._field_long_block_flags:
                    case field_type._field_char_block_index1:
                    case field_type._field_short_block_index1:
                    case field_type._field_long_block_index1:
                    case field_type._field_char_block_index2:
                    case field_type._field_short_block_index2:
                    case field_type._field_long_block_index2:
                        {
                            string fieldName, fieldType;
                            WriteField(writer, field, fieldNames, out fieldName, out fieldType);
                            constructorBodyBuilder.AppendLine(string.Format("this.{0} = binaryReader.Read{1}();", fieldName, fieldType));
                            break;
                        }
                    case field_type._field_array_start:
                        {
                            string fieldName, fieldType;
                            ProcessArrayFields(tagBlock, structDictionary, writer, fields, ref field, ref i, fieldNames, out fieldName, out fieldType);
                            var count = field.definition;
                            constructorBodyBuilder.AppendLine(string.Format(
@"this.{0} = new {1}[{2}];
for(int i = 0 ; i < {2}; ++i)
{{
    this.{0}[i] = new {1}(binaryReader);
}}", fieldName, fieldType, count));
                            break;
                        }
                    case field_type._field_array_end:
                        {
                            constructorBody = constructorBodyBuilder.ToString();
                            fieldDefinitions = fieldDefinitionsBuilder.ToString();
                            return;
                        }
                    case field_type._field_pad:
                        {
                            string fieldName;
                            WritePaddingField(writer, ref field, fieldNames, out fieldName);
                            constructorBodyBuilder.AppendLine(string.Format("this.{0} = binaryReader.Read{1};",
                                fieldName, field.definition == 1 ? "Byte()" : string.Format("Bytes({0})", field.definition)));
                            break;
                        }
                    case field_type._field_skip:
                        {
                            string fieldName;
                            WritePaddingField(writer, ref field, fieldNames, out fieldName, true);
                            constructorBodyBuilder.AppendLine(string.Format("this.{0} = binaryReader.Read{1};",
                                fieldName, field.definition == 1 ? "Byte()" : string.Format("Bytes({0})", field.definition)));
                            break;
                        }
                    case field_type._field_useless_pad:
                    case field_type._field_terminator:
                    case field_type._field_custom:
                        {
                            break;
                        }
                    default:
                        {
                            string fieldName, fieldType;
                            WriteField(writer, field, fieldNames, out fieldName, out fieldType, attributeString.ToString());
                            constructorBodyBuilder.AppendLine(string.Format("this.{0} = binaryReader.{1}();", fieldName, GetBinaryReaderMethod(field)));
                            break;
                        }
                }
            }
            fieldDefinitions = fieldDefinitionsBuilder.ToString();
            constructorBody = constructorBodyBuilder.ToString();
        }

        void CacheBinaryReaderMethods()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            // get BinaryReader extension methods from the executing assembly 
            var extensionMethods = (from type in types
                                    where type.IsSealed && !type.IsGenericType && !type.IsNested
                                    from method in type.GetMethods(BindingFlags.Static
                                        | BindingFlags.Public | BindingFlags.NonPublic)
                                    where method.IsDefined(typeof(ExtensionAttribute), false)
                                    where method.GetParameters()[0].ParameterType == typeof(BinaryReader)
                                    select new { method = method, type = method.ReturnType }).ToList();

            // trim this down further to one of each return type
            extensionMethods = (from method in extensionMethods
                                group method by method.type into g
                                select g.First()).ToList();

            using (var provider = new CSharpCodeProvider())
            {
                var test = provider.CreateValidIdentifier(typeof(int).ToString());
                var binaryReaderMethods = (from method in typeof(BinaryReader).GetMethods()
                                           where method.ReturnType != typeof(void)
                                           select new { method = method, type = method.ReturnType }).ToList().Where(x =>
                                           {
                                               var typeString = provider.CreateValidIdentifier((x.type).ToString());
                                               typeString = typeString.Split('.').Last();
                                               return x.method.Name.ToLower().Contains(typeString.ToLower());
                                           }).ToList();


                binaryReaderMethods = (from method in binaryReaderMethods
                                       group method by method.type into g
                                       select g.First()).ToList();

                var totalMethods = binaryReaderMethods.Union(extensionMethods);
                Methods = new Dictionary<Type, string>(totalMethods.Count());
                foreach (var item in totalMethods)
                {
                    Methods[item.type] = item.method.Name;
                }
            }
        }

        Dictionary<Type, string> Methods;

        private string GetBinaryReaderMethod(tag_field field)
        {
            var method = (from m in Methods
                          where m.Key == valueTypeDictionary[field.type]
                          where m.Value.ToLower().Contains(valueTypeDictionary[field.type].Name.Split('.').Last().ToLower())
                          select m).First();
            return method.Value;
        }

        private void WritePaddingField(StringWriter writer, ref tag_field field, Dictionary<string, int> fieldNames, out string fieldName, bool isSkip = false)
        {
            WritePaddingField(writer, ref field, fieldNames, out fieldName, field.definition, isSkip);
        }
        private void WritePaddingField(StringWriter writer, ref tag_field field, Dictionary<string, int> fieldNames, out string fieldName, int paddingLength, bool isSkip = false)
        {
            var postFix = ProcessFieldName(ToMemberName(field.Name), fieldNames);
            var token = "invalidName_";
            postFix = postFix.Contains(token) ? postFix.Remove(postFix.IndexOf(token), token.Length) : postFix;
            var paddingType = (isSkip ? "skip" : "padding");
            fieldName = paddingType + postFix;
            var fieldType = "byte";

            writer.WriteLine(@"#region {0}", paddingType);
            WriteFieldValArray(writer, paddingLength, fieldName, fieldType, true);
            writer.WriteLine(@"#endregion");
        }
        private void WriteFieldValArray(StringWriter writer, ref tag_field field, Dictionary<string, int> fieldNames, out string fieldName, out string fieldType, int arrayLength, bool isSkip = false)
        {
            fieldName = ProcessFieldName(ToMemberName(field.Name), fieldNames);
            fieldType = ToTypeName(field.Name);
            WriteFieldValArray(writer, arrayLength, fieldName, fieldType);
        }
        private void WriteFieldValArray(StringWriter writer, int arrayLength, string fieldName, string fieldType, bool isPrivate = false)
        {
            if (arrayLength != 1)
            {
                writer.WriteLine("[TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = {0})]", arrayLength);
            }
            writer.WriteLine("{3} {0} {1}{2};", fieldType, arrayLength == 1 ? "" : "[]", fieldName, isPrivate ? "private" : "public");
        }

        private void WriteField(StringWriter writer, tag_field field, Dictionary<string, int> fieldNames, out string fieldName, out string fieldType, string attributeString = "")
        {
            fieldType = FormatTypeString(ref field);
            fieldName = ProcessFieldName(ToMemberName(field.Name), fieldNames);
            WriteField(writer, fieldType, fieldName, attributeString);
        }
        private void WriteField(StringWriter writer, string typeString, string fieldNameString, string attributesString, bool isArray = false)
        {
            if (!string.IsNullOrEmpty(attributesString))
            {
                attributesString = FormatAttributeString(attributesString);
                writer.WriteLine(attributesString);
            }
            writer.WriteLine("public {0}{1} {2};", typeString, isArray ? "[]" : string.Empty, fieldNameString);
        }

        protected override string FormatTypeString(ref tag_field field)
        {
            var csType = valueTypeDictionary[field.type];
            return FormatTypeReference(csType);
        }

        private string ProcessFieldName(string fieldName, Dictionary<string, int> fieldNames)
        {
            if (fieldNames.ContainsKey(fieldName))
            {
                fieldName = fieldName + fieldNames[fieldName]++;
            }
            else
            {
                fieldNames[fieldName] = 0;
            }
            return ValidateFieldName(fieldName);
        }

        private void ProcessArrayFields(tag_block_definition definition, Dictionary<string, string> structDictionary,
            StringWriter writer, List<tag_field> fields, ref tag_field field, ref int fieldIndex, Dictionary<string, int> fieldNames,
            out string fieldName, out string fieldType)
        {
            fieldName = ToTypeName(field.Name);
            writer.WriteLine("public struct {0}", fieldName);
            writer.WriteLine("{");

            var name = field.Name;
            ++fieldIndex;
            string fieldDefinitions, constructorBody;
            ProcessFields(definition, structDictionary, writer, fields, ref fieldIndex, out fieldDefinitions, out constructorBody);

            writer.WriteLine("public {0}(BinaryReader binaryReader)", fieldName);
            writer.WriteLine("{");
            writer.Write(constructorBody);
            writer.WriteLine("}");
            writer.WriteLine("}");
            WriteFieldValArray(writer, ref field, fieldNames, out fieldName, out fieldType, field.definition);
        }

        private string ReadEnum(ref tag_field field)
        {
            switch (field.type)
            {
                case field_type._field_byte_flags:
                    return FormatEnum(ref field, field.Definition.Options, typeof(byte), new ActionRef<int>(IncrementFlags), true);
                case field_type._field_word_flags:
                    return FormatEnum(ref field, field.Definition.Options, typeof(short), new ActionRef<int>(IncrementFlags), true);
                case field_type._field_long_flags:
                    return FormatEnum(ref field, field.Definition.Options, typeof(int), new ActionRef<int>(IncrementFlags), true);
                case field_type._field_char_enum:
                    return FormatEnum(ref field, field.Definition.Options, typeof(byte), new ActionRef<int>(IncrementEnum));
                case field_type._field_enum:
                    return FormatEnum(ref field, field.Definition.Options, typeof(short), new ActionRef<int>(IncrementEnum));
                case field_type._field_long_enum:
                    return FormatEnum(ref field, field.Definition.Options, typeof(int), new ActionRef<int>(IncrementEnum));

            }
            throw new InvalidDataException();
        }

        delegate void ActionRef<T>(ref T item);

        public static string FormatTypeReference(Type type)
        {
            using (var provider = new CSharpCodeProvider())
            {
                var typeRef = new CodeTypeReference(type);
                var typeName = provider.GetTypeOutput(typeRef);

                typeName = typeName.Substring(typeName.LastIndexOf('.') + 1);
                return typeName;
            }
        }

        private string FormatEnum(ref tag_field field, List<string> options, Type baseType, ActionRef<int> incrementMethod, bool isFlags = false)
        {
            StringWriter stringWriter = new StringWriter();
            Dictionary<string, int> optionDictionary = new Dictionary<string, int>();

            var baseTypeString = FormatTypeReference(baseType);

            if (isFlags)
                stringWriter.WriteLine("[Flags]");

            stringWriter.WriteLine(string.Format("public enum {0} : {1}", ToTypeName(field.Name), baseTypeString));
            stringWriter.WriteLine('{');

            var index = isFlags ? 1 : 0;
            foreach (string option in options)
            {
                if (option != string.Empty)
                {
                    stringWriter.WriteLine("{0} = {1},", ProcessFieldName(ToTypeName(option), optionDictionary), index);
                }
                incrementMethod(ref index);
            }

            stringWriter.WriteLine("}");
            return stringWriter.ToString();
        }

        void IncrementEnum(ref int enumIndex)
        {
            enumIndex++;
        }

        void IncrementFlags(ref int flagsIndex)
        {
            flagsIndex <<= 1;
        }

        protected override string FormatAttributeString(string attributeString)
        {
            return string.Format("[{0}]", attributeString);
        }

        public string ReadString(BinaryReader reader, int address)
        {
            string str = "";

            // Check if address is smaller than the base address of the executable.
            if (address < Guerilla.BaseAddress)
            {
                // The string is stored in the h2 language library.
                StringBuilder sb = new StringBuilder(0x1000);
                Guerilla.LoadString(Guerilla.h2LangLib, (uint)address, sb, sb.Capacity);
                str = sb.ToString();
            }
            else if (address > Guerilla.BaseAddress && (address - Guerilla.BaseAddress) < (int)reader.BaseStream.Length)
            {
                // Seek to the string address.
                reader.BaseStream.Position = address - Guerilla.BaseAddress;

                // Read the string from the executable.
                char b;
                while ((b = reader.ReadChar()) != '\0')
                    str += b;
            }

            // Return the string buffer.
            return str;
        }

        public string GroupTagToString(int group_tag)
        {
            // Check if the group_tag is null.
            if (group_tag == -1)
                return string.Empty;

            // Convert the group_tag to a byte array.
            byte[] bytes = BitConverter.GetBytes(group_tag);

            // Convert each byte to a char.
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
                str += (char)bytes[i];

            // Return the string buffer.
            return Microsoft.VisualBasic.Strings.StrReverse(str);
        }

        public bool IsNumeric(string str)
        {
            // Loop through the string and check each character.
            for (int i = 0; i < str.Length; i++)
            {
                // Check if the character is numeric.
                if (char.IsDigit(str[i]) == false)
                    return false;
            }

            // Every character is numeric, return true.
            return true;
        }
    }
}
