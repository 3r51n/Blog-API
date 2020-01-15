using Blog.DataManager;
using Blog.DataManager.EFCore;
using Blog.DataManager.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityManager.Test
{
    internal class Helper
    {
        private static DbContextOptions GetDbContextOptionInMemory()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return options;
        }

        public static IRepository GetEFCoreRepository()
        {
            var repo = new EntityFrameworkCoreRepository(new BlogDbContext(GetDbContextOptionInMemory() as DbContextOptions<BlogDbContext>));
            return repo;
        }

        public static IEntityManager GetEntityManager()
        {
            var repo = GetEFCoreRepository();
            var _manager = new Blog.DataManager.EntityManager(repo);
            return _manager;
        }
    }
}
