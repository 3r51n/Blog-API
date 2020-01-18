using System;
using System.Collections.Generic;
using System.Linq;
using Blog.DataManager.EFCore.Context;
using Blog.Model;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataManager.EFCore
{
    public class EntityFrameworkCoreRepository:IRepository
    {
        private readonly DbContext _context;

        #region [ CTOR ]
        public EntityFrameworkCoreRepository(BlogDbContext context)
        {
            _context = context;
        }

        #endregion

        #region [ Get ]
        public TEntity Get<TEntity>(Func<TEntity, bool> predicate) where TEntity : class, IEntity, new()
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }
        #endregion

        #region [ GetByKey ]
        public TEntity GetByKey<TEntity>(Guid Key) where TEntity : class, IEntity, new()
        {
            var item = (TEntity) _context.Find(typeof(TEntity), Key);
            return item;
        }
        #endregion

        #region [ GetList ]
        public IEnumerable<TEntity> GetList<TEntity>(Func<TEntity, bool> predicate) where TEntity : class, IEntity, new()
        {
            return _context.Set<TEntity>().Where(predicate);
        }
        #endregion

        #region [ Add ]
        public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            _context.Add(entity);
            _context.SaveChanges();

            return entity;
        }
        #endregion

        #region [ Update ]
        public TEntity Update<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        #endregion

        #region [ Delete ]
        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
        #endregion
    }
}
