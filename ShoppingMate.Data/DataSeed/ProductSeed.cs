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
                new Product { Id = 1, Name = "Blue Jean", CategoryId = 1, Price = 80, Stock = 100, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 2, Name = "Leather Jacket", CategoryId = 1, Price = 150, Stock = 100, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 3, Name = "Sweetshirt", CategoryId = 1, Price = 60, Stock = 100, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 4, Name = "Dress", CategoryId = 1, Price = 200, Stock = 100, CreateDate = DateTime.Now, UnitType = "piece" },

                new Product { Id = 5, Name = "Washing Machine", CategoryId = 2, Price = 500, Stock = 50, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 6, Name = "Vacuum Cleaner", CategoryId = 2, Price = 70, Stock = 50, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 7, Name = "Television", CategoryId = 2, Price = 400, Stock = 50, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 8, Name = "Refrigerator", CategoryId = 2, Price = 650, Stock = 50, CreateDate = DateTime.Now, UnitType = "piece" },

                new Product { Id = 9, Name = "Pasta", CategoryId = 3, Price = 3, Stock = 250, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 10, Name = "Oil", CategoryId = 3, Price = 8, Stock = 250, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 11, Name = "Milk", CategoryId = 3, Price = 5, Stock = 250, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 12, Name = "Bread", CategoryId = 3, Price = 1, Stock = 250, CreateDate = DateTime.Now, UnitType = "piece" },

                new Product { Id = 13, Name = "Chair", CategoryId = 4, Price = 20, Stock = 150, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 14, Name = "Commode", CategoryId = 4, Price = 30, Stock = 150, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 15, Name = "Seat", CategoryId = 4, Price = 50, Stock = 150, CreateDate = DateTime.Now, UnitType = "piece" },
                new Product { Id = 16, Name = "Lampshade", CategoryId = 4, Price = 15, Stock = 150, CreateDate = DateTime.Now, UnitType = "piece" }
                );
        }
    }
}
