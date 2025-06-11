using ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetDtos;
using ItlaincenstmentApp.Core.Aplicationn.Dtos.InvestmentPorfolioDtos;

namespace ItlaincenstmentApp.Core.Aplicationn.Dtos.InvestmentAssetsDtos
{
    public class InvestmentAssetsDto
    {
        public required int AssetId { get; set; } // FK Asset
        public AssetDto? Assets { get; set; } // Navigation Propertie

        public required int InvestmentPorfolioId { get; set; }// FK Investment
        public InvestmentPorfolioDto? InvestmentPorfolio { get; set; } // Navigation Propertie

        public DateTime AsosiationDate { get; } = DateTime.UtcNow;
    }
}
