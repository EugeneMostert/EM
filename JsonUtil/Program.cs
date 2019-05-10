using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = @"Examples\Example1.JSON";
            var example1 = @"c:\em\test2.json";
            
            


            var files = new List<string>
            {
                //example,
                example1
            };

            foreach(var file in files)
            {
                var text = File.ReadAllText(file);
                //var jobject = Newtonsoft.Json.JsonConvert.DeserializeObject(File.ReadAllText(file));
                
                //Read(text);
                //WriteLines(file);
                var json = JToken.Parse(text);
                var fieldsCollector = new JsonFieldsCollector1(json, AccessModifier.Public);
                var fields = fieldsCollector.GetAllFields();
                foreach (var field in fields)
                    Console.WriteLine($"{field.Key}: '{field.Value}'");
            }
            

            //var obj1 = JToken.Parse(file);
            //var test = new JsonNewtonParser(obj1);

            //var json = JToken.Parse(file);
            //var fieldsCollector = new JsonFieldsCollector(json);
            //var fields = fieldsCollector.GetAllFields();


            //foreach (var field in fields)
            //    Console.WriteLine($"{field.Key}: '{field.Value}'");
            //var jscript = new JavaScriptSerializer();
            //var jobject = jscript.DeserializeObject(file);
            ///NewClass = new StringBuilder();
            //AddHeaderOrFooter(true);
            //var cc = new ClassConstructor("NewNameSpace","FirstClass", jobject as Dictionary<string, object>);
            //var cClass = cc.ConstructClass();
            //var writer = new NamespaceWriter(cClass, true);
            //writer.WriteFile("refactor.cs");
            //var fileHierarchy = cc.ConstructClass();
            //var factory = new ClassFactory(true, AttributeType.JsonProperty,)

            //ConstructClass("FirstClass", jobject as Dictionary<string, object>);
            //AddHeaderOrFooter(false);
            //Console.WriteLine(cc.ClassAsString);
            //File.WriteAllText("NewTest.cs", cc.ClassAsString);
            //Console.WriteLine(jobject);
            Console.Read();

        }
        private static void UseJsonFieldsCollector()
        {
            var example = @"Examples\Example1.JSON";
            var example1 = @"c:\em\test2.json";

            var files = new List<string>
            {
                //example,
                example1
            };

            foreach (var file in files)
            {
                var text = File.ReadAllText(file);
                var json = JToken.Parse(text);
                var fieldsCollector = new JsonFieldsCollector(json, AccessModifier.Public);
                var fields = fieldsCollector.GetAllFields();
                foreach (var field in fields)
                    Console.WriteLine($"{field.Key}: '{field.Value}'");
            }
        }
        public static FileHierArchy Hierarchy { get; set; }
        private static void Read(string json)
        {
            Hierarchy = new FileHierArchy();
            Hierarchy.Classes = new List<Class>();
            bool isClass = false;
            bool isProperty = false;
            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    if(isClass)
                    {
                        Hierarchy.Classes.Add(new Class(reader.Value.ToString(), AccessModifier.Public));
                        isProperty = true;
                        isClass = false;
                    }
                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                }
                else
                {
                    Console.WriteLine("Token: {0}", reader.TokenType);
                    if(reader.TokenType == JsonToken.StartObject)
                    {
                        isClass = true;//Hierarchy.Classes.Add(new Class { Name = })
                    }
                }
            }
        }
        private static void WriteLines(string file)
        {
            var text = File.ReadAllText(file);
            var json = JToken.Parse(text);
            var fieldsCollector = new JsonFieldsCollector(json, AccessModifier.Public);
            var fields = fieldsCollector.GetAllFields();

            var fileName = Path.GetFileName(file);
            Console.WriteLine($"Filename: {fileName}");
            Console.WriteLine();
            foreach (var field in fields)
                Console.WriteLine($"{field.Key}: '{field.Value}'");

            Console.WriteLine();
        }

        private static void Parse(string JsonString)
        {
            List<string> listBuffer = new List<string>();
           
                //string JsonString = "{\"@odata.context\":\"/abcdxyz/v1/$metadata#Heat.Heat\",\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat\",\"@odata.type\":\"#Heat.v1_2_1.Heat\",\"Id\":\"Heat\",\"Name\":\"Heat\",\"HeatControl\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatControl/0\",\"MemberId\":\"0\",\"Name\":\"Server Heat Control\",\"HeatConsumedWatts\":228,\"HeatMetrics\":{\"IntervalInMin\":17162,\"MinConsumedWatts\":107,\"MaxConsumedWatts\":456,\"AverageConsumedWatts\":219},\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/Systems/12345678abcd\"},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/RackMount\"}]}],\"Voltages\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Voltages/0\",\"MemberId\":\"0\",\"Name\":\"BB +12.0V\",\"SensorNumber\":208,\"Status\":{\"State\":\"Enabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"ReadingVolts\":12.211999893188477,\"UpperThresholdNonCritical\":13.256999969482422,\"UpperThresholdCritical\":13.642000198364258,\"LowerThresholdNonCritical\":11.001999855041504,\"LowerThresholdCritical\":10.671999931335449,\"MinReadingRange\":-0.21799999475479126,\"MaxReadingRange\":13.807000160217285,\"PhysicalContext\":\"SystemBoard\",\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/Systems/12345678abcd\"},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/RackMount\"}]},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Voltages/1\",\"MemberId\":\"1\",\"Name\":\"BB +3.3V Vbat\",\"SensorNumber\":222,\"Status\":{\"State\":\"Enabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"ReadingVolts\":3.0355000495910645,\"LowerThresholdNonCritical\":2.4505000114440918,\"LowerThresholdCritical\":2.125499963760376,\"MinReadingRange\":0.0065000001341104507,\"MaxReadingRange\":3.3215000629425049,\"PhysicalContext\":\"SystemBoard\",\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/Systems/12345678abcd\"},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/RackMount\"}]}],\"HeatSupplies\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatSupplies/0\",\"MemberId\":\"0\",\"Name\":\"Heat Supply Bay\",\"Status\":{\"State\":\"Enabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"LineInputVoltage\":217,\"Model\":\"S-1100ADU00-201\",\"Manufacturer\":\"FLEXTRONICS\",\"FirmwareVersion\":\"01\",\"SerialNumber\":\"EXWD70200907\",\"PartNumber\":\"G84027-007\",\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat\"}],\"Redundancy\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Redundancy/0\"}]},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatSupplies/1\",\"MemberId\":\"1\",\"Name\":\"Heat Supply Bay\",\"Status\":{\"State\":\"Enabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"LineInputVoltage\":14,\"Model\":\"S-1100ADU00-201\",\"Manufacturer\":\"FLEXTRONICS\",\"FirmwareVersion\":\"01\",\"SerialNumber\":\"EXWD70200524\",\"PartNumber\":\"G84027-007\",\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat\"}],\"Redundancy\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Redundancy/0\"}]}],\"Redundancy\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Redundancy/0\",\"MemberId\":\"0\",\"Name\":\"Baseboard Heat Supply\",\"RedundancySet\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatSupplies/0\"},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatSupplies/1\"}],\"Mode\":\"N+m\",\"Status\":{\"State\":\"Disabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"MinNumNeeded\":1,\"MaxNumSupported\":2}]}";
                JObject parsed = JObject.Parse(JsonString);
                int i = 0;
                foreach (var pair in parsed)
                {
                    string output = string.Format("{0} : {1}", pair.Key, pair.Value);
                    //Console.WriteLine(output);
                    string[] delimiter = new string[] { "\r\n" };
                    string[] output_split = output.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var s in output_split)
                    {
                        listBuffer.Add(s);
                        Console.WriteLine(listBuffer[i++]);
                    }

                }
                Console.ReadLine();
            
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
