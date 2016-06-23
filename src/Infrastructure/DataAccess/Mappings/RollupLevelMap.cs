using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class RollupLevelMap : ClassMap<RollupLevel>
	{
		public RollupLevelMap()
		{
			Table("roll_up_type");
			Id(x => x.Code, "roll_up_type_code");
			HasMany(x => x.Localizations)
				.KeyColumn("roll_up_type_code")
				.Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
				.Cascade.AllDeleteOrphan();
		}
	}
}
