using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using storeAPI.Errors;
using storeInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPI.Controllers
{

    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _storeContext;

        public BuggyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        /// <summary>
        /// Not found
        /// </summary>
        /// <returns></returns>
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _storeContext.Products.Find(42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }


        /// <summary>
        /// Server error
        /// </summary>
        /// <returns></returns>
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _storeContext.Products.Find(42);
            var thingToReturn = thing.ToString();

            return Ok(thingToReturn);
        }


        /// <summary>
        /// Bad Request
        /// </summary>
        /// <returns></returns>
        [HttpGet("badrequset")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }


        /// <summary>
        /// Bad request by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("badrequset/{id}")]
        public ActionResult GetBadRequestId(int id)
        {
            return BadRequest();
        }
    }
}
