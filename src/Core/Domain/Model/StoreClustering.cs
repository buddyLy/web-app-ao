using System.Linq;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
	public class StoreClustering : Capability
	{
        public virtual StoreClusteringStoresListFile StoreList
        {
            get
            {
                return Files.OfType<StoreClusteringStoresListFile>().LastOrDefault();
            }
            set
            {
                AddCapabilityFile(value);
            }
        }

        public virtual bool ReclassifedStoresFileExists
        {
            get
            {
                return Files.OfType<StoreClusteringReclassifedStoresFile>().Any();
            }
        }

        public virtual StoreClusteringReclassifedStoresFile ReclassifedStores
        {
            get
            {
                return Files.OfType<StoreClusteringReclassifedStoresFile>().LastOrDefault();
            }
            set
            {
                AddCapabilityFile(value);
            }
        }

        public virtual bool ModelSummaryFileExists
        {
            get
            {
                return Files.OfType<StoreClusteringModelSummaryFile>().Any();
            }
        }

        public virtual StoreClusteringModelSummaryFile ModelSummary
        {
            get
            {
                return Files.OfType<StoreClusteringModelSummaryFile>().FirstOrDefault();
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
				return "Cluster";
			}
		}

        public StoreClustering()
            : base()
        {
        }

        public StoreClustering(CreateStoreClusteringRequest req, string createdBy, Status status)
            : base(createdBy, status)
        {
            var file = new StoreClusteringStoresListFile(req.GetStoreListAsBytes(), createdBy);
            StoreList = file;
        }
	}
}
