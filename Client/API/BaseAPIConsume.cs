using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using BlazorTest.Client.Helpers;

namespace BlazorTest.Client.API
{
    public class BaseApiConsume
    {
        protected readonly IHttpClientFactory _httpClientFactory;

        public BaseApiConsume(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected async Task<T> ConsumirApi<T>(string metodo, HttpMethod httpMethod, string json = "", string token = "")
        {
            ConnectWithService conector = new ConnectWithService(_httpClientFactory);
            return await conector.ConstruirMetodo<T>(metodo, httpMethod, json, token);
        }
    }
}
