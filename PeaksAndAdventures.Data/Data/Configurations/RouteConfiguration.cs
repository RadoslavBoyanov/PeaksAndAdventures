﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Enums.Route;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            //builder.HasData(GenerateRoutes());
        }

        private Route[] GenerateRoutes()
        {
            ICollection<Route> routes =  new HashSet<Route>();
            
            routes.Add(new Route()
            {
                Id = 1,
                Name = "Връх Безбог",
                Description = "Връхът може да се изкачи по два маршрута. Най-популярният е като тръгнете към “душеватката” и Попово езеро, след което се изкачите на седловината между върховете Полежан и Безбог (вторият етап на прехода, който сме описали тук, но в обратна посока). Маршрутът тръгва покрай десния бряг Безбожкото езеро, където вдясно ще видите изоставена постройка. Това са руините на старата хижа „Безбог“, която е разрушена от лавина през 1971 година. Пътеката към върха минава вляво на постройката. По тази пътека няма маркировка, но „пирамидките“ от камъни могат да ви водят.Поглед към връх Безбог в Пирин.Пътеката е доста стръмна и през по- голямата част е през клекове. Малко преди върха започва каменист участък, който също е стръмен. Внимавайте къде стъпвате между камъните.На самия връх има кръст и веднага ще го познаете щом го видите.Гледката оттук е много красива: на Изток част от Кременското езеро, до него върховете Севрия, Джано, Джангал както и част от Поповото езеро. В другата посока се виждат връх Полежан, Стражите и Десилица.",
                StartingPoint = "Хижа Безбог",
                Difficulty = Difficulty.Moderate,
                DisplacementPositive = 450,
                DisplacementNegative = 450,
                Duration = new TimeSpan(0, 2, 40, 00),
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/09/DSCF5440-1024x819.webp",
                MountainId = 3
            });

            routes.Add(new Route()
            {
                Id = 2,
                Name = "Връх Мусала – най-високият връх в България и на Балканите",
                Description = "Хижа „Ястребец“ – хижа „Мусала“\r\nОт лифта тръгнете по главната пътека към хижата. Пътеката е почти равна и широка. Най-вероятно ще видите много хора и трудно бихте се объркали. Маршрута до хижата отнема около час, а маркировката, която трябва да следвате е червена. Повече информация може да прочетете в статията ни за хижа „Мусала.\r\n\r\nВръх Иречек вляво и връх Мусала вдясно, отпред Мусаленското езеро\r\nХижа „Мусала“ – Ледено езеро\r\nСлед като стигнете хижа „Мусала“ ви остават около 2 часа преход до върха. До хижата се намират първите три езера от езерната група Мусаленски езера. Тръгнете по дясната страна на езерото пред хижа „Мусала“. От тук започва постепенно изкачване, пътеката става все по-камениста и все по-често се върви по морени. По пътеката ще минете покрай две езера, първото от които е Алековото езеро. След около 30-35 минути ще достигнете до Леденото езеро.\r\n\r\n\r\nЛедено езеро – връх Мусала\r\nСега е моментът да си отдъхнете преди последното изкачване. То е най-трудно и изморително заради голямата денивелация. Тук е и единствената чешма по пътя.\r\n\r\n\r\n\r\nИма две пътеки – лятна и зимна. Зимната е камениста и стръмна, но има обезопасително метално въже.\r\n\r\n\r\nЗа по-неопитните туристи е препоръчително да изберат лятната пътека. След около половин час нагоре ще стигнете най-високата точка на България.\r\n\r\nГледка от връх Мусала към Леденото езеро\r\n\r\nПред вас ще се открие уникална гледка към върхове и езера. На юг са Маричините езера, на север – Ледено езеро и местността, от която дойдохте, на изток – върховете Малка Мусала (2902 м) и Иречек (2852 м). При ясно време можете да видите в далечината на запад връх Мальовица.",
                Difficulty = Difficulty.Moderate,
                DisplacementNegative = 104,
                DisplacementPositive = 684,
                Duration = new TimeSpan(0, 6, 00, 00),
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/09/DSC6986-1024x680.webp",
                MountainId = 2
            });

            routes.Add(new Route()
            {
                Id = 3,
                Name = "Хижа „Мазалат“ – уют и красиви гледки в Стара планина",
                Description =
                    "Хижа „Партизанска Песен“ – чешма\r\nПътеката започва от хижа „Партизанска песен“, като първите 30 минути се върви в прохладна гора. Маршрутът до хижата е част от Е3, по-известен като Ком-Емине, и е добре маркиран (следвайте Пътеката започва от хижа „Партизанска песен“, като първите 30 минути се върви в прохладна гора. Маршрутът до хижата е част от Е3, по-известен като „Ком-Емине“, и е добре маркиран (следвайте червената маркировка). Пътеката ясно се вижда и трудно бихте могли да се изгубите. След приятната горичка лека по-лека наклона става по-голям и излизате на открит участък, от където в далечината се виждат върховете Бузлуджа и Шипка, както и няколко вятърни турбини. Има едно местенце с голямо дърво и пейки, където можете да направите кратка почивка. Не след дълго се излиза на чешмичката, тя е над пътеката и трябва да внимавате да не я пропуснете. Отдъхнете и напълнете вода, защото е единствената по пътя.\r\n\r\n\r\n\r\n\r\nЧешма – хижа „Мазалат“\r\nОт чешмичката поемете нагоре и надясно по баира. Тук е най-голямото изкачване от маршрута. Тази част се минава трудно, защото през лятото е пълно с боровинки, на които не бихте устояли. След като изкачите възвишението пътеката става почти равна и навлиза в букова гора. Не забравяйте да вдигате достатъчно шум, за да избегнете среща с дивите животни и най-вече с мечките. Пътеката е много приятна и живописна. Скоро след като излезете от гората ще стигнете табела на Национален парк, от там пътят става широк и открит. Това е последната част от маршрута. До хижата остават около 20-30 минути. В хижата можете да хапнете, починете и да се насладите на гледките към масива Триглав. Ако имате достатъчно време, може да се разходите до връх Вълча глава (30 минути), скален феномен Пеещите скали (55 минути) или да направите маршрута до връх Голям Кадемлия.",
                Difficulty = Difficulty.Moderate,
                DisplacementNegative = 151,
                DisplacementPositive = 498,
                Duration = new TimeSpan(0, 6, 0, 0),
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/02/MANE7558-copy-1024x683.webp",
                MountainId = 1
            });

            return routes.ToArray();
        }
    }
}
