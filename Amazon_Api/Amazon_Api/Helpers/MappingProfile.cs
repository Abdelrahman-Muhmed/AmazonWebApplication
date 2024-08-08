using Amazon_Api.Dtos;
using Amazon_Core.Model;
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


        }
    }
}
