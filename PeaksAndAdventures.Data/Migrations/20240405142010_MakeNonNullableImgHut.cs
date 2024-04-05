using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class MakeNonNullableImgHut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Huts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Pictures of the hut",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Pictures of the hut");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 31, 17, 20, 9, 131, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 3, 4, 17, 20, 9, 131, DateTimeKind.Local).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 2, 5, 17, 20, 9, 131, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bac5108-fbe9-49fb-b5a6-3c0c8027ef05", "AQAAAAEAACcQAAAAEHqlH5jfWX0gQvZx4UjR2WozuUSFpYGdbUCbJsWBhAcyMCMeGsFF2Y9MWeA6C88vNA==", "6bb8bc7e-d935-479a-a04d-c4cc60dc202f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14c298ff-9eb1-499f-9192-25b61fa08b03", "AQAAAAEAACcQAAAAECilGk6M4YBMY8Ha4DGr5tSKIuOltptjL+27GYo/6e0B6AW/6lSTGIDZ9m7Rp0mB7w==", "7cd53542-3230-4d20-a182-2095196db97a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b17304d9-f611-4a07-bb27-bffafa316a7f", "AQAAAAEAACcQAAAAEMxnAqiAGmKu6Exx0I7lhqX5GtVqpPbpcW1ADZnPbUBbiNco501trCaq/LcjARDFCQ==", "d6646222-6820-49df-804a-85f49c34240a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Huts",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Pictures of the hut",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Pictures of the hut");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 31, 17, 9, 39, 759, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 3, 4, 17, 9, 39, 759, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 2, 5, 17, 9, 39, 759, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36496fd5-54b9-4d11-b61b-be6e9c2a5281", "AQAAAAEAACcQAAAAEOyVQxJ6CVRgLyNFg7Ry7D1FFkqz1SiETIl8Ggo0rUrHnprj6ck0J2r9BABEqryunQ==", "fbcec9a9-4f52-4fd5-9e96-13f06e84d06e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8993d94-f120-4656-8c18-fac64ca0d197", "AQAAAAEAACcQAAAAEHMd7UjI7f/6ZaUs/nfHtF6sR+NOVPwgMVKj3A8GlE1w0yLnGBVkh4+q8u5g1femmQ==", "b598d65f-ac2c-40a3-8d06-6cf4a5a67ca9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bd97469-bbfb-4c72-9f12-38624d7decef", "AQAAAAEAACcQAAAAEJM+kq/We//kuBFGUynKCnsjBoDSrBf7bcsWuZ9C5SyBOGVBQnGcmuU4udCPjAWz+w==", "608aca8b-817b-4c24-826b-f37956cafe2f" });
        }
    }
}
