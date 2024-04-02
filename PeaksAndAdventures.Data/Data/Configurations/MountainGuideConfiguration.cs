using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class MountainGuideConfiguration : IEntityTypeConfiguration<MountainGuide>
    {
        public void Configure(EntityTypeBuilder<MountainGuide> builder)
        {
            builder
                .HasOne(mg => mg.TourAgency)
                .WithMany(ta => ta.MountainGuides)
                .HasForeignKey(mg => mg.TourAgencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateMountainGuide());
        }

        private MountainGuide[] GenerateMountainGuide()
        {
            ICollection<MountainGuide> mountainGuides = new List<MountainGuide>();

            mountainGuides.Add(new MountainGuide()
            {
                Id = 1,
                Email = "mountaineer@mail.com",
                Experience = 7,
                FirstName = "Momchil",
                LastName = "Panayotov",
                Phone = "0895123456",
                TourAgencyId = 1,
                OwnerId = "dea12856-c198-4129-b3f3-b893d8395082",
            });

            return mountainGuides.ToArray();
        }
    }
}
