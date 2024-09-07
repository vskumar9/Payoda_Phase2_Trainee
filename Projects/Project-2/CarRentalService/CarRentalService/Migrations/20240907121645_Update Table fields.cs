using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablefields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "Customer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: "A001",
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 7, 12, 16, 43, 495, DateTimeKind.Utc).AddTicks(5136), "$2a$11$K/NaxILlf0gW8NlKa829M.cTYKvibeeCYH5CVJKOoeYz4znmVlIBS" });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: "A002",
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 7, 12, 16, 43, 851, DateTimeKind.Utc).AddTicks(2609), "$2a$11$kcJzbhcaRzaqPxJyYR3TrOX7vOoxLJLrYsO/sUwf1YyJDQXUJgbxu" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: "C001",
                columns: new[] { "LastLoginDate", "PasswordHash", "RegistrationDate" },
                values: new object[] { null, "$2a$11$qGiS1sObOy0WhPKzH78zK.CowLpuuDdSjGe3ew5ccLNg/bv9z.wFO", new DateTime(2024, 9, 7, 12, 16, 42, 823, DateTimeKind.Utc).AddTicks(5586) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: "C002",
                columns: new[] { "LastLoginDate", "PasswordHash", "RegistrationDate" },
                values: new object[] { null, "$2a$11$nNSIT1wViIEExwTzsHEBBeCcGFyLMlLZBD0K.eEAu44iuryi1y5Bm", new DateTime(2024, 9, 7, 12, 16, 43, 36, DateTimeKind.Utc).AddTicks(1275) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "Customer");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: "A001",
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 6, 13, 55, 1, 383, DateTimeKind.Utc).AddTicks(4238), "$2a$11$u9XzeIehX4KIERSv9xaH7um6a0YweoVP/og8eiatk0w6WfIILkQRm" });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: "A002",
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 6, 13, 55, 1, 604, DateTimeKind.Utc).AddTicks(416), "$2a$11$lmM8t5XNOnFk6Ptcr1PCzOpRNdn/KtfrnIgoHtk8nsuCisyiSklYW" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: "C001",
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "$2a$11$QJkNATBdJR/dgmVEi7ccoOxQgT/i6N7kwpPA.sVu2Qy9E9Lco/p9O", new DateTime(2024, 9, 6, 13, 55, 0, 473, DateTimeKind.Utc).AddTicks(5907) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: "C002",
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "$2a$11$TvNoOwq.u.vny7F2cOKEMuuFA4YW.neNmWnb/VtUhH//8uet8SW7K", new DateTime(2024, 9, 6, 13, 55, 0, 798, DateTimeKind.Utc).AddTicks(8027) });
        }
    }
}
