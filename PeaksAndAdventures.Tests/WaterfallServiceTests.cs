﻿using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Waterfall;
using PeaksAndAdventures.Core.Services;
using PeaksAndAdventures.Infrastructure.Data;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Enums.Route;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Tests
{
	[TestFixture]
	public class WaterfallServiceTests
	{
		private PeaksAndAdventuresDbContext _context;

		private IRepository _repository;
		private IWaterfallService _waterfallService;

		private IEnumerable<Waterfall> _waterfalls;
		private IEnumerable<Mountain> _mountains;
		private IEnumerable<Route> _routes;
		private IEnumerable<RouteWaterfall> _routeWaterfalls;

		[SetUp]
		public void SetUp()
		{
			var options = new DbContextOptionsBuilder<PeaksAndAdventuresDbContext>()
	.UseInMemoryDatabase("PeaksAndAdventuresTest" + Guid.NewGuid().ToString())
	.Options;

			_context = new PeaksAndAdventuresDbContext(options);
			_repository = new Repository(_context);
			_waterfallService = new WaterfallService(_repository);

			_waterfalls = new List<Waterfall>
			{
				new Waterfall
				{
					Id = 1,
					Name = "Райското пръскало",
					Description = "Райското пръскало е най-високият постоянен водопад в България и на Балканския полуостров – 124,5 m.Намира се в Стара планина, на южния склон под най-високия старопланински връх – Ботев. На територията е на природен резерват „Джендема“, част от Национален парк „Централен Балкан“.",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg/1200px-%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg",
					MountainId = 1
				},
				new Waterfall
				{
					Id = 2,
					Name = "Рилска скакавица",
					Description = "Водопад Рилска Скакавица е най-високият водопад в Рила (70 метра). Разположен е на 1750 метра надморска височина, а местността покрай него е много красива. Реката, която го захранва се нарича Скакавица, а преходът до него не е труден и е по добре маркирана пътека. Намира се на 10-на минути от хижа Скакавица, а за нея се тръгва от Паничище. Пътеката започва от началната станция на лифта за Седемте рилски езера и е добре обозначена с табели и маркировка. След като стигнете до хижата, следвате пътеката покрай реката, която ще ви отведе до подножието на водопада. През зимата водопадът замръзва.",
					ImageUrl = "https://bookvila.bg/img/210711093630.jpg",
					MountainId = 2
				}
			};

			_mountains = new List<Mountain>
			{
				new Mountain
				{
					 Id = 1,
				Name = "Стара планина",
				Location = "Стара планина(Balkan Mountains) е една от четирите физиографични региона на Зона Стара планина. Тя е част от Алпийско-Хималайската планинска система, специфично в голямата геоложка формация, известна като Балкански планини. Разположена между Предбалкана на север и Долините на Подбалканските планини на юг, се простира на запад до река Търговище Тимок (десен приток на Бели Тимок) и река Височица (Комшица, Темска река, десен приток на Нишава) в Сърбия. На изток достига Черно море до мисия Емине.\r\n\r\nСтара планина обхваща части от 14 български области: Видин, Монтана, Враца, София, София-град, Ловеч, Пловдив, Габрово, Стара Загора, Велико Търново, Сливен, Шумен, Бургас и Варна.\r\n\r\nПлощта на Стара планина в България е 11 596,4 км\u00b2, с дължина от 530 км и ширина, варираща от 15 км в централната част до 50 км в западната и източната части. Средната й височина е 722 метра надморска височина.",
				Climate = "Климатът е умерено континентален, с изключение на източните части, които подлежат на переходни континентални влияния.\r\n\r\nОсновният планински хребет на Стара планина попада в зоната на планински климат. Основните фактори, които формират климата, са атмосферната циркулация, височината и изложението на склоновете.\r\n\r\nСтара планина служи като основна климатична бариера и природна граница в България. Северните подножия имат умерено континентални климатични характеристики, докато южните са переходни. Переходът в климата е особено характерен за източните части на планината. От подножието до върха се променят характерът и стойностите на климатичните елементи. Средната годишна температура намалява с височината, достигайки -0,7 \u00b0C на станцията на връх Ботев. Средните температури през януари варират широко, от около 0 \u00b0C в най-източните части до -5 \u00b0C за станцията Петрохан и -9,3 \u00b0C за станцията на връх Ботев. Средните температури през юли варират от 8 до 20 \u00b0C, в зависимост от височината. Амплитудите на температурата не са големи, вариращи от 16 до 18 \u00b0C.\r\n\r\nВалежите се увеличават с височината, достигайки 1200–1400 mm. Те са по-обилни на северните склонове, докато южните склонове остават в сянка от валежите, получавайки около 550 mm валежи. В източните части, поради переходния климат, валежите достигат около 600 mm. Задържането на сняг е около 4–6 седмици в по-високите райони и 1–2 седмици на изток. Максималните валежи се случват през пролетта, докато минимумът е през зимата, със сезонно изравняване на валежите в източните части. Най-вятърните места в България са върховете на Мургаш и Ботев, където средната годишна скорост на вятъра достига 10 м/с. Северните подножия на Стара планина се характеризират с фенови явления, докато регионът на Твърдица и Сливен изпитва студения спускащ се вятър, известен като \"бора\" (често наричан \"Сливенски вятър\"). Неблагоприятните климатични явления включват мъгла, инверсии на температурата в котловините и ледени условия.",
				Waters = "Стара планина дава начало на няколко значителни реки в България, сред които Лом, Огоста, Нишава, Малки Искър, Вит, Осъм, Видима, Росица, Янтра, Стряма, Тунджа, Луда Камчия и други. Значителна част от дренажа на реките в България се формира в този планински хребет. Реките проявяват характеристики на дъжд-сняг, сняг-дъжд, дъжд (особено в източната част) и карстово попълване (реките Нишава, Искрецка река, Котленска река, Лева река и др.). Високогорските райони достигат пик на оттичането през май, докато в по-ниски райони това се случва през април за северния склон и март за южния склон. В басейна на река Лудогорие максимумът е през февруари. Тук се намират и два тектонски езера: \"Локвата\" под Голям Купен в Централна Стара планина и Скаленското в Студовска планина.\r\n\r\nМодулът на оттичането в региона на Стара планина показва значително разнообразие. Той е по-висок в зоната с висока надморска височина на северните вятърни склонове (над 25 л/с/км\u00b2), където валежите са по-значителни, задържането на сняг е по-голямо, а изпарението е по-малко изразено. Освен това максималното оттичане е влияно от непропускливото геоложко основание и стръмния релеф. В по-ниската зона модулът на оттичането е значително по-малък (10 л/с/км\u00b2), където по-малките количества валежи, по-малкото задържане на сняг и по-силното изпарение значително намаляват магнитудата му. В най-ниските части на Стара планина модулът варира между 3 и 5 л/с/км\u00b2, а тези стойности се дължат на ниски количества валежи, значително изпарение, значителна инфилтрация в пропускливото геоложко основание и слабия наклон на релефа.\r\n\r\nСред резервоарите най-голямото е язовирът Камчия, построен на река Луда Камчия. Характеристиките на скалната композиция позволяват образуването на значителни количества на подпукнали подземни води. Развитите карстови процеси също са причина за многочислените карстови извори. Някои от най-големите карстови извори тук са Искрецките извори, Житолюб до станция Лакатник, извора Опицвет при подножието на Чепан и Мала планина, Котелските извори, докато най-известните минерални извори са във Вършец, Бурсия (Берковско), Нешковци (Троянско) и други.\r\n\r\nЗабележителни водопади включват Райнското пръскало (най-високият постоянен водопад на Балканския полуостров), Голям Джендемски водопад, Видимското, Кадемлийското, Бабското, Карловско пръскало и други. Вратенският водопад край Враца е най-големият прекъсваем водопад на Балканите.",
				Flora = " До около 800 m н.в. преобладават широколистните видове, предимно дъб и габър, над които е поясът на буковите гори. На много места именно букът формира горната граница на гората. Над буковите гори на отделни места се срещат хубави смърчови гори, на места смесени с ела (Берковска и Калоферска планина). Срещат се още ограничени площи на гори от бяла мура (Тетевенско) и черен бор. По северните склонове на Берковска Стара планина има естествени гори от реликтния обикновен кестен. В Средна Стара планина по карстови терени се среща еделвайсът (района на Козята стена и връх Мазалат).\r\n\r\nНай-високите части са заети от пасища и ливади. От храстовите видове са разпространени шипка, глог, къпина, дрян, леска, хвойна, боровинка, връшняк, трънка, драка, смрадлика, люляк и др. На отделни участъци в Средна и Западна Стара планина са запазени и храстови съобщества от клек. В района на Айтос е разпространен ендемитът айтоско сграбиче, а в централните части на планината се среща ендемитът старопланинска иглика. Западно от Сливен е и най-северното находище на средиземноморския вид кукуч. Значително е разнообразието на тревни видове:­ власатки, ливадина, детелина, светлика, острици, орлова папрат, картъл, полевица и др.",
				Fauna = "Главната старопланинска верига обитават представители на средноевропейската и евросибирската фауна –­ дива коза, благороден елен, сърна, мечка, катерица, вълк, лисица, заек, таралеж, от птиците –­ орел, алпийска гарга, кълвач, дрозд, от влечугите и земноводните –­ дъждовник, усойница, живораждащ гущер, зелен гущер, алпийски тритон и др. Някои животински видове от бръмбарите, пеперудите, скакалците, охлювите, пещерните животни са ендемити.",
				ImageUrls = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Triglav_massif%2C_Bulgaria.jpg/375px-Triglav_massif%2C_Bulgaria.jpg"
				},
				new Mountain
				{
						 Id = 2,
				Name = "Рила",
				Location = "Рѝла е най-високата планина в България и на Балканския полуостров. Намира се в югозападната част на страната, и по-точно в северозападния край на Рило-Родопския планински масив. Най-високият връх на планината – Мусала, със своите 2925,2 m е и най-високият на Балканския полуостров и цяла Източна Европа. По билото на Рила минава Главният български вододел, който съвпада с Главния балкански вододел, разделящ водосборните басейни на Черно и Егейско море.\r\n\r\nВ Европа Рила се нарежда на 6-о място по височина след планините: Кавказ (връх Елбрус – 5642 m), Алпите (връх Монблан – 4807 m), Сиера Невада (връх Муласен – 3479 m), Пиренеите (връх Ането – 3404 m) и Етна (3357 m). От планината извират едни от най-големите и пълноводни български реки – Искър, Марица и Места.",
				Climate = "Рила има типичен планински климат. На връх Мусала (2925 m) падат 2000 mm валежи годишно като 80% от тях са от сняг. Там са измерени най-ниските температури за планината – абсолютна минимална температура -31,2 \u00b0C при средна месечна температура -11,6 \u00b0C, измерена през февруари. Абсолютната максимална температура е 18,7 \u00b0C. Отрицателните температури се задържат средно около 9 месеца, като често продължават до края на юни. Устойчиво повишаване на температурата се наблюдава към средата и края на юли. Но дори и през летните месеци температурата не се задържа трайно над 10 \u00b0C. От 5 до 10 дни през юни, юли и август са със средна температура над 15 \u00b0C. Това определя краткия вегетационен период във високопланинските части. Той варира от 3 до 6 месеца, като над 2000 метра надморска височина трае около 3 месеца.\r\n\r\nВъв високите части на Рила относителната влажност на въздуха най-често е в границите от 80 до 85%. Най-сухи са студените, зимни месеци. Влажността е различна за северните и южни склонове на Рила. По южните склонове на планината валежите през зимата достигат до 22 – 25% от годишната норма, докато по северните склонове са занижени. По западните и северни склонове максимумът на валежите е през пролетта и лятото, а по източните склонове – през зимата.\r\n\r\n\r\nРавни чал\r\nТрайно формиране на снежна покривка в зоните непосредствено над 1000 m надморска височина се наблюдава след 10 – 15 декември – за северните склонове, а за южните – след 20 – 30 декември. Снежната покривка се задържа средно 200 – 220 дни в годината, като за ниската зона на планината тя е най-дебела през февруари. Тогава средната месечна дебелина достига 20 – 30 cm. Във високата зона – над 2000 m надморска височина – снежната покривка е най-дебела през март – 70 – 80 cm. В най-високите части максималната дебелина на снежната покривка достига 200 – 240 cm. Средната продължителност на периода с устойчива снежна покривка е 70 – 80 дни за надморска височина 1200 – 1300 m, а при надморска височина над 2000 m достига до 180 – 200 дни. Не са изключение ветрове със скорост 30 – 40 m/s (над 100 km/h), с предимно югозападна и западна ориентация. Северозападните и североизточните ветрове са по-умерени. Средната месечна скорост на вятъра по най-високите планински върхове достига 11 – 12 m/s. В по-ниските части средната месечна скорост се изменя от 1,2 до 2,5 m/s, а в средната височинна зона от 2,5 – 3,2 m/s. ",
				Waters = "Рила е важен хидроложки възел за България с изключително голям хидроенергиен потенциал, представляващ около 1/4 от целия потенциал на страната. Планината попада в хидроложката област с континентално климатично влияние, планинска подобласт. По северните ѝ склонове и връх Мусала минава главният вододел, разделящ двата отточни басейна – Черноморския и Беломорския (Егейски).Водните запаси, които се формират в границите на планината са най-важният ресурс на чиста питейна вода за околните селища, София, част от населението на Северна Гърция и европейската част на Турция. Районът на населените места, разположени по западните склонове на Рила планина разполага с голям излишък от вода, тъй като оттокът надвишава потреблението около 8 пъти. Режимът на рилските реки е в пряка връзка с надморската височина и около половината от водните запаси в планината се намират на височина над 2050 m. От планината извират едни от най-пълноводните и дълги реки на Балканите – Искър, Марица и Места. Изворите на много притоци на тези реки, както и на притоци на Струма, също се намират във високопланинските части на Рила – Бели, Леви, Прав и Черни Искър, Бяла и Черна Места, реките Белишка, Благоевградска Бистрица, Градевска, Рилска. На територията на планината се формират около 10% от водните ресурси на Струма и Места, над 5% от тези на р. Марица и повече от 8% на р. Искър. Поради екзарационната дейност на ледниците през кватернера във високопланинските части на Рила са се образували голям брой ледникови езера. От тях по-голямата част са постоянни, около 35 са временни и за всички са характерни малките площ и обем. Обикновено заемат дъната на циркусите, циркусните тераси и троговите долини и са разположени на надморска височина между 2000 и 2600 m. Най-често имат закръглена или елипсовидна форма с малки дължина и ширина, като повечето са с площ под 10 дка. Тези води имат значение не толкова с количеството си, отколкото със своето качество и красотата на езерата, която привлича ежегодно хиляди туристи. Веригата на Седемте рилски езера е най-дългата, най-живописна и най-посещавана езерна група. В Рила са описани около 233 езера, от които 189 циркусни, а останалите имат тектонски или свлачищен произход.",
				Flora = "В Рила растат:\r\n\r\nдървета – обикновен габър (Carpinus betulus), зимен дъб (Quercus petraea), обикновен бук (Fagus sylvatica), трепетлика (Populus tremula), бреза (Betula pendula), обикновена ела (Abies alba), бяла мура (Pinus peuce), обикновен смърч (Picea abies), бял бор (Pinus sylvestris) покриват планинските склонове между 1600 до 2000 m.\r\nцветя – алпийска камбанка (Campanula alpina), планинско омайниче (Dryas octopetala), пролетна съсънка (Pulsatilla vernalis), иглика.",
				Fauna = "Общо 24 вида от срещащите се в Рила животни са вписани в Световната Червена книга. Гръбначните животни са 172 вида като 121 от тях са вписани в Българската Червена книга, 15 вида – в европейската Червена книга, 24 вида – в червения списък на Международния съюз за защита на природата (IUCN), а 158 – в списъците към Бернската конвенция.\r\n\r\nБезгръбначни\r\nВ Рила се срещат 2934 вида безгръбначни животни, като 242 са ендемични видове и подвидове. Общо 13 вида от безгръбначните животни живеещи тук са застрашени от изчезване в световен мащаб, а 41 вида са включени в световни и европейски списъци на застрашени видове.[38]\r\n\r\nРиби\r\nВ Рила се срещат 5 вида риби. Различни източници сочат, че видовото разнообразие на рибите достига до 18 като 4 от тях са балкански ендемити.[39] Дъговата и балканската пъстърва обитава езерата и язовирите и по-рядко реките Марица, Ибър, Крива река, Джерман. В рилските езера е широко разпространена лешанката. Видът е интродуциран за стръв от рибари. Някои от езерата са зарибени със сивен. Главочът се среща по-рядко, основно в река Черни Искър.\r\n\r\nЕндемитните видове в Рила са български – главоч (Cottus gobio haemusi) и струмски гулеш (Nemacheilus angorae bureschi) и балкански – маришка мряна (Barbus cyclolepis) и балкански щипок (Sabanejewia aurata balcanica).\r\n\r\nЗемноводни и влечуги\r\nПланината е обитавана от 20 вида земноводни и влечуги. Сред видовете, които се срещат в най-високите части на планината са планинска водна жаба, алпийски тритон, слепок, живороден гущер, ливаден гущер, усойница и медянка. От тях ендемичен вид е македонският гущер.\r\n\r\nПтици\r\nПтиците са представени от 99 вида (около 25% от орнитофауната на България) като тук са най-многобройните популации на глухара, лещарката и планинския кеклик, на пернатоногата и малката кукумявка. Тук се намират и едни от най-жизнените популации на хищни птици. От вписаните в Червената книга птици тук се срещат осояд, скален орел, горски бекас, белогръб кълвач, черен кълвач, малък креслив орел, сокол орко, голям ястреб, орел змияр, ловен сокол и други. Девет вида птици са престанали да гнездят тук.[40]\r\n\r\nБозайници\r\n\r\nЛешников сънливец\r\nБозайниците в Рила са 48 вида като тук е характерна популацията на дивата коза и високопланинската популация на лалугера.[38] Прилепите в Рила са десет, а дребните бозайници се подразделат на насекомоядни, зайци и гризачи. От тях са интересни таралежът, лешниковият сънливец и сляпото куче. Лалугерът е световно застрашен вид. Стабилна, но изолирана високопланинска колония от лалугери е установена в района на връх Белмекен. От по-едрите представители на бозайниците подвидовете на невестулката (Mustela nivalis galinthias) и дивата коза (Rupicapra rupicapra balcanica) са балкански ендемити.",
				ImageUrls = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b2/Maliovitsa_District_Rila.jpg/1280px-Maliovitsa_District_Rila.jpg"
				}
			};

			_routes = new List<Route>
			{
				new Route
				{
					 Id = 1,
				Name = "град Калофер – водопад Райското пръскало",
				Description = "От Калофер до местността Долен Параджик\r\nТръгваме към Райското пръскало от местността Паниците в Калофер. Маршрутът започва по стръмна горска пътека, която продължава около половин час. След като излезем от горския пояс, наклонът рязко намалява. Намираме се на обширни поляни, по които се движим в следващия час и петнайсетина минути. Тук е много горещо в летните дни. Препоръчвам ранно тръгване, за да избегнете обедния ад. Първата чешма се намира двайсетина минути след края на гората, леко вляво.\r\nСлед повече от час вървене на открито, излизаме на разклон в местността Долен Параджик. Наляво е екопътека „Бяла река“, надясно е жълтият маршрут за връх Ботев, а направо е нашата пътека към хижа Рай и Райското пръскало. 5 минути след разклона се открива една от най-красивите гледки по българските планини – към Джендема и връх Ботев над него. Зашеметяваща е! Има няколко пейки, на които да починете с тази гледка насреща. Общо от Калофер до тук е около 1:45 ч.\r\nОт местността Долен Параджик до хижа Рай\r\nНавлизаме в резерват Джендема, по чийто скалисти склонове тече Райското пръскало. Поглед напред разкрива какво ни очаква – слизане до долината под нас и изкачване до гребена на Райските купени отсреща. Хижа Рай се намира на върха му, от другата страна на гората.\r\nЗапочваме леко спускане по широк черен път, който навлиза в букова гора. След 15-20 минути пътят свършва на едно уширение. Вляво от него тръгва тясна горска пътека. Гората се сгъстява, а наклонът се увеличава, но не много. Скоро достигаме река Малка Бъзовица, след която наклонът се обръща нагоре. Малко след нея стигаме до чешмата Мечата глава. Бях по този маршрут през септември и почти не течеше вода по чучура. За щастие след десетина минути има друга чешма, която течеше нормално.\r\nМного скоро наклонът рязко се увеличава – веднага след като прекосим едно поточе. Оттук нататък вървенето става доста тежко в продължение на час и половина, може и повече – почти до хижа Рай. За щастие гората е гъста и предпазва от жаркото слънце. След като излезем от горския пояс, остават пет минутки до хижата. Ето че красивата ни цел се вижда ясно зад нея – Райското пръскало се спуска по Джендема.\r\nОт хижа Рай до Райското пръскало\r\nАко мислим, че се е свършило – не е така. Имаме още половин час до Райското пръскало по също толкова стръмна пътека, колкото досега. Продължаваме от другата страна на хижа Рай, минаваме покрай параклиса и се запътваме в посока водопада. Точно където се прекосява река Пръскалска, на първия завой на пътеката край едни камъни има разклонение. Основният маршрут продължава към Тарзановата пътека и връх Ботев, а вдясно излиза малка пътека, по която ние трябва да тръгнем. Тук ще вметна, че ако идвате май и юни, е много вероятно реката да е пълноводна. Затова е препоръчително да бъдете с хубави непромокаеми обувки.\r\nОттук до Райското пръскало няма много за описване. Само ще обърна внимание, че на места пътеката е сипеста и хлъзгава, но нищо сериозно. След двайсетина минути сме в подножието на водопада.\r\nВъзможност за продължение на маршрута е да слезем и да поемем по маршрута от хижа Рай до връх Ботев или към хижа Васил Левски.",
				Difficulty = Difficulty.Moderate,
				DisplacementPositive = 894,
				Duration = "0.05:00",
				ImageUrl = "https://izbulgaria.com/wp-content/uploads/2021/07/raiskoto-praskalo-768x576.jpg",
				MountainId = 1
				}
			};

			_routeWaterfalls = new List<RouteWaterfall>()
			{
				new RouteWaterfall()
				{
					RouteId = 1, WaterfallId = 1,
				}
			};

			_context.AddRange(this._mountains);
			_context.AddRange(this._waterfalls);
			_context.AddRange(this._routes);
			_context.AddRange(this._routeWaterfalls);
			_context.SaveChanges();
		}

		[TearDown]
		public async Task TearDown()
		{
			await _context.Database.EnsureDeletedAsync();
			await _context.DisposeAsync();
		}

		[Test]
		public async Task AllAsync_ShouldReturnAllWaterfalls()
		{
			var allWaterfalls = await _waterfallService.AllAsync();

			Assert.That(allWaterfalls.Count(), Is.EqualTo(2));
		}

		[Test]
		public async Task AllWaterfallsPaginationAsync_ShouldReturnWaterfallsWithPagination()
		{
			var result = await _waterfallService.AllWaterfallsPaginationAsync(1, 3);

			Assert.That(result.Peaks.Count(), Is.EqualTo(2));
			Assert.That(result.TotalPages, Is.EqualTo(1));
		}

		[Test]
		public async Task CheckWaterfallExistsByNameAsync_ShouldReturnTrue()
		{
			var result = await _waterfallService.CheckWaterfallExistsByNameAsync("Райското пръскало");

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task CheckWaterfallExistsByNameAsync_ShouldReturnFalse()
		{
			var result = await _waterfallService.CheckWaterfallExistsByNameAsync("Водопад");

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task CheckWaterfallExistsByIdAsync_ShouldReturnTrue()
		{
			var result = await _waterfallService.CheckWaterfallExistsByIdAsync(2);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task CheckWaterfallExistsByIdAsync_ShouldReturnFalse()
		{
			var result = await _waterfallService.CheckWaterfallExistsByIdAsync(3);

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task AddWaterfallToMountain_ShouldAddWaterfallToMountain()
		{
			var waterfallAdd = new WaterfallAddViewModel()
			{
				Name = "Видимско пръскало",
				Description = "Видимското пръскало се намира в природен резерват „Северен Джендем“, който обхваща северния склон на  връх Ботев. Представлява образувание от три отделни потока, които се събират в един. Най-близкото населено място до водопада е гр. Априлци. В бившето село Видима, което вече е част от града, се намират ВЕЦ Видима и хижа Видима. От там е и пътят, минаващ покрай Пръскалска река, по който се стига до водопада. По пътя е обособена и „Зелена класна стая”, където по достъпен игрови начин децата могат да се запознават с растенията, животните и да играят.",
				ImageUrl = "https://bookvila.bg/img/210709032337.jpg",
				MountainId = 1
			};

			await _waterfallService.AddWaterfallToMountain(waterfallAdd);

			var allWaterfalls = await _waterfallService.AllAsync();

			Assert.That(allWaterfalls.Count(), Is.EqualTo(3));

			var result = this._context.Waterfalls.FirstOrDefaultAsync(w => w.Name == "Видимско пръскало");

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Result.Name, Is.EqualTo(waterfallAdd.Name));
			Assert.That(result.Result.Description, Is.EqualTo(waterfallAdd.Description));
			Assert.That(result.Result.ImageUrl, Is.EqualTo(waterfallAdd.ImageUrl));
			Assert.That(result.Result.MountainId, Is.EqualTo(waterfallAdd.MountainId));
		}

		[Test]
		public async Task DetailsAsync_ShouldReturnDetailsOnWaterfall()
		{
			var result = await _waterfallService.DetailsAsync(1);

			Assert.That(result.Name, Is.EqualTo("Райското пръскало"));
			Assert.That(result.Description,
				Is.EqualTo(
					"Райското пръскало е най-високият постоянен водопад в България и на Балканския полуостров – 124,5 m.Намира се в Стара планина, на южния склон под най-високия старопланински връх – Ботев. На територията е на природен резерват „Джендема“, част от Национален парк „Централен Балкан“."));
			Assert.That(result.ImageUrl, Is.EqualTo("https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg/1200px-%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg"));
		}

		[Test]
		public async Task EditGetAsync_ShouldGetInformationForWaterfall()
		{
			var result = await _waterfallService.EditGetAsync(1);


			Assert.That(result.Id, Is.EqualTo(1));
			Assert.That(result.Name, Is.EqualTo("Райското пръскало"));
			Assert.That(result.Description,
				Is.EqualTo(
					"Райското пръскало е най-високият постоянен водопад в България и на Балканския полуостров – 124,5 m.Намира се в Стара планина, на южния склон под най-високия старопланински връх – Ботев. На територията е на природен резерват „Джендема“, част от Национален парк „Централен Балкан“."));
			Assert.That(result.ImageUrl, Is.EqualTo("https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg/1200px-%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg"));
		}

		[Test]
		public async Task EditPostAsync_ShouldEditWaterfall()
		{
			var waterfallEdit = new WaterfallEditViewModel()
			{
				Id = 2,
				Name = "Рилска скакавица",
				Description = "Водопад Рилска Скакавица е най-високият водопад в Рила (70 метра). Разположен е на 1750 метра надморска височина, а местността покрай него е много красива. Реката, която го захранва се нарича Скакавица, а преходът до него не е труден и е по добре маркирана пътека. Намира се на 10-на минути от хижа Скакавица, а за нея се тръгва от Паничище. Пътеката започва от началната станция на лифта за Седемте рилски езера и е добре обозначена с табели и маркировка. След като стигнете до хижата, следвате пътеката покрай реката, която ще ви отведе до подножието на водопада. През зимата водопадът замръзва.",
				ImageUrl = "https://bookvila.bg/img/210711093630.jpg",
			};

			await _waterfallService.EditPostAsync(waterfallEdit);

			var result = await this._context.Waterfalls.FirstOrDefaultAsync(w => w.Id == 2);

			Assert.That(result.Name, Is.EqualTo(waterfallEdit.Name));
			Assert.That(result.Description, Is.EqualTo(waterfallEdit.Description));
			Assert.That(result.ImageUrl, Is.EqualTo(waterfallEdit.ImageUrl));
		}

		[Test]
		public async Task DeleteGetAsync_ShouldGetInformationForDeleteWaterfall()
		{
			var result = await _waterfallService.DeleteGetAsync(1);

			Assert.That(result.Id, Is.EqualTo(1));
			Assert.That(result.Name, Is.EqualTo("Райското пръскало"));
			Assert.That(result.ImageUrl, Is.EqualTo("https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg/1200px-%D0%A0%D0%B0%D0%B9%D1%81%D0%BA%D0%BE%D1%82%D0%BE_%D0%BF%D1%80%D1%8A%D1%81%D0%BA%D0%B0%D0%BB%D0%BE_%D0%91%D0%B0%D0%BB%D0%BA%D0%B0%D0%BD.jpg"));
		}

		[Test]
		public async Task DeleteConfirmedAsync_ShouldDeleteWaterfall()
		{
			await _waterfallService.DeleteConfirmedAsync(2);

			var result = await this._context.Waterfalls.FirstOrDefaultAsync(w => w.Id == 2);

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task DeleteConfirmedAsync_ShouldDeleteWaterfallWithRoutes()
		{
			await _waterfallService.DeleteConfirmedAsync(1);

			var result = await this._context.Waterfalls.FirstOrDefaultAsync(w => w.Id == 1);

			Assert.That(result, Is.Null);
		}

		[Test]
		public async Task GetRoutesForWaterfallAsync_ShouldReturnAllRoutesToWaterfall()
		{
			var result = await _waterfallService.GetRoutesForWaterfallAsync(1);

			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task GetRoutesForWaterfallAsync_ShouldReturnEmptyCollectionWhereThereIsNoRoutes()
		{
			var result = await _waterfallService.GetRoutesForWaterfallAsync(2);

			Assert.That(result.Count(), Is.EqualTo(0));
		}
	}
}