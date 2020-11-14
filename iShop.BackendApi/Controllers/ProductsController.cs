using System.Threading.Tasks;
using iShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
