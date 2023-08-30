using Persistence;
using MySqlConnector;
namespace DAL;

public class OrderDetailsDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    public bool InsertOrderDetails(List<OrderDetails> orderDetails)
    {
        try
        {
            foreach (OrderDetails ordDetail in orderDetails)
            {
                query = @"insert into clothes_shop.orderdetails(Order_ID, Clothes_ID, Unit_price, Quantity) values (@orderid, @clothesid, @unitprice, @clothesquantity);";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderid", ordDetail.OrderID);
                command.Parameters.AddWithValue("@clothesid", ordDetail.ClothesID);
                command.Parameters.AddWithValue("@unitprice", ordDetail.UnitPrice);
                command.Parameters.AddWithValue("@clothesquantity", ordDetail.Quantity);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            return false;
        }
        return true;
    }
    
    public OrderDetails AddClothesToOrder(int orderID, int clothesID, int unitPrice, int Quantity)
    {
        OrderDetails odrDtls = new OrderDetails();
        odrDtls.OrderID = orderID;
        odrDtls.ClothesID = clothesID;
        odrDtls.UnitPrice = unitPrice;
        odrDtls.Quantity = Quantity;
        return odrDtls;
    }
}