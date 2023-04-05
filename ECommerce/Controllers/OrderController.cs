using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.ViewModels.Cart;
using ECommerce.Application.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;

        public OrderController(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }



        public async Task<IActionResult> Buy()
        {
            var orderViewModel = await _orderService.GetOrderViewModelAsync();
            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(SaveOrderViewModel orderViewModel)
        {
            orderViewModel.CartItems = await _cartService.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return View(orderViewModel);
            }

            await _orderService.AddOrderAsync(orderViewModel);

            return RedirectToAction("Confirmation");

        }

        public IActionResult Confirmation(ConfirmationOrderViewModel confirmationView)
        {
            return View(confirmationView);
        }

        public async Task<IActionResult> Index ()
        {
            return View(await _orderService.GetAllAsync());
        }

    }
}
