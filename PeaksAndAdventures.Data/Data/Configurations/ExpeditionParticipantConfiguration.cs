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
                ExpeditionId = 5,
                ParticipantId = "1e03c155-39f3-4713-897e-6dd625681add"
			});

            return expeditionParticipants.ToArray();
        }
    }
}
