using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables

            modelBuilder.Entity<Product>()
                .ToTable("Products");

            modelBuilder.Entity<Category>()
                .ToTable("Categories");

            modelBuilder.Entity<Order>()
                .ToTable("Orders");

            modelBuilder.Entity<ProductOrder>()
                .ToTable("ProductOrder");

            #endregion


            #region "primary key"

            modelBuilder.Entity<Product>()
               .HasKey(product => product.Id);

            modelBuilder.Entity<Category>()
               .HasKey(category => category.Id);

            modelBuilder.Entity<Order>()
               .HasKey(order => order.Id);

            modelBuilder.Entity<ProductOrder>()
               .HasKey(po => new { po.ProductId, po.OrderId });

            #endregion

            #region relationships

            modelBuilder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(po => po.Orders)
                .HasForeignKey(po => po.ProductId);

            modelBuilder.Entity<ProductOrder>()
               .HasOne(po => po.Order)
               .WithMany(po => po.Products)
               .HasForeignKey(po => po.OrderId);



            #endregion

        }
    }
}
