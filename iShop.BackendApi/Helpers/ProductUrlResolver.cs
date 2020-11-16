using AutoMapper;
using iShop.BackendApi.Dtos;
using iShop.Core.Entities;
using iShop.Utilities.Constants;
using Microsoft.Extensions.Configuration;

namespace iShop.BackendApi.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config[SystemConstants.ApiUrl] + source.PictureUrl;
            }
            return null;
        }
    }
}
