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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }



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




            //builder.Entity<ItemShoppingListJoint>()
            //    .HasKey(ky => new { ky.ItemId, ky.ShoppingListId });
            //builder.Entity<ItemShoppingListJoint>()
            //    .HasOne(ky => ky.Item)
            //    .WithMany(k => k.ShoppingLists)
            //    .HasForeignKey(ky => ky.ItemId);
            //builder.Entity<ItemShoppingListJoint>()
            //    .HasOne(ky=>ky.ShoppingList)
            //    .WithMany(k=>k.Items)
            //    .HasForeignKey(ky => ky.ShoppingListId);
            
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
