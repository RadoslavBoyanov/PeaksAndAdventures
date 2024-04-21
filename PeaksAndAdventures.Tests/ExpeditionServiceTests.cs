using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Expedition;
using PeaksAndAdventures.Core.Services;
using PeaksAndAdventures.Infrastructure.Data;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Enums.Route;
using PeaksAndAdventures.Infrastructure.Data.Models;
using static PeaksAndAdventures.Common.EntityValidations.ExpeditionValidation;

namespace PeaksAndAdventures.Tests
{
	[TestFixture]
	public class ExpeditionServiceTests
	{
		private PeaksAndAdventuresDbContext _context;

		private IRepository _repository;
		private IExpeditionService _service;

		private IEnumerable<Expedition> _expeditions;
		private IEnumerable<TourAgency> _tourAgencies;
		private IEnumerable<IdentityUser> _users;
		private IEnumerable<Route> _routes;
		private IEnumerable<ExpeditionParticipant> _participants;

		[SetUp]
		public void SetUp()
		{
			_context = new PeaksAndAdventuresDbContext(new DbContextOptionsBuilder<PeaksAndAdventuresDbContext>()
							.UseInMemoryDatabase(databaseName: "PeaksAndAdventuresTest" + Guid.NewGuid().ToString())
							.Options);

			_repository = new Repository(_context);
			_service = new ExpeditionService(_repository);

			_expeditions = new List<Expedition>
			{
				new Expedition()
				{
						Id = 1,
				Name = "Изпитай себе си и изкачи Еверест!",
				Days = 71,
				StartDate = new DateTime(2024, 04, 01),
				EndDate = new DateTime(2024, 06, 10),
				Includes = "Такса за разрешение за Еверест (в момента $11,500.00 на човек)\r\nТакса за ледопад Кхумбу\r\nSPCC такса за боклук и разходи за управление на боклука в базовия лагер\r\nКолективна такса за фиксирана линия над базовия лагер\r\nФонд за базовия лагер на Himalayan Rescue Assn за спешни медицински случаи и покритие за шерпи.\r\nНадбавка за офицер за връзка\r\nКатерене на шерпи\r\nПерсонал на базовия лагер - готвач, помощник-готвач, носачи\r\nЗастрахователно покритие на персонала за спешна евакуация с хеликоптер и медицинска застраховка\r\nВсички хранения\r\nПалатки за спане в базовия лагер (1 на член) и общи палатки в по-високите лагери\r\nПалатка за тоалетна и душ\r\nСъоръжения за първа помощ и използване на HRA станцията в базовия лагер\r\nКислородни бутилки (3 литра х 6 на човек), плюс една маска и регулатор на човек\r\nФиксирано въже и снежни барове (обикновено се предоставят от общността, но ние също ще имаме наши собствени)\r\nСтолова палатка BC и C2\r\nПреходът струва до базовия лагер и транспорт на оборудването с якове и носачи\r\nНастаняване в Катманду - двойна стая за 3 нощувки\r\nЛукла полет",
				Excludes = "Западен гид - може да се добави на частна основа.\r\nМеждународно пътуване до Катманду\r\nВсички полети с хеликоптер, използвани по лични причини\r\nЛична туристическа застраховка\r\nЛична екипировка и екипировка за катерене\r\nНепалска виза\r\nДопълнителни кислородни бутилки (700 USD всяка)\r\nРазходи, свързани с преждевременно приключване на експедиция или преждевременно напускане на експедиция.\r\nРазходи, свързани с удължаване на пътуване поради лошо време или други обстоятелства, включително разходите за допълнителни нощувки\r\nБонус за деня на срещата на върха към вашия водач шерпа от 2000,00 USD",
				Extras = "ХОТЕЛ ЯК И ЙЕТИ\r\n3 нощувки в двойна/двойна стандартна стая в този луксозен 5-звезден хотел, предлагащ съчетание от съвременна изтънченост и културно наследство със своя 100-годишен дворец и новопроектираната структура на хотела за 495$",
				RouteId = 1,
				Enrolment = 20,
				TourAgencyId = 1,
				Price = 55_000.00m,
				Program = "Връх Еверест е общо 10-седмична експедиция, с 2 седмици време за преход и 8 седмици период на изкачване. Не очаквайте обаче да се приберете у дома след изкачването на Еверест и да се върнете към нормалния живот, може да отнеме седмици и дори месеци, за да се възстановите напълно, както физически, така и психически.\r\n\r\nРаботим по съгласуван принцип за достигане на определени височини и спане в определени лагери по структуриран начин за период от осем седмици след достигане на базовия лагер, което позволява както зареждане на лагерите, така и оптимално време за аклиматизация. Програмата за катерачите се определя до голяма степен от графика на лагерите за зареждане, който от своя страна се определя от времето и позволява достатъчно почивки. Всеки опитен катерач ще разбере тази политика и ще се чувства удобно с гъвкавостта.\r\n\r\nПОХОД И АКЛИМАТИЗАЦИОНЕН ПЕРИОД ПРИ ИЗКАЧВАНЕ НА ЕВЕРЕСТ\r\nПървите 10 дни преминават в преход до базовия лагер. След това следва период на почивка и установяване. Ръководителите на екипи ще се срещнат и ще обсъдят съвместни операции по въпроси като поставяне на стационарни линии. Екипите също трябва да изчакат ледопадът да бъде „поправен“ от екипите на шерпите, чиято работа е да поставят стълбите и фиксираните въжета. Това отново може да отнеме дни.\r\n\r\nСледващият месец ще бъде прекаран в извършване на редица проучвателни изкачвания до лагер 1 през ледопада Khumbu и след това до лагер 2, където е важно да прекарате няколко нощувки. Времето и адаптацията към надморската височина ще определят точните дни, в които екипът ще се изкачва и почива. Носенето на лична екипировка може да се направи, докато шерпите поставят цялото основно оборудване до високите лагери. През това време ние също се аклиматизираме, като изкачваме друг връх в района, като Lobuche East или Island Peak.\r\n\r\nИма поне едно посещение на лагер 3 за нощувка. Това ще бъде добър шанс да тествате реакцията на тялото на много голяма надморска височина. За повечето хора Лагер 3 е най-високата точка, която ще достигнат без използването на бутилиран кислород, въпреки че някои хора избират да купят допълнителни бутилки, за да помогнат да стигнат до тази точка. След посещение на лагер 3 обикновено има почивка в базовия лагер или по-ниско, като подготовка за наддаване на върха. Често слизаме в Дебош, за да видим малко трева и да хапнем добра храна. ПЕРИОД НА ВЪРХА НА ЕВЕРЕСТ\r\nСлед като бъде взето решение да се направи опит за изкачване на върха в период някъде около средата на две седмици на май (статистически това е сравнително нормално, но хората са се изкачвали преди и след), тогава общият цикъл на върха от основата до върха и обратно е нормално седем дни, което позволява няколко нощувки в лагер 2 и след това една нощ в лагер 3. Изкачването до лагер 4 на южния стълб на Еверест става част от самото изкачване на върха, тъй като обикновено екипите пристигат в средата на следобед и почиват до около 21:00 когато се използват бутилки с пресен кислород, за да се изкачите до Балкона и да се присъедините към югоизточното било.\r\n\r\nСутринта на върха може да бъде съпътствана от проблеми с пренаселеността, особено на скалистото стъпало под южния връх. Обикновено груповият ред се определя по взаимно съгласие между ръководствата на компанията, но това не винаги е приложимо. Не е необичайно да откриете, че се движите много бавно зад голяма група или бавен индивид без възможност за изпреварване. Това води до студ и прекомерна употреба на ресурси като кислород. На балкона обикновено има смяна на бутилки, което дава възможност за промяна на груповия ред.\r\n\r\nОт Балкона до южния връх няма много възможности за изпреварване, въпреки че някои групи ще създадат свои собствени фиксирани линии от едната страна на основната. Може да бъде объркващо и разочароващо. Опитът и стабилната ръка тук ще бъдат много важни. До изгрев слънце бихме искали да сме на или под южния връх, с още два часа в ръка, за да стигнем върха.\r\n\r\nМаршрутът до Hillary Step е тесен и вълнуващ и неизбежно в ден с хубаво време ще има опашка в дъното на стъпалото и тук няма друг избор, освен да чакате. Стъпката може да е камениста или покрита със сняг и обикновено отнема само около двадесет минути, за да се премине. Оттам последните двеста метра до върха са лесна разходка. Целта е да пристигнете в средата на сутринта, като оставите целия останал ден, за да слезете обратно в лагер 4 и да си починете. Някои силни отбори желаят да стигнат до Лагер 3, но това не е приемливо, ако остави шерпите на високо ниво с огромно количество работа за вършене.\r\n\r\nВРЪЩАНЕ ОТ ЕВЕРЕСТ\r\nНяколко дни, прекарани обратно в базовия лагер, помагайки за разчистването на лагера, са последвани от преход обратно до Лукла и полет до Катманду. Някои хора избират да наемат хеликоптер, което е добре, но ние смятаме, че е важно да помогнем на шерпите да изчистят планината, а не просто да напуснат. Общата учтивост и уважение предполагат, че всеки ще се включи в разпадането на лагера, това е много по-приятно и трябва да се разглежда като част от пътуването и преживяването. Отнема много време, за да се обработи и усвои подобно преживяване, наистина няма нужда да бързате направо към Катманду.",
				OrganiserId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326",
				}
			};

			_tourAgencies = new List<TourAgency>
			{
				new TourAgency {
					Id = 1,
					Name = "Hikers",
					Description = "Hikers е изключително престижна туристическа агенция, посветена на страстта и приключението в света на планинарството. С богат опит в организацията на експедиции и планинарски турове, тази агенция съчетава страстта към природата със знание и професионализъм.\r\nНашата мисия е да предоставяме неповторими и вълнуващи преживявания за всички любители на приключенските спортове и обичатели на природата. Специализирани в организирането на експедиции в различни части на света, ние съчетаваме уникални маршрути, експертни водачи и безопасност на високо ниво, за да осигурим незабравими преживявания на върховете на света.\r\n\r\nНашите експедиции включват разнообразни дестинации - от високите върхове на Хималаите, през загадъчните планини в Южна Америка, до непокорените върхове в Африка и още много други. Съчетаваме екстремни предизвикателства с красивите природни пейзажи, за да създадем едно неповторимо приключение.\r\n\r\nНашите професионални гидове и инструктори са подготвени да водят клиентите ни през всеки етап от техния планинарски път. Разполагаме с модерно оборудване и осигуряваме пълна подкрепа за участниците в нашите турове, гарантирайки тяхната безопасност и комфорт.\r\nClimb and Hiking не предлага просто пътувания; предлагаме възможността за откриване на света от високо и по нов, невиждан начин. За нас, планинарството е не просто хоби, а начин на живот, който искаме да споделим с всички, които търсят истинско предизвикателство и незабравими преживявания в планината. Приключили сте да се катерите – започнете да живеете!",
					Email = "hikers@mail.com",
					Phone = "0899001166",
					OwnerId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326" },
			};

			_users = new List<IdentityUser>
			{
				new IdentityUser
				{
					Id = "0d59049e-81f2-48f1-abb2-a5fd09bc210f",
					UserName = "climber@mail.com",
					NormalizedUserName = "CLIMBER@MAIL.COM",
					Email = "climber@mail.com",
					NormalizedEmail = "CLIMBER@MAIL.COM"
				},
				new IdentityUser
				{
					Id = "007b397f-9a3d-48d5-a8e4-ad00bbc43326",
					UserName = "hikers@mail.com",
					NormalizedUserName = "HIKERS@MAIL.COM",
					Email = "hikers@mail.com",
					NormalizedEmail = "HIKERS@MAIL.COM"
				},
				new IdentityUser()
				{
					Id = "1e03c155-39f3-4713-897e-6dd625681add",
					UserName = "steph@mail.com",
					NormalizedUserName = "STEPH@MAIL.COM",
					Email = "steph@mail.com",
					NormalizedEmail = "STEPH@MAIL.COM"
				}
			};

			_routes = new List<Route>()
			{
				new Route()
				{
					Id = 1,
					Name = "Североизточен ръб - Еверест",
					StartingPoint = "Базов лагер Еверест",
					Description =
						"Североизточният ръб (наричан просто северен) започва от северната страна на планината, в Тибет. Експедицията прави преход пеша по каменист път до ледника Ронгбук, където на 5180 m се намира базовият лагер. За да достигнат Лагер 2, катерачите преминават през средно големи морени по източната страна на Ронгбук до базата Чангце на 6100 m. Лагер 3 (Преден базов лагер) се намира под Северното седло на 6500 m. За да достигнат до Лагер 4, катерачите се изкачват по ледника, след което по фиксирани въжета достигат до върха на Седлото (7010 m). Оттам следва изкачване по каменистия северен ръб, до Лагер 5 на 7775 m. Следва диагонално подсичане на северното било до Жълтия пояс, където се намира Лагер 6 на 8230 m. Оттам катерачите атакуват върха.Катерачите се сблъскват с коварното препятствие, което представлява Първото стъпало на 8534 m. Следва Второто стъпало (~8600 m). За неговото преодоляване се използва съоръжение, наречено „Китайската стълба“ – постоянна метална стълба, поставена през 1975 г. от китайска експедиция. Оттогава тя неизменно служи на катерачите, и на практика всеки атакуващ върха е минал през нея. Третото стъпало (8689 – 8800 m) се преодолява почти пълзешком. След стъпалата до върха остават снежен наклон под почти 50 градуса и финалният хребет..",
					Difficulty = Difficulty.Difficult,
					DisplacementPositive = 3669,
					DisplacementNegative = 3669,
					Duration = "60.00:00",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Mount_Everest_North_Face.jpg/220px-Mount_Everest_North_Face.jpg",
					MountainId = 6
				}
			};

			_participants = new List<ExpeditionParticipant>
			{
				new ExpeditionParticipant
				{
					ExpeditionId = 1,
					ParticipantId = "1e03c155-39f3-4713-897e-6dd625681add"
				}
			};

			_context.TourAgencies.AddRange(_tourAgencies);
			_context.Expeditions.AddRange(_expeditions);
			_context.Users.AddRange(_users);
			_context.Routes.AddRange(_routes);
			_context.ExpeditionsParticipants.AddRange(_participants);

			_context.SaveChanges();
		}

		[TearDown]
		public async Task TearDown()
		{
			await _context.Database.EnsureDeletedAsync();
			await _context.DisposeAsync();
		}

		[Test]
		public async Task RegisterForExpeditionAsync_WithValidData_ShouldReturnSuccess()
		{

			var userId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326";
			var expeditionId = 1;


			var result = await _service.RegisterForExpeditionAsync(userId, expeditionId);


			Assert.IsTrue(result.Success);
		}

		[Test]
		public async Task RegisterForExpeditionAsync_UserWhereIsRegisteredAlready_ShouldReturnFail()
		{

			var userId = "1e03c155-39f3-4713-897e-6dd625681add";
			var expeditionId = 1;


			var result = await _service.RegisterForExpeditionAsync(userId, expeditionId);


			Assert.IsFalse(result.Success);
		}

		[Test]
		public async Task UnregisterFromExpeditionAsync_ShouldUnregisterParticipant()
		{

			var userId = "1e03c155-39f3-4713-897e-6dd625681add";
			var expeditionId = 1;


			var result = await _service.UnregisterFromExpeditionAsync(userId, expeditionId);


			Assert.IsTrue(result.Success);
		}

		[Test]
		public async Task UnregisterFromExpeditionAsync_UserIsNotRegistered_ShouldReturnFail()
		{

			var userId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326";
			var expeditionId = 1;


			var result = await _service.UnregisterFromExpeditionAsync(userId, expeditionId);


			Assert.IsFalse(result.Success);
		}

		[Test]
		public async Task UnregisterFromExpeditionAsync_WhoIsUnregistedAlready_ShouldReturnFail()
		{

			var userId = "1e03c155-39f3-4713-897e-6dd625681add";
			var expeditionId = 1;


			await _service.UnregisterFromExpeditionAsync(userId, expeditionId);

			var result = await _service.UnregisterFromExpeditionAsync(userId, expeditionId);

			Assert.IsFalse(result.Success);
		}

		[Test]
		public async Task AllExpeditionGetAsync_ShouldReturnAllExpeditions()
		{
			var result = await _service.AllExpeditionGetAsync();

			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task CheckIfExistExpeditionByIdAsync_WithValidId_ShouldReturnTrue()
		{
			var expeditionId = 1;

			var result = await _service.CheckIfExistExpeditionByIdAsync(expeditionId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task CheckIfExistExpeditionByIdAsync_WithInvalidId_ShouldReturnFalse()
		{
			var expeditionId = 2;

			var result = await _service.CheckIfExistExpeditionByIdAsync(expeditionId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task CheckIfExistExpeditionByNameAsync_WithValidName_ShouldReturnTrue()
		{
			var expeditionName = "Изпитай себе си и изкачи Еверест!";

			var result = await _service.CheckIfExistExpeditionByNameAsync(expeditionName);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task CheckIfExistExpeditionByNameAsync_WithInvalidName_ShouldReturnFalse()
		{
			var expeditionName = "Изпитай себе си и изкачи К2!";

			var result = await _service.CheckIfExistExpeditionByNameAsync(expeditionName);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task DetailsAsync_WithValidId_ShouldReturnExpeditionDetails()
		{
			var expeditionId = 1;

			var result = await _service.DetailsAsync(expeditionId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(expeditionId));
			Assert.That(result.Name, Is.EqualTo("Изпитай себе си и изкачи Еверест!"));
			Assert.That(result.StartDate, Is.EqualTo("01.04.2024 00:00"));
			Assert.That(result.EndDate, Is.EqualTo("10.06.2024 00:00"));
			Assert.That(result.Price, Is.EqualTo(55_000.00m));
			Assert.That(result.RouteName, Is.EqualTo("Североизточен ръб - Еверест"));
			Assert.That(result.TourAgencyName, Is.EqualTo("Hikers"));
			Assert.That(result.Program, Is.EqualTo("Връх Еверест е общо 10-седмична експедиция, с 2 седмици време за преход и 8 седмици период на изкачване. Не очаквайте обаче да се приберете у дома след изкачването на Еверест и да се върнете към нормалния живот, може да отнеме седмици и дори месеци, за да се възстановите напълно, както физически, така и психически.\r\n\r\nРаботим по съгласуван принцип за достигане на определени височини и спане в определени лагери по структуриран начин за период от осем седмици след достигане на базовия лагер, което позволява както зареждане на лагерите, така и оптимално време за аклиматизация. Програмата за катерачите се определя до голяма степен от графика на лагерите за зареждане, който от своя страна се определя от времето и позволява достатъчно почивки. Всеки опитен катерач ще разбере тази политика и ще се чувства удобно с гъвкавостта.\r\n\r\nПОХОД И АКЛИМАТИЗАЦИОНЕН ПЕРИОД ПРИ ИЗКАЧВАНЕ НА ЕВЕРЕСТ\r\nПървите 10 дни преминават в преход до базовия лагер. След това следва период на почивка и установяване. Ръководителите на екипи ще се срещнат и ще обсъдят съвместни операции по въпроси като поставяне на стационарни линии. Екипите също трябва да изчакат ледопадът да бъде „поправен“ от екипите на шерпите, чиято работа е да поставят стълбите и фиксираните въжета. Това отново може да отнеме дни.\r\n\r\nСледващият месец ще бъде прекаран в извършване на редица проучвателни изкачвания до лагер 1 през ледопада Khumbu и след това до лагер 2, където е важно да прекарате няколко нощувки. Времето и адаптацията към надморската височина ще определят точните дни, в които екипът ще се изкачва и почива. Носенето на лична екипировка може да се направи, докато шерпите поставят цялото основно оборудване до високите лагери. През това време ние също се аклиматизираме, като изкачваме друг връх в района, като Lobuche East или Island Peak.\r\n\r\nИма поне едно посещение на лагер 3 за нощувка. Това ще бъде добър шанс да тествате реакцията на тялото на много голяма надморска височина. За повечето хора Лагер 3 е най-високата точка, която ще достигнат без използването на бутилиран кислород, въпреки че някои хора избират да купят допълнителни бутилки, за да помогнат да стигнат до тази точка. След посещение на лагер 3 обикновено има почивка в базовия лагер или по-ниско, като подготовка за наддаване на върха. Често слизаме в Дебош, за да видим малко трева и да хапнем добра храна. ПЕРИОД НА ВЪРХА НА ЕВЕРЕСТ\r\nСлед като бъде взето решение да се направи опит за изкачване на върха в период някъде около средата на две седмици на май (статистически това е сравнително нормално, но хората са се изкачвали преди и след), тогава общият цикъл на върха от основата до върха и обратно е нормално седем дни, което позволява няколко нощувки в лагер 2 и след това една нощ в лагер 3. Изкачването до лагер 4 на южния стълб на Еверест става част от самото изкачване на върха, тъй като обикновено екипите пристигат в средата на следобед и почиват до около 21:00 когато се използват бутилки с пресен кислород, за да се изкачите до Балкона и да се присъедините към югоизточното било.\r\n\r\nСутринта на върха може да бъде съпътствана от проблеми с пренаселеността, особено на скалистото стъпало под южния връх. Обикновено груповият ред се определя по взаимно съгласие между ръководствата на компанията, но това не винаги е приложимо. Не е необичайно да откриете, че се движите много бавно зад голяма група или бавен индивид без възможност за изпреварване. Това води до студ и прекомерна употреба на ресурси като кислород. На балкона обикновено има смяна на бутилки, което дава възможност за промяна на груповия ред.\r\n\r\nОт Балкона до южния връх няма много възможности за изпреварване, въпреки че някои групи ще създадат свои собствени фиксирани линии от едната страна на основната. Може да бъде объркващо и разочароващо. Опитът и стабилната ръка тук ще бъдат много важни. До изгрев слънце бихме искали да сме на или под южния връх, с още два часа в ръка, за да стигнем върха.\r\n\r\nМаршрутът до Hillary Step е тесен и вълнуващ и неизбежно в ден с хубаво време ще има опашка в дъното на стъпалото и тук няма друг избор, освен да чакате. Стъпката може да е камениста или покрита със сняг и обикновено отнема само около двадесет минути, за да се премине. Оттам последните двеста метра до върха са лесна разходка. Целта е да пристигнете в средата на сутринта, като оставите целия останал ден, за да слезете обратно в лагер 4 и да си починете. Някои силни отбори желаят да стигнат до Лагер 3, но това не е приемливо, ако остави шерпите на високо ниво с огромно количество работа за вършене.\r\n\r\nВРЪЩАНЕ ОТ ЕВЕРЕСТ\r\nНяколко дни, прекарани обратно в базовия лагер, помагайки за разчистването на лагера, са последвани от преход обратно до Лукла и полет до Катманду. Някои хора избират да наемат хеликоптер, което е добре, но ние смятаме, че е важно да помогнем на шерпите да изчистят планината, а не просто да напуснат. Общата учтивост и уважение предполагат, че всеки ще се включи в разпадането на лагера, това е много по-приятно и трябва да се разглежда като част от пътуването и преживяването. Отнема много време, за да се обработи и усвои подобно преживяване, наистина няма нужда да бързате направо към Катманду."));
			Assert.That(result.Days, Is.EqualTo(71));
			Assert.That(result.Enrolment, Is.EqualTo(20));
			Assert.That(result.Excludes, Is.EqualTo("Западен гид - може да се добави на частна основа.\r\nМеждународно пътуване до Катманду\r\nВсички полети с хеликоптер, използвани по лични причини\r\nЛична туристическа застраховка\r\nЛична екипировка и екипировка за катерене\r\nНепалска виза\r\nДопълнителни кислородни бутилки (700 USD всяка)\r\nРазходи, свързани с преждевременно приключване на експедиция или преждевременно напускане на експедиция.\r\nРазходи, свързани с удължаване на пътуване поради лошо време или други обстоятелства, включително разходите за допълнителни нощувки\r\nБонус за деня на срещата на върха към вашия водач шерпа от 2000,00 USD"));
			Assert.That(result.OrganiserId, Is.EqualTo("007b397f-9a3d-48d5-a8e4-ad00bbc43326"));
			Assert.That(result.RouteId, Is.EqualTo(1));
			Assert.That(result.TourAgencyId, Is.EqualTo(1));
			Assert.That(result.Includes, Is.EqualTo("Такса за разрешение за Еверест (в момента $11,500.00 на човек)\r\nТакса за ледопад Кхумбу\r\nSPCC такса за боклук и разходи за управление на боклука в базовия лагер\r\nКолективна такса за фиксирана линия над базовия лагер\r\nФонд за базовия лагер на Himalayan Rescue Assn за спешни медицински случаи и покритие за шерпи.\r\nНадбавка за офицер за връзка\r\nКатерене на шерпи\r\nПерсонал на базовия лагер - готвач, помощник-готвач, носачи\r\nЗастрахователно покритие на персонала за спешна евакуация с хеликоптер и медицинска застраховка\r\nВсички хранения\r\nПалатки за спане в базовия лагер (1 на член) и общи палатки в по-високите лагери\r\nПалатка за тоалетна и душ\r\nСъоръжения за първа помощ и използване на HRA станцията в базовия лагер\r\nКислородни бутилки (3 литра х 6 на човек), плюс една маска и регулатор на човек\r\nФиксирано въже и снежни барове (обикновено се предоставят от общността, но ние също ще имаме наши собствени)\r\nСтолова палатка BC и C2\r\nПреходът струва до базовия лагер и транспорт на оборудването с якове и носачи\r\nНастаняване в Катманду - двойна стая за 3 нощувки\r\nЛукла полет"));
			Assert.That(result.Extras, Is.EqualTo("ХОТЕЛ ЯК И ЙЕТИ\r\n3 нощувки в двойна/двойна стандартна стая в този луксозен 5-звезден хотел, предлагащ съчетание от съвременна изтънченост и културно наследство със своя 100-годишен дворец и новопроектираната структура на хотела за 495$"));
		}

		[Test]
		public async Task DetailsAsync_WithInvalidId_ShouldReturnNull()
		{
			var expeditionId = 2;

			var result = await _service.DetailsAsync(expeditionId);

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task DeleteGetAsync_WithValidId_ShouldReturnExpeditionDetails()
		{
			var expeditionId = 1;

			var result = await _service.DeleteGetAsync(expeditionId);
			var expedition = await _service.DetailsAsync(expeditionId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(expeditionId));
			Assert.That(result.Name, Is.EqualTo(expedition.Name));
			Assert.That(result.StartDate, Is.EqualTo(expedition.StartDate));
			Assert.That(result.EndDate, Is.EqualTo(expedition.EndDate));
			Assert.That(result.Price, Is.EqualTo(55_000.00m.ToString()));
			Assert.That(result.TourAgencyName, Is.EqualTo(expedition.TourAgencyName));
			Assert.That(result.OrganiserId, Is.EqualTo(expedition.OrganiserId));
		}

		[Test]
		public async Task DeleteGetAsync_WithInvalidId_ShouldReturnNull()
		{
			var expeditionId = 2;

			var result = await _service.DeleteGetAsync(expeditionId);

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task DeleteConfirmedAsync_WithValidId_ShouldDeleteExpedition()
		{
			var expeditionId = 1;
			await _service.DeleteConfirmedAsync(expeditionId);

			var result = this._context.Expeditions.FirstOrDefault(e => e.Id == 1);

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task DeleteConfirmedAsync_WithParticipants_ShouldDeleteAll()
		{
			var expeditionId = 1;
			await _service.DeleteConfirmedAsync(expeditionId);

			var result = this._context.ExpeditionsParticipants.FirstOrDefault(e => e.ExpeditionId == 1);

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task AddAsync_ShouldAddExpedition()
		{
			var startDate = DateTime.Now.AddDays(-1);
			var endDate = DateTime.Now.AddDays(1);

			var expedition = new ExpeditionAddViewModel
			{
				Name = "Изпитай себе си и изкачи К2!",
				StartDate = startDate,
				EndDate = endDate,
				Price = 55_000.00m,
				RouteId = 1,
				TourAgencyId = 1,
				Program = "aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis volutpat est velit egestas dui",
				Days = 71,
				Enrolment = 20,
				Includes = "aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis volutpat est velit egestas dui",
				Excludes = "aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis volutpat est velit egestas dui",
				Extras = "aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis volutpat est velit egestas dui",
				OrganiserId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326",
			};

			await _service.AddAsync(expedition);

			var allExpeditions = await _service.AllExpeditionGetAsync();

			var result = await _service.DetailsAsync(2);

			Assert.That(allExpeditions.Count(), Is.EqualTo(2));

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Name, Is.EqualTo(expedition.Name));
			Assert.That(result.StartDate.ToString(), Is.EqualTo(expedition.StartDate.ToString(DateTimeFormat)));
			Assert.That(result.EndDate.ToString(), Is.EqualTo(expedition.EndDate.ToString(DateTimeFormat)));
			Assert.That(result.Price, Is.EqualTo(55_000.00m));
			Assert.That(result.RouteId, Is.EqualTo(expedition.RouteId));
			Assert.That(result.TourAgencyId, Is.EqualTo(expedition.TourAgencyId));
			Assert.That(result.Program, Is.EqualTo(expedition.Program));
			Assert.That(result.Days, Is.EqualTo(expedition.Days));
			Assert.That(result.Enrolment, Is.EqualTo(expedition.Enrolment));
			Assert.That(result.Includes, Is.EqualTo(expedition.Includes));
			Assert.That(result.Excludes, Is.EqualTo(expedition.Excludes));
		}


		[Test]
		public async Task EditGetAsync_WithValidId_ShouldReturnExpeditionEditViewModel()
		{
			var expeditionId = 1;

			var result = await _service.EditGetAsync(expeditionId);
			var expedition = await _service.DetailsAsync(expeditionId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(expeditionId));
			Assert.That(expedition.Name, Is.EqualTo(result.Name));
			Assert.That(expedition.StartDate, Is.EqualTo(result.StartDate.ToString(DateTimeFormat)));
			Assert.That(expedition.EndDate, Is.EqualTo(result.EndDate.ToString(DateTimeFormat)));
			Assert.That(expedition.Price, Is.EqualTo(result.Price));
			Assert.That(expedition.RouteId, Is.EqualTo(result.RouteId));
			Assert.That(expedition.Includes, Is.EqualTo(expedition.Includes));
			Assert.That(expedition.Excludes, Is.EqualTo(expedition.Excludes));
			Assert.That(expedition.Extras, Is.EqualTo(expedition.Extras));
			Assert.That(expedition.Program, Is.EqualTo(expedition.Program));
			Assert.That(expedition.Days, Is.EqualTo(expedition.Days));
			Assert.That(expedition.Enrolment, Is.EqualTo(expedition.Enrolment));
		}

		[Test]
		public async Task EditPostAsync_ShouldEditExpedition()
		{
			var startDate = DateTime.Now.AddDays(-1);
			var endDate = DateTime.Now.AddDays(1);

			var expedition = new ExpeditionEditViewModel
			{
				Id = 1,
				Name = "Изпитай себе си и изкачи К2!",
				StartDate = startDate,
				EndDate = endDate,
				Price = 55_000.00m,
				RouteId = 1,
				Program =
					"aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis volutpat est velit egestas dui",
				Days = 71,
				Enrolment = 20,
				Includes =
					"aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis volutpat est velit egestas dui",
				Excludes =
					"aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultr"
			};

			await _service.EditPostAsync(expedition);

			var result = await _service.DetailsAsync(1);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Name, Is.EqualTo(expedition.Name));
			Assert.That(result.StartDate.ToString(), Is.EqualTo(expedition.StartDate.ToString(DateTimeFormat)));
			Assert.That(result.EndDate.ToString(), Is.EqualTo(expedition.EndDate.ToString(DateTimeFormat)));
			Assert.That(result.Price, Is.EqualTo(55_000.00m));
			Assert.That(result.RouteId, Is.EqualTo(expedition.RouteId));
			Assert.That(result.Program, Is.EqualTo(expedition.Program));
			Assert.That(result.Days, Is.EqualTo(expedition.Days));
			Assert.That(result.Enrolment, Is.EqualTo(expedition.Enrolment));
			Assert.That(result.Includes, Is.EqualTo(expedition.Includes));
			Assert.That(result.Excludes, Is.EqualTo(expedition.Excludes));
		}

		[Test]
		public async Task UserExpeditionsAsync()
		{
			var userId = "1e03c155-39f3-4713-897e-6dd625681add";

			var result = await _service.UserExpeditionsAsync(userId);

			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task UserExpeditionsAsync_WithInvalidUserId_ShouldReturnEmptyCollection()
		{
			var userId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326";

			var result = await _service.UserExpeditionsAsync(userId);

			Assert.That(result.Count(), Is.EqualTo(0));
		}
	}
}
