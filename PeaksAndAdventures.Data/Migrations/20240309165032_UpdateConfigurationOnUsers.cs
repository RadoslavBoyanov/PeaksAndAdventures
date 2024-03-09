using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class UpdateConfigurationOnUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "353e4227-d680-4ad1-8c64-70ce7841823d", "tourist@mail.com", "AQAAAAEAACcQAAAAEN2NKtvLRH/ijh03MIdckvHxqZLAO28Dc2A2/UeSrnlvaKCkAVxUSQX/51cvsPiBJQ==", "4ecaf18e-15a0-4857-b907-fb8d9590ad95", "tourist@mail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "12e5965a-7353-44b3-9c2f-8d105404bb6b", "climbаndhike@mail.com", "climbаndhike@mail.com", "climbаndhike@mail.com", "AQAAAAEAACcQAAAAEMg1f9DyrkyzcmlWub1vQIHURejP8CSZJ7jyAzaNtPWNuW8DQoTDpxJDINbKl6GPdw==", "a850655a-3dcd-4c38-8c59-5d5839cf2afc", "climbаndhike@mail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ec1fbdab-1656-4e0f-bb76-8eb3b75d1b4f", "mountaineer@mail.com", "mountaineer@mail.com", "AQAAAAEAACcQAAAAEFPGtpTDCPaayQMJaQNcODp1qDOwqJOoawSslGy1Cc7iBZvEfLuhAgNT5nk9UOaDrQ==", "a23be2a0-c090-4f1b-81f0-98421eebfab5", "mountaineer@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "579e6d52-96ba-4343-a8f0-48feefe6680d", "tourist", null, "b28831f8-7657-4377-a82a-11a87bcde963", "Tourist" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e2e8d3f3-ac91-4188-bea5-ebd74a8503f3", "climbAndHike@mail.com", "climbandhike@mail.com", "climbandhike", "AQAAAAEAACcQAAAAEFu1hHfAt8MY0oDXv/U2cma9TolavbPXEGyaGt3LH7naaztwbA1wCnN7H/m7xVWzug==", "a90ffba0-ed05-4d2e-a49a-7a063994e5d9", "ClimbAndHike" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "cf33fe1a-5f8c-47d4-b44c-d369ed6e586b", "agent@mail.com", "mountaineer", "AQAAAAEAACcQAAAAEIn2O4KTzWSFZrM5GwDt6XVm8+jih3UbMg01Dw6UYpiHEvIUfkeyUBLz865uSmkqow==", "e4c35719-cc68-4b11-8b63-0518571afa62", "Mountaineer" });
        }
    }
}
