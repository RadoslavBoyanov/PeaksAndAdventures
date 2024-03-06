using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class WaterfallConfiguration : IEntityTypeConfiguration<Waterfall>
    {
        public void Configure(EntityTypeBuilder<Waterfall> builder)
        {
            //builder.HasData(GenerateWaterfalls());
        }

        private Waterfall[] GenerateWaterfalls()
        {
            ICollection<Waterfall> waterfalls = new HashSet<Waterfall>();

            waterfalls.Add(new Waterfall()
            {
                Id = 1,
                Name = "Райското пръскало",
                Description = "Райското пръскало е най-високият постоянен водопад в България и на Балканския полуостров – 124,5 m.Намира се в Стара планина, на южния склон под най-високия старопланински връх – Ботев. На територията е на природен резерват „Джендема“, част от Национален парк „Централен Балкан“.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg/1200px-%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg",
                MountainId = 1
            });

            waterfalls.Add(new Waterfall()
            {
                Id = 2,
                Name = "Рилска скакавица",
                Description = "Водопад Рилска Скакавица е най-високият водопад в Рила (70 метра). Разположен е на 1750 метра надморска височина, а местността покрай него е много красива. Реката, която го захранва се нарича Скакавица, а преходът до него не е труден и е по добре маркирана пътека. Намира се на 10-на минути от хижа Скакавица, а за нея се тръгва от Паничище. Пътеката започва от началната станция на лифта за Седемте рилски езера и е добре обозначена с табели и маркировка. След като стигнете до хижата, следвате пътеката покрай реката, която ще ви отведе до подножието на водопада. През зимата водопадът замръзва.",
                ImageUrl = "https://bookvila.bg/img/210711093630.jpg",
                MountainId = 2
            });

            waterfalls.Add(new Waterfall()
            {
                Id = 3, 
                Name = "Видимско пръскало",
                Description = "Видимското пръскало се намира в природен резерват „Северен Джендем“, който обхваща северния склон на  връх Ботев. Представлява образувание от три отделни потока, които се събират в един. Най-близкото населено място до водопада е гр. Априлци. В бившето село Видима, което вече е част от града, се намират ВЕЦ Видима и хижа Видима. От там е и пътят, минаващ покрай Пръскалска река, по който се стига до водопада. По пътя е обособена и „Зелена класна стая”, където по достъпен игрови начин децата могат да се запознават с растенията, животните и да играят.",
                ImageUrl = "https://bookvila.bg/img/210709032337.jpg",
                MountainId = 1,
            });

            return waterfalls.ToArray();
        }
    }
}
