using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Dao
{
 public class PersonaDao : IPersonaDao
 {
 private readonly ArqPerDbContext _context;

 public PersonaDao(ArqPerDbContext context)
 {
 _context = context;
 }

 public async Task<IEnumerable<Persona>> GetAllAsync()
 {
 return await _context.Personas.AsNoTracking().ToListAsync();
 }

 public async Task<Persona?> GetByIdAsync(int cc)
 {
 return await _context.Personas.FindAsync(cc);
 }

 public async Task CreateAsync(Persona persona)
 {
 _context.Personas.Add(persona);
 await _context.SaveChangesAsync();
 }

 public async Task UpdateAsync(Persona persona)
 {
 _context.Personas.Update(persona);
 await _context.SaveChangesAsync();
 }

 public async Task DeleteAsync(int cc)
 {
 var entity = await _context.Personas.FindAsync(cc);
 if (entity != null)
 {
 _context.Personas.Remove(entity);
 await _context.SaveChangesAsync();
 }
 }

 public async Task<bool> ExistsAsync(int cc)
 {
 return await _context.Personas.AnyAsync(p => p.Cc == cc);
 }
 }
}
