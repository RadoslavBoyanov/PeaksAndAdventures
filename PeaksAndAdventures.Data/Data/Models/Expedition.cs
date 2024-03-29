﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static PeaksAndAdventures.Common.EntityValidations.ExpeditionValidation;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Expedition entity model")]
    public class Expedition
    {
        [Key]
        [Comment("Expedition id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Name of expedition")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("People signed for expedition")]
        public int Enrolment { get; set; }

        [Required]
        [Column("Start date")]
        [Comment("Expedition start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column("End date")]
        [Comment("Expedition end date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Comment("Expedition durations in days")]
        public int Days { get; set; }

        [Required]
        [StringLength(ProgramMaxLength)]
        [Comment("Expedition program")]
        public string Program { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Expedition price")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(IncludesMaxLength)]
        [Comment("What services does the expedition include in the price")]
        public string Includes { get; set; } = string.Empty;

        [Required]
        [StringLength(ExcludesMaxLength)]
        [Comment("What services are not included in the shipping price")]
        public string Excludes { get; set; } = string.Empty;

        [Comment("What additional services can be included for an additional fee")]
        [StringLength(ExcludesMaxLength)]
        public string? Extras { get; set; }

        [Required]
        [Comment("Navigation property for tour agency")]
        public int TourAgencyId { get; set; }
        [ForeignKey(nameof(TourAgencyId))] 
        public TourAgency TourAgency { get; set; } = null!;

        [Required]
        [Comment("Navigation property for organiser of the expedition")]
        public string OrganiserId { get; set; } = string.Empty;
        [ForeignKey(nameof(OrganiserId))]
        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        [Comment("Navigation property for route")]
        public int RouteId { get; set; }
        [ForeignKey(nameof(RouteId))]
        public Route Route { get; set; } = null!;

        public ICollection<ExpeditionParticipant> ExpeditionsParticipants { get; set; } =
            new List<ExpeditionParticipant>();
    }
}
