namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{

    public class StoreClusteringModelSummaryFile : CapabilityFile
    {
        public StoreClusteringModelSummaryFile()
            : base()
        {
        }
        public StoreClusteringModelSummaryFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.StoreClusteringModelSummary, creator)
        {
        }
    }
}
