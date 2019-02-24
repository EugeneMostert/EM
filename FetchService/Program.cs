using EM.Services.AlphaVantage.Entities;
using EM.Services.AlphaVantage.Entities.ApiQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EM.Services.FetchService
{
    class Program
    {
        static void Main(string[] args)
        {
            //var alphaClient = new AlphaVantage.RestService();
            //Task<MetaData> task = Task.Run(() => alphaClient.GetSharePricesAsync());
            //task.Wait();
            //var result = task.Result;
            //var result = Query.
            //var result = Query.


            //Console.WriteLine(result);
            Console.Read();
        }

        //private static Dictionary<string, string> Queries()
        //{
        //    var queries = new Dictionary<string, string>
        //    {
        //        { "function","TIME_SERIES_INTRADAY" },
        //        { "symbol","MSFT" },
        //        { "interval", "5min" },
        //        {"apikey","demo" }
        //    };
        //    return queries;

        //}

        private static StockTimeSeriesModel Query
        {
            get
            {
                return new StockTimeSeriesModel
                {
                    Interval = Interval.fifteen,
                    ApiKey = "demo"
                };
            }
        }

        public static string ResultQuery1(StockTimeSeriesModel query)
        {
            StringBuilder sb = new StringBuilder();
            //Type type = typeof(T);
            //var prop1 = type.GetProperty()
            


            sb.Append("?");
            sb.Append($"{nameof(query.Function).ToLower()}={query.Function}");
            sb.Append($"&{nameof(query.Symbol).ToLower()}={query.Symbol}");
            sb.Append($"&{nameof(query.Interval).ToLower()}={query.Interval}");
            sb.Append($"&{nameof(query.ApiKey).ToLower()}={query.ApiKey}");
            //query.Function.GetType().GetProperty().Name;
            //query.Function
            return sb.ToString();
        }

        public static string ResultQueries(Dictionary<string, string> queries)
        {
            StringBuilder query = new StringBuilder();
            query.Append("?");
            queries.TryGetValue("function", out string fvalue);
            query.Append($"function={fvalue}");

            queries.TryGetValue("symbol", out string svalue);
            query.Append($"&symbol={svalue}");

            queries.TryGetValue("interval", out string ivalue);
            query.Append($"&interval={ivalue}");

            queries.TryGetValue("apikey", out string avalue);
            query.Append($"&apikey={avalue}");


            return query.ToString();

        }
    }

    public static class Extensions
    {
        public static string ToQueryString<T>(this Type t)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var sb = new StringBuilder();
            Type type = typeof(T);

            for (int i = 0; i < properties.Length; i++)
            {
                var test = properties[i];
                var value = properties[i].GetValue(t, null);
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
