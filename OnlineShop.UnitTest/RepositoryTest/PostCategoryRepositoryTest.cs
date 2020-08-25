using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            this.dbFactory = new DbFactory();
            this.objRepository = new PostCategoryRepository(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = true;
            var result = objRepository.Add(category);
            unitOfWork.Commit();

            Assert.IsNotNull(result.ID);
        }

        [TestMethod]
        public void PosCategory_Repository_Update()
        {
            PostCategory category = new PostCategory();
            category.ID = 1;
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = false;
            objRepository.Update(category);
            unitOfWork.Commit();

            category = objRepository.GetSingleById(1);
            Assert.AreEqual(false, category.Status);
        }
    }
}
