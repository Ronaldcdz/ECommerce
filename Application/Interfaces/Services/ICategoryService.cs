using ECommerce.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<SaveCategoryViewModel> AddAsync(SaveCategoryViewModel categoryViewModel);
        Task UpdateAsync(SaveCategoryViewModel categoryViewModel, int id);
        Task DeleteAsync(int id);
        Task<List<CategoryViewModel>> GetAllAsync();
        Task<SaveCategoryViewModel> GetByIdAsync(int id);
    }
}
