using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);
        Task<Entity> UpdateAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);

        //Obtener todos los datos pero con sus joins
        Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties);  
    }
}
