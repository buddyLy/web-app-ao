using System.Linq;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public class Diagnostic : Capability
	{
        public virtual DiagnosticItemListFile DiagnosticItemList
        {
            get
            {
                return Files.OfType<DiagnosticItemListFile>().FirstOrDefault();
            }
            set
            {
                AddCapabilityFile(value);
            }
        }

        public virtual bool DiagnosticResultsExists
        {
            get
            {
                return Files.Any(x => x.FileType.Code == CapabilityFileTypes.DiagnosticResults.Code);
            }
        }

        public virtual CapabilityFile DiagnosticResults
        {
            get
            {
                return Files.OfType<DiagnosticResultsFile>().FirstOrDefault();
            }
            set
            {
                AddCapabilityFile(value);
            }
        }

		public override string ShortName
		{
			get
			{
				return "Diag";
			}
		}

        public Diagnostic() : base()
        {
        }

        public Diagnostic(string createdBy, Status status, byte[] itemList)
            : base(createdBy, status)
        {
            var file = new DiagnosticItemListFile(itemList, createdBy);
            DiagnosticItemList = file;
        }
	}
}
