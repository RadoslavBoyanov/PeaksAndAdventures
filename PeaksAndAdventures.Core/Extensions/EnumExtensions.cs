using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PeaksAndAdventures.Extensions
{
	public static class EnumExtensions
	{
		public static string GetDisplayName(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			if (field == null) return null;

			DisplayAttribute attribute = field.GetCustomAttribute<DisplayAttribute>();
			return attribute?.GetName() ?? value.ToString();
		}
	}
}
