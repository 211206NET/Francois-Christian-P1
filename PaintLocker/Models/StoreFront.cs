namespace Models;

public class StoreFront
{
    
    private string? _name;
    public String? Name
    {
        get => _name;
        set 
        {
            Regex pattern = new Regex("^[a-zA-Z0-9 ']+$");
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InputInvalidException("No input entered");
            }
            else if (!pattern.IsMatch(value))
            {
                throw new InputInvalidException("Store name can only have alphanumeric characters, white space, and '");
            }
            else 
            {
                this._name = value;
            }
        }
    }

    private string? _address;
    public String? Address
    {
        get => _address;
        set
        {
            Regex pattern = new Regex("^[a-zA-Z0-9 ']+$");
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InputInvalidException("No input entered");
            }
            else if (!pattern.IsMatch(value))
            {
                throw new InputInvalidException("Address can only have alphanumeric characters and whitespace");
            }
            else 
            {
                this._address = value;
            }
        }
    }
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