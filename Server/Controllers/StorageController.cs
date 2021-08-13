using BlazorTest.Business;
using BlazorTest.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Controllers
{
    public class StorageController : ControllerBase
    {
        private readonly B_Storage _storage;

        public StorageController(B_Storage storage)
        {
            _storage = storage;
        }

        [HttpPost("CreateStorage")]
        public async Task<int> CreateStorage(Storage storage)
        {
            return await _storage.CreateStorage(storage);
        }

        [HttpPost("UpdateStorage")]
        public async Task UpdateStorage(Storage storage)
        {
            await _storage.UpdateStorage(storage);
        }

        [HttpGet("StorageList")]
        public async Task<List<Category>> StorageList()
        {
            return await _storage.StorageList();
        }

        [HttpGet("IsProductInWarehouse/{storageId}")]
        public async Task<bool> IsProductInWarehouse(string storageId)
        {
            return await _storage.IsProductInWarehouse(storageId);
        }

        [HttpGet("StorageProductsByWarehouse/{warehouseId}")]
        public async Task<bool> StorageProductsByWarehouse(string warehouseId)
        {
            return await _storage.StorageProductsByWarehouse(warehouseId);
        }
    }
}
