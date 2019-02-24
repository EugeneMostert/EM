using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Contracts.Interfaces.Api
{
    public interface IConfig
    {
        string Key { get; set; }
        string Secret { get; set; }
        string ID { get; set; }
        string BaseUrl { get; set; }
        string Schema { get; set; }
        int Port { get; set; }
        string Path { get; set; }
        Dictionary<string, object> Parameters { get; set; }
    }
}
