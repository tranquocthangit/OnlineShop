using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Service;
using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IMenuService _menuService;
        ICommonService _commonService;
        IProductCategoryService _productCategoryService;
        IProductService _productService;

        public HomeController(IMenuService menuService
            , ICommonService commonService
            , IProductCategoryService productCategoryService
            , IProductService productService)
        {
            this._menuService = menuService;
            this._commonService = commonService;
            this._productCategoryService = productCategoryService;
            this._productService = productService;
        }

        public ActionResult Index()
        {
            var lastesProductModel = _productService.GetLastes(4);
            var topSaleProductModel = _productService.GetHotProduct(4);
            var lastesProductViewModel = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastesProductModel);
            var topSaleProductViewModel = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);

            var homeViewModel = new HomeViewModel();
            homeViewModel.LastesProducts = lastesProductViewModel;
            homeViewModel.TopSaleProducts = topSaleProductViewModel;

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var menus = _menuService.GetAllByMenuGroupId(1);
            var listMenuVm = AutoMapper.Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(menus);

            var productCategories = _productCategoryService.GetAll();
            var listproductcategoryVm = AutoMapper.Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategories);

            var homeViewModel = new HomeViewModel();
            homeViewModel.Menus = listMenuVm;
            homeViewModel.ProductCategories = listproductcategoryVm;

            return PartialView("Header", homeViewModel);
        }

        [ChildActionOnly]
        public ActionResult Footer() 
        {
            var footerModel = _commonService.GetFooter();
            var FooterVm = new FooterViewModel();
            AutoMapper.Mapper.Map(footerModel, FooterVm);

            return PartialView("Footer", FooterVm);
        }

        [ChildActionOnly]
        public ActionResult Banner()
        {
            var model = _commonService.GetSlide();

            var listSlideVm = AutoMapper.Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(model);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = listSlideVm;

            return PartialView("Banner", homeViewModel);
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}