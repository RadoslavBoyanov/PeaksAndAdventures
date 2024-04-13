using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static PeaksAndAdventures.Common.Constants;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
	{
		public void Configure(EntityTypeBuilder<IdentityUser> builder)
		{
			builder.HasData(GenerateUsers());
		}

		private IEnumerable<IdentityUser> GenerateUsers()
		{

			var users = new List<IdentityUser>();
			var hasher = new PasswordHasher<IdentityUser>();

			var mountaineerUser = new IdentityUser
			{
				Id = "0d59049e-81f2-48f1-abb2-a5fd09bc210f",
				UserName = "climber@mail.com",
				NormalizedUserName = "CLIMBER@MAIL.COM",
				Email = "climber@mail.com",
				NormalizedEmail = "CLIMBER@MAIL.COM"
			};
			mountaineerUser.PasswordHash = hasher.HashPassword(mountaineerUser, "climb1!");
			users.Add(mountaineerUser);

			var tourAgencyUser = new IdentityUser
			{
				Id = "007b397f-9a3d-48d5-a8e4-ad00bbc43326",
				UserName = "hikers@mail.com",
				NormalizedUserName = "HIKERS@MAIL.COM",
				Email = "hikers@mail.com",
				NormalizedEmail = "HIKERS@MAIL.COM"
			};
			tourAgencyUser.PasswordHash = hasher.HashPassword(tourAgencyUser, "Hik1");
			users.Add(tourAgencyUser);

			var tourist = new IdentityUser
			{
				Id = "1e03c155-39f3-4713-897e-6dd625681add",
				UserName = "steph@mail.com",
				NormalizedUserName = "STEPH@MAIL.COM",
				Email = "steph@mail.com",
				NormalizedEmail = "STEPH@MAIL.COM"
			};
			tourist.PasswordHash = hasher.HashPassword(tourist, "Steph30");
			users.Add(tourist);

			return users;
		}
	}
}
