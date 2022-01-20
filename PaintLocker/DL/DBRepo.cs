using Microsoft.Data.SqlClient;
using System.Data;

namespace DL;

public class DBRepo : IRepo
{

private String _connectionString;
    public DBRepo(String connectionString)
    {
        _connectionString = connectionString;
    }
    public void AddAdmin(Admin newAdmin)
    {
        throw new NotImplementedException();
    }

    public void AddCustomer(Customer newCustomer)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO Customer (Username, Passcode) VALUES (@username, @passcode)";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@username", newCustomer.Username);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@passcode", newCustomer.Password);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();            
            }
            connection.Close();
        }
    }

    public void addInventory(Inventory newInventory)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO Inventory (StoreID, ProductID, Name, Description, Price, Quantity) VALUES (@storeID, @productID, @name, @description, @price, @quantity)";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@storeID", newInventory.StoreID);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@productID", newInventory.ProductID);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@name", newInventory.ProductName);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@description", newInventory.ProductDescription);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@price", newInventory.ProductPrice);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@quantity", newInventory.Quantity);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();            
            }
            connection.Close();
        }
    }

    public void addLineItem(LineItem newLineItem)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO LineItem (OrderID, ProductID, Name, Description, Price, Quantity) VALUES (@orderID, @productID, @name, @description, @price, @quantity)";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@orderID", newLineItem.OrderID);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@productID", newLineItem.ProductID);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@name", newLineItem.ProductName);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@description", newLineItem.ProductDescription);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@price", newLineItem.ProductPrice);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@quantity", newLineItem.Quantity);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void addOrder(Order newOrder)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO Orders (CustomerID, StoreID, Total) VALUES (@customerID, @storeID, @total)";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@customerID", newOrder.CustomerID);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@storeID", newOrder.StoreID);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@total", newOrder.Total);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void addProducts(Product newProduct)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO Product (Name, Description, Price) VALUES (@name, @description, @price)";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@name", newProduct.Name);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@description", newProduct.Description);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@price", newProduct.Price);
                cmd.Parameters.Add(param);          
                cmd.ExecuteNonQuery();            
            }
            connection.Close();
        }
    }

    public void addStoreFront(StoreFront newStore)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO StoreFront (Name, Address) VALUES (@name, @address)";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@name", newStore.Name);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@address", newStore.Address);
                cmd.Parameters.Add(param);         
                cmd.ExecuteNonQuery();            
            }
            connection.Close();
        }
    }

    public void clearLineItem(List<LineItem> clearLineItem)
    {
        throw new NotImplementedException();
    }

    public List<Admin> GetAdmin()
    {
        List<Admin> allAdmin = new List<Admin>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            String queryTxt = "SELECT * FROM Admin";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Admin Admin = new Admin();
                        Admin.ID = reader.GetInt32(0);
                        Admin.Username = reader.GetString(1);
                        Admin.Password = reader.GetString(2);                    
                        allAdmin.Add(Admin);
                    }                    
                }
            }
            connection.Close();
        }
        return allAdmin;
    }

    public List<Customer> GetCustomers()
    {
        List<Customer> allCustomer = new List<Customer>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        String customerSelect = "SELECT * FROM Customer";
        String orderSelect = "SELECT * FROM Orders";
        DataSet CustomerSet = new DataSet();
        using SqlDataAdapter customerAdapter = new SqlDataAdapter(customerSelect, connection);
        using SqlDataAdapter orderAdapter = new SqlDataAdapter(orderSelect, connection);
        customerAdapter.Fill(CustomerSet, "Customer");
        orderAdapter.Fill(CustomerSet, "Orders");
        DataTable? CustomerTable = CustomerSet.Tables["Customer"];
        DataTable? OrderTable = CustomerSet.Tables["Orders"];
        if(CustomerTable != null && OrderTable != null)
        {
            foreach(DataRow row in CustomerTable.Rows)
            {
                Customer customer = new Customer();
                customer.ID = (int) row["CustomerID"];
                customer.Username = row["Username"].ToString();
                customer.Password = row["Passcode"].ToString();
                customer.Orders = OrderTable.AsEnumerable().Where(r => (int) r["CustomerID"] == customer.ID).Select
                (
                    r =>
                    new Order
                    {
                        OrderID = (int) r["OrderID"],
                        Total =  (decimal) r["Total"],
                        CustomerID = (int) r["CustomerID"],
                        StoreID = (int) r["StoreID"]                        
                    }
                )
                .ToList();
                allCustomer.Add(customer);
            }
        }       
        return allCustomer;
    }

    public List<Inventory> GetInventories()
    {
        List<Inventory> allInventory = new List<Inventory>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            String queryTxt = "SELECT * FROM Inventory";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Inventory Inventory = new Inventory();
                        Inventory.InventoryID = reader.GetInt32(0);
                        Inventory.Quantity = reader.GetInt32(1);
                        Inventory.ProductName = reader.GetString(2);
                        Inventory.ProductDescription = reader.GetString(3);
                        Inventory.ProductPrice = reader.GetDecimal(4);
                        Inventory.ProductID = reader.GetInt32(5);
                        Inventory.StoreID = reader.GetInt32(6);
                        allInventory.Add(Inventory);
                    }                    
                }
            }
            connection.Close();
        }
        return allInventory;
    }

    public List<LineItem> getLineItem()
    {
        List<LineItem> allLineItem = new List<LineItem>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            String queryTxt = "SELECT * FROM LineItem";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        LineItem LineItem = new LineItem();
                        LineItem.LineItemID = reader.GetInt32(0);
                        LineItem.Quantity = reader.GetInt32(1);
                        LineItem.ProductName = reader.GetString(2);
                        LineItem.ProductDescription = reader.GetString(3);
                        LineItem.ProductPrice = reader.GetDecimal(4);
                        LineItem.ProductID = reader.GetInt32(5);
                        LineItem.OrderID = reader.GetInt32(6);
                        allLineItem.Add(LineItem);
                    }                    
                }
            }
            connection.Close();
        }
        return allLineItem;
    }

    public List<Order> getOrders()
    {
        List<Order> allOrder = new List<Order>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        String OrderSelect = "SELECT * FROM Orders";
        String LineItemSelect = "SELECT * FROM LineItem";

        DataSet OrderSet = new DataSet();

        using SqlDataAdapter OrderAdapter = new SqlDataAdapter(OrderSelect, connection);
        using SqlDataAdapter LineItemAdapter = new SqlDataAdapter(LineItemSelect, connection);
        OrderAdapter.Fill(OrderSet, "Orders");
        LineItemAdapter.Fill(OrderSet, "LineItem");

        DataTable? OrderTable = OrderSet.Tables["Orders"];
        DataTable? LineItemTable = OrderSet.Tables["LineItem"];

        if(OrderTable != null && LineItemTable != null)
        {
            foreach(DataRow row in OrderTable.Rows)
            {
                Order Order = new Order();
                Order.OrderID = (int) row["OrderID"];
                Order.Total = (decimal) row["Total"];
                Order.CustomerID = (int) row["CustomerID"];
                Order.StoreID = (int) row["StoreID"];
                Order.LineItems = LineItemTable.AsEnumerable().Where(r => (int) r["OrderID"] == Order.OrderID).Select
                (
                    r =>
                    new LineItem
                    {
                        LineItemID = (int) r["LineItemID"],
                        Quantity =  (int) r["Quantity"],
                        ProductName = r["Name"].ToString() ?? "",
                        ProductDescription = r["Description"].ToString() ?? "",
                        ProductPrice = (decimal) r["Price"],
                        OrderID = (int) r["OrderID"],
                        ProductID = (int) r["ProductID"]                        
                    }
                )
                .ToList();
                allOrder.Add(Order);
            }
        }       
        return allOrder;
    }

    public List<Product> GetProducts()
    {
        List<Product> allProduct = new List<Product>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            String queryTxt = "SELECT * FROM Product";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Product product = new Product();
                        product.ProductID = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Description = reader.GetString(2);
                        product.Price = reader.GetDecimal(3);
                        allProduct.Add(product);
                    }                    
                }
            }
            connection.Close();
        }
        return allProduct;
    }

    public List<StoreFront> GetStoreFronts()
    {
        List<StoreFront> allStoreFront = new List<StoreFront>();
        using SqlConnection connection = new SqlConnection(_connectionString);

        String StoreFrontSelect = "SELECT * FROM StoreFront";
        String orderSelect = "SELECT * FROM Orders";
        String inventorySelect = "SELECT * FROM Inventory";

        DataSet StoreFrontSet = new DataSet();

        using SqlDataAdapter StoreFrontAdapter = new SqlDataAdapter(StoreFrontSelect, connection);
        using SqlDataAdapter orderAdapter = new SqlDataAdapter(orderSelect, connection);
        using SqlDataAdapter inventoryAdapter = new SqlDataAdapter(inventorySelect, connection);

        StoreFrontAdapter.Fill(StoreFrontSet, "StoreFront");
        orderAdapter.Fill(StoreFrontSet, "Orders");
        inventoryAdapter.Fill(StoreFrontSet, "Inventory");

        DataTable? StoreFrontTable = StoreFrontSet.Tables["StoreFront"];
        DataTable? OrderTable = StoreFrontSet.Tables["Orders"];
        DataTable? InventoryTable = StoreFrontSet.Tables["Inventory"];
        if(StoreFrontTable != null)
        {
            foreach(DataRow row in StoreFrontTable.Rows)
            {
                StoreFront storeFront = new StoreFront();
                storeFront.StoreID = (int) row["StoreID"];
                storeFront.Name = row["Name"].ToString() ?? "";
                storeFront.Address = row["Address"].ToString() ?? "";
                if (OrderTable != null)
                {
                storeFront.Orders = OrderTable.AsEnumerable().Where(r => (int) r["StoreID"] == storeFront.StoreID).Select
                (
                    r =>
                    new Order
                    {
                        OrderID = (int) r["OrderID"],
                        CustomerID = (int) r["CustomerID"],
                        StoreID = (int) r["StoreID"],
                        Total =  (decimal) r["Total"]
                    }
                )
                .ToList();
                }
                if (InventoryTable != null)
                storeFront.Inventories = InventoryTable.AsEnumerable().Where(r => (int) r["StoreID"] == storeFront.StoreID).Select
                (
                    r => 
                    new Inventory
                    {
                        InventoryID = (int) r["InventoryID"],
                        StoreID = (int) r["StoreID"],  
                        ProductID = (int) r["ProductID"],
                        ProductName = r["Name"].ToString() ?? "",
                        ProductDescription = r["Description"].ToString() ?? "",
                        ProductPrice = (decimal) r["Price"],
                        Quantity = (int) r["Quantity"]
                    }                   
                )
                .ToList();
                allStoreFront.Add(storeFront);
            }
        }       
        return allStoreFront;
    }

    public void removeInventory(List<Inventory> allInventory, Inventory exInventory)
    {
        throw new NotImplementedException();
    }

    public void removeLineItem(List<LineItem> removeLineItem, LineItem exLineItem)
    {
        throw new NotImplementedException();
    }

    public void removeProducts(List<Product> allProducts, Product exProduct)
    {
        throw new NotImplementedException();
    }

    public void removeStoreFront(List<StoreFront> allStores, StoreFront exStore)
    {
        throw new NotImplementedException();
    }

    public void updateCustomer(List<Customer> allCustomers)
    {
        throw new NotImplementedException();
    }

    public void updateInventory(int? quantity, Inventory updateInventory)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "UPDATE Inventory SET Quantity = @quantity WHERE InventoryID = @inventoryID";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                cmd.Parameters.AddWithValue("@inventoryID", updateInventory.InventoryID);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void updateStoreFront(List<StoreFront> allStores)
    {
        throw new NotImplementedException();
    }

    public void updateOrder(decimal? totalPlus, Order updateOrder)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "UPDATE Orders SET Total = @totalPlus WHERE OrderID = @orderID";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                cmd.Parameters.AddWithValue("@orderID", updateOrder.OrderID);
                cmd.Parameters.AddWithValue("@totalPlus", totalPlus);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public StoreFront searchStoreFront(int? storeID)
    {
        string query = "Select * From StoreFront Where StoreID = @storeID";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@storeID", storeID);
        cmd.Parameters.Add(param);
        using SqlDataReader reader = cmd.ExecuteReader();
        StoreFront store = new StoreFront();
        if (reader.Read())
        {
            store.StoreID = reader.GetInt32(0);
            store.Name = reader.GetString(1);
            store.Address = reader.GetString(2);
        }
        connection.Close();
        return store;
    }
    public Product searchProduct(int? productID)
    {
        string query = "Select * From Product Where ProductID = @productID";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@productID", productID);
        cmd.Parameters.Add(param);
        using SqlDataReader reader = cmd.ExecuteReader();
        Product product = new Product();
        if (reader.Read())
        {
            product.ProductID = reader.GetInt32(0);
            product.Name = reader.GetString(1);
            product.Description = reader.GetString(2);
            product.Price = reader.GetDecimal(3);
        }
        connection.Close();
        return product;
    }
    public Inventory searchInventory(int? inventoryID)
    {
        string query = "Select * From Inventory Where InventoryID = @InventoryID";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@InventoryID", inventoryID);
        cmd.Parameters.Add(param);
        using SqlDataReader reader = cmd.ExecuteReader();
        Inventory inventory = new Inventory();
        if (reader.Read())
        {
            inventory.InventoryID = reader.GetInt32(0);
            inventory.Quantity = reader.GetInt32(1);
            inventory.ProductName = reader.GetString(2);
            inventory.ProductDescription = reader.GetString(3);
            inventory.ProductPrice = reader.GetDecimal(4);
            inventory.ProductID = reader.GetInt32(5);
            inventory.StoreID = reader.GetInt32(6);
        }
        connection.Close();
        return inventory;
    }
    public bool isDuplicate(StoreFront store)
    {
        string query = $"SELECT * FROM StoreFront WHERE Name = '{store.Name}'";
        using SqlConnection  connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand(query, connection);
        connection.Open();
        using SqlDataReader reader = cmd.ExecuteReader();
        if(reader.HasRows)
        {
            return true;
        }
        return false;
    }
    public bool isDuplicate(Product product)
    {
        string query = $"SELECT * FROM Product WHERE Name = '{product.Name}'";
        using SqlConnection  connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand(query, connection);
        connection.Open();
        using SqlDataReader reader = cmd.ExecuteReader();
        if(reader.HasRows)
        {
            return true;
        }
        return false;
    }

}