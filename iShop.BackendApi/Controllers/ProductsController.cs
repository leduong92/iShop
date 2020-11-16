using System.Threading.Tasks;
using iShop.Core.Entities;
using iShop.Core.Interfaces;
using iShop.Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace iShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBransRepo;
        private readonly IGenericRepository<ProductType> _prodcutTypesRepo;
        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBransRepo, IGenericRepository<ProductType> prodcutTypesRepo)
        {
            _productsRepo = productsRepo;
            _productBransRepo = productBransRepo;
            _prodcutTypesRepo = prodcutTypesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            var results = await _productsRepo.ListAsync(spec);
            return Ok(results);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var result = await _productsRepo.GetEntityWithSpec(spec);
            return Ok(result);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            var results = await _productBransRepo.ListAllAsync();
            return Ok(results);
        }
        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypess()
        {
            var results = await _prodcutTypesRepo.ListAllAsync();
            return Ok(results);
        }
    }
}
