namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class LoyaltyStoreClusteringFile : CapabilityFile
    {
        public LoyaltyStoreClusteringFile()
            : base()
        {
        }
        public LoyaltyStoreClusteringFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.LoyaltyStoreClustering, creator)
        {
        }
    }
}
