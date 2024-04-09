using PeaksAndAdventures.Core.Models.ViewModels.Route;
using PeaksAndAdventures.Core.Models.ViewModels.TourAgency;
using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.ExpeditionValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.Models.ViewModels.Expedition
{
    public class ExpeditionAddViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Свободни места")]
        public int Enrolment { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = DateTimeFormat,
            ApplyFormatInEditMode = true)]
        [Display(Name = "Начало на експедицията")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = DateTimeFormat,
            ApplyFormatInEditMode = true)]
        [Display(Name = "Край на експедицията")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(DaysMin, DaysMax)]
        [Display(Name = "Дни")]
        public int Days { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(ProgramMaxLength,
            MinimumLength = ProgramMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Програма")]
        public string Program { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [DisplayFormat(DataFormatString = "{0:C}$")]
        [Range(PriceMin, PriceMax)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(IncludesMaxLength,
            MinimumLength = IncludesMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Какво е включено в цената")]
        public string Includes { get; set; } = string.Empty;

        [Required]
        [StringLength(ExcludesMaxLength)]
        [Display(Name = "Какво не е включено в цената")]
        public string Excludes { get; set; } = string.Empty;


        [StringLength(ExcludesMaxLength,
            MinimumLength = ExcludesMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Допълнителни услуги срещу заплащане")]
        public string? Extras { get; set; }

        [Required]
        public string OrganiserId { get; set; } = string.Empty;

        [Required]
        public int TourAgencyId { get; set; }

        [Required]
        public int RouteId { get; set; }

        public IEnumerable<GetAllRoutesViewModel> Routes { get; set; } = new List<GetAllRoutesViewModel>();
        public IEnumerable<TourAgencyGetViewModel> TourAgencies { get; set; } = new List<TourAgencyGetViewModel>();
    }
}
