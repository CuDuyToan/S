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
        odrDtls.ClothesID = reader.GetInt32("clothes_ID");
        odrDtls.UnitPrice = reader.GetInt32("clothes_quantity");
        odrDtls.Quantity = reader.GetInt32("total_price");
        return odrDtls;
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