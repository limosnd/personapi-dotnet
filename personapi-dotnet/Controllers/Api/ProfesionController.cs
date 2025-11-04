File: Controllers\Api\ProfesionController.cs
````````csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionController : ControllerBase
    {
        private readonly IProfesionDao _dao;
        public ProfesionController(IProfesionDao dao) => _dao = dao;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesion>>> GetAll() =>
            Ok(await _dao.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Profesion>> Get(int id)
        {
            var e = await _dao.GetByIdAsync(id);
            if (e == null) return NotFound();
            return Ok(e);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Profesion profesion)
        {
            await _dao.CreateAsync(profesion);
            return CreatedAtAction(nameof(Get), new { id = profesion.Id }, profesion);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Profesion profesion)
        {
            if (id != profesion.Id) return BadRequest();
            var exists = await _dao.ExistsAsync(id);
            if (!exists) return NotFound();
            await _dao.UpdateAsync(profesion);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _dao.ExistsAsync(id);
            if (!exists) return NotFound();
            await _dao.DeleteAsync(id);
            return NoContent();
        }
    }
}
