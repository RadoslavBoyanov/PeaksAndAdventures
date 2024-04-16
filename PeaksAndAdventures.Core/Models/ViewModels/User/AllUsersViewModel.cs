namespace PeaksAndAdventures.Core.Models.ViewModels.User
{
	public class AllUsersViewModel
	{
		public string Id { get; set; } = null!;

		public string UserName { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string UserRole { get; set; } = string.Empty;
	}
}
