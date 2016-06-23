using System;
using System.Linq;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class LoyaltyReport : Capability
	{
        public virtual CapabilityParameterValue LoyaltyLevel
        {
            get
            {
                return Parameters.LastOrDefault(x => x.Parameter.Id == CapabilityParameterTypes.LoyaltyLevel.Id);
            }
            set
            {
                SetCapabilityParameterValue(value);
            }
        }

        public virtual CapabilityParameterValue UseClustering
        {
            get
            {
                return Parameters.LastOrDefault(x => x.Parameter.Id == CapabilityParameterTypes.LoyaltyUseClustering.Id);
            }
            set
            {
                SetCapabilityParameterValue(value);
            }
        }


        public virtual LoyaltyItemListFile ItemList
        {
            get
            {
                return Files.OfType<LoyaltyItemListFile>().LastOrDefault();
            }
            set
            {
                AddCapabilityFile(value);
            }
        }

        public virtual LoyaltyStoreClusteringFile StoreClustering
        {
            get
            {
                return Files.OfType<LoyaltyStoreClusteringFile>().LastOrDefault();
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
                return Files.OfType<LoyaltyMetricsFile>().Any();
            }
        }

        public virtual LoyaltyMetricsFile Metrics
        {
            get
            {
                return Files.OfType<LoyaltyMetricsFile>().LastOrDefault();
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
				return "Loyalty";
			}
		}

        public LoyaltyReport()
            : base ()
        {
        }

        public LoyaltyReport(CreateLoyaltyReportRequest req, string createdBy, Status status)
            : base(createdBy, status)
        {
            var items = new LoyaltyItemListFile(req.GetItemListAsBytes(), createdBy);
            ItemList = items;

            LoyaltyLevel = new CapabilityParameterValue(CapabilityParameterTypes.LoyaltyLevel, req.LoyaltyLevel, createdBy);
            UseClustering = new CapabilityParameterValue(CapabilityParameterTypes.LoyaltyUseClustering, Convert.ToString(req.UseClustering).ToUpperInvariant(), createdBy);

            if (!req.UseClustering) return;
            var storeCluster = new LoyaltyStoreClusteringFile(req.GetItemListAsBytes(), createdBy);
            StoreClustering = storeCluster;
        }
	}
}
