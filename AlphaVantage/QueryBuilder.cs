using AlphaVantage.Entities.ApiQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AlphaVantage
{
    public class QueryBuilder
    {
        private readonly string baseUri = "www.alphavantage.co";

        public QueryBuilder()
        {

        }
        //"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=MSFT&interval=5min&apikey=demo";
        public string ConstructQuery(Dictionary<string, string> queries)
        {
            UriBuilder uri = new UriBuilder();
            uri.Scheme = "https";
            uri.Host = baseUri;
            uri.Path = "query";
            uri.Query = query.ToQueryString<IntraDay>();


            return uri.ToString();
        }

        private Dictionary<string, string> Queries()
        {
            var queries = new Dictionary<string, string>
            {
                { "function","TIME_SERIES_INTRADAY" },
                { "symbol","MSFT" },
                { "interval", "5min" },
                {"apikey","demo" }
            };
            return queries;
        }

        public IntraDay query
        {
            get
            {
                return new IntraDay
                {
                    Interval = "5min",
                    ApiKey = "demo"
                };
            }
        }
    }

    public static class ConstructQueries
    {
        //public ConstructQueries(Dictionary<string, string> queries)
        //{
        //    Queries = queries;
        //}
        //public Dictionary<string,string> Queries { get; set; }
        
        public static string ToQueryString<T>(this object t)
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

        //public string
    }
}
