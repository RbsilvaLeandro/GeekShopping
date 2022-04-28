using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Product.API.Model
{
    [Table("product")]
    public class Products
    {
        [Key]
        [Column("id")]
        public long id { get; set; }

        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(150)]
        public string Description { get; set; }

        [Column("category")]
        [StringLength(50)]
        public string Category { get; set; }

        [Column("imageurl")]
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
