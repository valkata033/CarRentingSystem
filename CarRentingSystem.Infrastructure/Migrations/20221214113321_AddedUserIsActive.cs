using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystem.Infrastructure.Migrations
{
    public partial class AddedUserIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4078b0fd-3914-461c-8c6b-06bda682647d",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b057c6ff-8ae6-438b-9d9e-399af914c46b", true, "AQAAAAEAACcQAAAAEP4TGwJXXCLGmKNcDbNNMTVu6w/R1AXbf3kgbAOJSkIcUr8auHdApGGTaZV47muYuQ==", "18644483-de51-4b41-9e7e-8b91769a696a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b83f0d6-7aec-4137-ab70-578404199abb", true, "AQAAAAEAACcQAAAAEOPxdoIOw8uQn6K1rn9iBxDR5lRNab6xQUttjfAGaIqlhwWk0VCuDPzQrs000qwF2g==", "5a230da0-d6b3-4eb5-8fa6-a766f563c4e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcc313a0-a38a-42a2-a42c-d00f09a89c5f",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2755fea7-096e-4b65-86dc-1b31f21d6777", true, "AQAAAAEAACcQAAAAEBtrAWYxNU2+8SaSPjShFNj3Zwhgo/FGbu8LegQlam3bMsp/kcmIsYomw3t9RbLl2Q==", "5ab3c225-50a8-423d-a138-e1a32a1419ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9171acf4-100a-4568-9a94-eaa60ee7a816", true, "AQAAAAEAACcQAAAAEJMnNoVnkAhyGU7GDQzgTIbnrWcP/18rpRNHYnCdafaBnMRfpd5nTGBCCJ6S3OBI9w==", "1cc47fa0-54bc-42b5-bfdb-efbd041155cc" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 19, 13, 33, 20, 970, DateTimeKind.Local).AddTicks(6608), new DateTime(2022, 12, 14, 13, 33, 20, 970, DateTimeKind.Local).AddTicks(6563) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

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
                keyValue: "bcc313a0-a38a-42a2-a42c-d00f09a89c5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44955139-1f8d-4821-bd01-76bac3a0b742", "AQAAAAEAACcQAAAAEH/UZ9dTc+JuycUugu/ByFtQAGN1KPOccOA0mr3bRVZX4LSU1ggj77ngBZD/Kk6NqQ==", "af44cff0-6d24-4ace-ac45-6b6335b7eac5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d017e33-4ce4-4b78-9df6-cfdd6c40f2fe", "AQAAAAEAACcQAAAAEPh/vS/lZ8klOJ/s2Q68Hdff/4xQwJ7bPvclKZkz48XorJzsDDVIsdosSWRr3dmvEA==", "9f95cdee-696e-4e29-a517-8c2dcfa37b50" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 13, 18, 23, 5, 898, DateTimeKind.Local).AddTicks(2734), new DateTime(2022, 12, 8, 18, 23, 5, 898, DateTimeKind.Local).AddTicks(2699) });
        }
    }
}
