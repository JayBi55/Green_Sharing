using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories.Interface
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        //Create
        Task<int> CreateOrUpdateAsync(Entity entity, bool needsUpdating = true);
        Task<int> CreateAsync(Entity entity);

        //Update
        Task<int> UpdateAsync(Entity entity);

        //GetAll
        Task<IEnumerable<Entity>> AllAsync();

        //Exists
        Task<bool> ExistsAsync(Expression<Func<Entity, bool>> whereExpression);

        //Delete
        Task<int> DeleteAsync(Guid entityId);
        Task<int> DeleteAsync(Entity entity);

        //Find
        Task<Entity> FindAsync(Guid entityId);
        Task<Entity> FindAsync(Expression<Func<Entity, bool>> whereExpression);

        //FindAll
        Task<IEnumerable<Entity>> FindAllAsync(Expression<Func<Entity, bool>> whereExpression);

        IQueryable<Entity> GetQuery();
        IQueryable<Entity> GetQuery(string navigationPath);
        IQueryable<Entity> FilterQuery(IQueryable<Entity> query, Expression<Func<Entity, bool>> whereExpression);
        IQueryable<Entity> OrderQuery<T>(IQueryable<Entity> query, Expression<Func<Entity, T>> keySelector);
        IQueryable<Entity> OrderQueryByDescending<T>(IQueryable<Entity> query, Expression<Func<Entity, T>> keySelector);
        IQueryable<Entity> FilterQuery(IQueryable<Entity> query, string navigationPath, Expression<Func<Entity, bool>> whereExpression);
        Task<int> CommitTransactionAsync();
        Task AddToTransactionAsync(Entity entity);
    }
}
