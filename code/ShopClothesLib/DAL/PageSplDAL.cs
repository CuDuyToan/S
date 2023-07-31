using Persistence;
using MySqlConnector;
namespace DAL;

public class PageSplDAL
{
    public rowPageSpl updatePageSpl(int No, int ID, string Name, string Size, string Color, int Unit_price)
    {
        rowPageSpl rowPageSpl = new rowPageSpl();
        rowPageSpl.No = No;
        rowPageSpl.ID = ID;
        rowPageSpl.Name =Name;
        rowPageSpl.Size =Size;
        rowPageSpl.Color =Color;
        rowPageSpl.Unit_price =Unit_price;
        return rowPageSpl;
    }
}