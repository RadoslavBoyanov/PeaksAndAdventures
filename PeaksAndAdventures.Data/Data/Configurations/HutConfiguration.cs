using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Enums.Hut;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class HutConfiguration : IEntityTypeConfiguration<Hut>
    {
        public void Configure(EntityTypeBuilder<Hut> builder)
        {
            builder.HasData(GenerateHuts());
        }

        private Hut[] GenerateHuts()
        {
            ICollection<Hut> huts = new HashSet<Hut>();

            huts.Add(new Hut()
            {
                Id = 1,
                Name = "Безбог",
                Altitude = 2240,
                Camping = Camping.Permitted,
                WorkTime = WorkTime.All,
                Phone = "0888286102",
                HasBathroom = true,
                HasCanteen = true,
                HasToilet = true,
                Description = "Разположена е край северната част на Безбожкото езеро в Северен Пирин. Предаставлява масивна пететажна сграда с капацитет 130 места с етажни санитарни възли и бани. Хижата е електрифицирана, водоснабдена, с централно отопление. Има ресторант, кафе-аперитив, лафка.",
                Places = 130,
                ImageUrl = "https://www.tourism-bg.net/hiji/img/bezbog.jpg",
                MountainId = 3
            });

            huts.Add(new Hut()
            {
                Id = 2,
                Name = "Рилски езера",
                Altitude = 2115,
                Camping = Camping.Permitted,
                WorkTime = WorkTime.All,
                Description = "Хижа „Рилски езера“ е туристическа хижа, намираща се в Рила планина.Разположена е в близост до Седемте рилски езера, на около 2000 м надморска височина.Предлага настаняване в стаи с 2, 3, 4, 6, 7, 11 и 12 легла, като голяма част от по-малките стаи имат собствени санитарни възли. Останалите ползват тоалетни и умивалници на етажа и общи бани на някои от етажите. Хижата разполага с ресторант-столова, дневна с телевизор, бар с топли, студени и алкохолни напитки, както и сладки храни. Работи целогодишно.До хижата се достига пеш или чрез двуседалковия лифт „Рилски езера“, който тръгва от района на хижа Пионерска в Паничище.Сухият рид над хижата предлага идеални условия за каране на ски както от начинаещи (по писта), така и за екстремни ски и ски свободен стил по улеите над нея. На разположение на туристите е ски-влек тип 'паничка'.На 40 мин. път се намира по-старата хижа „Седемте езера“.",
                HasToilet = true,
                HasCanteen = true, 
                HasBathroom = true,
                Phone = "0886509409",
                ImageUrl = "https://www.btsbg.org/sites/default/files/styles/768x576/public/hiji/%D1%80%D0%B8%D0%BB%D1%81%D0%BA%D0%B8%20%D0%B5%D0%B7%D0%B5%D1%80%D0%B0%D0%B0.jpg?itok=B2mSYcnJ",
                MountainId = 2
            });

            huts.Add(new Hut()
            {
                Id = 3,
                Name = "Мазалат",
                Altitude = 1620,
                Camping = Camping.Permitted,
                WorkTime = WorkTime.All,
                Description = "Намира се на главното било в местността Мандрището, на 1523 м н.в. Построена е през 1935 година, а през 1962 година е реконструирана. Представлява двуетажна масивна сграда с капацитет 60 места с вътрешна тоалетна. Разполага с туристическа кухня и столова. Към хижата има и друга двуетажна сграда с 30 легла и вътрешна тоалетна и умивалник. Хижа „Мазалат“ се нарежда на първите места сред най-добрите хижи в България.",
                HasToilet = true,
                HasCanteen = true,
                HasBathroom = true,
                Places = 60,
                Phone = "0897475538",
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/02/MANE7681-copy-1024x683.webp",
                MountainId = 1
            });

            huts.Add(new Hut()
            {
                Id = 4,
                Name = "Синаница",
                Altitude = 2185,
                Camping = Camping.Permitted,
                WorkTime = WorkTime.Summer,
                Description = "Разположена е на северния бряг на Синанишкото езеро, в непосредствена близост до връх Синаница. Хижата представлява масивна двуетажна постройка. На първия етаж е разположена просторна столова с кухня, има складови помещения и спално помещение за домакина. На втория етаж са обособени спалните помещения за туристи, като хижата може да приюти до 50 души. През летния сезон пред хижата се открива палатков лагер.Водоснабдена е и електрифицирана от генератор. Санитарните помещения са външни. През зимния сезон в хижата няма поддържащ персонал.Хижа „Синаница“ е построена през 1975 – 1977 г. от Туристическото дружество на гара Пирин – днешния град Кресна.",
                HasToilet = true,
                HasCanteen = true,
                HasBathroom = true,
                Places = 48,
                Phone = "0894360427",
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/09/DSCF1118-819x1024.webp",
                MountainId = 3
            });

            return huts.ToArray();
        }
    }
}
