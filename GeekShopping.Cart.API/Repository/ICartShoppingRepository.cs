using GeekShopping.Cart.API.Data.ValueObjects;

namespace GeekShopping.Cart.API.Repository
{
    public interface ICartShoppingRepository
    {
        Task<CartShoppingVO> FindCartByUserId(string userId);
        Task<CartShoppingVO> SaveOrUpdateCart(CartShoppingVO cart);
        Task<bool> RemoveFromCart(long cartDetailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> ClearCart(string userId);
    }
}
