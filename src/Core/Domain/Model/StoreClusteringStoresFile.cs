namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class StoreClusteringStoresListFile : CapabilityFile
    {
        public StoreClusteringStoresListFile()
            : base()
        {
        }
        public StoreClusteringStoresListFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.StoreClusteringStoresList, creator)
        {
        }
    }
}
