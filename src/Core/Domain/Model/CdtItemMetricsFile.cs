namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class CdtItemMetricsFile : CapabilityFile
    {
        public CdtItemMetricsFile()
            : base()
        {
        }
        public CdtItemMetricsFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.CdtItemMetrics, creator)
        {
        }
    }
}
