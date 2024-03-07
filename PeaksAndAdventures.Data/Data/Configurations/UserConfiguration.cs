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
                UserName = "Mountaineer",
                NormalizedUserName = "mountaineer",
                Email = "mountaineer@mail.com",
                NormalizedEmail = "agent@mail.com"
            };
            users.Add(mountaineerUser);

            mountaineerUser.PasswordHash = hasher.HashPassword(mountaineerUser, "mountainGuide99");

            var tourAgencyUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "ClimbAndHike",
                NormalizedUserName = "climbandhike",
                Email = "climbAndHike@mail.com",
                NormalizedEmail = "climbandhike@mail.com"
            };
            users.Add(tourAgencyUser);

            tourAgencyUser.PasswordHash = hasher.HashPassword(tourAgencyUser, "touragency1");

            var tourist = new IdentityUser()
            {
                Id = "2r2410ce-d421-0fc0-03d7-m6n3hk1f591e",
                UserName = "Tourist",
                NormalizedUserName = "tourist",
                Email = "tourist@mail.com",
                NormalizedEmail = "tourist@mail.com"
            };
            users.Add(tourist);

            return users;
        }
    }
}
