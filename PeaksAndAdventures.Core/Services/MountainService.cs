using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{

    public class MountainService : IMountainService
    {
        private readonly IRepository _repository;

        public MountainService(IRepository repository)
        {
            _repository = repository;
        }
         public async Task<IEnumerable<AllMountainsViewModel>> AllAsync()
         {
             return await _repository
                 .AllReadOnly<Mountain>()
                 .Select(m => new AllMountainsViewModel()
                 {
                     Id = m.Id,
                     Name = m.Name,
                     Location = m.Location,
                     Climate = m.Climate,
                     Waters = m.Waters,
                     Fauna = m.Fauna,
                     Flora = m.Flora,
                     ImageUrls = m.ImageUrls
                 })
                 .ToListAsync();
         }
    }
}
