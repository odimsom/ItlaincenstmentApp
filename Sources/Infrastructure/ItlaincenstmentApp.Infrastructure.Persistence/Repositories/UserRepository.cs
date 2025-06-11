using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Infrastructure.Persistence.Context;

namespace ItlaincenstmentApp.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User, InvestmentAppContext>, IUserRepository
    {
        public UserRepository(InvestmentAppContext context) : base(context)
        {
        }
    }
}
