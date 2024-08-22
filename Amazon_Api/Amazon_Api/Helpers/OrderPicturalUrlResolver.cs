using Amazon_Api.Dtos;
using Amazon_Core.Model.OrderModel;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace Amazon_Api.Helpers
{
    public class OrderPicturalUrlResolver : IValueResolver<OrderItem, OrderItemToReturnDto, string>
    {
        private readonly IConfiguration _configuration;
        public OrderPicturalUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.productItemOreder.picturelUrl))
                return $"{_configuration["BaseUrl"]}/{source.productItemOreder.picturelUrl}";
            return String.Empty;
        }
    }
}
