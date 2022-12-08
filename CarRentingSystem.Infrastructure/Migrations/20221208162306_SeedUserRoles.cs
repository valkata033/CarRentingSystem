using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eff399e-8200-43c8-b58d-f790d528f98b", "d21d75c0-e85b-4ed3-b69b-fe62a93299c1", "Administrator", "ADMINISTRATOR" },
                    { "20be60b0-71ee-4297-ad72-4e4ca05b2fc8", "e1de8b7d-1975-4210-ae6f-b7b585e4e086", "User", "USER" },
                    { "9390e3f1-821d-4d96-b3bb-397d373b7b04", "5823a48a-b52a-4af7-8f5a-3cee87997481", "Dealer", "DEALER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4078b0fd-3914-461c-8c6b-06bda682647d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c82129f-46e6-4a31-8a13-52f52a817555", "AQAAAAEAACcQAAAAEGsJZ9napR2KDb8vGF0ipwgTwViQLn1w/oqGDmLn5KE3bFuqlyrPO3uQH7eSkmzvFA==", "f96bff04-b060-4ff0-934c-a658d06bc4a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8a2cb93-242d-42d6-949f-8628289842c9", "AQAAAAEAACcQAAAAEGYPKEXbmjQqgLv9uE4fwMGfcISsvSdJDXvXD1gt4506NV4qst1kyFd9pIDKmuYaZg==", "43302b8f-0d80-4751-b25b-18acc10c1020" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d017e33-4ce4-4b78-9df6-cfdd6c40f2fe", "AQAAAAEAACcQAAAAEPh/vS/lZ8klOJ/s2Q68Hdff/4xQwJ7bPvclKZkz48XorJzsDDVIsdosSWRr3dmvEA==", "9f95cdee-696e-4e29-a517-8c2dcfa37b50" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcc313a0-a38a-42a2-a42c-d00f09a89c5f", 0, "44955139-1f8d-4821-bd01-76bac3a0b742", "gosho123@abv.bg", false, "Georgi Peshev", false, null, "GOSHO123@ABV.BG", "ADMIN", "AQAAAAEAACcQAAAAEH/UZ9dTc+JuycUugu/ByFtQAGN1KPOccOA0mr3bRVZX4LSU1ggj77ngBZD/Kk6NqQ==", null, false, "af44cff0-6d24-4ace-ac45-6b6335b7eac5", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "RenterId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Price", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 13, 18, 23, 5, 898, DateTimeKind.Local).AddTicks(2734), 200, new DateTime(2022, 12, 8, 18, 23, 5, 898, DateTimeKind.Local).AddTicks(2699) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9390e3f1-821d-4d96-b3bb-397d373b7b04", "4078b0fd-3914-461c-8c6b-06bda682647d" },
                    { "20be60b0-71ee-4297-ad72-4e4ca05b2fc8", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { "0eff399e-8200-43c8-b58d-f790d528f98b", "bcc313a0-a38a-42a2-a42c-d00f09a89c5f" },
                    { "9390e3f1-821d-4d96-b3bb-397d373b7b04", "dea12856-c198-4129-b3f3-b893d8395082" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9390e3f1-821d-4d96-b3bb-397d373b7b04", "4078b0fd-3914-461c-8c6b-06bda682647d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "20be60b0-71ee-4297-ad72-4e4ca05b2fc8", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0eff399e-8200-43c8-b58d-f790d528f98b", "bcc313a0-a38a-42a2-a42c-d00f09a89c5f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9390e3f1-821d-4d96-b3bb-397d373b7b04", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eff399e-8200-43c8-b58d-f790d528f98b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20be60b0-71ee-4297-ad72-4e4ca05b2fc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9390e3f1-821d-4d96-b3bb-397d373b7b04");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcc313a0-a38a-42a2-a42c-d00f09a89c5f");

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
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "RenterId",
                value: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Price", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 9, 12, 18, 34, 60, DateTimeKind.Local).AddTicks(357), 0, new DateTime(2022, 12, 4, 12, 18, 34, 60, DateTimeKind.Local).AddTicks(313) });
        }
    }
}
