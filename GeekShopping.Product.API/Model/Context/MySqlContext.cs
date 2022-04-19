using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.API.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(){}

        public MySqlContext(DbContextOptions<MySqlContext> options): base (options)
        {

        }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 1,
				Name = "Camiseta Goku Fases",
				Price = new decimal(59.99),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/13_dragon_ball.jpg",
				Category = "T-shirt"

			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 2,
				Name = "Camiseta No Internet",
				Price = new decimal(69.9),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true",
				Category = "T-shirt"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 3,
				Name = "Capacete Darth Vader Star Wars Black Series",
				Price = new decimal(999.99),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true",
				Category = "Action Figure"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 4,
				Name = "Star Wars The Black Series Hasbro - Stormtrooper Imperial",
				Price = new decimal(189.99),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/4_storm_tropper.jpg?raw=true",
				Category = "Action Figure"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 5,
				Name = "Camiseta Gamer",
				Price = new decimal(69.99),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_gamer.jpg?raw=true",
				Category = "T-shirt"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 6,
				Name = "Camiseta SpaceX",
				Price = new decimal(49.99),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spacex.jpg?raw=true",
				Category = "T-shirt"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 7,
				Name = "Camiseta Feminina Coffee Benefits",
				Price = new decimal(69.9),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_coffee.jpg?raw=true",
				Category = "T-shirt"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 8,
				Name = "Moletom Com Capuz Cobra Kai",
				Price = new decimal(159.9),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true",
				Category = "Sweatshirt"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 9,
				Name = "Livro Star Talk – Neil DeGrasse Tyson",
				Price = new decimal(49.9),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_neil.jpg?raw=true",
				Category = "Book"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 10,
				Name = "Star Wars Mission Fleet Han Solo Nave Milennium Falcon",
				Price = new decimal(359.99),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true",
				Category = "Action Figure"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 11,
				Name = "Camiseta Elon Musk Spacex Marte Occupy Mars",
				Price = new decimal(59.99),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/11_mars.jpg?raw=true",
				Category = "T-shirt"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 12,
				Name = "Camiseta GNU Linux Programador Masculina",
				Price = new decimal(59.99),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_gnu_linux.jpg?raw=true",
				Category = "T-shirt"
			});
			modelBuilder.Entity<Products>().HasData(new Products
			{
				id = 13,
				Name = "Camiseta GNU Linux Programador Feminina",
				Price = new decimal(19.99),
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout",
				ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_gnu_linux.jpg?raw=true",
				Category = "T-shirt"
			});
		}
    }
}
