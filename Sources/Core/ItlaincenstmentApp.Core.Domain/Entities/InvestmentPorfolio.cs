using ItlaincenstmentApp.Core.Domain.Common;

namespace ItlaincenstmentApp.Core.Domain.Entities
{
    public class InvestmentPorfolio : BasicEntity<int>
    {
        public required int UserId { get; set; }
        public User? User { get; set; }

        // many to many 
        public ICollection<InvestmentAssets>? InvestmentAssets { get; set; }
    }
}
