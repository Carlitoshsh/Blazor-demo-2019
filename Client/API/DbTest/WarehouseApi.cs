using System.Net.Http;
using System.Threading.Tasks;
using BlazorTest.Shared.Entities;
using System.Text.Json;
using System.Collections.Generic;

namespace BlazorTest.Client.API.DbTest
{
    public class WarehouseApi : BaseApiConsume
    {
        public string controllerName = "Warehouse";
        public WarehouseApi(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        public async Task<int[]> CreateWarehouse(Warehouse warehouse) =>
            await ConsumirApi<int[]>($"{controllerName}/CreateWarehouse", HttpMethod.Post, JsonSerializer.Serialize(warehouse));

        public async Task UpdateWarehouse(Warehouse warehouse) =>
               await ConsumirApi<int[]>($"{controllerName}/UpdateWarehouse", HttpMethod.Post, JsonSerializer.Serialize(warehouse));
        
        public async Task<List<Warehouse>> WarehouseList() =>
            await ConsumirApi<List<Warehouse>>($"{controllerName}/WarehouseList", HttpMethod.Get);
    }
}
