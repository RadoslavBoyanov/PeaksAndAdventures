﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //builder
            //    .HasOne(ta => ta.AuthorId)
            //    .WithMany()
            //    .HasForeignKey(ta => ta.AuthorId)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(GenerateArticles());
        }

        private Article[] GenerateArticles()
        {
            ICollection<Article> articles = new HashSet<Article>();

            articles.Add(new Article()
            {
                Id = 12,
                Title = "Хижите в България – условия, съвети и неписани правила",
                Content = "Може би много от вас са посещавали хижите в България. Условията в една хижа много зависят от нейната локация, поддръжка през годините и разбира се от хижарите. Има хижи, които се доближават до хотели – с много богато меню, самостоятелни стаи с тоалетни, бани с топла вода. Има и такива, които се спи в стая по 10 човека, само външна тоалетна и избор от две ястия. Нито едно от двете не изключва хижата да е много уютна с дружелюбни хижари и да си изкарате много хубаво.Все пак е важно преди да тръгнете на преход да сте наясно с условията на хижата, на която отивате, за да не бъдете изненадани или разочаровани. В следващите редове ще ви споделим някои от основните неща, които трябва да знаете за хижите в България. Важно е да уточним, че тези редове не се отнасят за всяка хижа.\r\nХрана: в много от случаите храната, която се предлага по-хижите се състои от супа като боб или леща, скара и салата.Закуската е често пържени филии, мекици или макарони.Понякога не се предлага обяд, случва се и храната да е свършила или да се сервира само в определени часове.За пиене се предлага вода, бира, кафе, чай и някаква газирана напитка.Има хижи и с много богато и разнообразно меню. Съвет: Носете се винаги храна с вас, за всеки случай.\r\nЛегловата база: в повечето хижи стаите са за 6,8,12 души.Стаите са общи (без значение от пола). Има хижи и с индивидуални стаи за по 2-ма, но се среща много рядко.В много от хижите леглата за двуетажни.Понякога стаята е с нарове (сковани дъски на разстояние от пода). Спи се един до друг.На прозорците няма комарници.В по-хладните вечери не винаги има отопление в стаите.Одеяла може да не са ви достатъчни, носете си дебели дрехи.Неписано правило е преди да напуснете стаята да съберете чаршафите от леглото – така помагате на хижарите.Съвет: Ако прецените може да си носите компактен чаршаф, както и спален чувал, ако искате да се чувствате по-комфортно. Прането и съхненето на чаршафите в повечето случаи е трудоемко за хижарите. Използвайки ваши чаршафи или спален чувал улеснявате тяхната работа.\r\nТоалетна: повечето тоалетни в хижите са общи.В никои хижи и заслони тоалетните са външни.Съвет: Носете си тоалетна хартия/кърпички. Моля, не ползвайте и не изхвърляйте мокри кърпи в природата!\r\nБаня:бъдете подготвени, че може и да не си вземете топъл душ след дълъг преход.Често на високопланинските хижи баня няма.Често се случва да чакате за ред.Топла вода може да няма или да е свършила.Почти винаги банята е обща (мъже и жени).В някои хижи има такса за използване на банята (2-3 лв.) Съвет: Не забравяйте да сложите в багажа компактна кърпа, сапун и джапанки.\r\nТок и обхват: в някои хижи се спира тока след 22:00 часа. До тогава е добре да сте се подготвили за следващия ден и вече да сте в леглата.Много често, особено във високопланинските хижи няма покритие на мобилните оператори. Понякога има определено място като камък, възвишение където се хваща обхват на определен оператор. Съветваме ви да попитате хижарите, те ще ви кажат.Съвет: Носете си външни батерии за телефона. Ако вие нямате обхват, проверете дали някой ваш приятел на друг мобилен оператор има.\r\nРезервиране на нощувка: хижата е място, в което винаги да можеш да намериш подслон и въпреки това в днешно време е почти задължително да се обадите, за да си запазите места в дадена хижа.Понякога е трудно да се свържем с хижарите заради липсата на обхват. Пробвайте няколко пъти да се обадите или пишете на Viber или SMS.Ако плановете ви се променят е важно да се обадите предварително и да кажете, че нощувката отпада, защото хижарите ще ви очакват и така пазят места, които могат да дадат на други хора.Съвет: В по-популярните хижи и особено през уикендите в летния сезон ви съветваме да направите резервация поне 2,3 седмици по-рано.\r\nЦени: цените по хижите често са по-високи отколкото може би очаквате. Споделяме ориентировъчни цени, за да знаете колко пари да си вземете и да не останете изненадани.\r\n\r\nНастаняване – 20 лв. – 40 лв.Супа – 2 лв. – 5 лв.Салата – 4 лв. – 8 лв.Скара – 2,50 лв. – 3,50 лв. / бр.Безалкохолно/ Бира – 3 лв. -5 лв.Чай/Кафе – 2 лв. – 3 лв.\r\nТакса за баня – 2 лв. – 3 лв.\r\nОще:в някои хижи трябва да се ходи без обувки, затова е добре да си носите чехли, ако ходенето боси ви притеснява.В повечето случаи след определен час не трябва да се вдига шум.Има хижи, в които вие трябва да си измиете посудата, която използвате.Старайте се да не оставяте боклуци в хижата, каквото можете вземете с вас.Възможно е в хижата да попаднете на някоя буболечка или животинка. На нас много рядко ни се е случвало до попадаме, но все пак имайте предвид, че не е е изключено, все пак се намирате сред природата.Ако сте на хижа, която е достъпна с кола, не се учудвайте ако попадне на парти със силна музика, особено през уикенда.Не забравяйте, че въпреки че си плащате за нощувка и храна, вие сте гости на хижата и трябва да се отнасяте с уважение към мястото и стопанина.",
                DatePublish = DateTime.Now.AddDays(-5),
                ImageUrl = "https://planinka.bg/wp-content/uploads/2023/09/DSCF1341-copy-683x1024.webp",
                AuthorId = "0d59049e-81f2-48f1-abb2-a5fd09bc210f",
            });

            articles.Add(new Article()
            {
                Id = 13,
                Title = "Как да се придвижвате в планината",
                Content = "1. Проучете маршрута преди да тръгнете\r\nМного важно е да сте запознати с маршрута преди да тръгнете. Проучете дължината, денивелацията и приблизителното времетраене. Преценете дали маршрутът е подходящ за вас и групата ви. Информирайте се дали има трудни и опасни участъци, има ли водоизточници по пътя и къде са най-близките хижи и заслони. Задължително проверете и следете метеорологичните условия.\r\n\r\n\r\n2. Не тръгвайте сами в планината\r\nНе тръгвате в планината сами дори за кратки, еднодневни преходи по познати маршрути. Инцидентите в планината не са за подценяване и винаги е добре да имате надежден спътник, който да повика помощ в случай на нужда.\r\n\r\n\r\n3. Уведомете близките си за прехода\r\nДобре е близките ви да са уведомени за планувания преход, предполагаемото пристигане и връщане. Регистрирането в хижите по маршрута ще помогне да бъдете локализирани при инцидент или загубване в планината.\r\n\r\n4. Тръгвайте винаги рано сутрин\r\nМного е важно да тръгнете рано сутрин. По време на прехода може да възникнат непредвидени ситуации, които да ви забавят, затова е важно да имате достатъчно време да пристигнете в светлата част на деня. Най-добре е по-голямата част от предвидения преход да се измине до обяд. През зимата планирайте достигането на целта си не по-късно от 15:00 часа.\r\n\r\n\r\n5. Движете се с умерено темпо\r\nТемпото на движение е много важно. За да не се задъхвате, наложете си постоянно, равномерно темпо. Забързаният ход с чести почивки ще ви умори повече. За да се настрои организмът ви към натоварването тръгнете бавно и постепенно усилвайте темпото, не спирайте рязко, а плавно намалете ритъма преди почивка. Старайте се да дишате равномерно и дълбоко.\r\n\r\n\r\n6. Съобразявайте скоростта на придвижване\r\nТемпото на движение е много важно. За да не се задъхвате, наложете си постоянно, равномерно Скоростта на придвижване зависи от денивелацията, сложността на терена и метеорологичните условия, но най-определяща е вашата собствена физическа форма. За да не се разкъсва групата, поддържайте темпо, съобразено с най-слабо подготвените участници.\r\n\r\n7. Не съкращавайте пътя за сметка на сигурността\r\nВодещо условие за избиране на маршрута е безопасността. Вземете под внимание структурата на терена (сипеи, ронливи скали, улеи, хлъзгави склонове), метеорологичните условия и дали хората във вашата група са в състояние да преминат маршрута.\r\n\r\n\r\n8. Пийте често, но по малко вода\r\nГолямото физическо натоварване ви кара да пиете повече вода заради усещането на сухота в гърлото. Не прекалявайте с водата при преход, защото това води до затрудняване на работата на бъбреците и сърцето, до обилно потене, при което организмът губи ценни соли. Най-добре е да пиете по няколко глътки на всяко спиране.",
                DatePublish = DateTime.Now.AddDays(-32),
                ImageUrl = "https://planinka.bg/wp-content/uploads/2023/05/MANE3457-1024x819.webp",
                AuthorId = "0d59049e-81f2-48f1-abb2-a5fd09bc210f"
			});

            articles.Add(new Article()
            {
                Id = 14,
                Title = "Слънцезащита в планината",
                Content = "В горещите дни бягаме в планината, за да намерим прохлада.\r\nИ все пак да не забравяме, че в планината слънцето е силно, затова слънцезащитата и хидратацията са изключително важни.\r\nЕто част от любимите ни продукти, които носим винаги с нас по време на преход:\r\nСлънчеви очила Clark на Тrevibulgaria. Освен, че са със 100% UV защита, лещите са минерални, което ги прави изключително устойчиви на надраскване.\r\nБъфовете на Bandittoheadware. Може да ги използвате като бъф или като кърпа, която да предпазава главата. Като три от основните им предимства са UV защитата, бързосъхнещи са и са изработени от рециклирани пластмасови бутилки.\r\nСлънцезащитния крем на Woodenspoon, който е със 100% натурални съставки. Серията Dry Oils е специално разработена със сухи натурални масла, за да не запушва порите.\r\nНикога не тръгваме на преход без вода. Дори и за кратка разходка е важно да бъдем хидратирани. Затова винаги носим с нас любимите бутилки за многократна употреба на Дизайница. Освен, че са леки и красиви, с тях спестяваме на планетата огромно количество пластмаса.",
                DatePublish = DateTime.Now.AddDays(-60),
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/07/DSCF0368-819x1024.webp",
                AuthorId = "0d59049e-81f2-48f1-abb2-a5fd09bc210f"
			});

        return articles.ToArray();
        }
    }
}
