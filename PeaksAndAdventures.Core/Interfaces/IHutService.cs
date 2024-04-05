﻿using PeaksAndAdventures.Core.ViewModels.Hut;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IHutService
{
    Task<IEnumerable<AllHutsViewModel>> AllAsync();
    Task AddHutToMountainAsync(AddHutViewModel hutForm);
    Task<bool> CheckHutExistsByIdAsync(int hutId);
    Task<bool> CheckHutExistsByNameAsync(string hutName);
    Task<HutDetailsViewModel> DetailsAsync(int hutId);
    Task<HutDeleteViewModel> DeleteGetAsync(int hutId);
    Task<int> DeleteConfirmedAsync(int hutId);
    Task<HutEditViewModel> EditGetAsync(int hutId);
    Task<int> EditPostAsync(HutEditViewModel hutForm);
}