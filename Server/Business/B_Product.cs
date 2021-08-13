using BlazorTest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Business
{
    public class B_Product : DefaultConnection
    {
        public async Task<int> CreateProduct(Product product)
        {
            var affectedRows = await Query<Product>("INSERT INTO Product (Id, Name, Description, TotalQuantity, CategoryId ) Values (@Id, @Name, @Description, @TotalQuantity, @CategoryId );",
                new
                {
                    product.Id,
                    product.Name,
                    product.Description,
                    product.TotalQuantity,
                    product.CategoryId
                }
            );

            return affectedRows.Count;
        }

        public async Task UpdateProduct(Product product)
        {
            await Query<Product>("Update Product set Name = @Name, Description = @Description, TotalQuantity = @TotalQuantity, CategoryId = @CategoryId where Id = @Id;",
                   new
                   {
                       product.Id,
                       product.Name,
                       product.Description,
                       product.TotalQuantity,
                       product.CategoryId
                   }
               );
        }

        public async Task<List<Product>> ProductList()
        {
            return await Query<Product>("select * from Product");
        }
    }
}
