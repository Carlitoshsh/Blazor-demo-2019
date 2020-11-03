using BlazorTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Business
{
    public class B_Category: DefaultConnection
    {
        public async Task<int> CreateCategory(Category category)
        {
            var affectedRows = await Query<Category>("INSERT INTO Category (Id, Name) Values (@Id, @Name);",
                new
                {
                    category.Id,
                    category.Name
                }
            );

            return affectedRows.Count;
        }

        public async Task UpdateCategory(Category category) {
            await Query<Category>("Update Category set Name = @Name where Id = @Id;",
                   new
                   {
                       category.Id,
                       category.Name
                   }
               );
        }

        public async Task<List<Category>> CategoryList()
        {
            return await Query<Category>("select * from Category");
        }
    }
}
