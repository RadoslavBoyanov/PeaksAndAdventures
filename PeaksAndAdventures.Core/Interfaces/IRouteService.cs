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
		Task<(IEnumerable<GetAllRoutesViewModel> Routes, int TotalPages)> AllRoutesPaginationAsync(int page = 1, int pageSize = 4);
		Task<bool> CheckIfExistRouteById(int routeId );
		Task<bool> CheckIfExistRouteByName(string routeName);
		Task<RouteDetailsViewModel> DetailsAsync(int routeId);
		Task<RouteDeleteViewModel> DeleteAsync(int routeId);
		Task<int> DeleteConfirmedAsync(int routeId);
		Task RateAsync(int routeId, double rating);
	}
}
