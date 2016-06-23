using System;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.UnitTests.StaticMocks
{
    public static class CapabilityMocker
    {
        private const int AssortId = 1234;

        public static DecisionTree GetDecisionTree()
        {
            var req = new CreateDecisionTreeRequest()
            {
                AssortmentID = AssortId
            };
            var cdt = new DecisionTree(req, "tester", CapabilityStatus.Waiting);
            return cdt;
        }

        public static StoreClustering GetStoreClustering()
        {
            var req = new CreateStoreClusteringRequest()
            {
                AssortmentID = AssortId,
                StoreList = FileMocker.GetFileString("sample.csv")
            };
            var storeCluster = new StoreClustering(req, "tester", CapabilityStatus.Waiting);
            return storeCluster;
        }

        public static LoyaltyReport GetLoyalty()
        {
            var req = new CreateLoyaltyReportRequest()
            {
                AssortmentID = AssortId,
                ItemList = FileMocker.GetFileString("sample.csv"),
                LoyaltyLevel = "Item",
                StoreClustering = FileMocker.GetFileString("sample.csv"),
                UseClustering = true
            };
            var loyalty = new LoyaltyReport(req, "tester", CapabilityStatus.Waiting);
            return loyalty;
        }

        public static Substitution GetSubstitution()
        {
            var req = new CreateSubstitutionRequest()
            {
                AssortmentID = AssortId,
                ItemList = FileMocker.GetFileString("sample.csv"),
            };
            var sub = new Substitution(req, "tester", CapabilityStatus.Waiting);
            return sub;
        }
    }
}
