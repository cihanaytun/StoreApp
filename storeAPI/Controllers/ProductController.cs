using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeAPI.Dtos;
using storeAPI.Errors;
using storeAPI.Helpers;
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

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

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
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper
            )
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// GetProductAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProduct([FromQuery]ProductSpecParams productSpecParams)
        {
            //var product = await _repo.GetProductsAsync();
            //var product = await _productsRepo.ListAllAsync();

            var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);
            var countSpec = new ProductWithFiltersCountSpecification(productSpecParams);
            var totalItems = await _productsRepo.CountAsync(countSpec);
            var products = await _productsRepo.ListAsync(spec);

            var data = _mapper
                .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            
            if (products == null)
            {
                return StatusCode(500);
            }

            return StatusCode(200,new Pagination<ProductToReturnDto>(productSpecParams.PageIndex,productSpecParams.PageSize,totalItems,data));
        }


        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Cached(600)]
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode:StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),statusCode: StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            //var product = await _repo.GetProductByIdAsync(id);
            //var product = await _productsRepo.GetByIdAsync(id);
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            if (product == null)
            {
                //return StatusCode(500);
                if (product == null) return NotFound(new ApiResponse(404));
            }

            return StatusCode(200,_mapper.Map<Product, ProductToReturnDto>(product));
        }

        /// <summary>
        /// GetBrands
        /// </summary>
        /// <returns></returns>
        [Cached(600)]
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
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
        [Cached(600)]
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
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
