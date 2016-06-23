using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class StoreClusteringReclassifedStoresMap : SubclassMap<StoreClusteringReclassifedStoresFile>
    {
        public StoreClusteringReclassifedStoresMap()
        {
            DiscriminatorValue(301);
        }
    }
}
