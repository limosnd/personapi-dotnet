using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Dao
{
 public interface IPersonaDao
 {
 Task<IEnumerable<Persona>> GetAllAsync();
 Task<Persona?> GetByIdAsync(int cc);
 Task CreateAsync(Persona persona);
 Task UpdateAsync(Persona persona);
 Task DeleteAsync(int cc);
 Task<bool> ExistsAsync(int cc);
 }
}
