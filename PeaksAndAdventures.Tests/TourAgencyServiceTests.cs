using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.TourAgency;
using PeaksAndAdventures.Core.Services;
using PeaksAndAdventures.Infrastructure.Data;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Tests
{
	[TestFixture]
	public class TourAgencyServiceTests
	{
		private PeaksAndAdventuresDbContext _context;

		private IRepository _repository;
		private ITourAgencyService _tourAgencyService;

		private IEnumerable<TourAgency> _tourAgencies;
		private IEnumerable<MountainGuide> _mountainGuides;
		private IEnumerable<Expedition> _expeditions;
		private IEnumerable<IdentityUser> _users;

		private IEnumerable<ExpeditionParticipant> _expeditionParticipants;

		[SetUp]
		public void SetUp()
		{
			var options = new DbContextOptionsBuilder<PeaksAndAdventuresDbContext>()
				.UseInMemoryDatabase(databaseName: "PeaksAndAdventuresTest" + Guid.NewGuid().ToString())
				.Options;

			_context = new PeaksAndAdventuresDbContext(options);

			_repository = new Repository(_context);
			_tourAgencyService = new TourAgencyService(_repository);

			_tourAgencies = new List<TourAgency>()
			{
				new TourAgency()
				{
					Id = 1,
					Name = "Hikers",
					Description = "Hikers е изключително престижна туристическа агенция, посветена на страстта и приключението в света на планинарството. С богат опит в организацията на експедиции и планинарски турове, тази агенция съчетава страстта към природата със знание и професионализъм.\r\nНашата мисия е да предоставяме неповторими и вълнуващи преживявания за всички любители на приключенските спортове и обичатели на природата. Специализирани в организирането на експедиции в различни части на света, ние съчетаваме уникални маршрути, експертни водачи и безопасност на високо ниво, за да осигурим незабравими преживявания на върховете на света.\r\n\r\nНашите експедиции включват разнообразни дестинации - от високите върхове на Хималаите, през загадъчните планини в Южна Америка, до непокорените върхове в Африка и още много други. Съчетаваме екстремни предизвикателства с красивите природни пейзажи, за да създадем едно неповторимо приключение.\r\n\r\nНашите професионални гидове и инструктори са подготвени да водят клиентите ни през всеки етап от техния планинарски път. Разполагаме с модерно оборудване и осигуряваме пълна подкрепа за участниците в нашите турове, гарантирайки тяхната безопасност и комфорт.\r\nClimb and Hiking не предлага просто пътувания; предлагаме възможността за откриване на света от високо и по нов, невиждан начин. За нас, планинарството е не просто хоби, а начин на живот, който искаме да споделим с всички, които търсят истинско предизвикателство и незабравими преживявания в планината. Приключили сте да се катерите – започнете да живеете!",
					Email = "hikers@mail.com",
					Phone = "0899001166",
					OwnerId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326"
				}
			};
			_mountainGuides = new List<MountainGuide>()
			{
				new MountainGuide {
					Id = 1,
					Email = "climber@mail.com",
					Experience = 7,
					FirstName = "Илия",
					LastName = "Петканов",
					Phone = "0895123456",
					Age = 32,
					ImageUrl = "https://i.pik.bg/news/326/660_5a4e3ddb77802504f456d107ec12255d.jpg",
					TourAgencyId = 1,
					OwnerId = "0d59049e-81f2-48f1-abb2-a5fd09bc210f",
				},
			};
			_expeditions = new List<Expedition>()
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
				RouteId = 6,
				Enrolment = 20,
				TourAgencyId = 1,
				Price = 55_000.00m,
				Program = "Връх Еверест е общо 10-седмична експедиция, с 2 седмици време за преход и 8 седмици период на изкачване. Не очаквайте обаче да се приберете у дома след изкачването на Еверест и да се върнете към нормалния живот, може да отнеме седмици и дори месеци, за да се възстановите напълно, както физически, така и психически.\r\n\r\nРаботим по съгласуван принцип за достигане на определени височини и спане в определени лагери по структуриран начин за период от осем седмици след достигане на базовия лагер, което позволява както зареждане на лагерите, така и оптимално време за аклиматизация. Програмата за катерачите се определя до голяма степен от графика на лагерите за зареждане, който от своя страна се определя от времето и позволява достатъчно почивки. Всеки опитен катерач ще разбере тази политика и ще се чувства удобно с гъвкавостта.\r\n\r\nПОХОД И АКЛИМАТИЗАЦИОНЕН ПЕРИОД ПРИ ИЗКАЧВАНЕ НА ЕВЕРЕСТ\r\nПървите 10 дни преминават в преход до базовия лагер. След това следва период на почивка и установяване. Ръководителите на екипи ще се срещнат и ще обсъдят съвместни операции по въпроси като поставяне на стационарни линии. Екипите също трябва да изчакат ледопадът да бъде „поправен“ от екипите на шерпите, чиято работа е да поставят стълбите и фиксираните въжета. Това отново може да отнеме дни.\r\n\r\nСледващият месец ще бъде прекаран в извършване на редица проучвателни изкачвания до лагер 1 през ледопада Khumbu и след това до лагер 2, където е важно да прекарате няколко нощувки. Времето и адаптацията към надморската височина ще определят точните дни, в които екипът ще се изкачва и почива. Носенето на лична екипировка може да се направи, докато шерпите поставят цялото основно оборудване до високите лагери. През това време ние също се аклиматизираме, като изкачваме друг връх в района, като Lobuche East или Island Peak.\r\n\r\nИма поне едно посещение на лагер 3 за нощувка. Това ще бъде добър шанс да тествате реакцията на тялото на много голяма надморска височина. За повечето хора Лагер 3 е най-високата точка, която ще достигнат без използването на бутилиран кислород, въпреки че някои хора избират да купят допълнителни бутилки, за да помогнат да стигнат до тази точка. След посещение на лагер 3 обикновено има почивка в базовия лагер или по-ниско, като подготовка за наддаване на върха. Често слизаме в Дебош, за да видим малко трева и да хапнем добра храна. ПЕРИОД НА ВЪРХА НА ЕВЕРЕСТ\r\nСлед като бъде взето решение да се направи опит за изкачване на върха в период някъде около средата на две седмици на май (статистически това е сравнително нормално, но хората са се изкачвали преди и след), тогава общият цикъл на върха от основата до върха и обратно е нормално седем дни, което позволява няколко нощувки в лагер 2 и след това една нощ в лагер 3. Изкачването до лагер 4 на южния стълб на Еверест става част от самото изкачване на върха, тъй като обикновено екипите пристигат в средата на следобед и почиват до около 21:00 когато се използват бутилки с пресен кислород, за да се изкачите до Балкона и да се присъедините към югоизточното било.\r\n\r\nСутринта на върха може да бъде съпътствана от проблеми с пренаселеността, особено на скалистото стъпало под южния връх. Обикновено груповият ред се определя по взаимно съгласие между ръководствата на компанията, но това не винаги е приложимо. Не е необичайно да откриете, че се движите много бавно зад голяма група или бавен индивид без възможност за изпреварване. Това води до студ и прекомерна употреба на ресурси като кислород. На балкона обикновено има смяна на бутилки, което дава възможност за промяна на груповия ред.\r\n\r\nОт Балкона до южния връх няма много възможности за изпреварване, въпреки че някои групи ще създадат свои собствени фиксирани линии от едната страна на основната. Може да бъде объркващо и разочароващо. Опитът и стабилната ръка тук ще бъдат много важни. До изгрев слънце бихме искали да сме на или под южния връх, с още два часа в ръка, за да стигнем върха.\r\n\r\nМаршрутът до Hillary Step е тесен и вълнуващ и неизбежно в ден с хубаво време ще има опашка в дъното на стъпалото и тук няма друг избор, освен да чакате. Стъпката може да е камениста или покрита със сняг и обикновено отнема само около двадесет минути, за да се премине. Оттам последните двеста метра до върха са лесна разходка. Целта е да пристигнете в средата на сутринта, като оставите целия останал ден, за да слезете обратно в лагер 4 и да си починете. Някои силни отбори желаят да стигнат до Лагер 3, но това не е приемливо, ако остави шерпите на високо ниво с огромно количество работа за вършене.\r\n\r\nВРЪЩАНЕ ОТ ЕВЕРЕСТ\r\nНяколко дни, прекарани обратно в базовия лагер, помагайки за разчистването на лагера, са последвани от преход обратно до Лукла и полет до Катманду. Някои хора избират да наемат хеликоптер, което е добре, но ние смятаме, че е важно да помогнем на шерпите да изчистят планината, а не просто да напуснат. Общата учтивост и уважение предполагат, че всеки ще се включи в разпадането на лагера, това е много по-приятно и трябва да се разглежда като част от пътуването и преживяването. Отнема много време, за да се обработи и усвои подобно преживяване, наистина няма нужда да бързате направо към Катманду.",
				OrganiserId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326",
				}
			};
			_users = new List<IdentityUser>()
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
				}
			};

			_expeditionParticipants = new List<ExpeditionParticipant>()
			{
				new ExpeditionParticipant()
				{
					ExpeditionId = 1, ParticipantId = "0d59049e-81f2-48f1-abb2-a5fd09bc210f"
				}
			};

			_context.AddRange(_tourAgencies);
			_context.AddRange(_mountainGuides);
			_context.AddRange(_expeditions);
			_context.AddRange(_users);
			_context.AddRange(_expeditionParticipants);

			_context.SaveChanges();
		}

		[TearDown]
		public async Task TearDown()
		{
			await _context.Database.EnsureDeletedAsync();
			await _context.DisposeAsync();
		}

		[Test]
		public async Task GetAllTourAgenciesAsync_WithTourAgencies_ShouldReturnAllTourAgencies()
		{
			var result = await _tourAgencyService.GetAllTourAgenciesAsync();

			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task GetTourAgencyByNameAsync_WithTourAgencyName_ShouldReturnTourAgency()
		{
			var result = await _tourAgencyService.GetTourAgencyByNameAsync("Hikers");

			Assert.That(result, Is.Not.Null);
		}

		[Test]
		public async Task GetTourAgencyByNameAsync_WithNonExistingTourAgencyName_ShouldReturnNull()
		{
			var result = await _tourAgencyService.GetTourAgencyByNameAsync("NonExisting");

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task CheckIfExistTourAgencyByNameAsync_WithExistingTourAgencyName_ShouldReturnTrue()
		{
			var result = await _tourAgencyService.CheckIfExistTourAgencyByNameAsync("Hikers");

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task CheckIfExistTourAgencyByNameAsync_WithNonExistingTourAgencyName_ShouldReturnFalse()
		{
			var result = await _tourAgencyService.CheckIfExistTourAgencyByNameAsync("NonExisting");

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task CheckIfExistTourAgencyByIdAsync_WithExistingTourAgencyId_ShouldReturnTrue()
		{
			var result = await _tourAgencyService.CheckIfExistTourAgencyByIdAsync(1);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task CheckIfExistTourAgencyByIdAsync_WithNonExistingTourAgencyId_ShouldReturnFalse()
		{
			var result = await _tourAgencyService.CheckIfExistTourAgencyByIdAsync(2);

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task CheckIfExistTourAgencyByOwnerIdAsync_WithExistingOwnerId_ShouldReturnTrue()
		{
			var result = await _tourAgencyService.CheckIfExistTourAgencyByOwnerIdAsync("007b397f-9a3d-48d5-a8e4-ad00bbc43326");

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task CheckIfExistTourAgencyByOwnerIdAsync_WithNonExistingOwnerId_ShouldReturnFalse()
		{
			var result = await _tourAgencyService.CheckIfExistTourAgencyByOwnerIdAsync("NonExisting");

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task GetExpeditionsInAgencyAsync_WithExistingTourAgencyId_ShouldReturnExpeditions()
		{
			var result = await _tourAgencyService.GetExpeditionsInAgencyAsync(1);

			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task GetExpeditionsInAgencyAsync_WithNonExistingTourAgencyId_ShouldReturnEmptyCollection()
		{
			var result = await _tourAgencyService.GetExpeditionsInAgencyAsync(2);

			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public async Task AllMountainGuideInAgencyAsync_WithExistingTourAgencyId_ShouldReturnMountainGuides()
		{
			var result = await _tourAgencyService.AllMountainGuideInAgencyAsync(1);

			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task AllMountainGuideInAgencyAsync_WithNonExistingTourAgencyId_ShouldReturnEmptyCollection()
		{
			var result = await _tourAgencyService.AllMountainGuideInAgencyAsync(2);

			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public async Task DetailsAsync_WithExistingTourAgencyId_ShouldReturnTourAgencyDetails()
		{
			var result = await _tourAgencyService.DetailsAsync(1);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Name, Is.EqualTo("Hikers"));
			Assert.That(result.Description, Is.EqualTo("Hikers е изключително престижна туристическа агенция, посветена на страстта и приключението в света на планинарството. С богат опит в организацията на експедиции и планинарски турове, тази агенция съчетава страстта към природата със знание и професионализъм.\r\nНашата мисия е да предоставяме неповторими и вълнуващи преживявания за всички любители на приключенските спортове и обичатели на природата. Специализирани в организирането на експедиции в различни части на света, ние съчетаваме уникални маршрути, експертни водачи и безопасност на високо ниво, за да осигурим незабравими преживявания на върховете на света.\r\n\r\nНашите експедиции включват разнообразни дестинации - от високите върхове на Хималаите, през загадъчните планини в Южна Америка, до непокорените върхове в Африка и още много други. Съчетаваме екстремни предизвикателства с красивите природни пейзажи, за да създадем едно неповторимо приключение.\r\n\r\nНашите професионални гидове и инструктори са подготвени да водят клиентите ни през всеки етап от техния планинарски път. Разполагаме с модерно оборудване и осигуряваме пълна подкрепа за участниците в нашите турове, гарантирайки тяхната безопасност и комфорт.\r\nClimb and Hiking не предлага просто пътувания; предлагаме възможността за откриване на света от високо и по нов, невиждан начин. За нас, планинарството е не просто хоби, а начин на живот, който искаме да споделим с всички, които търсят истинско предизвикателство и незабравими преживявания в планината. Приключили сте да се катерите – започнете да живеете!"));
			Assert.That(result.Email, Is.EqualTo("hikers@mail.com"));
			Assert.That(result.Phone, Is.EqualTo("0899001166"));
			Assert.That(result.OwnerId, Is.EqualTo("007b397f-9a3d-48d5-a8e4-ad00bbc43326"));
		}

		[Test]
		public async Task AddTourAgencyAsync_ShouldAddTourAgency()
		{
			var tourAgencyForm = new TourAgencyAddViewModel()
			{
				Name = "Mountain Hiking",
				Description =
					"Mountain Hiking е водеща туристическа агенция, специализирана в организирането на експедиции и приключения в някои от най-забележителните планински региони по целия свят. Със седалище в град София, ние предлагаме разнообразни програми за планинско изкачване, трекинг и бекпекинг за любители на приключенията от всички възрасти и нива на опит.\r\n\r\nНашата мисия е да предоставим незабравими преживявания в най-вълнуващите планински дестинации по света. Нашите експедиции са изградени с основен фокус върху безопасността, удовлетворението на клиентите и запазването на околната среда. С помощта на нашия екип от опитни планински водачи и инструктори, гарантираме, че всеки участник ще се наслади на неповторимо приключение и ще създаде незабравими спомени.\r\n\r\nНезависимо дали сте нов в света на планинските спортове или опитен алпинист, Mountain Hiking предлага разнообразни програми, които да задоволят вашите нужди и предпочитания. От изследване на върховете на Хималаите до изследване на планините на Патагония, ние сме ваш пътеводител към най-вълнуващите приключения в планинския свят.",
				Email = "mountainHiking@gmail.com",
				Phone = "0895738889",
				OwnerId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326",
			};

			await _tourAgencyService.AddTourAgencyAsync(tourAgencyForm);

			var allAgencies = await _tourAgencyService.GetAllTourAgenciesAsync();

			Assert.That(allAgencies.Count(), Is.EqualTo(2));

			var result = await _tourAgencyService.DetailsAsync(2);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Name, Is.EqualTo(result.Name));
			Assert.That(result.Description, Is.EqualTo(result.Description));
			Assert.That(result.Email, Is.EqualTo(result.Email));
			Assert.That(result.Phone, Is.EqualTo(result.Phone));
			Assert.That(result.OwnerId, Is.EqualTo(result.OwnerId));
		}

		[Test]
		public async Task EditGetAsync_ShouldGetInformationAboutEditTourAgency()
		{
			var result = await _tourAgencyService.EditGetAsync(1);
			var tourAgency = await _tourAgencyService.DetailsAsync(1);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Name, Is.EqualTo(tourAgency.Name));
			Assert.That(result.Description, Is.EqualTo(tourAgency.Description));
			Assert.That(result.Email, Is.EqualTo(tourAgency.Email));
			Assert.That(result.Phone, Is.EqualTo(tourAgency.Phone));
			Assert.That(result.OwnerId, Is.EqualTo(tourAgency.OwnerId));
		}

		[Test]
		public async Task EditPostAsync_ShouldEditTourAgency()
		{
			var tourAgencyForm = new TourAgencyEditViewModel()
			{
				Id = 1,
				Name = "Hike and climb in Mountains",
				Description =
					"Hikers е изключително престижна туристическа агенция, посветена на страстта и приключението в света на планинарството. С богат опит в организацията на експедиции и планинарски турове, тази агенция съчетава страстта към природата със знание и професионализъм.\r\nНашата мисия е да предоставяме неповторими и вълнуващи преживявания за всички любители на приключенските спортове и обичатели на природата. Специализирани в организирането на експедиции в различни части на света, ние съчетаваме уникални маршрути, експертни водачи и безопасност на високо ниво, за да осигурим незабравими преживявания на върховете на света.\r\n\r\nНашите експедиции включват разнообразни дестинации - от високите върхове на Хималаите, през загадъчните планини в Южна Америка, до непокорените върхове в Африка и още много други. Съчетаваме екстремни предизвикателства с красивите природни пейзажи, за да създадем едно неповторимо приключение.\r\n\r\nНашите професионални гидове и инструктори са подготвени да водят клиентите ни през всеки етап от техния планинарски път. Разполагаме с модерно оборудване и осигуряваме пълна подкрепа за участниците в нашите турове, гарантирайки тяхната безопасност и комфорт.\r\nClimb and Hiking не предлага просто пътувания; предлагаме възможността за откриване на света от високо и по нов, невиждан начин. За нас, планинарството е не просто хоби, а начин на живот, който искаме да споделим с всички, които търсят истинско предизвикателство и незабравими преживявания в планината. Приключили сте да се катерите – започнете да живеете!",
				Email = "hikers@mail.com",
				Phone = "0899001426",
				OwnerId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326"
			};

			await _tourAgencyService.EditPostAsync(tourAgencyForm);

			var result = await _tourAgencyService.DetailsAsync(1);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(tourAgencyForm.Id));
			Assert.That(result.Name, Is.EqualTo(tourAgencyForm.Name));
			Assert.That(result.Description, Is.EqualTo(tourAgencyForm.Description));
			Assert.That(result.Email, Is.EqualTo(tourAgencyForm.Email));
			Assert.That(result.Phone, Is.EqualTo(tourAgencyForm.Phone));
			Assert.That(result.OwnerId, Is.EqualTo(tourAgencyForm.OwnerId));
		}

		[Test]
		public async Task DeleteGetAsync_WithExistingTourAgencyId_ShouldReturnTourAgencyDeleteViewModel()
		{
			var result = await _tourAgencyService.DeleteGetAsync(1);
			var agency = await _tourAgencyService.DetailsAsync(1);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Name, Is.EqualTo(agency.Name));
			Assert.That(result.Email, Is.EqualTo(agency.Email));
			Assert.That(result.Phone, Is.EqualTo(agency.Phone));
			Assert.That(result.OwnerId, Is.EqualTo(agency.OwnerId));
		}

		[Test]
		public async Task DeleteConfirmedAsync_ShouldDeleteTourAgency()
		{
			var tourAgencyForm = new TourAgencyAddViewModel()
			{
				Name = "Mountain Hiking",
				Description =
					"Mountain Hiking е водеща туристическа агенция, специализирана в организирането на експедиции и приключения в някои от най-забележителните планински региони по целия свят. Със седалище в град София, ние предлагаме разнообразни програми за планинско изкачване, трекинг и бекпекинг за любители на приключенията от всички възрасти и нива на опит.\r\n\r\nНашата мисия е да предоставим незабравими преживявания в най-вълнуващите планински дестинации по света. Нашите експедиции са изградени с основен фокус върху безопасността, удовлетворението на клиентите и запазването на околната среда. С помощта на нашия екип от опитни планински водачи и инструктори, гарантираме, че всеки участник ще се наслади на неповторимо приключение и ще създаде незабравими спомени.\r\n\r\nНезависимо дали сте нов в света на планинските спортове или опитен алпинист, Mountain Hiking предлага разнообразни програми, които да задоволят вашите нужди и предпочитания. От изследване на върховете на Хималаите до изследване на планините на Патагония, ние сме ваш пътеводител към най-вълнуващите приключения в планинския свят.",
				Email = "mountainHiking@gmail.com",
				Phone = "0895738889",
				OwnerId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326",
			};

			await _tourAgencyService.AddTourAgencyAsync(tourAgencyForm);

			await _tourAgencyService.DeleteConfirmedAsync(2);

			var allAgencies = await _tourAgencyService.GetAllTourAgenciesAsync();

			Assert.That(allAgencies.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task DeleteAsync_CantDeleteTourAgencyIfExpeditionOrganisedByHerHaveParticipant()
		{
			await _tourAgencyService.DeleteConfirmedAsync(1);

			var allAgencies = await _tourAgencyService.GetAllTourAgenciesAsync();

			Assert.That(allAgencies.Count(), Is.EqualTo(1));
		}
	}
}
