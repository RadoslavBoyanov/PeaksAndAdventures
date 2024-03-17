using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PeaksAndAdventures.ModelBinders
{
	public class DecimalModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder? GetBinder(ModelBinderProviderContext context)
		{
			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			if (context.Metadata.ModelType == typeof(Decimal) || context.Metadata.ModelType == typeof(Decimal?))
			{
				return new DecimalModelBinder();
			}

			return null;
		}
	}
}
