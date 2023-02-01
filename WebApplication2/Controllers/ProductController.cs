using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebProblemDetails.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProblemDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private List<Product> _produts;

        public ProductController()
        {
            _produts = new List<Product>() {
                new Product() { Id = 1, Name = "Product 1", Category = "Exemple"},
                new Product() { Id = 2, Name = "Product 2", Category = "Exemple"},
                new Product() { Id = 3, Name = "Product 3", Category = "Exemple"}
            };
        }
        // GET: api/<ProductController>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult Get()
        {
            return Ok(_produts);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult Get(int id)
        {
            var product = new Product();
            IEnumerable<Product> products = _produts.Where(p => p.Id == id);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        // POST api/<ProductController>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public IActionResult Post([FromBody] Product value)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!_produts.Exists(p => p.Id == id)) {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(int id)
        {
            if (!_produts.Exists(p => p.Id == id))
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
