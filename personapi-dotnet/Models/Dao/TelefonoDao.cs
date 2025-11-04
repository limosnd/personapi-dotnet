using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Dao
{
 public class TelefonoDao : ITelefonoDao
 {
 private readonly ArqPerDbContext _context;
 public TelefonoDao(ArqPerDbContext context)
 {
 _context = context;
 }
 public async Task<IEnumerable<Telefono>> GetAllAsync()
 {
 return await _context.Telefonos.Include(t => t.DuenioNavigation).AsNoTracking().ToListAsync();
 }
 public async Task<Telefono?> GetByIdAsync(string num)
 {
 return await _context.Telefonos.FindAsync(num);
 }
 public async Task CreateAsync(Telefono telefono)
 {
 _context.Telefonos.Add(telefono);
 await _context.SaveChangesAsync();
 }
 public async Task UpdateAsync(Telefono telefono)
 {
 _context.Telefonos.Update(telefono);
 await _context.SaveChangesAsync();
 }
 public async Task DeleteAsync(string num)
 {
 var e = await _context.Telefonos.FindAsync(num);
 if (e != null)
 {
 _context.Telefonos.Remove(e);
 await _context.SaveChangesAsync();
 }
 }
 public async Task<bool> ExistsAsync(string num)
 {
 return await _context.Telefonos.AnyAsync(t => t.Num == num);
 }
 }
}
