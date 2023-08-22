namespace Persistence;

public class Order{
    public int OrderID{get;set;}
    public int CustomerID {set;get;}
    public string customerPhone {set; get;}
    public int StaffID{get;set;}
    public DateTime CreationTime{get;set;}
    public string CreateBy {set;get;} = "Unprocessed.";
    public int TotalPrice {set;get;}
    public int status {set;get;}
    public string PaymentMethod {set;get;}
}