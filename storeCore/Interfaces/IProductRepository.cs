using storeCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace storeCore.Interfaces
{
    public interface IProductRepository
    {

        Task<Product> GetProductByIdAsync(int id);

        Task<IReadOnlyList<Product>> GetProductsAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();




    }
}
