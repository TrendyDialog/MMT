using Microsoft.EntityFrameworkCore;
using MMT.Domain.Interfaces;
using MMT.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MMT.Infra.Data.Repository
{
    /// <summary>
    /// Titan default Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected MMTContext context;
        protected DbSet<TEntity> DbSet;

        /// <summary>
        /// Inject Titan databese context
        /// </summary>
        /// <param name="context"></param>
        public Repository(MMTContext context)
        {
            this.context = context;
            DbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Create new Entity
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        /// <summary>
        /// Create new Entities
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddRange(List<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        /// <summary>
        /// Get specific record
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).FirstOrDefault<TEntity>();
        }

        /// <summary>
        /// Select entity by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(long id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Select all records from database
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        /// <summary>
        /// Select all records from database
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        /// <summary>
        /// Update existing entity
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void attach(TEntity obj)
        {
            DbSet.Update(obj);
        }

        /// <summary>
        /// Delete entity by GUID
        /// </summary>
        /// <param name="id"></param>
        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="id"></param>
        public virtual void RemoveRange(List<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Select from database
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        /// <summary>
        /// Commit database changes
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Remove(long id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
    }
}
