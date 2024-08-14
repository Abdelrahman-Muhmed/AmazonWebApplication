using Amazon_Api.Error;
using Amazon_Core.IRepository;
using Amazon_Core.Model.BasketModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon_Api.Controllers
{
    
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        //[HttpGet("{id}")]
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basketItem = await _basketRepository.GetAsync(id);

            return Ok(basketItem is null ? new CustomerBasket(id): basketItem);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdate(CustomerBasket basket)
        {
            //Dont forgate to make valdiation for input >>>>>>>>>>>>>>>>>>>>>>>>> He use DTO  That right or not ?
            var CreteOrUpdateItem = await _basketRepository.CreateOrUpdateAsync(basket);
            if(CreteOrUpdateItem == null)
            {
                return BadRequest(new ApiResponse(400));
            }
           
            return Ok(CreteOrUpdateItem );
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasketItem(string id)
        {
            var deletItem = await _basketRepository.DeleteAsync(id);
            return deletItem;

        }
    }
}
