namespace PeaksAndAdventures.Core.ViewModels.Article
{
	public class ArticleDetailsViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public string DatePublish { get; set; }
		public string ImageUrl { get; set; } = string.Empty;
		public string AuthorId { get; set; } = string.Empty;
	}
}
