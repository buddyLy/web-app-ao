using FluentNHibernate.Mapping;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class CapabilityParameterMap : ClassMap<CapabilityParameter>
    {
        public CapabilityParameterMap()
        {
            Table("parameter");
            Id(x => x.Id, "parameter_id");
            Map(x => x.Name, "parameter_name");
        }
    }
}
