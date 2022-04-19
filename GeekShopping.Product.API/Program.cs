using AutoMapper;
using GeekShopping.Product.API.Config;
using GeekShopping.Product.API.Model.Context;
using GeekShopping.Product.API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<MySqlContext>(options =>
//{
//    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnectionString"), new MySqlServerVersion(new Version(6, 2, 4)));
//});

builder.Services.AddDbContext<MySqlContext>(options =>
{
    options.UseMySql(@"Server=localhost;Port=3306;Database=geekShopping_product_api;Uid=root;Pwd=Nigt@c#52489700", new MySqlServerVersion(new Version(6, 2, 4)));
});

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();