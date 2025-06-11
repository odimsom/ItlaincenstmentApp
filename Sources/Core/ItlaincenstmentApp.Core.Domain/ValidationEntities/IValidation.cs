using ItlaincenstmentApp.Core.Domain.Shere;

namespace ItlaincenstmentApp.Core.Domain.ValidationEntities
{
    public interface IValidation<T> where T : class
    {
       OperationResult<T> ValidateEntity(T Entity);
       OperationResult<T> ValidateEntityWithId(T Entity);
    }
}
