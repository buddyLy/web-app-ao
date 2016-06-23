namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public class DiagnosticResultsFile : CapabilityFile
	{
		public DiagnosticResultsFile() : base() { }
		public DiagnosticResultsFile(byte[] file, string creator)
			: base(file, CapabilityFileTypes.DiagnosticResults, creator) { }
	}
}