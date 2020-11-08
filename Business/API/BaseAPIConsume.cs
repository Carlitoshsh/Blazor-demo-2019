using BlazorTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using BlazorTest.Helpers;


namespace BlazorTest.Business.API
{
    public class BaseAPIConsume {

        protected readonly IHttpClientFactory _httpClientFactory;

        public BaseAPIConsume(IHttpClientFactory httpClientFactory){
            _httpClientFactory = httpClientFactory;
        }

        protected async Task<T> ConsumirApi<T>(string metodo, HttpMethod httpMethod, string json = "", string token = "")
            {
            ConnectWithService conector = new ConnectWithService(_httpClientFactory, "https://pokeapi.co/api/v2/");
            return await conector.ConstruirMetodo<T>(metodo, httpMethod, json, token);
            }
    }
}
