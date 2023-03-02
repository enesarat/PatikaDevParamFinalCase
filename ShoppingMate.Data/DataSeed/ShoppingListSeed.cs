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
    public class ShoppingListSeed : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasData(
                new ShoppingList { Id = 1, Name="Clothes List",CategoryId=1, CreateDate = DateTime.Now, },
                new ShoppingList { Id = 2, Name = "Household Appliances List", CategoryId = 2, CreateDate = DateTime.Now, },
                new ShoppingList { Id = 3, Name = "Foods List", CategoryId = 3, CreateDate = DateTime.Now, },
                new ShoppingList { Id = 4, Name = "Furnitures List", CategoryId = 4, CreateDate = DateTime.Now, }
                );
        }
    }
}
