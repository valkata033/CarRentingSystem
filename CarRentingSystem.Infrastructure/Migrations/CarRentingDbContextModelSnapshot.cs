﻿// <auto-generated />
using System;
using CarRentingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(CarRentingDbContext))]
    partial class CarRentingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3b38ec04-2125-45de-be67-3b365a7c7cd9",
                            Email = "dealer@mail.com",
                            EmailConfirmed = false,
                            FullName = "Dealer",
                            LockoutEnabled = false,
                            NormalizedEmail = "dealer@mail.com",
                            NormalizedUserName = "dealer@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAECDTRO5mu937CoINu0ji6b0jJ9eJWaWBIDoYyFXcTVSNa+bh+KaPyjxwNyuIsrBrlQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "57331a61-bc75-49b7-af8d-cae81129c62e",
                            TwoFactorEnabled = false,
                            UserName = "dealer@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "56266a5d-8052-48b7-b385-03d595defd8c",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            FullName = "Guest",
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEHGesrYwijz+t9EBqzlAogCjbQrMUjfJiBB5/ZTI5NjFbrSEu4AsnN5uCFiQYHmpbw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "069c7a03-88d7-4246-9622-769c52b5204c",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        });
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DealerId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "BMW",
                            CategoryId = 3,
                            DealerId = 2,
                            Description = "",
                            ImageUrl = "https://imgd.aeplcdn.com/0x0/ec/69/55/13232/img/l/BMW-5-Series-Front-view-27016.jpg?q=75",
                            Model = "530",
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            ReservationId = 1,
                            Year = 2014
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Mercedes",
                            CategoryId = 3,
                            DealerId = 2,
                            Description = "",
                            ImageUrl = "https://o.aolcdn.com/images/dims3/GLOB/legacy_thumbnail/800x450/format/jpg/quality/85/http://www.blogcdn.com/www.autoblog.com/media/2011/06/2012-mercedes-benz-c-class-coupe.jpg",
                            Model = "C 220",
                            Year = 2012
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Mercedes",
                            CategoryId = 3,
                            DealerId = 1,
                            Description = "",
                            ImageUrl = "https://paultan.org/image/2020/09/2021-W223-Mercedes-Benz-S-Class-White-9-1200x628.jpg",
                            Model = "S 500",
                            Year = 2020
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Mazda",
                            CategoryId = 1,
                            DealerId = 1,
                            Description = "",
                            ImageUrl = "https://hips.hearstapps.com/hmg-prod/amv-prod-cad-assets/wp-content/uploads/2018/01/2018-10Best-Trucks-SUVs-Mazda-CX-5-2p5L-lp.jpg?resize=480:*",
                            Model = "CX-5",
                            Year = 2019
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Porsche",
                            CategoryId = 5,
                            DealerId = 4,
                            Description = "",
                            ImageUrl = "https://www.auto-data.net/images/f15/file6121570.jpg",
                            Model = "911 Turbo S",
                            Year = 2017
                        },
                        new
                        {
                            Id = 6,
                            Brand = "BMW",
                            CategoryId = 6,
                            DealerId = 3,
                            Description = "",
                            ImageUrl = "http://hauteliving.com/wp-content/uploads/2014/07/M4_Coupe_127.jpg",
                            Model = "M3",
                            Year = 2015
                        });
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SUV"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hatchback"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Crossover"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sports Car"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Coupe"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Minivan"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Station Wagon"
                        });
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sofia"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Plovdiv"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Burgas"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Vidin"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Varna"
                        });
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Dealers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Luxury Cars",
                            PhoneNumber = "+359884588735",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Professional Rentals",
                            PhoneNumber = "+359887329454",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rental Central",
                            PhoneNumber = "+359885571323",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Deluxe Car Rentalss",
                            PhoneNumber = "+359889324572",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        });
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Dealership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adderss")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DealerId");

                    b.ToTable("Dealerships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adderss = "Sofia Airport",
                            CityId = 1,
                            DealerId = 1,
                            Name = "Sofia Dealership"
                        },
                        new
                        {
                            Id = 2,
                            Adderss = "Plovdiv Center",
                            CityId = 2,
                            DealerId = 2,
                            Name = "Plovdiv Dealership"
                        },
                        new
                        {
                            Id = 3,
                            Adderss = "Burgas Center",
                            CityId = 3,
                            DealerId = 3,
                            Name = "Burgas Dealership"
                        },
                        new
                        {
                            Id = 4,
                            Adderss = "Vidin Center",
                            CityId = 4,
                            DealerId = 4,
                            Name = "Vidin Dealership"
                        },
                        new
                        {
                            Id = 5,
                            Adderss = "Varna Center",
                            CityId = 5,
                            DealerId = 3,
                            Name = "Varna Dealership"
                        });
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2022, 11, 27, 20, 39, 21, 432, DateTimeKind.Local).AddTicks(321),
                            StartDate = new DateTime(2022, 11, 20, 20, 39, 21, 432, DateTimeKind.Local).AddTicks(287)
                        });
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.ReservationPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("ReservationPeriods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Days = 7,
                            Price = 200,
                            ReservationId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Car", b =>
                {
                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.Dealer", "Dealer")
                        .WithMany("Cars")
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.Reservation", "Reservation")
                        .WithMany("Cars")
                        .HasForeignKey("ReservationId");

                    b.Navigation("Category");

                    b.Navigation("Dealer");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Dealer", b =>
                {
                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Dealership", b =>
                {
                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.City", "City")
                        .WithMany("Dealerships")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.Dealer", "Dealer")
                        .WithMany()
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.ReservationPeriod", b =>
                {
                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.Reservation", "Reservation")
                        .WithMany("ReservationPeriods")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CarRentingSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.City", b =>
                {
                    b.Navigation("Dealerships");
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Dealer", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRentingSystem.Infrastructure.Data.Models.Reservation", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("ReservationPeriods");
                });
#pragma warning restore 612, 618
        }
    }
}
