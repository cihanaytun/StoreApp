using Microsoft.EntityFrameworkCore;
using storeCore.Entities;
using storeCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace storeInfrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        /// <summary>
        /// ProductBrand
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _storeContext.ProductBrands.ToArrayAsync();
        }

        /// <summary>
        /// ProducyById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _storeContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// ProductAll
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {

            return await _storeContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync();
        }

        /// <summary>
        /// ProductType
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _storeContext.ProductTypes.ToListAsync();
        }
    }
}
