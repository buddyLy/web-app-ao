using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Models
{
    public class DecisionTreeViewModel : CapabilityViewModel
    {
        public bool YulesQMatrixExists { get; set; }

        public bool ItemMetricsExists { get; set; }

        public bool AssortmentDescriptionExists { get; set; }

        public DecisionTreeViewModel(DecisionTree cdt)
            :base(cdt)
        {
            YulesQMatrixExists = cdt.YulesQMatrixExists;
            ItemMetricsExists = cdt.ItemMetricsExists;
            AssortmentDescriptionExists = cdt.AssortmentDescriptionExists;
        }
    }
}