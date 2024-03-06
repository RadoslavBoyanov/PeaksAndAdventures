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

            peaks.Add(new Peak()
            {
                Id = 1,
                Name = "Ботев",
                Altitude = 2376,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, И от заслон Ботев",
                Description = "Връх Ботев е най-високият връх в Стара планина и с неговите 2375,9 м тя нарежда планината на 3-то място по височина в България, след Рила (връх Мусала – 2925 м) и Пирин (връх Вихрен – 2914 м). Намира се в Средна Стара планина, в Национален парк „Централен Балкан“. Разположението му в сърцето на страната и множеството туристически маршрути, които го опасват, го правят привлекателен за множество планинари. В подножието му се намира и най-високия водопад на Балканския полуостров – Райското пръскало. Той е основна атракция в местността със своите 124,5 м, което допълнително популяризира връх Ботев.",
                ImageUrl = "https://izbulgaria.com/wp-content/uploads/2021/07/gledka-kam-vrah-botev-1024x768.jpg",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 2,
                Name = "Малък Юмрукчал",
                Altitude = 2340,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, С от вр.Ботев",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 3,
                Name = "Голям Кадемлия",
                Altitude = 2275,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, СИ от хижа Триглав",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 4,
                Name = "Млечния чал",
                Altitude = 2255,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, И от вр.Жълтец",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 5,
                Name = "Жълтец",
                Altitude = 2227,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина,И от вр.Костенурката",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 6,
                Name = "Малък Кадемлия",
                Altitude = 2226,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина,СИ от вр.Голям Кадемлия",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 7,
                Name = "Параджика",
                Altitude = 2209,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, ЮИ от заслон Маринка",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 8,
                Name = "Вежен",
                Altitude = 2198,
                Partition = "Средна Стара планина",
                SpecificLocation = "Златишко-Тетевенска планина, Ю от хижа Вежен",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 9,
                Name = "Мазалат (Зли връх)",
                Altitude = 2197,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, ЮИ от вр.Пиргос",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 10,
                Name = "Пиргос",
                Altitude = 2195,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, И от вр.Голям Кадемлия",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 11,
                Name = "Миджур",
                Altitude = 2169,
                Partition = "Западна Стара планина",
                SpecificLocation = "Чипровска планина, ЮЗ от хижа Миджур",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 12,
                Name = "Купена",
                Altitude = 2169,
                Partition = "Средна Стара планина",
                SpecificLocation = "Троянска планина, СЗ от хижа Васил Левски",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 13,
                Name = "Левски (Амбарица)",
                Altitude = 2166,
                Partition = "Средна Стара планина",
                SpecificLocation = "Троянска планина, СИ от хижа Добрила",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 14,
                Name = "Малка Амбарица",
                Altitude = 2143,
                Partition = "Средна Стара планина",
                SpecificLocation = "Троянска планина, СИ от вр.Левски",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 15,
                Name = "Юрушка грамада",
                Altitude = 2136,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, СИ от вр.Параджика",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 16,
                Name = "Ушите",
                Altitude = 2115,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, СЗ от вр.Параджика",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 17,
                Name = "Каменица",
                Altitude = 2104,
                Partition = "Средна Стара планина",
                SpecificLocation = "Златишко-Тетевенска планина, И от вр.Вежен",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 18,
                Name = "Малък купен",
                Altitude = 2101,
                Partition = "Средна Стара планина",
                SpecificLocation = "Троянска планина, З от вр.Купена",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 19,
                Name = "Побита глава",
                Altitude = 2075,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина, Ю от заслон Ботев",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 20,
                Name = "Тетевенска баба",
                Altitude = 2070,
                Partition = "Средна Стара планина",
                SpecificLocation = "Златишко-Тетевенска планина, С от с.Антон",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 21,
                Name = "Булуваня",
                Altitude = 2043,
                Partition = "Средна Стара планина",
                SpecificLocation = "Златишко-Тетевенска планина,СИ от с.Антон",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 22,
                Name = "Голям Кръстец",
                Altitude = 2035,
                Partition = "Средна Стара планина",
                SpecificLocation = "Троянска планина, СИ от вр.Купена",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 23,
                Name = "Костенурката",
                Altitude = 2035,
                Partition = "Средна Стара планина",
                SpecificLocation = "Троянска планина, С от хижа Васил Левски",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 24,
                Name = "Обов връх",
                Altitude = 2033,
                Partition = "Западна Стара планина",
                SpecificLocation = "Чипровска планина, З от хижа Миджур",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 25,
                Name = "Картала",
                Altitude = 2031,
                Partition = "Средна Стара планина",
                SpecificLocation = "Златишко-Тетевенска планина, СИ от вр.Паскал",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 26,
                Name = "Паскал",
                Altitude = 2029,
                Partition = "Средна Стара планина",
                SpecificLocation = "Златишко-Тетевенска планина, СИ от хижа Паскал",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 27,
                Name = "Ком",
                Altitude = 2016,
                Partition = "Западна Стара планина",
                SpecificLocation = "Берковска планина, ЮЗ от хижа Ком",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 28,
                Name = "Мартинова чука",
                Altitude = 2011,
                Partition = "Западна Стара планина",
                SpecificLocation = "Чипровска планина, ЮЗ от заслон Мартиница",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 29,
                Name = "Косица",
                Altitude = 2001,
                Partition = "Средна Стара планина",
                SpecificLocation = "Златишко-Тетевенска планина, С от хижа Паскал",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 30,
                Name = "Падитът",
                Altitude = 2001,
                Partition = "Средна Стара планина",
                SpecificLocation = "Калоферска планина,Ю от вр.Пиргос",
                MountainId = 1
            });

            peaks.Add(new Peak()
            {
                Id = 31,
                Name = "Мусала",
                Altitude = 2925,
                Partition = "Източна Рила",
                Description = "Мусала е първенецът на Рила и най-високият планински връх в България и на целия Балкански полуостров. Надморската му височина е 2925,4 m, измерена от равнището на пристанище Варна. По-висок е с 8 m от следващия по височина връх на Балканите, Митикас в планината Олимп в Гърция, и с 11 m от първенеца на Пирин, връх Вихрен, който заема третото място в класацията. Мусала има относителна надморска височина от 2473 m, което го подрежда на 7-о място в Европа.",
                ImageUrl = "https://svetogled.com/wp-content/uploads/2021/08/DSC_0050_1.jpg",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 32,
                Name = "Малка Мусала",
                Altitude = 2902,
                Partition = "Източна Рила",
                SpecificLocation = "И от вр.Мусала",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 33,
                Name = "Иречек",
                Altitude = 2852,
                Partition = "Източна Рила",
                SpecificLocation = "С от вр.Малка Мусала",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 34,
                Name = "Безименния връх",
                Altitude = 2792,
                Partition = "Източна Рила",
                SpecificLocation = "С от вр.Мусала",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 35,
                Name = "Дено",
                Altitude = 2790,
                Partition = "Източна Рила",
                SpecificLocation = "И от хижа Мусала",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 36,
                Name = "Голям Близнак",
                Altitude = 2779,
                Partition = "Източна Рила",
                SpecificLocation = "З от Маричини езера",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 37,
                Name = "Малък Близнак",
                Altitude = 2777,
                Partition = "Източна Рила",
                SpecificLocation = "Ю от вр.Мусала",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 38,
                Name = "Манчо",
                Altitude = 2773,
                Partition = "Източна Рила",
                SpecificLocation = "И от Маричини езера",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 39,
                Name = "Юрушки чал",
                Altitude = 2769,
                Partition = "Източна Рила",
                SpecificLocation = "С от хижа Грънчар",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 40,
                Name = "Песоклива вапа",
                Altitude = 2769,
                Partition = "Източна Рила",
                SpecificLocation = "И от вр.Юрушки чал",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 41,
                Name = "Маришки чал",
                Altitude = 2765,
                Partition = "Източна Рила",
                SpecificLocation = "Ю от Маричини езера",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 42,
                Name = "Студения чал",
                Altitude = 2760,
                Partition = "Източна Рила",
                SpecificLocation = "СИ от вр.Малка Мусала",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 43,
                Name = "Голям Купен",
                Altitude = 2731,
                Partition = "Северозападна Рила",
                SpecificLocation = "Ю от заслон Страшното езеро",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 44,
                Name = "Мальовица",
                Altitude = 2729,
                Partition = "Северозападна Рила",
                SpecificLocation = "СЗ от Еленино езеро",
                Description = "Мальовица е името на връх в северозападната част на планина Рила, висок 2729 m. Името на върха е свързано с Мальо войвода – борец срещу поробителите, загинал според преданието нейде в Мальовишката долина. Друго предположение е, че името произлиза от Малите езера, както планинците наричат езерата в североизточното подножие на върха.[1] На най-старите карти върхът е отбелязан с името Малевица. По труднодостъпните северни и източни склонове на връх Мальовица се намират едни от най-посещаваните от алпинисти скални стени в България. Северната отвесна стена на Мальовица е висока 124 метра и е символ в българския алпинизъм.",
                ImageUrl = "https://www.standartnews.com/media/1/2023/10/14/388220/960x540.jpg?timer=1697268969",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 45,
                Name = "Черна поляна",
                Altitude = 2716,
                Partition = "Средна Рила",
                SpecificLocation = "Ю от Павлев връх",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 46,
                Name = "Алеко",
                Altitude = 2713,
                Partition = "Източна Рила",
                SpecificLocation = "ЮЗ от хижа Мусала",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 47,
                Name = "Рилец",
                Altitude = 2713,
                Partition = "Средна Рила",
                SpecificLocation = "ЮЗ от Смрадливото езеро",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 48,
                Name = "Голям Скакавец",
                Altitude = 2706,
                Partition = "Средна Рила",
                SpecificLocation = "З от вр.Мусала",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 49,
                Name = "Голяма Попова капа",
                Altitude = 2704,
                Partition = "Северозападна Рила",
                SpecificLocation = "ЮИ от заслон Страшното езеро",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 50,
                Name = "Лопушки връх",
                Altitude = 2698,
                Partition = "Северозападна Рила",
                SpecificLocation = "СЗ от заслон Кобилино бранище",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 51,
                Name = "Йосифица",
                Altitude = 2697,
                Partition = "Средна Рила",
                SpecificLocation = "СИ от хижа Рибни езера",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 52,
                Name = "Отовишки връх",
                Altitude = 2696,
                Partition = "Северозападна Рила",
                SpecificLocation = "СИ от хижа Иван Вазов",
                MountainId = 2,
            });

            peaks.Add(new Peak()
            {
                Id = 53,
                Name = "Отовишки връх",
                Altitude = 2696,
                Partition = "Северозападна Рила",
                SpecificLocation = "СИ от хижа Иван Вазов",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 54,
                Name = "Ловница",
                Altitude = 2695,
                Partition = "Северозападна Рила",
                SpecificLocation = "И от заслон БАК",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 55,
                Name = "Канарата",
                Altitude = 2691,
                Partition = "Средна Рила",
                SpecificLocation = "Ю от хижа Рибни езера",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 56,
                Name = "Погледец",
                Altitude = 2691,
                Partition = "Средна Рила",
                SpecificLocation = "СЗ от Халовитото езеро",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 57,
                Name = "Орловец",
                Altitude = 2686,
                Partition = "Северозападна Рила",
                SpecificLocation = "ЮЗ от заслон БАК",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 58,
                Name = "Аладжа Слап",
                Altitude = 2683,
                Partition = "Средна Рила",
                SpecificLocation = "СИ от седловина Кадиин гроб",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 59,
                Name = "Водни чал",
                Altitude = 2683,
                Partition = "Средна Рила",
                SpecificLocation = "Ю от заслон Кобилино бранище",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 60,
                Name = "Реджепица",
                Altitude = 2678,
                Partition = "Средна Рила",
                SpecificLocation = "Ю от вр.Канарата",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 61,
                Name = "Злия зъб",
                Altitude = 2678,
                Partition = "Северозападна Рила",
                SpecificLocation = "ЮИ от заслон БАК",
                MountainId = 2
            });

            peaks.Add(new Peak()
            {
                Id = 62,
                Name = "Вихрен",
                Altitude = 2914,
                Partition = "Северен Пирин",
                Description = "Вѝхрен (до 29 юни 1942 г. Елтепе, Ел-тепе) е най-високият връх на Пирин. Със своите 2914 метра Вихрен е втори по височина в България след Мусала (2925,4) в Рила и трети на Балканския полуостров след Митикас (2917,727[3]) в Олимп. Гледан от Банско Вихрен прилича на пресечена пирамида, а от юг – на четиристенна пирамида. За този връх е характерно, че изглежда по много различен начин от различните посоки. Скалите, които изграждат Вихрен, са мрамори, които не задържат вода, поради което в целия район на върха няма реки и езера. Най-близките езера са Влахините на югозапад. Растителността по склоновете на Вихрен е бедна – трева и лишеи, докато животинският свят е по-богат – има птици, дребни гризачи, но най-вече диви кози, които обитават Казаните в подножието на върха. Цветето еделвайс се среща в изобилие по скалния ръб Джамджиеви скали.",
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/07/MANE2800a.jpg",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 63,


                Name = "Кутело",
                Altitude = 2908,
                Partition = "Северен Пирин",
                SpecificLocation = "С от вр.Вихрен",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 64,
                Name = "Бански суходол",
                Altitude = 2886,
                Partition = "Северен Пирин",
                SpecificLocation = "СЗ от вр.Кутело",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 65,
                Name = "Полежан",
                Altitude = 2852,
                Partition = "Северен Пирин",
                SpecificLocation = "СИ ог Горно Полежанско езеро",
                Description = "Полежан (до 29 юни 1942 г. Мангър тепе, Мангър-тепе) е най-високият гранитен връх (карлинг) в Пирин и четвърти по височина след мраморните първенци Вихрен, Кутело и Бански суходол. Висок е 2850,4 m. Той е първенецът на Полежанското странично било, където се намират още Малък Полежан (2820 m), Газей, Безбог, Каймакчал и Дисилица, както и внушителният ръб Стражите. Старото му име, преди да бъде преименуван през 1942 г., е Мангър тепе, което идва от турската дума мангър, тоест монета. Това е така, защото върхът е покрит с каменни плочи, които подобно на монети се клатят и тракат, когато се върви по тях. Най-близката хижа е Безбог на около 2 ч. път. От Полежан от Полежанското било се отделят две малки странични била – Безбожкото с връх Безбог, което се спуска към Места, и Газейското с връх Газей, което се спуска към долината на Демяница и образува стръмна странична долина, по която върви пътека. Около Полежан се намират двете най-високи езера в Пирин – Горното Полежанско (2710 м), което е най-високо и в България, и Горното Газейско, което е на второ място в Пирин (2642 м). Те обаче не се намират в Полежанския циркус, който отстои на север.",
                ImageUrl = "https://luckybansko.bg/wp-content/uploads/2020/08/2020-08-18_15h03_22.png",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 66,
                Name = "Каменица",
                Altitude = 2824,
                Partition = "Северен Пирин",
                SpecificLocation = "ЮИ от заслон Тевно езеро",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 67,
                Name = "Малък Полежан",
                Altitude = 2823,
                Partition = "Северен Пирин",
                SpecificLocation = "ЮЗ от вр.Полежан",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 68,
                Name = "Байови дупки",
                Altitude = 2821,
                Partition = "Северен Пирин",
                SpecificLocation = "СЗ от вр.Бански суходол",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 69,
                Name = "Голяма Стража",
                Altitude = 2799,
                Partition = "Северен Пирин",
                SpecificLocation = "ЮИ от хижа Демяница",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 70,
                Name = "Яловарника",
                Altitude = 2765,
                Partition = "Северен Пирин",
                SpecificLocation = "Ю от вр.Каменица",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 71,
                Name = "Газей",
                Altitude = 2756,
                Partition = "Северен Пирин",
                SpecificLocation = "СЗ от вр.Малък Полежан",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 72,
                Name = "Каймакчал",
                Altitude = 2754,
                Partition = "Северен Пирин",
                SpecificLocation = "И от хижа Демяница",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 73,
                Name = "Тодорин връх",
                Altitude = 2746,
                Partition = "Северен Пирин",
                SpecificLocation = "ЮИ от хижа Вихрен",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 74,
                Name = "Бъндеришки чукар",
                Altitude = 2738,
                Partition = "Северен Пирин",
                SpecificLocation = "Ю от хижа Вихрен",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 75,
                Name = "Дженгал",
                Altitude = 2729,
                Partition = "Северен Пирин",
                SpecificLocation = "З от Попово езеро",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 76,
                Name = "Разложки суходол",
                Altitude = 2728,
                Partition = "Северен Пирин",
                SpecificLocation = "СЗ от вр.Байови дупки",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 77,
                Name = "Момин двор",
                Altitude = 2722,
                Partition = "Северен Пирин",
                SpecificLocation = "СИ от заслон Тевно езеро",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 78,
                Name = "Десилица",
                Altitude = 2713,
                Partition = "Северен Пирин",
                SpecificLocation = "СИ от вр.Каймакчал",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 79,
                Name = "Кадиев рид",
                Altitude = 2709,
                Partition = "Северен Пирин",
                SpecificLocation = "СЗ от Горно Брезнишко езеро",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 80,
                Name = "Албутин",
                Altitude = 2688,
                Partition = "Северен Пирин",
                SpecificLocation = "СИ от хижа Загаза",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 81,
                Name = "Зъбът",
                Altitude = 2686,
                Partition = "Северен Пирин",
                SpecificLocation = "З от вр.Яловарника (2765 м)",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 82,
                Name = "Куклите",
                Altitude = 2686,
                Partition = "Северен Пирин",
                SpecificLocation = "ЮЗ от вр.Зъбът",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 83,
                Name = "Кралев двор",
                Altitude = 2684,
                Partition = "Северен Пирин",
                SpecificLocation = "ЮИ от заслон Тевно езеро",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 84,
                Name = "Башлийски чукар",
                Altitude = 2683,
                Partition = "Северен Пирин",
                SpecificLocation = "СИ от заслон Спано поле",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 85,
                Name = "Малка Каменица",
                Altitude = 2675,
                Partition = "Северен Пирин",
                SpecificLocation = "ЮИ от заслон Тевно езеро",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 86,
                Name = "Демирчал",
                Altitude = 2674,
                Partition = "Северен Пирин",
                SpecificLocation = "Ю от Горно Брезнишко езеро",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 87,
                Name = "Муратов връх",
                Altitude = 2669,
                Partition = "Северен Пирин",
                SpecificLocation = "ЮЗ от хижа Вихрен",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 88,
                Name = "Валявишки чукар",
                Altitude = 2662,
                Partition = "Северен Пирин",
                SpecificLocation = "СЗ от заслон Тевно езеро",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 89,
                Name = "Джано",
                Altitude = 2657,
                Partition = "Северен Пирин",
                SpecificLocation = "Ю от Попово езеро",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 90,
                Name = "Хлевен",
                Altitude = 2654,
                Partition = "Северен Пирин",
                SpecificLocation = "СИ от хижа Пирин",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 91,
                Name = "Безбог",
                Altitude = 2653,
                Partition = "Северен Пирин",
                SpecificLocation = "ЮЗ от хижа Безбог",
                MountainId = 3
            });

            peaks.Add(new Peak()
            {
                Id = 92,
                Name = "Голям Перелик",
                Altitude = 2191,
                Partition = "Западни Родопи",
                SpecificLocation = "ЮЗ от хижа Перелик",
                Description = "Връх Голям Перелик е най-високият връх в Родопите. С него Родопа се нарежда на седмо място сред българските планини. Планинското било е покрито с прекрасни иглолистни гори, сред които се намират живописни поляни.",
                ImageUrl = "https://www.btsbg.org/sites/default/files/obekti/vruh-golyam-perelik-rodopi.jpg",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 93,
                Name = "Карлъка",
                Altitude = 2188,
                Partition = "Западни Родопи",
                SpecificLocation = "ЮЗ от с.Гела",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 94,
                Name = "Голяма Сютка",
                Altitude = 2186,
                Partition = "Западни Родопи",
                SpecificLocation = "ЮЗ от хижа Пашино бърдо",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 95,
                Name = "Малък Перелик",
                Altitude = 2147,
                Partition = "Западни Родопи",
                SpecificLocation = "СЗ от вр.Голям Перелик",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 96,
                Name = "Краставата чука",
                Altitude = 2136,
                Partition = "Западни Родопи",
                SpecificLocation = "ЮИ от вр.Карлъка",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 97,
                Name = "Кузуятак",
                Altitude = 2110,
                Partition = "Западни Родопи",
                SpecificLocation = "И от хижа Перелик",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 98,
                Name = "Голям Персенк",
                Altitude = 2095,
                Partition = "Западни Родопи",
                SpecificLocation = "З от хижа Чудните мостове",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 99,
                Name = "Шабалиева каба",
                Altitude = 2087,
                Partition = "Западни Родопи",
                SpecificLocation = "С от вр.Малък перелик",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 100,
                Name = "Баташки снежник",
                Altitude = 2082,
                Partition = "Западни Родопи",
                SpecificLocation = "Ю от Батак",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 101,
                Name = "Малка Сютка",
                Altitude = 2079,
                Partition = "Западни Родопи",
                SpecificLocation = "Ю от вр.Голяма Сютка",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 102,
                Name = "Малък Персенк",
                Altitude = 2074,
                Partition = "Западни Родопи",
                SpecificLocation = "Ю от хижа Персенк",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 103,
                Name = "Рядката ела",
                Altitude = 2055,
                Partition = "Западни Родопи",
                SpecificLocation = "СЗ от хижа Перелик",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 104,
                Name = "Мусаята",
                Altitude = 2034,
                Partition = "Западни Родопи",
                SpecificLocation = "ЮЗ от вр.Голям Перелик",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 105,
                Name = "Преспа",
                Altitude = 2000,
                Partition = "Западни Родопи",
                SpecificLocation = "ЮИ от с.Манастир",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 106,
                Name = "Помаккидик",
                Altitude = 1994,
                Partition = "Западни Родопи",
                SpecificLocation = "Ю от хижа Ледницата",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 107,
                Name = "Модър",
                Altitude = 1992,
                Partition = "Западни Родопи",
                SpecificLocation = "СЗ от с.Орехово",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 108,
                Name = "Въртележка",
                Altitude = 1991,
                Partition = "Западни Родопи",
                SpecificLocation = "И от вр.Баташки снежник",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 109,
                Name = "Баталач",
                Altitude = 1988,
                Partition = "Западни Родопи",
                SpecificLocation = "ЮЗ от вр.Голяма Сютка",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 110,
                Name = "Новака",
                Altitude = 1981,
                Partition = "Западни Родопи",
                SpecificLocation = "ЮЗ от вр.Голям Перелик",
                MountainId = 4
            });

            peaks.Add(new Peak()
            {
                Id = 111,
                Name = "Руен",
                Altitude = 2251,
                Description = "Руен е най-високият връх (2251 m) в Осоговската планина, на границата на България със Северна Македония.",
                ImageUrl = "https://patekite.info/wp-content/uploads/2018/09/vryh-shapka-osogovo.jpeg",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 112,
                Name = "Мали Руен",
                Altitude = 2230,
                SpecificLocation = "СИ от вр.Руен",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 113,
                Name = "Шапка",
                Altitude = 2188,
                SpecificLocation = "СИ от вр.Мали Руен",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 114,
                Name = "Горна Сулумка",
                Altitude = 2139,
                SpecificLocation = "ЮИ от вр.Мали Руен",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 115,
                Name = "Царев връх",
                Altitude = 2085,
                SpecificLocation = "ЮЗ от вр.Руен (Северна Македония)",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 116,
                Name = "Църни камък",
                Altitude = 2069,
                SpecificLocation = "СИ от вр.Шапка",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 117,
                Name = "Човеко",
                Altitude = 2047,
                SpecificLocation = "С от заслон Превала",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 118,
                Name = "Таштепе",
                Altitude = 1993,
                SpecificLocation = "З от рудник Руен",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 119,
                Name = "Балтажийница",
                Altitude = 1984,
                SpecificLocation = "ЮИ от вр.Руен",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 120,
                Name = "Човечето",
                Altitude = 1972,
                SpecificLocation = "И от рудник Руен",
                MountainId = 5
            });

            peaks.Add(new Peak()
            {
                Id = 121,
                Name = "Еверест",
                Altitude = 8848,
                Partition = "Махалунгурския дял",
                SpecificLocation = "На границата между Непал и Китайския Тибетски автономен регион.",
                Description = "Еверест (на тибетски: – Джомолунгма: „Богинята майка на Земята“; на непалски:  – Сагарматха: „Високо в небесата“) е връх в Хималаите, най-високият от 14-те планински върхове осемхилядници, в Азия и на Земята. Статутът на най-висок връх в света привлича катерачи от всички категории, от най-опитните до новаци, готови да заплатят солидни суми на професионални планински водачи, обикновено шерпи, за да направят успешно изкачване. Планината не изпъква с изключителни алпинистки трудности при изкачването по стандартния маршрут, за разлика от други осемхилядници като К2 или Нанга Парбат. Въпреки това съществуват множество специфични опасности, като височинна болест, лошо време и силен вятър.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4b/Everest_kalapatthar_crop.jpg/250px-Everest_kalapatthar_crop.jpg",
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 122,
                Name = "Канченджанга",
                Altitude = 8586,
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 123,
                Name = "Лхотце",
                Altitude = 8516,
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 124,
                Name = "Макалу",
                Altitude = 8463,
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 125,
                Name = "Чо Ою",
                Altitude = 8201,
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 126,
                Name = "Дхаулагири",
                Altitude = 8167,
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 127,
                Name = "Манаслу",
                Altitude = 8156,
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 128,
                Name = "Нанга Парбат",
                Altitude = 8126,
                Description = "Нанга Парбате деветият по височина връх на Земята. Името му в превод означава „голата планина“. Понякога е наричан Диамир, което на санскрит означава „кралят на планините“.Планината Нанга Парбат взима много жертви през първата половина на XX век, поради което е известна и с прозвището „планината-убиец“. Въпреки че след този период те значително намаляват, върхът остава сред технически най-трудните за катерене. Характерно за него е, че се възвишава значително над всичко в близката околност.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/22/Nanga-Parbat.jpg/250px-Nanga-Parbat.jpg",
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 129,
                Name = "Анапурна",
                Altitude = 8091,
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 130,
                Name = "Шиша Пангма",
                Altitude = 8012,
                MountainId = 6
            });

            peaks.Add(new Peak()
            {
                Id = 131,
                Name = "Мон Блан",
                Altitude = 4810,
                Description = "Монблан (на италиански: Monte Bianco – Бял връх или Бяла планина) е планински връх в Алпите (част от едноименен масив), най-висок в цяла Западна Европа. Спорът дали върхът се намира на френска територия или на френско-италианската граница все още не е решен.",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR25azvCn83UqRcsHyGFgFjUURzin-Lakak0g&usqp=CAU",
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 132,
                Name = "Дюфур",
                Altitude = 4634,
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 133,
                Name = "Дом",
                Altitude = 4545,
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 134,
                Name = "Вайсхорн",
                Altitude = 4506,
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 135,
                Name = "Матерхорн",
                Altitude = 4478,
                Description = "Матерхорн (на немски: Matterhorn, на френски: Mont Cervin, на италиански: Monte Cervino) е връх в Алпите (Пенински Алпи), висок 4478 m. Представлява живописен остатък (карлинг) от скален блок, издигнат от движенията на земната кора преди 50 млн. години, когато са се сблъскали континентите Африка и Европа. Той е разположен на границата между Швейцария и Италия. Има вечни снегове и ледници. Матерхорн е най-късно изкаченият от високите алпийски върхове. Красивата пирамидална форма на върха може да бъде видяна от швейцарския град Цермат и от италианските алпийски градове Брьой-Червиния и Валтурнанш.Матерхорн е вероятно най-разпознаваемият връх в Алпите, благодарение на своята специфична пирамидална форма.",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6jyg7gj9s6m1QD7ZdY9GmmlIxyyXeX_AQDA&usqp=CAU",
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 136,
                Name = "Дент Бланш",
                Altitude = 4357,
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 137,
                Name = "Гран Комбен",
                Altitude = 4314,
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 138,
                Name = "Фенстеррархорн",
                Altitude = 4273,
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 139,
                Name = "Алечхорн",
                Altitude = 4193,
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 140,
                Name = "Юнгфрау",
                Altitude = 4158,
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 141,
                Name = "Бар дез Екрен",
                Altitude = 4102,
                MountainId = 7
            });

            peaks.Add(new Peak()
            {
                Id = 142,
                Name = "Анкоума",
                Altitude = 6424,
                MountainId = 8
            });

            peaks.Add(new Peak()
            {
                Id = 143,
                Name = "Кабарая",
                Altitude = 5860,
                MountainId = 8
            });

            peaks.Add(new Peak()
            {
                Id = 144,
                Name = "Акотанго",
                Altitude = 6052,
                MountainId = 8
            });

            peaks.Add(new Peak()
            {
                Id = 145,
                Name = "Серо Минчинча",
                Altitude = 5305,
                MountainId = 8
            });

            peaks.Add(new Peak()
            {
                Id = 146,
                Name = "Аконкагуа",
                Altitude = 6962,
                Description = "Аконкагуа (на испански: Aconcagua) е най-високият връх в Южна Америка. Разположен е в планината Анди. Висок е 6962 m. Изграден е от андезит. Има 7 ледника, дълги до 6 km, площ – 76,6 km2 Той се намира в аржентинската провинция Мендоса. Върхът е разположен на около 112 km западно от град Мендоса и на около 15 km от границата на Аржентина с Чили. Аконкагуа е най-високият връх в Западното и Южното полукълбо и е най-високият изгаснал вулкан в света. Той е един от седемте най-високи континентални първенци и неофициално е наричан Колосът на Америка",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/Monte_Aconcagua.jpg/250px-Monte_Aconcagua.jpg",
                MountainId = 8
            });

            peaks.Add(new Peak()
            {
                Id = 147,
                Name = "Серо Бахо",
                Altitude = 5401,
                MountainId = 8
            });

            peaks.Add(new Peak()
            {
                Id = 148,
                Name = "Алпамайо",
                Altitude = 5947,
                MountainId = 8
            });

            peaks.Add(new Peak()
            {
                Id = 149,
                Name = "Карнисеро",
                Altitude = 5960,
                MountainId = 8
            });

            peaks.Add(new Peak()
            {
                Id = 150,
                Name = "Денали",
                Altitude = 6190, 
                Description = "Денали  е най-високият връх в Северна Америка и на територията на Съединените щати.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Wonder_Lake_and_Denali.jpg/778px-Wonder_Lake_and_Denali.jpg",
                MountainId = 9
            });

            peaks.Add(new Peak()
            {
                Id = 151,
                Name = "Ухуру",
                Altitude = 5895,
                Description = "Връх Ухуру представлява най-високата точка в рамките на африканския континент и най-високият връх в Килиманджаро, чиято височина достига забележителните 5892 метра.",
                ImageUrl = "https://www.infopointbg.com/media/18/3471.jpg",
                MountainId = 10
            });

            peaks.Add(new Peak()
            {
                Id = 152,
                Name = "K2 (Чогори)",
                Altitude = 8611,
                Description = "К2 или Чогори, или Годуин Остин е вторият по височина връх на Земята (след Еверест). Надморската му височина е 8611 m. Намира се в планината Каракорум, на границата между Пакистан и Китай.Върхът е открит през 1856 от европейска изследователска експедиция, ръководена от Хенри Годуин-Остин. Името „К2“ е дадено от члена на експедицията Томас Монтгомъри, тъй като върхът е бил вторият, забелязан в Каракорум. Останалите, открити от експедицията върхове, са получили имена K1, K3, K4 и K5, които впоследствеие са заменени съответно с имената Машербрум, Броуд пик, Гашербрум II и Гашербрум I. Въпреки че К2 също е имал местни имена, най-разпространено и използвано е останало „К2“.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fb/K2_2006.jpg/250px-K2_2006.jpg",
                MountainId = 11
            });

            peaks.Add(new Peak()
            {
                Id = 153,
                Name = "Гашербрум I",
                Altitude = 8068,
                MountainId = 11
            });

            peaks.Add(new Peak()
            {
                Id = 154,
                Name = "Броуд пик",
                Altitude = 8047,
                Description = "Броуд Пик (наричан преди K3) е дванадесетият по височина връх в света. Намира се в Каракорум, в планинския масив Гашербрум[1] на границата между Китай и Кашмир, на 8 km от К2.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5b/7_15_BroadPeak.jpg"
                MountainId = 11
            });

            peaks.Add(new Peak()
            {
                Id = 155,
                Name = "Гашербрум II",
                Altitude = 8035,
                MountainId = 11
            });


            return peaks.ToArray();
        }
    }
}
