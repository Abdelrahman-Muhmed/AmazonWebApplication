using Amazon_Api.Dtos;
using Amazon_Core.Model;
using Amazon_Core.Model.IdentityModel;
using Amazon_Core.Model.OrderModel;
using AutoMapper;



namespace Amazon_Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductRetuenDto>()
                .ForMember(p => p.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(p => p.CategoryName, o => o.MapFrom(s => s.CategoryName.Name))

                //Add Resolver For PictureUrl 
                //.ForMember(p => p.PictureUrl, o => o.MapFrom(s => $"{https://localhost:7015}/{s.PictureUrl}"))
                .ForMember(p => p.PictureUrl, o => o.MapFrom<PictureUrlResolver>());

            CreateMap<AdressDto , Adress>().ReverseMap();
            CreateMap<AdressDto ,AdressModel>().ReverseMap();


            CreateMap<Order , OrderToReturnDto>()
                .ForMember(e => e.DeliveryMethod, f => f.MapFrom(s => s.deliveryMethod.shortName))
                .ForMember(e => e.cost, f => f.MapFrom(s => s.deliveryMethod.cost));

            CreateMap<OrderItem, OrderItemToReturnDto>()
                .ForMember(e => e.productId, f => f.MapFrom(s => s.productItemOreder.productId))
                .ForMember(e => e.productName, f => f.MapFrom(s => s.productItemOreder.productName))
                .ForMember(e => e.picturelUrl, f => f.MapFrom(s => s.productItemOreder.picturelUrl))
                .ForMember(e => e.picturelUrl, f => f.MapFrom<OrderPicturalUrlResolver>());
           
            


        }
    }
}
