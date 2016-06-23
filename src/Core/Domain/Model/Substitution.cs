using System.Linq;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public class Substitution : Capability
	{
        public virtual SubstitutionItemListFile ItemList
        {
            get
            {
                return Files.OfType<SubstitutionItemListFile>().LastOrDefault();
            }
            set
            {
                AddCapabilityFile(value);
            }
        }


        public virtual bool MetricsExists
        {
            get
            {
                return Files.OfType<SubstitutionMetricsFile>().Any();
            }
        }

        public virtual SubstitutionMetricsFile Metrics
        {
            get
            {
                return Files.OfType<SubstitutionMetricsFile>().LastOrDefault();
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
				return "Sub";
			}
		}

        public Substitution()
            : base()
        {
        }

        public Substitution(CreateSubstitutionRequest req, string createdBy, Status status)
            : base(createdBy, status)
        {
            var file = new SubstitutionItemListFile(req.GetItemListAsBytes(), createdBy);
            ItemList = file;
        }
	}
}
