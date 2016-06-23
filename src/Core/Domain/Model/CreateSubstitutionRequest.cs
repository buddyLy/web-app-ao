using System;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class CreateSubstitutionRequest
    {
        public int AssortmentID { get; set; }

        public string ItemList { get; set; }

        public byte[] GetItemListAsBytes()
        {
            return Convert.FromBase64String(ItemList);
        }

    }
}
