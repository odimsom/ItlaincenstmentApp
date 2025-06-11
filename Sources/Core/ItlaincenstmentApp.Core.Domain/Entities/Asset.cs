using ItlaincenstmentApp.Core.Domain.Common;

namespace ItlaincenstmentApp.Core.Domain.Entities
{
    public class Asset : BasicEntity<int>
    {
        public required string Symbol { get; set; }
        #region relationships
            public required int AssetTypeId { get; set; }
            public AssetType? AssetType { get; set; }
            // assetHistory
            public ICollection<AssetHistory>? AssetHistories { get; set; }
            // many to many
            public ICollection<InvestmentAssets>? InvestmentAssets { get; set; }
        #endregion
    }
}
