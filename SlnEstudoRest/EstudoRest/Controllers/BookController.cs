using EstudoRest.Model;
using EstudoRest.Business;
using Microsoft.AspNetCore.Mvc;
using EstudoRest.HyperMedia.Filters;
using Microsoft.AspNetCore.Authorization;

namespace EstudoRest.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetAll()
        {


            return Ok(_bookBusiness.FindAll());

        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetId(long id)
        {

            var book = _bookBusiness.FindById(id);

            if (book == null) return NotFound();

            return Ok(book);

        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {

            if (book == null) return BadRequest();

            return Ok(_bookBusiness.Create(book));

        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
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
