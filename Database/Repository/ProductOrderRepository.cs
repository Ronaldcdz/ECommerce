using Database.Context;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Database.Repository
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductOrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProductsToOrderAsync (List<ProductOrder> productOrder)
        {
            await _dbContext.ProductOrders.AddRangeAsync (productOrder);
            await _dbContext.SaveChangesAsync();
        }

       

        public async Task<List<ProductOrder>> GetAllProductsByOrderIdAsync(int orderId)
        {
            var products = await _dbContext.Set<ProductOrder>().ToListAsync();

            List<ProductOrder> result = new List<ProductOrder>();   

            foreach(var product in products)
            {
                if (product.OrderId == orderId)
                {
                    result.Add(product);
                }
            }

            return result;


        }


    }
}
