namespace DL;

public interface IRepo
{

    List<Customer> GetCustomers();
    void AddCustomer(Customer newCustomer);
    void updateCustomer(List<Customer> allCustomers);
    List<Admin> GetAdmin();
    void AddAdmin(Admin newAdmin);
    List<StoreFront> GetStoreFronts();
    void addStoreFront(StoreFront newStore);
    void removeStoreFront(List<StoreFront> allStores, StoreFront exStore);
    void updateStoreFront(List<StoreFront> allStores);
    List<Product> GetProducts();
    void addProducts(Product newProduct);
    void removeProducts(List<Product> allProducts, Product exProduct);
    List<Inventory> GetInventories();
    void addInventory(Inventory newInventory);
    void removeInventory(List<Inventory> allInventory, Inventory exInventory);
    void updateInventory(int? quantity, Inventory updateInventory);
    List<LineItem> getLineItem();
    void addLineItem(LineItem newLineItem);
    void removeLineItem(List<LineItem> removeLineItem, LineItem exLineItem);
    void clearLineItem(List<LineItem> clearLineItem);
    List<Order> getOrders();
    void addOrder(Order newOrder);
    void updateOrder(decimal? totalPlus, Order updateOrder);
    StoreFront searchStoreFront(int? storeID);
    
    Product searchProduct(int? productID);
    Inventory searchInventory(int? inventoryID);
    bool isDuplicate(StoreFront store);
    bool isDuplicate(Product store);
    

    
    
}