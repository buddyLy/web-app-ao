using Newtonsoft.Json;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages
{
    [JsonObject]
    public class DecisionTreeMessage : CapabilityMessage
    {
        public DecisionTreeMessage(DecisionTree cdt) : base(cdt)
        {
            CapabilityCode = 2;
        }
    }
}
