using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DataAccess.Mappings
{
    public class CapabilityParameterValueMap : TrackedEntityMap<CapabilityParameterValue>
    {
        public CapabilityParameterValueMap()
        {
            Table("assort_capability_parm");
            CompositeId()
                .KeyReference(x => x.Capability, "assort_capability_id")
                .KeyReference(x => x.Parameter, "parameter_id");
            Map(x => x.Value, "parameter_val");
        }

    }
}
