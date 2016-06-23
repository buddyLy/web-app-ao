using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class DecisionTreeMap : SubclassMap<DecisionTree>
    {
        public DecisionTreeMap()
        {
            DiscriminatorValue("2");
        }
    }
}
