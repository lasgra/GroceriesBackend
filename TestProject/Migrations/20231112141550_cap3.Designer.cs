﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestProject.Entities;

#nullable disable

namespace TestProject.Migrations
{
    [DbContext(typeof(GroceryDbContext))]
    [Migration("20231112141550_cap3")]
    partial class cap3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestProject.Entities.GroceryList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GroceryList");
                });

            modelBuilder.Entity("TestProject.Entities.GroceryListEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroceryListId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroceryListId");

                    b.ToTable("GroceryListEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Fruit",
                            Name = "Apple",
                            Price = 3.49m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Fruit",
                            Name = "Banana",
                            Price = 6.99m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Fruit",
                            Name = "Peach",
                            Price = 7.01m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Vegetable",
                            Name = "Tomato",
                            Price = 12.49m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Vegetable",
                            Name = "Carrot",
                            Price = 2.99m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Drink",
                            Name = "Milk",
                            Price = 2.49m,
                            Unit = "Pcs"
                        },
                        new
                        {
                            Id = 7,
                            Category = "Drink",
                            Name = "Sprite",
                            Price = 6.50m,
                            Unit = "Pcs"
                        },
                        new
                        {
                            Id = 8,
                            Category = "Candy",
                            Name = "Skittles",
                            Price = 9.99m,
                            Unit = "Pcs"
                        },
                        new
                        {
                            Id = 9,
                            Category = "Candy",
                            Name = "Chocolate",
                            Price = 4.69m,
                            Unit = "Pcs"
                        });
                });

            modelBuilder.Entity("TestProject.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestProject.Entities.GroceryListEntry", b =>
                {
                    b.HasOne("TestProject.Entities.GroceryList", null)
                        .WithMany("GroceryEntries")
                        .HasForeignKey("GroceryListId");
                });

            modelBuilder.Entity("TestProject.Entities.GroceryList", b =>
                {
                    b.Navigation("GroceryEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
