
namespace Models;


public class Product
{
    public int? ProductID{get;set;}
    private string? _name{get;set;}
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
                throw new InputInvalidException("Product name can only have alphanumerical characters, white space, and '");
            }
            else 
            {
                this._name = value;
            }
        }
    }
    private string? _description{get;set;} 
    public String? Description
    {
        get => _description;
        set
        {          
            Regex pattern = new Regex("^[a-zA-Z ']+$");
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InputInvalidException("No input entered");
            }
            else if (!pattern.IsMatch(value))
            {
                throw new InputInvalidException("Description can only have alphabet characters, white space, and '");
            }
            else 
            {
                this._description = value;
            }
        }
    }
    private decimal? _price{get;set;}
    public decimal? Price
    {
        get => _price;
        set
        {
            if(value < 0)
            {
                throw new InputInvalidException("Price must be greater than 0");
            }
            else
            {
                this._price = value;
            }
        }
    }

    public override string ToString()
    {
        return $"Id: {this.ProductID} Name: {this.Name} Description: {this.Description} Price: {this.Price}";
    }
}
