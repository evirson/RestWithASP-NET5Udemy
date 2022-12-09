using EstudoRest.Model;
using EstudoRest.Business;
using Microsoft.AspNetCore.Mvc;
using EstudoRest.HyperMedia.Filters;
using Microsoft.AspNetCore.Authorization;
using EstudoRest.Data.VO;

namespace EstudoRest.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CadGruController : ControllerBase
    {

        private ICadGruBusiness _cadGruBusiness;
        private readonly ILogger<CadGruController> _logger;

        public CadGruController(ILogger<CadGruController> logger, ICadGruBusiness cadGruBusiness)
        {
            _logger = logger;

            _cadGruBusiness = cadGruBusiness;
        }

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(List<CadGruVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(402)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(
            [FromQuery] string? nomgru,
            string sortDirection,
            int pageSize,
            int page)
        {

            return Ok(_cadGruBusiness.FindWithPagedSearch(nomgru, sortDirection, pageSize, page));

        }

        [HttpGet("{codGru}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetCod(string codGru)
        {

            var cadGru = _cadGruBusiness.FindByCodGru(codGru);

            if (cadGru == null) return NotFound();

            return Ok(cadGru);

        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] CadGruVO cadGru)
        {

            if (cadGru == null) return BadRequest();

            return Ok(_cadGruBusiness.Create(cadGru));

        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] CadGruVO cadGru)
        {

            if (cadGru == null) return BadRequest();

            return Ok(_cadGruBusiness.Update(cadGru));

        }

        [HttpDelete("{codGru}")]
        public IActionResult Delete(string codGru)
        {

            var cadGru = _cadGruBusiness.FindByCodGru(codGru);

            if (cadGru == null) return NotFound();

            _cadGruBusiness.Delete(codGru);

            return NoContent();

        }


    }
}
