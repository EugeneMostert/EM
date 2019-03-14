using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUtil
{
    class NamespaceWriter
    {
        public NamespaceWriter(FileHierArchy fileHierArchy, bool addAttritbute)
        {
            this.FileHierarchy = fileHierArchy;
            this.AddAttritbute = addAttritbute;
            FileBuilder = new StringBuilder();
        }

        private StringBuilder FileBuilder { get; set; }
        private FileHierArchy FileHierarchy { get; set; }
        private bool AddAttritbute { get; set; }

        public void WriteFile(string filename)
        {
            FileBuilder.Append("using System;");
            FileBuilder.Append("\n");
            FileBuilder.Append("\nnamespace Test");
            FileBuilder.Append("\n{");

            foreach (var _class in FileHierarchy.Classes)
            {
                if (AddAttritbute)
                {
                    FileBuilder.Append("\n\t" + AttributeFactory.AddAttribute(AttributeType.JsonProperty.ToString(), _class.Description));
                }

                var properties = new StringBuilder();
                foreach(var prop in _class.Properties)
                {
                    if (AddAttritbute)
                    {
                        properties.Append("\n\t\t" + AttributeFactory.AddAttribute(AttributeType.JsonProperty.ToString(), prop.Description));
                    }

                    properties.Append($"\n\t\t{prop.AccessModifier.GetDescription()} {prop.DataType} {prop.Name} {{ get; set; }}");
                    
                }

         

                FileBuilder.Append($"\n\t{_class.AccessModifier.GetDescription()} class {_class.Name}");
                FileBuilder.Append("\n\t{");
                FileBuilder.Append($"{properties.ToString()}");
                FileBuilder.Append("\n\t}");
            }
            FileBuilder.Append("\n}");

            File.WriteAllText(filename, FileBuilder.ToString());
        }
    }
}
