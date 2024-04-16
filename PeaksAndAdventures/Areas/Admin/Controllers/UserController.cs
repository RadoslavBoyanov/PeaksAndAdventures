using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Areas.Admin.Controllers
{
	public class UserController : BaseAdminController
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> AllUsers()
		{
			var allUsers = await _userService.GetAllUsersAsync();

			return View(allUsers);
		}
	}
}
