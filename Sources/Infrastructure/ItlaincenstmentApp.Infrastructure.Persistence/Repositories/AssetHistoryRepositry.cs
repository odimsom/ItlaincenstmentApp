using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Infrastructure.Persistence.Context;

namespace ItlaincenstmentApp.Infrastructure.Persistence.Repositories
{
    public class AssetHistoryRepositry : GenericRepository<AssetHistory, InvestmentAppContext>, IAssetHistoryRepositry
    {
        public AssetHistoryRepositry(InvestmentAppContext context) : base(context)
        {
        }
    }
}
