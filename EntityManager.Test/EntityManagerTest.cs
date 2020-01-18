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
            var inserted = _em.AddItem(item);
            // Assert
            Assert.NotNull(inserted);
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
            var insert1 = _em.AddItem(item1);
            var insert2 = _em.AddItem(item2);

            var list = _em.GetAllItemList<Category>();
            var resultCount = list.Count();
            // Assert
            Assert.NotNull(insert1);
            Assert.NotNull(insert2);
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
            var inserted = _em.AddItem(item);

            var getItem = _em.GetItemByKey<Category>(inserted.Key);
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
            var inserted = _em.AddItem(item);

            var getItem = _em.GetItemByKey<Category>(inserted.Key);
            getItem.Name = itemName;
            _em.UpdateItem(getItem);

            getItem = _em.GetItemByKey<Category>(inserted.Key);
            // Assert
            Assert.NotEqual(initialName, getItem.Name);
            Assert.Equal(itemName, getItem.Name);
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
            var inserted = _em.AddItem(item);

            var getItem = _em.GetItemByKey<Category>(inserted.Key);
            _em.DeleteItem(getItem);

            getItem = _em.GetItemByKey<Category>(inserted.Key);
            
            // Assert
            Assert.Null(getItem);
        }
    }
}
