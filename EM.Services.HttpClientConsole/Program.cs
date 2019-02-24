using EM.Services.AlphaVantage.Entities;
using EM.Services.AlphaVantage.Entities.ApiQueries;
using EM.Services.HttpClientConsole.ApiClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Services.HttpClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Task t = new Task(GetData);
            t.Start();

            Console.WriteLine();
            Console.Read();
        }

        private static async void GetData()
        {
            //var queries = new Dictionary<string, object>
            //{
            //    { "function","TIME_SERIES_INTRADAY" },
            //    { "symbol","MSFT" },
            //    { "interval", "5min" },
            //    { "apikey", ConfigurationManager.AppSettings["apikey"] }
            //};

            var stockTimeSeries = new StockTimeSeriesDictionary(new StockTimeSeriesModel
            {
                Function = TimeSeries.TIME_SERIES_INTRADAY,
                Symbol = "MSFT",
                Interval = Interval.fifteen,
                ApiKey = ConfigurationManager.AppSettings["apikey"]
            });

            var config = new Config
            {
                BaseUrl = "www.alphavantage.co",
                Schema = "https",
                Path = "query",
                Parameters = stockTimeSeries
            };

            var client = new Client(config);

            var result = await client.GetDataAsync<MetaData>(false);
            
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
            Console.Read();
        }
    }
}
