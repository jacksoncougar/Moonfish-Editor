using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenTK;

namespace Moonfish.Guerilla
{
    public static class StringExtensions
    {
        public static string Tab( this string value, ref int tabCount, int tabSize = 4 )
        {
            var openingBraceCount = value.Trim( ).Count( x => x == '{' );
            var closingBraceCount = value.Trim( ).Count( x => x == '}' );
            var netTab = openingBraceCount - closingBraceCount;
            tabCount = netTab < 0 ? tabCount += netTab : tabCount;
            string tab = new string( ' ', tabCount * tabSize );
            tabCount = netTab > 0 ? tabCount += netTab : tabCount;
            return tab + value.Trim( );
        }
    }
    public static class StringBuilderExtensions
    {
        public static void AppendSummary( this StringBuilder stringBuilder, string value )
        {
            stringBuilder.AppendLine( "/// <summary>" );
            stringBuilder.AppendLine( string.Format( "/// {0}", value ) );
            stringBuilder.AppendLine( "/// </summary>" );
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
        public ClassInfo( )
        {
            Usings = new List<string>( )
            {
                "using Moonfish.Model;",
                "using Moonfish.Tags.BlamExtension;",
                "using Moonfish.Tags;",
                "using OpenTK;",
                "using System;",
                "using System.IO;",
            };
            Attributes = new List<AttributeInfo>( );
            Fields = new List<FieldInfo>( );
            Constructors = new List<MethodInfo>( );
            EnumDefinitions = new List<EnumInfo>( );
            ClassDefinitions = new List<ClassInfo>( );
            Methods = new List<MethodInfo>( );
            MethodsTemplates = new List<MethodInfo>( );
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
        public List<MethodInfo> MethodsTemplates { get; set; }

        public readonly string NamespaceBase = "Moonfish.Guerilla.Tags";
        public string NamespaceDeclaration
        {
            get { return string.Format( "namespace {0}", string.IsNullOrWhiteSpace( this.Namespace ) ? NamespaceBase : NamespaceBase + "." + this.Namespace ); }
        }
        public string ClassDeclaration
        {
            get { return string.Format( "{0} class {1}", AccessModifiersExtensions.ToString( AccessModifiers ), Value.Name ).Trim( ); }
        }

        internal class TokenDictionary
        {
            HashSet<string> Tokens { get; set; }

            public TokenDictionary( )
            {
                Tokens = new HashSet<string>( );
            }

            public string GenerateValidToken( string token )
            {
                var validToken = "";
                var salt = 0;
                do
                {
                    if( Tokens.Contains( token ) )
                    {
                        validToken = string.Format( "{0}{1}", token, salt );
                    }
                    else validToken = token;
                    salt++;
                } while( Tokens.Contains( validToken ) );
                Tokens.Add( validToken );
                return validToken;
            }
        }

        public void Format( )
        {
            TokenDictionary tokenDictionary = new TokenDictionary( );
            string name, @namespace;
            if( GuerillaCs.SplitNamespaceFromFieldName( Value.Name, out name, out @namespace ) )
            {
                this.Value.Name = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( name ) );
                this.Namespace = GuerillaCs.ToTypeName( @namespace );
            }
            else
            {
                this.Value.Name = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( this.Value.Name ) );
            }

            FormatFieldNames( tokenDictionary );
            foreach( var item in ClassDefinitions )
            {
                item.Format( );
            }
        }

        void FormatFieldNames( TokenDictionary tokenDictionary )
        {
            using( var code = new Microsoft.CSharp.CSharpCodeProvider( ) )
            {
                foreach( var item in Fields )
                {
                    var token = tokenDictionary.GenerateValidToken( GuerillaCs.ToMemberName( item.Value.Name ) );
                    item.Value.Name = token;
                }

                foreach( var item in Methods )
                {
                    var token = tokenDictionary.GenerateValidToken( GuerillaCs.ToMemberName( item.ClassName ) );
                    item.ClassName = token;
                }

                foreach( var item in EnumDefinitions )
                {
                    var token = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( item.Value.Name ) );
                    item.Value.Name = token;
                }
            }
        }

        public void Generate( )
        {
            GenerateReadBlockTemplateMethod( );
            GenerateReadDataMethod( );
            GenerateBinaryReaderConstructor( );
        }

