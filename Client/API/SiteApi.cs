using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTest.Shared;

namespace BlazorTest.Client.API
{
    public class SiteApi : BaseApiConsume
    {
        public SiteApi(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        public async Task<WeatherForecast[]> GetWeather() =>
            await ConsumirApi<WeatherForecast[]>("/WeatherForecast", HttpMethod.Get);
    }
}