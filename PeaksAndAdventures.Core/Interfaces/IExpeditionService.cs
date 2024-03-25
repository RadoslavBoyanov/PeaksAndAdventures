using PeaksAndAdventures.Core.ViewModels.Expedition;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IExpeditionService
	{
		Task<IEnumerable<ExpeditionAllViewModel>> AllExpeditionGetAsync();
		Task<ExpeditionDetailsViewModel> DetailsAsync(int expeditionId);
	}
}
