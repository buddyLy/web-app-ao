using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class CdtItemMetricsFileMap : SubclassMap<CdtItemMetricsFile>
    {
        public CdtItemMetricsFileMap()
        {
            DiscriminatorValue(201);
        }
    }
}
