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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateProductDtoValidator>())
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(NotFoundFilter<,>));

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ApplicationDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("MsSql_ShoppingMate_DB"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)).GetName().Name);
    });
});

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepositoryAndServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomException();

app.MapControllers();

app.Run();
