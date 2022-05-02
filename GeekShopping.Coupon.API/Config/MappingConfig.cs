using AutoMapper;
using GeekShopping.Coupon.Data.ValueObjects;

namespace GeekShopping.Coupon.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }

}
