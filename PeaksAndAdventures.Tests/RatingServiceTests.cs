using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Services;
using PeaksAndAdventures.Infrastructure.Data;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Enums.Route;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Tests
{
	[TestFixture]
	public class RatingServiceTests
	{
		private PeaksAndAdventuresDbContext _context;

		private IRepository _repository;
		private IRatingService _ratingService;
		private IEnumerable<IdentityUser> _users;
		private IEnumerable<Rating> _ratings;
		private IEnumerable<TourAgency> _tourAgencies;
		private IEnumerable<MountainGuide> _mountainGuides;
		private IEnumerable<Route> _routes;

		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<PeaksAndAdventuresDbContext>()
				.UseInMemoryDatabase(databaseName: "PeaksAndAdventuresTest" + Guid.NewGuid().ToString())
				.Options;

			_context = new PeaksAndAdventuresDbContext(options);

			_repository = new Repository(_context);
			_ratingService = new RatingService(_repository);


			_ratings = new List<Rating>
			{
				new Rating
				{
					Id = 1,
					MountainGuideId = 1,
					Name = "Mountain Guide Rating",
					Values = new List<int> { 5, 5, 5, 5, 5 },
				},
				new Rating
				{
					Id = 2,
					RouteId = 1,
					Name = "Route Rating",
					Values = new List<int> { 2, 2, 4, 4 },
				},
				new Rating()
				{
					Id = 3,
					TourAgencyId = 1,
					Name = "Tour Agency Rating",
					Values = new List<int> { 1, 2, 3, 4, 5 }
				}
			};

			_users = new List<IdentityUser>()
			{
				new IdentityUser()
				{
					Id = "007b397f-9a3d-48d5-a8e4-ad00bbc43326",
					UserName = "hikers@mail.com",
					NormalizedUserName = "HIKERS@MAIL.COM",
					Email = "hikers@mail.com",
					NormalizedEmail = "HIKERS@MAIL.COM"
				},
				new IdentityUser()
				{
					Id = "0d59049e-81f2-48f1-abb2-a5fd09bc210f",
					UserName = "climber@mail.com",
					NormalizedUserName = "CLIMBER@MAIL.COM",
					Email = "climber@mail.com",
					NormalizedEmail = "CLIMBER@MAIL.COM"
				}
			};

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
				new MountainGuide()
				{
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
					MountainId = 1
				}
			};

			_context.Ratings.AddRange(_ratings);
			_context.SaveChanges();
		}

		[TearDown]
		public async Task TearDown()
		{
			await _context.Database.EnsureDeletedAsync();
			await _context.DisposeAsync();
		}

		[Test]
		public async Task AddRatingAsync_ShouldAddRatingToMountainGuide()
		{
			// Arrange
			var id = 1;
			var entityType = "MountainGuide";
			var value = 5;

			// Act
			await _ratingService.AddRatingAsync(id, entityType, value);

			// Assert
			var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.MountainGuideId == id);
			Assert.That(rating.Values.Count, Is.EqualTo(6));
		}

		[Test]
		public async Task AddRatingAsync_ShouldAddRatingToRoute()
		{
			// Arrange
			var id = 1;
			var entityType = "Route";
			var value = 5;

			// Act
			await _ratingService.AddRatingAsync(id, entityType, value);

			// Assert
			var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.RouteId == id);
			Assert.That(rating.Values.Count, Is.EqualTo(5));
		}

		[Test]
		public async Task AddRatingAsync_ShouldAddRatingToTourAgency()
		{
			// Arrange
			var id = 1;
			var entityType = "TourAgency";
			var value = 5;

			// Act
			await _ratingService.AddRatingAsync(id, entityType, value);

			// Assert
			var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.TourAgencyId == id);
			Assert.That(rating.Values.Count, Is.EqualTo(6));
		}

		[Test]
		public async Task GetAverageRatingByGuideAsync_ShouldReturnAverageRating()
		{
			// Arrange
			var guideId = 1;

			// Act
			var result = await _ratingService.GetAverageRatingByGuideAsync(guideId);

			// Assert
			Assert.That(result, Is.EqualTo(5));
		}

		[Test]
		public async Task GetAverageRatingByAgencyAsync_ShouldReturnAverageRating()
		{
			// Arrange
			var agencyId = 1;

			var result = await _ratingService.GetAverageRatingByAgencyAsync(agencyId);

			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public async Task GetAverageRatingByRouteAsync_ShouldReturnAverageRating()
		{
			// Arrange
			var routeId = 1;

			// Act
			var result = await _ratingService.GetAverageRatingByRouteAsync(routeId);

			// Assert
			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public async Task GetRatingDistributionByAgencyAsync_ShouldReturnRatingDistribution()
		{
			// Arrange
			var agencyId = 1;

			// Act
			var result = await _ratingService.GetRatingDistributionByAgencyAsync(agencyId);

			// Assert
			Assert.That(result.Count, Is.EqualTo(5));
		}

		[Test]
		public async Task GetRatingDistributionByGuideAsync_ShouldReturnRatingDistribution()
		{
			// Arrange
			var guideId = 1;

			// Act
			var result = await _ratingService.GetRatingDistributionByGuideAsync(guideId);

			// Assert
			Assert.That(result.Count, Is.EqualTo(5));
		}

		[Test]
		public async Task GetRatingDistributionByRouteAsync_ShouldReturnRatingDistribution()
		{
			// Arrange
			var routeId = 1;

			// Act
			var result = await _ratingService.GetRatingDistributionByRouteAsync(routeId);

			// Assert
			Assert.That(result.Count, Is.EqualTo(5));
		}

		[Test]
		public async Task DeleteRatings_ShouldDeleteRatingsOnMountainGuide()
		{
			// Arrange
			var id = 1;
			var entityType = "MountainGuide";

			// Act
			await _ratingService.DeleteRatings(id, entityType);

			// Assert
			var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.MountainGuideId == id);
			Assert.That(rating, Is.Null);
		}

		[Test]
		public async Task DeleteRatings_ShouldDeleteRatingsOnRoute()
		{
			// Arrange
			var id = 1;
			var entityType = "Route";

			// Act
			await _ratingService.DeleteRatings(id, entityType);

			// Assert
			var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.RouteId == id);
			Assert.That(rating, Is.Null);
		}


		[Test]
		public async Task DeleteRatings_ShouldDeleteRatingsOnTourAgency()
		{
			// Arrange
			var id = 1;
			var entityType = "TourAgency";

			// Act
			await _ratingService.DeleteRatings(id, entityType);

			// Assert
			var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.TourAgencyId == id);
			Assert.That(rating, Is.Null);
		}
	}
}
