using PeaksAndAdventures.Core.ViewModels.Route;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IRouteService
	{
		Task AddAsync(RouteAddViewModel routeForm);
		Task<IEnumerable<GetAllRoutesViewModel>> GetAllRoutesAsync();
		Task<bool> CheckIfExistRouteById(int routeId);
		Task<bool> CheckIfExistRouteByName(string routeName);
		Task<RouteDetailsViewModel> DetailsAsync(int routeId);
	}
}
