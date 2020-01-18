using System;
using System.Collections.Generic;
using Blog.Model;

namespace Blog.DataManager
{
    public interface IRepository
    {
        /// <summary>
        /// Get single item by predicate
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <param name="predicate">predicate - filter</param>
        /// <returns>item</returns>
        TEntity Get<TEntity>(Func<TEntity, bool> predicate) where TEntity : class, IEntity, new();

        /// <summary>
        /// Get single item by key
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <param name="Key">predicate - filter</param>
        /// <returns>item</returns>
        TEntity GetByKey<TEntity>(Guid Key) where TEntity : class, IEntity, new();

        /// <summary>
        /// Get item list by predicate
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <param name="predicate">predicate - filter</param>
        /// <returns>item list</returns>
        IEnumerable<TEntity> GetList<TEntity>(Func<TEntity, bool> predicate) where TEntity : class, IEntity, new();

        /// <summary>
        /// Insert item
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <param name="entity">new item</param>
        /// <returns>Inserted Item</returns>
        TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity, new();

        /// <summary>
        /// Update item
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <param name="entity">update item</param>
        /// <returns>Updated Item</returns>
        TEntity Update<TEntity>(TEntity entity) where TEntity : class, IEntity, new();

        /// <summary>
        /// Delete item
        /// </summary>
        /// <typeparam name="TEntity">Entity Item</typeparam>
        /// <param name="entity">delete item</param>
        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity, new();
    }
}
