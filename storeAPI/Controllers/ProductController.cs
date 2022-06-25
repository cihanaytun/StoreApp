using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeCore.Interfaces;
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
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// GetProductAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var product = await _repo.GetProductsAsync();
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
            var product = await _repo.GetProductByIdAsync(id);

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
            var brand = await _repo.GetProductBrandsAsync();
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
            var types = await _repo.GetProductTypesAsync();
            if (types == null)
            {
                return StatusCode(500);
            }
            return StatusCode(200, types);
        }

    }
}
