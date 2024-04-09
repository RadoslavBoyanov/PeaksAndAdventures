using PeaksAndAdventures.Core.Models.ViewModels.Expedition;

namespace PeaksAndAdventures.Core.Interfaces
{
    public interface IExpeditionService
    {
        Task AddAsync(ExpeditionAddViewModel expeditionForm);
		Task<IEnumerable<ExpeditionAllViewModel>> AllExpeditionGetAsync();
		Task<bool> CheckIfExistExpeditionByIdAsync(int expeditionId);
		Task<bool> CheckIfExistExpeditionByNameAsync(string expeditionName);
		Task<ExpeditionDetailsViewModel> DetailsAsync(int expeditionId);
		Task<ExpeditionDeleteViewModel> DeleteGetAsync(int expeditionId);
		Task<int> DeleteConfirmedAsync(int expeditionId);
		Task<ExpeditionEditViewModel> EditGetAsync(int expeditionId);
		Task<int> EditPostAsync(ExpeditionEditViewModel expeditionForm);
		Task<ExpeditionRegisterViewModel> RegisterForExpeditionAsync(string userId, int expeditionId);
		Task<ExpeditionRegisterViewModel> UnregisterFromExpeditionAsync(string userId, int expeditionId);
		Task<IEnumerable<ExpeditionAllViewModel>> UserExpeditionsAsync(string userId);
    }
}
