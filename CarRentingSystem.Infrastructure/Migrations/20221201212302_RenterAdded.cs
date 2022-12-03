using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    public partial class RenterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4078b0fd-3914-461c-8c6b-06bda682647d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed21a1e8-391b-42ff-9da3-1adee74725f2", "AQAAAAEAACcQAAAAEFPu5qLX+TO6hpUs2TzNi0S6ub5xS6S8fO3XVEK6n5Yhim5L7x8KxlTHnI22epz55A==", "348abf06-d329-46bb-ab54-1a514716d6e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "146083ac-9a01-47df-8f9d-76d5e8323c5e", "AQAAAAEAACcQAAAAEDWH8cJ/SvfT/DktBhMQnUs1jTYiqVXfwqIDMQnnfiwYUhIfY4pXZXHGqHZ8m8u0Qw==", "ac959ca8-0f9d-401b-9bfb-d22269a75088" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40fc5542-9b4a-4284-b705-bf946e0ca82e", "AQAAAAEAACcQAAAAEI/5JJQdDhxeD/l0x6xNjoxgBxzAf6n6xmak2QXECM+Na6dRtyQtt8DtkQtnBWHzsQ==", "3c80d114-8b43-4af0-8dde-7626a5f366cf" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 6, 23, 23, 2, 503, DateTimeKind.Local).AddTicks(9542), new DateTime(2022, 12, 1, 23, 23, 2, 503, DateTimeKind.Local).AddTicks(9507) });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RenterId",
                table: "Cars",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_RenterId",
                table: "Cars",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_RenterId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RenterId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4078b0fd-3914-461c-8c6b-06bda682647d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71533829-86e6-451c-8d78-eb0b3f9c57fa", "AQAAAAEAACcQAAAAEGaBIIfryHm7iL7P1XfLx5r4VeLBQUtK3iUYX4XcYI/h4SLMwBq8tgO7sANYI79imw==", "e00065c9-0da7-47ce-8f5b-3a9442e72174" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3246e941-5b1a-4518-8e91-db179b779286", "AQAAAAEAACcQAAAAECmsFnb2V/HK0BMJ+Qxh/PHPQfIyBARifj1Is16sb5fxenyWz0j6pbL3/7eIXycxUw==", "f375dc52-1fee-4b51-864a-4d1eab80af2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7d7a366-d18f-4fc2-95f9-d568154a081d", "AQAAAAEAACcQAAAAELqiSm7AoO+V4Bkn6aa2Gtx9zkYYDVbXupIu24VSFsZGvCUZ3/BBKi+fhs+bkxvXNA==", "95c698da-9429-4ed2-b7d5-154312628421" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 29, 20, 5, 27, 218, DateTimeKind.Local).AddTicks(1111), new DateTime(2022, 11, 24, 20, 5, 27, 218, DateTimeKind.Local).AddTicks(1074) });
        }
    }
}
