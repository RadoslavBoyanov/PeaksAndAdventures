using PeaksAndAdventures.Core.ViewModels.Route;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IRouteService
	{
		Task<IEnumerable<GetAllRoutesViewModel>> GetAllRoutesAsync();
	}
}
