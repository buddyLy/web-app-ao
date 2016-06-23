namespace Walmart.Assortment.AssortmentOptimizationSystem.Core.Domain.Model
{
    public static class CapabilityFileTypes
    {
        private const string CSV = @"text/csv";
        private const string PDF = @"application/pdf";
        public static readonly FileType DiagnosticItemList = new FileType {MIMEType = CSV, Code = 100};
        public static readonly FileType DiagnosticResults = new FileType {MIMEType = CSV, Code = 101};
        public static readonly FileType CdtYulesQMatrix = new FileType {MIMEType = CSV, Code = 200};
        public static readonly FileType CdtItemMetrics = new FileType {MIMEType = CSV, Code = 201};
        public static readonly FileType CdtAssortmentDescription = new FileType {MIMEType = CSV, Code = 202};
        public static readonly FileType StoreClusteringStoresList = new FileType {MIMEType = CSV, Code = 300};
        public static readonly FileType StoreClusteringReclassifedStores = new FileType {MIMEType = CSV, Code = 301};
        public static readonly FileType StoreClusteringModelSummary = new FileType {MIMEType = CSV, Code = 302};
        public static readonly FileType LoyaltyItemList = new FileType {MIMEType = CSV, Code = 400};
        public static readonly FileType LoyaltyStoreClustering = new FileType {MIMEType = CSV, Code = 401};
        public static readonly FileType LoyaltyMetrics = new FileType {MIMEType = CSV, Code = 402};
        public static readonly FileType SubstitutionItemList = new FileType {MIMEType = CSV, Code = 500};
        public static readonly FileType SubstitutionMetrics = new FileType {MIMEType = CSV, Code = 501};
    }
}