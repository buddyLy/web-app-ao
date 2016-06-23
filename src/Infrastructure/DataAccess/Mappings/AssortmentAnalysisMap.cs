using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class AssortmentAnalysisMap : TrackedEntityMap<AssortmentAnalysis>
	{
		public AssortmentAnalysisMap()
		{
			Table("assortment");
			Id(x => x.Id, "assortment_id").GeneratedBy.Sequence("assortment_id_seq");
			Map(x => x.Name, "assortment_name");
			Map(x => x.StartDate, "start_date");
			Map(x => x.EndDate, "end_date");
			Map(x => x.Department, "dept_nbr");
			References(x => x.Rollup, "roll_up_type_code");
			HasMany(x => x.Capabilities)
				.KeyColumn("assortment_id")
				.Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
				.Inverse().Cascade.AllDeleteOrphan();
		}
	}
}
