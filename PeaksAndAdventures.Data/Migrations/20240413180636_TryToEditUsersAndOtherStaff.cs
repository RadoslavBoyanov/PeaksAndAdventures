using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaksAndAdventures.Data.Migrations
{
    public partial class TryToEditUsersAndOtherStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpeditionsParticipants",
                keyColumns: new[] { "ExpeditionId", "ParticipantId" },
                keyValues: new object[] { 1, "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e" });

            migrationBuilder.DeleteData(
                table: "MountaineersMountains",
                keyColumns: new[] { "MountainGuideId", "MountainId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MountaineersMountains",
                keyColumns: new[] { "MountainGuideId", "MountainId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "MountaineersMountains",
                keyColumns: new[] { "MountainGuideId", "MountainId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "MountaineersRoutes",
                keyColumns: new[] { "MountainGuideId", "RouteId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MountaineersRoutes",
                keyColumns: new[] { "MountainGuideId", "RouteId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "MountaineersRoutes",
                keyColumns: new[] { "MountainGuideId", "RouteId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e");

            migrationBuilder.DeleteData(
                table: "Expeditions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MountainGuides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "TourAgencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "007b397f-9a3d-48d5-a8e4-ad00bbc43326", 0, "0fd2b493-424e-48a3-9f15-7c575f2dd666", "hikers@mail.com", false, false, null, "HIKERS@MAIL.COM", "HIKERS@MAIL.COM", "AQAAAAEAACcQAAAAENDauvP55eLVbRqglipiNUEJMM/0PkFOGIwv+4eH3Ajxw+3ltH1LpMqljpC3en13wg==", null, false, "41195217-c587-4f7d-8269-85fb646ed475", false, "hikers@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0d59049e-81f2-48f1-abb2-a5fd09bc210f", 0, "daaa57c8-7196-4418-8c52-3fa4cd2c37a9", "climber@mail.com", false, false, null, "CLIMBER@MAIL.COM", "CLIMBER@MAIL.COM", "AQAAAAEAACcQAAAAEMnpnAQJIqPvnrmTyWwYeOTwLFJ6p1o65+O1UN0eTXYMaTrcGXiM7bNflqp2/O0tuA==", null, false, "d7b2f208-9abb-440b-95e7-b0ebfb38eb3f", false, "climber@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e03c155-39f3-4713-897e-6dd625681add", 0, "dfd4bcd3-f400-4cfa-81ae-13f78becb009", "steph@mail.com", false, false, null, "STEPH@MAIL.COM", "STEPH@MAIL.COM", "AQAAAAEAACcQAAAAEAt+1hvDopiduPzb/1hKkxVQQwRmSIVxkCAgzLu0wzgkpT48pM0K7L4GRunmsEUH/Q==", null, false, "8ca45455-bf66-4e2f-ae83-9ed75e4e3bbb", false, "steph@mail.com" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Date publish" },
                values: new object[] { "0d59049e-81f2-48f1-abb2-a5fd09bc210f", new DateTime(2024, 4, 8, 21, 6, 34, 608, DateTimeKind.Local).AddTicks(7486) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Date publish" },
                values: new object[] { "0d59049e-81f2-48f1-abb2-a5fd09bc210f", new DateTime(2024, 3, 12, 21, 6, 34, 608, DateTimeKind.Local).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Date publish" },
                values: new object[] { "0d59049e-81f2-48f1-abb2-a5fd09bc210f", new DateTime(2024, 2, 13, 21, 6, 34, 608, DateTimeKind.Local).AddTicks(7543) });

            migrationBuilder.InsertData(
                table: "TourAgencies",
                columns: new[] { "Id", "Description", "Email", "Name", "OwnerId", "Phone" },
                values: new object[] { 4, "Hikers е изключително престижна туристическа агенция, посветена на страстта и приключението в света на планинарството. С богат опит в организацията на експедиции и планинарски турове, тази агенция съчетава страстта към природата със знание и професионализъм.\r\nНашата мисия е да предоставяме неповторими и вълнуващи преживявания за всички любители на приключенските спортове и обичатели на природата. Специализирани в организирането на експедиции в различни части на света, ние съчетаваме уникални маршрути, експертни водачи и безопасност на високо ниво, за да осигурим незабравими преживявания на върховете на света.\r\n\r\nНашите експедиции включват разнообразни дестинации - от високите върхове на Хималаите, през загадъчните планини в Южна Америка, до непокорените върхове в Африка и още много други. Съчетаваме екстремни предизвикателства с красивите природни пейзажи, за да създадем едно неповторимо приключение.\r\n\r\nНашите професионални гидове и инструктори са подготвени да водят клиентите ни през всеки етап от техния планинарски път. Разполагаме с модерно оборудване и осигуряваме пълна подкрепа за участниците в нашите турове, гарантирайки тяхната безопасност и комфорт.\r\nClimb and Hiking не предлага просто пътувания; предлагаме възможността за откриване на света от високо и по нов, невиждан начин. За нас, планинарството е не просто хоби, а начин на живот, който искаме да споделим с всички, които търсят истинско предизвикателство и незабравими преживявания в планината. Приключили сте да се катерите – започнете да живеете!", "hikers@mail.com", "Hikers", "007b397f-9a3d-48d5-a8e4-ad00bbc43326", "0899001166" });

            migrationBuilder.InsertData(
                table: "Expeditions",
                columns: new[] { "Id", "Days", "End date", "Enrolment", "Excludes", "Extras", "Includes", "Name", "OrganiserId", "Price", "Program", "RouteId", "Start date", "TourAgencyId" },
                values: new object[] { 5, 71, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Западен гид - може да се добави на частна основа.\r\nМеждународно пътуване до Катманду\r\nВсички полети с хеликоптер, използвани по лични причини\r\nЛична туристическа застраховка\r\nЛична екипировка и екипировка за катерене\r\nНепалска виза\r\nДопълнителни кислородни бутилки (700 USD всяка)\r\nРазходи, свързани с преждевременно приключване на експедиция или преждевременно напускане на експедиция.\r\nРазходи, свързани с удължаване на пътуване поради лошо време или други обстоятелства, включително разходите за допълнителни нощувки\r\nБонус за деня на срещата на върха към вашия водач шерпа от 2000,00 USD", "ХОТЕЛ ЯК И ЙЕТИ\r\n3 нощувки в двойна/двойна стандартна стая в този луксозен 5-звезден хотел, предлагащ съчетание от съвременна изтънченост и културно наследство със своя 100-годишен дворец и новопроектираната структура на хотела за 495$", "Такса за разрешение за Еверест (в момента $11,500.00 на човек)\r\nТакса за ледопад Кхумбу\r\nSPCC такса за боклук и разходи за управление на боклука в базовия лагер\r\nКолективна такса за фиксирана линия над базовия лагер\r\nФонд за базовия лагер на Himalayan Rescue Assn за спешни медицински случаи и покритие за шерпи.\r\nНадбавка за офицер за връзка\r\nКатерене на шерпи\r\nПерсонал на базовия лагер - готвач, помощник-готвач, носачи\r\nЗастрахователно покритие на персонала за спешна евакуация с хеликоптер и медицинска застраховка\r\nВсички хранения\r\nПалатки за спане в базовия лагер (1 на член) и общи палатки в по-високите лагери\r\nПалатка за тоалетна и душ\r\nСъоръжения за първа помощ и използване на HRA станцията в базовия лагер\r\nКислородни бутилки (3 литра х 6 на човек), плюс една маска и регулатор на човек\r\nФиксирано въже и снежни барове (обикновено се предоставят от общността, но ние също ще имаме наши собствени)\r\nСтолова палатка BC и C2\r\nПреходът струва до базовия лагер и транспорт на оборудването с якове и носачи\r\nНастаняване в Катманду - двойна стая за 3 нощувки\r\nЛукла полет", "Изпитай себе си и изкачи Еверест!", "007b397f-9a3d-48d5-a8e4-ad00bbc43326", 55000.00m, "Връх Еверест е общо 10-седмична експедиция, с 2 седмици време за преход и 8 седмици период на изкачване. Не очаквайте обаче да се приберете у дома след изкачването на Еверест и да се върнете към нормалния живот, може да отнеме седмици и дори месеци, за да се възстановите напълно, както физически, така и психически.\r\n\r\nРаботим по съгласуван принцип за достигане на определени височини и спане в определени лагери по структуриран начин за период от осем седмици след достигане на базовия лагер, което позволява както зареждане на лагерите, така и оптимално време за аклиматизация. Програмата за катерачите се определя до голяма степен от графика на лагерите за зареждане, който от своя страна се определя от времето и позволява достатъчно почивки. Всеки опитен катерач ще разбере тази политика и ще се чувства удобно с гъвкавостта.\r\n\r\nПОХОД И АКЛИМАТИЗАЦИОНЕН ПЕРИОД ПРИ ИЗКАЧВАНЕ НА ЕВЕРЕСТ\r\nПървите 10 дни преминават в преход до базовия лагер. След това следва период на почивка и установяване. Ръководителите на екипи ще се срещнат и ще обсъдят съвместни операции по въпроси като поставяне на стационарни линии. Екипите също трябва да изчакат ледопадът да бъде „поправен“ от екипите на шерпите, чиято работа е да поставят стълбите и фиксираните въжета. Това отново може да отнеме дни.\r\n\r\nСледващият месец ще бъде прекаран в извършване на редица проучвателни изкачвания до лагер 1 през ледопада Khumbu и след това до лагер 2, където е важно да прекарате няколко нощувки. Времето и адаптацията към надморската височина ще определят точните дни, в които екипът ще се изкачва и почива. Носенето на лична екипировка може да се направи, докато шерпите поставят цялото основно оборудване до високите лагери. През това време ние също се аклиматизираме, като изкачваме друг връх в района, като Lobuche East или Island Peak.\r\n\r\nИма поне едно посещение на лагер 3 за нощувка. Това ще бъде добър шанс да тествате реакцията на тялото на много голяма надморска височина. За повечето хора Лагер 3 е най-високата точка, която ще достигнат без използването на бутилиран кислород, въпреки че някои хора избират да купят допълнителни бутилки, за да помогнат да стигнат до тази точка. След посещение на лагер 3 обикновено има почивка в базовия лагер или по-ниско, като подготовка за наддаване на върха. Често слизаме в Дебош, за да видим малко трева и да хапнем добра храна. ПЕРИОД НА ВЪРХА НА ЕВЕРЕСТ\r\nСлед като бъде взето решение да се направи опит за изкачване на върха в период някъде около средата на две седмици на май (статистически това е сравнително нормално, но хората са се изкачвали преди и след), тогава общият цикъл на върха от основата до върха и обратно е нормално седем дни, което позволява няколко нощувки в лагер 2 и след това една нощ в лагер 3. Изкачването до лагер 4 на южния стълб на Еверест става част от самото изкачване на върха, тъй като обикновено екипите пристигат в средата на следобед и почиват до около 21:00 когато се използват бутилки с пресен кислород, за да се изкачите до Балкона и да се присъедините към югоизточното било.\r\n\r\nСутринта на върха може да бъде съпътствана от проблеми с пренаселеността, особено на скалистото стъпало под южния връх. Обикновено груповият ред се определя по взаимно съгласие между ръководствата на компанията, но това не винаги е приложимо. Не е необичайно да откриете, че се движите много бавно зад голяма група или бавен индивид без възможност за изпреварване. Това води до студ и прекомерна употреба на ресурси като кислород. На балкона обикновено има смяна на бутилки, което дава възможност за промяна на груповия ред.\r\n\r\nОт Балкона до южния връх няма много възможности за изпреварване, въпреки че някои групи ще създадат свои собствени фиксирани линии от едната страна на основната. Може да бъде объркващо и разочароващо. Опитът и стабилната ръка тук ще бъдат много важни. До изгрев слънце бихме искали да сме на или под южния връх, с още два часа в ръка, за да стигнем върха.\r\n\r\nМаршрутът до Hillary Step е тесен и вълнуващ и неизбежно в ден с хубаво време ще има опашка в дъното на стъпалото и тук няма друг избор, освен да чакате. Стъпката може да е камениста или покрита със сняг и обикновено отнема само около двадесет минути, за да се премине. Оттам последните двеста метра до върха са лесна разходка. Целта е да пристигнете в средата на сутринта, като оставите целия останал ден, за да слезете обратно в лагер 4 и да си починете. Някои силни отбори желаят да стигнат до Лагер 3, но това не е приемливо, ако остави шерпите на високо ниво с огромно количество работа за вършене.\r\n\r\nВРЪЩАНЕ ОТ ЕВЕРЕСТ\r\nНяколко дни, прекарани обратно в базовия лагер, помагайки за разчистването на лагера, са последвани от преход обратно до Лукла и полет до Катманду. Някои хора избират да наемат хеликоптер, което е добре, но ние смятаме, че е важно да помогнем на шерпите да изчистят планината, а не просто да напуснат. Общата учтивост и уважение предполагат, че всеки ще се включи в разпадането на лагера, това е много по-приятно и трябва да се разглежда като част от пътуването и преживяването. Отнема много време, за да се обработи и усвои подобно преживяване, наистина няма нужда да бързате направо към Катманду.", 6, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 });

            migrationBuilder.InsertData(
                table: "MountainGuides",
                columns: new[] { "Id", "Age", "Email", "Experience", "First name", "ImageUrl", "Last name", "OwnerId", "Phone", "TourAgencyId" },
                values: new object[] { 8, null, "climber@mail.com", 7, "Илия", null, "Петканов", "0d59049e-81f2-48f1-abb2-a5fd09bc210f", "0895123456", 4 });

            migrationBuilder.InsertData(
                table: "ExpeditionsParticipants",
                columns: new[] { "ExpeditionId", "ParticipantId" },
                values: new object[] { 5, "1e03c155-39f3-4713-897e-6dd625681add" });

            migrationBuilder.InsertData(
                table: "MountaineersMountains",
                columns: new[] { "MountainGuideId", "MountainId" },
                values: new object[,]
                {
                    { 8, 2 },
                    { 8, 6 },
                    { 8, 7 }
                });

            migrationBuilder.InsertData(
                table: "MountaineersRoutes",
                columns: new[] { "MountainGuideId", "RouteId" },
                values: new object[,]
                {
                    { 8, 2 },
                    { 8, 6 },
                    { 8, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpeditionsParticipants",
                keyColumns: new[] { "ExpeditionId", "ParticipantId" },
                keyValues: new object[] { 5, "1e03c155-39f3-4713-897e-6dd625681add" });

            migrationBuilder.DeleteData(
                table: "MountaineersMountains",
                keyColumns: new[] { "MountainGuideId", "MountainId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "MountaineersMountains",
                keyColumns: new[] { "MountainGuideId", "MountainId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "MountaineersMountains",
                keyColumns: new[] { "MountainGuideId", "MountainId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "MountaineersRoutes",
                keyColumns: new[] { "MountainGuideId", "RouteId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "MountaineersRoutes",
                keyColumns: new[] { "MountainGuideId", "RouteId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "MountaineersRoutes",
                keyColumns: new[] { "MountainGuideId", "RouteId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e03c155-39f3-4713-897e-6dd625681add");

            migrationBuilder.DeleteData(
                table: "Expeditions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MountainGuides",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d59049e-81f2-48f1-abb2-a5fd09bc210f");

            migrationBuilder.DeleteData(
                table: "TourAgencies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007b397f-9a3d-48d5-a8e4-ad00bbc43326");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e", 0, "9bac5108-fbe9-49fb-b5a6-3c0c8027ef05", "tourist@mail.com", false, false, null, "tourist@mail.com", "tourist@mail.com", "AQAAAAEAACcQAAAAEHqlH5jfWX0gQvZx4UjR2WozuUSFpYGdbUCbJsWBhAcyMCMeGsFF2Y9MWeA6C88vNA==", null, false, "6bb8bc7e-d935-479a-a04d-c4cc60dc202f", false, "tourist@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "14c298ff-9eb1-499f-9192-25b61fa08b03", "climbаndhike@mail.com", false, false, null, "climbаndhike@mail.com", "climbаndhike@mail.com", "AQAAAAEAACcQAAAAECilGk6M4YBMY8Ha4DGr5tSKIuOltptjL+27GYo/6e0B6AW/6lSTGIDZ9m7Rp0mB7w==", null, false, "7cd53542-3230-4d20-a182-2095196db97a", false, "climbаndhike@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", 0, "b17304d9-f611-4a07-bb27-bffafa316a7f", "mountaineer@mail.com", false, false, null, "mountaineer@mail.com", "mountaineer@mail.com", "AQAAAAEAACcQAAAAEMxnAqiAGmKu6Exx0I7lhqX5GtVqpPbpcW1ADZnPbUBbiNco501trCaq/LcjARDFCQ==", null, false, "d6646222-6820-49df-804a-85f49c34240a", false, "mountaineer@mail.com" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Date publish" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", new DateTime(2024, 3, 31, 17, 20, 9, 131, DateTimeKind.Local).AddTicks(1906) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Date publish" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", new DateTime(2024, 3, 4, 17, 20, 9, 131, DateTimeKind.Local).AddTicks(2002) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Date publish" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", new DateTime(2024, 2, 5, 17, 20, 9, 131, DateTimeKind.Local).AddTicks(2007) });

            migrationBuilder.InsertData(
                table: "TourAgencies",
                columns: new[] { "Id", "Description", "Email", "Name", "OwnerId", "Phone" },
                values: new object[] { 1, "Climb and Hiking е изключително престижна туристическа агенция, посветена на страстта и приключението в света на планинарството. С богат опит в организацията на експедиции и планинарски турове, тази агенция съчетава страстта към природата със знание и професионализъм.\r\nНашата мисия е да предоставяме неповторими и вълнуващи преживявания за всички любители на приключенските спортове и обичатели на природата. Специализирани в организирането на експедиции в различни части на света, ние съчетаваме уникални маршрути, експертни водачи и безопасност на високо ниво, за да осигурим незабравими преживявания на върховете на света.\r\n\r\nНашите експедиции включват разнообразни дестинации - от високите върхове на Хималаите, през загадъчните планини в Южна Америка, до непокорените върхове в Африка и още много други. Съчетаваме екстремни предизвикателства с красивите природни пейзажи, за да създадем едно неповторимо приключение.\r\n\r\nНашите професионални гидове и инструктори са подготвени да водят клиентите ни през всеки етап от техния планинарски път. Разполагаме с модерно оборудване и осигуряваме пълна подкрепа за участниците в нашите турове, гарантирайки тяхната безопасност и комфорт.\r\nClimb and Hiking не предлага просто пътувания; предлагаме възможността за откриване на света от високо и по нов, невиждан начин. За нас, планинарството е не просто хоби, а начин на живот, който искаме да споделим с всички, които търсят истинско предизвикателство и незабравими преживявания в планината. Приключили сте да се катерите – започнете да живеете!", "climbAndHike@mail.com", "Climb and Hiking", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "0899001166" });

            migrationBuilder.InsertData(
                table: "Expeditions",
                columns: new[] { "Id", "Days", "End date", "Enrolment", "Excludes", "Extras", "Includes", "Name", "OrganiserId", "Price", "Program", "RouteId", "Start date", "TourAgencyId" },
                values: new object[] { 1, 71, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Западен гид - може да се добави на частна основа.\r\nМеждународно пътуване до Катманду\r\nВсички полети с хеликоптер, използвани по лични причини\r\nЛична туристическа застраховка\r\nЛична екипировка и екипировка за катерене\r\nНепалска виза\r\nДопълнителни кислородни бутилки (700 USD всяка)\r\nРазходи, свързани с преждевременно приключване на експедиция или преждевременно напускане на експедиция.\r\nРазходи, свързани с удължаване на пътуване поради лошо време или други обстоятелства, включително разходите за допълнителни нощувки\r\nБонус за деня на срещата на върха към вашия водач шерпа от 2000,00 USD", "ХОТЕЛ ЯК И ЙЕТИ\r\n3 нощувки в двойна/двойна стандартна стая в този луксозен 5-звезден хотел, предлагащ съчетание от съвременна изтънченост и културно наследство със своя 100-годишен дворец и новопроектираната структура на хотела за 495$", "Такса за разрешение за Еверест (в момента $11,500.00 на човек)\r\nТакса за ледопад Кхумбу\r\nSPCC такса за боклук и разходи за управление на боклука в базовия лагер\r\nКолективна такса за фиксирана линия над базовия лагер\r\nФонд за базовия лагер на Himalayan Rescue Assn за спешни медицински случаи и покритие за шерпи.\r\nНадбавка за офицер за връзка\r\nКатерене на шерпи\r\nПерсонал на базовия лагер - готвач, помощник-готвач, носачи\r\nЗастрахователно покритие на персонала за спешна евакуация с хеликоптер и медицинска застраховка\r\nВсички хранения\r\nПалатки за спане в базовия лагер (1 на член) и общи палатки в по-високите лагери\r\nПалатка за тоалетна и душ\r\nСъоръжения за първа помощ и използване на HRA станцията в базовия лагер\r\nКислородни бутилки (3 литра х 6 на човек), плюс една маска и регулатор на човек\r\nФиксирано въже и снежни барове (обикновено се предоставят от общността, но ние също ще имаме наши собствени)\r\nСтолова палатка BC и C2\r\nПреходът струва до базовия лагер и транспорт на оборудването с якове и носачи\r\nНастаняване в Катманду - двойна стая за 3 нощувки\r\nЛукла полет", "Изпитай себе си и изкачи Еверест!", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 55000.00m, "Връх Еверест е общо 10-седмична експедиция, с 2 седмици време за преход и 8 седмици период на изкачване. Не очаквайте обаче да се приберете у дома след изкачването на Еверест и да се върнете към нормалния живот, може да отнеме седмици и дори месеци, за да се възстановите напълно, както физически, така и психически.\r\n\r\nРаботим по съгласуван принцип за достигане на определени височини и спане в определени лагери по структуриран начин за период от осем седмици след достигане на базовия лагер, което позволява както зареждане на лагерите, така и оптимално време за аклиматизация. Програмата за катерачите се определя до голяма степен от графика на лагерите за зареждане, който от своя страна се определя от времето и позволява достатъчно почивки. Всеки опитен катерач ще разбере тази политика и ще се чувства удобно с гъвкавостта.\r\n\r\nПОХОД И АКЛИМАТИЗАЦИОНЕН ПЕРИОД ПРИ ИЗКАЧВАНЕ НА ЕВЕРЕСТ\r\nПървите 10 дни преминават в преход до базовия лагер. След това следва период на почивка и установяване. Ръководителите на екипи ще се срещнат и ще обсъдят съвместни операции по въпроси като поставяне на стационарни линии. Екипите също трябва да изчакат ледопадът да бъде „поправен“ от екипите на шерпите, чиято работа е да поставят стълбите и фиксираните въжета. Това отново може да отнеме дни.\r\n\r\nСледващият месец ще бъде прекаран в извършване на редица проучвателни изкачвания до лагер 1 през ледопада Khumbu и след това до лагер 2, където е важно да прекарате няколко нощувки. Времето и адаптацията към надморската височина ще определят точните дни, в които екипът ще се изкачва и почива. Носенето на лична екипировка може да се направи, докато шерпите поставят цялото основно оборудване до високите лагери. През това време ние също се аклиматизираме, като изкачваме друг връх в района, като Lobuche East или Island Peak.\r\n\r\nИма поне едно посещение на лагер 3 за нощувка. Това ще бъде добър шанс да тествате реакцията на тялото на много голяма надморска височина. За повечето хора Лагер 3 е най-високата точка, която ще достигнат без използването на бутилиран кислород, въпреки че някои хора избират да купят допълнителни бутилки, за да помогнат да стигнат до тази точка. След посещение на лагер 3 обикновено има почивка в базовия лагер или по-ниско, като подготовка за наддаване на върха. Често слизаме в Дебош, за да видим малко трева и да хапнем добра храна. ПЕРИОД НА ВЪРХА НА ЕВЕРЕСТ\r\nСлед като бъде взето решение да се направи опит за изкачване на върха в период някъде около средата на две седмици на май (статистически това е сравнително нормално, но хората са се изкачвали преди и след), тогава общият цикъл на върха от основата до върха и обратно е нормално седем дни, което позволява няколко нощувки в лагер 2 и след това една нощ в лагер 3. Изкачването до лагер 4 на южния стълб на Еверест става част от самото изкачване на върха, тъй като обикновено екипите пристигат в средата на следобед и почиват до около 21:00 когато се използват бутилки с пресен кислород, за да се изкачите до Балкона и да се присъедините към югоизточното било.\r\n\r\nСутринта на върха може да бъде съпътствана от проблеми с пренаселеността, особено на скалистото стъпало под южния връх. Обикновено груповият ред се определя по взаимно съгласие между ръководствата на компанията, но това не винаги е приложимо. Не е необичайно да откриете, че се движите много бавно зад голяма група или бавен индивид без възможност за изпреварване. Това води до студ и прекомерна употреба на ресурси като кислород. На балкона обикновено има смяна на бутилки, което дава възможност за промяна на груповия ред.\r\n\r\nОт Балкона до южния връх няма много възможности за изпреварване, въпреки че някои групи ще създадат свои собствени фиксирани линии от едната страна на основната. Може да бъде объркващо и разочароващо. Опитът и стабилната ръка тук ще бъдат много важни. До изгрев слънце бихме искали да сме на или под южния връх, с още два часа в ръка, за да стигнем върха.\r\n\r\nМаршрутът до Hillary Step е тесен и вълнуващ и неизбежно в ден с хубаво време ще има опашка в дъното на стъпалото и тук няма друг избор, освен да чакате. Стъпката може да е камениста или покрита със сняг и обикновено отнема само около двадесет минути, за да се премине. Оттам последните двеста метра до върха са лесна разходка. Целта е да пристигнете в средата на сутринта, като оставите целия останал ден, за да слезете обратно в лагер 4 и да си починете. Някои силни отбори желаят да стигнат до Лагер 3, но това не е приемливо, ако остави шерпите на високо ниво с огромно количество работа за вършене.\r\n\r\nВРЪЩАНЕ ОТ ЕВЕРЕСТ\r\nНяколко дни, прекарани обратно в базовия лагер, помагайки за разчистването на лагера, са последвани от преход обратно до Лукла и полет до Катманду. Някои хора избират да наемат хеликоптер, което е добре, но ние смятаме, че е важно да помогнем на шерпите да изчистят планината, а не просто да напуснат. Общата учтивост и уважение предполагат, че всеки ще се включи в разпадането на лагера, това е много по-приятно и трябва да се разглежда като част от пътуването и преживяването. Отнема много време, за да се обработи и усвои подобно преживяване, наистина няма нужда да бързате направо към Катманду.", 6, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "MountainGuides",
                columns: new[] { "Id", "Age", "Email", "Experience", "First name", "ImageUrl", "Last name", "OwnerId", "Phone", "TourAgencyId" },
                values: new object[] { 1, null, "mountaineer@mail.com", 7, "Momchil", null, "Panayotov", "dea12856-c198-4129-b3f3-b893d8395082", "0895123456", 1 });

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
        }
    }
}
