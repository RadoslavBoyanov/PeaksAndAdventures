using System.ComponentModel.DataAnnotations;
using PeaksAndAdventures.Infrastructure.Data.Enums.Hut;

namespace PeaksAndAdventures.Core.Models.QueryModels.Hut
{
    public class AllHutsQueryModel
    {
        public const int HutsPerPage = 3;

        public int CurrentPage { get; init; } = 1;

        [Display(Name = "Работно време")] 
        public WorkTime WorkTime { get; init; } 

        [Display(Name = "Къмпинг")]
        public Camping Camping { get; init; }

        [Display(Name = "Търсене по име на хижа")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Търсене по планина")]
        public string MountainName { get; set; } = null!;

        public int Places { get; set; }

        public int TotalHutsCount { get; set; }

        public IEnumerable<HutServiceModel> Huts { get; set; } = new List<HutServiceModel>();

    }
}
