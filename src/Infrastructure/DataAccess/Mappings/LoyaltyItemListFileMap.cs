using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class LoyaltyItemListFileMap : SubclassMap<LoyaltyItemListFile>
    {
        public LoyaltyItemListFileMap()
        {
            DiscriminatorValue(400);
        }
    }
}
