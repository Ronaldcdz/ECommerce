using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Models;
using ECommerce.Application.ViewModels.Cart;
using ECommerce.Application.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly IProductOrderRepository _productOrderRepository;

        public ProductOrderService(IProductOrderRepository productOrderRepository)
        {
            _productOrderRepository = productOrderRepository;
        }

        public async Task AddFromSaveOrderViewModelAsync(SaveOrderViewModel orderViewModel)
        {
            List<ProductOrder> productsOrderList = new List<ProductOrder>();

            ProductOrder productsOrder = new ProductOrder();
            
            foreach(CartViewModel cartViewModel in orderViewModel.CartItems)
            {
                productsOrder.OrderId = orderViewModel.Id;
                productsOrder.ProductId = cartViewModel.ProductId;
                productsOrderList.Add(productsOrder);
            }

            await _productOrderRepository.AddProductsToOrderAsync(productsOrderList);

        }
    }
}
