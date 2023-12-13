﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SPC;

#nullable disable

namespace SPC.Migrations
{
    [DbContext(typeof(ProductsContext))]
    partial class ProductsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("SPC.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "FinishProduct"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "HalfFinishProduct"
                        });
                });

            modelBuilder.Entity("SPC.ProductModel", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BatchNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductModels");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            BatchNumber = "1234",
                            CategoryId = 1,
                            Model = "qwer"
                        },
                        new
                        {
                            ProductId = 2,
                            BatchNumber = "2345",
                            CategoryId = 2,
                            Model = "asdf"
                        },
                        new
                        {
                            ProductId = 3,
                            BatchNumber = "3456",
                            CategoryId = 2,
                            Model = "zxcv"
                        },
                        new
                        {
                            ProductId = 4,
                            BatchNumber = "4567",
                            CategoryId = 3,
                            Model = "wasd"
                        });
                });

            modelBuilder.Entity("SPC.ProductModel", b =>
                {
                    b.HasOne("SPC.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SPC.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
