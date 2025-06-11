using ItlaincenstmentApp.Core.Domain.Shere;

namespace ItlaincenstmentApp.Core.Domain.ValidationEntities
{
    public static class GenericValidId
    {
        public static OperationResult<int> ValidId(int id)
        {
            if (id <= 0) 
                return OperationResult<int>.Fail("id is invalid");

            return OperationResult<int>.Success(id, "id is successs");           
        }
    }
}
