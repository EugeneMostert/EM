using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EM.Services.AlphaVantage.Entities.ApiQueries
{
    /// <summary>
    ///  //var queries = new Dictionary<string, object>
    //{
    //    { "function","TIME_SERIES_INTRADAY" },
    //    { "symbol","MSFT" },
    //    { "interval", "5min" },
    //    { "apikey", ConfigurationManager.AppSettings["apikey"] }
    //};

    public class StockTimeSeriesModel
    {
        public TimeSeries Function { get; set; }
        public string Symbol { get; set; }
        public Interval Interval { get; set; }
        public OutputSize OutputSize { get; set; }
        public DataType DataType { get; set; }
        public string ApiKey { get; set; }
    }

    //var stockTimeSeries = new StockTimeSeriesDictionary(new StockTimeSeries
    //{
    //      Function = TimeSeries.TIME_SERIES_INTRADAY,
    //      Symbol = "MSFT",
    //      Interval = "5min",
    //      ApiKey = ConfigurationManager.AppSettings["apikey"]
    //});
    /// </summary>
    public class StockTimeSeriesDictionary : Dictionary<string, object>
    {
        public StockTimeSeriesDictionary(StockTimeSeriesModel stockTimeSeries)
        {
            this.Add(nameof(stockTimeSeries.Function).ToLower(), stockTimeSeries.Function.ToString());
            this.Add(nameof(stockTimeSeries.Symbol).ToLower(), string.IsNullOrEmpty(stockTimeSeries.Symbol) ? "" : stockTimeSeries.Symbol);
            this.Add(nameof(stockTimeSeries.Interval).ToLower(), stockTimeSeries.Interval.DescriptionAttr());
            this.Add(nameof(stockTimeSeries.OutputSize).ToLower(), stockTimeSeries.OutputSize);
            this.Add(nameof(stockTimeSeries.DataType).ToLower(), stockTimeSeries.DataType.ToString());
            this.Add(nameof(stockTimeSeries.ApiKey).ToLower(), string.IsNullOrEmpty(stockTimeSeries.ApiKey) ? "" : stockTimeSeries.ApiKey.ToString());
        }
    }

    public enum Interval
    {
        [Description("1min")] one,
        [Description("5min")] five,
        [Description("15min")] fifteen,
        [Description("30min")] thrity,
        [Description("60min")] sixty,
    }

    public enum OutputSize
    {
        compact,
        full
    }

    public enum TimeSeries
    {
        TIME_SERIES_INTRADAY,
        TIME_SERIES_DAILY,
        TIME_SERIES_DAILY_ADJUSTED,
        TIME_SERIES_WEEKLY,
        TIME_SERIES_WEEKLY_ADJUSTED,
        TIME_SERIES_MONTHLY,
        TIME_SERIES_MONTHLY_ADJUSTED,
        GLOBAL_QUOTE,
    }

    public enum DataType
    {
        json,
        csv
    }

    public static class Extensions
    {
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
