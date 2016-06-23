using Newtonsoft.Json;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages
{
    [JsonObject]
    public class SubstitutionMessage : CapabilityMessage
    {
        public SubstitutionMessage(Substitution sub)
            : base(sub)
        {
            CapabilityCode = 5;
        }
    }
}
