using EM.Services.AlphaVantage.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AlphaVantage
{
    //public class RestService
    //{
    //    readonly string baseUri = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=MSFT&interval=5min&apikey=demo";
    //        //"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=BA&apikey=demo";

    //    public async Task<MetaData> GetSharePricesAsync()
    //    {
    //        using (var httpClient = new HttpClient())
    //        {
             
    //            var json = await httpClient.GetStringAsync(baseUri);
    //            var test = JsonConvert.DeserializeObject<MetaData>(json);
    //            return test;
    //        }
    //    }

   // }
}
