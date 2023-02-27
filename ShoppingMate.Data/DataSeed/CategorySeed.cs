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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Clothes", CreateDate = DateTime.Now },
                new Category { Id = 2, Name = "Household Appliances", CreateDate = DateTime.Now },
                new Category { Id = 3, Name = "Food", CreateDate = DateTime.Now },
                new Category { Id = 4, Name = "Furniture", CreateDate = DateTime.Now }
                );
        }
    }
}
