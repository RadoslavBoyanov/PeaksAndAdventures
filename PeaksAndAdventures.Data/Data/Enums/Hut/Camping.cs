using System.ComponentModel.DataAnnotations;

namespace PeaksAndAdventures.Infrastructure.Data.Enums.Hut
{
    /// <summary>
    /// Enumeration for camping
    /// </summary>
    public enum Camping
    {
        [Display(Name = "Разрешено")]
        Permitted = 0,
        [Display(Name = "Забранено")]
        NotAllowed = 1,
        [Display(Name = "Позволено на определени места")]
        AllowedInCertainLocations = 2
    }
}
