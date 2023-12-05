﻿// <auto-generated />
using System;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    [DbContext(typeof(BotDbContext))]
    [Migration("20231205173742_Product-Basket-Order-Tables")]
    partial class ProductBasketOrderTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("E_Commerce.Domain.Entities.Basket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ClientTelegramId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 12, 5, 22, 37, 34, 291, DateTimeKind.Local).AddTicks(1038),
                            Description = "Ajoyib filialimiz",
                            Latitude = 60.0,
                            Longitude = 50.0,
                            Name = "Kukcha"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 12, 5, 22, 37, 34, 291, DateTimeKind.Local).AddTicks(1064),
                            Description = "Bu ham juda ajoyib filial",
                            Latitude = 61.0,
                            Longitude = 56.0,
                            Name = "Chilonzor"
                        });
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Feedback", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserTelegramId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("BasketId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromBranchId")
                        .HasColumnType("int");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.ProductList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long?>("BasketId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<long>("UserTelegramId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.ToTable("ProductLists");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Rate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<long>("UserTelegramId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.ProductList", b =>
                {
                    b.HasOne("E_Commerce.Domain.Entities.Basket", null)
                        .WithMany("Products")
                        .HasForeignKey("BasketId");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Basket", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}