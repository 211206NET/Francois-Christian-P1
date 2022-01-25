namespace Models;

public class StoreFront
{
    
    
    [Required]
    [RegularExpression("^[a-zA-Z0-9 ']+$", ErrorMessage = "StoreName can only have alphanumeric characters and whitespace")]
    public String? Name {get;set;}

    [Required]
    [RegularExpression("^[a-zA-Z0-9 ']+$", ErrorMessage = "StoreAddress can only have alphanumeric characters and whitespace")]
    public String? Address {get;set;}
    public int? StoreID {get;set;}
    public List<Inventory>? Inventories{get;set;}
    public List<Order>? Orders{get;set;}
    public StoreFront()
    {}

    public StoreFront(DataRow row)
    {
        this.StoreID = (int) row["StoreID"];
        this.Name = row["Name"].ToString() ?? "";
        this.Address = row["Address"].ToString() ?? "";
    }

    public override string ToString()
    {
        return $"Id: {this.StoreID} Name: {this.Name} Address: {this.Address} ";
    }

    
} 