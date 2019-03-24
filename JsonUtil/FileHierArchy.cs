using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUtil
{
    public class FileHierArchy
    {
        private List<Class> _classes;

        public string Namespace { get; set; }

        public List<Class> Classes
        {
            get => _classes == null? new List<Class>() : _classes;
            set => _classes = value;
        }
    }

    public class Class
    {
        public Class(string name, AccessModifier accessModifier)
        {
            Name = name;
            AccessModifier = accessModifier;
            Description = name.StripChars();
        }
        private List<ClassProperty> _properties;

        public string Name { get; private set; }
        public string Description { get; private set; }
        public AccessModifier AccessModifier { get; private set; }
        public List<ClassProperty> Properties
        {
            get
            {
                if (_properties == null)
                    _properties = new List<ClassProperty>();

                return _properties;
            }
            set
            {
                _properties = value;
            }
        }
    }

    public class ClassProperty
    {
        public ClassProperty(string name, AccessModifier accessModifier, string dataType, bool isClass)
        {
            Name = name;
            AccessModifier = accessModifier;
            IsClass = isClass;
            Description = name.StripChars();
            DataType = isClass ? name.StripChars() : dataType;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AccessModifier AccessModifier { get; set; }
        public bool IsClass { get; private set; }
        public string DataType { get; private set; }
    }
}
