using Newtonsoft.Json;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages
{
    [JsonObject]
    public abstract class CapabilityMessage
    {
        protected CapabilityMessage(Capability c)
        {
            AssortmentName = c.AssortmentAnalysis.Name;
            AssortmentId = c.AssortmentAnalysis.Id;
            CapabilityCode = CapabilityCode;
            AssortCapabilityId = c.Id;
            CreateUserId = c.Creator;
        }
        [JsonProperty]
        public string AssortmentName { get; protected set; }

        [JsonProperty]
        public int AssortmentId { get; protected set; }

        [JsonProperty]
         public int CapabilityCode { get; protected set; }

        [JsonProperty]
        public int AssortCapabilityId { get; protected set; }

        [JsonProperty]
        public string CreateUserId { get; protected set; }
    }
}
