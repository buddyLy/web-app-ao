using System;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Models
{
    public class AssortmentViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Department { get; set; }

        public string Creator { get; set; }

        public string CreateTime { get; set; }

        public string LastChangedBy { get; set; }

        public DateTime LastChangedTime { get; set; }

		public string Status { get; set; }
		public AssortmentViewModel(AssortmentAnalysis analysis)
		{
			Id = analysis.Id;
			Department = analysis.Department;
			Name = analysis.Name;
			Creator = analysis.Creator;
            CreateTime = analysis.Created.ToString("MM/dd/yyyy");//analysis.Created.ToShortDateString();
			LastChangedBy = analysis.LastChangedBy;
			LastChangedTime = analysis.LastChanged;
			Status = analysis.Status;
		}
    }
}