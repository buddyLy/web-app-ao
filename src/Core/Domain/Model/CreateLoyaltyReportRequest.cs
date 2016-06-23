using System;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class CreateLoyaltyReportRequest
    {
        public int AssortmentID { get; set; }

        public string LoyaltyLevel { get; set; }

        public bool UseClustering { get; set; }

        public string ItemList { get; set; }

        public byte[] GetItemListAsBytes()
        {
            return Convert.FromBase64String(ItemList);
        }

        public string StoreClustering { get; set; }

        public byte[] GetStoreClusteringAsBytes()
        {
            return Convert.FromBase64String(StoreClustering);
        } 
    }
}
