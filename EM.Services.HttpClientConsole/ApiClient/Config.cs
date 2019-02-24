using EM.Contracts.Interfaces.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Services.HttpClientConsole.ApiClient
{
    public class Config : IConfig
    {
        public Config()
        {

        }
        public string Key { get; set; }
        public string Secret { get; set; }
        public string ID { get ; set; }
        public string BaseUrl { get; set; }
        public string Schema { get; set; }
        public int Port { get; set; }
        public string Path { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}
