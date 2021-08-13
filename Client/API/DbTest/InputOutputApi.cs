using System.Net.Http;
using System.Threading.Tasks;
using BlazorTest.Shared.Entities;
using System.Text.Json;
using System.Collections.Generic;

namespace BlazorTest.Client.API.DbTest
{
    public class InputOutputApi : BaseApiConsume
    {
        public string controllerName = "InputOutput";
        public InputOutputApi(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        public async Task<int[]> CreateProduct(Product product) =>
            await ConsumirApi<int[]>($"{controllerName}/CreateProduct", HttpMethod.Post, JsonSerializer.Serialize(product));

        public async Task UpdateProduct(Product product) =>
               await ConsumirApi<int[]>($"{controllerName}/UpdateProduct", HttpMethod.Post, JsonSerializer.Serialize(product));
        
        public async Task<List<Product>> ProductList() =>
            await ConsumirApi<List<Product>>($"{controllerName}/ProductList", HttpMethod.Get);
    }
}
