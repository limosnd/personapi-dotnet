using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
 public class EstudioController : Controller
 {
 private readonly IEstudioDao _dao;
 private readonly IProfesionDao _profDao;
 private readonly IPersonaDao _perDao;
 public EstudioController(IEstudioDao dao, IProfesionDao profDao, IPersonaDao perDao)
 {
 _dao = dao;
 _profDao = profDao;
 _perDao = perDao;
 }
 public async Task<IActionResult> Index()
 {
 var list = await _dao.GetAllAsync();
 return View(list);
 }
 public async Task<IActionResult> Details(int? idProf, int? ccPer)
 {
 if (idProf == null || ccPer == null) return NotFound();
 var e = await _dao.GetByIdAsync(idProf.Value, ccPer.Value);
 if (e == null) return NotFound();
 return View(e);
 }
 public async Task<IActionResult> Create()
 {
 ViewData["IdProf"] = new SelectList(await _profDao.GetAllAsync(), "Id", "Nom");
 ViewData["CcPer"] = new SelectList(await _perDao.GetAllAsync(), "Cc", "Nombre");
 return View();
 }
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Create([Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
 {
 if (ModelState.IsValid)
 {
 await _dao.CreateAsync(estudio);
 return RedirectToAction(nameof(Index));
 }
 ViewData["IdProf"] = new SelectList(await _profDao.GetAllAsync(), "Id", "Nom", estudio.IdProf);
 ViewData["CcPer"] = new SelectList(await _perDao.GetAllAsync(), "Cc", "Nombre", estudio.CcPer);
 return View(estudio);
 }
 public async Task<IActionResult> Edit(int? idProf, int? ccPer)
 {
 if (idProf == null || ccPer == null) return NotFound();
 var e = await _dao.GetByIdAsync(idProf.Value, ccPer.Value);
 if (e == null) return NotFound();
 ViewData["IdProf"] = new SelectList(await _profDao.GetAllAsync(), "Id", "Nom", e.IdProf);
 ViewData["CcPer"] = new SelectList(await _perDao.GetAllAsync(), "Cc", "Nombre", e.CcPer);
 return View(e);
 }
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Edit(int idProf, int ccPer, [Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
 {
 if (idProf != estudio.IdProf || ccPer != estudio.CcPer) return NotFound();
 if (ModelState.IsValid)
 {
 await _dao.UpdateAsync(estudio);
 return RedirectToAction(nameof(Index));
 }
 ViewData["IdProf"] = new SelectList(await _profDao.GetAllAsync(), "Id", "Nom", estudio.IdProf);
 ViewData["CcPer"] = new SelectList(await _perDao.GetAllAsync(), "Cc", "Nombre", estudio.CcPer);
 return View(estudio);
 }
 public async Task<IActionResult> Delete(int? idProf, int? ccPer)
 {
 if (idProf == null || ccPer == null) return NotFound();
 var e = await _dao.GetByIdAsync(idProf.Value, ccPer.Value);
 if (e == null) return NotFound();
 return View(e);
 }
 [HttpPost, ActionName("Delete")]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> DeleteConfirmed(int idProf, int ccPer)
 {
 await _dao.DeleteAsync(idProf, ccPer);
 return RedirectToAction(nameof(Index));
 }
 }
}
