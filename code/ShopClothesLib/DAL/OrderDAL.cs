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
            query = @"INSERT INTO clothes_shop.orders (Order_ID, Customer_ID, Customer_Phone, Staff_ID, Create_at, Create_by, Total_price, Payment_method, status) VALUES (@orderid, @customerid, @customerphone, @staffid, @createtime, @createby, @totalprice, @paymentmethod, @status);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderid", order.OrderID);
            command.Parameters.AddWithValue("@customerid", order.CustomerID);
            command.Parameters.AddWithValue("@customerphone", order.customerPhone);
            command.Parameters.AddWithValue("@staffid", order.StaffID);
            command.Parameters.AddWithValue(@"createtime", order.CreationTime);
            command.Parameters.AddWithValue("@createby", order.CreateBy);
            command.Parameters.AddWithValue("@totalprice", order.TotalPrice);
            command.Parameters.AddWithValue("@status", order.status);
            command.Parameters.AddWithValue("@paymentmethod", order.PaymentMethod);
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

    // public List<OrderDetails> ShowOrderDetails(Order order, List<OrderDetails> ListOrderDetail, List<Clothes> listClothes, List<Size_color> listSzcl, List<Size> listSize, List<Color> listColor,List<Categories> listCategory, string CustomerName, string CustomerPhone, string NameStaff)
    // {
    //     ConsoleKeyInfo key;
    //     int count = 1, row = 1, maxRow = 0;
    //     string ClothesName ="";
    //     int price = 0, ID = 0;
    //     string size="", color="", category="", name="";
    //     Clothes clothes = new Clothes();
    //     do
    //     {
    //         Console.Clear();
    //         // row = 1;
    //         maxRow=0;
    //         Console.Write(@"
    //                 =============================================================================================================================
    //                 |                                                                                                                           |
    //                 |       ▒███████▒ ╔═╗┬  ┌─┐┌┬┐┬ ┬┌─┐┌─┐                                 ╔╗   ╦  ╦    ╦                                      |
    //                 |       ▒ ▒ ▒ ▄▀░ ║  │  │ │ │ ├─┤├┤ └─┐                                 ╠╩╗  ║  ║    ║                                      |
    //                 |       ░ ▒ ▄▀▒░  ╚═╝┴─┘└─┘ ┴ ┴ ┴└─┘└─┘                                 ╚═╝  ╩  ╩═╝  ╩═╝                                    |
    //                 |         ▄▀▒   ░   Đaã Nghĩ tới, Ngaại gì khôgn thử?                                                                       |
    //                 |       ▒███████▒ When you think about it, why don't try?                                                                   |
    //                 |       ░▒▒ ▓░▒░▒   Nơi biến polime thành trang phục.                    Order ID: {0, 3}                                      |
    //                 |       ░░▒ ▒ ░ ▒ Where to turn polymers into clothes.                                                                      |
    //                 |       ░ ░ ░ ░ ░                                                                                                           |
    //                 |         ░ ░                                                                                                               |
    //                 |       ░         [Thời gian: ......................................]                                                       |
    //                 |                                                                                                                           |
    //                 |                                                                                                                           |
    //                 |                 Customer Name   : {1, 20}                                                                    |
    //                 |                 Phone Number    : {2, 20}                                                                    |
    //                 |                 Create By Staff : {3, 20}                                                                    |
    //                 |                                                                                                                           |
    //                 |                 Address: ......................................                                                           |
    //                 |                                                                                                                           |
    //                 |       -------------------------------------------------------------------------------------------------------------       |", order.OrderID, CustomerName, CustomerPhone, NameStaff);
    //                 Console.Write(@"
    //                 |       | {0, 3} | {1, 39} | {2, 15} | {3, 18} | {4, 18} |       |
    //                 |       -------------------------------------------------------------------------------------------------------------       |", "No", "Name Clothes", "Quantity", "Unit Price", "Price");
    //         foreach (OrderDetails item in ListOrderDetail)
    //         {
    //             if (item.Quantity != 0)
    //             {
    //                 maxRow++;
    //             }
    //         }
    //         count = 1;
    //         foreach (OrderDetails orderDetails in ListOrderDetail)
    //         {
                
    //             foreach (Clothes item in listClothes)
    //             {
    //                 if (item.ID == orderDetails.ClothesID)
    //                 {
    //                     ClothesName = item.Name;
    //                     break;
    //                 }
    //             }
    //             price = orderDetails.Quantity * orderDetails.UnitPrice;
    //             if (orderDetails.Quantity != 0)
    //             {
    //                 if (count == row)
    //                 {
    //                     Console.Write(@"
    //                 |       |");
    //                     Console.ForegroundColor = ConsoleColor.DarkGreen;
    //                     Console.BackgroundColor = ConsoleColor.Cyan;
    //                     Console.Write(" {0, 3} | {1, 39} | {2, 15} | {3, 18} | {4, 18} ", count, ClothesName, orderDetails.Quantity, orderDetails.UnitPrice, price);
    //                     Console.ResetColor();
    //                     Console.Write(@"|       |");
    //                     ID = orderDetails.ClothesID;
    //                 }else
    //                 {
    //                     Console.Write(@"
    //                 |       | {0, 3} | {1, 39} | {2, 15} | {3, 18} | {4, 18} |       |", count, ClothesName, orderDetails.Quantity, orderDetails.UnitPrice, price);
    //                 }
    //                 count++;
    //             }
    //             if (count > maxRow)
    //             {
    //                 break;
    //             }
    //         }
    //         Console.Write(@"
    //                 |       -------------------------------------------------------------------------------------------------------------       |");
    //         key = Console.ReadKey(true);
    //         if (key.Key == ConsoleKey.UpArrow && row > 1)
    //         {
    //             row--;
    //         }else if(key.Key == ConsoleKey.DownArrow && row < maxRow)
    //         {
    //             row++;
    //         }else if (key.Key == ConsoleKey.Enter)
    //         {
    //             foreach (Clothes item in listClothes)
    //             {
    //                 if (item.ID == ID)
    //                 {
    //                     foreach (Categories itemCategory in listCategory)
    //                     {
    //                         if (itemCategory.ID == item.Category_ID)
    //                         {
    //                             category = itemCategory.Category_name;
    //                         }
    //                     }
    //                     name = item.Name;
    //                     break;
    //                 }
    //             }
    //             foreach (Size_color item in listSzcl)
    //             {
    //                 if (item.clothes_ID == ID)
    //                 {
    //                     foreach (Size itemSize in listSize)
    //                     {
    //                         if (itemSize.Size_ID == item.Size_ID)
    //                         {
    //                             size = itemSize.Size_Name;
    //                             break;
    //                         }
    //                     }
    //                     foreach (Color itemColor in listColor)
    //                     {
    //                         if (itemColor.Color_ID == item.Color_ID)
    //                         {
    //                             color = itemColor.Color_Name;
    //                             break;
    //                         }
    //                     }
    //                     break;
    //                 }
    //             }
    //             foreach (OrderDetails item in ListOrderDetail)
    //             {
    //                 if (item.ClothesID == ID)
    //                 {
    //                     item.Quantity = UpdateOrderDetail(ListOrderDetail, ID, size, color, category, name);
    //                 }
    //             }
    //         }else if (key.Key == ConsoleKey.Delete)
    //         {
    //             foreach (OrderDetails item in ListOrderDetail)
    //             {
    //                 if (item.ClothesID == ID)
    //                 {
    //                     item.Quantity = 0;
    //                 }
    //             }
    //         }


    //     } while (key.Key != ConsoleKey.Escape);
    //     return ListOrderDetail;
    // }

    // public int UpdateOrderDetail(List<OrderDetails> ListOrderDetail, int ClothesID, string size, string color, string category, string name)
    // {
    //     int quantity =1;
    //     int Length =0;
    //     foreach (OrderDetails orderDetail in ListOrderDetail)
    //     {
    //         if (ClothesID == orderDetail.ClothesID)
    //         {
    //             string strOrderID = Convert.ToString(orderDetail.OrderID);
    //             string strClothesID = Convert.ToString(orderDetail.ClothesID);
    //             quantity = orderDetail.Quantity;
    //             int count = 0;
    //             string strQuantity = Convert.ToString(quantity);

    //             strOrderID = addSpaceToStr(strOrderID);
    //             strClothesID = addSpaceToStr(strClothesID);
    //             size = addSpaceToStr(size);
    //             color = addSpaceToStr(color);
    //             category = addSpaceToStr(category);
    //             name = addSpaceToStr(name);

    //             Length = strQuantity.Length;

    //             ConsoleKeyInfo key;

    //             do
    //             {
    //                 string strQuantitySpace = addSpaceToStr(strQuantity+"]");
    //                 Console.Clear();
    //                 Console.Write(@"
    //                 -----------------------------------------------------------------------------------------------------------------------------
    //                 |                                                                                                                           |
    //                 |       Oder ID:               {0}      |
    //                 |       Clothes ID:            {1}      |
    //                 |       Clothes Name:          {2}      |
    //                 |       Size:                  {3}      |
    //                 |       Color:                 {4}      |
    //                 |       Category:              {5}      |
    //                 |       Quantity:             [{6}      |
    //                 |                                                                                                                           |
    //                 -----------------------------------------------------------------------------------------------------------------------------
    //                 ", strOrderID, strClothesID, name, size, color, category, strQuantitySpace);
    //                 key = Console.ReadKey(true);
    //                 if (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9 && Length < 80)
    //                 {
    //                     strQuantity += key.KeyChar;
    //                     Length++;
    //                 }else if (key.Key == ConsoleKey.Backspace && Length > 1)
    //                 {
    //                     count = strQuantity.Length;
    //                     strQuantity = strQuantity.Substring(0, count-1);
    //                     Length--;
    //                 }else if (key.Key == ConsoleKey.Backspace && Length <= 1 && Length >= 0)
    //                 {
    //                     strQuantity = "";
    //                 }
    //             } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
    //             if (strQuantity == "")
    //             {
    //                 quantity = 1;
    //             }else quantity = Convert.ToInt32(strQuantity);
                
    //         }
    //     }
    //     return quantity;
    // }

    // public string addSpaceToStr(string str)
    // {
    //     int spaceCount =  87-str.Length;
    //     string strSpace = str;
    //     for (int i = 0; i < spaceCount; i++)
    //     {
    //         strSpace = strSpace + " ";
    //     }
    //     return strSpace;
    // }
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

    // public void ViewOrderDetail(Order order, List<OrderDetails> ListOrderDetails)
    // {
    //     List<OrderDetails> UpdateOrderDetails = new List<OrderDetails>();
    //     foreach (var item in ListOrderDetails)
    //     {
            
    //     }
    // }
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

    public Order createNewOrder(int staffID, string staffName, int status)
    {
        Order order = new Order();
        try
        {
            query = @"SELECT max(Order_ID) FROM clothes_shop.orders;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                order.OrderID = reader.GetInt32("max(Order_ID)") + 1;
            }
            order.StaffID = staffID;
            order.CreateBy = staffName;
            order.TotalPrice = 0;
            order.status = status;
            order.CreationTime = DateTime.Now;
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