using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class StatusLocalizationMap : ClassMap<StatusLocalization>
	{
		public StatusLocalizationMap()
		{
			Table("capability_status_txt");
			CompositeId()
				.KeyProperty(x => x.Code, "capability_status_code")
				.KeyProperty(x => x.LanguageCode, "language_code");
			Map(x => x.Description, "capability_status_desc");

		}
	}
}
