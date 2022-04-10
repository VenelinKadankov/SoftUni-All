﻿using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputDto, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategoryInputModel, Category>();
            this.CreateMap<CategoryProductInputModel, CategoryProduct>();
        }
    }
}
