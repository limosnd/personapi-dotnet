using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Dao
{
 public interface ITelefonoDao
 {
 Task<IEnumerable<Telefono>> GetAllAsync();
 Task<Telefono?> GetByIdAsync(string num);
 Task CreateAsync(Telefono telefono);
 Task UpdateAsync(Telefono telefono);
 Task DeleteAsync(string num);
 Task<bool> ExistsAsync(string num);
 }
}
