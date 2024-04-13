using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class TourAgencyConfiguration : IEntityTypeConfiguration<TourAgency>

    {
        public void Configure(EntityTypeBuilder<TourAgency> builder)
        {

            builder.HasMany(ta => ta.MountainGuides)
                .WithOne(mg => mg.TourAgency)
                .HasForeignKey(mg => mg.TourAgencyId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasData(GenerateTourAgencies());
        }

        private TourAgency[] GenerateTourAgencies()
        {
            ICollection<TourAgency> tourAgencies = new HashSet<TourAgency>();

            tourAgencies.Add(new TourAgency()
            {
                Id = 4,
                Name = "Hikers",
                Description = "Hikers е изключително престижна туристическа агенция, посветена на страстта и приключението в света на планинарството. С богат опит в организацията на експедиции и планинарски турове, тази агенция съчетава страстта към природата със знание и професионализъм.\r\nНашата мисия е да предоставяме неповторими и вълнуващи преживявания за всички любители на приключенските спортове и обичатели на природата. Специализирани в организирането на експедиции в различни части на света, ние съчетаваме уникални маршрути, експертни водачи и безопасност на високо ниво, за да осигурим незабравими преживявания на върховете на света.\r\n\r\nНашите експедиции включват разнообразни дестинации - от високите върхове на Хималаите, през загадъчните планини в Южна Америка, до непокорените върхове в Африка и още много други. Съчетаваме екстремни предизвикателства с красивите природни пейзажи, за да създадем едно неповторимо приключение.\r\n\r\nНашите професионални гидове и инструктори са подготвени да водят клиентите ни през всеки етап от техния планинарски път. Разполагаме с модерно оборудване и осигуряваме пълна подкрепа за участниците в нашите турове, гарантирайки тяхната безопасност и комфорт.\r\nClimb and Hiking не предлага просто пътувания; предлагаме възможността за откриване на света от високо и по нов, невиждан начин. За нас, планинарството е не просто хоби, а начин на живот, който искаме да споделим с всички, които търсят истинско предизвикателство и незабравими преживявания в планината. Приключили сте да се катерите – започнете да живеете!",
                Email = "hikers@mail.com",
                Phone = "0899001166",
                OwnerId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326"
			});

            return tourAgencies.ToArray();
        }
    }
}
