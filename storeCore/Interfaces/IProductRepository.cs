using storeCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace storeCore.Interfaces
{
    public interface IProductRepository
    {

        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// GetProductAll
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Product>> GetProductsAsync();

        /// <summary>
        /// getProductBrands
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        /// <summary>
        /// getProductTypes
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();




    }
}
