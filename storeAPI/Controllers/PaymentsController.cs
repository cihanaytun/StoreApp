using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return await _paymentService.CreateOrUpdatePaymentIntent (basketId);
        }
    }
}
