using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class NewDurationOnRouteEverest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 3, 21, 37, 35, 921, DateTimeKind.Local).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 2, 5, 21, 37, 35, 921, DateTimeKind.Local).AddTicks(4243));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 1, 8, 21, 37, 35, 921, DateTimeKind.Local).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "579e6d52-96ba-4343-a8f0-48feefe6680d", "b28831f8-7657-4377-a82a-11a87bcde963" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2e8d3f3-ac91-4188-bea5-ebd74a8503f3", "AQAAAAEAACcQAAAAEFu1hHfAt8MY0oDXv/U2cma9TolavbPXEGyaGt3LH7naaztwbA1wCnN7H/m7xVWzug==", "a90ffba0-ed05-4d2e-a49a-7a063994e5d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf33fe1a-5f8c-47d4-b44c-d369ed6e586b", "AQAAAAEAACcQAAAAEIn2O4KTzWSFZrM5GwDt6XVm8+jih3UbMg01Dw6UYpiHEvIUfkeyUBLz865uSmkqow==", "e4c35719-cc68-4b11-8b63-0518571afa62" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: "60.00:00");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 3, 21, 23, 28, 646, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 2, 5, 21, 23, 28, 646, DateTimeKind.Local).AddTicks(963));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 1, 8, 21, 23, 28, 646, DateTimeKind.Local).AddTicks(968));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6cd77dac-41d9-4de7-8a12-ff218168c0c4", "2fd3c454-2926-4165-a68f-12ddd0e174b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b0f159a-b558-4846-a906-5f16ccc090a4", "AQAAAAEAACcQAAAAECRfQDmyUdHGAR0GUepqEIs91UIK53vKr07hs7bb/XNcV49t/xdP2QkfuK3t2ovEag==", "9512dac4-ba43-453d-bc7f-9e25e0d8ffd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2ecd11f-050e-450b-b12e-00a8914913ee", "AQAAAAEAACcQAAAAEOqk4l4E0kBShTvfIvA5C/FGqt+lkg8yyXegjvMV3YK42nqzwZGao90bW0FMSHPJtA==", "84f106e3-7c8b-40b6-a669-aa9154cb5d39" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: "0.06:00");
        }
    }
}
