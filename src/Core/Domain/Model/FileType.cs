namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public class FileType : CodeType<FileTypeLocalization>
	{
		public virtual string MIMEType { get; set; }
	}
}
