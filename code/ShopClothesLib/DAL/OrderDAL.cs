using Persistence;
using MySqlConnector;
namespace DAL;

public class OrderDAL
{
    private string query = "";
    private MySqlConnection connection = DbConfig.GetConnection();
    private OrderDetailsDAL orderDetails = new OrderDetailsDAL();
    public bool InsertOrder(Order order, List<OrderDetails> ListOrderDetail)
    {
        try
        {
            query = @"INSERT INTO clothes_shop.orders (Order_ID, Customer_ID, Customer_Phone , Staff_ID, Create_at, Create_by, Total_price, status) VALUES (@orderid, @customerid, @customerphone, @staffid, now(), @createby, @totalprice, @status);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderid", order.OrderID);
            command.Parameters.AddWithValue("@customerid", order.CustomerID);
            command.Parameters.AddWithValue("@customerphone", order.customerPhone);
            command.Parameters.AddWithValue("@staffid", order.StaffID);
            command.Parameters.AddWithValue("@createby", order.CreateBy);
            command.Parameters.AddWithValue("@totalprice", order.TotalPrice);
            command.Parameters.AddWithValue("@status", order.status);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Close();
            orderDetails.InsertOrderDetails(ListOrderDetail);
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            return false;
        }
        return true;
    }

    public void updateDataMysql(List<Size_color> ListSzcl, List<OrderDetails> ListOrderDetail)
    {
        try
        {
            foreach (Size_color szcl in ListSzcl)
            {
                foreach (OrderDetails orderdetail in ListOrderDetail)
                {
                    if (szcl.clothes_ID == orderdetail.ClothesID)
                    {
                        query = "UPDATE clothes_shop.size_color SET quantity = @quantity WHERE (size_color_ID = @sizecolorid);";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        // int quantity = szcl.Quantity - orderdetail.Quantity;
                        command.Parameters.AddWithValue("@quantity", szcl.Quantity);
                        command.Parameters.AddWithValue("@sizecolorid", szcl.size_color_ID);
                        MySqlDataReader reader = command.ExecuteReader();
                        reader.Close();
                        break;
                    }
                }
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public void ViewOrderDetail(Order order, List<OrderDetails> ListOrderDetails)
    {
        List<OrderDetails> UpdateOrderDetails = new List<OrderDetails>();
        foreach (var item in ListOrderDetails)
        {
            
        }
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

    public Order createNewOrder(int customerID, string customerPhone, int staffID, string staffName, int status)
    {
        Order order = new Order();
        try
        {
            query = @"SELECT max(Order_ID) FROM clothes_shop.orders;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == false)
            {
                order.OrderID = 1;
            }else{
                order.OrderID = reader.GetInt32("max(Order_ID)") + 1;
            }
            order.CustomerID = customerID;
            order.customerPhone = customerPhone;
            order.StaffID = staffID;
            order.CreateBy = staffName;
            order.TotalPrice = 0;
            order.status = status;
            reader.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return order;
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