using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;

    namespace personapi_dotnet.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudioController : ControllerBase
    {
        private readonly IEstudioDao _dao;
        public EstudioController(IEstudioDao dao) => _dao = dao;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudio>>> GetAll() =>
            Ok(await _dao.GetAllAsync());

        [HttpGet("{idProf:int}/{ccPer:int}")]
        public async Task<ActionResult<Estudio>> Get(int idProf, int ccPer)
        {
            var e = await _dao.GetByIdAsync(idProf, ccPer);
            if (e == null) return NotFound();
            return Ok(e);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Estudio estudio)
        {
            await _dao.CreateAsync(estudio);
            return CreatedAtAction(nameof(Get),
                new { idProf = estudio.IdProf, ccPer = estudio.CcPer }, estudio);
        }

        [HttpPut("{idProf:int}/{ccPer:int}")]
        public async Task<ActionResult> Update(int idProf, int ccPer, [FromBody] Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer) return BadRequest();
            var exists = await _dao.ExistsAsync(idProf, ccPer);
            if (!exists) return NotFound();
            await _dao.UpdateAsync(estudio);
            return NoContent();
        }

        [HttpDelete("{idProf:int}/{ccPer:int}")]
        public async Task<ActionResult> Delete(int idProf, int ccPer)
        {
            var exists = await _dao.ExistsAsync(idProf, ccPer);
            if (!exists) return NotFound();
            await _dao.DeleteAsync(idProf, ccPer);
            return NoContent();
        }
    }
}
