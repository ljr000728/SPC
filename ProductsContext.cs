using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC
{
    public class ProductsContext : DbContext
    {
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=products.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "FinishProduct" },
                new Category { CategoryId = 2, Name = "HalfFinishProduct" });
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { ProductId = 1, CategoryId = 1, Model = "qwer", BatchNumber = "1234" },
                new ProductModel { ProductId = 2, CategoryId = 2, Model = "asdf", BatchNumber = "2345" },
                new ProductModel { ProductId = 3, CategoryId = 2, Model = "zxcv", BatchNumber = "3456" },
                new ProductModel { ProductId = 4, CategoryId = 3, Model = "wasd", BatchNumber = "4567" });
        }
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("ProductModels");
            builder.HasOne<Category>(p => p.Category).WithMany(c => c.Products);
        }
    }
}
