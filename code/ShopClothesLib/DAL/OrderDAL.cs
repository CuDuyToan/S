using Persistence;
using MySqlConnector;
namespace DAL;

public class OrderDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    private OrderDetailsDAL orderDetails = new OrderDetailsDAL();
    public bool InsertOrder(Order order)
    {
        try
        {
            query = @"INSERT INTO `Orders`(ID, Staff_ID, Date_created, customer_ID, clothes_ID) VALUES (@id, @staffid, CURRENT_TIMESTAMP(), @customerid, clothesid);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", order.ID);
            command.Parameters.AddWithValue("@staffid", order.SellerID);
            command.Parameters.AddWithValue("@customerid", order.SellerID);
            command.Parameters.AddWithValue("@clothesid", order.SellerID);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }
    public List<Order> GetOrders()
    {
        List<Order> orders = new List<Order>();
        Order order = new Order();
        try
        {
            query = @"select ID, Staff_ID, Date_created from Orders;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                order = GetOrder(reader);
                orders.Add(order);
            }
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return orders;
    }
    public Order GetOrder(MySqlDataReader reader)
    {
        Order order = new Order();
        order.ID = reader.GetInt32("ID");
        order.SellerID = reader.GetInt32("Staff_ID");
        order.CreationTime = reader.GetDateTime("Date_created");
        order.CustomerID = reader.GetInt32("customer_ID");
        order.ClothesID = reader.GetInt32("clothes_ID");
        return order;
    }
}