using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Infrastructure.Persistence.Context;

namespace ItlaincenstmentApp.Infrastructure.Persistence.Repositories
{
    public class InvestmentAssetsRepository : GenericRepository<InvestmentAssets, InvestmentAppContext>, IInvestmentAssetsRepository
    {
        public InvestmentAssetsRepository(InvestmentAppContext context) : base(context)
        {
        }
    }
}
