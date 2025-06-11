namespace ItlaincenstmentApp.Core.Domain.Entities
{
    public class InvestmentAssets
    {
        public required int AssetId { get; set; } // FK Asset
        public Asset? Assets { get; set; } // Navigation Propertie

        public required int InvestmentPorfolioId { get; set; }// FK Investment
        public InvestmentPorfolio? InvestmentPorfolio { get; set; } // Navigation Propertie

        public DateTime AsosiationDate { get; } = DateTime.UtcNow;
    }
}
