using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Infrastructure.Persistence.Context;

namespace ItlaincenstmentApp.Infrastructure.Persistence.Repositories
{
    public class AssetRepository : GenericRepository<Asset, InvestmentAppContext>, IAssetRepository
    {
        private readonly InvestmentAppContext _context;
        public AssetRepository(InvestmentAppContext context) : base(context)
        {
            _context = context;
        }
    }
}
