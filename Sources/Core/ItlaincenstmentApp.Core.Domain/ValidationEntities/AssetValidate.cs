using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Shere;

namespace ItlaincenstmentApp.Core.Domain.ValidationEntities
{
    public class AssetValidate : IValidation<Asset>
    {
        public OperationResult<Asset> ValidateEntity(Asset asset)
        {
            var IsValidEntity = asset switch
            {
                null => OperationResult<Asset>.Fail("The entity is null"),
                { Name: "" or null } => OperationResult<Asset>.Fail("The Name is required"),
                { Description: "" or null } => OperationResult<Asset>.Fail("The Description is required"),
                { Symbol: "" or null } => OperationResult<Asset>.Fail("The Symbol is required"),
                { AssetTypeId: 0 } => OperationResult<Asset>.Fail("The AssetTypeId is required"),
                _ => OperationResult<Asset>.Success(asset, "Entity it is complete")
            }; 
            return IsValidEntity;
        }
        public OperationResult<Asset> ValidateEntityWithId(Asset Entity)
        {
            var entityIsValid = ValidateEntity(Entity);

            if (!entityIsValid.IsSuccess)
                return entityIsValid;

            var IsValidEntityWithId = entityIsValid.Value switch
            {
                { Id: 0 } => OperationResult<Asset>.Fail("The iD is required"),
                _ => entityIsValid
            };
            return IsValidEntityWithId;
        }
    }
}
