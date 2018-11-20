using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Web;

namespace HK.BussinessLogic
{
    public class GenericRepository<TEntity> : IDisposable
        where TEntity: Entity , new ()
    {
        internal DatosEntities context;
        internal DbSet<TEntity> dbSet;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
        }
        ~GenericRepository()
        {
            Dispose(false);
        }
        public GenericRepository(DatosEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual dynamic GetFirst()
        {
            var item = dbSet.FirstOrDefault();
            return item;
        }
        public virtual TEntity GetFirst(
        Expression<Func<TEntity, bool>> filter = null,
        string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            var item = query.FirstOrDefault();
            return item;
        }
        public virtual TEntity GetLast( Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            var x = query.ToList();
          
            return x.LastOrDefault();
        }
        //
        public virtual IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }
        public virtual IEnumerable<TEntity> GetAsNoTracking(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query.AsQueryable();
            }
        }
        public virtual IQueryable<TEntity> Query()
        {
            return dbSet.AsQueryable();
        }
        public virtual IQueryable<TEntity> GetAsQueryable(string includeProperties)
        {
            IQueryable<TEntity> query = dbSet.AsQueryable();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.AsQueryable();
        }
        public virtual TEntity Find(object id)
        {
            var item = dbSet.Find(id);
            if (item != null)
                item.EsNuevo = false;
            return item;
        }
        public virtual void Insert(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
            }
            catch (Exception x)
            {
                string s = x.Message;
            }
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            try
            {
                if (context.Entry(entityToUpdate).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToUpdate);
                }
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
            catch (Exception x)
            {
                string s = x.Message;
            }
        }
        public IQueryable<TEntity> Query<T>()
        {
            return dbSet.AsQueryable();
        }
        public virtual DbSet<TEntity> GetDbSet()
        {

            return dbSet;
        }
    }
}
