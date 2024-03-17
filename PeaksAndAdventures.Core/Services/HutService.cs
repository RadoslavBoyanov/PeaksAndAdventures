using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Hut;
using PeaksAndAdventures.Extensions;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
    public class HutService : IHutService
    {
        private readonly IRepository _repository;
        public HutService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<AllHutsViewModel>> AllAsync()
        {
            return await _repository
                .AllReadOnly<Hut>()
                .Select(h => new AllHutsViewModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Altitude = h.Altitude,
                    Description = h.Description,
                    WorkTime = h.WorkTime.GetDisplayName(),
                    HasToilet = h.HasToilet ? "да" : "не",
                    HasCanteen = h.HasCanteen ? "да" : "не",
                    HasBathroom = h.HasBathroom ? "да" : "не",
                    Camping = h.Camping.GetDisplayName(),
                    Phone = h.Phone,
                    ImageUrl = h.ImageUrl,
                    MountainId = h.MountainId,
                    MountainName = h.Mountain.Name
                })
                .ToListAsync();
        }
    }
}
