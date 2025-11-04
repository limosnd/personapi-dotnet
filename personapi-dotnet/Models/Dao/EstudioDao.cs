using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Dao
{
 public class EstudioDao : IEstudioDao
 {
 private readonly ArqPerDbContext _context;
 public EstudioDao(ArqPerDbContext context)
 {
 _context = context;
 }
 public async Task<IEnumerable<Estudio>> GetAllAsync()
 {
 return await _context.Estudios.Include(e => e.IdProfNavigation).Include(e => e.CcPerNavigation).AsNoTracking().ToListAsync();
 }
 public async Task<Estudio?> GetByIdAsync(int idProf, int ccPer)
 {
 return await _context.Estudios.FindAsync(idProf, ccPer);
 }
 public async Task CreateAsync(Estudio estudio)
 {
 _context.Estudios.Add(estudio);
 await _context.SaveChangesAsync();
 }
 public async Task UpdateAsync(Estudio estudio)
 {
 _context.Estudios.Update(estudio);
 await _context.SaveChangesAsync();
 }
 public async Task DeleteAsync(int idProf, int ccPer)
 {
 var e = await _context.Estudios.FindAsync(idProf, ccPer);
 if (e != null)
 {
 _context.Estudios.Remove(e);
 await _context.SaveChangesAsync();
 }
 }
 public async Task<bool> ExistsAsync(int idProf, int ccPer)
 {
 return await _context.Estudios.AnyAsync(e => e.IdProf == idProf && e.CcPer == ccPer);
 }
 }
}
