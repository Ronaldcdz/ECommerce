using ECommerce.Application.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Services
{
    public interface ICartService
    {
        Task<List<CartViewModel>> GetAllAsync();

        Task AddToCartAsync(int id);

        Task IncrementOneAsync(int id);

        Task DecrementOneAsync(int id);

        Task RemoveItemAsync(int id);



    }
}
