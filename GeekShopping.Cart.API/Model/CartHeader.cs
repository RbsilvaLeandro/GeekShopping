using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Cart.API.Model
{
    [Table("cart_header")]
    public class CartHeader
    {
        [Column("id")]
        public long id { get; set; }
        [Column("user_id")]
        public string UserId { get; set; }

        [Column("coupon_code")]
        public string CouponCode { get; set; }
    }
}
