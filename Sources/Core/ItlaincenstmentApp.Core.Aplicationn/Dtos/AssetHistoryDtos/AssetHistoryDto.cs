using ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetDtos;

namespace ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetHistoryDtos
{
    public class AssetHistoryDto
    {
        public required int Id { get; set; }
        public DateTime HistoryValueDate { get; set; }
        public required decimal Value { get; set; }
        #region relation one to one with Asset
            public required int AssetId { get; set; }
            public AssetDto? Asset { get; set; }
        #endregion
    }
}
