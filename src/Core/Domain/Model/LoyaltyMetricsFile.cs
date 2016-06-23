namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class LoyaltyMetricsFile : CapabilityFile
    {
        public LoyaltyMetricsFile()
            : base()
        {
        }
        public LoyaltyMetricsFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.LoyaltyMetrics, creator)
        {
        }
    }
}
