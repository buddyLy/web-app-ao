using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class DiagnosticResultsFileMap : SubclassMap<DiagnosticResultsFile>
	{
		public DiagnosticResultsFileMap()
		{
			DiscriminatorValue(101);
		}
	}
}
