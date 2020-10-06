namespace OnlineShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineShop.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShop.Data.OnlineShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineShop.Data.OnlineShopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateMenuGroupSample(context);
            CreateMenuSample(context);
            CreateSlideSample(context);
            ////  This method will be called after migrating to the latest version.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new OnlineShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new OnlineShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "thangtran",
            //    Email = "tranquocthang.it@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Tran Quoc Thang"

            //};

            //manager.Create(user, "123654$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tranquocthang.it@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(OnlineShop.Data.OnlineShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                     new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                      new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                       new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void CreateMenuGroupSample(OnlineShop.Data.OnlineShopDbContext context)
        {
            if (context.MenuGroups.Count() == 0)
            {
                List<MenuGroup> listMenuGroup = new List<MenuGroup>()
                {
                    new MenuGroup() { Name="Menu Top" },
                };
                context.MenuGroups.AddRange(listMenuGroup);
                context.SaveChanges();
            }
        }

        private void CreateMenuSample(OnlineShop.Data.OnlineShopDbContext context)
        {
            if (context.Menus.Count() == 0)
            {
                List<Menu> listMenu = new List<Menu>()
                {
                    new Menu() { Name="Trang chủ", URL="/", DisplayOrder=1, GroupID=1,Target="_self",Status=true },
                     new Menu() { Name="Giới thiệu", URL="/gioi-thieu", DisplayOrder=2, GroupID=1,Target="_self",Status=true },
                      new Menu() { Name="Sản phẩm", URL="/san-pham", DisplayOrder=3, GroupID=1,Target="_self",Status=true },
                       new Menu() { Name="Liên hệ", URL="/lien-he", DisplayOrder=4, GroupID=1,Target="_self",Status=true },
                };
                context.Menus.AddRange(listMenu);
                context.SaveChanges();
            }
        }

        private void CreateSlideSample(OnlineShop.Data.OnlineShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() { Name = "Slide 1", Description = "", DisplayOrder = 1, Status = true, Url = "#", Image= "", Content="Điện lạnh" }
                    ,new Slide() { Name = "Slide 2", Description = "", DisplayOrder = 2, Status = true, Url = "#", Image= "", Content="Viễn thông" }
                    ,new Slide() { Name = "Slide 3", Description = "", DisplayOrder = 3, Status = true, Url = "#", Image= "", Content="Đồ gia dụng + Mỹ phẩm" }
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
    }
}
