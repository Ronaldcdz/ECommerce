using Application.Interfaces.Repositories;
using Database.Context;
using Database.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    //Decorator method Pattern
    public static class ServiceRegistration
    {
        public static void AddDatabaseLayer(this IServiceCollection services, IConfiguration configuration)
        {



            // Agregando el servicio para inyeccion de depedencia a la hora de usar la base de datos 
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            //Inyeccion de dependencia con los servicios genericos
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
        }
    }
}
