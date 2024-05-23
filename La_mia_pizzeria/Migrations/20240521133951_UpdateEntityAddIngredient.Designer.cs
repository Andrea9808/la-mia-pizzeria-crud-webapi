﻿// <auto-generated />
using System;
using La_mia_pizzeria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace La_mia_pizzeria.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20240521133951_UpdateEntityAddIngredient")]
    partial class UpdateEntityAddIngredient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("La_mia_pizzeria.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("La_mia_pizzeria.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("La_mia_pizzeria.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("_description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("pizza_description");

                    b.Property<string>("_img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("pizza_img");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("pizza_name");

                    b.Property<decimal>("_price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("pizza_price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("IngredientId");

                    b.ToTable("pizza");
                });

            modelBuilder.Entity("La_mia_pizzeria.Models.Pizza", b =>
                {
                    b.HasOne("La_mia_pizzeria.Models.Category", "Categories")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoryId");

                    b.HasOne("La_mia_pizzeria.Models.Ingredient", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("IngredientId");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("La_mia_pizzeria.Models.Category", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("La_mia_pizzeria.Models.Ingredient", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}