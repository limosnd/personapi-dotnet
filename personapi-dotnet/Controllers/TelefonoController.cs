using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
 public class TelefonoController : Controller
 {
 private readonly ITelefonoDao _dao;
 private readonly IPersonaDao _perDao;
 public TelefonoController(ITelefonoDao dao, IPersonaDao perDao)
 {
 _dao = dao;
 _perDao = perDao;
 }
 public async Task<IActionResult> Index()
 {
 var list = await _dao.GetAllAsync();
 return View(list);
 }
 public async Task<IActionResult> Details(string id)
 {
 if (id == null) return NotFound();
 var e = await _dao.GetByIdAsync(id);
 if (e == null) return NotFound();
 return View(e);
 }
 public async Task<IActionResult> Create()
 {
 ViewData["Duenio"] = new SelectList(await _perDao.GetAllAsync(), "Cc", "Nombre");
 return View();
 }
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Create([Bind("Num,Oper,Duenio")] Telefono telefono)
 {
 if (ModelState.IsValid)
 {
 await _dao.CreateAsync(telefono);
 return RedirectToAction(nameof(Index));
 }
 ViewData["Duenio"] = new SelectList(await _perDao.GetAllAsync(), "Cc", "Nombre", telefono.Duenio);
 return View(telefono);
 }
 public async Task<IActionResult> Edit(string id)
 {
 if (id == null) return NotFound();
 var e = await _dao.GetByIdAsync(id);
 if (e == null) return NotFound();
 ViewData["Duenio"] = new SelectList(await _perDao.GetAllAsync(), "Cc", "Nombre", e.Duenio);
 return View(e);
 }
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Edit(string id, [Bind("Num,Oper,Duenio")] Telefono telefono)
 {
 if (id != telefono.Num) return NotFound();
 if (ModelState.IsValid)
 {
 await _dao.UpdateAsync(telefono);
 return RedirectToAction(nameof(Index));
 }
 ViewData["Duenio"] = new SelectList(await _perDao.GetAllAsync(), "Cc", "Nombre", telefono.Duenio);
 return View(telefono);
 }
 public async Task<IActionResult> Delete(string id)
 {
 if (id == null) return NotFound();
 var e = await _dao.GetByIdAsync(id);
 if (e == null) return NotFound();
 return View(e);
 }
 [HttpPost, ActionName("Delete")]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> DeleteConfirmed(string id)
 {
 await _dao.DeleteAsync(id);
 return RedirectToAction(nameof(Index));
 }
 }
}
