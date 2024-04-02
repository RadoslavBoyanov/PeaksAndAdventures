using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class AddValuesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Values",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "List of values");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Values",
                table: "Ratings");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 28, 12, 4, 28, 29, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 3, 1, 12, 4, 28, 29, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 2, 2, 12, 4, 28, 29, DateTimeKind.Local).AddTicks(704));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82b51011-80ee-4969-9629-b8630d3bad75", "AQAAAAEAACcQAAAAEAeEp07WyGf6rFq6/Vk04fh0BcQIlkfigODdZrthU65hwu+ZvDR923+EuT/LSEmv7A==", "5e26d653-1c84-475d-9f17-9e751a066b32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a07aef2f-a0d6-4f15-aada-496cceee7c53", "AQAAAAEAACcQAAAAEGsmUuOQ7/LQoSKZYwALdGZp9ZUUiDLpI8c5D3bxmd7VNjfs4y2TNnJjcOfQUUmeeg==", "3d4891e5-3707-4207-a5ad-2294b11c1a6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25c0bf0b-bcc4-4b43-81aa-7ff5cf105b9e", "AQAAAAEAACcQAAAAEGOTF+qIwHaAZvPCX2OGQSdUd4EKUWeGydc/lp6Xpo+vgCzwimIK6KbdSHsTdXN0vA==", "423b4c5d-b009-4b66-942f-7739f36ca05c" });
        }
    }
}
