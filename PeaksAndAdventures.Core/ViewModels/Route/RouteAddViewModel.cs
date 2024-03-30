using System.ComponentModel.DataAnnotations;
using PeaksAndAdventures.Core.Attributes;
using PeaksAndAdventures.Core.ViewModels.Hut;
using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Core.ViewModels.Peak;
using PeaksAndAdventures.Core.ViewModels.Waterfall;
using PeaksAndAdventures.Infrastructure.Data.Enums.Route;
using static PeaksAndAdventures.Common.EntityValidations.RouteValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.ViewModels.Route
{
	public class RouteAddViewModel
	{
		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(NameMaxLength, 
			MinimumLength = NameMinLength, 
			ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Име")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(StartingPointMaxLength,
			MinimumLength = StartingPointMinLength, 
			ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Начална точка")]
		public string StartingPoint { get; set; } = string.Empty;

		[Range(DisplacementPositiveMin, DisplacementPositiveMax)]
		[Display(Name = "Положителна денивелация")]
		public double DisplacementPositive { get; set; }

		[Range(DisplacementNegativeMin, DisplacementNegativeMax)]
		[Display(Name = "Отрицателна денивелация")]
		public double DisplacementNegative { get; set; }

		[Required(ErrorMessage = RequireErrorMessage)]
		[Display(Name = "Трудност")]
		public Difficulty Difficulty { get; set; }

		[Required(ErrorMessage = RequireErrorMessage)]
		[Duration(ErrorMessage = DurationFormatIsWrong)]
		[Display(Name = "Времетраене")]
		public string Duration { get; set; } = string.Empty;

		[Display(Name = "Изображение")]
		public string? ImageUrl { get; set; }

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(DescriptionMaxLength, 
			MinimumLength = DescriptionMinLength,
			ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Описание")]
		public string Description { get; set; } = string.Empty;

		[Required]
		public int MountainId { get; set; }
		[Required]
		public IEnumerable<GetAllMountainsViewModel> Mountains { get; set; } = new List<GetAllMountainsViewModel>();

		public IEnumerable<AllLakesViewModel> Lakes { get; set; } = new List<AllLakesViewModel>();

		public IEnumerable<AllHutsViewModel> Huts { get; set; } = new List<AllHutsViewModel>();
		public IEnumerable<AllPeaksViewModel> Peaks { get; set; } = new List<AllPeaksViewModel>();

		public IEnumerable<AllWaterfallsViewModel> Waterfalls { get; set; } = new List<AllWaterfallsViewModel>();
	}
}
