using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
	public class DiagnosticItemListFileMap : SubclassMap<DiagnosticItemListFile>
	{
		public DiagnosticItemListFileMap()
		{
			DiscriminatorValue(100);
		}
	}
}
