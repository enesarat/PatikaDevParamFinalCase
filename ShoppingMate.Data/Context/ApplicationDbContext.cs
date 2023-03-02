using Microsoft.EntityFrameworkCore;
using ShoppingMate.Core.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // dbsets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Item>()

                 .HasMany(x => x.ShoppingLists).WithMany(x => x.Items)
                 .UsingEntity<Dictionary<string, object>>("ItemsShoppingListsJoint",
                 x => x.HasOne<ShoppingList>().WithMany().HasForeignKey("ShoppingListId").HasConstraintName("ShoppingListFK"),
                 x => x.HasOne<Item>().WithMany().HasForeignKey("ItemId").HasConstraintName("ItemFK"));

            
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
