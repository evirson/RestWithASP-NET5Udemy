using EstudoRest.Model;
using EstudoRest.Business;
using Microsoft.AspNetCore.Mvc;

namespace EstudoRest.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {

        private IBookBusiness _bookBusiness;
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;

            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult GetAll()
        {


            return Ok(_bookBusiness.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetId(long id)
        {

            var book = _bookBusiness.FindById(id);

            if (book == null) return NotFound();

            return Ok(book);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {

            if (book == null) return BadRequest();

            return Ok(_bookBusiness.Create(book));

        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {

            if (book == null) return BadRequest();

            return Ok(_bookBusiness.Create(book));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {

            var person = _bookBusiness.FindById(id);

            if (person == null) return NotFound();

            _bookBusiness.Delete(id);

            return NoContent();

        }


    }
}
