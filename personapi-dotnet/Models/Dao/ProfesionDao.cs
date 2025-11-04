using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Dao
{
 public class ProfesionDao : IProfesionDao
 {
 private readonly ArqPerDbContext _context;
 public ProfesionDao(ArqPerDbContext context)
 {
 _context = context;
 }
 public async Task<IEnumerable<Profesion>> GetAllAsync()
 {
 return await _context.Profesions.AsNoTracking().ToListAsync();
 }
 public async Task<Profesion?> GetByIdAsync(int id)
 {
 return await _context.Profesions.FindAsync(id);
 }
 public async Task CreateAsync(Profesion profesion)
 {
 _context.Profesions.Add(profesion);
 await _context.SaveChangesAsync();
 }
 public async Task UpdateAsync(Profesion profesion)
 {
 _context.Profesions.Update(profesion);
 await _context.SaveChangesAsync();
 }
 public async Task DeleteAsync(int id)
 {
 var e = await _context.Profesions.FindAsync(id);
 if (e != null)
 {
 _context.Profesions.Remove(e);
 await _context.SaveChangesAsync();
 }
 }
 public async Task<bool> ExistsAsync(int id)
 {
 return await _context.Profesions.AnyAsync(p => p.Id == id);
 }
 }
}
