namespace Persistence;

public class OrderDetails
{
    public int OrderID{get;set;}
    public string ClothesID{get;set;} = "Unprocessed.";
    public int UnitPrice {set;get;}
    public int Quantity{get;set;}

}