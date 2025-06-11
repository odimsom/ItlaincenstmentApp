using ItlaincenstmentApp.Core.Aplicationn.Dtos.Common;
using ItlaincenstmentApp.Core.Aplicationn.Dtos.InvestmentAssetsDtos;
using ItlaincenstmentApp.Core.Aplicationn.Dtos.UserDtos;

namespace ItlaincenstmentApp.Core.Aplicationn.Dtos.InvestmentPorfolioDtos
{
    public class InvestmentPorfolioDto : BasicDto<int>
    {
        public required int UserId { get; set; }
        public UserDto? User { get; set; }

        // many to many 
        public ICollection<InvestmentAssetsDto>? InvestmentAssets { get; set; }
    }
}
