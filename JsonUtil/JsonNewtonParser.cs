using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUtil
{
    class JsonNewtonParser
    {
        public JsonNewtonParser(dynamic json)
        {
            this.Json = json;
            Recurse(json);
        }

        public dynamic Json { get; set; }

        private void Recurse(dynamic json)
        {
            foreach(var pair in json)
            {
                var t = pair.GetType();
                Recurse(pair);
            }
        }
    }
}
