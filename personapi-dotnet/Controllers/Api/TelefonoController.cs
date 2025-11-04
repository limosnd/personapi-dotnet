using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoDao _dao;
        public TelefonoController(ITelefonoDao dao) => _dao = dao;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefono>>> GetAll() =>
            Ok(await _dao.GetAllAsync());

        [HttpGet("{num}")]
        public async Task<ActionResult<Telefono>> Get(string num)
        {
            var e = await _dao.GetByIdAsync(num);
            if (e == null) return NotFound();
            return Ok(e);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Telefono telefono)
        {
            await _dao.CreateAsync(telefono);
            return CreatedAtAction(nameof(Get), new { num = telefono.Num }, telefono);
        }

        [HttpPut("{num}")]
        public async Task<ActionResult> Update(string num, [FromBody] Telefono telefono)
        {
            if (num != telefono.Num) return BadRequest();
            var exists = await _dao.ExistsAsync(num);
            if (!exists) return NotFound();
            await _dao.UpdateAsync(telefono);
            return NoContent();
        }

        [HttpDelete("{num}")]
        public async Task<ActionResult> Delete(string num)
        {
            var exists = await _dao.ExistsAsync(num);
            if (!exists) return NotFound();
            await _dao.DeleteAsync(num);
            return NoContent();
        }
    }
}
