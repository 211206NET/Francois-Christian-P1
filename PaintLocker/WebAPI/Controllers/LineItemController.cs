using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineItemController : ControllerBase
    {
        private IBL _bl;
        public LineItemController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<LineItemController>
        [HttpGet]
        public List<LineItem> Get()
        {
            return _bl.getLineItem();
        }

        // GET api/<LineItemController>/5
        [HttpGet("LineItem by {OrderID}")]
        public List<LineItem> Get(int id)
        {
            return _bl.searchOrderLineItem(id);
        }

        // POST api/<LineItemController>
        [HttpPost("{InventoryID}")]
        public ActionResult<LineItem> Post(int storeID, int InventoryID, int quantity, [FromBody] LineItem lineitemToAdd)
        {
            List<Inventory> allInventory = _bl.GetInventories();
            Inventory inventoryFound = _bl.searchInventory(InventoryID);
       
            if (inventoryFound.ProductID == lineitemToAdd.ProductID && inventoryFound.ProductName == lineitemToAdd.ProductName && inventoryFound.ProductPrice == lineitemToAdd.ProductPrice && inventoryFound.StoreID == storeID)
            {
                _bl.addLineItem(lineitemToAdd);
                Inventory currentInventory = _bl.searchInventory(InventoryID);
                List<Inventory> getInventory = _bl.GetInventories();
                int? Amount = 0;
                foreach (Inventory searchInventory in getInventory)
                {
                    if (searchInventory.InventoryID == currentInventory.InventoryID)
                    {
                        Amount += (searchInventory.Quantity - quantity);
                    }
                }
                _bl.updateInventory(Amount, currentInventory);
                return Created("Sucessfully created", lineitemToAdd);
            }
            else
            {
                return Conflict("LineItem not found, inputs may not match invenotory values");
            }
        }

        /*
        // PUT api/<LineItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LineItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
