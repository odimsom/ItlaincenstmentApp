using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Infrastructure.Persistence.Context;

namespace ItlaincenstmentApp.Infrastructure.Persistence.Repositories
{
    public class InvestmentPorfolioRepository : GenericRepository<InvestmentPorfolio, InvestmentAppContext>, IInvestmentPorfolioRepository
    {
        public InvestmentPorfolioRepository(InvestmentAppContext context) : base(context)
        {
        }
    }
}
