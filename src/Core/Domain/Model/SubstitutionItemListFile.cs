namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class SubstitutionItemListFile : CapabilityFile
    {
        public SubstitutionItemListFile()
            : base()
        {
        }
        public SubstitutionItemListFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.SubstitutionItemList, creator)
        {
        }
    }
}
