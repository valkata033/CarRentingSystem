using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    public partial class ReservationPeriodChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 9, 11, 58, 5, 537, DateTimeKind.Local).AddTicks(8805), new DateTime(2022, 12, 4, 11, 58, 5, 537, DateTimeKind.Local).AddTicks(8767) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 8, 14, 44, 33, 334, DateTimeKind.Local).AddTicks(8128), new DateTime(2022, 12, 3, 14, 44, 33, 334, DateTimeKind.Local).AddTicks(8093) });
        }
    }
}
