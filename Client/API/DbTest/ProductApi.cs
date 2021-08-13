using System.Net.Http;
using System.Threading.Tasks;
using BlazorTest.Shared.Entities;
using System.Text.Json;
using System.Collections.Generic;

namespace BlazorTest.Client.API.DbTest
{
    public class ProductApi : BaseApiConsume
    {
        public string controllerName = "CreateProduct";
        public ProductApi(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        public async Task<int[]> CreateProduct(Product product) =>
            await ConsumirApi<int[]>($"{controllerName}/CreateProduct", HttpMethod.Post, JsonSerializer.Serialize(product));

        public async Task UpdateProduct(Product product) =>
               await ConsumirApi<int[]>($"{controllerName}/UpdateProduct", HttpMethod.Post, JsonSerializer.Serialize(product));
        
        public async Task<List<Product>> ProductList() =>
            await ConsumirApi<List<Product>>($"{controllerName}/ProductList", HttpMethod.Get);
    }
}