        public void GenerateReadBlockTemplateMethod( )
        {
            MethodsTemplates.Add( new MethodInfo( )
            {
                Arguments = { "BinaryReader binaryReader" },
                AccessModifiers = AccessModifiers.Internal | AccessModifiers.Virtual,
                ClassName = "Read{0}Array",
                Body =
@"var elementSize = Deserializer.SizeOf(typeof({0}));
var blamPointer = binaryReader.ReadBlamPointer(elementSize);
var array = new {0}[blamPointer.Count];
using (binaryReader.BaseStream.Pin())
{{
    for (int i = 0; i < blamPointer.Count; ++i)
    {{
        binaryReader.BaseStream.Position = blamPointer[i];
        array[i] = new {0}(binaryReader);
    }}
}}
return array;",
                Returns = "{0}[]"
            } );
        }

        public void GenerateReadDataMethod( )
        {
            Methods.Add( new MethodInfo( )
            {
                Arguments = { "BinaryReader binaryReader" },
                AccessModifiers = AccessModifiers.Internal | AccessModifiers.Virtual,
                ClassName = "ReadData",
                Body =
@"var blamPointer = binaryReader.ReadBlamPointer(1);
var data = new byte[blamPointer.Count];
if(blamPointer.Count > 0)
{
    using (binaryReader.BaseStream.Pin())
    {
        binaryReader.BaseStream.Position = blamPointer[0];
        data = binaryReader.ReadBytes(blamPointer.Count);
    }
}
return data;",
                Returns = "byte[]"
            } );
        }

        public void GenerateBinaryReaderConstructor( )
        {
            Constructors.Add( new MethodInfo( )
            {
                ClassName = this.Value.Name,
                Returns = "",
                AccessModifiers = AccessModifiers.Internal,
                Arguments = { "BinaryReader binaryReader" },
            } );
            StringBuilder stringBuilder = new StringBuilder( );
            foreach( var item in this.Fields )
            {
                if( item.IsArray )
                {
                    // fixed byte array like padding or skip arrays
                    if( item.ArraySize > 0 && Type.GetType( item.FieldTypeName ) == typeof( byte ) )
                    {
                        stringBuilder.AppendLine( string.Format( "this.{0} = binaryReader.ReadBytes({1});", item.Value.Name, item.ArraySize ) );
                    }
                    // variable byte array (data)
                    else if( Type.GetType( item.FieldTypeName ) == typeof( byte ) )
                    {
                        stringBuilder.AppendLine( string.Format( "this.{0} = ReadData(binaryReader);", item.Value.Name, item.ArraySize ) );
                    }
                    // assume an TagBlock
                    else
                    {
                        var methodInfo = this.MethodsTemplates.Where( x => x.ClassName == "Read{0}Array" ).First( );
                        stringBuilder.AppendLine( string.Format( "this.{0} = {1};",
                            item.Value.Name, methodInfo.GetMethodCallSignatureFormat( item.FieldTypeName, "binaryReader" ) ) );
                        var method = methodInfo.MakeFromTemplate( item.FieldTypeName );
                        if( !this.Methods.Where( x => x.ClassName == method.ClassName
                            && x.Arguments == method.Arguments
                            && x.Returns == method.Returns ).Any( ) )
                            this.Methods.Add( method );
                    }
                }
                else
                {
                    if( EnumDefinitions.Where( x => x.Value.Name == item.FieldTypeName ).Any( ) )
                    {
                        var enumDefinition = EnumDefinitions.Where( x => x.Value.Name == item.FieldTypeName ).First( );
                        string type = enumDefinition.BaseType == EnumInfo.Type.Byte ? "Byte"
                            : enumDefinition.BaseType == EnumInfo.Type.Short ? "Int16" : "Int32";
                        stringBuilder.AppendLine( string.Format( "this.{0} = ({1})binaryReader.Read{2}();", item.Value.Name, item.FieldTypeName, type ) );
                    }
                    else if( Type.GetType( item.FieldTypeName ) == null )
                    {
                        stringBuilder.AppendLine( string.Format( "this.{0} = new {1}(binaryReader);", item.Value.Name, item.FieldTypeName ) );
                    }
                    else
                    {

                        var value = GuerillaCs.GetBinaryReaderMethodName( Type.GetType( item.FieldTypeName ) );
                        stringBuilder.AppendLine( string.Format( "this.{0} = binaryReader.{1}();", item.Value.Name, value ) );
                    }
                }
            }
            Constructors.Last( ).Body = stringBuilder.ToString( ).TrimEnd( );
        }

