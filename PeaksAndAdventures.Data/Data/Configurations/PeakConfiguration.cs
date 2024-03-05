using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class PeakConfiguration : IEntityTypeConfiguration<Peak>
    {
        public void Configure(EntityTypeBuilder<Peak> builder)
        {
            //builder.HasData(GeneratePeaks());
        }

        private Peak[] GeneratePeaks()
        {
            ICollection<Peak> peaks = new HashSet<Peak>();

            return peaks.ToArray();
        }
    }
}
