namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class LoyaltyItemListFile : CapabilityFile
    {
        public LoyaltyItemListFile()
            : base()
        {
        }
        public LoyaltyItemListFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.LoyaltyItemList, creator)
        {
        }
    }
}
