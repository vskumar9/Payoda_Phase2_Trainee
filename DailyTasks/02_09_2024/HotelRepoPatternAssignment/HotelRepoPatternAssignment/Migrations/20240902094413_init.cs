using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelRepoPatternAssignment.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: true),
                    RooomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "HotelId");
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "HotelId", "HotelName" },
                values: new object[,]
                {
                    { 1, "Thaj Mahal" },
                    { 2, "Munthaj Mahal" },
                    { 3, "Andhra Mahal" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomId", "HotelId", "Price", "RoomNumber", "RooomType" },
                values: new object[,]
                {
                    { 11, 1, 12000m, 101, "Luxury" },
                    { 12, 2, 12000m, 101, "Luxury" },
                    { 13, 3, 12000m, 101, "Luxury" },
                    { 14, 1, 12000m, 101, "Luxury" },
                    { 15, 2, 12000m, 101, "Luxury" },
                    { 16, 3, 12000m, 101, "Luxury" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
