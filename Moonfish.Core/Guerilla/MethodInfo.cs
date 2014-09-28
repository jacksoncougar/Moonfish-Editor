using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla
{
    public static class StringBuilderExtensions
    {
        public static void AppendSummary(this StringBuilder stringBuilder, string value)
        {
            stringBuilder.AppendLine("/// <summary>");
            stringBuilder.AppendLine(string.Format("/// {0}", value));
            stringBuilder.AppendLine("/// </summary>");
        }
    }

    [Flags]
    public enum AccessModifiers
    {
        Private = 1,
        Protected = 2,
        Internal = 4,
        Public = 8,
        Abstract = 16,
        Virtual = 32,
        Partial = 64,
    }

    public class ClassInfo
    {
        public ClassInfo()
        {
            Usings = new List<string>();
            Attributes = new List<AttributeInfo>();
            Fields = new List<FieldInfo>();
            Constructors = new List<MethodInfo>();
            EnumDefinitions = new List<EnumInfo>();
            ClassDefinitions = new List<ClassInfo>();
            Methods = new List<MethodInfo>();
        }

        public List<string> Usings { get; set; }
        public string Namespace { get; set; }
        public List<AttributeInfo> Attributes { get; set; }
        public AccessModifiers AccessModifiers { get; set; }
        public GuerillaName Value { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<MethodInfo> Constructors { get; set; }
        public List<EnumInfo> EnumDefinitions { get; set; }
        public List<ClassInfo> ClassDefinitions { get; set; }
        public List<MethodInfo> Methods { get; set; }

        public void Format()
        {
            string name, @namespace;
            if (GuerillaCs.SplitNamespaceFromFieldName(Value.Name, out name, out @namespace))
            {
                this.Value.Name = GuerillaCs.ToTypeName(name);
                this.Namespace = GuerillaCs.ToTypeName(@namespace);
            }

            FormatFieldNames();
        }
        public void FormatFieldNames()
        {
            using (var code = new Microsoft.CSharp.CSharpCodeProvider())
            {
                foreach (var field in Fields)
                {
                    var memberName = GuerillaCs.ToMemberName(field.Name);
                    field.Name = memberName;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", "Class",
                String.IsNullOrEmpty(Namespace) ? Value.Name : string.Format("{0}.{1}", Namespace, Value.Name));
        }
    }

    public static class AccessModifiersExtensions
    {
        public static string ToString(this AccessModifiers items)
        {
            var value = new StringBuilder();
            var values = items.ToString().Split(',').ToList();
            values.TakeWhile(x => x != values.Last()).ToList().ForEach(x => value.Append(string.Format("{0} ", x.ToLower())));
            value.Append(string.Format("{0}", values.LastOrDefault() == null ? "" : values.Last().ToLower()));

            return value.ToString();
        }
    }

    public class GuerillaName
    {
        public string Name
        {
            get { return GuerillaCs.SplitNameDescription(this.Value)[0]; }
            set { this.Value = this.Value.Replace(GuerillaCs.SplitNameDescription(this.Value)[0], value); }
        }
        public string Description
        {
            get { return GuerillaCs.SplitNameDescription(this.Value)[1]; }
            set { this.Value.Replace(GuerillaCs.SplitNameDescription(this.Value)[1], value); }
        }

        public bool HasDescription { get { return Description != null; } }

        string Value;

        public GuerillaName(string value)
        {
            this.Value = value;
        }

        public static implicit operator GuerillaName(string value)
        {
            return new GuerillaName(value);
        }

        public static implicit operator string(GuerillaName guerillaName)
        {
            return guerillaName.Value;
        }
    }

    public class EnumInfo
    {
        public Type BaseType { get; set; }
        public List<AttributeInfo> Attributes { get; set; }
        public AccessModifiers AccessModifiers { get; set; }
        public GuerillaName Value { get; set; }
        public List<GuerillaName> ValueNames { get; set; }

        public enum Type
        {
            Byte,
            Short,
            Int,
        }

        public EnumInfo()
        {
            Attributes = new List<AttributeInfo>();
            ValueNames = new List<GuerillaName>();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder
                (
                string.Format("{0} enum {1} : {2}", AccessModifiersExtensions.ToString(AccessModifiers), Value, BaseType.ToString().ToLowerInvariant())
                );
            stringBuilder.AppendLine("{");

            var isFlags = Attributes.Any(x => x.AttributeType == typeof(FlagsAttribute));
            var value = isFlags ? 1 : 0;
            foreach (var item in ValueNames)
            {
                if (item.HasDescription) stringBuilder.AppendSummary(item.Description);
                stringBuilder.AppendLine(string.Format("{0} = {1}", item.Name, value));
                value = isFlags ? value >> 1 : value++;
            }
            stringBuilder.AppendLine("};");
            return stringBuilder.ToString();
        }
    }

    public class AttributeInfo
    {
        public AttributeInfo(Type attributeType, params object[] namedParameters)
        {
            var count = namedParameters.Length % 2 == 0 ?
                namedParameters.Length / 2 : (namedParameters.Length - 1) / 2;
            this.NamedParameters = new List<Tuple<string, string>>(count);
            this.Parameters = new List<string>(count);
            for (int i = 0; i < count; i += 2)
            {
                if (namedParameters[i] == null)
                    Parameters.Add(namedParameters[i + 1].ToString());
                else
                    NamedParameters.Add(new Tuple<string, string>(namedParameters[i].ToString(), namedParameters[i + 1].ToString()));
            }
            this.AttributeType = attributeType;
        }

        public Type AttributeType { get; set; }
        public List<Tuple<string, string>> NamedParameters { get; set; }
        public List<string> Parameters { get; set; }

        public override string ToString()
        {
            using (var code = new Microsoft.CSharp.CSharpCodeProvider())
            {
                var hasParameters = NamedParameters.Count > 0 || Parameters.Count > 0;
                var parametersString = new StringBuilder();
                if (hasParameters && Parameters.Count > 0)
                {
                    Parameters.TakeWhile(x => Parameters.Last() != x).ToList().ForEach(x => parametersString.Append(string.Format("{0}, ", x)));
                    parametersString.Append(Parameters.Last());
                }
                if (hasParameters && NamedParameters.Count > 0)
                {
                    NamedParameters.TakeWhile(x => NamedParameters.Last() != x).ToList().ForEach(x => parametersString.Append(string.Format("{0}, ", x)));
                    parametersString.Append(NamedParameters.Last());
                }

                return string.Format("[{0}{1}]", AttributeType.Name,
                    hasParameters ? string.Format("{0}", parametersString) : "");
            }
        }
    }

    public class FieldInfo
    {
        public FieldInfo()
        {
            Attributes = new List<AttributeInfo>();
        }
        public List<AttributeInfo> Attributes { get; set; }
        AccessModifiers AccessModifiers { get; set; }
        public string FieldTypeName { get; set; }
        public string Name { get; set; }
        public bool IsArray { get; set; }
        public int ArraySize { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var attribute in Attributes)
                stringBuilder.AppendLine(attribute.ToString());
            var type = Type.GetType(FieldTypeName);
            var typeString = "";
            if (type != null)
            {
                using (var code = new Microsoft.CSharp.CSharpCodeProvider())
                {
                    typeString = code.GetTypeOutput(new System.CodeDom.CodeTypeReference(type.FullName));
                }
            }
            stringBuilder.AppendLine(string.Format("{0}{1} {2}",
                type == null ? FieldTypeName : typeString,
                IsArray ? "[]" : "", this.Name));
            return stringBuilder.ToString();
        }
    }

    public class MethodInfo
    {
        public MethodInfo()
        {
            Arguments = new List<string>();
        }
        public AccessModifiers AccessModifiers { get; set; }
        public string ClassName { get; set; }
        public List<string> Arguments { get; set; }
        public string Body { get; set; }
    }
}
