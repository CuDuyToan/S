namespace Persistence;

public class Clothes
{
    public int ID { get; set; }
    public string Size {set;get;} = "Input required";
    public string Name { get; set; } = "Unprocessed.";
    public int Price { get; set; }
    public int Quantity { get; set; }
    public string Color {set; get;} = "Input required";
    // public string UpdateBy {set;get;}
    // public string UpdateAt {set;get;}
    public string Material {set;get;}  = "Unprocessed.";
    public string Category {set;get;} = "Unprocessed.";
    
}