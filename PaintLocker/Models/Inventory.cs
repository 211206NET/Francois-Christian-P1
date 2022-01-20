namespace Models;

public class Inventory
{
    public int? InventoryID {get;set;}
    public int? Quantity{get;set;}
    public int? StoreID{get;set;}
    public int? ProductID{get;set;}
    public String? ProductName{get;set;}
    public String? ProductDescription{get;set;}
    public decimal? ProductPrice{get;set;}
    

    public void ToDataRow(ref DataRow row)
    {
        row["StoreID"] = this.StoreID;
        
    }

    public Inventory(DataRow row)
    {
        this.InventoryID = (int) row["InventoryID"];
        this.StoreID = (int) row["StoreID"];       
    }

    public Inventory()
    {

    }
}
