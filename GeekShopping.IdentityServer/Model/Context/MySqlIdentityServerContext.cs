using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class MySqlIdentityServerContext : IdentityDbContext<ApplicationUser>
    {
		public MySqlIdentityServerContext(DbContextOptions<MySqlIdentityServerContext> options) : base(options)
		{

		}
	}
}
