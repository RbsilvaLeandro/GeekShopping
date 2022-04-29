namespace GeekShopping.Cart.API.Data.ValueObjects
{
    public class CartShoppingVO
    {
        public CartHeaderVO CartHeader { get; set; }
        public IEnumerable<CartDetailVO> CartDetails { get; set; }
    }
}
