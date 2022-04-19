using GeekShopping.Product.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Product.API.Model
{
    [Table("product")]
    public class Products : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1, 10000)]
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
