using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class CreateRatingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "TourAgencies");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MountainGuides");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Rating Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: true, comment: "Navigation property for route"),
                    TourAgencyId = table.Column<int>(type: "int", nullable: true, comment: "Navigation property for tour agency"),
                    MountainGuideId = table.Column<int>(type: "int", nullable: true, comment: "Navigation property for mountain guide"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of object")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_MountainGuides_MountainGuideId",
                        column: x => x.MountainGuideId,
                        principalTable: "MountainGuides",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_TourAgencies_TourAgencyId",
                        column: x => x.TourAgencyId,
                        principalTable: "TourAgencies",
                        principalColumn: "Id");
                },
                comment: "Entity for ratings");

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

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MountainGuideId",
                table: "Ratings",
                column: "MountainGuideId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RouteId",
                table: "Ratings",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TourAgencyId",
                table: "Ratings",
                column: "TourAgencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "TourAgencies",
                type: "float",
                nullable: true,
                comment: "Tour agency rating");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Routes",
                type: "float",
                nullable: true,
                comment: "Route rating");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "MountainGuides",
                type: "float",
                nullable: true,
                comment: "Mountain guide rating");

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
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 6.0);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 8.0);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 7.0);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 7.0);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 7.0);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 8.0);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 7.0);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rating",
                value: 8.0);

            migrationBuilder.UpdateData(
                table: "TourAgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 9.0);
        }
    }
}
