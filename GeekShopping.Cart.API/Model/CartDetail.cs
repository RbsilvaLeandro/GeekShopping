using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Cart.API.Model
{
    [Table("cart_detail")]
    public class CartDetail
    {
        [Column("id")]
        public long id { get; set; }
        public long CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Products Product { get; set; }

        [Column("count")]
        public int Count { get; set; }
    }
}


