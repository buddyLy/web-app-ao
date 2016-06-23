using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class LoyaltyReportMap : SubclassMap<LoyaltyReport>
    {
        public LoyaltyReportMap()
        {
            DiscriminatorValue("4");
        }
    }
}
