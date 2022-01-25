using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IBL _bl;
        public InventoryController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<InventoryController>
        [HttpGet]
        public List <Inventory> Get()
        {
            return _bl.GetInventories();
        }

        // GET api/<InventoryController>/5
        [HttpGet("{StoreID}")]
        public List<Inventory> Get(int StoreID)
        {
            return _bl.searchStoreInventory(StoreID);
        }

        // POST api/<InventoryController>
        [HttpPost("{StoreID}")]
        public ActionResult<Inventory> Post([FromBody] Inventory inventoryToAdd)
        {
            List<Product> productList = _bl.GetProducts();
            Product productFound = new Product();   
            foreach(Product searchProduct in productList)
            {
                if(searchProduct.Name == inventoryToAdd.ProductName && searchProduct.Price == inventoryToAdd.ProductPrice && searchProduct.ProductID == inventoryToAdd.ProductID)
                {
                    productFound = searchProduct;
                    break;
                }
            }
            Inventory checkInventory = new Inventory();
            List<Inventory> allInventory = _bl.GetInventories();
            foreach (Inventory searchInventory in allInventory)
            {
                if (searchInventory.ProductID == inventoryToAdd.ProductID && searchInventory.StoreID == inventoryToAdd.StoreID)
                {
                    checkInventory = searchInventory;
                    break;
                }
            }
            if (productFound.ProductID != null && checkInventory.ProductID == null)
            {
                _bl.addInventory(inventoryToAdd);
                return Created("Sucessfully Added to inventory", inventoryToAdd);
            }
            else
            {
                return Conflict("Store already sells product or wrong values inputed");
            }
        }

        /*
        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
