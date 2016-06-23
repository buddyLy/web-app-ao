using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class CdtAssortmentDescriptionFileMap : SubclassMap<CdtAssortmentDescriptionFile>
    {
        public CdtAssortmentDescriptionFileMap()
		{
			DiscriminatorValue(202);
		}
    }
}
