using BlazorTest.Business;
using BlazorTest.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Controllers
{
    public class WarehouseController : ControllerBase
    {
        private readonly B_Warehouse _warehouse;

        public WarehouseController(B_Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        [HttpPost("CreateWarehouse")]
        public async Task<int> CreateWarehouse(Warehouse Warehouse)
        {
            return await _warehouse.CreateWarehouse(Warehouse);
        }

        [HttpPost("UpdateWarehouse")]
        public async Task UpdateWarehouse(Warehouse Warehouse)
        {
            await _warehouse.UpdateWarehouse(Warehouse);
        }

        [HttpGet("WarehouseList")]
        public async Task<List<Warehouse>> WarehouseList()
        {
            return await _warehouse.WarehouseList();
        }
    }
}
