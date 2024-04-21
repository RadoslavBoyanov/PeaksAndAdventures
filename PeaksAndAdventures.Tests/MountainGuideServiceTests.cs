using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.MountainGuide;
using PeaksAndAdventures.Core.Services;
using PeaksAndAdventures.Infrastructure.Data;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Enums.Route;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Tests
{
	[TestFixture]
	public class MountainGuideServiceTests
	{
		private PeaksAndAdventuresDbContext _context;

		private IRepository _repository;
		private IMountainGuideService _service;

		private IEnumerable<MountainGuide> _mountainGuides;
		private IEnumerable<Mountain> _mountains;
		private IEnumerable<Route> _routes;
		private IEnumerable<TourAgency> _tourAgencies;
		private IEnumerable<IdentityUser> _users;

		private IEnumerable<MountaineerMountain> _mountaineerMountains;
		private IEnumerable<MountaineerRoute> _mountaineerRoutes;

		[SetUp]
		public void SetUp()
		{
			_context = new PeaksAndAdventuresDbContext(new DbContextOptionsBuilder<PeaksAndAdventuresDbContext>()
							.UseInMemoryDatabase(databaseName: "PeaksAndAdventuresTest" + Guid.NewGuid().ToString())
							.Options);

			_repository = new Repository(_context);
			_service = new MountainGuideService(_repository);

			_mountainGuides = new List<MountainGuide>
			{
				new MountainGuide { 
					Id = 1,
					Email = "climber@mail.com",
					Experience = 7,
					FirstName = "Илия",
					LastName = "Петканов",
					Phone = "0895123456",
					Age = 32,
					ImageUrl = "https://i.pik.bg/news/326/660_5a4e3ddb77802504f456d107ec12255d.jpg",
					TourAgencyId = 1,
					OwnerId = "0d59049e-81f2-48f1-abb2-a5fd09bc210f",
				},
			};

			_mountains = new List<Mountain>
			{
				new Mountain { 
					Id = 1,
				Name = "Хималаи",
				Location = "Хималаите или Хималая ( от санскритската дума хима (сняг) + алая (дом), което буквално означава „домът на снега“[1]) е планинска верига в Индийския субконтинент, разположена на територията на Пакистан, Индия, Китай, Непал и Бутан, между Индо-Гангската равнина на юг, Тибетската планинска земя на север. В нея се издигат единадесет от четиринадесетте най-високи върхове на Земята, включително и този с най-високата надморска височина, връх Еверест. Те са най-мощната планинска система на Земята, с най-високите върхове, най-малките разлики във височина на къси разстояния и дълбоки (до 4 – 5 km) дефилета. Хималаите са дълбоко оформили културите на Южна Азия. Много хималайски върхове са свещени в будизма и хиндуизма.",
				Climate = "Хималаите имат голям ефект върху климата на Индийския субконтинент и Тибетското плато. Те спират мразовитите и сухи ветрове да достигнат на юг в субконтинента, което поддържа Южна Азия много по-топла, отколкото съответните умерени региони в останалите континенти. Планинската верига също така представлява бариера за мусонните ветрове на север, които изливат обилните си валежи в района на т.нар. тераи. За Хималаите също така се смята, че играят важна роля за формирането на пустините в Централна Азия, например Такламакан и Гоби.\r\n\r\nКлиматът в западния сектор на Хималаите се характеризира с резки колебания на температурата и силни ветрове. Зимата е студена (средна януарска температура -10, -18\u00b0С), а над 2500 m – със снежни виелици. Лятото е топло (средна юлска температура около 18\u00b0С) и сухо. Влиянието на мусоните е незначително и се изразява само в малкото увеличение на влажността и облачността през юли и август. Валежите (около 1000 mm годишно) са свързани с циклоните, като в долините и котловините тяхното количество е 3 – 4 пъти по-малко, отколкото по планинските склонове. Главните проходи се освобождават от снежната покривка в края на май. В Западните Хималаи на височина 1800 – 2200 m са разположени болшинството от климатичнети курорти на Индия (Шимла и др.). Източният сектор има много по горещ и влажен климат с мусонен режим на овлажняването, като 85 – 95% от годишните валежи падат от май до октомври. През лятото на височина 1500 m температурите по склоновете се повишават до 35\u00b0С, а в долините – даже до 45\u00b0С. Дъждовете валят почти непрекъснато. По южните склонове на височина 3000 – 4000 m падат от 2500 mm на запад до 5500 mm на изток, а във вътрешните райони – около 1000 mm. През зимата на височина 1800 m средната януарска температура е 4\u00b0С, а над 3000 m температурите са отрицателни. Снеговалежите са ежегодно явление над 2200 – 2500 m, а в долините има гъсти мъгли. Северните склонове на Хималаети имат планинско-пустинен климат. Денонощните температурни амплитуди достигат до 45\u00b0С, а годишната сума на валежите е около 100 mm. През лятото на височина 5000 – 6000 m само през деня има положителни температури. Относителната влажност на въздуха е 30 – 60%, а през зимата снегът преди да падне се изпарява и не се задържа.",
				Waters = "По-високите части на Хималаите са целогодишно покрити със сняг, въпреки близостта си до тропиците. Те дават началото на няколко големи реки, които се обединяват в две основни речни системи:Западните реки образуват Индския басейн, в който най-голямата река е Инд. Тя води началото си от Тибет на китайска територия и тече на югозапад през Индия и Пакистан до Арабско море. Главните реки в системата на Инд са Джелам, Чинаб, Рави, Биас и Сутледж.\r\nПовечето от останалите хималайски реки са част от басейна на Ганг-Брахмапутра. Неговите две основни реки са Ганг и Брахмапутра. Докато Ганг тече в равнините на юг от Хималаите, Брахмапутра извира в Тибет, тече на изток, след което заобикаля Хималаите от изток, отново променя посоката си на запад през Асам и се влива в Бенгалския залив, образувайки обща делта с Ганг. Като цяло речната система е много по-добре развита по техните южни склонове. В горните си течения реките имат снежно и ледниково подхранване с рязко колебания на оттока в течение на едно денонощие, като долините им са тесни и дълбоки, а течението им е съпроведено от много прагове и водопади. В средното и долното си течение подхранването им е дъждовно, с максимален отток праз лятото.\r\nВ Хималаите са разположени и стотици езера, като повечето са с надморска височина под 5000 m, а като цяло размерът им намалява с височината. Те са предимно с тектонски и ледников произход и особено много в западните части. Най-голямо е езерото Пангонг Цо, разположено на границата между Индия и Китай, което има площ около 700 km\u00b2. Други известни езера са Гуродонгмар и Цонгмо в Сиким и Тиличо в Непал.",
				Flora = "Природните ландшафти в Хималаите са много разнообразни, особено по южните склонове. Покрай подножието на планината на изток от долината на река Джамна се простира заблатената полоса от тераи – дървесно-храстова джунгла от сапунени дървета, мимози, палми, бамбук, банани, манго, всички те развити върху черни тинести почви. Нагоре, до 1000 – 1200 m по наветрените склонове и по долините на реките растат вечнозелени влажни тропични гори съставени от палми, пандануси, лаврови дървета, дървовидна папрат, бамбук, лиани (до 400 вида) и др. Над 1200 m на запад и 1500 m на изток е разположен поясът на вечнозелените широколистни гори, състоящи се от различни видове дъб, магнолия, а над 2200 m се появяват листопадни (елша, орех, бреза, клен) и иглолистни (хималайски кедър, син бор, сребрист смърч) гори от умерения пояс, в съпровод от мъхове и лишеи, покриващи почвата и стволовете на дърветата. На височина 2700 – 3600 m господстват иглолистните гори от сребриста ела, лественица, тсуга, хвойна и др. с гъст подлес от рододендрон. За долната част на горския пояс са характерни червеноземните, а нагоре – кафявите горски почви. В субалпийския пояс са развити малки хвойново-рододендронови горички. Горната граница на алпийските пасища е около 5000 m, макар че отделни растения (аренария, еделвайс) са разпространени и над 6000 m.",
				Fauna = "Сред животните господстват представители на тибетската фауна – хималайска мечка, планинска коза, планински овен, як. На височина до 2500 m има малки земеделски участъци, като се отглежда чай и цитрусовите култури, а по напояваните тераси – ориз. По северните склонове отглеждането на голозърнестия ечемик достига на височина до 4500 m.",
				ImageUrls = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Himalayas.jpg/450px-Himalayas.jpg" },
				new Mountain
				{
					 Id = 2,
				Name = "Алпи",
				Location = "Алпи  е една от големите планински вериги в Европа, простираща се от Австрия и Словения на изток през Италия, Швейцария, Лихтенщайн и Германия до Франция и Монако на запад.",
				Climate = "Климатът е планински. Средногодишните валежи в Алпите са 1450 mm.Алпите се делят на пет климатични зони, всяка с различен вид на околната среда. Климатът, растенията и животинския свят се различават в различните части или зони на планината.Зоната, която е над 3000 m, се нарича „зона на ледниковия сняг“ (фирн). Тази област, която е с най-студения климат, постоянно е покрита със сбит сняг.Алпийската тундра се намира на височина между 2000 и 3000 m. Тази зона е по-топла, отколкото зоната на фирна. Тук могат да се срещнат диви цветя и треви.Непосредствено под нея е субалпийската зона – от 1500 до 2000 m височина. Тук, с покачването на температурата бавно нагоре, започват да се срещат елхови и смърчови гори.На височина от около 1000 до 1500 m е обработваемата земя. В тази област са разпространени дъбовите гори, а също така е и мястото за селскостопанско производство.Под 1000 m са низините. Тук се среща далеч по-голямо разнообразие от растения. Човешките селища също така са в низините, тъй като температурата е по-поносима – както за хората, така и за животните.",
				Waters = "ай-дългите реки, които текат през Алпите, са Ин и Драва. Езерата в Алпите са образувани от някогашни ледници. Едни от най-красивите езера в Алпите са Лаго Маджоре, от което идва притокът на реката По, и езерото Лаго ди Гарда, намиращо се близо до река Адидже.",
				Flora = "Растителните пояси в Алпите постепенно се сменят с изкачването нагоре по планината. Естествената височинна граница на растителността е определена от основни широколистни видове – дъб, бук, ясен и явор. Те не достигат до едно и също ниво, нито се срещат често заедно, но горната им граница отговаря достатъчно точно на промяната от умерен към по-студен климат, което допълнително се доказва от промяната на тревистата растителност. Тази граница обикновено се намира на около 1200 m над морското равнище – от северната страна на Алпите, а на южните склонове често се издига на 1500 m, понякога дори до 1700 m.Този регион не винаги е белязан от присъствието на характерните дървета. Човешката намеса почти ги е унищожила в много области, и с изключение на буковите гори на австрийските Алпи, широколистните гори са рядко срещани. В много райони, където някога са съществували такива гори, сега са заменени от бял бор и смърч, които са по-нечувствителни към опустошенията от кози, които са най-големите врагове на такива дървета.Над горите често се срещат отделни малки групи от клек, който на свой ред е заменен от храсти – обикновено Rhododendron ferrugineum (върху по-киселинни почви) или Rhododendron hirsutum (върху по-алкални почви). Над тях са високопланинските ливади, а още по-високо растителността става все по-рядка. В Алпите са регистрирани няколко вида растения над 4000 m, включително Ranunculus glacialis (вид лютиче), Androsace Alpina и Saxifraga biflora.\r\n\r\nВ района на Алпите учените идентифицират 13 000 вида растения. Алпийските растения са групирани по тип местообитание и почва, която може да бъде варовикова или не. Растенията виреят в различни диапазони на условия на околната среда: от ливади, блата, гори (широколистни и иглолистни) и райони, незасегнати от сипеи и лавини, до скали и хребети.[15]\r\n\r\nЕдно от най-известните планински растения е ледниковото лютиче, което държи рекорд сред растенията с височина на виреене от 4200 m. Малки групи растения се намират на надморска височина от 2800 m. Много от тях, като например Eritríchium и Lýchnis имат специфична форма, която ги предпазва от тревопасни животни, които живеят на тези височини, и от загубата на влага. По този начин младите филизи са защитени от вятър и студ. Известният еделвайс е покрит със слой от бели власинки, които успешно задържат топлината.",
				Fauna = "Алпите са дом на 30 000 вида животни. Бозайниците обитават Алпите целогодишно, като някои от тях спят зимен сън. Само някои видове птици остават в планината през цялата година. Има птици, живеещи в Алпите, които напълно са се адаптирали към негостоприемната среда. Например снежната чинка строи гнезда в пукнатините на скалите над границата на гората и търси храната си (семена и насекоми) по планинските склонове. Жълтоклюната гарга също гнезди по скалите много над границата на гората. През зимата тя образува големи ята, които се събират около туристическите центрове и станции, където се хранят основно с отпадъци. Особено внимателно се подготвя за зимата сокерицата – през есента тази птица трупа запаси от семена и ядки, които заравя в земята. Преди началото на зимата сокерицата събира повече от 100 000 семена, които крие в около 25 скривалища. С невероятната памет, тя намира повечето от скривалищата си под снега през зимата, дебелината на който може да бъде повече от един метър. Със семената от складовете си сокерицата храни малките си.\r\n\r\nНай-често срещаното животно в Алпите е алпийският мармот. Освен него се отличават скалният орел, алпийският козирог, дивата коза, жълтоклюната гарга, пъстрогушата завирушка, брадатият лешояд, кафявата мечка, рисът, благородният елен, вълкът и тундровата яребица. В Алпите има 14 национални парка, които осигуряват опазването на алпийската фауна.",
				ImageUrls = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/Mont_Blanc_oct_2004.JPG/1280px-Mont_Blanc_oct_2004.JPG"
				}
			};

			_routes = new List<Route>
			{
				new Route {  Id = 1,
					Name = "Североизточен ръб - Еверест",
					StartingPoint = "Базов лагер Еверест",
					Description =
						"Североизточният ръб (наричан просто северен) започва от северната страна на планината, в Тибет. Експедицията прави преход пеша по каменист път до ледника Ронгбук, където на 5180 m се намира базовият лагер. За да достигнат Лагер 2, катерачите преминават през средно големи морени по източната страна на Ронгбук до базата Чангце на 6100 m. Лагер 3 (Преден базов лагер) се намира под Северното седло на 6500 m. За да достигнат до Лагер 4, катерачите се изкачват по ледника, след което по фиксирани въжета достигат до върха на Седлото (7010 m). Оттам следва изкачване по каменистия северен ръб, до Лагер 5 на 7775 m. Следва диагонално подсичане на северното било до Жълтия пояс, където се намира Лагер 6 на 8230 m. Оттам катерачите атакуват върха.Катерачите се сблъскват с коварното препятствие, което представлява Първото стъпало на 8534 m. Следва Второто стъпало (~8600 m). За неговото преодоляване се използва съоръжение, наречено „Китайската стълба“ – постоянна метална стълба, поставена през 1975 г. от китайска експедиция. Оттогава тя неизменно служи на катерачите, и на практика всеки атакуващ върха е минал през нея. Третото стъпало (8689 – 8800 m) се преодолява почти пълзешком. След стъпалата до върха остават снежен наклон под почти 50 градуса и финалният хребет..",
					Difficulty = Difficulty.Difficult,
					DisplacementPositive = 3669,
					DisplacementNegative = 3669,
					Duration = "60.00:00",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Mount_Everest_North_Face.jpg/220px-Mount_Everest_North_Face.jpg",
					MountainId = 1
				},
				new Route()
				{
					Id = 2,
					Name = "Gouter route - Монблан",
					StartingPoint = "Nid d'Aigle",
					Description = "\"Gouter Route\" се е превърнал в \"нормалния маршрут\" за изкачване на Мон Блан. От техническа гледна точка, това е най-малко трудния път към върха, но не бива да бъде подценяван. Изкачването до хижа Gouter не е само ходене по една туристическа пътека, пътят минава през заледен терен и трябва да се справяте и с надморската височина. В средата на лятото големият брой хора по този маршрут увеличават обективните опасности: каменопади, опашки от изчакващи се хора при тесните участъци, навалица в хижата. За щастие, тези дразнители не правят маршрута по-малко интересен: \"Покрива на Европа\" е красив за изкачване връх, дори по нормалния път, и е удивително изживяване. Изкачването до Егюй дю Гутер на светлината на челниците, бавното набиране на височина по склоновете, преминаването на тесния хребет Босе, осветен от сутрешното слънце, остава незаличими следи в умовете на тези, осмелили се да приемат предизвикателството на тези височини.",
					Difficulty = Difficulty.Difficult,
					DisplacementPositive = 2426,
					DisplacementNegative = 2426,
					Duration = "2.00:00",
					ImageUrl = "https://static.wixstatic.com/media/4bb50d_3e741a5aef4b434aa34a25bc182ea9e0~mv2.jpg/v1/fill/w_979,h_552,fp_0.50_0.50,q_85,usm_0.66_1.00_0.01,enc_auto/4bb50d_3e741a5aef4b434aa34a25bc182ea9e0~mv2.jpg",
					MountainId = 2
				}
			};

			_tourAgencies = new List<TourAgency>()
			{
				new TourAgency()
				{
					Id = 1,
					Name = "Hikers",
					Description = "Hikers е изключително престижна туристическа агенция, посветена на страстта и приключението в света на планинарството. С богат опит в организацията на експедиции и планинарски турове, тази агенция съчетава страстта към природата със знание и професионализъм.\r\nНашата мисия е да предоставяме неповторими и вълнуващи преживявания за всички любители на приключенските спортове и обичатели на природата. Специализирани в организирането на експедиции в различни части на света, ние съчетаваме уникални маршрути, експертни водачи и безопасност на високо ниво, за да осигурим незабравими преживявания на върховете на света.\r\n\r\nНашите експедиции включват разнообразни дестинации - от високите върхове на Хималаите, през загадъчните планини в Южна Америка, до непокорените върхове в Африка и още много други. Съчетаваме екстремни предизвикателства с красивите природни пейзажи, за да създадем едно неповторимо приключение.\r\n\r\nНашите професионални гидове и инструктори са подготвени да водят клиентите ни през всеки етап от техния планинарски път. Разполагаме с модерно оборудване и осигуряваме пълна подкрепа за участниците в нашите турове, гарантирайки тяхната безопасност и комфорт.\r\nClimb and Hiking не предлага просто пътувания; предлагаме възможността за откриване на света от високо и по нов, невиждан начин. За нас, планинарството е не просто хоби, а начин на живот, който искаме да споделим с всички, които търсят истинско предизвикателство и незабравими преживявания в планината. Приключили сте да се катерите – започнете да живеете!",
					Email = "hikers@mail.com",
					Phone = "0899001166",
					OwnerId = "007b397f-9a3d-48d5-a8e4-ad00bbc43326"
				}
			};

			_users = new List<IdentityUser>
			{
				new IdentityUser
				{
					Id = "0d59049e-81f2-48f1-abb2-a5fd09bc210f",
					UserName = "climber@mail.com",
					NormalizedUserName = "CLIMBER@MAIL.COM",
					Email = "climber@mail.com",
					NormalizedEmail = "CLIMBER@MAIL.COM"
				},
				new IdentityUser
				{
					Id = "007b397f-9a3d-48d5-a8e4-ad00bbc43326",
					UserName = "hikers@mail.com",
					NormalizedUserName = "HIKERS@MAIL.COM",
					Email = "hikers@mail.com",
					NormalizedEmail = "HIKERS@MAIL.COM"
				}
			};

			_mountaineerMountains = new List<MountaineerMountain>
			{
				new MountaineerMountain { MountainId = 1, MountainGuideId = 1 }
			};

			_mountaineerRoutes = new List<MountaineerRoute>
			{
				new MountaineerRoute { MountainGuideId = 1, RouteId = 1},
			};

			_context.AddRange(_mountainGuides);
			_context.AddRange(_mountains);
			_context.AddRange(_routes);
			_context.AddRange(_mountaineerMountains);
			_context.AddRange(_mountaineerRoutes);
			_context.AddRange(_tourAgencies);
			_context.AddRange(_users);


			_context.SaveChanges();
		}

		[TearDown]
		public async Task TearDown()
		{
			await _context.Database.EnsureDeletedAsync();
			await _context.DisposeAsync();
		}

		[Test]
		public async Task AddAsync_ShouldAddMountainGuide()
		{
			var mountainGuideForm = new MountainGuideAddViewModel
			{
				FirstName = "Бисер",
				LastName = "Бисеров",
				Email = "biser@gmail.com",
				Phone = "0895123456",
				Experience = 4,
				TourAgencyId = 1,
				OwnerId = "0d59049e-81f2 - 48f1 - abb2 - a5fd09bc210f",
				Age = 29,
				ImageUrl = "https://i.pik.bg/news/326/660_5a4e3ddb77802504f456d107ec12255d.jpg",
			};

			await _service.AddAsync(mountainGuideForm);

			var allMountainGuides = await _service.AllAsync();
			
			Assert.That(allMountainGuides.Count(), Is.EqualTo(2));

			var result = await this._service.DetailsAsync(2);

			Assert.IsNotNull(result);
			Assert.That(mountainGuideForm.FirstName, Is.EqualTo(result.FirstName));
			Assert.That(mountainGuideForm.LastName, Is.EqualTo(result.LastName));
			Assert.That(mountainGuideForm.Email, Is.EqualTo(result.Email));
			Assert.That(mountainGuideForm.Phone, Is.EqualTo(result.Phone));
			Assert.That(mountainGuideForm.Experience, Is.EqualTo(result.Experience));
			Assert.That(mountainGuideForm.TourAgencyId, Is.EqualTo(result.TourAgencyId));
			Assert.That(mountainGuideForm.OwnerId, Is.EqualTo(result.OwnerId));
			Assert.That(mountainGuideForm.Age.ToString(), Is.EqualTo(result.Age.ToString()));
			Assert.That(mountainGuideForm.ImageUrl, Is.EqualTo(result.ImageUrl));
		}

		[Test]
		public async Task AllAsync_ShouldReturnAllMountainGuides()
		{
			var result = await _service.AllAsync();

			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task AddRouteToMountainGuideAsync_ShouldAddRouteToMountainGuide()
		{
			var result = await _service.AddRouteToMountainGuideAsync(1, 2, "0d59049e-81f2-48f1-abb2-a5fd09bc210f");

			Assert.IsTrue(result);
		}

		[Test]
		public async Task AddMountainToMountainGuideAsync_ShouldAddMountainToMountainGuide()
		{
			var result = await _service.AddMountainToMountainGuideAsync(1, 2, "0d59049e-81f2-48f1-abb2-a5fd09bc210f");

			Assert.IsTrue(result);
		}

		[Test]
		public async Task CheckIfExistMountainGuideByIdAsync_ShouldReturnTrue()
		{
			var result = await _service.CheckIfExistMountainGuideByIdAsync(1);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task CheckIfExistMountainGuideByIdAsync_ShouldReturnFalse()
		{
			var result = await _service.CheckIfExistMountainGuideByIdAsync(2);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task CheckIfExistMountainGuideByOwnerIdAsync_ShouldReturnTrue()
		{
			var result = await _service.CheckIfExistMountainGuideByOwnerIdAsync("0d59049e-81f2-48f1-abb2-a5fd09bc210f");

			Assert.IsTrue(result);
		}

		[Test]
		public async Task CheckIfExistMountainGuideByOwnerIdAsync_ShouldReturnFalse()
		{
			var result = await _service.CheckIfExistMountainGuideByOwnerIdAsync("007b397f-9a3d-48d5-a8e4-ad00bbc43326");

			Assert.IsFalse(result);
		}

		[Test]
		public async Task DetailsAsync_ShouldReturnMountainGuideDetails()
		{
			var result = await _service.DetailsAsync(1);

			Assert.IsNotNull(result);
			Assert.That(result.FirstName, Is.EqualTo("Илия"));
			Assert.That(result.LastName, Is.EqualTo("Петканов"));
			Assert.That(result.Email, Is.EqualTo("climber@mail.com"));
			Assert.That(result.Phone, Is.EqualTo("0895123456"));
			Assert.That(result.Experience, Is.EqualTo(7));
			Assert.That(result.TourAgencyId, Is.EqualTo(1));
			Assert.That(result.OwnerId, Is.EqualTo("0d59049e-81f2-48f1-abb2-a5fd09bc210f"));
			Assert.That(result.Age, Is.EqualTo("32"));
			Assert.That(result.ImageUrl, Is.EqualTo("https://i.pik.bg/news/326/660_5a4e3ddb77802504f456d107ec12255d.jpg"));
		}

		[Test]
		public async Task DeleteGetAsync_ShouldGetInformationForGuideWhoWillBeDeleted()
		{
			var mountaineer = await _service.DetailsAsync(1);
			var result = await _service.DeleteGetAsync(1);

			Assert.IsNotNull(result);
			Assert.That(result.FirstName, Is.EqualTo(mountaineer.FirstName));
			Assert.That(result.LastName, Is.EqualTo(mountaineer.LastName));
			Assert.That(result.Email, Is.EqualTo(mountaineer.Email));
			Assert.That(result.ImageUrl, Is.EqualTo(mountaineer.ImageUrl));
		}

		[Test]
		public async Task DeleteGetAsync_ShouldReturnNull()
		{
			var result = await _service.DeleteGetAsync(2);

			Assert.IsNull(result);
		}

		[Test]
		public async Task DeleteConfirmedAsync_ShouldDeleteMountainGuide()
		{
			await _service.DeleteConfirmedAsync(1);

			var result = await _service.AllAsync();

			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public async Task DeleteConfirmedAsync_ShouldDeleteMountainGuideRoutes()
		{
			await _service.DeleteConfirmedAsync(1);

			var result = this._context.MountaineersRoutes.Where(x => x.MountainGuideId == 1);

			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public async Task DeleteConfirmedAsync_ShouldDeleteMountainGuideMountains()
		{
			await _service.DeleteConfirmedAsync(1);

			var result = this._context.MountaineersMountains.Where(x => x.MountainGuideId == 1);

			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public async Task EditGetAsync_ShouldGetMountainGuideForEdit()
		{
			var mountaineer = await _service.DetailsAsync(1);
			var result = await _service.EditGetAsync(1);

			Assert.IsNotNull(result);
			Assert.That(result.Id, Is.EqualTo(mountaineer.Id));
			Assert.That(result.FirstName, Is.EqualTo(mountaineer.FirstName));
			Assert.That(result.LastName, Is.EqualTo(mountaineer.LastName));
			Assert.That(result.Email, Is.EqualTo(mountaineer.Email));
			Assert.That(result.Phone, Is.EqualTo(mountaineer.Phone));
			Assert.That(result.Experience, Is.EqualTo(mountaineer.Experience));
			Assert.That(result.TourAgencyId, Is.EqualTo(mountaineer.TourAgencyId));
			Assert.That(result.TourAgencyName, Is.EqualTo(mountaineer.TourAgencyName));
			Assert.That(result.OwnerId, Is.EqualTo(mountaineer.OwnerId));
			Assert.That(result.Age.ToString(), Is.EqualTo(mountaineer.Age.ToString()));
			Assert.That(result.ImageUrl, Is.EqualTo(mountaineer.ImageUrl));
		}

		[Test]
		public async Task EditGetAsync_ShouldGiveMountainGuideForEditWithoutAgency()
		{
			var mountainGuideForm = new MountainGuideAddViewModel
			{
				FirstName = "Бисер",
				LastName = "Бисеров",
				Email = "biser@gmail.com",
				Phone = "0895123456",
				Experience = 4,
				OwnerId = "0d59049e-81f2 - 48f1 - abb2 - a5fd09bc210f",
				Age = 29,
				ImageUrl = "https://i.pik.bg/news/326/660_5a4e3ddb77802504f456d107ec12255d.jpg",
			};

			await _service.AddAsync(mountainGuideForm);

			var mountaineer = await _service.DetailsAsync(2);
			var result = await _service.EditGetAsync(2);
			Assert.AreEqual(null,result.TourAgencyId );
			Assert.IsNotNull(result);
			Assert.That(result.Id, Is.EqualTo(mountaineer.Id));
			Assert.That(result.FirstName, Is.EqualTo(mountaineer.FirstName));
			Assert.That(result.LastName, Is.EqualTo(mountaineer.LastName));
			Assert.That(result.Email, Is.EqualTo(mountaineer.Email));
			Assert.That(result.Phone, Is.EqualTo(mountaineer.Phone));
			Assert.That(result.Experience, Is.EqualTo(mountaineer.Experience));
			Assert.That(result.OwnerId, Is.EqualTo(mountaineer.OwnerId));
			Assert.That(result.Age.ToString(), Is.EqualTo(mountaineer.Age.ToString()));
			Assert.That(result.ImageUrl, Is.EqualTo(mountaineer.ImageUrl));
		}

		[Test]
		public async Task EditPostAsync_ShouldEditMountainGuide()
		{
			var mountainGuideForm = new MountainGuideEditViewModel
			{
				Id = 1,
				Email = "climber@mail.com",
				Experience = 7,
				FirstName = "Илия",
				LastName = "Петканов",
				Phone = "0895143451",
				Age = 33,
				ImageUrl = "https://i.pik.bg/news/326/660_5a4e3ddb77802504f456d107ec12255d.jpg",
				TourAgencyId = 1,
				OwnerId = "0d59049e-81f2-48f1-abb2-a5fd09bc210f",
			};

			await _service.EditPostAsync(mountainGuideForm);

			var result = await this._service.DetailsAsync(1);

			Assert.IsNotNull(result);
			Assert.That(mountainGuideForm.Id, Is.EqualTo(result.Id));
			Assert.That(mountainGuideForm.FirstName, Is.EqualTo(result.FirstName));
			Assert.That(mountainGuideForm.LastName, Is.EqualTo(result.LastName));
			Assert.That(mountainGuideForm.Email, Is.EqualTo(result.Email));
			Assert.That(mountainGuideForm.Phone, Is.EqualTo(result.Phone));
			Assert.That(mountainGuideForm.Experience, Is.EqualTo(result.Experience));
			Assert.That(mountainGuideForm.TourAgencyId, Is.EqualTo(result.TourAgencyId));
			Assert.That(mountainGuideForm.OwnerId, Is.EqualTo(result.OwnerId));
			Assert.That(mountainGuideForm.Age.ToString(), Is.EqualTo(result.Age.ToString()));
			Assert.That(mountainGuideForm.ImageUrl, Is.EqualTo(result.ImageUrl));
		}

		[Test]
		public async Task GetAllMountainsAsync_ShouldReturnAllMountains()
		{
			var result = await _service.GetAllMountainsAsync(1);

			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task GetAllMountainsAsync_ShouldReturnEmptyCollection()
		{
			var mountainGuideForm = new MountainGuideAddViewModel
			{
				FirstName = "Бисер",
				LastName = "Бисеров",
				Email = "biser@gmail.com",
				Phone = "0895123456",
				Experience = 4,
				TourAgencyId = 1,
				OwnerId = "0d59049e-81f2 - 48f1 - abb2 - a5fd09bc210f",
				Age = 29,
				ImageUrl = "https://i.pik.bg/news/326/660_5a4e3ddb77802504f456d107ec12255d.jpg",
			};

			await _service.AddAsync(mountainGuideForm);

			var result = await _service.GetAllMountainsAsync(2);

			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public async Task GetAllRoutesAsync_ShouldReturnAllRoutes()
		{
			var result = await _service.GetAllRoutesAsync(1);

			Assert.That(result.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task GetAllRoutesAsync_ShouldReturnEmptyCollection()
		{
			var mountainGuideForm = new MountainGuideAddViewModel
			{
				FirstName = "Бисер",
				LastName = "Бисеров",
				Email = "biser@gmail.com",
				Phone = "0895123456",
				Experience = 4,
				TourAgencyId = 1,
				OwnerId = "0d59049e-81f2 - 48f1 - abb2 - a5fd09bc210f",
				Age = 29,
				ImageUrl = "https://i.pik.bg/news/326/660_5a4e3ddb77802504f456d107ec12255d.jpg",
			};

			await _service.AddAsync(mountainGuideForm);

			var result = await _service.GetAllRoutesAsync(2);

			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public async Task GetMountainGuideAddRouteAsync_ShouldReturnAllRoutes()
		{
			var result = await _service.GetMountainGuideAddRouteAsync(1);

			Assert.That(result.Routes.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task GetMountainGuideAddRouteAsync_ShouldReturnNullIfGuideIsNull()
		{
			var result = await _service.GetMountainGuideAddRouteAsync(2);

			Assert.IsNull(result);
		}


		[Test]
		public async Task GetMountainGuideAddMountainAsync_ShouldReturnAllMountains()
		{
			var result = await _service.GetMountainGuideAddMountainAsync(1);

			Assert.That(result.Mountains.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task GetMountainGuideAddMountainAsync_ShouldReturnNullIfGuideIsNull()
		{
			var result = await _service.GetMountainGuideAddMountainAsync(2);

			Assert.IsNull(result);
		}
	}
}
