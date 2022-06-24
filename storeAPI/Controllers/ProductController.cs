using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly StoreContext _storeContext;
        public ProductController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var product = await _storeContext.Products.ToListAsync();
            if (product == null)
            {
                return StatusCode(500);
            }
            return StatusCode(200, product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _storeContext.Products.FindAsync(id);

            if (product.Id != id)
            {
                return StatusCode(500);
            }
            return StatusCode(200, product);
        }

    }
}
