namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class SubstitutionMetricsFile : CapabilityFile
    {
        public SubstitutionMetricsFile()
            : base()
        {
        }
        public SubstitutionMetricsFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.SubstitutionMetrics, creator)
        {
        }
    }
}
