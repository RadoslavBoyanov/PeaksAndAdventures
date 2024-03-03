using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Many-to-many relationship class between expedition and participant")]
    public class ExpeditionParticipant
    {
        [Required]
        [Comment("Navigation property for expedition")]
        public int ExpeditionId { get; set; }
        [ForeignKey(nameof(ExpeditionId))]
        public Expedition Expedition { get; set; } = null!;

        [Required]
        [Comment("Navigation property for participant")]
        public string ParticipantId { get; set; } = string.Empty;
        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser Participant { get; set; } = null!;
    }
}
