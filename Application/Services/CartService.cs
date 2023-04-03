using AutoMapper;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.ViewModels.Cart;
using ECommerce.Application.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CartService(IProductService productService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<List<CartViewModel>> GetAllAsync()
        {
            var cart = _httpContextAccessor.HttpContext.Session.Get<List<CartViewModel>>("cart");

            return cart;
        }

        public async Task AddToCartAsync(int id)
        {
            //Mapeo de SaveProductViewModel a CartViewModel 
            var product = _mapper.Map<CartViewModel>(await _productService.GetByIdAsync(id));
            var cart = _httpContextAccessor.HttpContext.Session.Get<List<CartViewModel>>("cart");

            int totalItem = product.Quantity;
            product.Quantity = 1;

            if (cart == null)
            {
                cart = new List<CartViewModel>
                {
                    product
                };
            }

            else
            {
                int index = cart.FindIndex(p => p.ProductId == id);


                if (index != -1) //Si el item esta en el carrito le aumenta la cantidad
                {
                    // Si la cantidad agregada excede de la cantidad total que haya no se agregara otra cantidad del producto
                    cart[index].Quantity = (cart[index].Quantity >= totalItem) ? cart[index].Quantity += 0 : cart[index].Quantity + 1;


                }

                else
                {
                    product.Quantity = 1;
                    cart.Add(product);
                }
            }

            _httpContextAccessor.HttpContext.Session.Set("cart", cart);
        }

        public async Task IncrementOneAsync(int id)
        {
            var product = _mapper.Map<CartViewModel>(await _productService.GetByIdAsync(id));
            var cart = _httpContextAccessor.HttpContext.Session.Get<List<CartViewModel>>("cart");

            int index = cart.FindIndex(p => p.ProductId == id);

            int totalItem = product.Quantity;
            cart[index].Quantity = (cart[index].Quantity >= totalItem) ? cart[index].Quantity += 0 : cart[index].Quantity + 1;

            _httpContextAccessor.HttpContext.Session.Set("cart", cart);
        }

        public async Task DecrementOneAsync(int id)
        {
            var product = _mapper.Map<CartViewModel>(await _productService.GetByIdAsync(id));
            var cart = _httpContextAccessor.HttpContext.Session.Get<List<CartViewModel>>("cart");

            int index = cart.FindIndex(p => p.ProductId == id);

            if (cart[index].Quantity == 1)
            {
                cart.RemoveAt(index);
            }

            else
            {
                cart[index].Quantity--;
            }

            _httpContextAccessor.HttpContext.Session.Set("cart", cart);
        }

        public async Task RemoveItemAsync(int id)
        {
            var product = _mapper.Map<CartViewModel>(await _productService.GetByIdAsync(id));
            var cart = _httpContextAccessor.HttpContext.Session.Get<List<CartViewModel>>("cart");

            int index = cart.FindIndex(p => p.ProductId == id);

            cart.RemoveAt(index);

            _httpContextAccessor.HttpContext.Session.Set("cart", cart);
        }
    }
}
