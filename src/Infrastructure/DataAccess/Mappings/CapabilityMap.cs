using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class CapabilityMap : TrackedEntityMap<Capability>
	{
		public CapabilityMap()
		{
			Table("assort_capability");
			DiscriminateSubClassesOnColumn("capability_code").AlwaysSelectWithValue();
			Id(x => x.Id, "assort_capability_id").GeneratedBy.Sequence("assort_capability_id_seq");
			References(x => x.AssortmentAnalysis, "assortment_id");
			References(x => x.Status, "capability_status_code");
			Map(x => x.StatusMessage, "capability_status_msg_txt");
            HasMany(x => x.Files)
                .KeyColumn("assort_capability_id")
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                .Inverse().Cascade.AllDeleteOrphan();
            HasMany(x => x.Parameters)
                .KeyColumn("assort_capability_id")
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                .Inverse().Cascade.AllDeleteOrphan();
		}
	}
}
