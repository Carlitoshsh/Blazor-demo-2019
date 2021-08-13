using System.Net.Http;
using System.Threading.Tasks;
using BlazorTest.Shared.Entities;
using System.Text.Json;
using System.Collections.Generic;

namespace BlazorTest.Client.API.DbTest
{
    public class CategoryApi : BaseApiConsume
    {
        public string controllerName = "Category";
        public CategoryApi(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        public async Task<int[]> CreateCategory(Category Category) =>
            await ConsumirApi<int[]>($"{controllerName}/CreateCategory", HttpMethod.Post, JsonSerializer.Serialize(Category));

        public async Task UpdateCategory(Category Category) =>
               await ConsumirApi<int[]>($"{controllerName}/UpdateCategory", HttpMethod.Post, JsonSerializer.Serialize(Category));
        
        public async Task<List<Category>> CategoryList() =>
            await ConsumirApi<List<Category>>($"{controllerName}/CategoryList", HttpMethod.Get);
    }
}
