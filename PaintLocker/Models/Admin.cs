namespace Models;

public class Admin
{
    public int? ID {get;set;}
    public String? Username {get;set;}
    public String? Password {get;set;}
    public List<Order>? Orders {get;set;}
    
}