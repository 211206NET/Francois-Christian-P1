namespace Models;

public class Order
{
    //public DateOnly OrderDate {get;set;}
    public int? OrderID {get;set;}
    public decimal? Total {get;set;}
    public int? CustomerID {get;set;}
    public int? StoreID {get;set;}
    
    public List<LineItem>? LineItems {get;set;}
    
    
    

    
        

}


