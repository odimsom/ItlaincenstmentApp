using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Shere;

namespace ItlaincenstmentApp.Core.Domain.ValidationEntities
{
    public class AssetTypeValidation : IValidation<AssetType>
    {
        public OperationResult<AssetType> ValidateEntity(AssetType assetType)
        {
            var IsValidEntity = assetType switch
            {
                null => OperationResult<AssetType>.Fail("The entity is null"),
                { Name: "" or null } => OperationResult<AssetType>.Fail("The Name is required"),
                { Description: "" or null } => OperationResult<AssetType>.Fail("The Description is required"),
                _ => OperationResult<AssetType>.Success(assetType, "Entity it is complete")
            };
            return IsValidEntity;
        }

        public OperationResult<AssetType> ValidateEntityWithId(AssetType Entity)
        {
            var entityIsValid = ValidateEntity(Entity);

            if (!entityIsValid.IsSuccess)
                return entityIsValid;

            var IsValidEntityWithId = entityIsValid.Value switch
            {
                { Id: 0 } => OperationResult<AssetType>.Fail("The iD is required"),
                _ => entityIsValid
            };
            return IsValidEntityWithId;
        }
    }
}
