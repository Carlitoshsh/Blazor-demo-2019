using BlazorTest.Business;
using BlazorTest.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateProductController : ControllerBase
    {
        private readonly B_Product _product;

        public CreateProductController(B_Product product)
        {
            _product = product;
        }

        [HttpPost("CreateProduct")]
        public async Task<int> CreateProduct(Product product)
        {
            return await _product.CreateProduct(product);
        }

        [HttpPost("UpdateProduct")]
        public async Task UpdateProduct(Product product)
        {
            await _product.UpdateProduct(product);
        }

        [HttpGet("ProductList")]
        public async Task<List<Product>> ProductList()
        {
            return await _product.ProductList();
        }
    }
}
