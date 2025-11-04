using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaDao _dao;
        public PersonaController(IPersonaDao dao) => _dao = dao;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetAll() =>
            Ok(await _dao.GetAllAsync());

        [HttpGet("{cc:int}")]
        public async Task<ActionResult<Persona>> Get(int cc)
        {
            var p = await _dao.GetByIdAsync(cc);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Persona persona)
        {
            await _dao.CreateAsync(persona);
            return CreatedAtAction(nameof(Get), new { cc = persona.Cc }, persona);
        }

        [HttpPut("{cc:int}")]
        public async Task<ActionResult> Update(int cc, [FromBody] Persona persona)
        {
            if (cc != persona.Cc) return BadRequest();
            var exists = await _dao.ExistsAsync(cc);
            if (!exists) return NotFound();
            await _dao.UpdateAsync(persona);
            return NoContent();
        }

        [HttpDelete("{cc:int}")]
        public async Task<ActionResult> Delete(int cc)
        {
            var exists = await _dao.ExistsAsync(cc);
            if (!exists) return NotFound();
            await _dao.DeleteAsync(cc);
            return NoContent();
        }
    }
}
