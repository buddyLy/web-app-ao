using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class RollupLevelLocalizationMap : ClassMap<RollupLevelLocalization>
	{
		public RollupLevelLocalizationMap()
		{
			Table("roll_up_type_txt");
			CompositeId()
				.KeyProperty(x => x.Code, "roll_up_type_code")
				.KeyProperty(x => x.LanguageCode, "language_code");
			Map(x => x.Description, "roll_up_type_desc");
		}
	}
}
