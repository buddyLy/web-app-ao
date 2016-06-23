using System;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class CreateStoreClusteringRequest
    {
        public int AssortmentID { get; set; }
        public string StoreList { get; set; }
        public byte[] GetStoreListAsBytes()
        {
            return Convert.FromBase64String(StoreList);
        }
    }
}
