using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Model;

namespace Blog.DataManager
{
    public class EntityManager:IEntityManager
    {
        private readonly IRepository _repository;

        #region [ CTOR ]
        public EntityManager(IRepository repository)
        {
            _repository = repository;
        }
        #endregion

        public Task<IEnumerable<TEntity>> GetAllItemListAsync<TEntity>() where TEntity : class, IEntity, new()
        {
            return _repository.GetList<TEntity>(x => x.Active);
        }

        //public Task<IEnumerable<TEntity>> FilterAsync<TEntity>(Func<TEntity, bool> predicate) where TEntity : class, IEntity, new()
        //{
        //    return _repository.GetList(predicate);
        //}

        public Task<TEntity> GetItemByKeyAsync<TEntity>(Guid key) where TEntity : class, IEntity, new()
        {
            return _repository.GetByKey<TEntity>(key);
        }

        public Task<TEntity> AddItemAsync<TEntity>(TEntity item) where TEntity : class, IEntity, new()
        {
            return _repository.Add(item);
        }

        public Task<TEntity> UpdateItemAsync<TEntity>(TEntity item) where TEntity : class, IEntity, new()
        {
            return _repository.Update(item);
        }

        public void DeleteItem<TEntity>(TEntity item) where TEntity : class, IEntity, new()
        {
            _repository.Delete(item);
        }
    }
}
