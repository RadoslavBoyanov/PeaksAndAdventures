using System.ComponentModel.DataAnnotations;

namespace PeaksAndAdventures.Infrastructure.Data.Enums.Hut
{
	/// <summary>
	/// Enumeration for work time for Hut in seasons
	/// </summary>
	[Flags]
    public enum WorkTime
    {
        [Display(Name = "Не работи")]
        None = 0,
        [Display(Name = "Пролет")]
        Spring = 1,
        [Display(Name = "Лято")]
		Summer = 2,
		[Display(Name = "Есен")]
		Autumn = 4,
		[Display(Name = "Зима")]
		Winter = 8,
		[Display(Name = "Пролет и лято")]
		SpringSummer = Spring | Summer,
		[Display(Name = "Пролет и есен")]
		SpringAutumn = Spring | Autumn,
		[Display(Name = "Лято и есен")]
		SummerAutumn = Summer | Autumn,
		[Display(Name = "Пролет и зима")]
		SpringWinter = Spring | Winter,
		[Display(Name = "лято и зима")]
		SummerWinter = Summer | Winter,
		[Display(Name = "Есен и зима")]
		AutumnWinter = Autumn | Winter,

		[Display(Name = "Пролет, лято и есен")]
		SpringSummerAutumn = Spring | Summer | Autumn,
		[Display(Name = "Пролет, лято и зима")]
		SpringSummerWinter = Spring | Summer | Winter,
		[Display(Name = "Пролет, есен и зима")]
		SpringAutumnWinter = Spring | Autumn | Winter,
		[Display(Name = "Лято, есен и зима")]
		SummerAutumnWinter = Summer | Autumn | Winter,

		[Display(Name = "Всички сезони")]
		All = Spring | Summer | Autumn | Winter
    }
}
