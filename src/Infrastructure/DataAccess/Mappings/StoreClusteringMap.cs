using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    class StoreClusteringMap : SubclassMap<StoreClustering>
    {
        public StoreClusteringMap()
        {
            DiscriminatorValue("3");
        }
    }
}
