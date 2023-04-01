using ECommerce.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<SaveProductViewModel> AddAsync(SaveProductViewModel productViewModel);
        Task UpdateAsync(SaveProductViewModel productViewModel, int id);
        Task DeleteAsync(int id);
        Task<List<ProductViewModel>> GetAllAsync();
        Task<SaveProductViewModel> GetByIdAsync(int id);

        //Obtener todos los datos pero con sus joins
    }
}
