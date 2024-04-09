using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.ArticleValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.Models.ViewModels.Article
{
    /// <summary>
    /// View model for add article
    /// </summary>
    public class ArticleAddViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(ContentMaxLength,
            MinimumLength = ContentMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = DateTimeFormat, ApplyFormatInEditMode = true)]
        [Display(Name = "Дата на публикуване")]
        public DateTime DatePublish { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Изображение свързано със статията")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public string AuthorId { get; set; } = string.Empty;
    }
}
