using BlazorTest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Business
{
    public class B_Storage : DefaultConnection
    {
        public async Task<int> CreateStorage(Storage storage)
        {
            var affectedRows = await Query<Storage>("INSERT INTO Storage (Id, LastUpdate,PartialQuantity, ProductId ) Values (@Id, @LastUpdate,@PartialQuantity, @ProductId);",
                new
                {
                    storage.Id,
                    storage.LastUpdate,
                    storage.PartialQuantity,
                    storage.ProductId
                }
            );

            return affectedRows.Count;
        }

        public async Task UpdateStorage(Storage storage)
        {
            await Query<Storage>("Update Storage set PartialQuantity = @PartialQuantity, LastUpdate = @LastUpdate, ProductId = @ProductId where Id = @Id;",
                   new
                   {
                       storage.Id,
                       storage.LastUpdate,
                       storage.PartialQuantity,
                       storage.ProductId
                   }
               );
        }

        public async Task<List<Category>> StorageList()
        {
            return await Query<Category>("select * from Storage");
        }

        public async Task<bool> IsProductInWarehouse(string storageId)
        {
            return (await Query<Warehouse>("select 1 from Storage where Id = @Id", new
            {
                Id = storageId
            })).Any();
        }

        public async Task<bool> StorageProductsByWarehouse(string warehouseId)
        {
            return (await Query<Warehouse>("select 1 from Storage where WarehouseId = @Id", new
            {
                Id = warehouseId
            })).Any();
        }
    }
}
