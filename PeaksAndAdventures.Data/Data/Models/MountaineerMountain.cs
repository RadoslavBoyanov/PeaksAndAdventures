using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Many-to-many relationship table between mountain guide and mountain")]
    public class MountaineerMountain
    {
        [Required]
        [Comment("Navigation property for mountain guide")]
        public int MountainGuideId { get; set; }
        [ForeignKey(nameof(MountainGuideId))]
        public MountainGuide MountainGuide { get; set; } = null!;

        [Required]
        [Comment("Navigation property for mountain")]
        public int MountainId { get; set; }
        [ForeignKey(nameof(MountainId))]
        public Mountain Mountain { get; set; } = null!;
    }
}
