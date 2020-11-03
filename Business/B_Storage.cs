using BlazorTest.Entities;
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
            var affectedRows = await Query<Storage>("INSERT INTO Storage (Id, LastUpdate,PartialQuantity ) Values (@Id, @LastUpdate,@PartialQuantity);",
                new
                {
                    storage.Id,
                    storage.LastUpdate,
                    storage.PartialQuantity
                }
            );

            return affectedRows.Count;
        }

        public async Task UpdateStorage(Storage storage)
        {
            await Query<Storage>("Update Storage set PartialQuantity = @PartialQuantity, LastUpdate = @LastUpdate where Id = @Id;",
                   new
                   {
                       storage.Id,
                       storage.LastUpdate,
                       storage.PartialQuantity
                   }
               );
        }

        public async Task<List<Category>> StorageList()
        {
            return await Query<Category>("select * from Storage");
        }
    }
}
