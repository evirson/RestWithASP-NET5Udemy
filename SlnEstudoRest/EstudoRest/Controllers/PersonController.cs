using EstudoRest.Model;
using EstudoRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstudoRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private IPersonService _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;

            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {


            return Ok(_personService.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetId(long id)
        {

            var person = _personService.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {

            if (person == null) return BadRequest();

            return Ok(_personService.Create(person));

        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {

            if (person == null) return BadRequest();

            return Ok(_personService.Create(person));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {

            var person = _personService.FindById(id);

            if (person == null) return NotFound();

            _personService.Delete(id);

            return NoContent();

        }


    }
}
