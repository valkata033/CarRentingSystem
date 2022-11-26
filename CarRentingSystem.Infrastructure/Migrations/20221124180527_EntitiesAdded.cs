using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dealers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MakeYear = table.Column<int>(type: "int", nullable: false),
                    Gearbox = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dealerships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adderss = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealerships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dealerships_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dealerships_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ReservationPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationPeriods_ReservationPeriodId",
                        column: x => x.ReservationPeriodId,
                        principalTable: "ReservationPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4078b0fd-3914-461c-8c6b-06bda682647d", 0, "71533829-86e6-451c-8d78-eb0b3f9c57fa", "LuxuryDealer@abv.bg", false, "Luxury Dealer", false, null, "LuxuryDealer@abv.bg", "dealer123", "AQAAAAEAACcQAAAAEGaBIIfryHm7iL7P1XfLx5r4VeLBQUtK3iUYX4XcYI/h4SLMwBq8tgO7sANYI79imw==", null, false, "e00065c9-0da7-47ce-8f5b-3a9442e72174", false, "dealer123" },
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "3246e941-5b1a-4518-8e91-db179b779286", "guest@mail.com", false, "Guest", false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAECmsFnb2V/HK0BMJ+Qxh/PHPQfIyBARifj1Is16sb5fxenyWz0j6pbL3/7eIXycxUw==", null, false, "f375dc52-1fee-4b51-864a-4d1eab80af2e", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "b7d7a366-d18f-4fc2-95f9-d568154a081d", "dealer@mail.com", false, "Dealer", false, null, "dealer@mail.com", "dealer@mail.com", "AQAAAAEAACcQAAAAELqiSm7AoO+V4Bkn6aa2Gtx9zkYYDVbXupIu24VSFsZGvCUZ3/BBKi+fhs+bkxvXNA==", null, false, "95c698da-9429-4ed2-b7d5-154312628421", false, "dealer@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SUV" },
                    { 2, "Hatchback" },
                    { 3, "Sedan" },
                    { 4, "Crossover" },
                    { 5, "Sports Car" },
                    { 6, "Coupe" },
                    { 7, "Minivan" },
                    { 8, "Station Wagon" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia" },
                    { 2, "Plovdiv" },
                    { 3, "Burgas" },
                    { 4, "Vidin" },
                    { 5, "Varna" }
                });

            migrationBuilder.InsertData(
                table: "ReservationPeriods",
                columns: new[] { "Id", "Days", "Price" },
                values: new object[,]
                {
                    { 1, 3, 50 },
                    { 2, 5, 250 },
                    { 3, 10, 500 },
                    { 4, 30, 1500 }
                });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "Name", "PhoneNumber", "UserId" },
                values: new object[] { 1, "Luxury Cars", "+359884588735", "4078b0fd-3914-461c-8c6b-06bda682647d" });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "Name", "PhoneNumber", "UserId" },
                values: new object[] { 2, "Professional Rentals", "+359887329454", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CategoryId", "DealerId", "Description", "FuelType", "Gearbox", "ImageUrl", "MakeYear", "Model", "PricePerDay", "RenterId" },
                values: new object[,]
                {
                    { 1, "BMW", 3, 2, "Very good car for youngth renter or for family.", 1, 0, "https://imgd.aeplcdn.com/0x0/ec/69/55/13232/img/l/BMW-5-Series-Front-view-27016.jpg?q=75", 2014, "530", 50, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 2, "Mercedes", 3, 2, "Very good car for family.", 1, 1, "https://o.aolcdn.com/images/dims3/GLOB/legacy_thumbnail/800x450/format/jpg/quality/85/http://www.blogcdn.com/www.autoblog.com/media/2011/06/2012-mercedes-benz-c-class-coupe.jpg", 2012, "C 220", 35, null },
                    { 3, "Mercedes", 3, 1, "Very luxury car for rich people.", 0, 1, "https://paultan.org/image/2020/09/2021-W223-Mercedes-Benz-S-Class-White-9-1200x628.jpg", 2020, "S 500", 100, null },
                    { 4, "Mazda", 1, 1, "Very good for family car.", 0, 0, "https://hips.hearstapps.com/hmg-prod/amv-prod-cad-assets/wp-content/uploads/2018/01/2018-10Best-Trucks-SUVs-Mazda-CX-5-2p5L-lp.jpg?resize=480:*", 2019, "CX-5", 80, null },
                    { 5, "Porsche", 5, 1, "Very fast car for people who want to make some new advantures.", 0, 1, "https://www.auto-data.net/images/f15/file6121570.jpg", 2017, "911 Turbo S", 110, null },
                    { 6, "BMW", 6, 2, "Very good car for youngth people and people who want to make some new advantures.", 1, 0, "http://hauteliving.com/wp-content/uploads/2014/07/M4_Coupe_127.jpg", 2015, "M3", 75, null }
                });

            migrationBuilder.InsertData(
                table: "Dealerships",
                columns: new[] { "Id", "Adderss", "CityId", "DealerId", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia Airport", 1, 1, "Sofia Dealership" },
                    { 2, "Plovdiv Center", 2, 2, "Plovdiv Dealership" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CarId", "EndDate", "ReservationPeriodId", "StartDate" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 29, 20, 5, 27, 218, DateTimeKind.Local).AddTicks(1111), 2, new DateTime(2022, 11, 24, 20, 5, 27, 218, DateTimeKind.Local).AddTicks(1074) });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DealerId",
                table: "Cars",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_CityId",
                table: "Dealerships",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_DealerId",
                table: "Dealerships",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationPeriodId",
                table: "Reservations",
                column: "ReservationPeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "ReservationPeriods");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4078b0fd-3914-461c-8c6b-06bda682647d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
