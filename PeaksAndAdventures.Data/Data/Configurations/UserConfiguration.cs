using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            ICollection<IdentityUser> users = new HashSet<IdentityUser>();

            var hasher = new PasswordHasher<IdentityUser>();

            var mountaineerUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "mountaineer@mail.com",
                NormalizedUserName = "mountaineer@mail.com",
                Email = "mountaineer@mail.com",
                NormalizedEmail = "mountaineer@mail.com"
            };
            users.Add(mountaineerUser);

            mountaineerUser.PasswordHash = hasher.HashPassword(mountaineerUser, "mountainGuide99");

            var tourAgencyUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "climbаndhike@mail.com",
                NormalizedUserName = "climbаndhike@mail.com",
                Email = "climbаndhike@mail.com",
                NormalizedEmail = "climbаndhike@mail.com"
            };
            users.Add(tourAgencyUser);

            tourAgencyUser.PasswordHash = hasher.HashPassword(tourAgencyUser, "tourAgency1");

            var tourist = new IdentityUser()
            {
                Id = "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                UserName = "tourist@mail.com",
                NormalizedUserName = "tourist@mail.com",
                Email = "tourist@mail.com",
                NormalizedEmail = "tourist@mail.com"
            };
            users.Add(tourist);

            tourist.PasswordHash = hasher.HashPassword(tourist, "tourist00");

            return users;
        }
    }
}
