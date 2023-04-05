using ECommerce.Application.ViewModels.Cart;
using ECommerce.Application.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<SaveOrderViewModel> GetOrderViewModelAsync();

        Task<ConfirmationOrderViewModel> AddOrderAsync(SaveOrderViewModel orderViewModel);
        
        Task<List<OrderViewModel>> GetAllAsync();
    }
}
