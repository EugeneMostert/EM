using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUtil
{
    class JsonNewtonParser
    {
        public JsonNewtonParser(JToken json)
        {
            this.Json = json;
            Recurse(json);
        }

        public JToken Json { get; set; }

        private void Recurse(JToken json)
        {
            var test = json.Type;
            foreach(var pair in json)
            {

                //var test = 
                var t = pair.GetType();
                Recurse(pair);
            }
        }
    }
}
