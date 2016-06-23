using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class CdtYulesQMatrixFileMap : SubclassMap<CdtYulesQMatrixFile>
    {
        public CdtYulesQMatrixFileMap()
        {
            DiscriminatorValue(200);
        }
    }
}
