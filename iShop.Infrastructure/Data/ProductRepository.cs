
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
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
