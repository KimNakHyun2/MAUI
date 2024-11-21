﻿// <auto-generated />
using System;
using Icecream.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Icecream.API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Icecream.API.Data.Entities.IceCream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Icecreams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_0.jpg",
                            Name = "Vanilla Delight",
                            Price = 6.25
                        },
                        new
                        {
                            Id = 2,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_1.jpg",
                            Name = "ChocoBerry Bliss",
                            Price = 7.5
                        },
                        new
                        {
                            Id = 3,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_2.jpg",
                            Name = "Minty Cookie Crunch",
                            Price = 8.75
                        },
                        new
                        {
                            Id = 4,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_3.jpg",
                            Name = "Strawberry Dream",
                            Price = 6.9500000000000002
                        },
                        new
                        {
                            Id = 5,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_4.jpg",
                            Name = "Cookie Dough Extravaganza",
                            Price = 9.1999999999999993
                        },
                        new
                        {
                            Id = 6,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_5.jpg",
                            Name = "Caramel Swirl Symphony",
                            Price = 7.75
                        },
                        new
                        {
                            Id = 7,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_6.jpg",
                            Name = "Peanut Butter Paradise",
                            Price = 8.5
                        },
                        new
                        {
                            Id = 8,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_7.jpg",
                            Name = "Mango Tango Tango",
                            Price = 9.8000000000000007
                        },
                        new
                        {
                            Id = 9,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_8.jpg",
                            Name = "Hazelnut Heaven",
                            Price = 8.9499999999999993
                        },
                        new
                        {
                            Id = 10,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_9.jpg",
                            Name = "Blueberry Bliss Bonanza",
                            Price = 7.2000000000000002
                        },
                        new
                        {
                            Id = 11,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_10.jpg",
                            Name = "Toffee Twist Temptation",
                            Price = 7.9500000000000002
                        },
                        new
                        {
                            Id = 12,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_11.jpg",
                            Name = "Rocky Road Revelry",
                            Price = 9.5
                        },
                        new
                        {
                            Id = 13,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_12.jpg",
                            Name = "Passionfruit Paradise",
                            Price = 8.75
                        },
                        new
                        {
                            Id = 14,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_13.jpg",
                            Name = "Cotton Candy Carnival",
                            Price = 7.2000000000000002
                        },
                        new
                        {
                            Id = 15,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_14.jpg",
                            Name = "Lemon Sorbet Serenity",
                            Price = 6.9000000000000004
                        },
                        new
                        {
                            Id = 16,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_15.jpg",
                            Name = "Maple Pecan Pleasure",
                            Price = 8.25
                        },
                        new
                        {
                            Id = 17,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_16.jpg",
                            Name = "Raspberry Ripple Rhapsody",
                            Price = 7.4500000000000002
                        },
                        new
                        {
                            Id = 18,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_17.jpg",
                            Name = "Almond Joyful Jubilee",
                            Price = 9.9499999999999993
                        },
                        new
                        {
                            Id = 19,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_18.jpg",
                            Name = "Blue Lagoon Blists",
                            Price = 8.5
                        },
                        new
                        {
                            Id = 20,
                            Image = "https://raw.githubusercontent.com/KimNakHyun2/Image-Icons/main/icecream/main/ic_19.jpg",
                            Name = "Coconut Caramel Carnival",
                            Price = 7.7999999999999998
                        });
                });

            modelBuilder.Entity("Icecream.API.Data.Entities.IcecreamOption", b =>
                {
                    b.Property<int>("IcecreamId")
                        .HasColumnType("int");

                    b.Property<string>("Flavor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Topping")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IcecreamId", "Flavor", "Topping");

                    b.ToTable("IcecreamOptions");

                    b.HasData(
                        new
                        {
                            IcecreamId = 1,
                            Flavor = "Vanilla",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 1,
                            Flavor = "Default",
                            Topping = "Chocolate Sauce"
                        },
                        new
                        {
                            IcecreamId = 1,
                            Flavor = "Default",
                            Topping = "Whipped Cream"
                        },
                        new
                        {
                            IcecreamId = 2,
                            Flavor = "Vanilla",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 2,
                            Flavor = "Strawberry",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 2,
                            Flavor = "Default",
                            Topping = "Sprinkles"
                        },
                        new
                        {
                            IcecreamId = 3,
                            Flavor = "Mint Chocolate Chip",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 3,
                            Flavor = "Default",
                            Topping = "Cherries"
                        },
                        new
                        {
                            IcecreamId = 3,
                            Flavor = "Default",
                            Topping = "Chocolate Sauce"
                        },
                        new
                        {
                            IcecreamId = 4,
                            Flavor = "Strawberry",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 4,
                            Flavor = "Default",
                            Topping = "Sprinkles"
                        },
                        new
                        {
                            IcecreamId = 4,
                            Flavor = "Default",
                            Topping = "Whipped Cream"
                        },
                        new
                        {
                            IcecreamId = 5,
                            Flavor = "Cooke Dough",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 5,
                            Flavor = "Default",
                            Topping = "Chocolate Sauce"
                        },
                        new
                        {
                            IcecreamId = 5,
                            Flavor = "Default",
                            Topping = "Cherries"
                        },
                        new
                        {
                            IcecreamId = 6,
                            Flavor = "Vanilla",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 6,
                            Flavor = "Default",
                            Topping = "Chocolate Sauce"
                        },
                        new
                        {
                            IcecreamId = 6,
                            Flavor = "Default",
                            Topping = "Cherries"
                        },
                        new
                        {
                            IcecreamId = 7,
                            Flavor = "Chocolate",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 7,
                            Flavor = "Default",
                            Topping = "Whipped Cream"
                        },
                        new
                        {
                            IcecreamId = 7,
                            Flavor = "Default",
                            Topping = "Sprinkles"
                        },
                        new
                        {
                            IcecreamId = 8,
                            Flavor = "Strawberry",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 8,
                            Flavor = "Cooke Dough",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 8,
                            Flavor = "Default",
                            Topping = "Sprinkles"
                        },
                        new
                        {
                            IcecreamId = 9,
                            Flavor = "Mint Chocolate Chip",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 9,
                            Flavor = "Default",
                            Topping = "Chocolate Sauce"
                        },
                        new
                        {
                            IcecreamId = 9,
                            Flavor = "Default",
                            Topping = "Whipped Cream"
                        },
                        new
                        {
                            IcecreamId = 10,
                            Flavor = "Chocolate",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 10,
                            Flavor = "Strawberry",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 10,
                            Flavor = "Default",
                            Topping = "Cherries"
                        },
                        new
                        {
                            IcecreamId = 11,
                            Flavor = "Vanilla",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 11,
                            Flavor = "Default",
                            Topping = "Whipped Cream"
                        },
                        new
                        {
                            IcecreamId = 11,
                            Flavor = "Default",
                            Topping = "Cherries"
                        },
                        new
                        {
                            IcecreamId = 12,
                            Flavor = "Chocolate",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 12,
                            Flavor = "Mint Chocolate Chip",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 12,
                            Flavor = "Default",
                            Topping = "Chocolate Sauce"
                        },
                        new
                        {
                            IcecreamId = 13,
                            Flavor = "Strawberry",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 13,
                            Flavor = "Default",
                            Topping = "Sprinkles"
                        },
                        new
                        {
                            IcecreamId = 13,
                            Flavor = "Default",
                            Topping = "Whipped Cream"
                        },
                        new
                        {
                            IcecreamId = 14,
                            Flavor = "Cooke Dough",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 14,
                            Flavor = "Default",
                            Topping = "Chocolate Sauce"
                        },
                        new
                        {
                            IcecreamId = 14,
                            Flavor = "Default",
                            Topping = "Cherries"
                        },
                        new
                        {
                            IcecreamId = 15,
                            Flavor = "Vanilla",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 15,
                            Flavor = "Strawberry",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 15,
                            Flavor = "Default",
                            Topping = "Sprinkles"
                        },
                        new
                        {
                            IcecreamId = 16,
                            Flavor = "Chocolate",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 16,
                            Flavor = "Mint Chocolate Chip",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 16,
                            Flavor = "Default",
                            Topping = "Whipped Cream"
                        },
                        new
                        {
                            IcecreamId = 17,
                            Flavor = "Strawberry",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 17,
                            Flavor = "Cooke Dough",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 17,
                            Flavor = "Default",
                            Topping = "Chocolate Sauce"
                        },
                        new
                        {
                            IcecreamId = 18,
                            Flavor = "Vanilla",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 18,
                            Flavor = "Default",
                            Topping = "Sprinkles"
                        },
                        new
                        {
                            IcecreamId = 18,
                            Flavor = "Default",
                            Topping = "Cherries"
                        },
                        new
                        {
                            IcecreamId = 19,
                            Flavor = "Chocolate",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 19,
                            Flavor = "Strawberry",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 19,
                            Flavor = "Default",
                            Topping = "Whipped Cream"
                        },
                        new
                        {
                            IcecreamId = 20,
                            Flavor = "Mint Chocolate Chip",
                            Topping = "Default"
                        },
                        new
                        {
                            IcecreamId = 20,
                            Flavor = "Default",
                            Topping = "Chocolate Sauce"
                        },
                        new
                        {
                            IcecreamId = 20,
                            Flavor = "Default",
                            Topping = "Sprinkles"
                        });
                });

            modelBuilder.Entity("Icecream.API.Data.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("OrderAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Icecream.API.Data.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Flavor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IcecreamId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Topping")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Icecream.API.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Icecream.API.Data.Entities.IcecreamOption", b =>
                {
                    b.HasOne("Icecream.API.Data.Entities.IceCream", "Icecream")
                        .WithMany("Options")
                        .HasForeignKey("IcecreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Icecream");
                });

            modelBuilder.Entity("Icecream.API.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("Icecream.API.Data.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Icecream.API.Data.Entities.IceCream", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Icecream.API.Data.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
