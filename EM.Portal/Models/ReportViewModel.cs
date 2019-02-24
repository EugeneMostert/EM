using EM.Services.AlphaVantage.Entities;
using EM.Services.AlphaVantage.Entities.ApiQueries;
using EM.Services.HttpClientConsole.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EM.Portal.Models
{
    public class ReportViewModel
    {
        public StockTimeSeriesModel StockTimeSeries { get; set; }
        public Config _config { get; set; }
        public MetaData MetaData { get; set; }
    }
}