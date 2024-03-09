using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PeaksAndAdventures.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
