using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarShop.Models;
using Microsoft.EntityFrameworkCore;


namespace GuitarShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category {CategoryId = 1,Name="Basses"},
               new Category { CategoryId = 2, Name ="Guitar"},
               new Category {CategoryId = 3, Name = "Drums" }
                            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name= "Fender", Price=100,CategoryId=2 });
        }


    }
}
