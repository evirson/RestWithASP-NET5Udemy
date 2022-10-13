using EstudoRest.Model;
using EstudoRest.Business;
using Microsoft.AspNetCore.Mvc;

namespace EstudoRest.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private IPersonBusiness _personBusiness;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;

            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult GetAll()
        {


            return Ok(_personBusiness.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetId(long id)
        {

            var person = _personBusiness.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {

            if (person == null) return BadRequest();

            return Ok(_personBusiness.Create(person));

        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {

            if (person == null) return BadRequest();

            return Ok(_personBusiness.Create(person));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {

            var person = _personBusiness.FindById(id);

            if (person == null) return NotFound();

            _personBusiness.Delete(id);

            return NoContent();

        }


    }
}
