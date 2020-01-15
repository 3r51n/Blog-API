using System;
using System.Linq;
using Blog.DataManager;
using Xunit;
using Blog.Model;

namespace EntityManager.Test
{
    public class EntityManagerTest
    {
        private readonly IEntityManager _em;
        public EntityManagerTest()
        {
            _em = Helper.GetEntityManager();
        }

        [Fact]
        public void InsertNewCategory()
        {
            // Arrange
            //var cm = Helper.GetEntityManager();
            var item = new Category()
            {
                CreateDate = DateTime.Now,
                Name = "ASP.NET Core",
                ParentKey = null,
                ParentCategory = null,

            };

            // Act
            var insertTask = _em.AddItemAsync(item);
            insertTask.Wait();
            var inserted = insertTask.Result;
            // Assert
            Assert.NotNull(insertTask);
            Assert.NotEqual(default(Guid), inserted.Key);
        }

        [Fact]
        public void GetAllCategories()
        {
            //var cm = GetManager();

            // Arrange
            var item1 = new Category()
            {
                CreateDate = DateTime.Now,
                Name = "ASP.NET Core",
                ParentKey = null,
                ParentCategory = null,
                Active = true,

            };
            var item2 = new Category()
            {
                CreateDate = DateTime.Now,
                Name = "C#",
                ParentKey = null,
                ParentCategory = null,
                Active = true,

            };
            // Act
            var insertTask = _em.AddItemAsync(item1);
            var insertTask2 = _em.AddItemAsync(item2);

            var listTask = _em.GetAllItemListAsync<Category>();
            listTask.Wait();
            var resultCount = listTask.Result.Count();
            // Assert
            Assert.NotNull(insertTask.Result);
            Assert.NotNull(insertTask2.Result);
            Assert.Equal(2, resultCount);
        }

        [Fact]
        public void GetByKeyCategory()
        {
            //var cm = GetManager();

            // Arrange
            var item = new Category()
            {
                CreateDate = DateTime.Now,
                Name = "ASP.NET Core",
                ParentKey = null,
                ParentCategory = null,

            };
            // Act
            var insertTask = _em.AddItemAsync(item);
            insertTask.Wait();
            var inserted = insertTask.Result;

            var getByKey = _em.GetItemByKeyAsync<Category>(inserted.Key);
            getByKey.Wait();
            var getItem = getByKey.Result;
            // Assert
            Assert.Equal(inserted, getItem);
        }

        [Fact]
        public void UpdateCategory()
        {
            //var cm = GetManager();
            var initialName = "ASP.NET Core";
            var itemName = "ASP.NET Core MVC";
            // Arrange
            var item = new Category()
            {
                CreateDate = DateTime.Now,
                Name = initialName,
                ParentKey = null,
                ParentCategory = null,

            };
            // Act
            var insertTask = _em.AddItemAsync(item);
            insertTask.Wait();
            var key = insertTask.Result.Key;

            var getItem = _em.GetItemByKeyAsync<Category>(key);
            getItem.Wait();
            getItem.Result.Name = itemName;
            var updateTask = _em.UpdateItemAsync(getItem.Result);
            updateTask.Wait();

            getItem = _em.GetItemByKeyAsync<Category>(key);
            getItem.Wait();
            // Assert
            Assert.NotEqual(initialName, getItem.Result.Name);
            Assert.Equal(itemName, getItem.Result.Name);
        }

        [Fact]
        public void DeleteCategory()
        {
            //var cm = GetManager();
            var initialName = "ASP.NET Core";
            // Arrange
            var item = new Category()
            {
                CreateDate = DateTime.Now,
                Name = initialName,
                ParentKey = null,
                ParentCategory = null,

            };
            // Act
            var insertTask = _em.AddItemAsync(item);
            insertTask.Wait();
            var key = insertTask.Result.Key;

            var getItem = _em.GetItemByKeyAsync<Category>(key);
            getItem.Wait();

            _em.DeleteItem(getItem.Result);

            getItem = _em.GetItemByKeyAsync<Category>(key);
            getItem.Wait();
            // Assert
            Assert.Null(getItem.Result);
        }
    }
}
