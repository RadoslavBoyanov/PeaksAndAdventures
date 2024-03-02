using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeaksAndAdventures.Infrastructure.Models
{
    [Comment("Many-to-many relationship class between tour agency and expedition")]
    public class TourAgencyExpedition
    {
        [Required]
        [Comment("Navigation property for tour agency")]
        public int TourAgencyId { get; set; }
        [ForeignKey(nameof(TourAgencyId))]
        public TourAgency TourAgency { get; set; } = null!;

        [Required]
        [Comment("Navigation property for expedition")]
        public int ExpeditionId { get; set; }
        [ForeignKey(nameof(ExpeditionId))]
        public Expedition Expedition { get; set; } = null!;
    }
}
