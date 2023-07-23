namespace Persistence;

public class Order{
    public int ID{get;set;}
    public int SellerID{get;set;}
    public int CustomerID {set;get;}
    public int ClothesID {set;get;}
    public DateTime CreationTime{get;set;}
    public string CreateBy {set;get;}
}