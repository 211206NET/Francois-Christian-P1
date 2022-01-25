namespace Models;

public class Customer
{
    public int? ID {get;set;}
    [Required]
    [RegularExpression("^[a-zA-Z0-9 ']{5,12}$", ErrorMessage = "CustomerUsername can only have alphanumeric characters and whitespace")]
    public String? Username {get;set;}
    [Required]
    [RegularExpression("^[a-zA-Z0-9 ']{5,12}$", ErrorMessage = "CustomerPassword can only have alphanumeric characters and whitespace")]
    public String? Password{get;set;}
    public List<Order>? Orders {get;set;}
    
    public void ToDataRow(ref DataRow row)
    {
        row["Username"] = this.Username;
        row["Passcode"] = this.Password;
    }
}