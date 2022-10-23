using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using storeAPI.Errors;
using storeCore.Entities;
using storeCore.Interfaces;
using System.Threading.Tasks;

namespace storeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseApiController
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent (string basketId)
        {
            var basket =  await _paymentService.CreateOrUpdatePaymentIntent (basketId);

            if (basket == null) return BadRequest(new ApiResponse(400, "Problem with youer basket"));
            return basket;
        }
    }
}
