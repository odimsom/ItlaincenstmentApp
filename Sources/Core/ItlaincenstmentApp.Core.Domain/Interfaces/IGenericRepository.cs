using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Shere;

namespace ItlaincenstmentApp.Core.Domain.Interfaces
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<OperationResult<Entity>> AddAsync(Entity entity);
        Task<OperationResult<ICollection<Entity>>> AddRangeAsync(ICollection<Entity> entities);
        Task<OperationResult<ICollection<Entity>>> GetAllAsync();
        Task<OperationResult<ICollection<Entity>>> GetAllIncludeAsync(ICollection<string> properties);
        Task<OperationResult<IQueryable<Entity>>> GetAllQuery();
        Task<OperationResult<IQueryable<Entity>>> GetAllQueryInclude(ICollection<string> properties);
        Task<OperationResult<Entity>> GetByIdAsync(int id);
        Task<OperationResult<Entity>> Remove(int Id);
        Task<OperationResult<Entity>> UpdateAsync(int id, Entity entity);
    }
}