using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Mappings
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<Product,ProductCategoryViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductTag, ProductTagViewModel>();
            CreateMap<MenuGroup, MenuGroupViewModel>();
            CreateMap<Menu, MenuViewModel>();
            //CreateMap<Slide, SlideViewModel>();
        }

        //public static void Configure()
        //{
        //    Mapper.CreateMap<Post, PostViewModel>();
        //    Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
        //    Mapper.CreateMap<Tag, TagViewModel>();
        //}

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutoMapperConfiguration>();
            });
        }
    }
}