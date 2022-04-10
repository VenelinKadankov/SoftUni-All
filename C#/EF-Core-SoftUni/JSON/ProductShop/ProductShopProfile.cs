using AutoMapper;
using ProductShop.DataTransferObject;
using ProductShop.Models;
using ProductShop.ViewModels;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategoryInputModel, Category>();
            this.CreateMap<CategoryProductModel, CategoryProduct>();

            //view models

            this.CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.FullNameSeller, y => y.MapFrom(s => s.Buyer.FirstName));
        }
    }
}
