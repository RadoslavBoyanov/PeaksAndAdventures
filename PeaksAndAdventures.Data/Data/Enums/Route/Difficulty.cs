using System.ComponentModel.DataAnnotations;

namespace PeaksAndAdventures.Infrastructure.Data.Enums.Route
{
    /// <summary>
    /// Enumeration for difficulty on one route
    /// </summary>
    public enum Difficulty
    {
        [Display(Name = "Лесен")]
        Easy = 1 | 2,
        [Display(Name = "Среден")]
        Moderate = 3 | 4,
        [Display(Name = "Труден")]
        Difficult = 5 | 6
    }
}
