using BlazorTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Business
{
    public class B_Warehouse : DefaultConnection
    {
        public async Task<int> CreateWarehouse(Warehouse warehouse)
        {
            var affectedRows = await Query<Warehouse>("INSERT INTO Warehouse (Id, Name,Address ) Values (@Id, @Name,@Address);",
                new
                {
                    warehouse.Id,
                    warehouse.Name,
                    warehouse.Address
                }
            );

            return affectedRows.Count;
        }

        public async Task UpdateWarehouse(Warehouse warehouse)
        {
            await Query<Warehouse>("Update Warehouse set Name = @Name, Address = @Address where Id = @Id;",
                   new
                   {
                       warehouse.Id,
                       warehouse.Name,
                       warehouse.Address
                   }
               );
        }

        public async Task<List<Category>> WarehouseList()
        {
            return await Query<Category>("select * from Warehouse");
        }
    }
}
