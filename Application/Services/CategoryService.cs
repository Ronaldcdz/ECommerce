using Application.Interfaces.Repositories;
using AutoMapper;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Models;
using ECommerce.Application.ViewModels.Category;
using ECommerce.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<SaveCategoryViewModel> AddAsync(SaveCategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            category = await _categoryRepository.AddAsync(category);

            SaveCategoryViewModel categoryVm = _mapper.Map<SaveCategoryViewModel>(category);
            return categoryVm;
        }

        public async Task UpdateAsync(SaveCategoryViewModel categoryViewModel, int id)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            await _categoryRepository.UpdateAsync(category, id);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var categoryList = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryViewModel>>(categoryList);
        }

        public async Task<SaveCategoryViewModel> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<SaveCategoryViewModel>(category);
        }


    }
}
