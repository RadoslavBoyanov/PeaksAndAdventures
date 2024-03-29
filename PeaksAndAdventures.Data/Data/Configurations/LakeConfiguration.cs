﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class LakeConfiguration : IEntityTypeConfiguration<Lake>
    {
        public void Configure(EntityTypeBuilder<Lake> builder)
        {
            builder.HasData(GenerateLakes());
        }

        private Lake[] GenerateLakes()
        {
            ICollection<Lake> lakes = new HashSet<Lake>();

            lakes.Add(new Lake()
            {
                Id = 1,
                Name = "Горно Полежанско",
                Description = "Смята се, че е Горното Полежанско езеро (2710 м), въпреки че има различни измервания и спор дали е то или Леденото езеро в Рила планина.Горно Полежанското езеро се намира в Северен Пирин на 2710 м н.в. под връх Полежан. То е част от езерната група на Полежанските езера, които са три на брой. Често през сухите лета няма да го видите, защото то пресъхва.",
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/08/MANE3567-1-1024x683.jpg",
                MountainId = 3
            });

            lakes.Add(new Lake()
            {
                Id = 2,
                Name = "Страшното езеро",
                Description = "Езерото е дълго 200 m, широко 75 m и дълбоко до 2 m, а площта му е 14,4 дка. То е най-голямото и най-високо разположеното от езерата в Прекоречкия циркус на Мальовишкия дял. Оттича се на север, към долината на Горна (Трета) Прека река.Вдълбано е в подножието на връх Попова капа и Купените. Техните надвиснали скали създават забележителна акустика, която при буря отразява многогласно гръмотевиците.",
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/09/DSCF4676-1024x683.webp",
                MountainId = 2
            });

            lakes.Add(new Lake()
            {
                Id = 3, 
                Name = "Синанишко",
                Description = "Синанишкото езеро (Голямо Синивръшко езеро) е езеро в западния склон на Северен Пирин, разположено в дълбок циркус на 650 m на север-североизток от връх Синаница (Сини връх), на 2181 m н.в. Със своите 11,5 m дълбочина то е сред 10-те най-дълбоки езера в Пирин.Има продълговата форма (140 на 90 m) и площ от 1,01 ha. Оттича се подземно, но водите му излизат на повърхността след 120 m и дават началото на Синанишката река, ляв приток на река Влахинска река, ляв приток на Струма. На северния бряг на езерото е изградена хижа Синаница.",
                ImageUrl = "https://planinka.bg/wp-content/uploads/2022/09/DSCF1129-1024x683.webp",
                MountainId = 3
            });

            return lakes.ToArray();
        }
    }
}
