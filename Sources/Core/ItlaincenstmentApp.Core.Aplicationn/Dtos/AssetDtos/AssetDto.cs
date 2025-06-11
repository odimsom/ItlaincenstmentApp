using ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetTypeDtos;
using ItlaincenstmentApp.Core.Aplicationn.Dtos.Common;

namespace ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetDtos
{
    public class AssetDto : BasicDto<int>
    {
        public required string Symbol { get; set; }
        public required int AssetTypeId { get; set; }

        public AssetsTypeDto? assetTypeDto { get; set; }

        public static Builder NewBuilder() => new Builder();

        public class Builder
        {
            public readonly AssetDto _assetDto = new AssetDto { Id = 0, AssetTypeId = 0, Name = "", Symbol = "" };
            public Builder WithId(int id)
            {
                _assetDto.Id = id;
                return this;
            }
            public Builder WithAssetTypeId(int assettypeId)
            {
                _assetDto.AssetTypeId = assettypeId;
                return this;
            }
            public Builder WithAsetType(AssetsTypeDto assettype)
            {
                _assetDto.assetTypeDto = assettype;
                return this;
            }
            public Builder WithName(string name)
            {
                _assetDto.Name = name;
                return this;
            }
            public Builder WithDescription(string description)
            {
                _assetDto.Description = description;
                return this;
            }
            public Builder WithSymbol(string symbol)
            {
                _assetDto.Symbol = symbol;
                return this;
            }
            public AssetDto Buil()
            {
                return _assetDto;
            }
        }
    }
}
