namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class CdtAssortmentDescriptionFile : CapabilityFile
    {
        public CdtAssortmentDescriptionFile()
            : base()
        {
        }
        public CdtAssortmentDescriptionFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.CdtAssortmentDescription, creator)
        {
        }
    }
}
