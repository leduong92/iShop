using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iShop.BackendApi.Dtos;
using iShop.BackendApi.Errors;
using iShop.Core.Entities;
using iShop.Core.Interfaces;
using iShop.Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iShop.BackendApi.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBransRepo;
        private readonly IGenericRepository<ProductType> _prodcutTypesRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBransRepo, 
            IGenericRepository<ProductType> prodcutTypesRepo, IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productBransRepo = productBransRepo;
            _prodcutTypesRepo = prodcutTypesRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(sort);
            var products = await _productsRepo.ListAsync(spec);

            return Ok(
                _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products)
                );
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
            //return Ok(result);
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
