using AutoMapper;
using GeekShopping.Cart.API.Data.ValueObjects;
using GeekShopping.Cart.API.Model;

namespace GeekShopping.Cart.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Products>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
                config.CreateMap<CartShoppingVO, CartShopping>().ReverseMap();
            });
            return mappingConfig;
        }
    }

}
