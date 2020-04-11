﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MMT.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Default IRepository
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adding new entry
        /// </summary>
        /// <param name="obj"></param>
        void Add(TEntity obj);

        /// <summary>
        /// Adding new entries
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(List<TEntity> entities);

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(long id);

        /// <summary>
        /// Get all the items
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Update an Item
        /// </summary>
        /// <param name="obj"></param>
        void Update(TEntity obj);

        void attach(TEntity obj);

        /// <summary>
        /// Remove Items
        /// </summary>
        /// <param name="id"></param>
        void Remove(long id);

        /// <summary>
        /// Remove Items
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(List<TEntity> entities);

        /// <summary>
        /// Find All Items
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(Expression<Func<TEntity, bool>> where);
        /// <summary>
        /// Save Changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}