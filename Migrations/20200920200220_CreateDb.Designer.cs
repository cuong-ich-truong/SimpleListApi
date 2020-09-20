﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleListApi.Contexts;

namespace SimpleListApi.Migrations
{
    [DbContext(typeof(SimpleListContext))]
    [Migration("20200920200220_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("SimpleListApi.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1636d3c8-fc9e-4f5d-a8ee-80c1c44509f4"),
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = new Guid("b90cfb66-06eb-416e-a8eb-4e78fbf3ecb7"),
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"),
                            Name = "Kitchen"
                        });
                });

            modelBuilder.Entity("SimpleListApi.Models.LineItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("LineItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1355a30f-e2d9-47fb-85f0-ab33bfb0d1e2"),
                            CategoryId = new Guid("1636d3c8-fc9e-4f5d-a8ee-80c1c44509f4"),
                            Name = "TV",
                            Price = 2000m
                        },
                        new
                        {
                            Id = new Guid("574d69e3-0571-4273-8128-71b2f1e30a4d"),
                            CategoryId = new Guid("1636d3c8-fc9e-4f5d-a8ee-80c1c44509f4"),
                            Name = "Playstation",
                            Price = 400m
                        },
                        new
                        {
                            Id = new Guid("5a666b42-0736-40a2-a3f7-372daec8da01"),
                            CategoryId = new Guid("1636d3c8-fc9e-4f5d-a8ee-80c1c44509f4"),
                            Name = "Stereo",
                            Price = 1600m
                        },
                        new
                        {
                            Id = new Guid("d644804f-26bf-4b33-8f92-6e8d912bfae0"),
                            CategoryId = new Guid("b90cfb66-06eb-416e-a8eb-4e78fbf3ecb7"),
                            Name = "Shirts",
                            Price = 1100m
                        },
                        new
                        {
                            Id = new Guid("9364175f-9f25-4ed6-89da-0668e2f5fe3e"),
                            CategoryId = new Guid("b90cfb66-06eb-416e-a8eb-4e78fbf3ecb7"),
                            Name = "Jeans",
                            Price = 1100m
                        },
                        new
                        {
                            Id = new Guid("b8573bc1-349f-47bc-a052-e50eef1d9b95"),
                            CategoryId = new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"),
                            Name = "Pots and Pans",
                            Price = 3000m
                        },
                        new
                        {
                            Id = new Guid("1a1f26ab-11f2-4b1d-9ba4-917b9740fa81"),
                            CategoryId = new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"),
                            Name = "Flatware",
                            Price = 500m
                        },
                        new
                        {
                            Id = new Guid("db62b4a5-9ced-46be-aeb6-4ddff612a6c4"),
                            CategoryId = new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"),
                            Name = "Knife Set",
                            Price = 500m
                        },
                        new
                        {
                            Id = new Guid("c11da0e2-6b98-496c-aead-d75a6019d650"),
                            CategoryId = new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"),
                            Name = "Mics",
                            Price = 1000m
                        });
                });

            modelBuilder.Entity("SimpleListApi.Models.LineItem", b =>
                {
                    b.HasOne("SimpleListApi.Models.Category", "Category")
                        .WithMany("LineItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}