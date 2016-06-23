using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Models
{
    public class ClusteringViewModel : CapabilityViewModel
    {
        public bool ReclassifiedStoresExists { get; set; }

        public bool ModelSummaryExists { get; set; }

        public ClusteringViewModel(StoreClustering cluster)
            : base(cluster)
        {
            ReclassifiedStoresExists = cluster.ReclassifedStoresFileExists;
            ModelSummaryExists = cluster.ModelSummaryFileExists;
        }
    }
}