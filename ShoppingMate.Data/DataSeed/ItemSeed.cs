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
    public class ItemSeed : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData(
                new Item { Id = 1, CreateDate = DateTime.Now, ProductId = 1, Quantity = 3, ShoppingListId = 1 },
                new Item { Id = 2, CreateDate = DateTime.Now, ProductId = 2, Quantity = 1, ShoppingListId = 1 },
                new Item { Id = 3, CreateDate = DateTime.Now, ProductId = 3, Quantity = 5, ShoppingListId = 1 },
                new Item { Id = 4, CreateDate = DateTime.Now, ProductId = 4, Quantity = 2, ShoppingListId = 1 },

                new Item { Id = 5, CreateDate = DateTime.Now, ProductId = 5, Quantity = 1, ShoppingListId = 2 },
                new Item { Id = 6, CreateDate = DateTime.Now, ProductId = 6, Quantity = 1, ShoppingListId = 2 },
                new Item { Id = 7, CreateDate = DateTime.Now, ProductId = 7, Quantity = 2, ShoppingListId = 2 },
                new Item { Id = 8, CreateDate = DateTime.Now, ProductId = 8, Quantity = 1, ShoppingListId = 1 },

                new Item { Id = 9, CreateDate = DateTime.Now, ProductId = 9, Quantity = 10, ShoppingListId = 3 },
                new Item { Id = 10, CreateDate = DateTime.Now, ProductId = 10, Quantity = 2, ShoppingListId = 3 },
                new Item { Id = 11, CreateDate = DateTime.Now, ProductId = 11, Quantity = 5, ShoppingListId = 3 },
                new Item { Id = 12, CreateDate = DateTime.Now, ProductId = 12, Quantity = 3, ShoppingListId = 3 },

                new Item { Id = 13, CreateDate = DateTime.Now, ProductId = 13, Quantity = 4, ShoppingListId = 4 },
                new Item { Id = 14, CreateDate = DateTime.Now, ProductId = 14, Quantity = 1, ShoppingListId = 4 },
                new Item { Id = 15, CreateDate = DateTime.Now, ProductId = 15, Quantity = 2, ShoppingListId = 4 },
                new Item { Id = 16, CreateDate = DateTime.Now, ProductId = 16, Quantity = 5, ShoppingListId = 4 }
                );
        }
    }
}
