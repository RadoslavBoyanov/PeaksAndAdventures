using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class ExpeditionParticipantConfiguration : IEntityTypeConfiguration<ExpeditionParticipant>
    {
        public void Configure(EntityTypeBuilder<ExpeditionParticipant> builder)
        {
            builder
                .HasKey(ep => new
                {
                    ep.ExpeditionId, ep.ParticipantId
                });
        }
    }
}
