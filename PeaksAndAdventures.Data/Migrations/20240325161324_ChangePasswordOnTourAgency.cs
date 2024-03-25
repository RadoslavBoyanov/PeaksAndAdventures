using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class ChangePasswordOnTourAgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 20, 18, 13, 22, 627, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 2, 22, 18, 13, 22, 627, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 1, 25, 18, 13, 22, 627, DateTimeKind.Local).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03d46638-ff16-40fc-867f-b416adb1da4a", "AQAAAAEAACcQAAAAEFJWpdNptsPHgNDFilu7EU93kZJjiOJrXxKV1Pr+2rciFYZHDSxtZ1kpV1WVZknwsA==", "ca04c1db-8181-4b16-87ef-8847a93f838a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f82e819a-f0e0-4e9f-af70-81860a8da3a1", "AQAAAAEAACcQAAAAEBJF5ooP1uTL5Y7uQ5neyxL6egLPhB+RjebHZ7QxdtbdK8ICd2LvRdx1kJwSoeLwHw==", "5054b1a5-0df9-4eba-b6a3-a3a621191f45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "753fa43e-bf97-46e5-9a3f-5d6c4356b9eb", "AQAAAAEAACcQAAAAEKza6zK0JxDep50lrSay3P2Ey1eO8yMe4BFzU0bBEQNTCDmgFCa2igiRxW0YjzfZgw==", "e5519677-826f-47ba-9765-8291ca63a5eb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
