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
                Id = 8,
                Email = "climber@mail.com",
                Experience = 7,
                FirstName = "Илия",
                LastName = "Петканов",
                Phone = "0895123456",
                TourAgencyId = 4,
                OwnerId = "0d59049e-81f2-48f1-abb2-a5fd09bc210f",
            });

            return mountainGuides.ToArray();
        }
    }
}
