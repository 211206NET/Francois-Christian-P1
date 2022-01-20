
namespace BL;

public class RRBL : IBL
{
    private IRepo _dl;
    public RRBL(IRepo repo)
    {
        _dl = repo;
    }

    public List<Customer> GetCustomers()
    { 
        return _dl.GetCustomers();
    }

    public void AddCustomer(Customer newCustomer)
    {
        _dl.AddCustomer(newCustomer);
    }
    public void updateCustomer(List<Customer> allCustomers)
    {
        _dl.updateCustomer(allCustomers);
    }

    public List<Admin> GetAdmin()
    { 
        return _dl.GetAdmin();
    }

    public void AddAdmin(Admin newAdmin)
    {
        _dl.AddAdmin(newAdmin);
    }

    public List<StoreFront> GetStoreFronts()
    {

        return _dl.GetStoreFronts();
    }

    public void addStoreFront(StoreFront newStore)
    {
        if(!_dl.isDuplicate(newStore))
        {
        _dl.addStoreFront(newStore);
        }
        else throw new DuplicateRecordException("A Store with same name already exists!");
    }

    public void removeStoreFront(List<StoreFront> allStores, StoreFront exStore)
    {
        _dl.removeStoreFront(allStores, exStore);
    }

    public void updateStoreFront(List<StoreFront> allStores)
    {
        _dl.updateStoreFront(allStores);
    }

public List<Product> GetProducts()
    {
        return _dl.GetProducts();
    }

    public void addProducts(Product newProduct)
    {
        if(!_dl.isDuplicate(newProduct))
        {
        _dl.addProducts(newProduct);
        }
        else throw new DuplicateRecordException("A Product with same name already exists!");
    }
    public void removeProducts(List<Product> allProducts, Product exProduct)
    {        
        _dl.removeProducts(allProducts, exProduct);
    }
    public List<Inventory> GetInventories()
    {
        return _dl.GetInventories();
    }

    public void addInventory(Inventory newInventory)
    {
        _dl.addInventory(newInventory);
    }

    public void removeInventory(List<Inventory> allInventory, Inventory exInventory)
    {
        _dl.removeInventory(allInventory, exInventory);
    }

    public void updateInventory(int? quantity, Inventory updateInventory)
    {       
        _dl.updateInventory(quantity, updateInventory);
    }
    
    public List<LineItem> getLineItem()
    {       
        return _dl.getLineItem();    
    }

    public void addLineItem(LineItem newLineItem)
    {
        _dl.addLineItem(newLineItem);
    }

    public void removeLineItem(List<LineItem> removeLineItem, LineItem exLineItem)
    {
        _dl.removeLineItem(removeLineItem, exLineItem);
    }

    public void clearLineItem(List<LineItem> clearLineItem)
    {
        _dl.clearLineItem(clearLineItem);
    }
    public List<Order> getOrders()
    {
        return _dl.getOrders();
    }
    
    public void addOrder(Order newOrder)
    {
        _dl.addOrder(newOrder);
    }
    public void updateOrder(decimal? totalPlus, Order updateOrder)
    {
        _dl.updateOrder(totalPlus, updateOrder);
    }
    public StoreFront searchStoreFront(int? storeID)
    {
        return _dl.searchStoreFront(storeID);
    }
    public Product searchProduct(int? productID)
    {
        return _dl.searchProduct(productID);
    }
    public Inventory searchInventory(int? inventoryID)
    {
        return _dl.searchInventory(inventoryID);
    }
}
