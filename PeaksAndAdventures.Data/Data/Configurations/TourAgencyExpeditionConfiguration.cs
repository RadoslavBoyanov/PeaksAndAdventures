using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class TourAgencyExpeditionConfiguration : IEntityTypeConfiguration<TourAgencyExpedition>
    {
        public void Configure(EntityTypeBuilder<TourAgencyExpedition> builder)
        {

            builder
                .HasKey(tae => new
                {
                    tae.TourAgencyId, tae.ExpeditionId
                });

            builder
                .HasOne(tae => tae.Expedition)
                .WithMany(e=> e.TourAgenciesExpeditions)
                .HasForeignKey(tae => tae.ExpeditionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(tae => tae.TourAgency)
                .WithMany(ta => ta.TourAgenciesExpeditions)
                .HasForeignKey(tae => tae.TourAgencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateTourAgencyExpeditions());
        }

        private TourAgencyExpedition[] GenerateTourAgencyExpeditions()
        {
            ICollection<TourAgencyExpedition> tourAgencyExpeditions = new HashSet<TourAgencyExpedition>();

            tourAgencyExpeditions.Add(new TourAgencyExpedition()
            {
                TourAgencyId = 1,
                ExpeditionId = 1
            });

            return tourAgencyExpeditions.ToArray();
        }
    }
}
