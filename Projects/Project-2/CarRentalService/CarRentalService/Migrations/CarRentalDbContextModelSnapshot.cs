﻿// <auto-generated />
using System;
using CarRentalService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentalService.Migrations
{
    [DbContext(typeof(CarRentalDbContext))]
    partial class CarRentalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRentalService.Models.Admin", b =>
                {
                    b.Property<string>("AdminId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AdminId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Admin", (string)null);

                    b.HasData(
                        new
                        {
                            AdminId = "A001",
                            CreatedDate = new DateTime(2024, 9, 7, 12, 16, 43, 495, DateTimeKind.Utc).AddTicks(5136),
                            Email = "admin.one@example.com",
                            FullName = "Admin One",
                            PasswordHash = "$2a$11$K/NaxILlf0gW8NlKa829M.cTYKvibeeCYH5CVJKOoeYz4znmVlIBS",
                            Username = "admin1"
                        },
                        new
                        {
                            AdminId = "A002",
                            CreatedDate = new DateTime(2024, 9, 7, 12, 16, 43, 851, DateTimeKind.Utc).AddTicks(2609),
                            Email = "admin.two@example.com",
                            FullName = "Admin Two",
                            PasswordHash = "$2a$11$kcJzbhcaRzaqPxJyYR3TrOX7vOoxLJLrYsO/sUwf1YyJDQXUJgbxu",
                            Username = "admin2"
                        });
                });

            modelBuilder.Entity("CarRentalService.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", (string)null);

                    b.HasData(
                        new
                        {
                            CustomerId = "C001",
                            DateOfBirth = new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sanjeev@example.com",
                            FirstName = "sanjeev",
                            LastName = "kumar",
                            PasswordHash = "$2a$11$qGiS1sObOy0WhPKzH78zK.CowLpuuDdSjGe3ew5ccLNg/bv9z.wFO",
                            PhoneNumber = "1234567890",
                            RegistrationDate = new DateTime(2024, 9, 7, 12, 16, 42, 823, DateTimeKind.Utc).AddTicks(5586)
                        },
                        new
                        {
                            CustomerId = "C002",
                            DateOfBirth = new DateTime(1990, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sanjay@example.com",
                            FirstName = "sanjay",
                            LastName = "ray",
                            PasswordHash = "$2a$11$nNSIT1wViIEExwTzsHEBBeCcGFyLMlLZBD0K.eEAu44iuryi1y5Bm",
                            PhoneNumber = "0987654321",
                            RegistrationDate = new DateTime(2024, 9, 7, 12, 16, 43, 36, DateTimeKind.Utc).AddTicks(1275)
                        });
                });

            modelBuilder.Entity("CarRentalService.Models.Rental", b =>
                {
                    b.Property<string>("RentalId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RentalId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rental", (string)null);

                    b.HasData(
                        new
                        {
                            RentalId = "R001",
                            Cost = 300.00m,
                            CustomerId = "C001",
                            RentalDate = new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = "V001"
                        },
                        new
                        {
                            RentalId = "R002",
                            Cost = 250.00m,
                            CustomerId = "C002",
                            RentalDate = new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = "V002"
                        },
                        new
                        {
                            RentalId = "R003",
                            Cost = 350.00m,
                            CustomerId = "C001",
                            RentalDate = new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = "V003"
                        });
                });

            modelBuilder.Entity("CarRentalService.Models.Vehicle", b =>
                {
                    b.Property<string>("VehicleId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RentalCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicle", (string)null);

                    b.HasData(
                        new
                        {
                            VehicleId = "V001",
                            Color = "Blue",
                            Make = "Toyota",
                            Model = "Camry",
                            RentalCount = 10,
                            Year = 2023
                        },
                        new
                        {
                            VehicleId = "V002",
                            Color = "Red",
                            Make = "Honda",
                            Model = "Civic",
                            RentalCount = 5,
                            Year = 2022
                        },
                        new
                        {
                            VehicleId = "V003",
                            Color = "Black",
                            Make = "Ford",
                            Model = "Escape",
                            RentalCount = 8,
                            Year = 2021
                        });
                });

            modelBuilder.Entity("CarRentalService.Models.Rental", b =>
                {
                    b.HasOne("CarRentalService.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalService.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
