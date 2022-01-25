using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IBL _bl;
        public ProductController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            return _bl.GetProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product productFound = _bl.searchProduct(id);
            if (productFound.ProductID != 0)
            {
                return Ok(productFound);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product productToAdd)
        {
            try 
            {
                _bl.addProducts(productToAdd);
                return Created("Sucessfully Created", productToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
            catch (InputInvalidException ex)
            {
                return Conflict(ex.Message);
            }
        }
        /*
        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
