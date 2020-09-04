using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using System.Collections.Generic;

namespace OnlineShop.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        IEnumerable<Product> GetAllByCategoryId(int parentId);

        Product GetById(int id);

        void Save();
    }

    internal class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository ProductRepository, IUnitOfWork unitOfWork)
        {
            this._ProductRepository = ProductRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            return _ProductRepository.Add(product);
        }

        public Product Delete(int id)
        {
            return _ProductRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _ProductRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _ProductRepository.GetAll();
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryID)
        {
            return _ProductRepository.GetMulti(x => x.Status && x.CategoryID == categoryID);
        }

        public Product GetById(int id)
        {
            return _ProductRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _ProductRepository.Update(product);
        }
    }
}