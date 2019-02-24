using EM.Contracts.Interfaces.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EM.Services.HttpClientConsole.ApiClient
{
    public class Client
    {
        readonly IConfig config;

        public Client(IConfig config, Dictionary<string, object> parameters, string urlCommand)
        {
            this.config = config;
        }

        public Client(IConfig config, string urlCommand)
        {
            this.config = config;
        }

        public Client(IConfig config)
        {
            this.config = config;
        }

        public async Task<T> GetDataAsync<T>(bool authenticate)
        {
            var resultUrl = new UrlFactory(config);
            string url = string.Empty;
            url = resultUrl.ParamaterizedUrl();

            var handler = new HttpClientHandler { ClientCertificateOptions = ClientCertificateOption.Automatic };
            using (HttpClient client = new HttpClient(handler))
            {
                if (authenticate)
                {
                    var byteArr = Encoding.ASCII.GetBytes($"{config.Key}:{config.Secret}");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArr));
                }
                try
                {
                    var response = await client.GetAsync(url);
                    Console.WriteLine(url);
                    var resultString = await response.Content.ReadAsStringAsync();

                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resultString);
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GetData error: ", ex.Message);
                    throw ex;
                }
            }
        }

        public async Task<T> PostDataAsync<T>(KeyValuePair<string, string>[] formHeaderContents, bool authenticate)
        {
            var resultUrl = new UrlFactory(config);
            string url = string.Empty;


            url = resultUrl.ParamaterizedUrl();

            var handler = new HttpClientHandler();
            using (HttpClient client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(formHeaderContents);

                if (authenticate)
                {
                    var byteArr = Encoding.ASCII.GetBytes($"{config.Key}:{config.Secret}");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArr));
                }

                try
                {
                    var response = await client.PostAsync(url, formContent);

                    var resultString = await response.Content.ReadAsStringAsync();

                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resultString);
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GetData error: ", ex.Message);
                    throw ex;
                }
            }
        }
        //public async Task<T> PostDataAsync<T>(string urlCommand, bool authenticate)
        //{
        //    return await PostDataAsync<T>(null, null, true);
        //}
    }
}
