namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public class DiagnosticItemListFile : CapabilityFile
	{
		public DiagnosticItemListFile() : base() { }
		public DiagnosticItemListFile(byte[] file, string creator)
			: base(file, CapabilityFileTypes.DiagnosticItemList, creator)
		{
		}
	}
}
