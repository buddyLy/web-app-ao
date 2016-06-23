using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class LoyaltyMetricsFileMap : SubclassMap<LoyaltyMetricsFile>
    {
        public LoyaltyMetricsFileMap()
        {
            DiscriminatorValue(402);
        }
    }
}
