using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    public partial class AddedIsActiveToReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4078b0fd-3914-461c-8c6b-06bda682647d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bd3d75b-822c-4633-bc3d-c113567ec538", "AQAAAAEAACcQAAAAEO6gAB/AUFRBtEMyDv5cPLfUq+Smf9IxEao684fcSfYS+FrPDcoRP1eFeOG9StnqvQ==", "e51df23e-2d59-4592-a475-4900f8457bc3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59678593-1560-46db-8c2e-7cd28671a09e", "AQAAAAEAACcQAAAAEG+MZiQyVdZpHqxtCok+v/Ef6rlQxuTUnK3/DNzrsBIdwhDvqJRk446dOtVee12jvg==", "1366be58-2884-4fc9-80eb-61dd6a9bdaf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ed4dfd3-bdbe-4f25-ae38-333cd5154d01", "AQAAAAEAACcQAAAAEF4N1KflI2XN2uWabUgl/4jS4KsuYnbYAGECUdsbGYVY29hpEPkiQkVni7gAJadqdw==", "23ee8206-dc32-4935-a6f7-70bd46e9f7fe" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 9, 12, 18, 34, 60, DateTimeKind.Local).AddTicks(357), new DateTime(2022, 12, 4, 12, 18, 34, 60, DateTimeKind.Local).AddTicks(313) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4078b0fd-3914-461c-8c6b-06bda682647d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d456a835-c1dc-41e4-8072-3607b6469094", "AQAAAAEAACcQAAAAELqBS5//oNox1IJTQYnFCD14E7HI+mPiA8bkNZkCV/s8dnNsWtgfzjHSqs5hAAACNQ==", "d4f9ef9d-7dec-43f5-8620-3d198299e58f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb056982-d71d-4ae6-b9d3-57c332777ec7", "AQAAAAEAACcQAAAAEJE/eO895Pl2IclimhNQNaprNJ8PJMGJuxM7T7hgetewX76q3D20b3DDXaOV7Y2sBQ==", "8a9dceed-f6e4-450e-8743-e17c0b0410a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf4bc03d-6d1f-4298-8d08-15fe939631d9", "AQAAAAEAACcQAAAAEHqXGIAjQ34GIKIpUKwAaovWWBh3lKeNPkcNsUACiST/D6XkZsh836UZvIjphoTZVg==", "a84de8f7-2037-4d37-af1a-c566784d4819" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 9, 12, 10, 56, 641, DateTimeKind.Local).AddTicks(5966), new DateTime(2022, 12, 4, 12, 10, 56, 641, DateTimeKind.Local).AddTicks(5930) });
        }
    }
}
