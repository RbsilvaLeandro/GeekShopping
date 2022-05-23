using GeekShopping.Order.API;
using GeekShopping.Order.API.MessageConsumer;
using GeekShopping.Order.API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MySqlContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("GeekShoppingCartAPIConnection"), new MySqlServerVersion(new Version(6, 2, 4)));
});

var builderContext = new DbContextOptionsBuilder<MySqlContext>();
builderContext.UseMySql(builder.Configuration.GetConnectionString("GeekShoppingCartAPIConnection"),
            new MySqlServerVersion(
                new Version(8, 0, 5)));

builder.Services.AddSingleton(new OrderRepository(builderContext.Options));

builder.Services.AddHostedService<RabbitMQCheckoutConsumer>();
//builder.Services.AddScoped<ICartShoppingRepository, CartShoppingRepository>();
//builder.Services.AddScoped<IRabbitMqMessageSender, RabbitMqMessageSender>();

builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:4435/";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.CartAPI", Version = "v1" });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token!",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
       {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
            {
              Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In= ParameterLocation.Header
          },
          new List<string> ()
       }
    });
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "geek_shopping");
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
