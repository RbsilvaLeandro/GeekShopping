using GeekShopping.Cart.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Cart.API.Model
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
    }
}
