using ItlaincenstmentApp.Core.Domain.Common;

namespace ItlaincenstmentApp.Core.Domain.Entities
{
    public class AssetType : BasicEntity<int>
    {
        #region relationship one to many with Assets
            public ICollection<Asset>? Assets { get; set; }
        #endregion
    }
}
