using AutoMapper;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Models;
using ECommerce.Application.ViewModels.Order;
using ECommerce.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        private readonly IProductOrderService _productOrderService;
        private readonly IProductService _productService;
        public OrderService(IOrderRepository orderRepository, IMapper mapper, ICartService cartService, IProductOrderService productOrderService, IProductService productService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _cartService = cartService;
            _productOrderService = productOrderService;
            _productService = productService;
        }

       

        public async Task<SaveOrderViewModel> GetOrderViewModelAsync()
        {
            var cartItems = await _cartService.GetAllAsync();

            SaveOrderViewModel orderViewModel = new SaveOrderViewModel {
                Date = DateTime.UtcNow.Date,
                Subtotal = cartItems.Sum(c => c.Quantity * c.Price),
                CartItems = cartItems,
            };

            orderViewModel.Taxes = 0.18 * orderViewModel.Subtotal;
            orderViewModel.Total = orderViewModel.Subtotal + orderViewModel.Taxes;

            return orderViewModel;
        }


        public async Task<ConfirmationOrderViewModel> AddOrderAsync(SaveOrderViewModel orderViewModel)
        {
            orderViewModel.Subtotal = orderViewModel.CartItems.Sum(c => c.Quantity * c.Price);
            orderViewModel.Taxes = 0.18 * orderViewModel.Subtotal;
            orderViewModel.Total = orderViewModel.Subtotal + orderViewModel.Taxes;

            var order = _mapper.Map<Order>(orderViewModel);

            order = await _orderRepository.AddAsync(order);

            orderViewModel.Id= order.Id;

            await _productOrderService.AddFromSaveOrderViewModelAsync(orderViewModel);

            foreach(var products in orderViewModel.CartItems)
            {
                await _cartService.RemoveItemAsync(products.ProductId);
            }

            List<ProductViewModel> productList = _mapper.Map<List<ProductViewModel>>(orderViewModel.CartItems);
            await _productService.UpdateProductsQuantityAsync(productList);

            return new ConfirmationOrderViewModel();
        }

        public Task GetAllAsync()
        {
            throw new NotImplementedException();
        }

    }
}
