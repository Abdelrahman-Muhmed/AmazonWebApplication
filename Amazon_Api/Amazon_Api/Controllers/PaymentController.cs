using Amazon_Api.Error;
using Amazon_Core.Model.BasketModel;
using Amazon_Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon_Api.Controllers
{
    [Authorize]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdateBasket(string basketId)
        {
            var GetBasketOrUpdate = await _paymentService.CreateOrUpdatePaymentIntent(basketId);
            if (GetBasketOrUpdate == null)
                return BadRequest(new ApiResponse(404));

            return Ok(GetBasketOrUpdate);
        }

    }
}
