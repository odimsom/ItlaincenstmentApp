using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Core.Domain.Shere;
using ItlaincenstmentApp.Core.Domain.ValidationEntities;
using ItlaincenstmentApp.Infrastructure.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace ItlaincenstmentApp.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity, Context>(Context context) : IGenericRepository<Entity> 
        where Entity : class 
        where Context : DbContext
    {
        private readonly Context _context = context;

        public virtual async Task<OperationResult<IQueryable<Entity>>> GetAllQuery()
        {
            var tryResult = await TryDbHelper.TryGetAllQueryAsync<Entity, Context>(_context);
            if (!tryResult.IsSuccess)
                return tryResult;
            return OperationResult<IQueryable<Entity>>.Success(tryResult.Value, tryResult.Message);
        }
        public virtual async Task<OperationResult<IQueryable<Entity>>> GetAllQueryInclude(ICollection<string> properties)
        {
            var tryResult = await TryDbHelper.TryGetAllQueryAsyncIncluede<Entity, Context>(_context, properties);
            if (!tryResult.IsSuccess)
                return tryResult;
            return OperationResult<IQueryable<Entity>>.Success(tryResult.Value, tryResult.Message);
        }
        public virtual async Task<OperationResult<ICollection<Entity>>> GetAllAsync()
        {
            var tryResult = await TryDbHelper.TryGetAllAsync<Entity, Context>(_context);
            if (!tryResult.IsSuccess)
                return tryResult;

            return OperationResult<ICollection<Entity>>.Success(tryResult.Value, tryResult.Message);
        }
        public virtual async Task<OperationResult<ICollection<Entity>>> GetAllIncludeAsync(ICollection<string> properties)
        {
            var tryResult = await TryDbHelper.TryGetAllAsyncInclude<Entity, Context>(_context, properties);
            if (!tryResult.IsSuccess)
                return tryResult;

            return OperationResult<ICollection<Entity>>.Success(tryResult.Value, tryResult.Message);
        }
        public virtual async Task<OperationResult<Entity>> GetByIdAsync(int id)
        {
            var IdIsValid = GenericValidId.ValidId(id);

            if (!IdIsValid.IsSuccess)
                return OperationResult<Entity>.Fail(IdIsValid.Message);

            var tryResult = await TryDbHelper.TryGetByIdAsync<Entity, Context>(_context, IdIsValid.Value);

            if (!tryResult.IsSuccess)
                return tryResult;

            return tryResult;
        }
        public virtual async Task<OperationResult<Entity>> AddAsync(Entity entity)
        {
            var tryResult = await TryDbHelper.TryAddAsync(_context, entity);

            if (!tryResult.IsSuccess)
                return tryResult;

            return tryResult;
        }
        public virtual async Task<OperationResult<ICollection<Entity>>> AddRangeAsync(ICollection<Entity> entities)
        {
            var tryResult = await TryDbHelper.TryAddAsync(_context, entities);

            if (!tryResult.IsSuccess)
                return tryResult;

            return tryResult;
        }
        public virtual async Task<OperationResult<Entity>> UpdateAsync(int id, Entity entity)
        {
            var entry = await _context.Set<Entity>().FindAsync(id);

            var tryResult = await TryDbHelper.TryUpdateAsync(_context, entry!, entity);

            if (!tryResult.IsSuccess)
                return tryResult;

            return tryResult;
        }
        public virtual async Task<OperationResult<Entity>> Remove(int Id)
        {
            var IdIsValid = GenericValidId.ValidId(Id);

            if (!IdIsValid.IsSuccess)
                return OperationResult<Entity>.Fail(IdIsValid.Message);

            var entry = await _context.Set<Entity>().FindAsync(IdIsValid.Value);

            // Proceso de eliminado
            var resutl = _context.Set<Entity>().Remove(entry!);

            return OperationResult<Entity>.Success(resutl.Entity, "Remove success");
        }
    }
}
