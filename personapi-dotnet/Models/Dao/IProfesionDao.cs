using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Dao
{
 public interface IProfesionDao
 {
 Task<IEnumerable<Profesion>> GetAllAsync();
 Task<Profesion?> GetByIdAsync(int id);
 Task CreateAsync(Profesion profesion);
 Task UpdateAsync(Profesion profesion);
 Task DeleteAsync(int id);
 Task<bool> ExistsAsync(int id);
 }
}
