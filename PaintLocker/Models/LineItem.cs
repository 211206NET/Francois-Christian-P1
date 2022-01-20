namespace Models;

public class LineItem
{
    public int? LineItemID {get;set;}
    public int? Quantity{get;set;}
    public int? OrderID{get;set;}
    public int? ProductID{get;set;}
    public String? ProductName{get;set;}
    public String? ProductDescription{get;set;}
    public decimal? ProductPrice{get;set;}
    
}