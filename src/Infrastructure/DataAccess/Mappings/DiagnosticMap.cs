using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class DiagnosticMap : SubclassMap<Diagnostic>
	{
		public DiagnosticMap()
		{
			DiscriminatorValue("1");
			//References(x => x.Input, "assort_capability_id");
		}
	}
}
