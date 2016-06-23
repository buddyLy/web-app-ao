using System;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Models
{
    public class DiagnosticViewModel : CapabilityViewModel
    {
        public short RollupCode { get; set; }
        public string RollupName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool DiagnosticResultsExists { get; set; }

        public DiagnosticViewModel(Diagnostic diagnostic)
            :base(diagnostic)
        {
            CapabilityTypeCode = 1;
            RollupCode = diagnostic.AssortmentAnalysis.Rollup.Code;
            RollupName = diagnostic.AssortmentAnalysis.Rollup.Description();
            StartDate = diagnostic.AssortmentAnalysis.StartDate;
            EndDate = diagnostic.AssortmentAnalysis.EndDate;
            DiagnosticResultsExists = diagnostic.DiagnosticResultsExists;
        }
    }
}