using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public static class CapabilityParameterTypes
    {
        public static CapabilityParameter LoyaltyLevel =
            new CapabilityParameter() { Id = 400 };

        public static CapabilityParameter LoyaltyUseClustering =
            new CapabilityParameter() { Id = 401 };
    }
}
