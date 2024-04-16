using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeaksAndAdventures.Core.Models.ViewModels.User;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
	}
}
