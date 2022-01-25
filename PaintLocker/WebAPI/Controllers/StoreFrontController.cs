using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreFrontController : ControllerBase
    {
        private IBL _bl;
        public StoreFrontController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<StoreFrontController>
        [HttpGet]
        public List<StoreFront> Get()
        {
            return _bl.GetStoreFronts();
        }

        // GET api/<StoreFrontController>/5
        [HttpGet("{id}")]
        public ActionResult<StoreFront> Get(int id)
        {
            StoreFront storeFound = _bl.searchStoreFront(id);
            if(storeFound.StoreID != 0)
            {
                return Ok(storeFound);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<StoreFrontController>
        [HttpPost]
        public ActionResult<StoreFront> Post([FromBody] StoreFront storeToAdd)
        {
            try
            {
                _bl.addStoreFront(storeToAdd);
                return Created("Sucessfully Created", storeToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }
        /*
        // PUT api/<StoreFrontController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreFrontController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
