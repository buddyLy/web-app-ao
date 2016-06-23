using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class SubstitutionMap : SubclassMap<Substitution>
    {
        public SubstitutionMap()
        {
            DiscriminatorValue("5");
        }
    }
}
