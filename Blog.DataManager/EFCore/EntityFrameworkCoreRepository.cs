using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<TEntity> Get<TEntity>(Func<TEntity, bool> predicate) where TEntity : class, IEntity, new()
        {
            var list = await _context.Set<TEntity>().ToListAsync();
            var returnList = list.ToList().SingleOrDefault(predicate);
            return returnList;
        }
        #endregion

        #region [ GetByKey ]
        public async Task<TEntity> GetByKey<TEntity>(Guid Key) where TEntity : class, IEntity, new()
        {
            var item = (TEntity)await _context.FindAsync(typeof(TEntity), Key);
            return item;
        }
        #endregion

        #region [ GetList ]
        public async Task<IEnumerable<TEntity>> GetList<TEntity>(Func<TEntity, bool> predicate) where TEntity : class, IEntity, new()
        {
            var list = await _context.Set<TEntity>().ToListAsync();
            var returnList = list.ToList().Where(predicate);
            return returnList;
        }
        #endregion

        #region [ Add ]
        public async Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        #endregion

        #region [ Update ]
        public async Task<TEntity> Update<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        #endregion

        #region [ Delete ]
        public async void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
