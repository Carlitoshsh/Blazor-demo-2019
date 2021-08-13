using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTest.Client.API
{
    public class SiteApi: BaseApiConsume 
    {
        public string apiUrl = "";
        public SiteApi(IHttpClientFactory httpClientFactory): base(httpClientFactory) { }
    }
}