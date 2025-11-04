using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
 public class PersonaController : Controller
 {
 private readonly IPersonaDao _dao;

 public PersonaController(IPersonaDao dao)
 {
 _dao = dao;
 }

 // GET: Persona
 public async Task<IActionResult> Index()
 {
 var list = await _dao.GetAllAsync();
 return View(list);
 }

 // GET: Persona/Details/5
 public async Task<IActionResult> Details(int? id)
 {
 if (id == null) return NotFound();
 var persona = await _dao.GetByIdAsync(id.Value);
 if (persona == null) return NotFound();
 return View(persona);
 }

 // GET: Persona/Create
 public IActionResult Create()
 {
 return View();
 }

 // POST: Persona/Create
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Create([Bind("Cc,Nombre,Apellido,Genero,Edad")] Persona persona)
 {
 if (ModelState.IsValid)
 {
 await _dao.CreateAsync(persona);
 return RedirectToAction(nameof(Index));
 }
 return View(persona);
 }

 // GET: Persona/Edit/5
 public async Task<IActionResult> Edit(int? id)
 {
 if (id == null) return NotFound();
 var persona = await _dao.GetByIdAsync(id.Value);
 if (persona == null) return NotFound();
 return View(persona);
 }

 // POST: Persona/Edit/5
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Edit(int id, [Bind("Cc,Nombre,Apellido,Genero,Edad")] Persona persona)
 {
 if (id != persona.Cc) return NotFound();
 if (ModelState.IsValid)
 {
 await _dao.UpdateAsync(persona);
 return RedirectToAction(nameof(Index));
 }
 return View(persona);
 }

 // GET: Persona/Delete/5
 public async Task<IActionResult> Delete(int? id)
 {
 if (id == null) return NotFound();
 var persona = await _dao.GetByIdAsync(id.Value);
 if (persona == null) return NotFound();
 return View(persona);
 }

 // POST: Persona/Delete/5
 [HttpPost, ActionName("Delete")]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> DeleteConfirmed(int id)
 {
 await _dao.DeleteAsync(id);
 return RedirectToAction(nameof(Index));
 }
 }
}
