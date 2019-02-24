using EM.Portal.Models;
using EM.Services.AlphaVantage.Entities;
using EM.Services.AlphaVantage.Entities.ApiQueries;
using EM.Services.HttpClientConsole.ApiClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EM.Portal.Functions
{
    public class Master
    {
        public MetaData MetaResult { get; set; }
        public async Task<MetaData> GetDataAsync(ReportViewModel reportViewModel)
        {
            
            var stockTimeSeries = new StockTimeSeriesDictionary(reportViewModel.StockTimeSeries);
            //var stockTimeSeries = new StockTimeSeriesDictionary(new StockTimeSeriesModel
            //{
            //    Function = TimeSeries.TIME_SERIES_INTRADAY,
            //    Symbol = "MSFT",
            //    Interval = Interval.five,
            //    ApiKey = "3GKRGSLN9Y9CYXXF"
            //});

            //var config = new Config
            //{
            //    BaseUrl = "www.alphavantage.co",
            //    Schema = "https",
            //    Path = "query",
            //    Parameters = stockTimeSeries
            //};

            var client = new Client(reportViewModel._config);

            var result = await client.GetDataAsync<MetaData>(false);

            

            return result;
        }

        public MetaData GetDataAsync1()
        {
            
            var stockTimeSeries = new StockTimeSeriesDictionary(new StockTimeSeriesModel
            {
                Function = TimeSeries.TIME_SERIES_INTRADAY,
                Symbol = "MSFT",
                Interval = Interval.five,
                ApiKey = "3GKRGSLN9Y9CYXXF"
            });

            //var config = new Config
            //{
            //    BaseUrl = "www.alphavantage.co",
            //    Schema = "https",
            //    Path = "query",
            //    Parameters = stockTimeSeries
            //};

            var config = GetProvider();
            config.Parameters = stockTimeSeries;

            var client = new Client(config);
            
            var task = Task.Run<MetaData>(async() =>
            
                await client.GetDataAsync<MetaData>(false)
            );
            
            return task.GetAwaiter().GetResult();
        }

        public Config GetProvider()
        {
            var config = new Config();
            string sql = "select top 1 * from dbo.Provider";
            // using (var connection = new Connection())
            using (var conn = new SqlConnection(@"Data Source=.; Initial Catalog=EMDb; Integrated Security=True; Pooling=False; Connect Timeout=30"))
            {
                conn.Open();
                using (var reader = new SqlCommand(sql, conn).ExecuteReader())
                {
                    while (reader.Read())
                    {
                        config.BaseUrl = reader["BaseUrl"].ToString();
                        config.Schema = reader["Schema"].ToString();
                        config.Path = reader["Path"].ToString();
                    }
                    return config;
                }
            }

        }

        //public async Task<MetaData> GetDataAsync()
        //{
        //    MetaData data = await GetDataAsync();


        //}

    }
}