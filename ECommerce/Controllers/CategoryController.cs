using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Experimental.ProjectCache;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View("SaveCategory", new SaveCategoryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveCategoryViewModel categoryViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("SaveCategory",categoryViewModel);
            }

            try
            {
                categoryViewModel = await _categoryService.AddAsync(categoryViewModel);
            }

            catch(Exception ex) 
            { 
                ViewBag.Error = ex.Message;
            }


            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return View("SaveCategory", category);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SaveCategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveCategory", categoryViewModel);
            }

            try
            {
                await _categoryService.UpdateAsync(categoryViewModel, categoryViewModel.Id);
            }

            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _categoryService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _categoryService.DeleteAsync(id);

            return RedirectToAction("Index");
        }


    }
}
