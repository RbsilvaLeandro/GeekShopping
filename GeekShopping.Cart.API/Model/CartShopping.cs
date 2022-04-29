namespace GeekShopping.Cart.API.Model
{
    public class CartShopping
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
