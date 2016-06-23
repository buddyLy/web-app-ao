namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class CdtYulesQMatrixFile : CapabilityFile
    {
        public CdtYulesQMatrixFile()
            : base()
        {
        }
        public CdtYulesQMatrixFile(byte[] file, string creator)
            : base(file, CapabilityFileTypes.CdtYulesQMatrix, creator)
        {
        }
    }
}
