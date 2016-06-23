using System;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Models
{
    public abstract class CapabilityViewModel
    {
        public int CapabilityId { get; set; }
        public int AssortmentId { get; set; }
        public string AssortmentName { get; set; }
        public int Department { get; set; }
        public int StatusCode { get; set;  }
        public int CapabilityTypeCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public CapabilityViewModel(Capability c)
        {
            CapabilityId = c.Id;
            AssortmentId = c.AssortmentAnalysis.Id;
            AssortmentName = c.AssortmentAnalysis.Name;
            Department = c.AssortmentAnalysis.Department;
            StatusCode = c.Status.Code;
            CreatedBy = c.Creator;
            CreatedOn = c.Created;
            UpdatedBy = c.LastChangedBy;
            UpdatedOn = c.LastChanged;
        }
    }
}