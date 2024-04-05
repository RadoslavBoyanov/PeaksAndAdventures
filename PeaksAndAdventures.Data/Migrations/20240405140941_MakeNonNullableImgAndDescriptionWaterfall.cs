using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class MakeNonNullableImgAndDescriptionWaterfall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Waterfalls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Pictures of the waterfall",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Pictures of the waterfall");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Waterfalls",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "",
                comment: "Waterfall description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldNullable: true,
                oldComment: "Waterfall description");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Waterfalls",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Pictures of the waterfall",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Pictures of the waterfall");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Waterfalls",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true,
                comment: "Waterfall description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldComment: "Waterfall description");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 31, 16, 43, 33, 202, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 3, 4, 16, 43, 33, 202, DateTimeKind.Local).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 2, 5, 16, 43, 33, 202, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87c6f498-ae75-462e-bfc8-9e3c378ea3d4", "AQAAAAEAACcQAAAAECzVW+ck976hAoEflh06QCQXlCkCPfkmrH6PTrtbWoPoYKWgoFNk9USQCCMVkHE1hA==", "e933d6e4-45de-4c05-97cd-e47ff938d387" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8a381d7-ddc5-40cd-aa63-6d2d46e4db00", "AQAAAAEAACcQAAAAENpw1Con2hHg0sGUBn27Fa+AEiN7+P6nZ6OeFnfRaZR1cB+Lk8iwG1KIo30xOIeeuQ==", "2d951830-839f-4f89-a9ae-e9a40f089c1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "035d6d85-f12b-4e6b-a979-5491e11bfb3a", "AQAAAAEAACcQAAAAEBqa0pJlT0mEL2Ao1JJjV+LpRrOoeJ41APYxPT8N9RMbhwjq6IhMf5D0OgRlLP2ZAQ==", "ede9a2f7-0550-45db-b218-94291a1c83d5" });
        }
    }
}
