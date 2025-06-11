using ItlaincenstmentApp.Core.Domain.Shere;
using ItlaincenstmentApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ItlaincenstmentApp.Infrastructure.Persistence.Helper
{
    public static class TryDbHelper
    {
        public static async Task<OperationResult<IQueryable<T>>> TryGetAllQueryAsync<T, Context>(Context context) where T : class where Context : DbContext
        {
            try
            {
                var queryable = context.Set<T>()
                    .AsQueryable(); // select * from AssetType ......... the what you want / Diferred Execution
                var haveElement = await queryable.AnyAsync();
                return haveElement
                    ? OperationResult<IQueryable<T>>.Success(queryable, "Database data found")
                    : OperationResult<IQueryable<T>>.Success(queryable, "Nothing found in the database");
            }
            catch (Exception ex)
            {
                return OperationResult<IQueryable<T>>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public static async Task<OperationResult<IQueryable<T>>> TryGetAllQueryAsyncIncluede<T, Context>(Context context, ICollection<string> properties) where T : class where Context : DbContext
        {
            try
            {
                var query = context.Set<T>().AsQueryable(); // diferrect execution
                foreach (var property in properties)
                {
                    query = query.Include(property);
                }
                var HaveElement = await query.AnyAsync();
                return HaveElement
                    ? OperationResult<IQueryable<T>>.Success(query, "Database data found")
                    : OperationResult<IQueryable<T>>.Fail("Nothing found in the database", query!);
            }
            catch (Exception ex)
            {
                return OperationResult<IQueryable<T>>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public static async Task<OperationResult<ICollection<T>>> TryGetAllAsync<T, Context>(Context context) where T : class where Context : DbContext
        {
            try
            {
                var ListAssetType = await context.Set<T>().ToListAsync(); // EF - Inmediante Execution
                return ListAssetType is not null && ListAssetType.Count != 0
                    ? OperationResult<ICollection<T>>.Success(ListAssetType, "Database data found")
                    : OperationResult<ICollection<T>>.Fail("Nothing found in the database", ListAssetType!);
            }
            catch (Exception ex)
            {
                return OperationResult<ICollection<T>>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public static async Task<OperationResult<ICollection<T>>> TryGetAllAsyncInclude<T, Context>(Context context, ICollection<string> properties) where T : class where Context : DbContext
        {
            try
            {
                var query = context.Set<T>().AsQueryable();
                foreach (var property in properties)
                {
                    query = query.Include(property);
                }
                var ListAssetType = await query.ToListAsync(); // EF - Inmediante Execution
                return ListAssetType is not null && ListAssetType.Count != 0
                    ? OperationResult<ICollection<T>>.Success(ListAssetType, "Database data found")
                    : OperationResult<ICollection<T>>.Fail("Nothing found in the database", ListAssetType!);
            }
            catch (Exception ex)
            {
                return OperationResult<ICollection<T>>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public static async Task<OperationResult<T>> TryGetByIdAsync<T, Context>(Context context, int id) where T : class where Context : DbContext
        {
            try
            {
                var entity = await context.Set<T>().FindAsync(id);
                return OperationResult<T>.Success(entity!, "Entity updateSucess");
            }
            catch (Exception ex)
            {
                return OperationResult<T>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public static async Task<OperationResult<T>> TryAddAsync<T, Context>(Context context, T entity) where T : class where Context : DbContext
        {
            try
            {
                await context.Set<T>().AddAsync(entity);
                var result = await context.SaveChangesAsync();

                return result > 0
                    ? OperationResult<T>.Success(entity, "Entity created successfully")
                    : OperationResult<T>.Fail("No changes saved");
            }
            catch (Exception ex)
            {
                return OperationResult<T>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public static async Task<OperationResult<ICollection<T>>> TryAddAsync<T, Context>(Context context, ICollection<T> entites) where T : class where Context : DbContext
        {
            try
            {
                await context.Set<T>().AddRangeAsync(entites);
                var result = await context.SaveChangesAsync();

                return result > 0
                    ? OperationResult<ICollection<T>>.Success(entites, "Entity created successfully")
                    : OperationResult<ICollection<T>>.Fail("No changes saved");
            }
            catch (Exception ex)
            {
                return OperationResult<ICollection<T>>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public static async Task<OperationResult<T>> TryUpdateAsync<T, Context>(Context context, T entity, T enityUpdate) where T : class where Context : DbContext
        {
            try
            {
                context.Entry(entity).CurrentValues.SetValues(enityUpdate);
                var resultOperationSaveDataBase = await context.SaveChangesAsync();

                return resultOperationSaveDataBase > 0
                    ? OperationResult<T>.Success(entity, "Entity updateSucess")
                    : OperationResult<T>.Fail("Error Save Changes at the data base");
            }
            catch (Exception ex)
            {
                return OperationResult<T>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public static async Task<OperationResult<T>> TryRomoveAsync<T, Context>(Context context, T entity) where T : class where Context : DbContext
        {
            try
            {
                context.Entry(entity).CurrentValues.SetValues(entity);
                var resultOperationSaveDataBase = await context.SaveChangesAsync();

                return resultOperationSaveDataBase > 0
                    ? OperationResult<T>.Success(entity, "Entity updateSucess")
                    : OperationResult<T>.Fail("Error Save Changes at the data base");
            }
            catch (Exception ex)
            {
                return OperationResult<T>.Fail($"Unexpected error: {ex.Message}");
            }
        }
    }

}
