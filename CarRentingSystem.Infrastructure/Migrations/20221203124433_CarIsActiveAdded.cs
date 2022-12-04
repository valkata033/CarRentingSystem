using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    public partial class CarIsActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4078b0fd-3914-461c-8c6b-06bda682647d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c848a820-ce55-4985-8478-a0401d821214", "AQAAAAEAACcQAAAAEFPbSaqRF27FhU8e3+r+cKU6N+TDy4UAx7dK4eapgLUj6Vi0NJWtPWREMzRnJuhXMQ==", "cba8f8ce-9663-4aee-90c9-3e9cdbf52d90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6cfd9f7-8b38-4691-bde4-65095fe85ab7", "AQAAAAEAACcQAAAAEERd8YIz3peSZbQVugZhkmHY85hWxAFUKe56SIabu6O9+7HUSb1BirS7/uKuLeUucw==", "72bd2371-973b-4218-ae58-1c34a2ac6874" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a4c1405-9577-4708-8ff1-02012120d578", "AQAAAAEAACcQAAAAEEzGD19y1ruYsS6FAO3nIi/DL6wz/i/WNivms1LnNpoBZltkAeIoi4FlfwQ7keMbRg==", "d32dbd6c-060d-4234-984b-a8a93bb3f1d0" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 14, 44, 33, 334, DateTimeKind.Local).AddTicks(8128), new DateTime(2022, 12, 3, 14, 44, 33, 334, DateTimeKind.Local).AddTicks(8093) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cars");

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
        }
    }
}
