using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iShop.BackendApi.Data;
using iShop.BackendApi.Entities;
using iShop.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var results = await _repo.GetProductsAsync();
            return Ok(results);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _repo.GetProductByIdAsync(id);
            return Ok(result);
        }
    }
}
