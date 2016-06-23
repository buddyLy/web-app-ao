using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class LoyaltyStoreClusteringFileMap : SubclassMap<LoyaltyStoreClusteringFile>
    {
        public LoyaltyStoreClusteringFileMap()
        {
            DiscriminatorValue(401);
        }
    }
}
