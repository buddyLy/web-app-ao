using System.Collections.Generic;
using System.Linq;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public abstract class CodeType<T> : IEntity where T : Localization
	{
		public virtual short Code { get; set; }
		private IList<T> _localizations;
		public virtual IEnumerable<T> Localizations { get { return _localizations; } }

		//In the future this method can change to pass in the language code for 
		//international support, for now we will hardcode it -rlgrego
		public virtual string Description()
		{
			return _localizations.Where(x => x.LanguageCode == "101")
				.Select(x => x.Description)
				.FirstOrDefault();
		}

	}
}
