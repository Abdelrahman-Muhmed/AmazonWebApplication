using Amazon_Api.Dtos;
using Amazon_Core.Model;
using AutoMapper;
using AutoMapper.Execution;
using Microsoft.IdentityModel.Tokens;

namespace Amazon_Api.Helpers
{
    public class PictureUrlResolver : IValueResolver<Product, ProductRetuenDto, string>
    {
        private readonly IConfiguration _configuration;
        public PictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string Resolve(Product source, ProductRetuenDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)) 
                return $"{_configuration["BaseUrl"]}/{source.PictureUrl}";
            return String.Empty;
        }
    }
}
