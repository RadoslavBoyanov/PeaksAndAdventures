using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class TourAgencyPropertyCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TourAgencyId",
                table: "MountainGuides",
                type: "int",
                nullable: true,
                comment: "Mountain guide tour agency",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Mountain guide tour agency");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TourAgencyId",
                table: "MountainGuides",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Mountain guide tour agency",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Mountain guide tour agency");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 28, 15, 17, 25, 502, DateTimeKind.Local).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 3, 1, 15, 17, 25, 502, DateTimeKind.Local).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 2, 2, 15, 17, 25, 502, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e375981-b99b-4cf6-8213-31a500e44bd5", "AQAAAAEAACcQAAAAEJXgbzujuhWovoU/GjGIW8BquECKyLchfVKv4FTHCJjR7tJfeyqnJ5ICpsyrDvdSxw==", "1b83429a-26e1-4c0b-9e8f-c58ac1299518" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c3a60a4-6262-4cbd-98f3-1ee34c8e02b9", "AQAAAAEAACcQAAAAENBMpYw66f8nwzv16HDZvHjTXpli/kIT5d6DtiWFSN/yo8+DAsCNJf7nFE64vCH/4g==", "694c3eb3-0ef5-45e2-98db-06340717ba4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "545914fe-b690-47ec-8b59-bc2085ff9420", "AQAAAAEAACcQAAAAEESIJ/zMTVqCdKrfm0PsMllb3f+HfOAgES8cE5BixCPlPvdegnvQvYz/TcmZFne4eg==", "c4a88f5d-c142-43fb-9cbe-30d9a66d8621" });
        }
    }
}
