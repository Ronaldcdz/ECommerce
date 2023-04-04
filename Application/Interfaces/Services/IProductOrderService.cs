using ECommerce.Application.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services
{
    public interface IProductOrderService
    {
        Task AddFromSaveOrderViewModelAsync(SaveOrderViewModel orderViewModel);
    }
}
