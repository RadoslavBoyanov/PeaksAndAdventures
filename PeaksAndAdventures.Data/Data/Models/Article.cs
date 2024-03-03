using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PeaksAndAdventures.Common.EntityValidations.ArticleValidation;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Article entity model")]
    public class Article
    {
        [Key]
        [Comment("Article id")]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        [Comment("Article title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(ContentMaxLength)]
        [Comment("Article content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Column("Date publish")]
        [Comment("Article date publish")]
        public DateTime DatePublish { get; set; }

        [Required]
        [Comment("Pictures for article")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Navigation property for author")]
        public string AuthorId { get; set; } = string.Empty;
        [Required, ForeignKey(nameof(AuthorId))]
        public IdentityUser Author { get; set; } = null!;
    }
}
