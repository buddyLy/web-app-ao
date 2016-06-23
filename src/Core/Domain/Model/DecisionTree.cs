using System.Linq;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public class DecisionTree : Capability
	{
        public virtual bool YulesQMatrixExists
        {
            get
            {
                var files = Files.ToList();
                return files.OfType<CdtYulesQMatrixFile>().Any();
            }
        }

        public virtual CdtYulesQMatrixFile YulesQMatrix
        {
            get
            {
                return Files.OfType<CdtYulesQMatrixFile>().LastOrDefault();
            }
            set
            {
                AddCapabilityFile(value);
            }
        }

        public virtual bool ItemMetricsExists
        {
            get
            {
                var files = Files.ToList();
                return files.OfType<CdtItemMetricsFile>().Any();
            }
        }

        public virtual CdtItemMetricsFile ItemMetrics
        {
            get
            {
                return Files.OfType<CdtItemMetricsFile>().LastOrDefault();
            }
            set
            {
                AddCapabilityFile(value);
            }
        }

        public virtual bool AssortmentDescriptionExists
        {
            get
            {
                var files = Files.ToList();
                return files.OfType<CdtAssortmentDescriptionFile>().Any();
            }
        }

        public virtual CdtAssortmentDescriptionFile AssortmentDescription
        {
            get
            {
                return Files.OfType<CdtAssortmentDescriptionFile>().LastOrDefault();
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
				return "CDT";
			}
		}

        public DecisionTree()
            :base()
        {
        }

        public DecisionTree(CreateDecisionTreeRequest req, string createdBy, Status status)
            : base(createdBy, status)
        {
            
        }

	}
}
