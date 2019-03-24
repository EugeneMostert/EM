using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUtil
{
    class ClassConstructor
    {
        public ClassConstructor(string nameSpace, string intialClassName, Dictionary<string, object> jObject)
        {
            this.NameSpace = nameSpace;
            this.IntialClassName = intialClassName;
            this.JObject = jObject;
            Initialize();
        }

        private void Initialize()
        {
            NewClass = new StringBuilder();
            AddHeaderOrFooter(true);
            ConstructClass();
            AddHeaderOrFooter(false);
            ClassAsString = NewClass.ToString();
            BaseClasses = new List<Class>();

        }

        public string NameSpace { get; private set; }
        public string IntialClassName { get; set; }
        public Dictionary<string, object> JObject { get; set; }
        public StringBuilder NewClass { get; set; }
        public string ClassAsString { get; set; }
        public FileHierArchy FileHierarchy { get; set; }
        public List<Class> BaseClasses { get; set; }

        private void AddHeaderOrFooter(bool header)
        {
            if (header)
            {
                NewClass.Append("using System;");
                NewClass.Append("\n");
                NewClass.Append("\nnamespace Test");
                NewClass.Append("\n{");
            }
            else
            {
                NewClass.Append("\n}");
            }
        }



        public FileHierArchy ConstructClass()
        {
            var dic = new Dictionary<string, object>();
            var props = new Dictionary<string, string>();

            FileHierarchy = new FileHierArchy();
            FileHierarchy.Namespace = NameSpace;
            FileHierarchy.Classes = new List<Class>();
            
            RecursiveClasses(IntialClassName, JObject);

            return FileHierarchy;
        }

        private void RecursiveClasses(string className, Dictionary<string, object> obdic)
        {
            FileHierarchy.Classes.Add(new Class(className, AccessModifier.Public));

            var cItem = FileHierarchy.Classes.Find(c => c.Name == className.StripChars());
            cItem.Properties = new List<ClassProperty>();
            var obType = obdic.GetType();
;
            foreach (var pair in obdic)
            {
                //TODO check isclass parameter
                cItem.Properties.Add(new ClassProperty(pair.Key, AccessModifier.Public, pair.Key, false));

                var vType = pair.Value.GetType();

                bool isdictionary = vType.IsGenericType && vType.GetGenericTypeDefinition() == typeof(Dictionary<,>);
                if (isdictionary)
                {
                    if(IsDictionaries(pair.Value))
                    {
                        var t = pair.Value.GetType();
                        var keyType = t.GetGenericArguments()[0];
                        var valueType = t.GetGenericArguments()[1];


                        RecursiveClasses(pair.Key, pair.Value as Dictionary<string, object>);
                    }
                    //else if(IsDictionaries1(pair.Value))
                    //{
                    //    { }
                    //}
                    //else
                    //{
                    //    { }
                    //}
                    
                }
                //else
                //{
                //    { }
                //    //var test = TestForDuplicates(cItem);
                //    //BaseClasses.Add(cItem);
                //}
            }
        }

        private bool TestForDuplicates(Class @class)
        {
            var result = FileHierarchy.Classes.Find(x => x.Properties.Equals(@class.Properties));
            if (result != null)
                return true;
            return false;
        }

        private bool IsDictionaries(object o)
        {
            var type = o.GetType();
            bool isdictionary = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
            if (!isdictionary)
            {
                return false;                
            }

            return true;
        }

        private bool IsDictionaries1(object o)
        {
            var type = o.GetType();
            bool isdictionary = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<string, string>);
            if (!isdictionary)
            {
                return false;
            }

            return true;
        }

        private void ClassComparer()
        {

        }
    }
}
