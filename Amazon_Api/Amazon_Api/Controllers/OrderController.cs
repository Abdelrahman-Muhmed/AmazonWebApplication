using Amazon_Api.Dtos;
using Amazon_Api.Error;
using Amazon_Core.Model.OrderModel;
using Amazon_Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon_Api.Controllers
{
    
    public class OrderController : BaseApiController
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;
        public OrderController(IOrdersService ordersService, IMapper mapper)
        {
            _ordersService = ordersService;
            _mapper = mapper;   
        }

        [ProducesResponseType(typeof(Order),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Order), StatusCodes.Status400BadRequest)]
        [Authorize]
        [HttpPost("createOrder")]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var mapAdress = _mapper.Map<AdressDto,AdressModel>(orderDto.ShepingAdress);
            var createOrder = await _ordersService.CreatOrderAsync(orderDto.BuyerEmail, orderDto.BasketId, orderDto.DeliveryMethodId, mapAdress);

            if (createOrder == null)
                return BadRequest(new ApiResponse(400));

            return Ok(createOrder);

        }
    }
}
