namespace Persistence;

public class OrderDetails
{
    public int ID {set;get;}
    public int OrderID{get;set;}
    public string ClothesName{get;set;} = "Unprocessed.";
    public int ClothesQuantity{get;set;}
    public int TotalPrice{get;set;} 
    public int UnitPrice {set;get;}
}