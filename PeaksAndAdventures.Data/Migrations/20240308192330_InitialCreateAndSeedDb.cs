using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class InitialCreateAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Article id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: false, comment: "Article title"),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false, comment: "Article content"),
                    Datepublish = table.Column<DateTime>(name: "Date publish", type: "datetime2", nullable: false, comment: "Article date publish"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Pictures for article"),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Navigation property for author")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Article entity model");

            migrationBuilder.CreateTable(
                name: "Mountains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Mountain Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Mountain name"),
                    Location = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Mountain location"),
                    Climate = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Mountain climate"),
                    Waters = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false, comment: "Mountain waters"),
                    Flora = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false, comment: "Mountain flora"),
                    Fauna = table.Column<string>(type: "nvarchar(3500)", maxLength: 3500, nullable: false, comment: "Mountain fauna"),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Pictures of the mountain")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountains", x => x.Id);
                },
                comment: "Mountain model");

            migrationBuilder.CreateTable(
                name: "TourAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Tour agency id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Tour agency name"),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Tour agency description"),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Tour agency email"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Tour agency phone number"),
                    Rating = table.Column<double>(type: "float", nullable: true, comment: "Tour agency rating"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Tour agency owner")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourAgencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourAgencies_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tour agency entity model");

            migrationBuilder.CreateTable(
                name: "Huts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Hut id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Hut name"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Hut description - history, location and other things"),
                    WorkTime = table.Column<int>(type: "int", nullable: false, comment: "Hut work time in seasons"),
                    Places = table.Column<int>(type: "int", nullable: false, comment: "How many people can sleep in hut"),
                    Camping = table.Column<int>(type: "int", nullable: false, comment: "Camping around the hut"),
                    Altitude = table.Column<double>(type: "float", nullable: true, comment: "Hut altitude"),
                    HasBathroom = table.Column<bool>(type: "bit", nullable: false, comment: "Hut bathroom"),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false, comment: "Hut toilet"),
                    HasCanteen = table.Column<bool>(type: "bit", nullable: false, comment: "Hut canteen"),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Hut phone number"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Pictures of the hut"),
                    MountainId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for mountain")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huts_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Hut entity model");

            migrationBuilder.CreateTable(
                name: "Lakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Lake Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Lake name"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "Lake description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Pictures of the lake"),
                    MountainId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for mountain")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lakes_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Lake entity model");

            migrationBuilder.CreateTable(
                name: "Peaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Peak Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Peak name"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true, comment: "Peak description"),
                    Altitude = table.Column<int>(type: "int", nullable: false, comment: "Peak altitude"),
                    Partition = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true, comment: "Partition in mountain where is the peak"),
                    SpecificLocation = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true, comment: "Peak specific location"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Pictures of the peak"),
                    MountainId = table.Column<int>(type: "int", nullable: false, comment: "Mountain id for the peak")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peaks_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Peak model");

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Route id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Route key names"),
                    Startingpoint = table.Column<string>(name: "Starting point", type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Route starting point"),
                    Displacementpositive = table.Column<double>(name: "Displacement positive", type: "float", nullable: false, comment: "Route displacement positive"),
                    Displacementnegative = table.Column<double>(name: "Displacement negative", type: "float", nullable: false, comment: "Route displacement negative"),
                    Difficulty = table.Column<int>(type: "int", nullable: false, comment: "Route difficulty"),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Route duration"),
                    Rating = table.Column<double>(type: "float", nullable: true, comment: "Route rating"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Pictures of the route"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 7000, nullable: false, comment: "Route description"),
                    MountainId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for mountain")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Route entity model");

            migrationBuilder.CreateTable(
                name: "Waterfalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Waterfall id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Waterfall name"),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true, comment: "Waterfall description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Pictures of the waterfall"),
                    MountainId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for mountain")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waterfalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waterfalls_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Waterfall entity model");

            migrationBuilder.CreateTable(
                name: "MountainGuides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Mountain guide id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(name: "First name", type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Mountain guide first name"),
                    Lastname = table.Column<string>(name: "Last name", type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Mountain guide last name"),
                    Age = table.Column<int>(type: "int", nullable: true, comment: "Mountain guide age"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Mountain guide phone number"),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Mountain guide email"),
                    Experience = table.Column<int>(type: "int", nullable: false, comment: "Mountain guide experience"),
                    Rating = table.Column<double>(type: "float", nullable: true, comment: "Mountain guide rating"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Mountain guide profile picture"),
                    TourAgencyId = table.Column<int>(type: "int", nullable: false, comment: "Mountain guide tour agency"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Navigation property for owner on the model")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainGuides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MountainGuides_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MountainGuides_TourAgencies_TourAgencyId",
                        column: x => x.TourAgencyId,
                        principalTable: "TourAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Mountain guide entity model");

            migrationBuilder.CreateTable(
                name: "Expeditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Expedition id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Startdate = table.Column<DateTime>(name: "Start date", type: "datetime2", nullable: false, comment: "Expedition start date"),
                    Enddate = table.Column<DateTime>(name: "End date", type: "datetime2", nullable: false, comment: "Expedition end date"),
                    Days = table.Column<int>(type: "int", nullable: false, comment: "Expedition durations in days"),
                    Program = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false, comment: "Expedition program"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Expedition price"),
                    Includes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "What services does the expedition include in the price"),
                    Excludes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "What services are not included in the shipping price"),
                    Extras = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "What additional services can be included for an additional fee"),
                    TourAgencyId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for tour agency"),
                    OrganiserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Navigation property for organiser of the expedition"),
                    RouteId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for route")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expeditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expeditions_AspNetUsers_OrganiserId",
                        column: x => x.OrganiserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expeditions_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expeditions_TourAgencies_TourAgencyId",
                        column: x => x.TourAgencyId,
                        principalTable: "TourAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Expedition entity model");

            migrationBuilder.CreateTable(
                name: "RoutesHuts",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for route"),
                    HutId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for hut")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutesHuts", x => new { x.RouteId, x.HutId });
                    table.ForeignKey(
                        name: "FK_RoutesHuts_Huts_HutId",
                        column: x => x.HutId,
                        principalTable: "Huts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoutesHuts_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Many-to-many relationship class between route and hut");

            migrationBuilder.CreateTable(
                name: "RoutesLakes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for route"),
                    LakeId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for lake")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutesLakes", x => new { x.RouteId, x.LakeId });
                    table.ForeignKey(
                        name: "FK_RoutesLakes_Lakes_LakeId",
                        column: x => x.LakeId,
                        principalTable: "Lakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoutesLakes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Many-to-many relationship class between route and lake");

            migrationBuilder.CreateTable(
                name: "RoutesPeaks",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for route"),
                    PeakId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for peak")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutesPeaks", x => new { x.RouteId, x.PeakId });
                    table.ForeignKey(
                        name: "FK_RoutesPeaks_Peaks_PeakId",
                        column: x => x.PeakId,
                        principalTable: "Peaks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoutesPeaks_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Many-to-many relationship class between route and peak");

            migrationBuilder.CreateTable(
                name: "RoutesWaterfalls",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for route"),
                    WaterfallId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for waterfall")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutesWaterfalls", x => new { x.RouteId, x.WaterfallId });
                    table.ForeignKey(
                        name: "FK_RoutesWaterfalls_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoutesWaterfalls_Waterfalls_WaterfallId",
                        column: x => x.WaterfallId,
                        principalTable: "Waterfalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Many-to-many relationship class between route and waterfall");

            migrationBuilder.CreateTable(
                name: "MountaineersMountains",
                columns: table => new
                {
                    MountainGuideId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for mountain guide"),
                    MountainId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for mountain")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountaineersMountains", x => new { x.MountainGuideId, x.MountainId });
                    table.ForeignKey(
                        name: "FK_MountaineersMountains_MountainGuides_MountainGuideId",
                        column: x => x.MountainGuideId,
                        principalTable: "MountainGuides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MountaineersMountains_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Many-to-many relationship table between mountain guide and mountain");

            migrationBuilder.CreateTable(
                name: "MountaineersRoutes",
                columns: table => new
                {
                    MountainGuideId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for mountain guide"),
                    RouteId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for route")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountaineersRoutes", x => new { x.RouteId, x.MountainGuideId });
                    table.ForeignKey(
                        name: "FK_MountaineersRoutes_MountainGuides_MountainGuideId",
                        column: x => x.MountainGuideId,
                        principalTable: "MountainGuides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MountaineersRoutes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Many-to-many relationship class between mountain guide and route");

            migrationBuilder.CreateTable(
                name: "ExpeditionsParticipants",
                columns: table => new
                {
                    ExpeditionId = table.Column<int>(type: "int", nullable: false, comment: "Navigation property for expedition"),
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Navigation property for participant")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpeditionsParticipants", x => new { x.ExpeditionId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_ExpeditionsParticipants_AspNetUsers_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpeditionsParticipants_Expeditions_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expeditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Many-to-many relationship class between expedition and participant");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e", 0, "6cd77dac-41d9-4de7-8a12-ff218168c0c4", "tourist@mail.com", false, false, null, "tourist@mail.com", "tourist", null, null, false, "2fd3c454-2926-4165-a68f-12ddd0e174b3", false, "Tourist" },
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "6b0f159a-b558-4846-a906-5f16ccc090a4", "climbAndHike@mail.com", false, false, null, "climbandhike@mail.com", "climbandhike", "AQAAAAEAACcQAAAAECRfQDmyUdHGAR0GUepqEIs91UIK53vKr07hs7bb/XNcV49t/xdP2QkfuK3t2ovEag==", null, false, "9512dac4-ba43-453d-bc7f-9e25e0d8ffd6", false, "ClimbAndHike" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "c2ecd11f-050e-450b-b12e-00a8914913ee", "mountaineer@mail.com", false, false, null, "agent@mail.com", "mountaineer", "AQAAAAEAACcQAAAAEOqk4l4E0kBShTvfIvA5C/FGqt+lkg8yyXegjvMV3YK42nqzwZGao90bW0FMSHPJtA==", null, false, "84f106e3-7c8b-40b6-a669-aa9154cb5d39", false, "Mountaineer" }
                });

            migrationBuilder.InsertData(
                table: "Mountains",
                columns: new[] { "Id", "Climate", "Fauna", "Flora", "ImageUrls", "Location", "Name", "Waters" },
                values: new object[,]
                {
                    { 1, "Климатът е умерено континентален, с изключение на източните части, които подлежат на переходни континентални влияния.\r\n\r\nОсновният планински хребет на Стара планина попада в зоната на планински климат. Основните фактори, които формират климата, са атмосферната циркулация, височината и изложението на склоновете.\r\n\r\nСтара планина служи като основна климатична бариера и природна граница в България. Северните подножия имат умерено континентални климатични характеристики, докато южните са переходни. Переходът в климата е особено характерен за източните части на планината. От подножието до върха се променят характерът и стойностите на климатичните елементи. Средната годишна температура намалява с височината, достигайки -0,7 °C на станцията на връх Ботев. Средните температури през януари варират широко, от около 0 °C в най-източните части до -5 °C за станцията Петрохан и -9,3 °C за станцията на връх Ботев. Средните температури през юли варират от 8 до 20 °C, в зависимост от височината. Амплитудите на температурата не са големи, вариращи от 16 до 18 °C.\r\n\r\nВалежите се увеличават с височината, достигайки 1200–1400 mm. Те са по-обилни на северните склонове, докато южните склонове остават в сянка от валежите, получавайки около 550 mm валежи. В източните части, поради переходния климат, валежите достигат около 600 mm. Задържането на сняг е около 4–6 седмици в по-високите райони и 1–2 седмици на изток. Максималните валежи се случват през пролетта, докато минимумът е през зимата, със сезонно изравняване на валежите в източните части. Най-вятърните места в България са върховете на Мургаш и Ботев, където средната годишна скорост на вятъра достига 10 м/с. Северните подножия на Стара планина се характеризират с фенови явления, докато регионът на Твърдица и Сливен изпитва студения спускащ се вятър, известен като \"бора\" (често наричан \"Сливенски вятър\"). Неблагоприятните климатични явления включват мъгла, инверсии на температурата в котловините и ледени условия.", "Главната старопланинска верига обитават представители на средноевропейската и евросибирската фауна –­ дива коза, благороден елен, сърна, мечка, катерица, вълк, лисица, заек, таралеж, от птиците –­ орел, алпийска гарга, кълвач, дрозд, от влечугите и земноводните –­ дъждовник, усойница, живораждащ гущер, зелен гущер, алпийски тритон и др. Някои животински видове от бръмбарите, пеперудите, скакалците, охлювите, пещерните животни са ендемити.", " До около 800 m н.в. преобладават широколистните видове, предимно дъб и габър, над които е поясът на буковите гори. На много места именно букът формира горната граница на гората. Над буковите гори на отделни места се срещат хубави смърчови гори, на места смесени с ела (Берковска и Калоферска планина). Срещат се още ограничени площи на гори от бяла мура (Тетевенско) и черен бор. По северните склонове на Берковска Стара планина има естествени гори от реликтния обикновен кестен. В Средна Стара планина по карстови терени се среща еделвайсът (района на Козята стена и връх Мазалат).\r\n\r\nНай-високите части са заети от пасища и ливади. От храстовите видове са разпространени шипка, глог, къпина, дрян, леска, хвойна, боровинка, връшняк, трънка, драка, смрадлика, люляк и др. На отделни участъци в Средна и Западна Стара планина са запазени и храстови съобщества от клек. В района на Айтос е разпространен ендемитът айтоско сграбиче, а в централните части на планината се среща ендемитът старопланинска иглика. Западно от Сливен е и най-северното находище на средиземноморския вид кукуч. Значително е разнообразието на тревни видове:­ власатки, ливадина, детелина, светлика, острици, орлова папрат, картъл, полевица и др.", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Triglav_massif%2C_Bulgaria.jpg/375px-Triglav_massif%2C_Bulgaria.jpg", "Стара планина(Balkan Mountains) е една от четирите физиографични региона на Зона Стара планина. Тя е част от Алпийско-Хималайската планинска система, специфично в голямата геоложка формация, известна като Балкански планини. Разположена между Предбалкана на север и Долините на Подбалканските планини на юг, се простира на запад до река Търговище Тимок (десен приток на Бели Тимок) и река Височица (Комшица, Темска река, десен приток на Нишава) в Сърбия. На изток достига Черно море до мисия Емине.\r\n\r\nСтара планина обхваща части от 14 български области: Видин, Монтана, Враца, София, София-град, Ловеч, Пловдив, Габрово, Стара Загора, Велико Търново, Сливен, Шумен, Бургас и Варна.\r\n\r\nПлощта на Стара планина в България е 11 596,4 км², с дължина от 530 км и ширина, варираща от 15 км в централната част до 50 км в западната и източната части. Средната й височина е 722 метра надморска височина.", "Стара планина", "Стара планина дава начало на няколко значителни реки в България, сред които Лом, Огоста, Нишава, Малки Искър, Вит, Осъм, Видима, Росица, Янтра, Стряма, Тунджа, Луда Камчия и други. Значителна част от дренажа на реките в България се формира в този планински хребет. Реките проявяват характеристики на дъжд-сняг, сняг-дъжд, дъжд (особено в източната част) и карстово попълване (реките Нишава, Искрецка река, Котленска река, Лева река и др.). Високогорските райони достигат пик на оттичането през май, докато в по-ниски райони това се случва през април за северния склон и март за южния склон. В басейна на река Лудогорие максимумът е през февруари. Тук се намират и два тектонски езера: \"Локвата\" под Голям Купен в Централна Стара планина и Скаленското в Студовска планина.\r\n\r\nМодулът на оттичането в региона на Стара планина показва значително разнообразие. Той е по-висок в зоната с висока надморска височина на северните вятърни склонове (над 25 л/с/км²), където валежите са по-значителни, задържането на сняг е по-голямо, а изпарението е по-малко изразено. Освен това максималното оттичане е влияно от непропускливото геоложко основание и стръмния релеф. В по-ниската зона модулът на оттичането е значително по-малък (10 л/с/км²), където по-малките количества валежи, по-малкото задържане на сняг и по-силното изпарение значително намаляват магнитудата му. В най-ниските части на Стара планина модулът варира между 3 и 5 л/с/км², а тези стойности се дължат на ниски количества валежи, значително изпарение, значителна инфилтрация в пропускливото геоложко основание и слабия наклон на релефа.\r\n\r\nСред резервоарите най-голямото е язовирът Камчия, построен на река Луда Камчия. Характеристиките на скалната композиция позволяват образуването на значителни количества на подпукнали подземни води. Развитите карстови процеси също са причина за многочислените карстови извори. Някои от най-големите карстови извори тук са Искрецките извори, Житолюб до станция Лакатник, извора Опицвет при подножието на Чепан и Мала планина, Котелските извори, докато най-известните минерални извори са във Вършец, Бурсия (Берковско), Нешковци (Троянско) и други.\r\n\r\nЗабележителни водопади включват Райнското пръскало (най-високият постоянен водопад на Балканския полуостров), Голям Джендемски водопад, Видимското, Кадемлийското, Бабското, Карловско пръскало и други. Вратенският водопад край Враца е най-големият прекъсваем водопад на Балканите." },
                    { 2, "Рила има типичен планински климат. На връх Мусала (2925 m) падат 2000 mm валежи годишно като 80% от тях са от сняг. Там са измерени най-ниските температури за планината – абсолютна минимална температура -31,2 °C при средна месечна температура -11,6 °C, измерена през февруари. Абсолютната максимална температура е 18,7 °C. Отрицателните температури се задържат средно около 9 месеца, като често продължават до края на юни. Устойчиво повишаване на температурата се наблюдава към средата и края на юли. Но дори и през летните месеци температурата не се задържа трайно над 10 °C. От 5 до 10 дни през юни, юли и август са със средна температура над 15 °C. Това определя краткия вегетационен период във високопланинските части. Той варира от 3 до 6 месеца, като над 2000 метра надморска височина трае около 3 месеца.\r\n\r\nВъв високите части на Рила относителната влажност на въздуха най-често е в границите от 80 до 85%. Най-сухи са студените, зимни месеци. Влажността е различна за северните и южни склонове на Рила. По южните склонове на планината валежите през зимата достигат до 22 – 25% от годишната норма, докато по северните склонове са занижени. По западните и северни склонове максимумът на валежите е през пролетта и лятото, а по източните склонове – през зимата.\r\n\r\n\r\nРавни чал\r\nТрайно формиране на снежна покривка в зоните непосредствено над 1000 m надморска височина се наблюдава след 10 – 15 декември – за северните склонове, а за южните – след 20 – 30 декември. Снежната покривка се задържа средно 200 – 220 дни в годината, като за ниската зона на планината тя е най-дебела през февруари. Тогава средната месечна дебелина достига 20 – 30 cm. Във високата зона – над 2000 m надморска височина – снежната покривка е най-дебела през март – 70 – 80 cm. В най-високите части максималната дебелина на снежната покривка достига 200 – 240 cm. Средната продължителност на периода с устойчива снежна покривка е 70 – 80 дни за надморска височина 1200 – 1300 m, а при надморска височина над 2000 m достига до 180 – 200 дни. Не са изключение ветрове със скорост 30 – 40 m/s (над 100 km/h), с предимно югозападна и западна ориентация. Северозападните и североизточните ветрове са по-умерени. Средната месечна скорост на вятъра по най-високите планински върхове достига 11 – 12 m/s. В по-ниските части средната месечна скорост се изменя от 1,2 до 2,5 m/s, а в средната височинна зона от 2,5 – 3,2 m/s. ", "Общо 24 вида от срещащите се в Рила животни са вписани в Световната Червена книга. Гръбначните животни са 172 вида като 121 от тях са вписани в Българската Червена книга, 15 вида – в европейската Червена книга, 24 вида – в червения списък на Международния съюз за защита на природата (IUCN), а 158 – в списъците към Бернската конвенция.\r\n\r\nБезгръбначни\r\nВ Рила се срещат 2934 вида безгръбначни животни, като 242 са ендемични видове и подвидове. Общо 13 вида от безгръбначните животни живеещи тук са застрашени от изчезване в световен мащаб, а 41 вида са включени в световни и европейски списъци на застрашени видове.[38]\r\n\r\nРиби\r\nВ Рила се срещат 5 вида риби. Различни източници сочат, че видовото разнообразие на рибите достига до 18 като 4 от тях са балкански ендемити.[39] Дъговата и балканската пъстърва обитава езерата и язовирите и по-рядко реките Марица, Ибър, Крива река, Джерман. В рилските езера е широко разпространена лешанката. Видът е интродуциран за стръв от рибари. Някои от езерата са зарибени със сивен. Главочът се среща по-рядко, основно в река Черни Искър.\r\n\r\nЕндемитните видове в Рила са български – главоч (Cottus gobio haemusi) и струмски гулеш (Nemacheilus angorae bureschi) и балкански – маришка мряна (Barbus cyclolepis) и балкански щипок (Sabanejewia aurata balcanica).\r\n\r\nЗемноводни и влечуги\r\nПланината е обитавана от 20 вида земноводни и влечуги. Сред видовете, които се срещат в най-високите части на планината са планинска водна жаба, алпийски тритон, слепок, живороден гущер, ливаден гущер, усойница и медянка. От тях ендемичен вид е македонският гущер.\r\n\r\nПтици\r\nПтиците са представени от 99 вида (около 25% от орнитофауната на България) като тук са най-многобройните популации на глухара, лещарката и планинския кеклик, на пернатоногата и малката кукумявка. Тук се намират и едни от най-жизнените популации на хищни птици. От вписаните в Червената книга птици тук се срещат осояд, скален орел, горски бекас, белогръб кълвач, черен кълвач, малък креслив орел, сокол орко, голям ястреб, орел змияр, ловен сокол и други. Девет вида птици са престанали да гнездят тук.[40]\r\n\r\nБозайници\r\n\r\nЛешников сънливец\r\nБозайниците в Рила са 48 вида като тук е характерна популацията на дивата коза и високопланинската популация на лалугера.[38] Прилепите в Рила са десет, а дребните бозайници се подразделат на насекомоядни, зайци и гризачи. От тях са интересни таралежът, лешниковият сънливец и сляпото куче. Лалугерът е световно застрашен вид. Стабилна, но изолирана високопланинска колония от лалугери е установена в района на връх Белмекен. От по-едрите представители на бозайниците подвидовете на невестулката (Mustela nivalis galinthias) и дивата коза (Rupicapra rupicapra balcanica) са балкански ендемити.", "В Рила растат:\r\n\r\nдървета – обикновен габър (Carpinus betulus), зимен дъб (Quercus petraea), обикновен бук (Fagus sylvatica), трепетлика (Populus tremula), бреза (Betula pendula), обикновена ела (Abies alba), бяла мура (Pinus peuce), обикновен смърч (Picea abies), бял бор (Pinus sylvestris) покриват планинските склонове между 1600 до 2000 m.\r\nцветя – алпийска камбанка (Campanula alpina), планинско омайниче (Dryas octopetala), пролетна съсънка (Pulsatilla vernalis), иглика.", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b2/Maliovitsa_District_Rila.jpg/1280px-Maliovitsa_District_Rila.jpg", "Рѝла е най-високата планина в България и на Балканския полуостров. Намира се в югозападната част на страната, и по-точно в северозападния край на Рило-Родопския планински масив. Най-високият връх на планината – Мусала, със своите 2925,2 m е и най-високият на Балканския полуостров и цяла Източна Европа. По билото на Рила минава Главният български вододел, който съвпада с Главния балкански вододел, разделящ водосборните басейни на Черно и Егейско море.\r\n\r\nВ Европа Рила се нарежда на 6-о място по височина след планините: Кавказ (връх Елбрус – 5642 m), Алпите (връх Монблан – 4807 m), Сиера Невада (връх Муласен – 3479 m), Пиренеите (връх Ането – 3404 m) и Етна (3357 m). От планината извират едни от най-големите и пълноводни български реки – Искър, Марица и Места.", "Рила", "Рила е важен хидроложки възел за България с изключително голям хидроенергиен потенциал, представляващ около 1/4 от целия потенциал на страната. Планината попада в хидроложката област с континентално климатично влияние, планинска подобласт. По северните ѝ склонове и връх Мусала минава главният вододел, разделящ двата отточни басейна – Черноморския и Беломорския (Егейски).Водните запаси, които се формират в границите на планината са най-важният ресурс на чиста питейна вода за околните селища, София, част от населението на Северна Гърция и европейската част на Турция. Районът на населените места, разположени по западните склонове на Рила планина разполага с голям излишък от вода, тъй като оттокът надвишава потреблението около 8 пъти. Режимът на рилските реки е в пряка връзка с надморската височина и около половината от водните запаси в планината се намират на височина над 2050 m. От планината извират едни от най-пълноводните и дълги реки на Балканите – Искър, Марица и Места. Изворите на много притоци на тези реки, както и на притоци на Струма, също се намират във високопланинските части на Рила – Бели, Леви, Прав и Черни Искър, Бяла и Черна Места, реките Белишка, Благоевградска Бистрица, Градевска, Рилска. На територията на планината се формират около 10% от водните ресурси на Струма и Места, над 5% от тези на р. Марица и повече от 8% на р. Искър. Поради екзарационната дейност на ледниците през кватернера във високопланинските части на Рила са се образували голям брой ледникови езера. От тях по-голямата част са постоянни, около 35 са временни и за всички са характерни малките площ и обем. Обикновено заемат дъната на циркусите, циркусните тераси и троговите долини и са разположени на надморска височина между 2000 и 2600 m. Най-често имат закръглена или елипсовидна форма с малки дължина и ширина, като повечето са с площ под 10 дка. Тези води имат значение не толкова с количеството си, отколкото със своето качество и красотата на езерата, която привлича ежегодно хиляди туристи. Веригата на Седемте рилски езера е най-дългата, най-живописна и най-посещавана езерна група. В Рила са описани около 233 езера, от които 189 циркусни, а останалите имат тектонски или свлачищен произход." },
                    { 3, "Климатът в Пирин се отличава с голямо разнообразие, следствие от големите разлики в надморската височина, експозицията на склоновете, разчленението и подстилащата повърхнина. В по-ниските части и в долините на Струма и Места има силно средиземноморско влияние.\r\n\r\nНа север в района на Разложката котловина, разположена на ок. 940 м.н.в. е характерен умереноконтиненталния климат, дължащ се главно на голямата надморска височина на котловината. Средните януарски температури са ок. -2 °C, а валежите ок. 650 – 700 мм., като максимумът им е през ноември и вторичен – през юни. На юг в района на Гоцеделчевската котловина климатът е с преходносредиземноморски черти. Тук средногодишната температура достига 11,4 °C, а януарската е ок. 0 °C, валежите са предимно от дъжд със зимен максимум. Във високите части на планината климатът е типично планински. Средноянуарските температури варират от -1 до -2 °C в подножието и до -5 °C в по-високите части. Средната годишна температура на хижа „Вихрен“ е +3,5 °C. Количеството на валежите варира от 600 – 800 мм в по-ниските части до 1400 – 1500 мм в по-високите. Снежната покривка се задържа в по-високите части 7 – 8 месеца, а в Южен Пирин около 3 месеца. Често във високите части на планината през зимата се образуват опасни лавини.", "Още по-голямо е богатството на животински видове. Познати са над 2000 вида и подвида безгръбначни животни (паяци, стоножки, насекоми, охлюви) и почти 250 вида гръбначни. От последните преобладават птиците (177 вида) и бозайниците (45 вида), а рибите са само 6 вида. Много от тези животни са застрашени и се нуждаят от специална защита – скален орел, трипръст кълвач, планински кефал, шипоопашата костенурка. Най-често могат да се срещнат дива коза, сърна, мечка, вълк, лисица, орел, сокол, глухар и др.", "Пирин е извънредно богат на растения и животни. Установени са около 1300 вида висши растения, което е 1/3 от всичките познати в България, 320 вида мъхове и няколкостотин вида водорасли. Висок е процентът на локалните ендемити – растения, които се срещат само в Пирин. Те са 18 на брой – пирински мак, пиринска ливадина, пиринска мащерка, давидов лопен и др. Много от растенията са редки и защитени, като например познатият на всички еделвайс, който се среща най-вече по Джамджиевите скали под Вихрен. Растителността е вертикално зонирана в три височинни пояса – горски, субалпийски и алпийски. Горският пояс е зает предимно от иглолистни дървета – бял и черен бор, бяла и черна мура, ела, обикновен смърч и достига приблизително до 2000 м. Оттам нагоре до 2500 м следва субалпийският пояс, в който доминират храстите клек и хвойна, чиито размери намаляват с увеличаването на височината. Накрая идва ред на алпийският пояс, зает от треви, лишеи и мъхове, а на границата между двата в изобилие се среща черната боровинка. По-особена е растителността край водните басейни, където най-често могат да се срещнат представителина рода на острицата. Най-известното дърво в Пирин е Байкушевата мура, носеща името на откривателя си, лесовъда Коста Байкушев. През 1897 година той изследва дървото с тръбна сонда и изчислява възрастта му на 1200 години. Приблизителните ѝ размери са височина 24 м, диаметър 2,2 м и обиколка 7,8 м.", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Pogled_kum_prez_gr_Petrich_kum_gr_Sandanski.jpg/1280px-Pogled_kum_prez_gr_Petrich_kum_gr_Sandanski.jpg", "Пирин е разположен в югозападната част на страната между долините на реките Струма и Места, между 41°26' и 41°56' северна ширина. На север граница с Рила е седловината Предел (1142 м), а на юг – Парилската седловина (1170 м), която отделя Пирин от планината Славянка. На североизток планината достига до долината на река Места с Разложката и Гоцеделчевската котловина и пролома Момина клисура, я отделят от Родопите. На запад и югозапад долината на река Струма със своите котловини Симитлийска и Петричко-Санданска и Кресненският пролом я отделят от планините Влахина, Малешевска и Огражден.\r\n\r\nПлощта на планината е 2585 квадратни километра, т.е. тя е сравнително компактна, малка планина, което се потвърждава и от голямата ѝ средна височина – 1033 метра. Дължината ѝ по права линия от северозапад на югоизток е 66 км, а максималната ѝ широчина в направление югозапад-североизток е 40 километра – от град Сандански до село Обидим.", "Пирин", "Пирин е много водна планина. Тя дава началото на голям брой реки, които принадлежат към водосборните басейни на Струма и Места. Те са сравнително къси, буйни и пълноводни, с голям наклон, поради което по тях се образуват множество водопади, прагове и бързеи. Има няколко по-изявени водопада – Влахинският водопад, Скоко, Попинолъшкият (15 м), Демянишки скок (11 м) и Юленски скок (9 м). Вододелът между водосборните басейни на Струма и Места минава по централното пиринско било. Пиринските реки имат снежно-дъждовен режим със силно изразен пролетен максимум. Най-голямото водно богатство на Пирин са красивите езера. На брой 186, те имат ледников произход, разположени са в малки и големи циркуси. Поради този си произход те са сравнително дълбоки, бистри, а поради височината – много студени. " },
                    { 4, "В Западните Родопи, заради по-голямата надморска височина преобладава планински климат. Климатът там е смекчен от топлите средиземноморски въздушни маси, проникващи по теченията на реките. Това смекчаване на климата е по-осезаемо в Източните Родопи, защото там надморската височина е по-малка и речните долини предлагат лесен път на по-топлия въздух от юг. В Западните Родопи средиземноморското влияние е по-слабо, а в Източните – по-силно, което е видно от средногодишните температури и средногодишната сума на валежите за пет метеорологични станции: Велинград 9 °С, 550 mm; Смолян 8,5 °С, 981 mm; Златоград 10,9 °С, 986 mm; Кърджали 12,5 °С, 663 mm; Ивайловград 12,7 °С, 736 mm. В Западните Родопи валежите са главно през летните месеци, а в Източните – през зимата.", "Горите в Родопите предоставят убежище на голям брой животински видове, които живеят, придвижват се и се възпроизвеждат в района, някои от които са редки видове.За много видове големи бозайници, като мечка, вълк, дива коза, елен, сърна и глиган, районът представлява най-южната точка на ареала им. Тези животни живеят и се възпроизвеждат в гъстите борови, букови, и дъбови гори. Най-значимият бозайник тук е кафявата мечка, включена в Червената книга на застрашените от изчезване гръбначни животни в Гърция.Смята се, че в Централните Родопи живеят 25 – 30 мечки, за които горите в региона са идеално местообитание. Дивата коза се среща по най-стръмните склонове в Родопите, в района на Фрактос. Популацията й вече е много малка (около 50 – 60 екземпляра) и изисква взимането на строги мерки за опазването й. Други значими видове, регистрирани в района, са чакал, дива котка, язовец, видра, както и някои видове прилепи.", "Голямото климатично и почвено разнообразие обуславят голямо растително разнообразие в Родопите. На територията на планината са установени над 2000 вида висши растения, от които 90 са балкански ендемити и силно застрашени от изчезване видове. В ниските части на Източните Родопи горите отстъпват място на субсредиземноморските нискостеблени видове – вергилиев дъб, брекина, габър, дива круша (Pyrus pyraster), драка, червена хвойна и др.\r\n\r\nНа височина над 800 м преобладават гори от обикновен горун, мизийски бук, габър, ясен, явор, шестил и др. В иглолистния пояс, който е развит предимно в Западните Родопи, се срещат обикновен смърч, бял бор, черен бор, както и бук. На по-голяма височина преобладава храстовата растителност и алпийските ливади.", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/East-Rhodopes-view.JPG/1280px-East-Rhodopes-view.JPG", "Родопите (вариант на името Родопа, на гръцки: Ροδόπη) е планина в Южна България и Северна Гърция, част от Рило-Родопския масив. Тя е най-обширната планина в България и заема около една седма част от българската територия. Дължината ѝ е около 220 – 240 km, а ширината до 100 km. Общата площ на Родопите е около 18 хиляди km², от които на българска територия са 14 738 km², което представлява 81,88% от цялата ѝ площ. Родопите заемат източната част на Рило-Родопския масив, в централната част на Балканския полуостров. Планината се простира на територията на Южна България (части от областите Благоевградска, Пазарджишка, Пловдивска и Хасковска и изцяло областите Смолянска и Кърджалийска) и Северна Гърция.Дължината им от запад на изток е около 240 km, а ширината от север на юг надхвърля 100 km. Общата площ на Родопите е около 18 хил. km², от които на българска територия са 14 738 km², което представлява 81,88% от цялата ѝ територия.", "Родопи", "Родопите са планина с гъста и сложна речна мрежа. Планината изцяло попада към Беломорския водосборен басейн, като реките, извиращи и течащи през нея, се оттичат към две главни реки (Марица и Места) или директно се вливат в Егейско море. В близо 80% от територията на планината, с изключение на югозападните и южните ѝ части, оттокът е насочен към река Марица чрез нейните десни притоци Чепинска река, Стара река, Въча, Първенецка река, Черкезица, Мечка, Каялийка, Банска река, Харманлийска река, Бисерска река, Арда, Луда река и други по-малки. Югозападните части на планината принадлежат към водосборния басейн на река Места и нейните леви притоци – Златарица, Канина, Чечка Бистрица, Доспат, Дяволска река и други. В най-южните части на Родопите (на територията на Гърция) реките директно се вливат в Егейско море – Върба, Сушица, Аксу, Търнава и други. Повечето от реките в Родопите протичат в дълбоки проломни долини, което е предпоставка за изграждане на хидротехнически съоръжения и оползотворяването на техните големи водноенергийни ресурси. В планината са изградени едни от най-големите български и гръцки язовири: Доспат, Широка поляна, Батак, Голям Беглик, Въча, Кричим, Цанков камък, Кърджали, Студен кладенец, Ивайловград, Черешовско езеро (Лимни Тисавру), Оленско езеро (Лимни Платановрисис) и много други по-малки." },
                    { 5, "Климатът на планината е преходно-континентален, а по високите ѝ части типично планински. ", "Срещат се много защитени от закона птици като осояд, червена каня, белоопашат мишелов, сокол скитник, скален орел, зеления и пъстър кълвач, дрозд и жълтоклюна алпийска гарга. Сред другите видове представители на животинското царство са видра, европейски вълк, рис, сухоземни костенурки, алпийски тритон, змия медянка, усойница, жаба дървесница и други. В реките виреят множество видове риби сред които са балкански щипок, горчивка, мряна и пъстърва.", "Единственият резерват в планината е „Църна река“. Разположен е в горното течение на Църна река. Почти 97% от площта му е заета от иглолистни и смесени гори, които са слабо засегнати от антропогенна дейност. Особено ценни са чистите букови гори с единични екземпляри от други видове като бял бор, сибирска хвойна, черна елша, върба, явор и други. От тревните видове са разпространени светлика, лазаркиня, власатки, горски здравец, орлова папрат, горски зановец и много други. Западно от село Богослов има гора от секвои.", "https://www.entusiasti.net/app/uploads/2022/01/18.Osogovo-mountain-720x238.jpg", "Осоговската планина или Осогово е планина в Западна България и Република Северна Македония. Тя е петата по височина планина в България. Най-високата ѝ точка е връх Руен – 2251,3 m, който се намира на границата между двете държави и е един от 100-те национални туристически обекта. От склоновете на Руен водят началото си четири основни реки: Елешница и Бистрица от Струмския басейн, Крива река и река Каменица от Вардарския басейн. Осогово е най-северно разположената планина от Осоговско-Беласишката планинска група, както и най-високата планина от тази редица. Напряко на основното ѝ било, от югоизток на северозапад планината е поделена между България и Република Северна Македония, като североизточната по-малка част остава на българска територия, а югозападната, по-голямата част – на северномакедонска. Границата между двете държави върви от гранична пирамида № 76 (седловината Черната скала) до гранична пирамида № 96 (Велбъждкия проход).", "Осогово", "Цялата планина изцяло попада към Беломорския водосборен басейн. Североизточните и източните ѝ склонове принадлежат към басейна на река Струма (десните притоци Бистрица, Новоселска река, Гращица, Елешница и др.), южните – към басейна на река Брегалница (десните притоци Звегорска, Каменица, Оризарска, Кочанска, Злетовска и други), а северните – към басейна на Крива река (левите притоци Бела вода и други)." },
                    { 6, "Хималаите имат голям ефект върху климата на Индийския субконтинент и Тибетското плато. Те спират мразовитите и сухи ветрове да достигнат на юг в субконтинента, което поддържа Южна Азия много по-топла, отколкото съответните умерени региони в останалите континенти. Планинската верига също така представлява бариера за мусонните ветрове на север, които изливат обилните си валежи в района на т.нар. тераи. За Хималаите също така се смята, че играят важна роля за формирането на пустините в Централна Азия, например Такламакан и Гоби.\r\n\r\nКлиматът в западния сектор на Хималаите се характеризира с резки колебания на температурата и силни ветрове. Зимата е студена (средна януарска температура -10, -18°С), а над 2500 m – със снежни виелици. Лятото е топло (средна юлска температура около 18°С) и сухо. Влиянието на мусоните е незначително и се изразява само в малкото увеличение на влажността и облачността през юли и август. Валежите (около 1000 mm годишно) са свързани с циклоните, като в долините и котловините тяхното количество е 3 – 4 пъти по-малко, отколкото по планинските склонове. Главните проходи се освобождават от снежната покривка в края на май. В Западните Хималаи на височина 1800 – 2200 m са разположени болшинството от климатичнети курорти на Индия (Шимла и др.). Източният сектор има много по горещ и влажен климат с мусонен режим на овлажняването, като 85 – 95% от годишните валежи падат от май до октомври. През лятото на височина 1500 m температурите по склоновете се повишават до 35°С, а в долините – даже до 45°С. Дъждовете валят почти непрекъснато. По южните склонове на височина 3000 – 4000 m падат от 2500 mm на запад до 5500 mm на изток, а във вътрешните райони – около 1000 mm. През зимата на височина 1800 m средната януарска температура е 4°С, а над 3000 m температурите са отрицателни. Снеговалежите са ежегодно явление над 2200 – 2500 m, а в долините има гъсти мъгли. Северните склонове на Хималаети имат планинско-пустинен климат. Денонощните температурни амплитуди достигат до 45°С, а годишната сума на валежите е около 100 mm. През лятото на височина 5000 – 6000 m само през деня има положителни температури. Относителната влажност на въздуха е 30 – 60%, а през зимата снегът преди да падне се изпарява и не се задържа.", "Сред животните господстват представители на тибетската фауна – хималайска мечка, планинска коза, планински овен, як. На височина до 2500 m има малки земеделски участъци, като се отглежда чай и цитрусовите култури, а по напояваните тераси – ориз. По северните склонове отглеждането на голозърнестия ечемик достига на височина до 4500 m.", "Природните ландшафти в Хималаите са много разнообразни, особено по южните склонове. Покрай подножието на планината на изток от долината на река Джамна се простира заблатената полоса от тераи – дървесно-храстова джунгла от сапунени дървета, мимози, палми, бамбук, банани, манго, всички те развити върху черни тинести почви. Нагоре, до 1000 – 1200 m по наветрените склонове и по долините на реките растат вечнозелени влажни тропични гори съставени от палми, пандануси, лаврови дървета, дървовидна папрат, бамбук, лиани (до 400 вида) и др. Над 1200 m на запад и 1500 m на изток е разположен поясът на вечнозелените широколистни гори, състоящи се от различни видове дъб, магнолия, а над 2200 m се появяват листопадни (елша, орех, бреза, клен) и иглолистни (хималайски кедър, син бор, сребрист смърч) гори от умерения пояс, в съпровод от мъхове и лишеи, покриващи почвата и стволовете на дърветата. На височина 2700 – 3600 m господстват иглолистните гори от сребриста ела, лественица, тсуга, хвойна и др. с гъст подлес от рододендрон. За долната част на горския пояс са характерни червеноземните, а нагоре – кафявите горски почви. В субалпийския пояс са развити малки хвойново-рододендронови горички. Горната граница на алпийските пасища е около 5000 m, макар че отделни растения (аренария, еделвайс) са разпространени и над 6000 m.", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Himalayas.jpg/450px-Himalayas.jpg", "Хималаите или Хималая ( от санскритската дума хима (сняг) + алая (дом), което буквално означава „домът на снега“[1]) е планинска верига в Индийския субконтинент, разположена на територията на Пакистан, Индия, Китай, Непал и Бутан, между Индо-Гангската равнина на юг, Тибетската планинска земя на север. В нея се издигат единадесет от четиринадесетте най-високи върхове на Земята, включително и този с най-високата надморска височина, връх Еверест. Те са най-мощната планинска система на Земята, с най-високите върхове, най-малките разлики във височина на къси разстояния и дълбоки (до 4 – 5 km) дефилета. Хималаите са дълбоко оформили културите на Южна Азия. Много хималайски върхове са свещени в будизма и хиндуизма.", "Хималаи", "По-високите части на Хималаите са целогодишно покрити със сняг, въпреки близостта си до тропиците. Те дават началото на няколко големи реки, които се обединяват в две основни речни системи:Западните реки образуват Индския басейн, в който най-голямата река е Инд. Тя води началото си от Тибет на китайска територия и тече на югозапад през Индия и Пакистан до Арабско море. Главните реки в системата на Инд са Джелам, Чинаб, Рави, Биас и Сутледж.\r\nПовечето от останалите хималайски реки са част от басейна на Ганг-Брахмапутра. Неговите две основни реки са Ганг и Брахмапутра. Докато Ганг тече в равнините на юг от Хималаите, Брахмапутра извира в Тибет, тече на изток, след което заобикаля Хималаите от изток, отново променя посоката си на запад през Асам и се влива в Бенгалския залив, образувайки обща делта с Ганг. Като цяло речната система е много по-добре развита по техните южни склонове. В горните си течения реките имат снежно и ледниково подхранване с рязко колебания на оттока в течение на едно денонощие, като долините им са тесни и дълбоки, а течението им е съпроведено от много прагове и водопади. В средното и долното си течение подхранването им е дъждовно, с максимален отток праз лятото.\r\nВ Хималаите са разположени и стотици езера, като повечето са с надморска височина под 5000 m, а като цяло размерът им намалява с височината. Те са предимно с тектонски и ледников произход и особено много в западните части. Най-голямо е езерото Пангонг Цо, разположено на границата между Индия и Китай, което има площ около 700 km². Други известни езера са Гуродонгмар и Цонгмо в Сиким и Тиличо в Непал." },
                    { 7, "Климатът е планински. Средногодишните валежи в Алпите са 1450 mm.Алпите се делят на пет климатични зони, всяка с различен вид на околната среда. Климатът, растенията и животинския свят се различават в различните части или зони на планината.Зоната, която е над 3000 m, се нарича „зона на ледниковия сняг“ (фирн). Тази област, която е с най-студения климат, постоянно е покрита със сбит сняг.Алпийската тундра се намира на височина между 2000 и 3000 m. Тази зона е по-топла, отколкото зоната на фирна. Тук могат да се срещнат диви цветя и треви.Непосредствено под нея е субалпийската зона – от 1500 до 2000 m височина. Тук, с покачването на температурата бавно нагоре, започват да се срещат елхови и смърчови гори.На височина от около 1000 до 1500 m е обработваемата земя. В тази област са разпространени дъбовите гори, а също така е и мястото за селскостопанско производство.Под 1000 m са низините. Тук се среща далеч по-голямо разнообразие от растения. Човешките селища също така са в низините, тъй като температурата е по-поносима – както за хората, така и за животните.", "Алпите са дом на 30 000 вида животни. Бозайниците обитават Алпите целогодишно, като някои от тях спят зимен сън. Само някои видове птици остават в планината през цялата година. Има птици, живеещи в Алпите, които напълно са се адаптирали към негостоприемната среда. Например снежната чинка строи гнезда в пукнатините на скалите над границата на гората и търси храната си (семена и насекоми) по планинските склонове. Жълтоклюната гарга също гнезди по скалите много над границата на гората. През зимата тя образува големи ята, които се събират около туристическите центрове и станции, където се хранят основно с отпадъци. Особено внимателно се подготвя за зимата сокерицата – през есента тази птица трупа запаси от семена и ядки, които заравя в земята. Преди началото на зимата сокерицата събира повече от 100 000 семена, които крие в около 25 скривалища. С невероятната памет, тя намира повечето от скривалищата си под снега през зимата, дебелината на който може да бъде повече от един метър. Със семената от складовете си сокерицата храни малките си.\r\n\r\nНай-често срещаното животно в Алпите е алпийският мармот. Освен него се отличават скалният орел, алпийският козирог, дивата коза, жълтоклюната гарга, пъстрогушата завирушка, брадатият лешояд, кафявата мечка, рисът, благородният елен, вълкът и тундровата яребица. В Алпите има 14 национални парка, които осигуряват опазването на алпийската фауна.", "Растителните пояси в Алпите постепенно се сменят с изкачването нагоре по планината. Естествената височинна граница на растителността е определена от основни широколистни видове – дъб, бук, ясен и явор. Те не достигат до едно и също ниво, нито се срещат често заедно, но горната им граница отговаря достатъчно точно на промяната от умерен към по-студен климат, което допълнително се доказва от промяната на тревистата растителност. Тази граница обикновено се намира на около 1200 m над морското равнище – от северната страна на Алпите, а на южните склонове често се издига на 1500 m, понякога дори до 1700 m.Този регион не винаги е белязан от присъствието на характерните дървета. Човешката намеса почти ги е унищожила в много области, и с изключение на буковите гори на австрийските Алпи, широколистните гори са рядко срещани. В много райони, където някога са съществували такива гори, сега са заменени от бял бор и смърч, които са по-нечувствителни към опустошенията от кози, които са най-големите врагове на такива дървета.Над горите често се срещат отделни малки групи от клек, който на свой ред е заменен от храсти – обикновено Rhododendron ferrugineum (върху по-киселинни почви) или Rhododendron hirsutum (върху по-алкални почви). Над тях са високопланинските ливади, а още по-високо растителността става все по-рядка. В Алпите са регистрирани няколко вида растения над 4000 m, включително Ranunculus glacialis (вид лютиче), Androsace Alpina и Saxifraga biflora.\r\n\r\nВ района на Алпите учените идентифицират 13 000 вида растения. Алпийските растения са групирани по тип местообитание и почва, която може да бъде варовикова или не. Растенията виреят в различни диапазони на условия на околната среда: от ливади, блата, гори (широколистни и иглолистни) и райони, незасегнати от сипеи и лавини, до скали и хребети.[15]\r\n\r\nЕдно от най-известните планински растения е ледниковото лютиче, което държи рекорд сред растенията с височина на виреене от 4200 m. Малки групи растения се намират на надморска височина от 2800 m. Много от тях, като например Eritríchium и Lýchnis имат специфична форма, която ги предпазва от тревопасни животни, които живеят на тези височини, и от загубата на влага. По този начин младите филизи са защитени от вятър и студ. Известният еделвайс е покрит със слой от бели власинки, които успешно задържат топлината.", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/Mont_Blanc_oct_2004.JPG/1280px-Mont_Blanc_oct_2004.JPG", "Алпи  е една от големите планински вериги в Европа, простираща се от Австрия и Словения на изток през Италия, Швейцария, Лихтенщайн и Германия до Франция и Монако на запад.", "Алпи", "ай-дългите реки, които текат през Алпите, са Ин и Драва. Езерата в Алпите са образувани от някогашни ледници. Едни от най-красивите езера в Алпите са Лаго Маджоре, от което идва притокът на реката По, и езерото Лаго ди Гарда, намиращо се близо до река Адидже." },
                    { 8, "Климатът в Андите варира значително – в зависимост от географското положение, надморската височина и близостта до морето. Южната част е дъждовна и хладна, Централните Анди са сухи, а в Северните Анди обикновено е дъждовно и топло, със средна температура от 18 °C в Колумбия. За климата тук е известен факта, че се променя драстично дори при малки разстояния – например, дъждовни гори (известни като селва) съществуват само на километри от заснежения връх Котопакси.\r\n\r\nПланините оказват голям ефект върху температурата на околните райони. Снежната линия е в зависимост от местоположението – обикновено е между 4500 – 4800 m в тропическите части на Еквадор, Колумбия, Венецуела и Северно Перу; нараства до 4800 – 5200 m в сухите планински области на южно Перу и северната част на Чили на юг; и след това се спуска – последователно до 4500 m при връх Аконкагуа, 2000 m на 40° южна ширина, 500 m на 50° южна ширина, и едва 300 m при Огнена земя. От 50° южна ширина, няколко от по-големите ледници се спускат директно до морското равнище.\r\n\r\nКоличеството на валежите достига до 3000 mm годишно. Най-изобилни са валежите по западните склонове на Северните Анди (станция Андагоя – 7140 mm валеж). Поради екваториалния климат в подножията на Северните Анди към низината на Амазонка и към Тихия океан, са характерни всекидневните валежи и висока температура.[1]\r\n\r\nПодножието на Андите попада в горещия пояс (тиера калиенте). Той достига до 600 m височина. Над него е умереният пояс (тиера темплада), достигащ до 2000 m височина. До 2800 m е разположен студеният пояс (тиера фриа). Над 2800 m е разположена студенаполупустинна местност. Планинските била над 3400 m до съвременната снежна граница попадат в мразовия пояс.", "Андите са богати на фауна: С почти 1 000 вида, от които около 2/3 са ендемични за региона, Андите са най-важният регион в света за земноводни. Разнообразието на животинските видове в Андите е високо, с почти 600 вида бозайници (13% ендемични), над 1 700 вида птици (около 1/3 ендемични), около 600 вида влечуги (около 45% ендемични) и почти 400 вида риба (около 1/3 ендемични).\r\n\r\nВикунята и гуанакото могат да се срещат в Алтипланото, докато техно близкият домашен лама и алпака се отглеждат широко от местните хора като товарни животни и заради техните месо и вълна. Чинчилите, активни през съмрака и зазоряването, два заплашени члена на разред гризачи, обитават алпийските региони на Андите. Андският кондор, най-големият птицеобразен представител от своя вид в Западното полукълбо, се среща из цялото Андийско планинско крайбрежие, но обикновено на много ниски плътности. Други животни, намерени в относително откритите места на високите Анди, включват хуемула, пума, лисици от род Pseudalopex, и за птици, определени видове тинаму (предимно членове на рода Nothoprocta), андска гъска, гигантски чаплък, фламинга (главно асоциирани с хиперсолени езера), по-малко рея, андски фликер, диадемно пясъчно водно кокошче, дребници, сиера-четки и дюка-четки.\r\n\r\nЕзеро Титикака е дом на няколко ендемични вида, сред които се отличават силно застрашеният титикакски неотлетен гъбек и титикакски воден жаб. Някои видове колибри, особено някои звездички, могат да се видят на височина над 4 000 метра (13 100 фута), но по-голямо разнообразие се намира на по-ниски височини, особено във влажните Андийски гори (\"облачни гори\") на склоновете в Колумбия, Еквадор, Перу, Боливия и далечен северозападен Аржентина. Тези видове гори, които включват Юнгас и части от Чоко, са много богати на флора и фауна, въпреки че се срещат малко големи бозайници, изключенията биват заплашеният горски тапир, обикновеният мечка и жълтата вълнена маймуна.\r\n\r\nПтици от влажните Андийски гори включват планински тукани, кетцали и андски кок-о-рок, докато смесени стада от видове, доминирани от танагри и фурнариди, често се виждат - в противоположност на някои вокални, но обикновено криптични видове от крайбрежни градини, тапакулоси и мравколюбиви. Някои видове като кралският цинклод и бялокръвият ритм-разцеп влизат във връзка с Полилепис и, съответно, са заплашени.", "В миналото дъждовните гори са заемали голяма част от Северните Анди, но сега са намалели значително, особено в Чоко и вътрешните планински долини в Колумбия. Като противоположност на влажната част на андските склонове, са сравнително сухите части в по-голямата част от Западно Перу, Чили и Аржентина. Заедно с няколко вътрешни планински долини, те обикновено са доминирани от широколистни гори, храсти и растителност, достигаща до крайните склонове в близост до пустинята Атакама.\r\n\r\nПочвено-растителният свят на Андите е изключително разнообразен. Това е обусловено от голямата височина на горите, значителната разлика в овлажняването на западните и източните склонове. Височинната поясност в Андите е ясно изразена. Обособени са три пояса – тиера калиенте, тиера фрия и тиера елада.\r\n\r\nВ планинските червени почви на Андите на Венецуела растат широколистни (по време на зимното засушаване) гори и храсти. По-ниските части на наветрените склонове от Северозападните до Централните Анди са покрити с планински влажни екваториални и тропически гори, виреещи на латеритни почви (планинска растителност), както и смесени гори от вечнозелени и листопадни видове. Външният вид на екваториалните гори в планината слабо се отличава от този в равнинната част на континента; характерни са различни палми, фикуси, банани, какаови дървета и др. По-нагоре (до височина 2500 – 3000 m) характерът на растителността се изменя; типични са бамбук, дървесни папрати, храсти кока (източник на кокаин), хининово дърво. Между 3000 m и 3800 m се среща високопланинска растителност с ниски дървета и храсти, епифити и лиани, характерни са бамбук, дървесни папрати, вечнозелени дъбове представители на Миртови и Пиренови. По-нагоре основно е издръжлива ксерофитна растителност, парамос, многобройни сложноцветни; мъхови на плоските участъци и безжизнени каменисти пространства на полегатите склонове. Над 4500 m е поясът на вечните снегове и ледове.\r\n\r\nПó на юг в субтропичните чилийски Анди се срещат вечнозелени храсти върху кафяви почви. В Продълговатата долина има почви, по състав напомнящи чернозем. Растителността по високите плата е: на север – планински екваториални луга парамос, в Перуанските Анди и на изток от Пуна – сухи високопланински тропически степи халка, на запад от Пуна и по целия тихоокеански запад между 5 – 28° южна ширина – пустинен тип растителност (в пустинята Атакама – сукулентна растителност и кактуси).", "https://upload.wikimedia.org/wikipedia/commons/0/03/Andes_Chile_Argentina.jpg", "Андите са планинска верига, разположена в Южна Америка, естествено продължение на планинската верига Кордилери от Северна Америка.\r\n\r\nПростират се от най-северните части на континента до най-южните при остров Огнена земя. Най-висок връх е Аконкагуа – 6960 m, разположен на държавната граница между Чили и Аржентина. Части от Андите, освен в тези две държави, се намират и в Боливия, Венецуела, Еквадор, Колумбия и Перу.", "Анди", "Андите са дом на множество реки и езера, подхранвани от топенето на сняга и ледниците. Големи реки като Амазонка, Ориноко и Парана извират в Андите. Амазонката, по-специално, е тясно свързана с планините, получавайки принос от притоци, които започват в тях.\r\n\r\nЕзера високо в планината, образувани от талеж на ледни води, са разпръснати по целия регион на Андите. Тези езера допринасят за хидрологичния цикъл и поддържат уникални екосистеми. Примери включват езеро Титикака, разположено на висока надморска височина на границата между Перу и Боливия, както и различни ледникови езера на различни височини." },
                    { 9, "Денали има субарктически климат, характеризиран с екстремни температури и сурови метеорологични условия. Зимите са сурови с ледени температури, докато летните месеци могат да донесат по-меко време. Планината е известна с непредсказуемите и сурови метеорологични условия, включително силни ветрове, снежни бури и интензивна студ.", "Националният парк Денали, който включва планината, е дом на разнообразна дивеч. Големи бозайници като кафяви мечки, черни мечки, лосове, карибу, Долски овце и вълци свободно се движат из парка. Небето над Денали е постоянно посещавано от различни видове птици, включително орли, соколи и мигриращи птици. Паркът предоставя уникална възможност за любителите на дивечта да наблюдават и оценяват естественото биоразнообразие на региона.", "Растителността около Денали варира в зависимост от височината и климатичните условия. На по-ниски надморски височини процъфтяват борови гори, владеещи се от ела, бор и ела. С възходенето, ландшафтът преминава в алпийска тундра, характеризирана с устойчиви треви, мъхове и диви цветя, приспособени към трудните условия. По-високите височини се характеризират със сняг и лед, които ограничават растителния свят.", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ed/Mount_McKinley_and_Denali_National_Park_Road_2048px.jpg/1280px-Mount_McKinley_and_Denali_National_Park_Road_2048px.jpg", "Денали, известен като планината Маккинли, се намира в Аляска Рейндж в щата Аляска, Съединени щати. Той е най-високият връх в Северна Америка, издигащ се на 6 190 метра (20 310 фута) над морското равнище.", "Денали", "Регионът около Денали е украсен с множество ледници, ледени полета и безпетлени езера, образувайки интригуваща мрежа от водни обекти. Тези ледници спомагат за формирането на няколко големи реки, допринасяйки за уникалната хидрология на района." },
                    { 10, "Климатът е екваториален планински. Сухите сезони са от януари до март и от юли до септември. През останалото време условията са като в Европа през зимата. За Килиманджаро средното количество на годишните валежи е около 1000 mm.\r\n\r\nВъпреки че се намира в тропично-екваториалната климатична зона, едно от най-горещите места в света, на върха на Килиманджаро има постоянна снежна покривка, включваща ледниците Фуртвенглер и Ребман. Поради глобалното затопляне ледената покривка постоянно се смалява, за което съдим от сателитни снимки.", "Големите животни са рядкост на Килиманджаро и са по-чести в горите и по-ниските части на планината. Сред опасните за туристите животни могат да бъдат слонове и кафяви биволи. Съобщава се, че се срещат още бушбъци, хамелеони, дик-дици, дуйкърси, мангусти, слънцеклюнове и кабанчета. Зебри, леопарди и хиени са наблюдавани от време на време на платото Шира. Специфични видове, свързани с планината, включват шреклията на Килиманджаро и хамелеона Kinyongia tavetana.", "Растителността на Килиманджаро е разнообразна и се променя с височината и климатичните условия. На по-ниските височини се срещат борови гори, доминирани от ела, бор и мъжки ела. С преход към по-високите височини, пейзажът преминава в алпийски тундра, характеризирана с устойчиви треви, мъхове и цветя, адаптирани към трудните условия. На по-високите височини сняг и лед ограничават растителността.\r\n\r\nНационалният парк Килиманджаро, който обхваща планината, е дом на разнообразна гама от дивеч. Големи бозайници като слони, бизони, еланди и различни видове маймуни обитават долните склонове. Любителите на птиците могат да наблюдават разнообразие от птичи видове, включително слънчогледи, барбети и слънчев птич. Паркът предоставя уникална възможност да се насладите на разнообразието от флора и фауна на тази иконична африканска планина.", "https://images.followalice.com/4hWRlLrxdRQyRPjfcw3fi6/3a64145aef24a98fa291baeaa38b7a0b/Mt_Kilimanjaro_seen_from_Amboseli.jpg?fit=fill&w=1600&h=1600&fm=jpg", "Килиманджаро се намира в североизточната част на Танзания, близо до границата с Кения, която преминава по северното и източното подножие на планината. Административно тя е част от регион Килиманджаро, като основната й част влиза в окръг Ромбо, а по-малки части - в окръзите Хаи и Моши - селски. Цялата територия на планината влиза в границите на Националния парк Килиманджаро.", "Килиманджаро", "Водите, изтичащи при топенето на леда, захранват в значителна степен двете реки в планината, Пангани и Галана, но 90% от валежите се поглъщат от гората. По тази причина изчезването на ледниците не би трябвало да има значително пряко въздействие върху местната хидрология, за разлика от обезлесяването и дейността на хората, свързана с четирикратно увеличение на използваната за напояване вода през последните четири десетилетия.\r\n\r\nГорите на Килиманджаро получават 1,6 милиарда m³ вода годишно, от които 5% от пряк контакт с облаците мъгла. Две трети от тази вода се връща в атмосферата чрез изпарение. По този начин гората играе ролята на троен резервоар – чрез почвата, чрез биомасата и чрез въздуха." },
                    { 11, "лиматът на Каракорум е предимно полупустинен, рязко континентален. По южните му склонове се проявява овлажняващото влияние на мусоните от Индийския океан, а за северните склонове е характерна изключителната аридност. В подножията на склоновете годишната сума на валежите е около 100 mm, а на височина над 5000 m – над 500 mm. Валежите във високопланинската зона са с летен максимум и са винаги във вид на сняг. За голяма част от планината са характерни отрицателните средногодишни температури на въздуха. Характерни особености на климата се явяват също интензивната слънчева радиация, големите денонощни амплитуди на температурата на въздуха и значителната изпаряемост.", "Най-специфичните представители на животинския свят се явяват: тибетски як, антилопа оронго, антилопа ада, а по южните склонове – диво магаре. От хищниците се среща снежен барс. Има многочислени гризачи (сив хомяк и др.), а най-характерните птица са пухопръста пустинарка, тибетски улар, яребица, сърпоклюн, белогърдест гълъб, червена планинска чинка. Участъците по бреговете на реките и езерата се използват за пасища. По южните склонове на места е развито земеделие, като до около 4000 m н.в. се отглежда ечемик, грах, люцерна, а по най-ниските склонове – грозде, праскови.", "Значителните контрасти в овлажняването на северните и южните склонове и колебанията на височините в Каракорум обуславят голямото разнообразие от ландшафти, разпределението на които се подчинява на закономерностите на височинната зоналност. По северните склонове до височина 2400 – 2800 m са разпространени пустинни ландшафти с рядка растителна покривка от калидиум, реомюрия и ефедра, а обширни пространства са съвършено лишени от растителност. Само около изворите на река Раскемдаря и нейните притоци има участъци заети с храсталаци (предимно барбарис) и топола. До 3100 m н.в. господстват пустинно-степните ландшафти, заети от редки участъци с терескен в съчетание с треви (типчак, коило). До 3500 m н.в. преобладават планинските степи, а в най-овлажнените и защитени от ветровете места – ливадни степи с участие на кобрезия. Още по-нагоре следват високопланински терескенови и пелино-терескенови пустини в съчетание със солончакови пасища. По южните склонове и по долините на реките до 3000 – 3500 m н.в. са развити гори от бор и хималайски кедър, а покрай реките – от топола. Нагоре следват високопланински степи с елементи на алпийски пасища.", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Baltoro_glacier_from_air.jpg/800px-Baltoro_glacier_from_air.jpg", "Каракорум (наименованието е от тюркски произход и означава „Черни скалисти планини“) е планинска система в Централна Азия, разположена на териториите Индия, Пакистан и Китай, между планинските системи на Хиндукуш на северозапад, Кунлун на север и Гангдисе (Трансхималаи, Гандисишан) на юг. Дължина от северозапад на югоизток около 500 km, а заедно с източните си продължения – хребетите Чангченмо и Пангонг, осъществяващи връзката ѝ с Тибетската планинска земя, – над 800 km. Ширина от 150 до 250 km.", "", "Планината служи за вододел между басейните на реките Инд (Шигар, Шайок) и Тарим (Раскемдаря и притока и Кърчинбулак). Основното подхранване на реките се дължи на топенето на сезонните и вечните снегове и ледници през лятото. Грунтовите води се формират в наносните конуси и способстват за по-равномерния отток през годината. През зимата всички реки замръзват и се образуват големи ледени натрупвания. В средните и долни части на склоновете реките имат предимно транзитен характер. В централните части на междупланинските котловини понякога се срещат безотточни езера и солени блата." }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "Date publish", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "dea12856-c198-4129-b3f3-b893d8395082", "Може би много от вас са посещавали хижите в България. Условията в една хижа много зависят от нейната локация, поддръжка през годините и разбира се от хижарите. Има хижи, които се доближават до хотели – с много богато меню, самостоятелни стаи с тоалетни, бани с топла вода. Има и такива, които се спи в стая по 10 човека, само външна тоалетна и избор от две ястия. Нито едно от двете не изключва хижата да е много уютна с дружелюбни хижари и да си изкарате много хубаво.Все пак е важно преди да тръгнете на преход да сте наясно с условията на хижата, на която отивате, за да не бъдете изненадани или разочаровани. В следващите редове ще ви споделим някои от основните неща, които трябва да знаете за хижите в България. Важно е да уточним, че тези редове не се отнасят за всяка хижа.\r\nХрана: в много от случаите храната, която се предлага по-хижите се състои от супа като боб или леща, скара и салата.Закуската е често пържени филии, мекици или макарони.Понякога не се предлага обяд, случва се и храната да е свършила или да се сервира само в определени часове.За пиене се предлага вода, бира, кафе, чай и някаква газирана напитка.Има хижи и с много богато и разнообразно меню. Съвет: Носете се винаги храна с вас, за всеки случай.\r\nЛегловата база: в повечето хижи стаите са за 6,8,12 души.Стаите са общи (без значение от пола). Има хижи и с индивидуални стаи за по 2-ма, но се среща много рядко.В много от хижите леглата за двуетажни.Понякога стаята е с нарове (сковани дъски на разстояние от пода). Спи се един до друг.На прозорците няма комарници.В по-хладните вечери не винаги има отопление в стаите.Одеяла може да не са ви достатъчни, носете си дебели дрехи.Неписано правило е преди да напуснете стаята да съберете чаршафите от леглото – така помагате на хижарите.Съвет: Ако прецените може да си носите компактен чаршаф, както и спален чувал, ако искате да се чувствате по-комфортно. Прането и съхненето на чаршафите в повечето случаи е трудоемко за хижарите. Използвайки ваши чаршафи или спален чувал улеснявате тяхната работа.\r\nТоалетна: повечето тоалетни в хижите са общи.В никои хижи и заслони тоалетните са външни.Съвет: Носете си тоалетна хартия/кърпички. Моля, не ползвайте и не изхвърляйте мокри кърпи в природата!\r\nБаня:бъдете подготвени, че може и да не си вземете топъл душ след дълъг преход.Често на високопланинските хижи баня няма.Често се случва да чакате за ред.Топла вода може да няма или да е свършила.Почти винаги банята е обща (мъже и жени).В някои хижи има такса за използване на банята (2-3 лв.) Съвет: Не забравяйте да сложите в багажа компактна кърпа, сапун и джапанки.\r\nТок и обхват: в някои хижи се спира тока след 22:00 часа. До тогава е добре да сте се подготвили за следващия ден и вече да сте в леглата.Много често, особено във високопланинските хижи няма покритие на мобилните оператори. Понякога има определено място като камък, възвишение където се хваща обхват на определен оператор. Съветваме ви да попитате хижарите, те ще ви кажат.Съвет: Носете си външни батерии за телефона. Ако вие нямате обхват, проверете дали някой ваш приятел на друг мобилен оператор има.\r\nРезервиране на нощувка: хижата е място, в което винаги да можеш да намериш подслон и въпреки това в днешно време е почти задължително да се обадите, за да си запазите места в дадена хижа.Понякога е трудно да се свържем с хижарите заради липсата на обхват. Пробвайте няколко пъти да се обадите или пишете на Viber или SMS.Ако плановете ви се променят е важно да се обадите предварително и да кажете, че нощувката отпада, защото хижарите ще ви очакват и така пазят места, които могат да дадат на други хора.Съвет: В по-популярните хижи и особено през уикендите в летния сезон ви съветваме да направите резервация поне 2,3 седмици по-рано.\r\nЦени: цените по хижите често са по-високи отколкото може би очаквате. Споделяме ориентировъчни цени, за да знаете колко пари да си вземете и да не останете изненадани.\r\n\r\nНастаняване – 20 лв. – 40 лв.Супа – 2 лв. – 5 лв.Салата – 4 лв. – 8 лв.Скара – 2,50 лв. – 3,50 лв. / бр.Безалкохолно/ Бира – 3 лв. -5 лв.Чай/Кафе – 2 лв. – 3 лв.\r\nТакса за баня – 2 лв. – 3 лв.\r\nОще:в някои хижи трябва да се ходи без обувки, затова е добре да си носите чехли, ако ходенето боси ви притеснява.В повечето случаи след определен час не трябва да се вдига шум.Има хижи, в които вие трябва да си измиете посудата, която използвате.Старайте се да не оставяте боклуци в хижата, каквото можете вземете с вас.Възможно е в хижата да попаднете на някоя буболечка или животинка. На нас много рядко ни се е случвало до попадаме, но все пак имайте предвид, че не е е изключено, все пак се намирате сред природата.Ако сте на хижа, която е достъпна с кола, не се учудвайте ако попадне на парти със силна музика, особено през уикенда.Не забравяйте, че въпреки че си плащате за нощувка и храна, вие сте гости на хижата и трябва да се отнасяте с уважение към мястото и стопанина.", new DateTime(2024, 3, 3, 21, 23, 28, 646, DateTimeKind.Local).AddTicks(889), "https://planinka.bg/wp-content/uploads/2023/09/DSCF1341-copy-683x1024.webp", "Хижите в България – условия, съвети и неписани правила" },
                    { 2, "dea12856-c198-4129-b3f3-b893d8395082", "1. Проучете маршрута преди да тръгнете\r\nМного важно е да сте запознати с маршрута преди да тръгнете. Проучете дължината, денивелацията и приблизителното времетраене. Преценете дали маршрутът е подходящ за вас и групата ви. Информирайте се дали има трудни и опасни участъци, има ли водоизточници по пътя и къде са най-близките хижи и заслони. Задължително проверете и следете метеорологичните условия.\r\n\r\n\r\n2. Не тръгвайте сами в планината\r\nНе тръгвате в планината сами дори за кратки, еднодневни преходи по познати маршрути. Инцидентите в планината не са за подценяване и винаги е добре да имате надежден спътник, който да повика помощ в случай на нужда.\r\n\r\n\r\n3. Уведомете близките си за прехода\r\nДобре е близките ви да са уведомени за планувания преход, предполагаемото пристигане и връщане. Регистрирането в хижите по маршрута ще помогне да бъдете локализирани при инцидент или загубване в планината.\r\n\r\n4. Тръгвайте винаги рано сутрин\r\nМного е важно да тръгнете рано сутрин. По време на прехода може да възникнат непредвидени ситуации, които да ви забавят, затова е важно да имате достатъчно време да пристигнете в светлата част на деня. Най-добре е по-голямата част от предвидения преход да се измине до обяд. През зимата планирайте достигането на целта си не по-късно от 15:00 часа.\r\n\r\n\r\n5. Движете се с умерено темпо\r\nТемпото на движение е много важно. За да не се задъхвате, наложете си постоянно, равномерно темпо. Забързаният ход с чести почивки ще ви умори повече. За да се настрои организмът ви към натоварването тръгнете бавно и постепенно усилвайте темпото, не спирайте рязко, а плавно намалете ритъма преди почивка. Старайте се да дишате равномерно и дълбоко.\r\n\r\n\r\n6. Съобразявайте скоростта на придвижване\r\nТемпото на движение е много важно. За да не се задъхвате, наложете си постоянно, равномерно Скоростта на придвижване зависи от денивелацията, сложността на терена и метеорологичните условия, но най-определяща е вашата собствена физическа форма. За да не се разкъсва групата, поддържайте темпо, съобразено с най-слабо подготвените участници.\r\n\r\n7. Не съкращавайте пътя за сметка на сигурността\r\nВодещо условие за избиране на маршрута е безопасността. Вземете под внимание структурата на терена (сипеи, ронливи скали, улеи, хлъзгави склонове), метеорологичните условия и дали хората във вашата група са в състояние да преминат маршрута.\r\n\r\n\r\n8. Пийте често, но по малко вода\r\nГолямото физическо натоварване ви кара да пиете повече вода заради усещането на сухота в гърлото. Не прекалявайте с водата при преход, защото това води до затрудняване на работата на бъбреците и сърцето, до обилно потене, при което организмът губи ценни соли. Най-добре е да пиете по няколко глътки на всяко спиране.", new DateTime(2024, 2, 5, 21, 23, 28, 646, DateTimeKind.Local).AddTicks(963), "https://planinka.bg/wp-content/uploads/2023/05/MANE3457-1024x819.webp", "Как да се придвижвате в планината" },
                    { 3, "dea12856-c198-4129-b3f3-b893d8395082", "В горещите дни бягаме в планината, за да намерим прохлада.\r\nИ все пак да не забравяме, че в планината слънцето е силно, затова слънцезащитата и хидратацията са изключително важни.\r\nЕто част от любимите ни продукти, които носим винаги с нас по време на преход:\r\nСлънчеви очила Clark на Тrevibulgaria. Освен, че са със 100% UV защита, лещите са минерални, което ги прави изключително устойчиви на надраскване.\r\nБъфовете на Bandittoheadware. Може да ги използвате като бъф или като кърпа, която да предпазава главата. Като три от основните им предимства са UV защитата, бързосъхнещи са и са изработени от рециклирани пластмасови бутилки.\r\nСлънцезащитния крем на Woodenspoon, който е със 100% натурални съставки. Серията Dry Oils е специално разработена със сухи натурални масла, за да не запушва порите.\r\nНикога не тръгваме на преход без вода. Дори и за кратка разходка е важно да бъдем хидратирани. Затова винаги носим с нас любимите бутилки за многократна употреба на Дизайница. Освен, че са леки и красиви, с тях спестяваме на планетата огромно количество пластмаса.", new DateTime(2024, 1, 8, 21, 23, 28, 646, DateTimeKind.Local).AddTicks(968), "https://planinka.bg/wp-content/uploads/2022/07/DSCF0368-819x1024.webp", "Слънцезащита в планината" }
                });

            migrationBuilder.InsertData(
                table: "Huts",
                columns: new[] { "Id", "Altitude", "Camping", "Description", "HasBathroom", "HasCanteen", "HasToilet", "ImageUrl", "MountainId", "Name", "Phone", "Places", "WorkTime" },
                values: new object[,]
                {
                    { 1, 2240.0, 0, "Разположена е край северната част на Безбожкото езеро в Северен Пирин. Предаставлява масивна пететажна сграда с капацитет 130 места с етажни санитарни възли и бани. Хижата е електрифицирана, водоснабдена, с централно отопление. Има ресторант, кафе-аперитив, лафка.", true, true, true, "https://www.tourism-bg.net/hiji/img/bezbog.jpg", 3, "Безбог", "0888286102", 130, 15 },
                    { 2, 2115.0, 0, "Хижа „Рилски езера“ е туристическа хижа, намираща се в Рила планина.Разположена е в близост до Седемте рилски езера, на около 2000 м надморска височина.Предлага настаняване в стаи с 2, 3, 4, 6, 7, 11 и 12 легла, като голяма част от по-малките стаи имат собствени санитарни възли. Останалите ползват тоалетни и умивалници на етажа и общи бани на някои от етажите. Хижата разполага с ресторант-столова, дневна с телевизор, бар с топли, студени и алкохолни напитки, както и сладки храни. Работи целогодишно.До хижата се достига пеш или чрез двуседалковия лифт „Рилски езера“, който тръгва от района на хижа Пионерска в Паничище.Сухият рид над хижата предлага идеални условия за каране на ски както от начинаещи (по писта), така и за екстремни ски и ски свободен стил по улеите над нея. На разположение на туристите е ски-влек тип 'паничка'.На 40 мин. път се намира по-старата хижа „Седемте езера“.", true, true, true, "https://www.btsbg.org/sites/default/files/styles/768x576/public/hiji/%D1%80%D0%B8%D0%BB%D1%81%D0%BA%D0%B8%20%D0%B5%D0%B7%D0%B5%D1%80%D0%B0%D0%B0.jpg?itok=B2mSYcnJ", 2, "Рилски езера", "0886509409", 0, 15 },
                    { 3, 1620.0, 0, "Намира се на главното било в местността Мандрището, на 1523 м н.в. Построена е през 1935 година, а през 1962 година е реконструирана. Представлява двуетажна масивна сграда с капацитет 60 места с вътрешна тоалетна. Разполага с туристическа кухня и столова. Към хижата има и друга двуетажна сграда с 30 легла и вътрешна тоалетна и умивалник. Хижа „Мазалат“ се нарежда на първите места сред най-добрите хижи в България.", true, true, true, "https://planinka.bg/wp-content/uploads/2022/02/MANE7681-copy-1024x683.webp", 1, "Мазалат", "0897475538", 60, 15 },
                    { 4, 2185.0, 0, "Разположена е на северния бряг на Синанишкото езеро, в непосредствена близост до връх Синаница. Хижата представлява масивна двуетажна постройка. На първия етаж е разположена просторна столова с кухня, има складови помещения и спално помещение за домакина. На втория етаж са обособени спалните помещения за туристи, като хижата може да приюти до 50 души. През летния сезон пред хижата се открива палатков лагер.Водоснабдена е и електрифицирана от генератор. Санитарните помещения са външни. През зимния сезон в хижата няма поддържащ персонал.Хижа „Синаница“ е построена през 1975 – 1977 г. от Туристическото дружество на гара Пирин – днешния град Кресна.", true, true, true, "https://planinka.bg/wp-content/uploads/2022/09/DSCF1118-819x1024.webp", 3, "Синаница", "0894360427", 48, 2 }
                });

            migrationBuilder.InsertData(
                table: "Lakes",
                columns: new[] { "Id", "Description", "ImageUrl", "MountainId", "Name" },
                values: new object[,]
                {
                    { 1, "Смята се, че е Горното Полежанско езеро (2710 м), въпреки че има различни измервания и спор дали е то или Леденото езеро в Рила планина.Горно Полежанското езеро се намира в Северен Пирин на 2710 м н.в. под връх Полежан. То е част от езерната група на Полежанските езера, които са три на брой. Често през сухите лета няма да го видите, защото то пресъхва.", "https://planinka.bg/wp-content/uploads/2022/08/MANE3567-1-1024x683.jpg", 3, "Горно Полежанско" },
                    { 2, "Езерото е дълго 200 m, широко 75 m и дълбоко до 2 m, а площта му е 14,4 дка. То е най-голямото и най-високо разположеното от езерата в Прекоречкия циркус на Мальовишкия дял. Оттича се на север, към долината на Горна (Трета) Прека река.Вдълбано е в подножието на връх Попова капа и Купените. Техните надвиснали скали създават забележителна акустика, която при буря отразява многогласно гръмотевиците.", "https://planinka.bg/wp-content/uploads/2022/09/DSCF4676-1024x683.webp", 2, "Страшното езеро" },
                    { 3, "Синанишкото езеро (Голямо Синивръшко езеро) е езеро в западния склон на Северен Пирин, разположено в дълбок циркус на 650 m на север-североизток от връх Синаница (Сини връх), на 2181 m н.в. Със своите 11,5 m дълбочина то е сред 10-те най-дълбоки езера в Пирин.Има продълговата форма (140 на 90 m) и площ от 1,01 ha. Оттича се подземно, но водите му излизат на повърхността след 120 m и дават началото на Синанишката река, ляв приток на река Влахинска река, ляв приток на Струма. На северния бряг на езерото е изградена хижа Синаница.", "https://planinka.bg/wp-content/uploads/2022/09/DSCF1129-1024x683.webp", 3, "Синанишко" }
                });

            migrationBuilder.InsertData(
                table: "Peaks",
                columns: new[] { "Id", "Altitude", "Description", "ImageUrl", "MountainId", "Name", "Partition", "SpecificLocation" },
                values: new object[,]
                {
                    { 1, 2376, "Връх Ботев е най-високият връх в Стара планина и с неговите 2375,9 м тя нарежда планината на 3-то място по височина в България, след Рила (връх Мусала – 2925 м) и Пирин (връх Вихрен – 2914 м). Намира се в Средна Стара планина, в Национален парк „Централен Балкан“. Разположението му в сърцето на страната и множеството туристически маршрути, които го опасват, го правят привлекателен за множество планинари. В подножието му се намира и най-високия водопад на Балканския полуостров – Райското пръскало. Той е основна атракция в местността със своите 124,5 м, което допълнително популяризира връх Ботев.", "https://izbulgaria.com/wp-content/uploads/2021/07/gledka-kam-vrah-botev-1024x768.jpg", 1, "Ботев", "Средна Стара планина", "Калоферска планина, И от заслон Ботев" },
                    { 2, 2340, null, null, 1, "Малък Юмрукчал", "Средна Стара планина", "Калоферска планина, С от вр.Ботев" },
                    { 3, 2275, null, null, 1, "Голям Кадемлия", "Средна Стара планина", "Калоферска планина, СИ от хижа Триглав" },
                    { 4, 2255, null, null, 1, "Млечния чал", "Средна Стара планина", "Калоферска планина, И от вр.Жълтец" },
                    { 5, 2227, null, null, 1, "Жълтец", "Средна Стара планина", "Калоферска планина,И от вр.Костенурката" },
                    { 6, 2226, null, null, 1, "Малък Кадемлия", "Средна Стара планина", "Калоферска планина,СИ от вр.Голям Кадемлия" },
                    { 7, 2209, null, null, 1, "Параджика", "Средна Стара планина", "Калоферска планина, ЮИ от заслон Маринка" },
                    { 8, 2198, null, null, 1, "Вежен", "Средна Стара планина", "Златишко-Тетевенска планина, Ю от хижа Вежен" },
                    { 9, 2197, null, null, 1, "Мазалат (Зли връх)", "Средна Стара планина", "Калоферска планина, ЮИ от вр.Пиргос" },
                    { 10, 2195, null, null, 1, "Пиргос", "Средна Стара планина", "Калоферска планина, И от вр.Голям Кадемлия" },
                    { 11, 2169, null, null, 1, "Миджур", "Западна Стара планина", "Чипровска планина, ЮЗ от хижа Миджур" },
                    { 12, 2169, null, null, 1, "Купена", "Средна Стара планина", "Троянска планина, СЗ от хижа Васил Левски" },
                    { 13, 2166, null, null, 1, "Левски (Амбарица)", "Средна Стара планина", "Троянска планина, СИ от хижа Добрила" },
                    { 14, 2143, null, null, 1, "Малка Амбарица", "Средна Стара планина", "Троянска планина, СИ от вр.Левски" },
                    { 15, 2136, null, null, 1, "Юрушка грамада", "Средна Стара планина", "Калоферска планина, СИ от вр.Параджика" },
                    { 16, 2115, null, null, 1, "Ушите", "Средна Стара планина", "Калоферска планина, СЗ от вр.Параджика" },
                    { 17, 2104, null, null, 1, "Каменица", "Средна Стара планина", "Златишко-Тетевенска планина, И от вр.Вежен" },
                    { 18, 2101, null, null, 1, "Малък купен", "Средна Стара планина", "Троянска планина, З от вр.Купена" },
                    { 19, 2075, null, null, 1, "Побита глава", "Средна Стара планина", "Калоферска планина, Ю от заслон Ботев" },
                    { 20, 2070, null, null, 1, "Тетевенска баба", "Средна Стара планина", "Златишко-Тетевенска планина, С от с.Антон" },
                    { 21, 2043, null, null, 1, "Булуваня", "Средна Стара планина", "Златишко-Тетевенска планина,СИ от с.Антон" },
                    { 22, 2035, null, null, 1, "Голям Кръстец", "Средна Стара планина", "Троянска планина, СИ от вр.Купена" },
                    { 23, 2035, null, null, 1, "Костенурката", "Средна Стара планина", "Троянска планина, С от хижа Васил Левски" },
                    { 24, 2033, null, null, 1, "Обов връх", "Западна Стара планина", "Чипровска планина, З от хижа Миджур" },
                    { 25, 2031, null, null, 1, "Картала", "Средна Стара планина", "Златишко-Тетевенска планина, СИ от вр.Паскал" },
                    { 26, 2029, null, null, 1, "Паскал", "Средна Стара планина", "Златишко-Тетевенска планина, СИ от хижа Паскал" },
                    { 27, 2016, null, null, 1, "Ком", "Западна Стара планина", "Берковска планина, ЮЗ от хижа Ком" },
                    { 28, 2011, null, null, 1, "Мартинова чука", "Западна Стара планина", "Чипровска планина, ЮЗ от заслон Мартиница" },
                    { 29, 2001, null, null, 1, "Косица", "Средна Стара планина", "Златишко-Тетевенска планина, С от хижа Паскал" },
                    { 30, 2001, null, null, 1, "Падитът", "Средна Стара планина", "Калоферска планина,Ю от вр.Пиргос" },
                    { 31, 2925, "Мусала е първенецът на Рила и най-високият планински връх в България и на целия Балкански полуостров. Надморската му височина е 2925,4 m, измерена от равнището на пристанище Варна. По-висок е с 8 m от следващия по височина връх на Балканите, Митикас в планината Олимп в Гърция, и с 11 m от първенеца на Пирин, връх Вихрен, който заема третото място в класацията. Мусала има относителна надморска височина от 2473 m, което го подрежда на 7-о място в Европа.", "https://svetogled.com/wp-content/uploads/2021/08/DSC_0050_1.jpg", 2, "Мусала", "Източна Рила", null },
                    { 32, 2902, null, null, 2, "Малка Мусала", "Източна Рила", "И от вр.Мусала" }
                });

            migrationBuilder.InsertData(
                table: "Peaks",
                columns: new[] { "Id", "Altitude", "Description", "ImageUrl", "MountainId", "Name", "Partition", "SpecificLocation" },
                values: new object[,]
                {
                    { 33, 2852, null, null, 2, "Иречек", "Източна Рила", "С от вр.Малка Мусала" },
                    { 34, 2792, null, null, 2, "Безименния връх", "Източна Рила", "С от вр.Мусала" },
                    { 35, 2790, null, null, 2, "Дено", "Източна Рила", "И от хижа Мусала" },
                    { 36, 2779, null, null, 2, "Голям Близнак", "Източна Рила", "З от Маричини езера" },
                    { 37, 2777, null, null, 2, "Малък Близнак", "Източна Рила", "Ю от вр.Мусала" },
                    { 38, 2773, null, null, 2, "Манчо", "Източна Рила", "И от Маричини езера" },
                    { 39, 2769, null, null, 2, "Юрушки чал", "Източна Рила", "С от хижа Грънчар" },
                    { 40, 2769, null, null, 2, "Песоклива вапа", "Източна Рила", "И от вр.Юрушки чал" },
                    { 41, 2765, null, null, 2, "Маришки чал", "Източна Рила", "Ю от Маричини езера" },
                    { 42, 2760, null, null, 2, "Студения чал", "Източна Рила", "СИ от вр.Малка Мусала" },
                    { 43, 2731, null, null, 2, "Голям Купен", "Северозападна Рила", "Ю от заслон Страшното езеро" },
                    { 44, 2729, "Мальовица е името на връх в северозападната част на планина Рила, висок 2729 m. Името на върха е свързано с Мальо войвода – борец срещу поробителите, загинал според преданието нейде в Мальовишката долина. Друго предположение е, че името произлиза от Малите езера, както планинците наричат езерата в североизточното подножие на върха.[1] На най-старите карти върхът е отбелязан с името Малевица. По труднодостъпните северни и източни склонове на връх Мальовица се намират едни от най-посещаваните от алпинисти скални стени в България. Северната отвесна стена на Мальовица е висока 124 метра и е символ в българския алпинизъм.", "https://www.standartnews.com/media/1/2023/10/14/388220/960x540.jpg?timer=1697268969", 2, "Мальовица", "Северозападна Рила", "СЗ от Еленино езеро" },
                    { 45, 2716, null, null, 2, "Черна поляна", "Средна Рила", "Ю от Павлев връх" },
                    { 46, 2713, null, null, 2, "Алеко", "Източна Рила", "ЮЗ от хижа Мусала" },
                    { 47, 2713, null, null, 2, "Рилец", "Средна Рила", "ЮЗ от Смрадливото езеро" },
                    { 48, 2706, null, null, 2, "Голям Скакавец", "Средна Рила", "З от вр.Мусала" },
                    { 49, 2704, null, null, 2, "Голяма Попова капа", "Северозападна Рила", "ЮИ от заслон Страшното езеро" },
                    { 50, 2698, null, null, 2, "Лопушки връх", "Северозападна Рила", "СЗ от заслон Кобилино бранище" },
                    { 51, 2697, null, null, 2, "Йосифица", "Средна Рила", "СИ от хижа Рибни езера" },
                    { 52, 2696, null, null, 2, "Отовишки връх", "Северозападна Рила", "СИ от хижа Иван Вазов" },
                    { 53, 2696, null, null, 2, "Отовишки връх", "Северозападна Рила", "СИ от хижа Иван Вазов" },
                    { 54, 2695, null, null, 2, "Ловница", "Северозападна Рила", "И от заслон БАК" },
                    { 55, 2691, null, null, 2, "Канарата", "Средна Рила", "Ю от хижа Рибни езера" },
                    { 56, 2691, null, null, 2, "Погледец", "Средна Рила", "СЗ от Халовитото езеро" },
                    { 57, 2686, null, null, 2, "Орловец", "Северозападна Рила", "ЮЗ от заслон БАК" },
                    { 58, 2683, null, null, 2, "Аладжа Слап", "Средна Рила", "СИ от седловина Кадиин гроб" },
                    { 59, 2683, null, null, 2, "Водни чал", "Средна Рила", "Ю от заслон Кобилино бранище" },
                    { 60, 2678, null, null, 2, "Реджепица", "Средна Рила", "Ю от вр.Канарата" },
                    { 61, 2678, null, null, 2, "Злия зъб", "Северозападна Рила", "ЮИ от заслон БАК" },
                    { 62, 2914, "Вѝхрен (до 29 юни 1942 г. Елтепе, Ел-тепе) е най-високият връх на Пирин. Със своите 2914 метра Вихрен е втори по височина в България след Мусала (2925,4) в Рила и трети на Балканския полуостров след Митикас (2917,727[3]) в Олимп. Гледан от Банско Вихрен прилича на пресечена пирамида, а от юг – на четиристенна пирамида. За този връх е характерно, че изглежда по много различен начин от различните посоки. Скалите, които изграждат Вихрен, са мрамори, които не задържат вода, поради което в целия район на върха няма реки и езера. Най-близките езера са Влахините на югозапад. Растителността по склоновете на Вихрен е бедна – трева и лишеи, докато животинският свят е по-богат – има птици, дребни гризачи, но най-вече диви кози, които обитават Казаните в подножието на върха. Цветето еделвайс се среща в изобилие по скалния ръб Джамджиеви скали.", "https://planinka.bg/wp-content/uploads/2022/07/MANE2800a.jpg", 3, "Вихрен", "Северен Пирин", null },
                    { 63, 2908, null, null, 3, "Кутело", "Северен Пирин", "С от вр.Вихрен" },
                    { 64, 2886, null, null, 3, "Бански суходол", "Северен Пирин", "СЗ от вр.Кутело" },
                    { 65, 2852, "Полежан (до 29 юни 1942 г. Мангър тепе, Мангър-тепе) е най-високият гранитен връх (карлинг) в Пирин и четвърти по височина след мраморните първенци Вихрен, Кутело и Бански суходол. Висок е 2850,4 m. Той е първенецът на Полежанското странично било, където се намират още Малък Полежан (2820 m), Газей, Безбог, Каймакчал и Дисилица, както и внушителният ръб Стражите. Старото му име, преди да бъде преименуван през 1942 г., е Мангър тепе, което идва от турската дума мангър, тоест монета. Това е така, защото върхът е покрит с каменни плочи, които подобно на монети се клатят и тракат, когато се върви по тях. Най-близката хижа е Безбог на около 2 ч. път. От Полежан от Полежанското било се отделят две малки странични била – Безбожкото с връх Безбог, което се спуска към Места, и Газейското с връх Газей, което се спуска към долината на Демяница и образува стръмна странична долина, по която върви пътека. Около Полежан се намират двете най-високи езера в Пирин – Горното Полежанско (2710 м), което е най-високо и в България, и Горното Газейско, което е на второ място в Пирин (2642 м). Те обаче не се намират в Полежанския циркус, който отстои на север.", "https://luckybansko.bg/wp-content/uploads/2020/08/2020-08-18_15h03_22.png", 3, "Полежан", "Северен Пирин", "СИ ог Горно Полежанско езеро" },
                    { 66, 2824, null, null, 3, "Каменица", "Северен Пирин", "ЮИ от заслон Тевно езеро" },
                    { 67, 2823, null, null, 3, "Малък Полежан", "Северен Пирин", "ЮЗ от вр.Полежан" },
                    { 68, 2821, null, null, 3, "Байови дупки", "Северен Пирин", "СЗ от вр.Бански суходол" },
                    { 69, 2799, null, null, 3, "Голяма Стража", "Северен Пирин", "ЮИ от хижа Демяница" },
                    { 70, 2765, null, null, 3, "Яловарника", "Северен Пирин", "Ю от вр.Каменица" },
                    { 71, 2756, null, null, 3, "Газей", "Северен Пирин", "СЗ от вр.Малък Полежан" },
                    { 72, 2754, null, null, 3, "Каймакчал", "Северен Пирин", "И от хижа Демяница" },
                    { 73, 2746, null, null, 3, "Тодорин връх", "Северен Пирин", "ЮИ от хижа Вихрен" },
                    { 74, 2738, null, null, 3, "Бъндеришки чукар", "Северен Пирин", "Ю от хижа Вихрен" }
                });

            migrationBuilder.InsertData(
                table: "Peaks",
                columns: new[] { "Id", "Altitude", "Description", "ImageUrl", "MountainId", "Name", "Partition", "SpecificLocation" },
                values: new object[,]
                {
                    { 75, 2729, null, null, 3, "Дженгал", "Северен Пирин", "З от Попово езеро" },
                    { 76, 2728, null, null, 3, "Разложки суходол", "Северен Пирин", "СЗ от вр.Байови дупки" },
                    { 77, 2722, null, null, 3, "Момин двор", "Северен Пирин", "СИ от заслон Тевно езеро" },
                    { 78, 2713, null, null, 3, "Десилица", "Северен Пирин", "СИ от вр.Каймакчал" },
                    { 79, 2709, null, null, 3, "Кадиев рид", "Северен Пирин", "СЗ от Горно Брезнишко езеро" },
                    { 80, 2688, null, null, 3, "Албутин", "Северен Пирин", "СИ от хижа Загаза" },
                    { 81, 2686, null, null, 3, "Зъбът", "Северен Пирин", "З от вр.Яловарника (2765 м)" },
                    { 82, 2686, null, null, 3, "Куклите", "Северен Пирин", "ЮЗ от вр.Зъбът" },
                    { 83, 2684, null, null, 3, "Кралев двор", "Северен Пирин", "ЮИ от заслон Тевно езеро" },
                    { 84, 2683, null, null, 3, "Башлийски чукар", "Северен Пирин", "СИ от заслон Спано поле" },
                    { 85, 2675, null, null, 3, "Малка Каменица", "Северен Пирин", "ЮИ от заслон Тевно езеро" },
                    { 86, 2674, null, null, 3, "Демирчал", "Северен Пирин", "Ю от Горно Брезнишко езеро" },
                    { 87, 2669, null, null, 3, "Муратов връх", "Северен Пирин", "ЮЗ от хижа Вихрен" },
                    { 88, 2662, null, null, 3, "Валявишки чукар", "Северен Пирин", "СЗ от заслон Тевно езеро" },
                    { 89, 2657, null, null, 3, "Джано", "Северен Пирин", "Ю от Попово езеро" },
                    { 90, 2654, null, null, 3, "Хлевен", "Северен Пирин", "СИ от хижа Пирин" },
                    { 91, 2653, null, null, 3, "Безбог", "Северен Пирин", "ЮЗ от хижа Безбог" },
                    { 92, 2191, "Връх Голям Перелик е най-високият връх в Родопите. С него Родопа се нарежда на седмо място сред българските планини. Планинското било е покрито с прекрасни иглолистни гори, сред които се намират живописни поляни.", "https://www.btsbg.org/sites/default/files/obekti/vruh-golyam-perelik-rodopi.jpg", 4, "Голям Перелик", "Западни Родопи", "ЮЗ от хижа Перелик" },
                    { 93, 2188, null, null, 4, "Карлъка", "Западни Родопи", "ЮЗ от с.Гела" },
                    { 94, 2186, null, null, 4, "Голяма Сютка", "Западни Родопи", "ЮЗ от хижа Пашино бърдо" },
                    { 95, 2147, null, null, 4, "Малък Перелик", "Западни Родопи", "СЗ от вр.Голям Перелик" },
                    { 96, 2136, null, null, 4, "Краставата чука", "Западни Родопи", "ЮИ от вр.Карлъка" },
                    { 97, 2110, null, null, 4, "Кузуятак", "Западни Родопи", "И от хижа Перелик" },
                    { 98, 2095, null, null, 4, "Голям Персенк", "Западни Родопи", "З от хижа Чудните мостове" },
                    { 99, 2087, null, null, 4, "Шабалиева каба", "Западни Родопи", "С от вр.Малък перелик" },
                    { 100, 2082, null, null, 4, "Баташки снежник", "Западни Родопи", "Ю от Батак" },
                    { 101, 2079, null, null, 4, "Малка Сютка", "Западни Родопи", "Ю от вр.Голяма Сютка" },
                    { 102, 2074, null, null, 4, "Малък Персенк", "Западни Родопи", "Ю от хижа Персенк" },
                    { 103, 2055, null, null, 4, "Рядката ела", "Западни Родопи", "СЗ от хижа Перелик" },
                    { 104, 2034, null, null, 4, "Мусаята", "Западни Родопи", "ЮЗ от вр.Голям Перелик" },
                    { 105, 2000, null, null, 4, "Преспа", "Западни Родопи", "ЮИ от с.Манастир" },
                    { 106, 1994, null, null, 4, "Помаккидик", "Западни Родопи", "Ю от хижа Ледницата" },
                    { 107, 1992, null, null, 4, "Модър", "Западни Родопи", "СЗ от с.Орехово" },
                    { 108, 1991, null, null, 4, "Въртележка", "Западни Родопи", "И от вр.Баташки снежник" },
                    { 109, 1988, null, null, 4, "Баталач", "Западни Родопи", "ЮЗ от вр.Голяма Сютка" },
                    { 110, 1981, null, null, 4, "Новака", "Западни Родопи", "ЮЗ от вр.Голям Перелик" },
                    { 111, 2251, "Руен е най-високият връх (2251 m) в Осоговската планина, на границата на България със Северна Македония.", "https://patekite.info/wp-content/uploads/2018/09/vryh-shapka-osogovo.jpeg", 5, "Руен", null, null },
                    { 112, 2230, null, null, 5, "Мали Руен", null, "СИ от вр.Руен" },
                    { 113, 2188, null, null, 5, "Шапка", null, "СИ от вр.Мали Руен" },
                    { 114, 2139, null, null, 5, "Горна Сулумка", null, "ЮИ от вр.Мали Руен" },
                    { 115, 2085, null, null, 5, "Царев връх", null, "ЮЗ от вр.Руен (Северна Македония)" },
                    { 116, 2069, null, null, 5, "Църни камък", null, "СИ от вр.Шапка" }
                });

            migrationBuilder.InsertData(
                table: "Peaks",
                columns: new[] { "Id", "Altitude", "Description", "ImageUrl", "MountainId", "Name", "Partition", "SpecificLocation" },
                values: new object[,]
                {
                    { 117, 2047, null, null, 5, "Човеко", null, "С от заслон Превала" },
                    { 118, 1993, null, null, 5, "Таштепе", null, "З от рудник Руен" },
                    { 119, 1984, null, null, 5, "Балтажийница", null, "ЮИ от вр.Руен" },
                    { 120, 1972, null, null, 5, "Човечето", null, "И от рудник Руен" },
                    { 121, 8848, "Еверест (на тибетски: – Джомолунгма: „Богинята майка на Земята“; на непалски:  – Сагарматха: „Високо в небесата“) е връх в Хималаите, най-високият от 14-те планински върхове осемхилядници, в Азия и на Земята. Статутът на най-висок връх в света привлича катерачи от всички категории, от най-опитните до новаци, готови да заплатят солидни суми на професионални планински водачи, обикновено шерпи, за да направят успешно изкачване. Планината не изпъква с изключителни алпинистки трудности при изкачването по стандартния маршрут, за разлика от други осемхилядници като К2 или Нанга Парбат. Въпреки това съществуват множество специфични опасности, като височинна болест, лошо време и силен вятър.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4b/Everest_kalapatthar_crop.jpg/250px-Everest_kalapatthar_crop.jpg", 6, "Еверест", "Махалунгурския дял", "На границата между Непал и Китайския Тибетски автономен регион." },
                    { 122, 8586, null, null, 6, "Канченджанга", null, null },
                    { 123, 8516, null, null, 6, "Лхотце", null, null },
                    { 124, 8463, null, null, 6, "Макалу", null, null },
                    { 125, 8201, null, null, 6, "Чо Ою", null, null },
                    { 126, 8167, null, null, 6, "Дхаулагири", null, null },
                    { 127, 8156, null, null, 6, "Манаслу", null, null },
                    { 128, 8126, "Нанга Парбате деветият по височина връх на Земята. Името му в превод означава „голата планина“. Понякога е наричан Диамир, което на санскрит означава „кралят на планините“.Планината Нанга Парбат взима много жертви през първата половина на XX век, поради което е известна и с прозвището „планината-убиец“. Въпреки че след този период те значително намаляват, върхът остава сред технически най-трудните за катерене. Характерно за него е, че се възвишава значително над всичко в близката околност.", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/22/Nanga-Parbat.jpg/250px-Nanga-Parbat.jpg", 6, "Нанга Парбат", null, null },
                    { 129, 8091, null, null, 6, "Анапурна", null, null },
                    { 130, 8012, null, null, 6, "Шиша Пангма", null, null },
                    { 131, 4810, "Монблан (на италиански: Monte Bianco – Бял връх или Бяла планина) е планински връх в Алпите (част от едноименен масив), най-висок в цяла Западна Европа. Спорът дали върхът се намира на френска територия или на френско-италианската граница все още не е решен.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR25azvCn83UqRcsHyGFgFjUURzin-Lakak0g&usqp=CAU", 7, "Монблан", null, null },
                    { 132, 4634, null, null, 7, "Дюфур", null, null },
                    { 133, 4545, null, null, 7, "Дом", null, null },
                    { 134, 4506, null, null, 7, "Вайсхорн", null, null },
                    { 135, 4478, "Матерхорн (на немски: Matterhorn, на френски: Mont Cervin, на италиански: Monte Cervino) е връх в Алпите (Пенински Алпи), висок 4478 m. Представлява живописен остатък (карлинг) от скален блок, издигнат от движенията на земната кора преди 50 млн. години, когато са се сблъскали континентите Африка и Европа. Той е разположен на границата между Швейцария и Италия. Има вечни снегове и ледници. Матерхорн е най-късно изкаченият от високите алпийски върхове. Красивата пирамидална форма на върха може да бъде видяна от швейцарския град Цермат и от италианските алпийски градове Брьой-Червиния и Валтурнанш.Матерхорн е вероятно най-разпознаваемият връх в Алпите, благодарение на своята специфична пирамидална форма.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6jyg7gj9s6m1QD7ZdY9GmmlIxyyXeX_AQDA&usqp=CAU", 7, "Матерхорн", null, null },
                    { 136, 4357, null, null, 7, "Дент Бланш", null, null },
                    { 137, 4314, null, null, 7, "Гран Комбен", null, null },
                    { 138, 4273, null, null, 7, "Фенстеррархорн", null, null },
                    { 139, 4193, null, null, 7, "Алечхорн", null, null },
                    { 140, 4158, null, null, 7, "Юнгфрау", null, null },
                    { 141, 4102, null, null, 7, "Бар дез Екрен", null, null },
                    { 142, 6424, null, null, 8, "Анкоума", null, null },
                    { 143, 5860, null, null, 8, "Кабарая", null, null },
                    { 144, 6052, null, null, 8, "Акотанго", null, null },
                    { 145, 5305, null, null, 8, "Серо Минчинча", null, null },
                    { 146, 6962, "Аконкагуа (на испански: Aconcagua) е най-високият връх в Южна Америка. Разположен е в планината Анди. Висок е 6962 m. Изграден е от андезит. Има 7 ледника, дълги до 6 km, площ – 76,6 km2 Той се намира в аржентинската провинция Мендоса. Върхът е разположен на около 112 km западно от град Мендоса и на около 15 km от границата на Аржентина с Чили. Аконкагуа е най-високият връх в Западното и Южното полукълбо и е най-високият изгаснал вулкан в света. Той е един от седемте най-високи континентални първенци и неофициално е наричан Колосът на Америка", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/Monte_Aconcagua.jpg/250px-Monte_Aconcagua.jpg", 8, "Аконкагуа", null, null },
                    { 147, 5401, null, null, 8, "Серо Бахо", null, null },
                    { 148, 5947, null, null, 8, "Алпамайо", null, null },
                    { 149, 5960, null, null, 8, "Карнисеро", null, null },
                    { 150, 6190, "Денали  е най-високият връх в Северна Америка и на територията на Съединените щати.", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Wonder_Lake_and_Denali.jpg/778px-Wonder_Lake_and_Denali.jpg", 9, "Денали", null, null },
                    { 151, 5895, "Връх Ухуру представлява най-високата точка в рамките на африканския континент и най-високият връх в Килиманджаро, чиято височина достига забележителните 5892 метра.", "https://www.infopointbg.com/media/18/3471.jpg", 10, "Ухуру", null, null },
                    { 152, 8611, "К2 или Чогори, или Годуин Остин е вторият по височина връх на Земята (след Еверест). Надморската му височина е 8611 m. Намира се в планината Каракорум, на границата между Пакистан и Китай.Върхът е открит през 1856 от европейска изследователска експедиция, ръководена от Хенри Годуин-Остин. Името „К2“ е дадено от члена на експедицията Томас Монтгомъри, тъй като върхът е бил вторият, забелязан в Каракорум. Останалите, открити от експедицията върхове, са получили имена K1, K3, K4 и K5, които впоследствеие са заменени съответно с имената Машербрум, Броуд пик, Гашербрум II и Гашербрум I. Въпреки че К2 също е имал местни имена, най-разпространено и използвано е останало „К2“.", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fb/K2_2006.jpg/250px-K2_2006.jpg", 11, "K2 (Чогори)", null, null },
                    { 153, 8068, null, null, 11, "Гашербрум I", null, null },
                    { 154, 8047, "Броуд Пик (наричан преди K3) е дванадесетият по височина връх в света. Намира се в Каракорум, в планинския масив Гашербрум[1] на границата между Китай и Кашмир, на 8 km от К2.", "https://upload.wikimedia.org/wikipedia/commons/5/5b/7_15_BroadPeak.jpg", 11, "Броуд пик", null, null },
                    { 155, 8035, null, null, 11, "Гашербрум II", null, null }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Description", "Difficulty", "Displacement negative", "Displacement positive", "Duration", "ImageUrl", "MountainId", "Name", "Rating", "Starting point" },
                values: new object[,]
                {
                    { 1, "Връхът може да се изкачи по два маршрута. Най-популярният е като тръгнете към “душеватката” и Попово езеро, след което се изкачите на седловината между върховете Полежан и Безбог (вторият етап на прехода, който сме описали тук, но в обратна посока). Маршрутът тръгва покрай десния бряг Безбожкото езеро, където вдясно ще видите изоставена постройка. Това са руините на старата хижа „Безбог“, която е разрушена от лавина през 1971 година. Пътеката към върха минава вляво на постройката. По тази пътека няма маркировка, но „пирамидките“ от камъни могат да ви водят.Поглед към връх Безбог в Пирин.Пътеката е доста стръмна и през по- голямата част е през клекове. Малко преди върха започва каменист участък, който също е стръмен. Внимавайте къде стъпвате между камъните.На самия връх има кръст и веднага ще го познаете щом го видите.Гледката оттук е много красива: на Изток част от Кременското езеро, до него върховете Севрия, Джано, Джангал както и част от Поповото езеро. В другата посока се виждат връх Полежан, Стражите и Десилица.", 7, 450.0, 450.0, "0.02:40", "https://planinka.bg/wp-content/uploads/2022/09/DSCF5440-1024x819.webp", 3, "Връх Безбог", 6.0, "Хижа Безбог" },
                    { 2, "Хижа „Ястребец“ – хижа „Мусала“\r\nОт лифта тръгнете по главната пътека към хижата. Пътеката е почти равна и широка. Най-вероятно ще видите много хора и трудно бихте се объркали. Маршрута до хижата отнема около час, а маркировката, която трябва да следвате е червена. Повече информация може да прочетете в статията ни за хижа „Мусала.\r\n\r\nВръх Иречек вляво и връх Мусала вдясно, отпред Мусаленското езеро\r\nХижа „Мусала“ – Ледено езеро\r\nСлед като стигнете хижа „Мусала“ ви остават около 2 часа преход до върха. До хижата се намират първите три езера от езерната група Мусаленски езера. Тръгнете по дясната страна на езерото пред хижа „Мусала“. От тук започва постепенно изкачване, пътеката става все по-камениста и все по-често се върви по морени. По пътеката ще минете покрай две езера, първото от които е Алековото езеро. След около 30-35 минути ще достигнете до Леденото езеро.\r\n\r\n\r\nЛедено езеро – връх Мусала\r\nСега е моментът да си отдъхнете преди последното изкачване. То е най-трудно и изморително заради голямата денивелация. Тук е и единствената чешма по пътя.\r\n\r\n\r\n\r\nИма две пътеки – лятна и зимна. Зимната е камениста и стръмна, но има обезопасително метално въже.\r\n\r\n\r\nЗа по-неопитните туристи е препоръчително да изберат лятната пътека. След около половин час нагоре ще стигнете най-високата точка на България.\r\n\r\nГледка от връх Мусала към Леденото езеро\r\n\r\nПред вас ще се открие уникална гледка към върхове и езера. На юг са Маричините езера, на север – Ледено езеро и местността, от която дойдохте, на изток – върховете Малка Мусала (2902 м) и Иречек (2852 м). При ясно време можете да видите в далечината на запад връх Мальовица.", 7, 104.0, 684.0, "0.05:00", "https://planinka.bg/wp-content/uploads/2022/09/DSC6986-1024x680.webp", 2, "Връх Мусала – най-високият връх в България и на Балканите", 8.0, "Хижа Ястребец" },
                    { 3, "Хижа „Партизанска Песен“ – чешма\r\nПътеката започва от хижа „Партизанска песен“, като първите 30 минути се върви в прохладна гора. Маршрутът до хижата е част от Е3, по-известен като Ком-Емине, и е добре маркиран (следвайте Пътеката започва от хижа „Партизанска песен“, като първите 30 минути се върви в прохладна гора. Маршрутът до хижата е част от Е3, по-известен като „Ком-Емине“, и е добре маркиран (следвайте червената маркировка). Пътеката ясно се вижда и трудно бихте могли да се изгубите. След приятната горичка лека по-лека наклона става по-голям и излизате на открит участък, от където в далечината се виждат върховете Бузлуджа и Шипка, както и няколко вятърни турбини. Има едно местенце с голямо дърво и пейки, където можете да направите кратка почивка. Не след дълго се излиза на чешмичката, тя е над пътеката и трябва да внимавате да не я пропуснете. Отдъхнете и напълнете вода, защото е единствената по пътя.\r\n\r\n\r\n\r\n\r\nЧешма – хижа „Мазалат“\r\nОт чешмичката поемете нагоре и надясно по баира. Тук е най-голямото изкачване от маршрута. Тази част се минава трудно, защото през лятото е пълно с боровинки, на които не бихте устояли. След като изкачите възвишението пътеката става почти равна и навлиза в букова гора. Не забравяйте да вдигате достатъчно шум, за да избегнете среща с дивите животни и най-вече с мечките. Пътеката е много приятна и живописна. Скоро след като излезете от гората ще стигнете табела на Национален парк, от там пътят става широк и открит. Това е последната част от маршрута. До хижата остават около 20-30 минути. В хижата можете да хапнете, починете и да се насладите на гледките към масива Триглав. Ако имате достатъчно време, може да се разходите до връх Вълча глава (30 минути), скален феномен Пеещите скали (55 минути) или да направите маршрута до връх Голям Кадемлия.", 7, 151.0, 498.0, "0.06:00", "https://planinka.bg/wp-content/uploads/2022/02/MANE7558-copy-1024x683.webp", 1, "Хижа „Мазалат“ – уют и красиви гледки в Стара планина", 7.0, "Партизанска Песен" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Description", "Difficulty", "Displacement negative", "Displacement positive", "Duration", "ImageUrl", "MountainId", "Name", "Rating", "Starting point" },
                values: new object[,]
                {
                    { 4, "Хижа „Вихрен“ – Муратово езеро\r\nНачалото на маршрута е от хижа „Вихрен“. Следвате синьо-жълтата маркировка, като трябва да тръгнете нагоре по стълбичките пред хижата. Оттам има леко изкачване по камъни, а след това и кратък равен участък. След 10-15 минути от началото на маршрута ще стигнете мостче. Вместо да минавате по него, трябва да тръгнете надясно по камъните, успоредно на реката.\r\nМалко след това има 15 минутно изкачване, което е най-трудната част от маршрута. Пътеката завива надясно и не след дълго пред вас ще се открие Муратовото езеро. В нашата статия може да прочетете подробно описание на маршрута от хижа „Вихрен“ до Муратово езеро.\r\nМуратово езеро – Бъндеришка порта\r\nОт Муратово езеро поемете наляво и продължeте нагоре по сипеите, като следвате синьо-жълтата маркировка. Непременно се обърнете назад, за да се насладите на езерото от високо. След като превалите баира не се заблуждавайте, че това е Бъндеришката порта. Следва по-равна част. Отляво ще видите няколко езера от групата Овинати и продължете по пътеката, която криволичи през клекове. Най-накрая ще зърнете в далечината портата, която е седловината между Муратов връх и Дончови караули.\r\nОттук започва изкачване по морени, камънаци и сипеи. На места е доста стръмно и трябва да си помагате с ръце и да внимавате къде стъпвате. Оглеждайте се за синьо-жълтата маркировка по камъните, за да не се отклоните от целта. Частта от Муратово езеро до Бъндеришка порта се минава за час и малко. След като стъпите на Бъндеришка порта пред вас се разкрива гледка към обширното Спано поле.\r\n\r\n\r\nБъндеришка порта – Синанишка порта\r\nОт Бъндеришката порта следвайте синята маркировка и продължете леко надясно. Следва и най-приятната част от прехода – вървите по почти равна и добре отъпкана пътека. Местността, в която се намирате се нарича Голямо Спано Поле. По пътя може да срещнете много стада с крави и диви коне. Ако стадата са на пътеката е добре да ги заобиколите, защото наоколо е възможно да има и кучета, които да се спуснат към вас, затова бъдете внимателни!\r\n\r\nПътеката към Синанишкото езеро\r\nСлед равния участък започва леко изкачване към Синанишката порта, което не е трудно, но отново трябва да внимавате. Когато стигнете портата идва и една от най-хубавите части – гледката към кристалните води на Синанишкото езеро и стръмните бели склонове на връх Синаница.\r\nСинанишка порта – Синанишко езеро и хижа „Синаница“\r\nОт портата следва продължително слизане към хижа „Синаница“- първоначално по камъни, а след това по мека пътека измежду клековете.\r\nСинанишкото езеро и хижа Синаница\r\nХижата изглежда близо, но слизането е продължително, все надолу и надолу. Най-накрая зад един завой се вижда простор за пране и след него се открива гледка към хижата и сините води на езерото. На юг от езерото се вижда връх Синаница (2516 м).\r\n\r\nСинанишкото езеро\r\nВръх Синаница в Пирин планина\r\nМаршрутът не е много труден, с редуващи се изкачвания и равни участъци и с изглед към красивите пирински езера. Оттук може да изкачите връх Синаница, да минете през Синанишка порта към заслон „Спано поле“ или да се върнете по обратния път до хижа „Вихрен“.", 7, 436.0, 663.0, "0.03:50", "https://planinka.bg/wp-content/uploads/2022/09/DSCF1021-copy-1024x683.webp", 3, "Хижа „Синаница“ и Синанишко езеро – едно от най-красивите в България", 7.0, "Хижа Вихрен" },
                    { 5, "От Калофер до местността Долен Параджик\r\nТръгваме към Райското пръскало от местността Паниците в Калофер. Маршрутът започва по стръмна горска пътека, която продължава около половин час. След като излезем от горския пояс, наклонът рязко намалява. Намираме се на обширни поляни, по които се движим в следващия час и петнайсетина минути. Тук е много горещо в летните дни. Препоръчвам ранно тръгване, за да избегнете обедния ад. Първата чешма се намира двайсетина минути след края на гората, леко вляво.\r\nСлед повече от час вървене на открито, излизаме на разклон в местността Долен Параджик. Наляво е екопътека „Бяла река“, надясно е жълтият маршрут за връх Ботев, а направо е нашата пътека към хижа Рай и Райското пръскало. 5 минути след разклона се открива една от най-красивите гледки по българските планини – към Джендема и връх Ботев над него. Зашеметяваща е! Има няколко пейки, на които да починете с тази гледка насреща. Общо от Калофер до тук е около 1:45 ч.\r\nОт местността Долен Параджик до хижа Рай\r\nНавлизаме в резерват Джендема, по чийто скалисти склонове тече Райското пръскало. Поглед напред разкрива какво ни очаква – слизане до долината под нас и изкачване до гребена на Райските купени отсреща. Хижа Рай се намира на върха му, от другата страна на гората.\r\nЗапочваме леко спускане по широк черен път, който навлиза в букова гора. След 15-20 минути пътят свършва на едно уширение. Вляво от него тръгва тясна горска пътека. Гората се сгъстява, а наклонът се увеличава, но не много. Скоро достигаме река Малка Бъзовица, след която наклонът се обръща нагоре. Малко след нея стигаме до чешмата Мечата глава. Бях по този маршрут през септември и почти не течеше вода по чучура. За щастие след десетина минути има друга чешма, която течеше нормално.\r\nМного скоро наклонът рязко се увеличава – веднага след като прекосим едно поточе. Оттук нататък вървенето става доста тежко в продължение на час и половина, може и повече – почти до хижа Рай. За щастие гората е гъста и предпазва от жаркото слънце. След като излезем от горския пояс, остават пет минутки до хижата. Ето че красивата ни цел се вижда ясно зад нея – Райското пръскало се спуска по Джендема.\r\nОт хижа Рай до Райското пръскало\r\nАко мислим, че се е свършило – не е така. Имаме още половин час до Райското пръскало по също толкова стръмна пътека, колкото досега. Продължаваме от другата страна на хижа Рай, минаваме покрай параклиса и се запътваме в посока водопада. Точно където се прекосява река Пръскалска, на първия завой на пътеката край едни камъни има разклонение. Основният маршрут продължава към Тарзановата пътека и връх Ботев, а вдясно излиза малка пътека, по която ние трябва да тръгнем. Тук ще вметна, че ако идвате май и юни, е много вероятно реката да е пълноводна. Затова е препоръчително да бъдете с хубави непромокаеми обувки.\r\nОттук до Райското пръскало няма много за описване. Само ще обърна внимание, че на места пътеката е сипеста и хлъзгава, но нищо сериозно. След двайсетина минути сме в подножието на водопада.\r\nВъзможност за продължение на маршрута е да слезем и да поемем по маршрута от хижа Рай до връх Ботев или към хижа Васил Левски.", 7, 0.0, 894.0, "0.05:00", "https://izbulgaria.com/wp-content/uploads/2021/07/raiskoto-praskalo-768x576.jpg", 1, "град Калофер – водопад Райското пръскало", 7.0, "" },
                    { 6, "Североизточният ръб (наричан просто северен) започва от северната страна на планината, в Тибет. Експедицията прави преход пеша по каменист път до ледника Ронгбук, където на 5180 m се намира базовият лагер. За да достигнат Лагер 2, катерачите преминават през средно големи морени по източната страна на Ронгбук до базата Чангце на 6100 m. Лагер 3 (Преден базов лагер) се намира под Северното седло на 6500 m. За да достигнат до Лагер 4, катерачите се изкачват по ледника, след което по фиксирани въжета достигат до върха на Седлото (7010 m). Оттам следва изкачване по каменистия северен ръб, до Лагер 5 на 7775 m. Следва диагонално подсичане на северното било до Жълтия пояс, където се намира Лагер 6 на 8230 m. Оттам катерачите атакуват върха.Катерачите се сблъскват с коварното препятствие, което представлява Първото стъпало на 8534 m. Следва Второто стъпало (~8600 m). За неговото преодоляване се използва съоръжение, наречено „Китайската стълба“ – постоянна метална стълба, поставена през 1975 г. от китайска експедиция. Оттогава тя неизменно служи на катерачите, и на практика всеки атакуващ върха е минал през нея. Третото стъпало (8689 – 8800 m) се преодолява почти пълзешком. След стъпалата до върха остават снежен наклон под почти 50 градуса и финалният хребет..", 7, 3669.0, 3669.0, "0.06:00", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Mount_Everest_North_Face.jpg/220px-Mount_Everest_North_Face.jpg", 6, "Североизточен ръб - Еверест", 8.0, "Базов лагер Еверест" },
                    { 7, "Абруци е маршрутът на K2, като 75% от алпинистите се справят с този проход, който се намира от пакистанската страна на планината. Този маршрут получава името си от принц Луиджи Амедео, херцог на Абруци, който за първи път се опитва да го пресече през 1909 г.Абруци минава покрай някои от най-техничните изкачвания на планината, „Коминът на къщата“ и „Черната пирамида“. Той също така вижда катерачи нагоре по „Гърлото на бутилката“, което се намира точно вляво от опасните сераци. Именно на това място през 2008 г. поредица от инциденти доведоха до смъртта на 11 алпинисти.", 7, 3461.0, 3461.0, "40.00:00", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c0/K2_Abruzzi_Spur.jpg/220px-K2_Abruzzi_Spur.jpg", 11, "Маршрутът на Абруци - К2", 7.0, "Базов лагер К2" },
                    { 8, "\"Gouter Route\" се е превърнал в \"нормалния маршрут\" за изкачване на Мон Блан. От техническа гледна точка, това е най-малко трудния път към върха, но не бива да бъде подценяван. Изкачването до хижа Gouter не е само ходене по една туристическа пътека, пътят минава през заледен терен и трябва да се справяте и с надморската височина. В средата на лятото големият брой хора по този маршрут увеличават обективните опасности: каменопади, опашки от изчакващи се хора при тесните участъци, навалица в хижата. За щастие, тези дразнители не правят маршрута по-малко интересен: \"Покрива на Европа\" е красив за изкачване връх, дори по нормалния път, и е удивително изживяване. Изкачването до Егюй дю Гутер на светлината на челниците, бавното набиране на височина по склоновете, преминаването на тесния хребет Босе, осветен от сутрешното слънце, остава незаличими следи в умовете на тези, осмелили се да приемат предизвикателството на тези височини.", 7, 2426.0, 2426.0, "2.00:00", "https://static.wixstatic.com/media/4bb50d_3e741a5aef4b434aa34a25bc182ea9e0~mv2.jpg/v1/fill/w_979,h_552,fp_0.50_0.50,q_85,usm_0.66_1.00_0.01,enc_auto/4bb50d_3e741a5aef4b434aa34a25bc182ea9e0~mv2.jpg", 7, "Gouter route - Монблан", 8.0, "Nid d'Aigle" }
                });

            migrationBuilder.InsertData(
                table: "TourAgencies",
                columns: new[] { "Id", "Description", "Email", "Name", "OwnerId", "Phone", "Rating" },
                values: new object[] { 1, "Climb and Hiking е изключително престижна туристическа агенция, посветена на страстта и приключението в света на планинарството. С богат опит в организацията на експедиции и планинарски турове, тази агенция съчетава страстта към природата със знание и професионализъм.\r\nНашата мисия е да предоставяме неповторими и вълнуващи преживявания за всички любители на приключенските спортове и обичатели на природата. Специализирани в организирането на експедиции в различни части на света, ние съчетаваме уникални маршрути, експертни водачи и безопасност на високо ниво, за да осигурим незабравими преживявания на върховете на света.\r\n\r\nНашите експедиции включват разнообразни дестинации - от високите върхове на Хималаите, през загадъчните планини в Южна Америка, до непокорените върхове в Африка и още много други. Съчетаваме екстремни предизвикателства с красивите природни пейзажи, за да създадем едно неповторимо приключение.\r\n\r\nНашите професионални гидове и инструктори са подготвени да водят клиентите ни през всеки етап от техния планинарски път. Разполагаме с модерно оборудване и осигуряваме пълна подкрепа за участниците в нашите турове, гарантирайки тяхната безопасност и комфорт.\r\nClimb and Hiking не предлага просто пътувания; предлагаме възможността за откриване на света от високо и по нов, невиждан начин. За нас, планинарството е не просто хоби, а начин на живот, който искаме да споделим с всички, които търсят истинско предизвикателство и незабравими преживявания в планината. Приключили сте да се катерите – започнете да живеете!", "climbAndHike@mail.com", "Climb and Hiking", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "0899001166", 9.0 });

            migrationBuilder.InsertData(
                table: "Waterfalls",
                columns: new[] { "Id", "Description", "ImageUrl", "MountainId", "Name" },
                values: new object[,]
                {
                    { 1, "Райското пръскало е най-високият постоянен водопад в България и на Балканския полуостров – 124,5 m.Намира се в Стара планина, на южния склон под най-високия старопланински връх – Ботев. На територията е на природен резерват „Джендема“, част от Национален парк „Централен Балкан“.", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg/1200px-%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg", 1, "Райското пръскало" },
                    { 2, "Водопад Рилска Скакавица е най-високият водопад в Рила (70 метра). Разположен е на 1750 метра надморска височина, а местността покрай него е много красива. Реката, която го захранва се нарича Скакавица, а преходът до него не е труден и е по добре маркирана пътека. Намира се на 10-на минути от хижа Скакавица, а за нея се тръгва от Паничище. Пътеката започва от началната станция на лифта за Седемте рилски езера и е добре обозначена с табели и маркировка. След като стигнете до хижата, следвате пътеката покрай реката, която ще ви отведе до подножието на водопада. През зимата водопадът замръзва.", "https://bookvila.bg/img/210711093630.jpg", 2, "Рилска скакавица" },
                    { 3, "Видимското пръскало се намира в природен резерват „Северен Джендем“, който обхваща северния склон на  връх Ботев. Представлява образувание от три отделни потока, които се събират в един. Най-близкото населено място до водопада е гр. Априлци. В бившето село Видима, което вече е част от града, се намират ВЕЦ Видима и хижа Видима. От там е и пътят, минаващ покрай Пръскалска река, по който се стига до водопада. По пътя е обособена и „Зелена класна стая”, където по достъпен игрови начин децата могат да се запознават с растенията, животните и да играят.", "https://bookvila.bg/img/210709032337.jpg", 1, "Видимско пръскало" }
                });

            migrationBuilder.InsertData(
                table: "Expeditions",
                columns: new[] { "Id", "Days", "End date", "Excludes", "Extras", "Includes", "OrganiserId", "Price", "Program", "RouteId", "Start date", "TourAgencyId" },
                values: new object[] { 1, 71, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Западен гид - може да се добави на частна основа.\r\nМеждународно пътуване до Катманду\r\nВсички полети с хеликоптер, използвани по лични причини\r\nЛична туристическа застраховка\r\nЛична екипировка и екипировка за катерене\r\nНепалска виза\r\nДопълнителни кислородни бутилки (700 USD всяка)\r\nРазходи, свързани с преждевременно приключване на експедиция или преждевременно напускане на експедиция.\r\nРазходи, свързани с удължаване на пътуване поради лошо време или други обстоятелства, включително разходите за допълнителни нощувки\r\nБонус за деня на срещата на върха към вашия водач шерпа от 2000,00 USD", "ХОТЕЛ ЯК И ЙЕТИ\r\n3 нощувки в двойна/двойна стандартна стая в този луксозен 5-звезден хотел, предлагащ съчетание от съвременна изтънченост и културно наследство със своя 100-годишен дворец и новопроектираната структура на хотела за 495$", "Такса за разрешение за Еверест (в момента $11,500.00 на човек)\r\nТакса за ледопад Кхумбу\r\nSPCC такса за боклук и разходи за управление на боклука в базовия лагер\r\nКолективна такса за фиксирана линия над базовия лагер\r\nФонд за базовия лагер на Himalayan Rescue Assn за спешни медицински случаи и покритие за шерпи.\r\nНадбавка за офицер за връзка\r\nКатерене на шерпи\r\nПерсонал на базовия лагер - готвач, помощник-готвач, носачи\r\nЗастрахователно покритие на персонала за спешна евакуация с хеликоптер и медицинска застраховка\r\nВсички хранения\r\nПалатки за спане в базовия лагер (1 на член) и общи палатки в по-високите лагери\r\nПалатка за тоалетна и душ\r\nСъоръжения за първа помощ и използване на HRA станцията в базовия лагер\r\nКислородни бутилки (3 литра х 6 на човек), плюс една маска и регулатор на човек\r\nФиксирано въже и снежни барове (обикновено се предоставят от общността, но ние също ще имаме наши собствени)\r\nСтолова палатка BC и C2\r\nПреходът струва до базовия лагер и транспорт на оборудването с якове и носачи\r\nНастаняване в Катманду - двойна стая за 3 нощувки\r\nЛукла полет", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 55000.00m, "Връх Еверест е общо 10-седмична експедиция, с 2 седмици време за преход и 8 седмици период на изкачване. Не очаквайте обаче да се приберете у дома след изкачването на Еверест и да се върнете към нормалния живот, може да отнеме седмици и дори месеци, за да се възстановите напълно, както физически, така и психически.\r\n\r\nРаботим по съгласуван принцип за достигане на определени височини и спане в определени лагери по структуриран начин за период от осем седмици след достигане на базовия лагер, което позволява както зареждане на лагерите, така и оптимално време за аклиматизация. Програмата за катерачите се определя до голяма степен от графика на лагерите за зареждане, който от своя страна се определя от времето и позволява достатъчно почивки. Всеки опитен катерач ще разбере тази политика и ще се чувства удобно с гъвкавостта.\r\n\r\nПОХОД И АКЛИМАТИЗАЦИОНЕН ПЕРИОД ПРИ ИЗКАЧВАНЕ НА ЕВЕРЕСТ\r\nПървите 10 дни преминават в преход до базовия лагер. След това следва период на почивка и установяване. Ръководителите на екипи ще се срещнат и ще обсъдят съвместни операции по въпроси като поставяне на стационарни линии. Екипите също трябва да изчакат ледопадът да бъде „поправен“ от екипите на шерпите, чиято работа е да поставят стълбите и фиксираните въжета. Това отново може да отнеме дни.\r\n\r\nСледващият месец ще бъде прекаран в извършване на редица проучвателни изкачвания до лагер 1 през ледопада Khumbu и след това до лагер 2, където е важно да прекарате няколко нощувки. Времето и адаптацията към надморската височина ще определят точните дни, в които екипът ще се изкачва и почива. Носенето на лична екипировка може да се направи, докато шерпите поставят цялото основно оборудване до високите лагери. През това време ние също се аклиматизираме, като изкачваме друг връх в района, като Lobuche East или Island Peak.\r\n\r\nИма поне едно посещение на лагер 3 за нощувка. Това ще бъде добър шанс да тествате реакцията на тялото на много голяма надморска височина. За повечето хора Лагер 3 е най-високата точка, която ще достигнат без използването на бутилиран кислород, въпреки че някои хора избират да купят допълнителни бутилки, за да помогнат да стигнат до тази точка. След посещение на лагер 3 обикновено има почивка в базовия лагер или по-ниско, като подготовка за наддаване на върха. Често слизаме в Дебош, за да видим малко трева и да хапнем добра храна. ПЕРИОД НА ВЪРХА НА ЕВЕРЕСТ\r\nСлед като бъде взето решение да се направи опит за изкачване на върха в период някъде около средата на две седмици на май (статистически това е сравнително нормално, но хората са се изкачвали преди и след), тогава общият цикъл на върха от основата до върха и обратно е нормално седем дни, което позволява няколко нощувки в лагер 2 и след това една нощ в лагер 3. Изкачването до лагер 4 на южния стълб на Еверест става част от самото изкачване на върха, тъй като обикновено екипите пристигат в средата на следобед и почиват до около 21:00 когато се използват бутилки с пресен кислород, за да се изкачите до Балкона и да се присъедините към югоизточното било.\r\n\r\nСутринта на върха може да бъде съпътствана от проблеми с пренаселеността, особено на скалистото стъпало под южния връх. Обикновено груповият ред се определя по взаимно съгласие между ръководствата на компанията, но това не винаги е приложимо. Не е необичайно да откриете, че се движите много бавно зад голяма група или бавен индивид без възможност за изпреварване. Това води до студ и прекомерна употреба на ресурси като кислород. На балкона обикновено има смяна на бутилки, което дава възможност за промяна на груповия ред.\r\n\r\nОт Балкона до южния връх няма много възможности за изпреварване, въпреки че някои групи ще създадат свои собствени фиксирани линии от едната страна на основната. Може да бъде объркващо и разочароващо. Опитът и стабилната ръка тук ще бъдат много важни. До изгрев слънце бихме искали да сме на или под южния връх, с още два часа в ръка, за да стигнем върха.\r\n\r\nМаршрутът до Hillary Step е тесен и вълнуващ и неизбежно в ден с хубаво време ще има опашка в дъното на стъпалото и тук няма друг избор, освен да чакате. Стъпката може да е камениста или покрита със сняг и обикновено отнема само около двадесет минути, за да се премине. Оттам последните двеста метра до върха са лесна разходка. Целта е да пристигнете в средата на сутринта, като оставите целия останал ден, за да слезете обратно в лагер 4 и да си починете. Някои силни отбори желаят да стигнат до Лагер 3, но това не е приемливо, ако остави шерпите на високо ниво с огромно количество работа за вършене.\r\n\r\nВРЪЩАНЕ ОТ ЕВЕРЕСТ\r\nНяколко дни, прекарани обратно в базовия лагер, помагайки за разчистването на лагера, са последвани от преход обратно до Лукла и полет до Катманду. Някои хора избират да наемат хеликоптер, което е добре, но ние смятаме, че е важно да помогнем на шерпите да изчистят планината, а не просто да напуснат. Общата учтивост и уважение предполагат, че всеки ще се включи в разпадането на лагера, това е много по-приятно и трябва да се разглежда като част от пътуването и преживяването. Отнема много време, за да се обработи и усвои подобно преживяване, наистина няма нужда да бързате направо към Катманду.", 6, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "MountainGuides",
                columns: new[] { "Id", "Age", "Email", "Experience", "First name", "ImageUrl", "Last name", "OwnerId", "Phone", "Rating", "TourAgencyId" },
                values: new object[] { 1, null, "mountaineer@mail.com", 7, "Momchil", null, "Panayotov", "dea12856-c198-4129-b3f3-b893d8395082", "0895123456", null, 1 });

            migrationBuilder.InsertData(
                table: "RoutesHuts",
                columns: new[] { "HutId", "RouteId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "RoutesLakes",
                columns: new[] { "LakeId", "RouteId" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "RoutesPeaks",
                columns: new[] { "PeakId", "RouteId" },
                values: new object[,]
                {
                    { 91, 1 },
                    { 31, 2 },
                    { 121, 6 },
                    { 152, 7 },
                    { 131, 8 }
                });

            migrationBuilder.InsertData(
                table: "RoutesWaterfalls",
                columns: new[] { "RouteId", "WaterfallId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "ExpeditionsParticipants",
                columns: new[] { "ExpeditionId", "ParticipantId" },
                values: new object[] { 1, "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e" });

            migrationBuilder.InsertData(
                table: "MountaineersMountains",
                columns: new[] { "MountainGuideId", "MountainId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 6 },
                    { 1, 7 }
                });

            migrationBuilder.InsertData(
                table: "MountaineersRoutes",
                columns: new[] { "MountainGuideId", "RouteId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 6 },
                    { 1, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Expeditions_OrganiserId",
                table: "Expeditions",
                column: "OrganiserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expeditions_RouteId",
                table: "Expeditions",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Expeditions_TourAgencyId",
                table: "Expeditions",
                column: "TourAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionsParticipants_ParticipantId",
                table: "ExpeditionsParticipants",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Huts_MountainId",
                table: "Huts",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_Lakes_MountainId",
                table: "Lakes",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_MountaineersMountains_MountainId",
                table: "MountaineersMountains",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_MountaineersRoutes_MountainGuideId",
                table: "MountaineersRoutes",
                column: "MountainGuideId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainGuides_OwnerId",
                table: "MountainGuides",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainGuides_TourAgencyId",
                table: "MountainGuides",
                column: "TourAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Peaks_MountainId",
                table: "Peaks",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_MountainId",
                table: "Routes",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesHuts_HutId",
                table: "RoutesHuts",
                column: "HutId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesLakes_LakeId",
                table: "RoutesLakes",
                column: "LakeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesPeaks_PeakId",
                table: "RoutesPeaks",
                column: "PeakId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesWaterfalls_WaterfallId",
                table: "RoutesWaterfalls",
                column: "WaterfallId");

            migrationBuilder.CreateIndex(
                name: "IX_TourAgencies_OwnerId",
                table: "TourAgencies",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Waterfalls_MountainId",
                table: "Waterfalls",
                column: "MountainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ExpeditionsParticipants");

            migrationBuilder.DropTable(
                name: "MountaineersMountains");

            migrationBuilder.DropTable(
                name: "MountaineersRoutes");

            migrationBuilder.DropTable(
                name: "RoutesHuts");

            migrationBuilder.DropTable(
                name: "RoutesLakes");

            migrationBuilder.DropTable(
                name: "RoutesPeaks");

            migrationBuilder.DropTable(
                name: "RoutesWaterfalls");

            migrationBuilder.DropTable(
                name: "Expeditions");

            migrationBuilder.DropTable(
                name: "MountainGuides");

            migrationBuilder.DropTable(
                name: "Huts");

            migrationBuilder.DropTable(
                name: "Lakes");

            migrationBuilder.DropTable(
                name: "Peaks");

            migrationBuilder.DropTable(
                name: "Waterfalls");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "TourAgencies");

            migrationBuilder.DropTable(
                name: "Mountains");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");
        }
    }
}
