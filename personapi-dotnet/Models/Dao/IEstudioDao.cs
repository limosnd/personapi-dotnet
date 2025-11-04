using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Dao
{
 public interface IEstudioDao
 {
 Task<IEnumerable<Estudio>> GetAllAsync();
 Task<Estudio?> GetByIdAsync(int idProf, int ccPer);
 Task CreateAsync(Estudio estudio);
 Task UpdateAsync(Estudio estudio);
 Task DeleteAsync(int idProf, int ccPer);
 Task<bool> ExistsAsync(int idProf, int ccPer);
 }
}
