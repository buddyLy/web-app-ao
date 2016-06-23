using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Models
{
    public class SubstitutionViewModel : CapabilityViewModel
    {
        public bool SubstitutionMetricsExist { get; set; }

        public SubstitutionViewModel(Substitution sub)
            : base(sub)
        {
            SubstitutionMetricsExist = sub.MetricsExists;
        }
    }
}