namespace ItlaincenstmentApp.Core.Domain.Entities
{
    public class AssetHistory
    {
        public required int Id { get; set; }
        public DateTime HistoryValueDate { get; set; }
        public required decimal Value { get; set; }
        #region relation one to one with Asset
            public required int AssetId { get; set; }
            public Asset? Asset { get; set; }
        #endregion
    }
}
