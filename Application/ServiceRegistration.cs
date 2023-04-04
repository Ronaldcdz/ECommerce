using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public static class ServiceRegistration
    {

        public static void AddApplicationLayer (this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductOrderService, ProductOrderService>();
        }


    }
}
