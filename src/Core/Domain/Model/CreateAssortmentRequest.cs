using System;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public class CreateAssortmentRequest
    {
        public string Name { get; set; }

        public int Department { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public short RollUpTypeCode { get; set; }

        public string ItemList { get; set; }

        public byte[] GetItemListAsBytes()
        {
            return Convert.FromBase64String(ItemList);
        }
    }
}
