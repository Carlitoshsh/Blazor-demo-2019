using System.Net.Http;
using System.Threading.Tasks;
using BlazorTest.Shared.Entities;
using System.Text.Json;
using System.Collections.Generic;

namespace BlazorTest.Client.API.DbTest
{
    public class StorageApi : BaseApiConsume
    {
        public string controllerName = "Storage";
        public StorageApi(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        public async Task<int[]> CreateStorage(Storage Storage) =>
            await ConsumirApi<int[]>($"{controllerName}/CreateStorage", HttpMethod.Post, JsonSerializer.Serialize(Storage));

        public async Task UpdateStorage(Storage Storage) =>
               await ConsumirApi<int[]>($"{controllerName}/UpdateStorage", HttpMethod.Post, JsonSerializer.Serialize(Storage));
        
        public async Task<List<Storage>> StorageList() =>
            await ConsumirApi<List<Storage>>($"{controllerName}/StorageList", HttpMethod.Get);

        public async Task<bool> IsProductInWarehouse(string storageId) =>
            await ConsumirApi<bool>($"{controllerName}/IsProductInWarehouse/{storageId}", HttpMethod.Get);
        
        public async Task<bool> StorageProductsByWarehouse(string warehouseId) =>
                await ConsumirApi<bool>($"{controllerName}/StorageProductsByWarehouse/{warehouseId}", HttpMethod.Get);
    }
}
