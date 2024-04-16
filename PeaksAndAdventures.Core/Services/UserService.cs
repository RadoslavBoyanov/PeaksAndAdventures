using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.User;
using PeaksAndAdventures.Infrastructure.Data.Common;

namespace PeaksAndAdventures.Core.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository _repository;
		private readonly UserManager<IdentityUser> _userManager;

		public UserService(
			IRepository repository,
			UserManager<IdentityUser> userManager)
		{
			_repository = repository;
			_userManager = userManager;
		}


		public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
		{
			var users = await _repository.AllReadOnly<IdentityUser>()
				.ToListAsync();

			var tasks = users.Select(async u => new AllUsersViewModel
			{
				Id = u.Id,
				UserName = u.UserName,
				Email = u.Email
			});

			var result = await Task.WhenAll(tasks);
			return result;
		}


	}
}
