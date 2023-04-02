using ECommerce.Application.Interfaces.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _productService.GetDetailsAsync(id));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}