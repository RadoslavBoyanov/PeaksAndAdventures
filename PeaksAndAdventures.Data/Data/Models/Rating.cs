using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
	[Comment("Entity for ratings")]
	public class Rating
	{
		[Key]
		[Comment("Rating Id")]
		public int Id { get; set; }
	
		[Comment("Navigation property for route")]
		public int? RouteId { get; set; }
		[Comment("Rating entity type")]
		[ForeignKey(nameof(RouteId))]
		public Route? Route { get; set; }

		[Comment("Navigation property for tour agency")]
		public int? TourAgencyId { get; set; }
		[ForeignKey(nameof(TourAgencyId))]
		public TourAgency? TourAgency { get; set; }

		[Comment("Navigation property for mountain guide")]
		public int? MountainGuideId { get; set; }
		[ForeignKey(nameof(MountainGuideId))] 
		public MountainGuide? MountainGuide { get; set; }
		[Required]
		[Comment("Name of object")]
		public string Name { get; set; } = string.Empty;

		[NotMapped]
		public List<int> Values { get; set; } = new List<int>();

		[Column("Values")]
		[Comment("List of values")]
		public string ValuesSerialized
		{
			get => JsonConvert.SerializeObject(Values);
			set
			{
				if (value.StartsWith("[") && value.EndsWith("]"))
				{
					value = value.Substring(1, value.Length - 2); // премахваме първата и последната скоба
				}

				var valuesArray = value.Split(',')
					.Select(s =>
					{
						if (int.TryParse(s, out int intValue))
						{
							return intValue;
						}
						else
						{
							// Генериране на грешка или връщане на null за неправилните стойности
							throw new ArgumentException("Invalid value found in the input string.");
							// Или може да върнете null, ако списъка позволява нулеви стойности
							// return null;
						}
					})
					.ToList();
				Values = valuesArray;
			}
		}
	}
}
