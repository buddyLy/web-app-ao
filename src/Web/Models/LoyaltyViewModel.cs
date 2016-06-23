using System;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Models
{
    public class LoyaltyViewModel : CapabilityViewModel
    {
        public bool LoyaltyMetricsExist { get; set; }

        public string LoyaltyLevel { get; set; }

        public bool UseClustering { get; set; }

        public LoyaltyViewModel(LoyaltyReport loyalty)
            : base(loyalty)
        {
            LoyaltyLevel = loyalty.LoyaltyLevel.Value;
            UseClustering = Convert.ToBoolean(loyalty.UseClustering.Value);
            LoyaltyMetricsExist = loyalty.MetricsExists;
        }
    }
}