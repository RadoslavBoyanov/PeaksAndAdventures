using PeaksAndAdventures.Core.ViewModels.Route;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IRouteService
	{
		Task AddAsync(RouteAddViewModel routeForm, 
			List<int> selectedPeaksIds,
			List<int> selectedHutsIds,
			List<int> selectedLakesIds,
			List<int> selectedWaterfallsIds);

		Task<RouteEditViewModel> EditGetAsync(int routeId);
		Task<int> EditPostAsync(RouteEditViewModel routeForm, 
						List<int> selectedPeaksIds,
						List<int> selectedHutsIds,
						List<int> selectedLakesIds,
						List<int> selectedWaterfallsIds);
		Task<IEnumerable<GetAllRoutesViewModel>> GetAllRoutesAsync();
		Task<bool> CheckIfExistRouteById(int routeId );
		Task<bool> CheckIfExistRouteByName(string routeName);
		Task<RouteDetailsViewModel> DetailsAsync(int routeId);
	}
}
