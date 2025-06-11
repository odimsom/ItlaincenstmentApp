using ItlaincenstmentApp.Core.Aplicationn.Dtos.Common;
using System.Security.Cryptography.X509Certificates;

namespace ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetTypeDtos
{
    public class AssetsTypeDto : BasicDto<int>
    {
        public int? AssetsQuantity { get; set; }
        public static Builder NewBuilder() => new Builder();

        public class Builder
        {
            private AssetsTypeDto _assetsTypeDto = new(){ Id = 0, Name = ""};

            public Builder WithId(int id)
            {
                _assetsTypeDto.Id = id;
                return this;
            }

            public Builder WithName(string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Name cannot be null or empty.", nameof(name));

                _assetsTypeDto.Name = name;
                return this;
            }

            public Builder WithDescription(string description)
            {
                if (string.IsNullOrWhiteSpace(description))
                    throw new ArgumentException("Description cannot be null or empty.", nameof(description));

                _assetsTypeDto.Description = description;
                return this;
            }            
                        
            public Builder WithAssetsQuantity(int assetsQuantity)
            {
                _assetsTypeDto.AssetsQuantity = assetsQuantity;
                return this;
            }



            public AssetsTypeDto Build()
            {
                return _assetsTypeDto;
            }
        }

    }
}
