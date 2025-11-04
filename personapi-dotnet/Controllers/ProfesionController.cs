using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
 public class ProfesionController : Controller
 {
 private readonly IProfesionDao _dao;
 public ProfesionController(IProfesionDao dao)
 {
 _dao = dao;
 }
 public async Task<IActionResult> Index()
 {
 var list = await _dao.GetAllAsync();
 return View(list);
 }
 public async Task<IActionResult> Details(int? id)
 {
 if (id == null) return NotFound();
 var e = await _dao.GetByIdAsync(id.Value);
 if (e == null) return NotFound();
 return View(e);
 }
 public IActionResult Create() => View();
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Create([Bind("Id,Nom,Des")] Profesion profesion)
 {
 if (ModelState.IsValid)
 {
 await _dao.CreateAsync(profesion);
 return RedirectToAction(nameof(Index));
 }
 return View(profesion);
 }
 public async Task<IActionResult> Edit(int? id)
 {
 if (id == null) return NotFound();
 var e = await _dao.GetByIdAsync(id.Value);
 if (e == null) return NotFound();
 return View(e);
 }
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Des")] Profesion profesion)
 {
 if (id != profesion.Id) return NotFound();
 if (ModelState.IsValid)
 {
 await _dao.UpdateAsync(profesion);
 return RedirectToAction(nameof(Index));
 }
 return View(profesion);
 }
 public async Task<IActionResult> Delete(int? id)
 {
 if (id == null) return NotFound();
 var e = await _dao.GetByIdAsync(id.Value);
 if (e == null) return NotFound();
 return View(e);
 }
 [HttpPost, ActionName("Delete")]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> DeleteConfirmed(int id)
 {
 await _dao.DeleteAsync(id);
 return RedirectToAction(nameof(Index));
 }
 }
}
