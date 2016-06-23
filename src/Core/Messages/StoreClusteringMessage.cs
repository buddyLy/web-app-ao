using Newtonsoft.Json;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages
{
    [JsonObject]
    public class StoreClusteringMessage : CapabilityMessage
    {
        public StoreClusteringMessage(StoreClustering cluster)
            : base(cluster)
        {
            CapabilityCode = 3;
        }
    }
}
