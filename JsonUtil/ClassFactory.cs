using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUtil
{
    abstract class Factory
    {
        public Factory(bool addAttritbute, AttributeType attributeType, string attributeValue, AccessModifier accessModifier)
        {
            this.AddAttritbute = addAttritbute;
            this.AttributeValue = attributeValue;
            this.AccessModifier = accessModifier;
            this.AttributeType = attributeType;

            FactoryString = new StringBuilder();
        }

        public AccessModifier AccessModifier { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }
        public bool AddAttritbute { get; set; }
        public AttributeType AttributeType { get; set; }
        public string AttributeValue { get; set; }

        public StringBuilder FactoryString { get; set; }

        public abstract string Result(string dataType, string name);

    }


    class ClassFactory : Factory
    {
        public ClassFactory(bool addAttritbute, AttributeType attributeType, string attributeValue, AccessModifier accessModifier, Class @class)
            : base(addAttritbute, attributeType, attributeValue, accessModifier)
        {
            this.Class = @class;
        }

        public void Initialize()
        {
            var properties = new StringBuilder();
            foreach(var prop in Class.Properties)
            {
                var propertyFactory = new PropertyFactory(AddAttritbute, AttributeType, prop.Name, prop.AccessModifier);
                var result = propertyFactory.Result(prop.DataType, prop.Name);
                properties.Append(result);
            }

            Properties = properties.ToString();
        }

        public string Properties { get; set; }

        public Class Class { get; set; }

        public override string Result(string dataType, string name)
        {
            if (AddAttritbute)
            {
                FactoryString.Append("\n"+AttributeFactory.AddAttribute(AttributeType.ToString(), AttributeValue));
            }

            FactoryString.Append($"\n\t{AccessModifier.GetDescription()} class {name}");
            FactoryString.Append("\n\t{");
            FactoryString.Append($"{Properties}");
            FactoryString.Append("\n\t}");
            return FactoryString.ToString();
        }
    }

    class PropertyFactory : Factory
    {

        public PropertyFactory(bool addAttritbute, AttributeType attributeType, string attributeValue, AccessModifier accessModifier) 
            : base (addAttritbute, attributeType, attributeValue, accessModifier)
        {
           
        }

        public override string Result(string dataType, string propertyName)
        {
            if (AddAttritbute)
            {
                FactoryString.Append("\n\t\t"+AttributeFactory.AddAttribute(AttributeType.ToString(), AttributeValue));
            }

            FactoryString.Append($"\n\t\t{AccessModifier.GetDescription()} {dataType} {propertyName} {{ get; set; }}");
            return FactoryString.ToString();
        }
    }

    //class PropertiesFactory
    //{
    //    public PropertiesFactory(ClassProperty properties)
    //    {
    //        this.Properties = properties;
    //    }
    //    public ClassProperty Properties { get; set; }

    //    public string Result()
    //    {
    //        var props = new StringBuilder();
    //        foreach(var prop in Properties.)
    //        {
    //            var property = new PropertyFactory(true, AttributeType.JsonProperty, prop.Key, AccessModifier.Public);
    //            var stripped = prop.Key.StripChars();
    //            props.Append(property.Result(stripped, prop.Value));
    //        }
    //        //Console.WriteLine(props.ToString());
    //        return props.ToString();
    //    }
    //}


}
