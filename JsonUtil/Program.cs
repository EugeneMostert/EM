using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace JsonUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllText(@"c:\em\test2.json");
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(file);
            dynamic obj1 = JObject.Parse(file);
            var test = new JsonNewtonParser(obj1);
            var jscript = new JavaScriptSerializer();
            var jobject = jscript.DeserializeObject(file);
            ///NewClass = new StringBuilder();
            //AddHeaderOrFooter(true);
            var cc = new ClassConstructor("NewNameSpace","FirstClass", jobject as Dictionary<string, object>);
            var cClass = cc.ConstructClass();
            var writer = new NamespaceWriter(cClass, true);
            writer.WriteFile("refactor.cs");
            //var fileHierarchy = cc.ConstructClass();
            //var factory = new ClassFactory(true, AttributeType.JsonProperty,)

            //ConstructClass("FirstClass", jobject as Dictionary<string, object>);
            //AddHeaderOrFooter(false);
            //Console.WriteLine(cc.ClassAsString);
            //File.WriteAllText("NewTest.cs", cc.ClassAsString);
            //Console.WriteLine(jobject);
            Console.Read();

        }

        //private static void AddHeaderOrFooter(bool header)
        //{
        //    if(header)
        //    {
        //        NewClass.Append("using System;");
        //        NewClass.Append("\n");
        //        NewClass.Append("\nnamespace Test");
        //        NewClass.Append("\n{");
        //    }
        //    else
        //    {
        //        NewClass.Append("\n}");
        //    }
        //}

        //public static StringBuilder NewClass { get; set; }
        //public List<Dictionary<string,object>> Classes { get; set; }

        //public static void ConstructClass(string intialClass, Dictionary<string, object> obdic)
        //{
        //    var dic = new Dictionary<string, object>();
        //    var props = new Dictionary<string, string>();
            

        //    foreach (var pair in obdic)
        //    {
        //        var pType = pair.Value.GetType();
        //        var kType = pair.Key.GetType();

        //        bool isdictionary = pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        //        if (isdictionary)
        //        {
       
        //            var stripped = pair.Key.StripChars();
        //            props.Add(stripped, stripped);
        //            dic.Add(stripped, pair.Value);
        //        }
        //        else
        //        {
        //            props.Add(pair.Key, pType.Name.ToLower());
        //        }

        //    }

        //    AddClassToFile(intialClass, props);

        //    foreach(var pair in dic)
        //    {
        //        var _className = pair.Key.StripChars();
        //        var _props = pair.Value as Dictionary<string, object>;
        //        ConstructClass(_className, _props);
        //    }
        //}

        

        //public static void AddClassToFile(string className, Dictionary<string, string> parameters)
        //{
        //    var props = new PropertiesFactory(parameters);
        //    var classFactory = new ClassFactory(false, AttributeType.None, "", AccessModifier.Public, props.Properties());
        //    NewClass.Append("\n"+classFactory.Result("", className));
        //}

        

        public static bool ParseType<T>(object o)
        {
            var type = o.GetType();

            bool isdictionary = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(T);
            if (isdictionary)
            {
                return true;

            }
            return false;
        }
        public static Type ParseType(object o)
        {
            var type = o.GetType();

            foreach(Type t in Types())
            {
                bool isType = type.IsGenericType && type.GetGenericTypeDefinition() == t;
                if (isType)
                    return t;
            }
            return type;
            //bool isdictionary = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(T);
            //if (isdictionary)
            //{
            //    return true;

            //}
            //return false;
        }

        public static List<Type> Types()
        {
            var list = new List<Type>()
            {
                typeof(int),
                typeof(string),
                typeof(Dictionary<,>),
                typeof(DateTime)
            };

            return list;
        }
    }
}
