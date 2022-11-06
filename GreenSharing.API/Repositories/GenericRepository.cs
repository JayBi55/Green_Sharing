using GreenSharing.API.Models;
using GreenSharing.API.Repositories.Interface;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GreenSharing.API.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected static readonly ILog Logger = LogManager.GetLogger(typeof(IGenericRepository<Entity>));

        internal DbSet<Entity> DbSet;
        public GreenSharingContext Context { get; }

        public GenericRepository(GreenSharingContext context)
        {
            Context = context;
            DbSet = Context.Set<Entity>();
        }

        #region GenericMethods
        public async Task<int> CreateOrUpdateAsync(Entity entity, bool needsUpdating = true)
        {
            int result = 0;

            try
            {
                PropertyInfo entityIdProperty = typeof(Entity).GetProperty("Id");
                var id = entityIdProperty.GetValue(entity);
                var entityFound = DbSet.Find(id);
                if (entityFound == null)
                {
                    result = await CreateAsync(entity);
                }
                else if (needsUpdating)
                {
                    result = await UpdateAsync(entity);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        //Create
        public async Task<int> CreateAsync(Entity entity)
        {
            int result = 0;

            try
            {
                var creationDateProperty = typeof(Entity).GetProperty("CreationDate");
                if (creationDateProperty != null && (creationDateProperty.GetValue(entity) == null || (DateTime)creationDateProperty.GetValue(entity) == DateTime.MinValue))
                {
                    creationDateProperty.SetValue(entity, DateTime.UtcNow);
                }

                var dateOfActionProperty = typeof(Entity).GetProperty("DateOfAction");
                if (dateOfActionProperty != null && (dateOfActionProperty.GetValue(entity) == null || (DateTime)dateOfActionProperty.GetValue(entity) == DateTime.MinValue))
                {
                    dateOfActionProperty.SetValue(entity, DateTime.UtcNow);
                }

                var creationTimeProperty = typeof(Entity).GetProperty("CreationTime");
                if (creationTimeProperty != null && (creationTimeProperty.GetValue(entity) == null || (DateTime)creationTimeProperty.GetValue(entity) == DateTime.MinValue))
                {
                    creationTimeProperty.SetValue(entity, DateTime.UtcNow);
                }

                var isActiveProperty = typeof(Entity).GetProperty("IsActive");
                if (isActiveProperty != null) isActiveProperty.SetValue(entity, true);

                await DbSet.AddAsync(entity);
                result = await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
            return result;
        }

        public async Task AddToTransactionAsync(Entity entity)
        {
            try
            {
                var creationDateProperty = typeof(Entity).GetProperty("CreationDate");
                if (creationDateProperty != null && creationDateProperty.GetValue(entity) == null) creationDateProperty.SetValue(entity, DateTime.UtcNow);

                var dateOfActionProperty = typeof(Entity).GetProperty("DateOfAction");
                if (dateOfActionProperty != null && (DateTime)dateOfActionProperty.GetValue(entity) == DateTime.MinValue) dateOfActionProperty.SetValue(entity, DateTime.UtcNow);

                var creationTimeProperty = typeof(Entity).GetProperty("CreationTime");
                if (creationTimeProperty != null && (DateTime)creationTimeProperty.GetValue(entity) == DateTime.MinValue) creationTimeProperty.SetValue(entity, DateTime.UtcNow);

                var isActiveProperty = typeof(Entity).GetProperty("IsActive");
                if (isActiveProperty != null) isActiveProperty.SetValue(entity, true);

                await DbSet.AddAsync(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> CommitTransactionAsync()
        {
            int result = 0;

            try
            {
                result = await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        //Update
        public async Task<int> UpdateAsync(Entity entity)
        {
            int result = 0;

            try
            {
                var bdEntityId = GetId(entity);
                var bdEntity = await DbSet.FindAsync(bdEntityId);
                Context.Entry(bdEntity).State = EntityState.Detached;
                Context.Entry(entity).State = EntityState.Modified;
                result = await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        //All
        public async Task<IEnumerable<Entity>> AllAsync()
        {
            return await DbSet.ToListAsync();
        }

        //Overrides Default Delete
        public async Task<int> DeleteAsync(Guid entityId)
        {
            int result = 0;

            try
            {
                var entity = await FindAsync(entityId);
                if (entity == null)
                {
                    throw new Exception($"Can't find {typeof(Entity)} in the DB");
                }

                if (entity.GetType().GetProperty("IsActive") != null)
                {
                    PropertyInfo isActiveProperty = typeof(Entity).GetProperty("IsActive");
                    isActiveProperty.SetValue(entity, (bool)false);
                }
                if (entity.GetType().GetProperty("IsDeleted") != null)
                {
                    PropertyInfo isDeletedProperty = typeof(Entity).GetProperty("IsDeleted");
                    isDeletedProperty.SetValue(entity, (bool)true);
                }
                if (entity.GetType().GetProperty("ClosingDate") != null)
                {
                    PropertyInfo closingDateProperty = typeof(Entity).GetProperty("ClosingDate");
                    closingDateProperty.SetValue(entity, DateTime.UtcNow);
                }

                result = await UpdateAsync(entity);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"UNMANAGED ERROR OCCURED WHILE DELETING {typeof(Entity)} in the DB. \n Details {e.StackTrace}");
                throw new Exception($"UNMANAGED ERROR OCCURED WHILE DELETING {typeof(Entity)} in the DB. \n Details {e.StackTrace}");
            }
            return result;
        }
        public async Task<int> DeleteAsync(Entity entity)
        {
            int result = 0;

            try
            {
                var toDelete = await DbSet.FindAsync(entity);
                if (toDelete == null)
                {
                    throw new Exception($"Can't find {typeof(Entity)} in the DB");
                }

                if (entity.GetType().GetProperty("IsActive") != null)
                {
                    PropertyInfo isActiveProperty = typeof(Entity).GetProperty("IsActive");
                    isActiveProperty.SetValue(entity, (bool)false);
                }
                if (entity.GetType().GetProperty("IsDeleted") != null)
                {
                    PropertyInfo isDeletedProperty = typeof(Entity).GetProperty("IsDeleted");
                    isDeletedProperty.SetValue(entity, (bool)true);
                }
                if (entity.GetType().GetProperty("ClosingDate") != null)
                {
                    PropertyInfo closingDateProperty = typeof(Entity).GetProperty("ClosingDate");
                    closingDateProperty.SetValue(entity, DateTime.UtcNow);
                }

                result = await UpdateAsync(entity);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat($"UNMANAGED ERROR OCCURED WHILE DELETING {typeof(Entity)} in the DB. \n Details {e.StackTrace}");
                throw new Exception($"UNMANAGED ERROR OCCURED WHILE DELETING {typeof(Entity)} in the DB. \n Details {e.StackTrace}");
            }
            return result;
        }

        //Find
        public virtual async Task<Entity> FindAsync(Guid entityId)
        {
            Entity entity = null;

            try
            {
                entity = await DbSet.FindAsync(entityId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entity;
        }
        public async Task<Entity> FindAsync(Expression<Func<Entity, bool>> whereExpression)
        {
            Entity entity = null;

            try
            {
                entity = await DbSet.Where(whereExpression).SingleOrDefaultAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //FindAll
        public virtual async Task<IEnumerable<Entity>> FindAllAsync(Expression<Func<Entity, bool>> whereExpression)
        {
            List<Entity> entityList = null;

            try
            {
                entityList = await DbSet.Where(whereExpression).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return entityList;
        }
        #endregion

        #region Search Expressions
        //GetId
        private Guid GetId(object entity)
        {
            PropertyInfo entityIdProperty = typeof(Entity).GetProperty("Id");
            return (Guid)entityIdProperty.GetValue(entity);
        }

        //Exists
        public async Task<bool> ExistsAsync(Expression<Func<Entity, bool>> whereExpression)
        {
            return await DbSet.AnyAsync(whereExpression);
        }
        #endregion

        #region FilterQuery
        public IQueryable<Entity> GetQuery()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<Entity> GetQuery(string navigationPath)
        {
            return DbSet
                .Include(navigationPath)
                .AsQueryable();
        }

        public IQueryable<Entity> FilterQuery(IQueryable<Entity> query, Expression<Func<Entity, bool>> whereExpression)
        {
            return query.Where(whereExpression);
        }

        public IQueryable<Entity> OrderQuery<T>(IQueryable<Entity> query, Expression<Func<Entity, T>> keySelector)
        {
            return query.OrderBy(keySelector);
        }

        public IQueryable<Entity> OrderQueryByDescending<T>(IQueryable<Entity> query, Expression<Func<Entity, T>> keySelector)
        {
            return query.OrderByDescending(keySelector);
        }

        public IQueryable<Entity> FilterQuery(IQueryable<Entity> query, string navigationPath, Expression<Func<Entity, bool>> whereExpression)
        {
            return query.Include(navigationPath).Where(whereExpression);
        }
        #endregion
    }
}