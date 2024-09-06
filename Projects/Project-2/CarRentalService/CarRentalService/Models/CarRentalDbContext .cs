using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CarRentalService.Models
{
    public class CarRentalDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Customer table
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.DateOfBirth);
                entity.Property(e => e.RegistrationDate).IsRequired();
            });

            // Seed Customer data
            modelBuilder.Entity<Customer>().HasData(
                new Customer {
                    CustomerId = "C001",
                    FirstName = "sanjeev",
                    LastName = "kumar",
                    Email = "sanjeev@example.com",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    RegistrationDate = DateTime.UtcNow,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123")},
                new Customer {
                    CustomerId = "C002",
                    FirstName = "sanjay",
                    LastName = "ray",
                    Email = "sanjay@example.com",
                    PhoneNumber = "0987654321",
                    DateOfBirth = new DateTime(1990, 11, 25),
                    RegistrationDate = DateTime.UtcNow,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("password456")});

            // Configure Vehicle table
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasKey(e => e.VehicleId);

                entity.Property(e => e.VehicleId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Make).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.Color).IsRequired().HasMaxLength(50);
                entity.Property(e => e.RentalCount).HasDefaultValue(0);
            });

            // Seed Vehicle data
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle {
                    VehicleId = "V001",
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2023,
                    Color = "Blue",
                    RentalCount = 10},
                new Vehicle {
                    VehicleId = "V002",
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2022,
                    Color = "Red",
                    RentalCount = 5},
                new Vehicle {
                    VehicleId = "V003",
                    Make = "Ford",
                    Model = "Escape",
                    Year = 2021,
                    Color = "Black",
                    RentalCount = 8});

            // Configure Rental table
            modelBuilder.Entity<Rental>(entity => {
                entity.ToTable("Rental");

                entity.HasKey(e => e.RentalId);

                entity.Property(e => e.RentalId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CustomerId).IsRequired();
                entity.Property(e => e.VehicleId).IsRequired();
                entity.Property(e => e.RentalDate).IsRequired();
                entity.Property(e => e.ReturnDate);
                entity.Property(e => e.Cost).IsRequired();

                entity.HasOne(e => e.Customer)
                    .WithMany()
                    .HasForeignKey(e => e.CustomerId);

                entity.HasOne(e => e.Vehicle)
                    .WithMany()
                    .HasForeignKey(e => e.VehicleId);});

            // Seed Rental data
            modelBuilder.Entity<Rental>().HasData(
                new Rental {
                    RentalId = "R001",
                    CustomerId = "C001",
                    VehicleId = "V001",
                    RentalDate = new DateTime(2024, 8, 1),
                    ReturnDate = new DateTime(2024, 8, 10),
                    Cost = 300.00m},
                new Rental {
                    RentalId = "R002",
                    CustomerId = "C002",
                    VehicleId = "V002",
                    RentalDate = new DateTime(2024, 8, 15),
                    ReturnDate = new DateTime(2024, 8, 20),
                    Cost = 250.00m},

                new Rental {
                    RentalId = "R003",
                    CustomerId = "C001",
                    VehicleId = "V003",
                    RentalDate = new DateTime(2024, 9, 1),
                    ReturnDate = new DateTime(2024, 8, 20),
                    Cost = 350.00m});


            // Configure Admin table
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasKey(e => e.AdminId);

                entity.Property(e => e.AdminId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.LastLoginDate);

                // Set unique constraints
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Seed Admin data
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminId = "A001",
                    Username = "admin1",
                    FullName = "Admin One",
                    Email = "admin.one@example.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("adminpassword123"),
                    CreatedDate = DateTime.UtcNow},
                new Admin {
                    AdminId = "A002",
                    Username = "admin2",
                    FullName = "Admin Two",
                    Email = "admin.two@example.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("adminpassword456"),
                    CreatedDate = DateTime.UtcNow
                });




        }
    }
}
