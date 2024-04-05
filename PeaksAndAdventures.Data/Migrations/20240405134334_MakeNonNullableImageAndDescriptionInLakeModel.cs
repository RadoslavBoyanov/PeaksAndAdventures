using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class MakeNonNullableImageAndDescriptionInLakeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Lakes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Pictures of the lake",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Pictures of the lake");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Lakes",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                comment: "Lake description",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true,
                oldComment: "Lake description");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Lakes",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Pictures of the lake",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Pictures of the lake");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Lakes",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                comment: "Lake description",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "Lake description");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 30, 19, 35, 49, 466, DateTimeKind.Local).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 3, 3, 19, 35, 49, 466, DateTimeKind.Local).AddTicks(2929));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 2, 4, 19, 35, 49, 466, DateTimeKind.Local).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bdf4ebe-3f36-473c-a5f3-d6187427405f", "AQAAAAEAACcQAAAAEFNOAOSfH1Cc0W+w/cfp9cO2MBJ0tfGnAmW5bAUySI1Votp+/3SM/OlzK/Uq588BGQ==", "0c6b5523-b7b0-4a84-8b8a-81d5872228df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "365df078-be08-4d14-aa5d-e23198853698", "AQAAAAEAACcQAAAAEJAuYMHQ0g+4gBvuP/7m63vs0qgVqAlhnKGw6woiTq9urYdbfX7SShQuvLxabzCfug==", "9fe57f8d-6557-4a72-a62d-2c5de9d2dbd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37eacce1-0815-43a0-a4cf-2d627d7ff10d", "AQAAAAEAACcQAAAAENWUo1FhkFPt2ySosBRCBHnXaQ5G2w7O6DjJ/JHlGWsX9zumCA3G2bHef/zd84gpCQ==", "a6209761-b2c8-4adc-a355-f589248fad48" });
        }
    }
}
