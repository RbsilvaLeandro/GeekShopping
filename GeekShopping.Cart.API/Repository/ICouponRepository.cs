
using GeekShopping.Cart.Data.ValueObjects;

namespace GeekShopping.Cart.API.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode, string token);
    }
}
