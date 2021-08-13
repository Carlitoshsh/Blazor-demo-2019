using BlazorTest.Business;
using BlazorTest.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly B_Category _category;

        public CategoryController(B_Category category)
        {
            _category = category;
        }

        [HttpPost("CreateCategory")]
        public async Task<int> CreateCategory(Category category)
        {
            return await _category.CreateCategory(category);
        }

        [HttpPost("UpdateCategory")]
        public async Task UpdateCategory(Category category) {
            await _category.UpdateCategory(category);
        }

        [HttpGet("CategoryList")]
        public async Task<List<Category>> CategoryList() {
            return await _category.CategoryList();
        }
    }
}
