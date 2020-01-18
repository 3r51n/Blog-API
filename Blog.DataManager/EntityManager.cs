using System;
using System.Collections.Generic;
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

        public IEnumerable<TEntity> GetAllItemList<TEntity>() where TEntity : class, IEntity, new()
        {
            return _repository.GetList<TEntity>(x => x.Active);
        }

        public TEntity GetItemByKey<TEntity>(Guid key) where TEntity : class, IEntity, new()
        {
            return _repository.GetByKey<TEntity>(key);
        }

        public TEntity AddItem<TEntity>(TEntity item) where TEntity : class, IEntity, new()
        {
            return _repository.Add(item);
        }

        public TEntity UpdateItem<TEntity>(TEntity item) where TEntity : class, IEntity, new()
        {
            return _repository.Update(item);
        }

        public void DeleteItem<TEntity>(TEntity item) where TEntity : class, IEntity, new()
        {
            _repository.Delete(item);
        }
    }
}
