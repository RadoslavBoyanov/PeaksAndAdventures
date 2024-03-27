﻿using PeaksAndAdventures.Core.ViewModels.Article;
using PeaksAndAdventures.Core.ViewModels.Expedition;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IExpeditionService
    {
        Task AddAsync(ExpeditionAddViewModel expeditionForm);
		Task<IEnumerable<ExpeditionAllViewModel>> AllExpeditionGetAsync();
		Task<bool> CheckIfExistExpeditionByIdAsync(int expeditionId);
		Task<bool> CheckIfExistExpeditionByNameAsync(string expeditionName);
		Task<ExpeditionDetailsViewModel> DetailsAsync(int expeditionId);
		Task<ExpeditionEditViewModel> EditGetAsync(int expeditionId);
		Task<int> EditPostAsync(ExpeditionEditViewModel expeditionForm);
	}
}
