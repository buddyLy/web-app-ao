using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class StatusMap : ClassMap<Status>
	{
		public StatusMap()
		{
			Table("capability_status");
			Id(x => x.Code, "capability_status_code");
			HasMany(x => x.Localizations)
				.KeyColumn("capability_status_code")
				.Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
				.Inverse().Cascade.AllDeleteOrphan();
		}
	}
}
