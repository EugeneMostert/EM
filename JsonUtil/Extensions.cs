using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JsonUtil
{
    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            var mem = value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description; ;

            return mem;
        }
        public static string StripChars(this string toStrip)
        {
            string result = string.Empty;
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            result = rgx.Replace(toStrip, "").Replace(" ", "");
            return result;
        }
    }
}
