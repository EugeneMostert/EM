using EM.Contracts.Interfaces.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EM.Services.HttpClientConsole.ApiClient
{
    public class UrlFactory
    {
        private readonly IConfig config;

        public UrlFactory(IConfig config)
        {
            this.config = config;
        }

        public string ParamaterizedUrl()
        {
            var resultUrl = new StringBuilder();
            var uri = new UriBuilder();
            var paramaterized = UrlParametersA(config.Parameters);

            uri.Scheme = config.Schema;
            uri.Host = config.BaseUrl;
            if(uri.Port >= 0)
                uri.Port = config.Port;

            uri.Path = config.Path;
            uri.Query = UrlParametersA(config.Parameters);

            return uri.ToString(); ;
        }

        public string UrlParametersB(Dictionary<string, object> paramaters)
        {
            var sb = new StringBuilder();
            sb.Append("?");
            var count = paramaters.Count;
            foreach (var row in paramaters)
            {
                sb.Append(string.Join("=", row.Key, row.Value));
                sb.Append("&");
            }
            var result = sb.ToString().TrimEnd('&');
            return HttpUtility.HtmlEncode(result);
        }

        public string UrlParametersA(Dictionary<string, object> paramaters)
        {
            var url = new StringBuilder();
            var count = paramaters.Count;
   
            int i = 0;

            foreach (var row in paramaters)
            {
                if (i > 0)
                    url.Append("&");

                url.Append(string.Join("=", row.Key, row.Value));

                i++;
            }

            return HttpUtility.HtmlEncode(url.ToString());
        }

        /// <summary>
        /// Pass in class object to convert to paramaterized string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public string UrlParameters<T>(object t)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var sb = new StringBuilder();
            //Type type = typeof(T);

            for (int i = 0; i < properties.Length; i++)
            {
                var test = properties[i];
                var value = properties[i].GetValue((T)t, null);
                var name = properties[i].Name.ToLower();
                if (value != null)
                {
                    if (i == 0)
                        sb.Append("?");
                    else
                        sb.Append("&");
                    sb.Append($"{name}={value}");
                }
            }

            return HttpUtility.UrlEncode(sb.ToString());
        }
    }
}
