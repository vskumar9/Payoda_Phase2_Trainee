using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalService.Migrations
{
    /// <inheritdoc />
    public partial class CarRentalDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RentalCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    VehicleId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rental_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminId", "CreatedDate", "Email", "FullName", "LastLoginDate", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { "A001", new DateTime(2024, 9, 6, 13, 55, 1, 383, DateTimeKind.Utc).AddTicks(4238), "admin.one@example.com", "Admin One", null, "$2a$11$u9XzeIehX4KIERSv9xaH7um6a0YweoVP/og8eiatk0w6WfIILkQRm", "admin1" },
                    { "A002", new DateTime(2024, 9, 6, 13, 55, 1, 604, DateTimeKind.Utc).AddTicks(416), "admin.two@example.com", "Admin Two", null, "$2a$11$lmM8t5XNOnFk6Ptcr1PCzOpRNdn/KtfrnIgoHtk8nsuCisyiSklYW", "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "DateOfBirth", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RegistrationDate" },
                values: new object[,]
                {
                    { "C001", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "sanjeev@example.com", "sanjeev", "kumar", "$2a$11$QJkNATBdJR/dgmVEi7ccoOxQgT/i6N7kwpPA.sVu2Qy9E9Lco/p9O", "1234567890", new DateTime(2024, 9, 6, 13, 55, 0, 473, DateTimeKind.Utc).AddTicks(5907) },
                    { "C002", new DateTime(1990, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sanjay@example.com", "sanjay", "ray", "$2a$11$TvNoOwq.u.vny7F2cOKEMuuFA4YW.neNmWnb/VtUhH//8uet8SW7K", "0987654321", new DateTime(2024, 9, 6, 13, 55, 0, 798, DateTimeKind.Utc).AddTicks(8027) }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "Color", "Make", "Model", "RentalCount", "Year" },
                values: new object[,]
                {
                    { "V001", "Blue", "Toyota", "Camry", 10, 2023 },
                    { "V002", "Red", "Honda", "Civic", 5, 2022 },
                    { "V003", "Black", "Ford", "Escape", 8, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Rental",
                columns: new[] { "RentalId", "Cost", "CustomerId", "RentalDate", "ReturnDate", "VehicleId" },
                values: new object[,]
                {
                    { "R001", 300.00m, "C001", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "V001" },
                    { "R002", 250.00m, "C002", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "V002" },
                    { "R003", 350.00m, "C001", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "V003" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Email",
                table: "Admin",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Username",
                table: "Admin",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CustomerId",
                table: "Rental",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_VehicleId",
                table: "Rental",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
