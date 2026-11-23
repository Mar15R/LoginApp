using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Lib
{
    public class Repository
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TEntity GetEntityByFilter<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            try
            {
                IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsNoTracking();

                return query.FirstOrDefault(filter);
            }
            catch { throw; }
        }
        public List<TEntity> GetEntitiesByFilter<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            try
            {
                IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsNoTracking();
                return query.Where(filter).ToList();
            }
            catch { throw; }
        }

        public TEntity GetEntityById<TEntity>(object id) where TEntity : class
        {
            try
            {
                return _dbContext.Set<TEntity>().Find(id);
            }
            catch { throw; }
        }
        public TEntity InsertEntity<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch { throw; }
        }
        public List<TEntity> GetEntities<TEntity>() where TEntity : class
        {
            try
            {
                return _dbContext.Set<TEntity>().AsNoTracking().ToList();
            }
            catch { throw; }
        }
        public List<TEntity> GetEntities<TEntity>(int count) where TEntity : class
        {
            try
            {
                return _dbContext.Set<TEntity>().AsNoTracking().Take(count).ToList();
            }
            catch { throw; }
        }
        
        public bool UpdateEntity<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                var entry = _dbContext.Entry(entity);

                if (entry.State == EntityState.Detached)
                {
                    var objectContext =
                        ((System.Data.Entity.Infrastructure.IObjectContextAdapter)_dbContext)
                        .ObjectContext;

                    var objectSet = objectContext.CreateObjectSet<TEntity>();

                    var key = objectSet.EntitySet.ElementType.KeyMembers
                        .Select(k => k.Name)
                        .ToArray();

                    var keyValues = key.Select(k =>
                        typeof(TEntity).GetProperty(k)?.GetValue(entity))
                        .ToArray();

                    var existingEntity = _dbContext.Set<TEntity>()
                        .Find(keyValues);

                    if (existingEntity != null)
                    {
                        _dbContext.Entry(existingEntity)
                            .CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        _dbContext.Set<TEntity>().Attach(entity);
                        _dbContext.Entry(entity).State = EntityState.Modified;
                    }
                }
                else
                {
                    entry.State = EntityState.Modified;
                }

                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
