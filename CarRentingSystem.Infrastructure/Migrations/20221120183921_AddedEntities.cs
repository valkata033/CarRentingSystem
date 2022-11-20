using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    public partial class AddedEntities : Migration
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
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
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
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Cars_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservationPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationPeriods_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "56266a5d-8052-48b7-b385-03d595defd8c", "guest@mail.com", false, "Guest", false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEHGesrYwijz+t9EBqzlAogCjbQrMUjfJiBB5/ZTI5NjFbrSEu4AsnN5uCFiQYHmpbw==", null, false, "069c7a03-88d7-4246-9622-769c52b5204c", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "3b38ec04-2125-45de-be67-3b365a7c7cd9", "dealer@mail.com", false, "Dealer", false, null, "dealer@mail.com", "dealer@mail.com", "AQAAAAEAACcQAAAAECDTRO5mu937CoINu0ji6b0jJ9eJWaWBIDoYyFXcTVSNa+bh+KaPyjxwNyuIsrBrlQ==", null, false, "57331a61-bc75-49b7-af8d-cae81129c62e", false, "dealer@mail.com" }
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
                table: "Reservations",
                columns: new[] { "Id", "EndDate", "StartDate" },
                values: new object[] { 1, new DateTime(2022, 11, 27, 20, 39, 21, 432, DateTimeKind.Local).AddTicks(321), new DateTime(2022, 11, 20, 20, 39, 21, 432, DateTimeKind.Local).AddTicks(287) });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "Luxury Cars", "+359884588735", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "Professional Rentals", "+359887329454", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 3, "Rental Central", "+359885571323", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 4, "Deluxe Car Rentalss", "+359889324572", "dea12856-c198-4129-b3f3-b893d8395082" }
                });

            migrationBuilder.InsertData(
                table: "ReservationPeriods",
                columns: new[] { "Id", "Days", "Price", "ReservationId" },
                values: new object[] { 1, 7, 200, 1 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CategoryId", "DealerId", "Description", "ImageUrl", "Model", "RenterId", "ReservationId", "Year" },
                values: new object[,]
                {
                    { 1, "BMW", 3, 2, "", "https://imgd.aeplcdn.com/0x0/ec/69/55/13232/img/l/BMW-5-Series-Front-view-27016.jpg?q=75", "530", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 1, 2014 },
                    { 2, "Mercedes", 3, 2, "", "https://o.aolcdn.com/images/dims3/GLOB/legacy_thumbnail/800x450/format/jpg/quality/85/http://www.blogcdn.com/www.autoblog.com/media/2011/06/2012-mercedes-benz-c-class-coupe.jpg", "C 220", null, null, 2012 },
                    { 3, "Mercedes", 3, 1, "", "https://paultan.org/image/2020/09/2021-W223-Mercedes-Benz-S-Class-White-9-1200x628.jpg", "S 500", null, null, 2020 },
                    { 4, "Mazda", 1, 1, "", "https://hips.hearstapps.com/hmg-prod/amv-prod-cad-assets/wp-content/uploads/2018/01/2018-10Best-Trucks-SUVs-Mazda-CX-5-2p5L-lp.jpg?resize=480:*", "CX-5", null, null, 2019 },
                    { 5, "Porsche", 5, 4, "", "https://www.auto-data.net/images/f15/file6121570.jpg", "911 Turbo S", null, null, 2017 },
                    { 6, "BMW", 6, 3, "", "http://hauteliving.com/wp-content/uploads/2014/07/M4_Coupe_127.jpg", "M3", null, null, 2015 }
                });

            migrationBuilder.InsertData(
                table: "Dealerships",
                columns: new[] { "Id", "Adderss", "CityId", "DealerId", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia Airport", 1, 1, "Sofia Dealership" },
                    { 2, "Plovdiv Center", 2, 2, "Plovdiv Dealership" },
                    { 3, "Burgas Center", 3, 3, "Burgas Dealership" },
                    { 4, "Vidin Center", 4, 4, "Vidin Dealership" },
                    { 5, "Varna Center", 5, 3, "Varna Dealership" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DealerId",
                table: "Cars",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ReservationId",
                table: "Cars",
                column: "ReservationId");

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
                name: "IX_ReservationPeriods_ReservationId",
                table: "ReservationPeriods",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropTable(
                name: "ReservationPeriods");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

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
