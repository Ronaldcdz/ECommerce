using ECommerce.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Repositories
{
    public interface IProductOrderRepository
    {
        Task AddProductsToOrderAsync(List<ProductOrder> productsOrder);


        Task<List<ProductOrder>> GetAllProductsByOrderIdAsync(int orderId);
    }
}