        public override string ToString( )
        {
            return string.Format( "{0}:{1}", "Class",
                String.IsNullOrEmpty( Namespace ) ? Value.Name : string.Format( "{0}.{1}", Namespace, Value.Name ) );
        }
    }

    public static class AccessModifiersExtensions
    {
        public static string ToString( this AccessModifiers items )
        {
            if( !Enum.IsDefined( typeof( AccessModifiers ), items ) ) return "";
            var value = new StringBuilder( );
            var values = items.ToString( ).Split( ',' ).ToList( );
            values.TakeWhile( x => x != values.Last( ) ).ToList( ).ForEach( x => value.Append( string.Format( "{0} ", x.ToLower( ) ) ) );
            value.Append( string.Format( "{0}", values.LastOrDefault( ) == null ? "" : values.Last( ).ToLower( ) ) );

            return value.ToString( ).Trim( );
        }
    }

    public class GuerillaName
    {
        public string Name
        {
            get { return GuerillaCs.SplitNameDescription( this.Value )[0]; }
            set
            {
                if( HasName )
                    this.Value = this.Value.Replace( GuerillaCs.SplitNameDescription( this.Value )[0], value );
                else
                    this.Value = this.Value.Insert( 0, value );
            }
        }
        public string Description
        {
            get { return GuerillaCs.SplitNameDescription( this.Value )[1]; }
            set
            {
                if( HasDescription )
                    this.Value = this.Value.Replace( GuerillaCs.SplitNameDescription( this.Value )[1], value );
                else
                    this.Value = this.Value.Insert( this.Name.Length, "#" + value );
            }
        }

        public bool HasName { get { return !string.IsNullOrEmpty( this.Name ); } }

        public bool HasDescription { get { return !string.IsNullOrEmpty( this.Description ); } }

        string Value;

        public GuerillaName( string value )
        {
            this.Value = value;
        }

        public static implicit operator GuerillaName( string value )
        {
            return new GuerillaName( value );
        }

        public static implicit operator string( GuerillaName guerillaName )
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

        public EnumInfo( )
        {
            Attributes = new List<AttributeInfo>( );
            ValueNames = new List<GuerillaName>( );
        }

        public override string ToString( )
        {
            var stringBuilder = new StringBuilder
                (
                string.Format( "{0} enum {1} : {2}", AccessModifiersExtensions.ToString( AccessModifiers ), Value.Name, BaseType.ToString( ).ToLowerInvariant( ) ).Trim( )
                );
            stringBuilder.AppendLine( );
            stringBuilder.AppendLine( "{" );

            var isFlags = Attributes.Any( x => x.AttributeType == typeof( FlagsAttribute ) );
            var value = isFlags ? 1 : 0;
            foreach( var item in ValueNames )
            {
                if( item.HasDescription ) stringBuilder.AppendSummary( item.Description );
                stringBuilder.AppendLine( string.Format( "{0} = {1},", GuerillaCs.ToTypeName( item.Name ), value ) );
                value = isFlags ? value << 1 : value++;
            }
            stringBuilder.AppendLine( "};" );
            return stringBuilder.ToString( ).Trim( );
        }
    }

    public class AttributeInfo
    {
        public AttributeInfo( Type attributeType, params object[] namedParameters )
        {
            var count = namedParameters.Length % 2 == 0 ?
                namedParameters.Length / 2 : ( namedParameters.Length - 1 ) / 2;
            this.NamedParameters = new List<Tuple<string, string>>( count );
            this.Parameters = new List<string>( count );
            for( int i = 0; i < count; i += 2 )
            {
                if( namedParameters[i] == null )
                    Parameters.Add( namedParameters[i + 1].ToString( ) );
                else
                    NamedParameters.Add( new Tuple<string, string>( namedParameters[i].ToString( ), namedParameters[i + 1].ToString( ) ) );
            }
            this.AttributeType = attributeType;
        }

        public Type AttributeType { get; set; }
        public List<Tuple<string, string>> NamedParameters { get; set; }
        public List<string> Parameters { get; set; }

        public override string ToString( )
        {
            using( var code = new Microsoft.CSharp.CSharpCodeProvider( ) )
            {
                var hasParameters = NamedParameters.Count > 0 || Parameters.Count > 0;
                var parametersString = new StringBuilder( );
                if( hasParameters && Parameters.Count > 0 )
                {
                    Parameters.TakeWhile( x => Parameters.Last( ) != x ).ToList( ).ForEach( x => parametersString.Append( string.Format( "{0}, ", x ) ) );
                    parametersString.Append( Parameters.Last( ) );
                }
                if( hasParameters && NamedParameters.Count > 0 )
                {
                    NamedParameters.TakeWhile( x => NamedParameters.Last( ) != x ).ToList( ).ForEach( x => parametersString.Append( string.Format( "{0}, ", x ) ) );
                    parametersString.Append( NamedParameters.Last( ) );
                }

                return string.Format( "[{0}{1}]", AttributeType.Name,
                    hasParameters ? string.Format( "({0})", parametersString ) : "" );
            }
        }
    }

    public class FieldInfo
    {
        public FieldInfo( )
        {
            Attributes = new List<AttributeInfo>( );
        }
        public List<AttributeInfo> Attributes { get; set; }
        public AccessModifiers AccessModifiers { get; set; }
        public string FieldTypeName { get; set; }
        public GuerillaName Value { get; set; }
        public bool IsArray { get; set; }
        public int ArraySize { get; set; }

        public override string ToString( )
        {
            StringBuilder stringBuilder = new StringBuilder( );
            // write Summary
            if( Value.HasDescription ) stringBuilder.AppendSummary( Value.Description );
            // write Attributes
            foreach( var attribute in Attributes )
                stringBuilder.AppendLine( attribute.ToString( ) );

            var typeString = GetTypeOutput( );

            // write Field
            stringBuilder.AppendLine( string.Format( "{0}{1} {2};",
                typeString, IsArray ? "[]" : "", this.Value.Name ) );

            return stringBuilder.ToString( ).Trim( );
        }

        private string GetTypeOutput( )
        {
            var type = Type.GetType( FieldTypeName );
            if( type != null )
            {
                using( var code = new Microsoft.CSharp.CSharpCodeProvider( ) )
                {
                    return code.GetTypeOutput( new System.CodeDom.CodeTypeReference( type.FullName ) );
                }
            }
            else return FieldTypeName;
        }
    }

    public class MethodInfo
    {
        public MethodInfo( )
        {
            Arguments = new List<string>( );
        }
        public AccessModifiers AccessModifiers { get; set; }
        public string ClassName { get; set; }
        public List<string> Arguments { get; set; }
        public string Body { get; set; }
        public string Returns { get; set; }

        public string GetMethodCallSignature( params string[] arguments )
        {
            return GetMethodCallSignatureFormat( "", arguments );
        }

        public string GetMethodSignature( )
        {
            return GetMethodSignatureFormat( "" );
        }

        public string GetMethodSignatureFormat( string methodName )
        {
            return GetMethodCallSignatureFormat( methodName, this.Arguments.ToArray( ) );
        }

        public string GetMethodCallSignatureFormat( string methodName, params string[] arguments )
        {

            var argumentStringBuilder = new StringBuilder( );
            if( arguments.Any( ) )
            {
                arguments.TakeWhile( x => x != arguments.Last( ) ).ToList( ).ForEach( x => argumentStringBuilder.AppendFormat( "{0}, ", x ) );
                argumentStringBuilder.Append( arguments.Last( ) );
            }
            return string.Format( "{0}{1}", String.Format( ClassName, methodName ), string.Format( "({0})", arguments.Any( ) ? argumentStringBuilder.ToString( ) : "" ) );
        }

        public MethodInfo MakeFromTemplate( params string[] args )
        {
            return new MethodInfo( )
            {
                Arguments = this.Arguments,
                AccessModifiers = this.AccessModifiers,
                ClassName = string.Format( this.ClassName, args ),
                Body = string.Format( this.Body, args ),
                Returns = string.Format( this.Returns, args ),
            };
        }

        public override string ToString( )
        {
            StringBuilder methodStringBuilder = new StringBuilder( );
            var modifiersString = AccessModifiersExtensions.ToString( AccessModifiers );
            methodStringBuilder.AppendFormat( "{0} {1} {2}", modifiersString, Returns, GetMethodSignature( ) );
            methodStringBuilder.AppendLine( );
            methodStringBuilder.AppendLine( "{" );
            methodStringBuilder.Append( this.Body );
            methodStringBuilder.AppendLine( );
            methodStringBuilder.AppendLine( "}" );
            return methodStringBuilder.ToString( ).Trim( );
        }
    }
}
