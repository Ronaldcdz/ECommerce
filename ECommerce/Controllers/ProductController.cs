using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            SaveProductViewModel productViewModel= new SaveProductViewModel();

            productViewModel.Categories = await _categoryService.GetAllAsync();

            return View("SaveProduct", productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                productViewModel.Categories = await _categoryService.GetAllAsync();
                return View("SaveProduct", productViewModel);
            }

            try
            {
                productViewModel = await _productService.AddAsync(productViewModel);

            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            product.Categories = await _categoryService.GetAllAsync();

            return View("SaveProduct", product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductViewModel productViewModel)
        {

            if (!ModelState.IsValid)
            {
                productViewModel.Categories = await _categoryService.GetAllAsync();
                return View("SaveProduct", productViewModel);
            }

            try
            {
                 await _productService.UpdateAsync(productViewModel, productViewModel.Id);

            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _productService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _productService.DeleteAsync(id);

            return RedirectToAction("Index");
        }


    }
}
