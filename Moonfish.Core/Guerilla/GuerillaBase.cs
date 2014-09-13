using Microsoft.CSharp;
using Moonfish.Tags;
using OpenTK;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Moonfish.Guerilla
{
    //public static class GuerillaBase
    //{
    //    /// <summary>
    //    /// The image load address used for translating virtual addresses to physical addresses.
    //    /// </summary>
    //    public const int BaseAddress = 0x400000;

    //    /// <summary>
    //    /// Virtual address of the tag layout table.
    //    /// </summary>
    //    public const int TagLayoutTableAddress = 0x00901B90;

    //    /// <summary>
    //    /// The number of tag layouts in the tag layout table.
    //    /// </summary>
    //    public const int NumberOfTagLayouts = 120;

    //    /// <summary>
    //    /// Name of the h2 language library used for localizing user interface strings.
    //    /// </summary>
    //    public const string H2LanguageLibrary = @"C:\Program Files (x86)\Microsoft Games\Halo 2 Map Editor\h2alang.dll";

    //    #region Imports

    //    [DllImport("kernel32")]
    //    public extern static IntPtr LoadLibrary(string librayName);

    //    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    //    public static extern int LoadString(IntPtr hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);

    //    #endregion

    //    public static IntPtr h2LangLib;

    //    public static void LoadLanguageLibrary()
    //    {
    //        // Load the h2 language library.
    //        h2LangLib = LoadLibrary(H2LanguageLibrary);
    //    }

    //    static GuerillaBase()
    //    {
    //        LoadLanguageLibrary();
    //        CacheBinaryReaderMethods();
    //        LoadValueTypesLookup();
    //    }

    //    private static void LoadValueTypesLookup()
    //    {
    //        var assembly = typeof(Moonfish.Tags.StringID).Assembly;
    //        var query = from type in assembly.GetTypes()
    //                    where type.GetCustomAttributes(typeof(GuerillaTypeAttribute), false).Count() > 0
    //                    select type;
    //        var valueTypes = query.ToArray();
    //        valueTypeDictionary = new Dictionary<field_type, Type>(valueTypes.Count());
    //        foreach (var type in valueTypes)
    //        {
    //            var guerillaTypeAttributes = (GuerillaTypeAttribute[])type.GetCustomAttributes(typeof(GuerillaTypeAttribute), false);
    //            foreach (var guerillaType in guerillaTypeAttributes)
    //            {
    //                valueTypeDictionary.Add(guerillaType.FieldType, type);
    //            }
    //        }
    //        valueTypeDictionary.Add(field_type._field_angle, typeof(float));
    //        valueTypeDictionary.Add(field_type._field_real_euler_angles_3d, typeof(Vector3));
    //        valueTypeDictionary.Add(field_type._field_char_integer, typeof(byte));
    //        valueTypeDictionary.Add(field_type._field_short_integer, typeof(short));
    //        valueTypeDictionary.Add(field_type._field_short_bounds, typeof(int));
    //        valueTypeDictionary.Add(field_type._field_long_integer, typeof(int));
    //        valueTypeDictionary.Add(field_type._field_real, typeof(float));
    //        valueTypeDictionary.Add(field_type._field_real_fraction, typeof(float));
    //        valueTypeDictionary.Add(field_type._field_real_fraction_bounds, typeof(float));
    //        valueTypeDictionary.Add(field_type._field_real_vector_3d, typeof(Vector3));
    //        valueTypeDictionary.Add(field_type._field_real_point_2d, typeof(Vector2));
    //        valueTypeDictionary.Add(field_type._field_real_point_3d, typeof(Vector3));
    //        valueTypeDictionary.Add(field_type._field_real_euler_angles_2d, typeof(Vector2));
    //        valueTypeDictionary.Add(field_type._field_real_plane_2d, typeof(Vector3));
    //        valueTypeDictionary.Add(field_type._field_real_plane_3d, typeof(Vector4));
    //        valueTypeDictionary.Add(field_type._field_real_quaternion, typeof(Vector4));
    //        valueTypeDictionary.Add(field_type._field_real_argb_color, typeof(Vector4));
    //        valueTypeDictionary.Add(field_type._field_rectangle_2d, typeof(Vector2));
    //    }

    //    static void CacheBinaryReaderMethods()
    //    {
    //        var types = Assembly.GetExecutingAssembly().GetTypes();
    //        // get BinaryReader extension methods from the executing assembly 
    //        var extensionMethods = (from type in types
    //                                where type.IsSealed && !type.IsGenericType && !type.IsNested
    //                                from method in type.GetMethods(BindingFlags.Static
    //                                    | BindingFlags.Public | BindingFlags.NonPublic)
    //                                where method.IsDefined(typeof(ExtensionAttribute), false)
    //                                where method.GetParameters()[0].ParameterType == typeof(BinaryReader)
    //                                select new { method = method, type = method.ReturnType }).ToList();

    //        // trim this down further to one of each return type
    //        extensionMethods = (from method in extensionMethods
    //                            group method by method.type into g
    //                            select g.First()).ToList();

    //        using (var provider = new CSharpCodeProvider())
    //        {
    //            var test = provider.CreateValidIdentifier(typeof(int).ToString());
    //            var binaryReaderMethods = (from method in typeof(BinaryReader).GetMethods()
    //                                       where method.ReturnType != typeof(void)
    //                                       select new { method = method, type = method.ReturnType }).ToList().Where(x =>
    //                                       {
    //                                           var typeString = provider.CreateValidIdentifier((x.type).ToString());
    //                                           typeString = typeString.Split('.').Last();
    //                                           return x.method.Name.ToLower().Contains(typeString.ToLower());
    //                                       }).ToList();


    //            binaryReaderMethods = (from method in binaryReaderMethods
    //                                   group method by method.type into g
    //                                   select g.First()).ToList();

    //            var totalMethods = binaryReaderMethods.Union(extensionMethods);
    //            Methods = new Dictionary<Type, string>(totalMethods.Count());
    //            foreach (var item in totalMethods)
    //            {
    //                Methods[item.type] = item.method.Name;
    //            }
    //        }
    //    }

    //    public static List<tag_field> ReadFieldSetFields(this BinaryReader reader, tag_field_set fieldSet)
    //    {
    //        // Seek to the field set address.
    //        reader.BaseStream.Position = fieldSet.fields_address - BaseAddress;

    //        var fields = new List<tag_field>();
    //        var field = new tag_field();
    //        do
    //        {
    //            long currentAddress = reader.BaseStream.Position;
    //            field = reader.ReadFieldDefinition<tag_field>();
    //            fields.Add(field);
    //            // Seek to the next tag_field.
    //            reader.BaseStream.Position = currentAddress + 16;// sizeof(tag_field);
    //        }
    //        while (field.type != field_type._field_terminator);
    //        return fields;
    //    }

    //    public static tag_field_set ReadFieldSet(this BinaryReader reader, ref tag_block_definition definition, string group_tag = "")
    //    {
    //        var field_set = new tag_field_set();
    //        if (group_tag == "snd!")
    //        {
    //            definition.field_sets_address = 0x957870;
    //            //definition.field_set_latest_address = 0x906178;
    //            field_set.version.fields_address = 0x906178;
    //            field_set.version.index = 0;
    //            field_set.version.upgrade_proc = 0;
    //            field_set.version.size_of = -1;
    //            field_set.size = 172;
    //            field_set.alignment_bit = 0;
    //            field_set.parent_version_index = -1;
    //            field_set.fields_address = 0x906178;
    //            field_set.size_string_address = 0x00795330;
    //            field_set.size_string = "sizeof(sound_definition)";
    //        }
    //        else
    //        {
    //            // We are going to use the latest tag_field_set for right now.
    //            reader.BaseStream.Position = definition.field_set_latest_address - BaseAddress;
    //            field_set = reader.ReadFieldDefinition<tag_field_set>();
    //        }
    //        return field_set;
    //    }

    //    public static T ReadFieldDefinition<T>(this BinaryReader reader) where T : IReadDefinition, new()
    //    {
    //        // Read the tag_block_definition struct from the stream.
    //        T definition = new T();

    //        definition.Read(h2LangLib, reader);
    //        return definition;
    //    }

    //    public static T ReadFieldDefinition<T>(this BinaryReader reader, ref tag_field field) where T : IReadDefinition, new()
    //    {
    //        // Seek to the tag_block_definition address.
    //        reader.BaseStream.Position = field.definition - BaseAddress;

    //        return ReadFieldDefinition<T>(reader);
    //    }

    //    static Dictionary<Type, string> Methods;

    //    public static string GetBinaryReaderMethod(tag_field field)
    //    {
    //        var method = (from m in Methods
    //                      where m.Key == valueTypeDictionary[field.type]
    //                      where m.Value.ToLower().Contains(valueTypeDictionary[field.type].Name.Split('.').Last().ToLower())
    //                      select m).First();
    //        return method.Value;
    //    }

    //    public static string FormatAttributeString(string attributeString)
    //    {
    //        return string.Format("[{0}]", attributeString);
    //    }

    //    public static int CountFields(List<tag_field> fields, BinaryReader reader)
    //    {
    //        var totalFieldSetSize = 0;
    //        for (var i = 0; i < fields.Count; ++i)
    //        {
    //            var field = fields[i];
    //            var fieldSize = ResolveFieldSize(field, reader);
    //            if (field.type == field_type._field_array_start)
    //            {
    //                var arrayCount = field.definition;
    //                var elementSize = 0;
    //                do
    //                {
    //                    field = fields[++i];
    //                    elementSize += ResolveFieldSize(field, reader);
    //                } while (field.type != field_type._field_array_end);
    //                fieldSize += elementSize * arrayCount;
    //            }
    //            totalFieldSetSize += fieldSize;
    //        }
    //        return totalFieldSetSize;
    //    }

    //    public static int ResolveFieldSize(tag_field field, BinaryReader reader)
    //    {
    //        switch (field.type)
    //        {
    //            case field_type._field_struct:
    //                {
    //                    tag_struct_definition struct_definition = reader.ReadFieldDefinition<tag_struct_definition>(ref field);
    //                    reader.BaseStream.Position = struct_definition.block_definition_address - BaseAddress;

    //                    tag_block_definition block_definition = reader.ReadFieldDefinition<tag_block_definition>();
    //                    var fieldSet = reader.ReadFieldSet(ref block_definition);
    //                    var fields = reader.ReadFieldSetFields(fieldSet);
    //                    return CountFields(fields, reader);
    //                }
    //            case field_type._field_tag_reference:
    //            case field_type._field_block:
    //            case field_type._field_data:
    //                return 8;
    //            case field_type._field_char_enum:
    //            case field_type._field_byte_flags:
    //            case field_type._field_byte_block_flags:
    //            case field_type._field_char_block_index1:
    //            case field_type._field_char_block_index2:
    //                return 1;
    //            case field_type._field_enum:
    //            case field_type._field_word_flags:
    //            case field_type._field_word_block_flags:
    //            case field_type._field_short_block_index1:
    //            case field_type._field_short_block_index2:
    //                return 2;
    //            case field_type._field_long_enum:
    //            case field_type._field_long_flags:
    //            case field_type._field_long_block_flags:
    //            case field_type._field_long_block_index1:
    //            case field_type._field_long_block_index2:
    //                return 4;
    //            case field_type._field_array_start:
    //            case field_type._field_array_end:
    //                return 0;
    //            case field_type._field_skip:
    //            case field_type._field_pad:
    //                return field.definition;
    //            case field_type._field_useless_pad:
    //            case field_type._field_terminator:
    //            case field_type._field_custom:
    //            case field_type._field_explanation:
    //                return 0;
    //            default:
    //                var type = valueTypeDictionary[field.type];
    //                var size = Marshal.SizeOf(type);
    //                return size;
    //        }
    //    }

    //    public static string ValidateFieldName(string fieldName)
    //    {
    //        using (var provider = new CSharpCodeProvider())
    //        {
    //            if (!provider.IsValidIdentifier(fieldName))
    //            {
    //                fieldName = string.Format("invalidName_{0}", fieldName);
    //            }
    //        }
    //        return fieldName;
    //    }

    //    public static string ProcessFieldName(string fieldName, Dictionary<string, int> fieldNames)
    //    {
    //        if (fieldNames.ContainsKey(fieldName))
    //        {
    //            fieldName = fieldName + fieldNames[fieldName]++;
    //        }
    //        else
    //        {
    //            fieldNames[fieldName] = 0;
    //        }
    //        return ValidateFieldName(fieldName);
    //    }

    //    public static string ResolveFieldName(ref tag_field field, string fallbackFieldName)
    //    {
    //        var fieldName = field.Name.ToMemberName();
    //        return fieldName == "invalidName_" ? fallbackFieldName : fieldName;
    //    }

    //    public static string FormatTypeString(ref tag_field field)
    //    {
    //        var type = valueTypeDictionary[field.type];
    //        var typeName = FormatTypeReference(type);
    //        return typeName;
    //    }

    //    public static string FormatTypeReference(Type type)
    //    {
    //        using (var provider = new CSharpCodeProvider())
    //        {
    //            var typeRef = new CodeTypeReference(type);
    //            var typeName = provider.GetTypeOutput(typeRef);

    //            typeName = typeName.Substring(typeName.LastIndexOf('.') + 1);
    //            return typeName;
    //        }
    //    }

    //    public static string ToTypeName(this string option)
    //    {
    //        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    //        var typeName = option.Replace('_', ' ');
    //        typeName = typeName.Replace('-', ' ');
    //        typeName = textInfo.ToTitleCase(typeName);
    //        Regex r = new Regex("[^a-zA-Z0-9 -]");
    //        typeName = r.Replace(typeName, "");
    //        typeName = typeName.Replace(" ", "");
    //        typeName = ValidateFieldName(typeName);
    //        return typeName;
    //    }

    //    public static string ToMemberName(this string name)
    //    {
    //        if (string.Empty == ToTypeName(name)) return string.Empty;
    //        StringBuilder memberName = new StringBuilder(ToTypeName(name));
    //        var firstChar = char.ToLower(memberName[0]);
    //        memberName[0] = firstChar;
    //        return memberName.ToString();
    //    }

    //    public static string ReadString(BinaryReader reader, int address)
    //    {
    //        string str = "";

    //        // Check if address is smaller than the base address of the executable.
    //        if (address < BaseAddress)
    //        {
    //            // The string is stored in the h2 language library.
    //            StringBuilder sb = new StringBuilder(0x1000);
    //            LoadString(h2LangLib, (uint)address, sb, sb.Capacity);
    //            str = sb.ToString();
    //        }
    //        else if (address > BaseAddress && (address - BaseAddress) < (int)reader.BaseStream.Length)
    //        {
    //            // Seek to the string address.
    //            reader.BaseStream.Position = address - BaseAddress;

    //            // Read the string from the executable.
    //            char b;
    //            while ((b = reader.ReadChar()) != '\0')
    //                str += b;
    //        }

    //        // Return the string buffer.
    //        return str;
    //    }

    //    public static string GroupTagToString(int group_tag)
    //    {
    //        // Check if the group_tag is null.
    //        if (group_tag == -1)
    //            return string.Empty;

    //        // Convert the group_tag to a byte array.
    //        byte[] bytes = BitConverter.GetBytes(group_tag);

    //        // Convert each byte to a char.
    //        string str = "";
    //        for (int i = 0; i < bytes.Length; i++)
    //            str += (char)bytes[i];

    //        // Return the string buffer.
    //        return Microsoft.VisualBasic.Strings.StrReverse(str);
    //    }

    //    public static bool IsNumeric(string str)
    //    {
    //        // Loop through the string and check each character.
    //        for (int i = 0; i < str.Length; i++)
    //        {
    //            // Check if the character is numeric.
    //            if (char.IsDigit(str[i]) == false)
    //                return false;
    //        }

    //        // Every character is numeric, return true.
    //        return true;
    //    }
    //}

    public partial class Guerilla
    {
        /// <summary>
        /// The image load address used for translating virtual addresses to physical addresses.
        /// </summary>
        public const int BaseAddress = 0x400000;

        /// <summary>
        /// Virtual address of the tag layout table.
        /// </summary>
        public const int TagLayoutTableAddress = 0x00901B90;

        /// <summary>
        /// The number of tag layouts in the tag layout table.
        /// </summary>
        public const int NumberOfTagLayouts = 120;

        /// <summary>
        /// Name of the h2 language library used for localizing user interface strings.
        /// </summary>
        public const string H2LanguageLibrary = @"C:\Program Files (x86)\Microsoft Games\Halo 2 Map Editor\h2alang.dll";

        #region Imports

        [DllImport("kernel32")]
        public extern static IntPtr LoadLibrary(string librayName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int LoadString(IntPtr hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);

        #endregion

        public readonly static IntPtr h2LangLib;
        public static List<tag_group> h2Tags;
        public readonly static Dictionary<string, Action<BinaryReader, IList<tag_field>>> PostprocessFunctions;

        static Guerilla()
        {
            h2Tags = new List<tag_group>();
            Guerilla.h2LangLib = LoadLibrary(H2LanguageLibrary);
            PostprocessFunctions = new Dictionary<string, Action<BinaryReader, IList<tag_field>>>();
            var methods = (from method in Assembly.GetExecutingAssembly().GetTypes().SelectMany(x => x.GetMethods(BindingFlags.NonPublic | BindingFlags.Static))
                           where method.IsDefined(typeof(GuerillaPreProcessMethodAttribute), false)
                           select method).ToArray();
            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(GuerillaPreProcessMethodAttribute), false);

                foreach (GuerillaPreProcessMethodAttribute attribute in attributes)
                {
                    PostprocessFunctions[attribute.BlockName] = (Action<BinaryReader, IList<tag_field>>)Delegate.CreateDelegate(typeof(Action<BinaryReader, IList<tag_field>>), (method));
                }
            }
        }

        protected Guerilla(string guerillaExecutablePath)
        {
            // Open the guerilla executable.
            using (BinaryReader reader = new BinaryReader(new VirtualMemoryStream(guerillaExecutablePath, Guerilla.BaseAddress)))
            {
                Guerilla.h2Tags = new List<tag_group>(Guerilla.NumberOfTagLayouts);

                // Loop through all the tag layouts and extract each one.
                for (int i = 0; i < Guerilla.NumberOfTagLayouts; i++)
                {
                    // Go to the tag layout table.
                    reader.BaseStream.Position = Guerilla.TagLayoutTableAddress + (i * 4);

                    // Read the tag layout pointer.
                    int layoutAddress = reader.ReadInt32();

                    // Go to the tag layout and read it.
                    reader.BaseStream.Position = layoutAddress;
                    tag_group tag = new tag_group(reader);
                    h2Tags.Add(tag);
                }
            }
        }

        protected virtual string FormatAttributeString(string attributeString)
        {
            return attributeString;
        }

        public static int CalculateSizeOfFieldSet(IList<tag_field> fields)
        {
            var totalFieldSetSize = 0;
            for (int i = 0; i < fields.Count; ++i)
            {
                var field = fields[i];
                var fieldSize = CalculateSizeOfField(field);
                if (field.type == field_type._field_array_start)
                {
                    var arrayCount = field.definition;
                    var elementSize = 0;
                    do
                    {
                        field = fields[++i];
                        elementSize += CalculateSizeOfField(field);
                    } while (field.type != field_type._field_array_end);
                    fieldSize += elementSize * arrayCount;
                }
                totalFieldSetSize += fieldSize;
            }
            return totalFieldSetSize;
        }

        public static int CalculateSizeOfField(tag_field field)
        {
            switch (field.type)
            {
                case field_type._field_struct:
                    {
                        tag_struct_definition struct_definition = (tag_struct_definition)field.Definition;
                        tag_block_definition blockDefinition = struct_definition.Definition;

                        return CalculateSizeOfFieldSet(blockDefinition.LatestFieldSet.Fields);
                    }
                case field_type._field_skip:
                case field_type._field_pad:
                    return field.definition;
                default:
                    return GetFieldSize(field.type);
            }
        }

        public static int GetFieldSize(field_type type)
        {
            switch (type)
            {
                #region Standard Types
                case field_type._field_char_integer:
                case field_type._field_char_enum:
                case field_type._field_byte_flags:
                case field_type._field_byte_block_flags:
                case field_type._field_char_block_index1:
                case field_type._field_char_block_index2:
                    return 1;
                case field_type._field_short_integer:
                case field_type._field_enum:
                case field_type._field_word_flags:
                case field_type._field_word_block_flags:
                case field_type._field_short_block_index1:
                case field_type._field_short_block_index2:
                    return 2;
                case field_type._field_long_integer:
                case field_type._field_long_enum:
                case field_type._field_long_flags:
                case field_type._field_long_block_flags:
                case field_type._field_long_block_index1:
                case field_type._field_long_block_index2:
                    return 4;
                #endregion
                case field_type._field_string:
                    return 32;
                case field_type._field_long_string:
                    return 256;
                case field_type._field_string_id:
                case field_type._field_old_string_id: //?
                    return 4;

                case field_type._field_point_2d:
                    {
                        return 4;
                    }
                case field_type._field_rectangle_2d:
                    return 8;

                #region Real, Vector, Point, Angle Types
                case field_type._field_real:
                case field_type._field_angle:
                case field_type._field_real_fraction:
                    return 4;
                case field_type._field_real_point_2d:
                case field_type._field_real_vector_2d:
                case field_type._field_real_euler_angles_2d:
                    return 8;
                case field_type._field_real_point_3d:
                case field_type._field_real_vector_3d:
                case field_type._field_real_euler_angles_3d:
                    return 12;
                case field_type._field_real_quaternion:
                    return 16;
                case field_type._field_real_plane_2d:
                    return 12;
                case field_type._field_real_plane_3d:
                    return 16;
                #endregion

                #region Colour Types
                case field_type._field_rgb_color:
                    return 3;
                case field_type._field_argb_color:
                    return 4;
                case field_type._field_real_rgb_color:
                case field_type._field_real_hsv_color:
                    return 12;
                case field_type._field_real_argb_color:
                case field_type._field_real_ahsv_color:
                    return 16;
                #endregion

                #region Bounds
                case field_type._field_short_bounds:
                    return 4;
                case field_type._field_angle_bounds:
                case field_type._field_real_bounds:
                case field_type._field_real_fraction_bounds:
                    return 8;
                #endregion

                case field_type._field_tag:
                    return 4;
                case field_type._field_tag_reference:
                case field_type._field_block:
                case field_type._field_data:
                    return 8;

                case field_type._field_vertex_buffer:
                    return 32;

                //case field_type._field_pad:
                //case field_type._field_skip:
                //case field_type._field_struct:

                case field_type._field_useless_pad:
                case field_type._field_array_start:
                case field_type._field_array_end:
                case field_type._field_explanation:
                case field_type._field_terminator:
                case field_type._field_custom:
                    return 0;
            }
            throw new Exception();
        }

        protected virtual string ValidateFieldName(string fieldName)
        {
            using (var provider = new CSharpCodeProvider())
            {
                if (!provider.IsValidIdentifier(fieldName))
                {
                    var huh = provider.CreateValidIdentifier(fieldName);
                    fieldName = string.Format("invalidName_{0}", fieldName);
                }
            }
            return fieldName;
        }

        protected virtual string PostProcessFieldName(string fieldName, Dictionary<string, int> fieldNames)
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

        protected virtual string ResolveFieldName(ref tag_field field, string fallbackFieldName)
        {
            var fieldName = ToMemberName(field.Name);
            return fieldName == "invalidName_" ? fallbackFieldName : fieldName;
        }

        protected virtual string FormatTypeString(ref tag_field field)
        {
            return field.type.ToString();
        }

        protected virtual string ToTypeName(string value)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var typeName = value.Replace('_', ' ');
            typeName = typeName.Replace('-', ' ');
            typeName = textInfo.ToTitleCase(typeName);
            Regex r = new Regex("[^a-zA-Z0-9 -]");
            typeName = r.Replace(typeName, "");
            typeName = typeName.Replace(" ", "");
            typeName = ValidateFieldName(typeName);
            return typeName;
        }

        protected virtual string ToMemberName(string value)
        {
            if (string.Empty == ToTypeName(value)) return string.Empty;
            StringBuilder memberName = new StringBuilder(ToTypeName(value));
            var firstChar = char.ToLower(memberName[0]);
            memberName[0] = firstChar;
            return memberName.ToString();
        }

        public static string ReadString(BinaryReader reader, int address)
        {
            string str = "";

            // Check if address is smaller than the base address of the executable.
            if (address < BaseAddress)
            {
                // The string is stored in the h2 language library.
                StringBuilder sb = new StringBuilder(0x1000);
                LoadString(h2LangLib, (uint)address, sb, sb.Capacity);
                str = sb.ToString();
            }
            else if (address > BaseAddress && (address - BaseAddress) < (int)reader.BaseStream.Length)
            {
                // Seek to the string address.
                reader.BaseStream.Position = address - BaseAddress;

                // Read the string from the executable.
                char b;
                while ((b = reader.ReadChar()) != '\0')
                    str += b;
            }

            // Return the string buffer.
            return str;
        }

        public static string GroupTagToString(int group_tag)
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

        public static bool IsNumeric(string str)
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
