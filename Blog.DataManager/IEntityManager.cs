using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Model;

namespace Blog.DataManager
{
    public interface IEntityManager
    {
        /// <summary>
        /// Get All Item List
        /// </summary>
        /// <returns>Item List</returns>
        Task<IEnumerable<TEntity>> GetAllItemListAsync<TEntity>() where TEntity : class, IEntity, new();

        //Task<IEnumerable<TEntity>> FilterAsync<TEntity>(Func<TEntity, bool> predicate) where TEntity : class, IEntity, new();
        
        /// <summary>
        /// Get Item By Key
        /// </summary>
        /// <param name="key">Key property value</param>
        /// <returns>Item</returns>
        Task<TEntity> GetItemByKeyAsync<TEntity>(Guid key) where TEntity : class, IEntity, new();

        /// <summary>
        /// Add New Item
        /// </summary>
        /// <param name="item">New Item</param>
        /// <returns>Inserted Item</returns>
        Task<TEntity> AddItemAsync<TEntity>(TEntity item) where TEntity : class, IEntity, new();

        /// <summary>
        /// Update an exist item
        /// </summary>
        /// <param name="item">Item(Update model)</param>
        /// <returns>Updated Item</returns>
        Task<TEntity> UpdateItemAsync<TEntity>(TEntity item) where TEntity : class, IEntity, new();

        /// <summary>
        /// Delete an exist item
        /// </summary>
        /// <param name="item">Item (Delete model)</param>
        void DeleteItem<TEntity>(TEntity item) where TEntity : class, IEntity, new();
    }
}
