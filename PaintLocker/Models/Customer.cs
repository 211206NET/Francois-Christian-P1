namespace Models;

public class Customer
{
    public int? ID {get;set;}
    private string? _userName{get;set;}
    public String? Username
    {
        get => _userName;
        set
        {
            Regex pattern = new Regex("^[a-zA-Z0-9 ']{5,12}$");
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InputInvalidException("No input entered");
            }
            else if (!pattern.IsMatch(value))
            {
                throw new InputInvalidException("Customer username can only have alphanumerical characters, white space, ', and must be within 5 - 12 characters");
            }
            else 
            {
                this._userName = value;
            }
        }
    }
    private string? _password{get;set;}
    public String? Password
    {
        get => _password;
        set
        {
            Regex pattern = new Regex("^[a-zA-Z0-9 ']{5,12}$");
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InputInvalidException("No input entered");
            }
            else if (!pattern.IsMatch(value))
            {
                throw new InputInvalidException("Customer password can only have alphanumerical characters, white space, ', and must be within 5 - 12 characters");
            }
            else 
            {
                this._password = value;
            }
        }
        

        
    }
    public List<Order>? Orders {get;set;}
    
    public void ToDataRow(ref DataRow row)
    {
        row["Username"] = this.Username;
        row["Passcode"] = this.Password;
    }
}