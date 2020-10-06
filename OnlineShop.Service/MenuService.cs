using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repositories;
using OnlineShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service
{
    public interface IMenuService
    {
        Menu Add(Menu Menu);

        void Update(Menu Menu);

        Menu Delete(int id);

        IEnumerable<Menu> GetAll();

        IEnumerable<Menu> GetAll(string keyword);

        IEnumerable<Menu> GetAllByMenuGroupId(int parentId);

        Menu GetById(int id);

        void Save();
    }

    public class MenuService : IMenuService
    {
        private IMenuRepository _menuRepository;
        private IUnitOfWork _unitOfWork;

        public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this._menuRepository = menuRepository;
            this._unitOfWork = unitOfWork;
        }

        public Menu Add(Menu Menu)
        {
            return _menuRepository.Add(Menu);
        }

        public Menu Delete(int id)
        {
            return _menuRepository.Delete(id);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public IEnumerable<Menu> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _menuRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _menuRepository.GetAll();
        }

        public IEnumerable<Menu> GetAllByMenuGroupId(int parentId)
        {
            return _menuRepository.GetMulti(x => x.Status && x.GroupID == parentId);
        }

        public Menu GetById(int id)
        {
            return _menuRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Menu Menu)
        {
            _menuRepository.Update(Menu);
        }
    }
}
