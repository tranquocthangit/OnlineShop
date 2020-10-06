using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { set; get; }
        public IEnumerable<MenuViewModel> Menus { set; get; }
        public IEnumerable<ProductViewModel> LastesProducts { set; get; }
        public IEnumerable<ProductViewModel> TopSaleProducts { set; get; }
        public IEnumerable<ProductCategoryViewModel> ProductCategories { set; get; }
    }
}