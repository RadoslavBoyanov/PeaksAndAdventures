using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PeaksAndAdventures.Common.Constants;

namespace PeaksAndAdventures.Areas.Admin.Controllers
{
	[Authorize(Roles = AdminRole)]
	[Area("Admin")]
	public abstract class BaseAdminController : Controller
	{
		
	}
}
