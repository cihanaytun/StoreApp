using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using storeAPI.Errors;
using storeCore.Entities;
using storeCore.Entities.OrderAggregate;
using storeCore.Interfaces;
using storeInfrastructure.Services;
using Stripe;
using System.IO;
using System.Threading.Tasks;
using Order = storeCore.Entities.OrderAggregate.Order;

namespace storeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentService> _logger;
        private const string WhScreet = "whsec_e29eb4856d9d3c2fca6accc784be0ad9b26014a10da1b5b30755c2776f2030e7";

        public PaymentsController(IPaymentService paymentService,ILogger<PaymentService> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent (string basketId)
        {
            var basket =  await _paymentService.CreateOrUpdatePaymentIntent (basketId);

            if (basket == null) return BadRequest(new ApiResponse(400, "Problem with youer basket"));
            return basket;
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signatuere"], WhScreet);

            PaymentIntent intent;
            Order order;

            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment Succeeded : ", intent.Id);
                    // TODO: update order with new status
                    order = await _paymentService.UpdateOrderPaymentSucceeded(intent.Id);
                    _logger.LogInformation("Order updated to payment received :", order.Id);
                    break;

                case "payment_intent.payment_failed":
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment Failed : ", intent.Id);
                    order = await _paymentService.UpdateOrderPaymentFailed(intent.Id);
                    _logger.LogInformation("Payment failed :", order.Id);
                    // TODO: update order  status
                    break;
            }

            return new EmptyResult();
        }
    }
}
