using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Infrastructure.Persistence.Context;

namespace ItlaincenstmentApp.Infrastructure.Persistence.Repositories
{
    public class AssetTypeRepository : GenericRepository<AssetType, InvestmentAppContext>, IAssetTypeRepository
    {
        private readonly InvestmentAppContext _context;
        public AssetTypeRepository(InvestmentAppContext context) : base(context)
        {
            _context = context;
        }
    }
}