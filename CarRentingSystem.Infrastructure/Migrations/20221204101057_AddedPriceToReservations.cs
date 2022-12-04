using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    public partial class AddedPriceToReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ReservationPeriods");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ReservationPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4078b0fd-3914-461c-8c6b-06bda682647d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2640a62-16ec-4e63-b423-c675e7389b12", "AQAAAAEAACcQAAAAEF5iqC6OPSLrAPBPFcPFM5VfliEBH+SCl59ACAYGwCTsuxZrREVWRMxGCnFcjTZE2Q==", "ffee41f3-1199-4290-b775-59ab33a7f697" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f96b2def-9694-4a29-b16a-6095666bf4bd", "AQAAAAEAACcQAAAAEPcfMGp0N5AGTR5QK5j/36FdgTiJpBhe53TZYLfiycmriNMTG6ktIJ4rv8/1m8+lwg==", "89d96dfb-224f-4f09-87ad-0577ccf3e15c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24994c87-0906-4c4b-8d84-1e248029cae6", "AQAAAAEAACcQAAAAELpN4XOXOQ8y7QN7DOUZt4LVjIKCuHNcfc033Cd03IYgvg4ypjzj8isoNsfqMVYt8Q==", "234d4ae0-ca88-493f-9646-eba02d48b9d5" });

            migrationBuilder.UpdateData(
                table: "ReservationPeriods",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ReservationPeriods",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ReservationPeriods",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 500);

            migrationBuilder.UpdateData(
                table: "ReservationPeriods",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 1500);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 9, 11, 58, 5, 537, DateTimeKind.Local).AddTicks(8805), new DateTime(2022, 12, 4, 11, 58, 5, 537, DateTimeKind.Local).AddTicks(8767) });
        }
    }
}
