using Microsoft.EntityFrameworkCore;
using ShoppingMate.Core.Repository;
using ShoppingMate.Core.Service;
using ShoppingMate.Core.UnitOfWork;
using ShoppingMate.Data.Context;
using ShoppingMate.Data.Repository;
using ShoppingMate.Data.UnitOfWork;
using ShoppingMate.Service.Mapper;
using ShoppingMate.Core.Service;
using ShoppingMate.Service.Service.Concrete;
using System.Reflection;
using FluentValidation.AspNetCore;
using ShoppingMate.API.Filters;
using Microsoft.AspNetCore.Mvc;
using ShoppingMate.Service.Validator.Product;
using ShoppingMate.API.Middlewares;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using ShoppingMate.API.Modules;
using Autofac.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using ShoppingMate.Caching.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateProductDtoValidator>())
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

builder.Services.AddHttpContextAccessor();


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0.0",
        Title = "ShoppingMate (PatikaDev & Param) RESTful API",
        Contact = new OpenApiContact
        {
            Name = "Enes Arat",
            Url = new Uri("https://github.com/enesarat"),
            Email = "enes_arat@outlook.com"
        },
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<ApplicationDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("MsSql_ShoppingMate_DB"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)).GetName().Name);
    });
});

builder.Services.AddSingleton<RedisRepository>(sp =>
{
    return new RedisRepository(url: builder.Configuration[key: "CacheOptions:Url"]);
});

builder.Services.AddSingleton<IDatabase>(sp =>
{
    var redisService = sp.GetRequiredService<RedisRepository>();
    return redisService.GetDatabase(0);
});


//builder.Host.UseServiceProviderFactory
//    (new AutofacServiceProviderFactory());
//builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepositoryAndServiceModule()));

builder.Services.AddScoped(typeof(IAccountService), typeof(AccountService));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
builder.Services.AddScoped(typeof(IItemService), typeof(ItemService));
builder.Services.AddScoped(typeof(IRoleService), typeof(RoleService));
builder.Services.AddScoped(typeof(IShoppingListService), typeof(ShoppingListService));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));
builder.Services.AddScoped<IProductRepository>(sp =>
{
    var appDbContext = sp.GetService<ApplicationDbContext>();
    var productRepository = new ProductRepository(appDbContext);
    var redisRepository = sp.GetRequiredService<RedisRepository>();
    return new ProductCachedRepository(productRepository, redisRepository);
});

builder.Services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
builder.Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
builder.Services.AddScoped(typeof(IItemRepository), typeof(ItemRepository));
builder.Services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
builder.Services.AddScoped(typeof(IShoppingListRepository), typeof(ShoppingListRepository));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


builder.Services.AddScoped(typeof(NotFoundFilter<,>));

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));



builder.Services.AddAutoMapper(typeof(MappingProfile));






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

app.UseCustomException();

app.MapControllers();

app.Run();
