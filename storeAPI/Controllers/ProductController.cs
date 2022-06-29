 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeCore.Entities;
using storeCore.Interfaces;
using storeCore.Specifications;
using storeInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        /*
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        */



        public ProductController(
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo)
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }

        /// <summary>
        /// GetProductAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            //var product = await _repo.GetProductsAsync();
            //var product = await _productsRepo.ListAllAsync();

            var spec = new ProductsWithTypesAndBrandsSpecification();
            var product = await _productsRepo.ListAsync(spec);
            if (product == null)
            {
                return StatusCode(500);
            }
            return StatusCode(200, product);
        }


        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            //var product = await _repo.GetProductByIdAsync(id);
            //var product = await _productsRepo.GetByIdAsync(id);
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var product = await _productsRepo.GetEntityWithSpec(spec);
            if (product == null)
            {
                return StatusCode(500);
            }
            return StatusCode(200, product);
        }

        /// <summary>
        /// GetBrands
        /// </summary>
        /// <returns></returns>
        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            //var brand = await _repo.GetProductBrandsAsync();
            var brand = await _productBrandRepo.ListAllAsync();
            if (brand == null)
            {
                return StatusCode(500);
            }
            return StatusCode(200, brand);
        }

        /// <summary>
        /// GetTypes
        /// </summary>
        /// <returns></returns>
        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            //var types = await _repo.GetProductTypesAsync();
            var types = await _productTypeRepo.ListAllAsync();
            if (types == null)
            {
                return StatusCode(500);
            }
            return StatusCode(200, types);
        }

    }
}
