using AutoMapper;
using ECommerce.Application.Models;
using ECommerce.Application.ViewModels.Category;
using ECommerce.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {

            CreateMap<Product, SaveProductViewModel>()
                .ForMember(x => x.Categories, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Category, opt => opt.Ignore())
                .ForMember(x => x.Orders, opt => opt.Ignore());


            CreateMap<Product, ProductViewModel>()
                .ReverseMap()
                .ForMember(x => x.Description, opt => opt.Ignore())
                .ForMember(x => x.Quantity, opt => opt.Ignore())
                .ForMember(x => x.CategoryId, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.Ignore())
                .ForMember(x => x.Orders, opt => opt.Ignore());


            CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(x => x.Category, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Category, opt => opt.Ignore())
                .ForMember(x => x.Orders, opt => opt.Ignore());



            CreateMap<Category, CategoryViewModel>()
                .ReverseMap()
                .ForMember(x => x.Products, opt => opt.Ignore());


            CreateMap<Category, SaveCategoryViewModel>()
                .ReverseMap()
                .ForMember(x => x.Products, opt => opt.Ignore());

            CreateMap<CategoryViewModel, SaveCategoryViewModel>()
                .ReverseMap();

        }


    }
}
