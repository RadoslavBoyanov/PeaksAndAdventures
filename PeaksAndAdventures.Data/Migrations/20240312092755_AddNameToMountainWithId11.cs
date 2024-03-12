using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class AddNameToMountainWithId11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 7, 11, 27, 53, 952, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 2, 9, 11, 27, 53, 952, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 1, 12, 11, 27, 53, 952, DateTimeKind.Local).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1cc58dc-daa3-4219-a6d6-5000e09135e5", "AQAAAAEAACcQAAAAEKBaiJTs5hc7GJhUOsmiQpx30Pm+ZmQrPVSXY4+6nqlq4uLdJU1Bb4/2PdyZh0dPsw==", "3232a814-f9ba-4db4-8f7d-822099104c5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "917cdaea-0d0f-4b29-bb76-3ec3c4f7fb63", "AQAAAAEAACcQAAAAENW/13jl3hVWtK2Uq3PL9LEQBxfVH5QTqeolx5Q0FxnxmyecRO6SCZUZcyjXZgnjKQ==", "c8c5ea53-dcdc-465e-9551-34c411722ab3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4af0311f-20c4-4d5a-9567-1851deb3527c", "AQAAAAEAACcQAAAAEAwXt2pcqWhPLAuicKAMpzM6kqZBHDH9sGn8qhi9HOlhqbeaAsPE+o+mz/kudnMFIw==", "eec39497-c752-4478-8683-9d3bd3d3452f" });

            migrationBuilder.UpdateData(
                table: "Mountains",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Каракорум");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 4, 18, 50, 30, 821, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 2, 6, 18, 50, 30, 821, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 1, 9, 18, 50, 30, 821, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "353e4227-d680-4ad1-8c64-70ce7841823d", "AQAAAAEAACcQAAAAEN2NKtvLRH/ijh03MIdckvHxqZLAO28Dc2A2/UeSrnlvaKCkAVxUSQX/51cvsPiBJQ==", "4ecaf18e-15a0-4857-b907-fb8d9590ad95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12e5965a-7353-44b3-9c2f-8d105404bb6b", "AQAAAAEAACcQAAAAEMg1f9DyrkyzcmlWub1vQIHURejP8CSZJ7jyAzaNtPWNuW8DQoTDpxJDINbKl6GPdw==", "a850655a-3dcd-4c38-8c59-5d5839cf2afc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec1fbdab-1656-4e0f-bb76-8eb3b75d1b4f", "AQAAAAEAACcQAAAAEFPGtpTDCPaayQMJaQNcODp1qDOwqJOoawSslGy1Cc7iBZvEfLuhAgNT5nk9UOaDrQ==", "a23be2a0-c090-4f1b-81f0-98421eebfab5" });

            migrationBuilder.UpdateData(
                table: "Mountains",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "");
        }
    }
}
