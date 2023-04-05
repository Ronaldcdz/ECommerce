using AutoMapper;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Models;
using ECommerce.Application.ViewModels.Cart;
using ECommerce.Application.ViewModels.Order;
using ECommerce.Application.ViewModels.Product;
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
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductOrderService(IProductOrderRepository productOrderRepository, IMapper mapper, IProductService productService)
        {
            _productOrderRepository = productOrderRepository;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task AddFromSaveOrderViewModelAsync(SaveOrderViewModel orderViewModel)
        {
            List<ProductOrder> productsOrderList = new List<ProductOrder>();

            ProductOrder productsOrder = new ProductOrder();
            
            foreach(CartViewModel cartViewModel in orderViewModel.CartItems)
            {
                productsOrder.OrderId = orderViewModel.Id;
                productsOrder.ProductId = cartViewModel.ProductId;
                productsOrder.ProductQuantity = cartViewModel.Quantity;
                productsOrderList.Add(productsOrder);
            }

            await _productOrderRepository.AddProductsToOrderAsync(productsOrderList);

        }


        public async Task<List<ProductViewModel>> GetAllProductsByOrderIdAsync(int orderId)
        {
            //Lista mapeada
            var productViewModel = _mapper.Map<List<ProductViewModel>>(await _productOrderRepository.GetAllProductsByOrderIdAsync(orderId));


            //Nueva lista con datos faltantes como el nombre e imagen
            List<ProductViewModel> productsOrderList = new List<ProductViewModel>();

            //Objeto para obtener solamente los datos necesarios
            ProductViewModel singleProduct = new ProductViewModel();

            foreach(var product in productViewModel)
            {
                singleProduct = await _productService.GetProductInfoByIdAsync(product.Id);
                singleProduct.Quantity = product.Quantity;
                productsOrderList.Add(singleProduct);
            }

            return productsOrderList;
        }


    }
}
