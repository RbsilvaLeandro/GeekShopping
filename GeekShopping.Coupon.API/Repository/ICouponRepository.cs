
using GeekShopping.Coupon.Data.ValueObjects;

namespace GeekShopping.Coupon.API.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode);
    }
}
