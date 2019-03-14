using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUtil
{
   
    public class AttributeFactory
    {
        public static string AddAttribute(string type, string value)
        {
            return $"[{type}(\"{value}\")]";
        }
    }

    public enum AttributeType
    {
        Description,
        JsonProperty,
        None
    }

    public enum AccessModifier
    {
        [Description("public")]
        Public,
        [Description("private")]
        Private,
        [Description("internal")]
        Internal,
        [Description("protected")]
        Protected,
        [Description("")]
        Default
    }
}
