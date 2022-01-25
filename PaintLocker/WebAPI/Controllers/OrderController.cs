using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IBL _bl;
        public OrderController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<OrderController>
        [HttpGet]
       
        public List<Order> Get()
        {
            return _bl.getOrders();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            Order orderFound = _bl.searchOrder(id);
            if(orderFound.OrderID != 0)
            {
                return Ok(orderFound);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<OrderController>
        [HttpPost("Start order")]
        public void Post(int orderID, [FromBody] Order orderToAdd)
        {
            _bl.addOrder(orderToAdd);
        }

        [HttpPost("Finalize Order")]
        public void Post([FromBody] Order orderToAdd)
        {
            int? Quan = 0;
            decimal? Cost = 0;
            decimal? Tots = 0;
            List<LineItem> getLineItem = _bl.getLineItem();
            foreach (LineItem searchLine in getLineItem)
            {
                if (searchLine.OrderID == orderToAdd.OrderID)
                {
                    Quan = searchLine.Quantity;
                    Cost = searchLine.ProductPrice;
                    Tots += (decimal?)Quan * Cost;
                }
            }
            _bl.updateOrder(Tots, orderToAdd);
        }
        /*
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
