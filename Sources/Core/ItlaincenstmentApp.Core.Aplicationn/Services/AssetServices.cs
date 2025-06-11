using ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetDtos;
using ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetTypeDtos;
using ItlaincenstmentApp.Core.Aplicationn.Interfaces;
using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Core.Domain.Shere;
using ItlaincenstmentApp.Core.Domain.ValidationEntities;
using Microsoft.EntityFrameworkCore;

namespace ItlaincenstmentApp.Core.Aplicationn.Services
{
    public class AssetServices : IAssetServices
    {
        private readonly IAssetRepository _repository;
        private readonly IValidation<Asset> _validation = new AssetValidate();
        public AssetServices(IAssetRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<ICollection<AssetDto>>> GetAllWithAsset()
        {
            var resultQuery = await _repository.GetAllQueryInclude(["AssetType"]);
            if (!resultQuery.IsSuccess)
                return OperationResult<ICollection<AssetDto>>.Fail(resultQuery.Message);

            var asset = await resultQuery.Value.ToListAsync();

            var dto = asset.Select(a => AssetDto.NewBuilder()
                .WithId(a.Id)
                .WithName(a.Name)
                .WithDescription(a.Description != null ? a.Description : "")
                .WithSymbol(a.Symbol)
                .WithAssetTypeId(a.AssetType != null ? a.AssetType.Id : 0)
                .WithAsetType(
                    AssetsTypeDto.NewBuilder()
                    .WithId(a.AssetType != null ? a.AssetType.Id : 0)
                    .WithName(a.AssetType != null ? a.AssetType.Name : "")
                    .WithDescription(a.AssetType != null && a.AssetType.Description != null ? a.AssetType.Description : "")
                    .Build()
                ).Buil()).ToList();

            return OperationResult<ICollection<AssetDto>>.Success(dto, resultQuery.Message);
        }
        public async Task<OperationResult<ICollection<AssetDto>>> GetAll()
        {
            var result = await _repository.GetAllAsync();

            if (!result.IsSuccess)
                return OperationResult<ICollection<AssetDto>>.Fail(result.Message);

            var dto = result.Value.Select(a => AssetDto.NewBuilder()
                .WithId(a.Id)
                .WithName(a.Name)
                .WithDescription(a.Description != null ? a.Description : "")
                .WithSymbol(a.Symbol)
                .Buil()).ToList();

            return OperationResult<ICollection<AssetDto>>.Success(dto, result.Message);
        }
        public async Task<OperationResult<AssetDto>> GetByIdAsync(int id)
        {
            var IsSuccess = GenericValidId.ValidId(id);
            if (!IsSuccess.IsSuccess)
                return OperationResult<AssetDto>.Fail(IsSuccess.Message);

            var resultList = await _repository.GetAllQueryInclude(["AssetType"]);

            if (!resultList.IsSuccess)
                return OperationResult<AssetDto>.Fail(resultList.Message);

            var result = await resultList.Value.FirstOrDefaultAsync(a => a.Id == IsSuccess.Value);

            var dto = AssetDto.NewBuilder()
                .WithId(result == null ? 0 : result.Id)
                .WithName(result == null ? "" : result.Name)
                .WithDescription(result == null ? "" : result.Description == null ? "" : result.Description)
                .WithSymbol(result == null ? "" : result.Symbol)
                .Buil();

            return OperationResult<AssetDto>.Success(dto, "Operation Is Success");
        }
        public async Task<OperationResult<AssetDto>> AddAsync(AssetDto dto)
        {
            if (dto == null)
                return OperationResult<AssetDto>.Fail("dto is requaired");

            Asset entity = new()
            {
                Id = 0,
                Name = dto.Name,
                Description = dto.Description,
                Symbol = dto.Symbol,
                AssetTypeId = dto.AssetTypeId
            };

            var IsSuccess = _validation.ValidateEntity(entity);
            if (!IsSuccess.IsSuccess)
                return OperationResult<AssetDto>.Fail(IsSuccess.Message);

            var result = await _repository.AddAsync(entity);

            if (!result.IsSuccess)
                return OperationResult<AssetDto>.Fail(result.Message);

            return OperationResult<AssetDto>.Success(dto, result.Message);
        }
        public async Task<OperationResult<AssetDto>> UbdateAsync(AssetDto dto)
        {
            Asset entity = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Symbol = dto.Symbol,
                AssetTypeId = dto.AssetTypeId

            };

            var IsSuccess = _validation.ValidateEntityWithId(entity);
            if (!IsSuccess.IsSuccess)
                return OperationResult<AssetDto>.Fail(IsSuccess.Message);

            var result = await _repository.UpdateAsync(entity.Id, entity);

            if (!result.IsSuccess)
                return OperationResult<AssetDto>.Fail(result.Message);

            return OperationResult<AssetDto>.Success(dto, result.Message);
        }
        public async Task<OperationResult<AssetDto>> DeleteAsync(int id)
        {
            var IsSuccess = GenericValidId.ValidId(id);
            if (!IsSuccess.IsSuccess)
                return OperationResult<AssetDto>.Fail(IsSuccess.Message);

            var result = await _repository.Remove(id);

            if (!result.IsSuccess)
                return OperationResult<AssetDto>.Fail(result.Message);

            var dto = AssetDto.NewBuilder()
                .WithId(result.Value.Id)
                .WithName(result.Value.Name)
                .WithDescription(result.Value.Description!)
                .Buil();

            return OperationResult<AssetDto>.Success(dto, result.Message);
        }
    }
}
