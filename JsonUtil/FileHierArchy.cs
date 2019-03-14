using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUtil
{
    public class FileHierArchy
    {
        public string Namespace { get; set; }

        public List<Class> Classes {get;set;}
    }

    public class Class
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public List<ClassProperty> Properties { get; set; }
    }

    public class ClassProperty
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public string DataType { get; set; }
    }
}
