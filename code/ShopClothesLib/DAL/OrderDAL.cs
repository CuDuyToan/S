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
            query = @"INSERT INTO `clothes_shop`.`orders` (`Customer_ID`, `Staff_ID`, `Create_at`, `Create_by`, `Total_price`, `status`) VALUES (@customerid, @staffid, now(), @createby, @totalprice, @status);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerid", order.CustomerID);
            command.Parameters.AddWithValue("@staffid", order.StaffID);
            command.Parameters.AddWithValue("@createby", order.CreateBy);
            command.Parameters.AddWithValue("@totalprice", order.TotalPrice);
            command.Parameters.AddWithValue("@status", order.status);
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
            query = @"SELECT * FROM clothes_shop.orders;";
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
        order.OrderID = reader.GetInt32("Order_ID");
        order.CustomerID = reader.GetInt32("Customer_ID");
        order.StaffID = reader.GetInt32("Staff_ID");
        order.CreationTime = reader.GetDateTime("Create_at");
        order.CreateBy = reader.GetString("Create_by");
        order.TotalPrice = reader.GetInt32("Total_price");
        order.status = reader.GetInt32("status");
        return order;
    }
}