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
                query = @"INSERT INTO OrderDetails(order_ID, clothes_name, clothes_quantity) VALUES (@orderid, @clothesname, @clothesquantity);";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderid", ordDetail.OrderID);
                command.Parameters.AddWithValue("@clothesname", ordDetail.ClothesName);
                command.Parameters.AddWithValue("@clothesquantity", ordDetail.ClothesQuantity);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }
    public List<OrderDetails> GetOrderDetailsByID(int orderID)
    {
        List<OrderDetails> orders = new List<OrderDetails>();
        OrderDetails ordDtls = new OrderDetails();
        try
        {
            query = @"select * from order_detail where order_ID=@orderid;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderid", orderID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ordDtls = GetOrderDetails(reader);
                orders.Add(ordDtls);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return orders;
    }
    public OrderDetails GetOrderDetails(MySqlDataReader reader)
    {
        OrderDetails odrDtls = new OrderDetails();
        odrDtls.OrderID = reader.GetInt32("order_ID");
        odrDtls.ClothesName = reader.GetString("clothes_name");
        odrDtls.ClothesQuantity = reader.GetInt32("clothes_quantity");
        odrDtls.TotalPrice = reader.GetInt32("total_price");
        return odrDtls;
    }
}