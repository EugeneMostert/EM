using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Services.AlphaVantage.Entities.ApiQueries
{
    public class SearchEndPointModel
    {
        public string Function => "SYMBOL_SEARCH";
        public string Keyword { get; set; }
        public string DataType { get; set; }
        public string ApiKey { get; set; }
    }

    public class SearchEndPointDictionary : Dictionary<string, object>
    {
        public SearchEndPointDictionary(SearchEndPointModel model)
        {
            this.Add(nameof(model.Function).ToLower(), model.Function.ToString());
            this.Add(nameof(model.Keyword).ToLower(), string.IsNullOrEmpty(model.Keyword) ? "" : model.Keyword.ToLower());
            this.Add(nameof(model.DataType).ToLower(), string.IsNullOrEmpty(model.DataType) ? "" : model.DataType.ToLower());
            this.Add(nameof(model.ApiKey).ToLower(), model.ApiKey.ToString());
        }
    }
}
