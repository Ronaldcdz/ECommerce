using AutoMapper;
using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        public async Task<IActionResult> Index()
        {
            var cart = await _cartService.GetAllAsync();

            if (cart != null)
            {
                ViewBag.Total = cart.Sum(c => c.Quantity * c.Price);
            }

            else
            {
                cart = new List<CartViewModel>();
                ViewBag.Total = 0;
            }

            return View(cart);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            await _cartService.AddToCartAsync(id);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> IncrementOne(int id)
        {
            await _cartService.IncrementOneAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MinusOne(int id)
        {

           await _cartService.DecrementOneAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            await _cartService.RemoveItemAsync(id);
            return RedirectToAction("Index");
        }


    }
}
