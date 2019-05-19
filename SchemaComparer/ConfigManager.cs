using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.SqlServer.Dac;

namespace SchemaComparer
{
    class ConfigManager
    {
        private readonly string CompareConfig = "CompareConfig.json";
        public string Config { get; set; }
        public ConfigManager()
        {

        }

        public T GetConfiguration<T>(ConfigType configType)
        {
            switch(configType)
            {
                case ConfigType.CompareConfig:
                    Config = File.ReadAllText(CompareConfig);
                    break;
            }

            if (!File.Exists(Config))
                return default(T);
            
            var json = JsonConvert.DeserializeObject<T>(Config);

            return json;
        }

        public enum ConfigType
        {
            CompareConfig,
        }

        public void WriteConfiguration(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            File.WriteAllText("test.json", json);
        }


    }
}
