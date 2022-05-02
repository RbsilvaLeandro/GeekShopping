namespace GeekShopping.Cart.API.Data.ValueObjects
{
    public class CartDetailVO
    {
        public long id { get; set; }
        public long CartHeaderId { get; set; }       
        public long ProductId { get; set; }       
        public ProductVO Product { get; set; }
      
        public int Count { get; set; }
    }
}


