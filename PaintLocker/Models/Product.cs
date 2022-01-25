
namespace Models;


public class Product
{
    public int? ProductID{get;set;}
    [Required]
    [RegularExpression("^[a-zA-Z0-9 ']+$", ErrorMessage = "ProductName can only have alphanumeric characters and whitespace")]
    public String? Name {get;set;}
    [Required]
    [RegularExpression("^[a-zA-Z0-9 ']+$", ErrorMessage = "ProductDescription can only have alphanumeric characters and whitespace")]
    public String? Description {get;set;}
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
