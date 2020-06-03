using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
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
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                // goes back to this json field in appsettings.development.json
                // case sensitive must be exact - this gives the full path to the image in the project
                // for the web app, similar to phaser in loading images from project structure
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}