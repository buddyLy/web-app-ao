using Newtonsoft.Json;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages
{
    [JsonObject]
    public class LoyaltyMessage : CapabilityMessage
    {
        public LoyaltyMessage(LoyaltyReport loyalty)
            : base(loyalty)
        {
            LoyaltyLevel = loyalty.LoyaltyLevel.Value;
            UseClustering = System.Convert.ToBoolean(loyalty.UseClustering.Value);
            CapabilityCode = 4;
        }

        [JsonProperty]
        public string LoyaltyLevel { get; set; }

        [JsonProperty]
        public bool UseClustering { get; set; }
    }
}
