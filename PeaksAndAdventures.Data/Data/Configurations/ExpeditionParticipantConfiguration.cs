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

            builder.HasData(GenerateExpeditionParticipants());
        }

        private ExpeditionParticipant[] GenerateExpeditionParticipants()
        {
            ICollection<ExpeditionParticipant> expeditionParticipants = new HashSet<ExpeditionParticipant>();

            expeditionParticipants.Add(new ExpeditionParticipant()
            {
                ExpeditionId = 1,
                ParticipantId = "2r2410ce-d421-0fc0-03d7-m6n3hk1f591"
            });

            return expeditionParticipants.ToArray();
        }
    }
}
