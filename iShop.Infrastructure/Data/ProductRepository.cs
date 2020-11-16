
using iShop.Core.Entities;
using iShop.Core.Interfaces;
using iShop.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iShop.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBransAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

    }
}
