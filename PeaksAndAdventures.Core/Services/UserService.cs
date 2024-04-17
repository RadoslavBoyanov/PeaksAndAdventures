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

		public async Task<string> GetRoleOfUser(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				throw new InvalidOperationException("User not found");
			}

			var roles = await _userManager.GetRolesAsync(user);
			return roles.FirstOrDefault();
		}

		public async Task<IdentityUser> GetUserId(string userId)
		{
			return await _repository.GetByIdAsync<IdentityUser>(userId);
		}
	}
}
