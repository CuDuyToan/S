namespace Persistence;

public class Clothes
{
    public int ID { get; set; }
    public string Name { get; set; } = "Unprocessed.";
    public int Unit_price{ get; set; }
    public string Material {set;get;}  = "Unprocessed.";
    public int Category_ID {set;get;}
    public string user_manual{set;get;}="";
    public int status {set;get;}
    // public string UpdateBy {set;get;}
    // public string UpdateAt {set;get;}


    
}