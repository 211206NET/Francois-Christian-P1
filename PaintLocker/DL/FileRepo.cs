namespace DL;

public class FileRepo : IRepo
{
    public FileRepo()
    {}

    private String fileCustomer = "../DL/customer.json";
    private String fileStoreFront = "../DL/storefront.json";
    private String fileAdmin = "../DL/admin.json";
    private String fileProduct = "../DL/product.json";
    private String fileInventory = "../DL/inventory.json";
    private String fileLineItem = "../DL/lineitem.json";
    private String fileOrder = "../Dl/order.json";
    
    public List<Customer> GetCustomers()
    { 
        String jsonCustomer = File.ReadAllText(fileCustomer);
        return JsonSerializer.Deserialize<List<Customer>>(jsonCustomer) ?? new List<Customer>();
    }

    public void AddCustomer(Customer newCustomer)
    {
        List<Customer> allCustomers = GetCustomers();
        allCustomers.Add(newCustomer);
        String jsonCustomerAdd = JsonSerializer.Serialize(allCustomers);
        File.WriteAllText(fileCustomer, jsonCustomerAdd);
    }

    public void updateCustomer(List<Customer> allCustomers)
    {
        String jsonCustomerUpdate = JsonSerializer.Serialize<List<Customer>>(allCustomers);
        File.WriteAllText(fileCustomer, jsonCustomerUpdate);
    }

    
    public List<Admin> GetAdmin()
    { 
        String jsonAdmin = File.ReadAllText(fileAdmin);
        return JsonSerializer.Deserialize<List<Admin>>(jsonAdmin) ?? new List<Admin>();
    }

    public void AddAdmin(Admin newAdmin)
    {
        List<Admin> allAdmins = GetAdmin();
        allAdmins.Add(newAdmin);
        String jsonAdminAdd = JsonSerializer.Serialize(allAdmins);
        File.WriteAllText(fileAdmin, jsonAdminAdd);
    }
    public List<StoreFront> GetStoreFronts()
    {
        String jsonStoreFront = File.ReadAllText(fileStoreFront);
        return JsonSerializer.Deserialize<List<StoreFront>>(jsonStoreFront) ?? new List<StoreFront>();
    }

    public void addStoreFront(StoreFront newStore)
    {
        List<StoreFront> allStores = GetStoreFronts();
        allStores.Add(newStore);
        String jsonStoreFrontAdd = JsonSerializer.Serialize<List<StoreFront>>(allStores);
        File.WriteAllText(fileStoreFront, jsonStoreFrontAdd);
    }

    public void removeStoreFront(List<StoreFront> allStores, StoreFront exStore)
    {
        allStores.Remove(exStore);
        String jsonStoreFrontRemove = JsonSerializer.Serialize<List<StoreFront>>(allStores);
        File.WriteAllText(fileStoreFront, jsonStoreFrontRemove);
    }

    public void updateStoreFront(List<StoreFront> allStores)
    {
        String jsonStoreFrontUpdate = JsonSerializer.Serialize<List<StoreFront>>(allStores);
        File.WriteAllText(fileStoreFront, jsonStoreFrontUpdate);
    }

    public List<Product> GetProducts()
    {
        String jsonProduct = File.ReadAllText(fileProduct);   
        return JsonSerializer.Deserialize<List<Product>>(jsonProduct) ?? new List<Product>();
    }

    public void addProducts(Product newProduct)
    {
        List<Product> allProducts = GetProducts();
        allProducts.Add(newProduct);
        String jsonProductAdd = JsonSerializer.Serialize<List<Product>>(allProducts);
        File.WriteAllText(fileProduct, jsonProductAdd);
    }

    public void removeProducts(List<Product> allProducts, Product exProduct)
    {        
        allProducts.Remove(exProduct);
        String jsonProductRemove = JsonSerializer.Serialize<List<Product>>(allProducts);
        File.WriteAllText(fileProduct, jsonProductRemove);
    }

    public List<Inventory> GetInventories()
    {
        String jsonInventory = File.ReadAllText(fileInventory);
        return JsonSerializer.Deserialize<List<Inventory>>(jsonInventory) ?? new List<Inventory>();
    }

    public void addInventory(Inventory newInventory)
    {
        List<Inventory> allInventory = GetInventories();
        allInventory.Add(newInventory);         
        String jsonInventoryAdd = JsonSerializer.Serialize<List<Inventory>>(allInventory);
        File.WriteAllText(fileInventory, jsonInventoryAdd);
    }

    public void removeInventory(List<Inventory> allInventory, Inventory exInventory)
    {
        allInventory.Remove(exInventory);
        String jsonInventoryRemove = JsonSerializer.Serialize<List<Inventory>>(allInventory);
        File.WriteAllText(fileInventory, jsonInventoryRemove);
    }

    public void updateInventory(int? quantity, Inventory updateInventory)
    {       
        String jsonInventoryupdate = JsonSerializer.Serialize(updateInventory);
        File.WriteAllText(fileInventory, jsonInventoryupdate);
    }
    
    public List<LineItem> getLineItem()
    {       
        String jsonLineItem = File.ReadAllText(fileLineItem);
        return JsonSerializer.Deserialize<List<LineItem>>(jsonLineItem) ?? new List<LineItem>();       
    }

    public void addLineItem(LineItem newLineItem)
    {
        List<LineItem> allLineItem = getLineItem();
        allLineItem.Add(newLineItem);
        String jsonLineItemAdd = JsonSerializer.Serialize<List<LineItem>>(allLineItem);
        File.WriteAllText(fileLineItem, jsonLineItemAdd);
    }
    
    public void removeLineItem(List<LineItem> removeLineItem, LineItem exLineItem)
    {
        removeLineItem.Remove(exLineItem);
        String jsonLineItemClear = JsonSerializer.Serialize<List<LineItem>>(removeLineItem);
        File.WriteAllText(fileLineItem, jsonLineItemClear);
    }

    public void clearLineItem(List<LineItem> clearLineItem)
    {
        String jsonLineItemClear = JsonSerializer.Serialize<List<LineItem>>(clearLineItem);
        File.WriteAllText(fileLineItem, jsonLineItemClear);
    }

    public List<Order> getOrders()
    {
        String jsonOrder = File.ReadAllText(fileOrder);
        return JsonSerializer.Deserialize<List<Order>>(jsonOrder) ?? new List<Order>();
    }

    public void addOrder(Order newOrder)
    {
        List<Order> addOrder = getOrders();
        addOrder.Add(newOrder);
        String jsonOrderAdd = JsonSerializer.Serialize<List<Order>>(addOrder);
        File.WriteAllText(fileOrder, jsonOrderAdd);

    }

    public void updateOrder(decimal? totalPlus, Order updateOrder)
    {

    }

    public StoreFront searchStoreFront(int? storeID)
    {
        throw new NotImplementedException();
    }
    public Product searchProduct(int? productID)
    {
        throw new NotImplementedException();
    }
    public Inventory searchInventory(int? inventoryID)
    {
        throw new NotImplementedException();
    }
    public bool isDuplicate(StoreFront store)
    {
        throw new NotImplementedException();
    }
    public bool isDuplicate(Product store)
    {
        throw new NotImplementedException();
    }
}