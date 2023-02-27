using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingMate.Core.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Data.DataSeed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Blue Jean", CategoryId = 1, Price = 80, Stock = 100, CreateDate = DateTime.Now },
                new Product { Id = 2, Name = "Washing Machine", CategoryId = 2, Price = 500, Stock = 50, CreateDate = DateTime.Now },
                new Product { Id = 3, Name = "Pasta", CategoryId = 3, Price = 3, Stock = 250, CreateDate = DateTime.Now },
                new Product { Id = 4, Name = "Chair", CategoryId = 4, Price = 20, Stock = 150, CreateDate = DateTime.Now }
                );
        }
    }
}
