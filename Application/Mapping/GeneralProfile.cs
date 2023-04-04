using AutoMapper;
using ECommerce.Application.Models;
using ECommerce.Application.ViewModels.Cart;
using ECommerce.Application.ViewModels.Category;
using ECommerce.Application.ViewModels.Order;
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

            #region Products
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


            CreateMap<ProductViewModel, CartViewModel>()
                .ForMember(x => x.ProductId, opt => opt.MapFrom(p => p.Id))
                .ForMember(x => x.Subtotal, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.MapFrom(c => c.ProductId));



            #endregion

            #region Categories

            CreateMap<Category, CategoryViewModel>()
                .ReverseMap()
                .ForMember(x => x.Products, opt => opt.Ignore());


            CreateMap<Category, SaveCategoryViewModel>()
                .ReverseMap()
                .ForMember(x => x.Products, opt => opt.Ignore());

            CreateMap<CategoryViewModel, SaveCategoryViewModel>()
                .ReverseMap();

            #endregion

            #region Cart

            CreateMap<CartViewModel, SaveProductViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(p => p.ProductId))
                .ForMember(x => x.CategoryId, opt => opt.Ignore())
                .ForMember(x => x.Categories, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.ProductId, opt => opt.MapFrom(p => p.Id))
                .ForMember(x => x.Subtotal, opt => opt.Ignore());

            #endregion


            #region Order

            CreateMap<Order, SaveOrderViewModel>()
                .ForMember(x => x.CreditCardNumber, opt => opt.Ignore())
                .ForMember(x => x.CreditCardOwnerName, opt => opt.Ignore())
                .ForMember(x => x.CreditCardValidity, opt => opt.Ignore())
                .ForMember(x => x.CreditCardCvv, opt => opt.Ignore())
                .ForMember(x => x.CartItems, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Products, opt => opt.Ignore());


            #endregion


        }


    }
}
