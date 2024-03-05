using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class TourAgencyConfiguration : IEntityTypeConfiguration<TourAgency>

    {
        public void Configure(EntityTypeBuilder<TourAgency> builder)
        {
            //builder.HasData(GenerateTourAgencies());
        }

        private TourAgency[] GenerateTourAgencies()
        {
            ICollection<TourAgency> tourAgencies = new HashSet<TourAgency>();

            return tourAgencies.ToArray();
        }
    }
}
