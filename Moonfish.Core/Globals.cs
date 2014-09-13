using Moonfish.Tags;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Moonfish
{
    /// <summary>
    /// This static class holds all globals for Halo 2 and useful methods
    /// </summary>
    public static class Halo2
    {
        public const int NullPtr = 0;

        /// <summary>
        /// A list of each tag_type used in halo 2's retail maps
        /// </summary>
        public static TagGroupLookup Classes
        {
            get { return tagGroups; }
        }
        /// <summary>
        /// A list of all standard strings in Halo 2
        /// </summary>
        public static GlobalStrings Strings
        {
            get { return strings; }
        }

        public static GlobalPaths Paths { get; set; }

        public static dynamic GetReferenceObject(TagReference reference)
        {
            if (mapStream == null) return null;

            return mapStream[reference.TagID].Deserialize();
        }

        static MapStream mapStream;
        static TagGroupLookup tagGroups = new TagGroupLookup();
        static GlobalStrings strings = new GlobalStrings();
        static Dictionary<TagClass, Type> definedTagGroupsDictionary;

        static Halo2()
        {
            Paths = new GlobalPaths();
            definedTagGroupsDictionary = new Dictionary<TagClass, Type>(3);
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                //if (!type.IsNested)
                {
                    if (type.IsDefined(typeof(Tags.TagClassAttribute), false))
                    {
                        TagClass class_of_tag = (type.GetCustomAttributes(typeof(Tags.TagClassAttribute), false)[0] as Tags.TagClassAttribute).TagClass;
                        definedTagGroupsDictionary.Add(class_of_tag, type);
                    }
                }
            }
        }

        public static Type GetTypeOf(TagClass className)
        {
            return definedTagGroupsDictionary[className];
        }

        public static TagBlock CreateInstance(TagClass className)
        {
            Type tagblock_type = definedTagGroupsDictionary[className];
            return Activator.CreateInstance(tagblock_type) as TagBlock;
        }

        internal static void ActiveMap(MapStream mapstream)
        {
            mapStream = mapstream;
        }
    }

    public static class Log
    {
        public delegate void LogMessageHandler(string message);
        public static LogMessageHandler OnLog;

        internal static void Error(string message)
        {
            LogMessage("Error", message);
        }

        internal static void Warn(string message)
        {
            LogMessage("Warning", message);
        }

        static void LogMessage(string token, string message)
        {
            if (OnLog != null)
                OnLog(string.Format("{0}: {1}", token, message));
        }

        internal static void Info(string message)
        {
            LogMessage("Info", message);
        }
    }

    public static class StaticBenchmark
    {
        static Stopwatch Timer = new Stopwatch();
        static string result;

        public static void Begin()
        {
            Timer.Start();
        }
        public static void End()
        {
            Timer.Stop();
            result = Timer.ElapsedMilliseconds.ToString() + " Milliseconds";
            Timer.Reset();
        }
        public static string Result { get { return result; } }

        public static new string ToString()
        {
            return Result;
        }
    }

    public class TagGroupLookup : IEnumerable, IEnumerable<string>
    {
        public string this[int index]
        {
            get { return classes[index]; }
        }

        static readonly List<string> classes = new List<string>() {
                                    #region Class Strings
"$#!+",
"*cen","*eap","*ehi","*igh","*ipd","*qip","*rea","*sce",
"/**/",
"<fx>",
"BooM",
"DECP","DECR",
"MGS2",
"PRTM",
"adlg",
"ai**","ant!",
"bipd","bitm","bloc","bsdt",
"char","cin*","clu*","clwd","coll","coln","colo","cont","crea","ctrl",
"dc*s","dec*","deca","devi","devo","dgr*","dobc",
"effe","egor","eqip",
"fog ","foot","fpch",
"garb","gldf","goof","grhi",
"hlmt","hmt ","hsc*","hud#","hudg",
"item","itmc",
"jmad","jpt!",
"lens","lifi","ligh","lsnd","ltmp",
"mach","matg","mdlg","metr","mode","mpdt","mply","mulg",
"nhdt",
"obje",
"phmo","phys","pmov","pphy","proj","prt3",
"sbsp","scen","scnr","sfx+","shad","sily","skin","sky ","slit","sncl","snd!","snde","snmx","spas","spk!","ssce","sslt","stem","styl",
"tdtl","trak","trg*",
"udlg","ugh!","unhi","unic","unit",
"vehc","vehi","vrtx",
"weap","weat","wgit","wgtz","whip","wigl","wind","wphi",
#endregion
                                  };

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return classes.GetEnumerator();
        }

        #endregion

        #region IEnumerable<string> Members

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return classes.GetEnumerator();
        }

        #endregion
    }
}