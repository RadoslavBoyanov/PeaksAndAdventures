using System.ComponentModel.DataAnnotations;

namespace PeaksAndAdventures.Core.Models.ViewModels.Expedition
{
    public class ExpeditionAllViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:C}$")]
        public string Price { get; set; } = string.Empty;
    }
}
