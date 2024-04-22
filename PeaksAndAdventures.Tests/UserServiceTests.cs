using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Services;
using PeaksAndAdventures.Infrastructure.Data;
using PeaksAndAdventures.Infrastructure.Data.Common;

namespace PeaksAndAdventures.Tests
{
	[TestFixture]
	public class UserServiceTests
	{
		private PeaksAndAdventuresDbContext _context;

		private IRepository _repository;
		private UserService _userService;
		private UserManager<IdentityUser> _userManager;

		private IEnumerable<IdentityUser> _users;

		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<PeaksAndAdventuresDbContext>()
				.UseInMemoryDatabase(databaseName: "PeaksAndAdventuresTest" + Guid.NewGuid().ToString())
				.Options;

			_context = new PeaksAndAdventuresDbContext(options);

			_repository = new Repository(_context);
			_userService = new UserService(_repository, _userManager);

			_repository = new Repository(_context);
			_userManager = new UserManager<IdentityUser>(
								new UserStore<IdentityUser>(_context),
												null,
												null,
												null,
												null,
												null,
												null,
												null,
												null);

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
				}
			};

			_context.Users.AddRange(_users);

			_context.SaveChanges();
		}

		[TearDown]
		public async Task TearDown()
		{
			await _context.Database.EnsureDeletedAsync();
			await _context.DisposeAsync();
		}

		[Test]
		public async Task GetAllUsersAsync_ShouldReturnAllUsers()
		{
			var userService = new UserService(_repository, _userManager);

			var result = await userService.GetAllUsersAsync();

			Assert.That(result.Count(), Is.EqualTo(2));
		}

		[Test]
		public async Task GetUserId_ShouldReturnUserId()
		{
			var userService = new UserService(_repository, _userManager);

			var result = await userService.GetUserId("0d59049e-81f2-48f1-abb2-a5fd09bc210f");

			Assert.That(result.Id, Is.EqualTo("0d59049e-81f2-48f1-abb2-a5fd09bc210f"));
		}
	}
}
