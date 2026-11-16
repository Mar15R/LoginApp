using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

    }
}
