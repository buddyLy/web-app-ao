using Newtonsoft.Json;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages
{
    [JsonObject]
    public class DiagnosticMessage : CapabilityMessage
    {
        public DiagnosticMessage(Diagnostic diagnostic)
            : base(diagnostic)
        {
            CapabilityCode = 1;
            RollUpTypeCode = diagnostic.AssortmentAnalysis.Rollup.Code;
        }
        [JsonProperty]
        public int RollUpTypeCode {get ; set; }
    }
}
