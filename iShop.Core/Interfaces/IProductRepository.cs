using iShop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iShop.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBransAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
