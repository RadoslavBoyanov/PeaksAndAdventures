﻿namespace PeaksAndAdventures.Core.Models.ViewModels.Article
{
    public class ArticleDeleteViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string AuthorId { get; set; } = null!;

    }
}
