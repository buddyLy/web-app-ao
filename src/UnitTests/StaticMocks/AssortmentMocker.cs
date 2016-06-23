using System;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.StaticMocks
{
    public static class AssortmentMocker
    {
        public static AssortmentAnalysis GetAssortment()
        {
            var assortment = new AssortmentAnalysis()
            {
                Id = 1001,
                Name = "TEST ASSORTMENT PLEASE IGNORE",
                Rollup = new RollupLevel() { Code = 1 },
                Creator = "tester",
                LastChangedBy = "tester",
                Created = DateTime.Now.AddDays(-2),
                LastChanged = DateTime.Now.AddDays(-2),
                Department = 12
            };
            return assortment;
        }
    }
}
