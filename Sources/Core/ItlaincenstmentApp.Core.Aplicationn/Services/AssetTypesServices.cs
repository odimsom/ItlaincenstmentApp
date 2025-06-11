using ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetTypeDtos;
using ItlaincenstmentApp.Core.Aplicationn.Interfaces;
using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Core.Domain.Shere;
using ItlaincenstmentApp.Core.Domain.ValidationEntities;
using Microsoft.EntityFrameworkCore;

namespace ItlaincenstmentApp.Core.Aplicationn.Services
{
    public class AssetTypesServices : IAssetTypesServices
    {
        private readonly IAssetTypeRepository _repository;
        private readonly IValidation<AssetType> _validation = new AssetTypeValidation();
        public AssetTypesServices(IAssetTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<ICollection<AssetsTypeDto>>> GetAllWithAsset()
        {
            var resultQuery = await _repository.GetAllQueryInclude(["Assets"]);
            if (!resultQuery.IsSuccess)
                return OperationResult<ICollection<AssetsTypeDto>>.Fail(resultQuery.Message);

            var dto = resultQuery.Value.Select(a => AssetsTypeDto.NewBuilder()
                .WithId(a.Id)
                .WithName(a.Name)
                .WithDescription(a.Description!)
                .WithAssetsQuantity(a.Assets != null ? a.Assets.Where(a => !a.Remove).ToList().Count : 0)
                .Build()).ToList();

            return OperationResult<ICollection<AssetsTypeDto>>.Success(dto, resultQuery.Message);
        }
        public async Task<OperationResult<ICollection<AssetsTypeDto>>> GetAll()
        {
            var result = await _repository.GetAllAsync();

            if (!result.IsSuccess)
                return OperationResult<ICollection<AssetsTypeDto>>.Fail(result.Message, result.Value.Select(a => AssetsTypeDto.NewBuilder()
                .WithId(0)
                .WithName("")
                .WithDescription("")
                .Build()).ToList());

            var dto = result.Value.Select(a => AssetsTypeDto.NewBuilder()
                .WithId(a.Id)
                .WithName(a.Name)
                .WithDescription(a.Description!)
                .Build()).ToList();

            return OperationResult<ICollection<AssetsTypeDto>>.Success(dto, result.Message);
        }
        public async Task<OperationResult<AssetsTypeDto>> GetByIdAsync(int id)
        {
            var IsSuccess = GenericValidId.ValidId(id);
            if (!IsSuccess.IsSuccess)
                return OperationResult<AssetsTypeDto>.Fail(IsSuccess.Message);

            var result = await _repository.GetByIdAsync(id);

            if (!result.IsSuccess)
                return OperationResult<AssetsTypeDto>.Fail(result.Message);

            var dto = AssetsTypeDto.NewBuilder()
                .WithId(result.Value.Id)
                .WithName(result.Value.Name)
                .WithDescription(result.Value.Description!)
                .Build();

            return OperationResult<AssetsTypeDto>.Success(dto, result.Message);
        }
        public async Task<OperationResult<AssetsTypeDto>> AddAsync(AssetsTypeDto dto)
        {
            AssetType entity = new()
            {
                Id = 0,
                Name = dto.Name,
                Description = dto.Description
            };

            var IsSuccess = _validation.ValidateEntity(entity);
            if (!IsSuccess.IsSuccess)
                return OperationResult<AssetsTypeDto>.Fail(IsSuccess.Message); ;

            var result = await _repository.AddAsync(entity);

            if (!result.IsSuccess)
                return OperationResult<AssetsTypeDto>.Fail(result.Message);

            return OperationResult<AssetsTypeDto>.Success(dto, result.Message);
        }
        public async Task<OperationResult<AssetsTypeDto>> UbdateAsync(AssetsTypeDto dto)
        {
            AssetType entity = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };

            var IsSuccess = _validation.ValidateEntityWithId(entity);
            if (!IsSuccess.IsSuccess)
                return OperationResult<AssetsTypeDto>.Fail(IsSuccess.Message);

            var result = await _repository.UpdateAsync(entity.Id, entity);

            if (!result.IsSuccess)
                return OperationResult<AssetsTypeDto>.Fail(result.Message);

            return OperationResult<AssetsTypeDto>.Success(dto, result.Message);
        }
        public async Task<OperationResult<AssetsTypeDto>> DeleteAsync(int id)
        {
            var IsSuccess = GenericValidId.ValidId(id);
            if (!IsSuccess.IsSuccess)
                return OperationResult<AssetsTypeDto>.Fail(IsSuccess.Message);

            var result = await _repository.Remove(id);

            if (!result.IsSuccess)
                return OperationResult<AssetsTypeDto>.Fail(result.Message);

            var dto = AssetsTypeDto.NewBuilder()
                .WithId(result.Value.Id)
                .WithName(result.Value.Name)
                .WithDescription(result.Value.Description!)
                .Build();

            return OperationResult<AssetsTypeDto>.Success(dto, result.Message);
        }
    }
}