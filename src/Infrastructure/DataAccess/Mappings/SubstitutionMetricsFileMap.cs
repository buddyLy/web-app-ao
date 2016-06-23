using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class SubstitutionMetricsFileMap : SubclassMap<SubstitutionMetricsFile>
    {
        public SubstitutionMetricsFileMap()
        {
            DiscriminatorValue(501);
        }
    }
}
