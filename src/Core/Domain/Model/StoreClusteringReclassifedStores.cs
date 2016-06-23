namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class StoreClusteringReclassifedStoresFile : CapabilityFile
    {
        public StoreClusteringReclassifedStoresFile()
            : base()
        {
        }
        public StoreClusteringReclassifedStoresFile(byte[] file, string createdBy)
            : base(file, CapabilityFileTypes.StoreClusteringReclassifedStores, createdBy)
        {
        }
    }
}
