using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class AddNewPropertiesNameAndEnrolment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Enrolment",
                table: "Expeditions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "People signed for expedition");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Expeditions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Name of expedition");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date publish",
                value: new DateTime(2024, 3, 20, 18, 33, 36, 52, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date publish",
                value: new DateTime(2024, 2, 22, 18, 33, 36, 52, DateTimeKind.Local).AddTicks(1034));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date publish",
                value: new DateTime(2024, 1, 25, 18, 33, 36, 52, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "953b2d18-98f2-4746-b52a-da643b840723", "AQAAAAEAACcQAAAAEBEluGsPsNyoZedDAr31sv0OmVJsX/URyvLijAEBXY7Zk83iJbqmMYf990A5nLxstA==", "33dcf1b9-5737-49a8-b92c-b20a9284d0a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "726b7afe-f6ae-49c0-8d27-e7aa17b13f26", "AQAAAAEAACcQAAAAEKJc/nYh+hbOM1o3cstPMpOr+3yIkN1mdFlLZhWyKIrq0rILXoOboKjjuFEB6v8idQ==", "3b865870-f0de-4b80-95aa-7cb44723d9a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db57e345-f45d-4034-a204-f2f666eea8b1", "AQAAAAEAACcQAAAAECRI8G0z23iktnbYNLnHiKkS6qDBVZPHSslCj99y2hoKJw/CJgxaYyHV4JHkFSJ4XA==", "5e2e9bfb-eb09-4221-90b5-0d67b1140c8a" });

            migrationBuilder.UpdateData(
                table: "Expeditions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Enrolment", "Name" },
                values: new object[] { 20, "Изпитай себе си и изкачи Еверест!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enrolment",
                table: "Expeditions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Expeditions");

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
    }
}
